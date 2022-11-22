using Alize.Platform.Core.Models;
using Alize.Platform.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Alize.Platform.Core.Constants;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Options;
using Alize.Platform.Infrastructure.Options;
using Newtonsoft.Json.Linq;
using System;
using Alize.Platform.Core.Exceptions;

namespace Alize.Platform.Infrastructure.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IModuleRepository _moduleRepository;
        private readonly EmailOptions _emailSettings;

        public SecurityService(UserManager<User> userManager, RoleManager<Role> roleManager, IModuleRepository moduleRepository, IConfiguration configuration, IOptions<EmailOptions> emailSettings)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _moduleRepository = moduleRepository;
            _emailSettings = emailSettings.Value;
        }

        public async Task SetUserRoleAsync(string userId, string roleId)
        {
            var user = await _userManager.FindByIdAsync(userId) ?? throw new KeyNotFoundException(userId);
            var role = await _roleManager.FindByIdAsync(roleId) ?? throw new KeyNotFoundException(roleId);

            var userRoles = await _userManager.GetRolesAsync(user);

            await _userManager.UpdateSecurityStampAsync(user);
            await _userManager.RemoveFromRolesAsync(user, userRoles);
            await _userManager.AddToRoleAsync(user, role.Name);
        }

        public async Task<string> LoginUserWithEmail(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user is null || !user.IsActive || !await _userManager.CheckPasswordAsync(user, password))
                throw new UnauthorizedAccessException();

            var roles = await _userManager.GetRolesAsync(user);

            var modules = await _moduleRepository.GetModulesForRoleAsync(roles.Single());

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Role, roles.Single())
            };

            foreach (var module in modules)
            {
                claims.Add(new Claim("module", module.Name));
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(720),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }

        public async Task UpdateUserPasswordAsync(User user, string newPassword)
        {
            await _userManager.RemovePasswordAsync(user);
            await _userManager.AddPasswordAsync(user, newPassword);
        }

        public async Task<IEnumerable<User>> GetUserListForUserAsync(Guid userId)
        {
            var user = await _userManager.Users
                .Include(u => u.Roles)
                .SingleAsync(u => u.Id == userId);

            var usersQuery = _userManager.Users
                    .Include(u => u.Applications)
                    .Include(u => u.Company)
                    .Include(u => u.Roles);

            return user.Role?.Name switch
            {
                Roles.AdminPro => await usersQuery.ToListAsync(),
                Roles.Distributor => await usersQuery
                        .Where(u => u.CompanyId == user.CompanyId || u.Company.ParentCompanyId == user.CompanyId)
                        .Where(u => u.Roles.All(r => r.Name != Roles.AdminPro))
                        .ToListAsync(),
                Roles.Admin => await usersQuery
                        .Where(u => u.CompanyId == user.CompanyId)
                        .Where(u => u.Roles.All(r => r.Name != Roles.AdminPro))
                        .ToListAsync(),
                _ => new List<User>() { user }
            };
        }

        public async Task<User?> GetUserAsync(string id)
        {
            return await _userManager.Users
                .Include(u => u.Company)
                .Include(u => u.Applications)
                .Include(u => u.Roles)
                .ThenInclude(r => r.Modules)
                .SingleOrDefaultAsync(u => u.Id.ToString() == id);
        }

        public async Task<User?> GetUserAsync(Guid id) => await this.GetUserAsync(id.ToString());

        public async Task<User> RegisterUserAsync(User user, string password)
        {
            var result = await _userManager.CreateAsync(user);

            if (result.Succeeded)
            {
                result = await _userManager.AddPasswordAsync(user, password);

                if (result.Succeeded)
                {
                    return user;
                }

                await _userManager.DeleteAsync(user);
            }

            throw new ApplicationException();
        }

        public async Task UpdateUserAsync(User user) => await _userManager.UpdateAsync(user);

        public async Task<IEnumerable<Role>> GetRolesAsync()
        {
            return await _roleManager.Roles.ToListAsync();
        }

        public async Task<IEnumerable<Role>> GetRolesForUserAsync(Guid userId)
        {
            var user = await _userManager.Users
                .Include(u => u.Roles)
                .SingleAsync(u => u.Id == userId);

            var rolesQuery = _roleManager.Roles;

            return user.Role?.Name switch
            {
                Roles.AdminPro => await rolesQuery.ToListAsync(),
                Roles.Distributor or
                Roles.Admin => await rolesQuery
                        .Where(r => r.Name != Roles.AdminPro)
                        .ToListAsync(),
                _ => new List<Role>() { user.Role }
            };
        }

        public async Task<Role?> GetRoleAsync(Guid guid)
        {
            return await _roleManager.Roles.Include(r => r.Modules).SingleOrDefaultAsync(r => r.Id == guid);
        }

        public async Task UpdateRoleAsync(Role role)
        {
            await _roleManager.UpdateAsync(role);
        }

        public bool VerifyRolePermit(string currentRole, string toChangeRole)
        {
            List<string> roles = new List<string>() { Roles.AdminPro.ToLower(), Roles.Distributor.ToLower(), Roles.Admin.ToLower() };
            int indexCurrent = roles.IndexOf(currentRole.ToLower());
            if (indexCurrent < 0) return false;
            int indexChangeRole = roles.IndexOf(toChangeRole);

            if (indexCurrent >= 0 && indexCurrent < indexChangeRole) return false;

            return true;
        }

        public async Task DeleteUserAsync(User user)
        {
            await _userManager.DeleteAsync(user);
        }

        public async Task RecoverUserPasswordAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user is null) 
                throw new NotFountException<User>();

            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

            var username = _emailSettings.Username;
            var password = _emailSettings.Password;

            var host = _emailSettings.Host;
            var port = _emailSettings.Port;

            var mail = new MailMessage();
            mail.From = new MailAddress(_emailSettings.SenderEmail);
            mail.To.Add(new MailAddress(email));
            mail.Subject = "Recover Password";
            mail.IsBodyHtml = true;
            mail.Body = $@"
                <!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
                <html xmlns=""http://www.w3.org/1999/xhtml"">
                    <head>
                    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"" />
                    <meta name=""x-apple-disable-message-reformatting"" />
                    <meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8"" />
                    <meta name=""color-scheme"" content=""light dark"" />
                    <meta name=""supported-color-schemes"" content=""light dark"" />
                    <title></title>
                    <style type=""text/css"" rel=""stylesheet"" media=""all"">
                    /* Base ------------------------------ */
    
                    @import url(""https://fonts.googleapis.com/css?family=Nunito+Sans:400,700&display=swap"");
                    body {{
                        width: 100% !important;
                        height: 100%;
                        margin: 0;
                        -webkit-text-size-adjust: none;
                    }}
    
                    a {{
                        color: #3869D4;
                    }}
    
                    a img {{
                        border: none;
                    }}
    
                    td {{
                        word-break: break-word;
                    }}
    
                    .preheader {{
                        display: none !important;
                        visibility: hidden;
                        mso-hide: all;
                        font-size: 1px;
                        line-height: 1px;
                        max-height: 0;
                        max-width: 0;
                        opacity: 0;
                        overflow: hidden;
                    }}
                    /* Type ------------------------------ */
    
                    body,
                    td,
                    th {{
                        font-family: ""Nunito Sans"", Helvetica, Arial, sans-serif;
                    }}
    
                    h1 {{
                        margin-top: 0;
                        color: #333333;
                        font-size: 22px;
                        font-weight: bold;
                        text-align: left;
                    }}
    
                    h2 {{
                        margin-top: 0;
                        color: #333333;
                        font-size: 16px;
                        font-weight: bold;
                        text-align: left;
                    }}
    
                    h3 {{
                        margin-top: 0;
                        color: #333333;
                        font-size: 14px;
                        font-weight: bold;
                        text-align: left;
                    }}
    
                    td,
                    th {{
                        font-size: 16px;
                    }}
    
                    p,
                    ul,
                    ol,
                    blockquote {{
                        margin: .4em 0 1.1875em;
                        font-size: 16px;
                        line-height: 1.625;
                    }}
    
                    p.sub {{
                        font-size: 13px;
                    }}
                    /* Utilities ------------------------------ */
    
                    .align-right {{
                        text-align: right;
                    }}
    
                    .align-left {{
                        text-align: left;
                    }}
    
                    .align-center {{
                        text-align: center;
                    }}
    
                    .u-margin-bottom-none {{
                        margin-bottom: 0;
                    }}
                    /* Buttons ------------------------------ */
    
                    .button {{
                        background-color: #3869D4;
                        border-top: 10px solid #3869D4;
                        border-right: 18px solid #3869D4;
                        border-bottom: 10px solid #3869D4;
                        border-left: 18px solid #3869D4;
                        display: inline-block;
                        color: #FFF;
                        text-decoration: none;
                        border-radius: 3px;
                        box-shadow: 0 2px 3px rgba(0, 0, 0, 0.16);
                        -webkit-text-size-adjust: none;
                        box-sizing: border-box;
                    }}
    
                    .button--green {{
                        background-color: #22BC66;
                        border-top: 10px solid #22BC66;
                        border-right: 18px solid #22BC66;
                        border-bottom: 10px solid #22BC66;
                        border-left: 18px solid #22BC66;
                    }}
    
                    .button--red {{
                        background-color: #FF6136;
                        border-top: 10px solid #FF6136;
                        border-right: 18px solid #FF6136;
                        border-bottom: 10px solid #FF6136;
                        border-left: 18px solid #FF6136;
                    }}
    
                    @media only screen and (max-width: 500px) {{
                        .button {{
                        width: 100% !important;
                        text-align: center !important;
                        }}
                    }}
                    /* Attribute list ------------------------------ */
    
                    .attributes {{
                        margin: 0 0 21px;
                    }}
    
                    .attributes_content {{
                        background-color: #F4F4F7;
                        padding: 16px;
                    }}
    
                    .attributes_item {{
                        padding: 0;
                    }}
                    /* Related Items ------------------------------ */
    
                    .related {{
                        width: 100%;
                        margin: 0;
                        padding: 25px 0 0 0;
                        -premailer-width: 100%;
                        -premailer-cellpadding: 0;
                        -premailer-cellspacing: 0;
                    }}
    
                    .related_item {{
                        padding: 10px 0;
                        color: #CBCCCF;
                        font-size: 15px;
                        line-height: 18px;
                    }}
    
                    .related_item-title {{
                        display: block;
                        margin: .5em 0 0;
                    }}
    
                    .related_item-thumb {{
                        display: block;
                        padding-bottom: 10px;
                    }}
    
                    .related_heading {{
                        border-top: 1px solid #CBCCCF;
                        text-align: center;
                        padding: 25px 0 10px;
                    }}
                    /* Discount Code ------------------------------ */
    
                    .discount {{
                        width: 100%;
                        margin: 0;
                        padding: 24px;
                        -premailer-width: 100%;
                        -premailer-cellpadding: 0;
                        -premailer-cellspacing: 0;
                        background-color: #F4F4F7;
                        border: 2px dashed #CBCCCF;
                    }}
    
                    .discount_heading {{
                        text-align: center;
                    }}
    
                    .discount_body {{
                        text-align: center;
                        font-size: 15px;
                    }}
                    /* Social Icons ------------------------------ */
    
                    .social {{
                        width: auto;
                    }}
    
                    .social td {{
                        padding: 0;
                        width: auto;
                    }}
    
                    .social_icon {{
                        height: 20px;
                        margin: 0 8px 10px 8px;
                        padding: 0;
                    }}
                    /* Data table ------------------------------ */
    
                    .purchase {{
                        width: 100%;
                        margin: 0;
                        padding: 35px 0;
                        -premailer-width: 100%;
                        -premailer-cellpadding: 0;
                        -premailer-cellspacing: 0;
                    }}
    
                    .purchase_content {{
                        width: 100%;
                        margin: 0;
                        padding: 25px 0 0 0;
                        -premailer-width: 100%;
                        -premailer-cellpadding: 0;
                        -premailer-cellspacing: 0;
                    }}
    
                    .purchase_item {{
                        padding: 10px 0;
                        color: #51545E;
                        font-size: 15px;
                        line-height: 18px;
                    }}
    
                    .purchase_heading {{
                        padding-bottom: 8px;
                        border-bottom: 1px solid #EAEAEC;
                    }}
    
                    .purchase_heading p {{
                        margin: 0;
                        color: #85878E;
                        font-size: 12px;
                    }}
    
                    .purchase_footer {{
                        padding-top: 15px;
                        border-top: 1px solid #EAEAEC;
                    }}
    
                    .purchase_total {{
                        margin: 0;
                        text-align: right;
                        font-weight: bold;
                        color: #333333;
                    }}
    
                    .purchase_total--label {{
                        padding: 0 15px 0 0;
                    }}
    
                    body {{
                        background-color: #F2F4F6;
                        color: #51545E;
                    }}
    
                    p {{
                        color: #51545E;
                    }}
    
                    .email-wrapper {{
                        width: 100%;
                        margin: 0;
                        padding: 0;
                        -premailer-width: 100%;
                        -premailer-cellpadding: 0;
                        -premailer-cellspacing: 0;
                        background-color: #F2F4F6;
                    }}
    
                    .email-content {{
                        width: 100%;
                        margin: 0;
                        padding: 0;
                        -premailer-width: 100%;
                        -premailer-cellpadding: 0;
                        -premailer-cellspacing: 0;
                    }}
                    /* Masthead ----------------------- */
    
                    .email-masthead {{
                        padding: 25px 0;
                        text-align: center;
                    }}
    
                    .email-masthead_logo {{
                        width: 94px;
                    }}
    
                    .email-masthead_name {{
                        font-size: 16px;
                        font-weight: bold;
                        color: #A8AAAF;
                        text-decoration: none;
                        text-shadow: 0 1px 0 white;
                    }}
                    /* Body ------------------------------ */
    
                    .email-body {{
                        width: 100%;
                        margin: 0;
                        padding: 0;
                        -premailer-width: 100%;
                        -premailer-cellpadding: 0;
                        -premailer-cellspacing: 0;
                    }}
    
                    .email-body_inner {{
                        width: 570px;
                        margin: 0 auto;
                        padding: 0;
                        -premailer-width: 570px;
                        -premailer-cellpadding: 0;
                        -premailer-cellspacing: 0;
                        background-color: #FFFFFF;
                    }}
    
                    .email-footer {{
                        width: 570px;
                        margin: 0 auto;
                        padding: 0;
                        -premailer-width: 570px;
                        -premailer-cellpadding: 0;
                        -premailer-cellspacing: 0;
                        text-align: center;
                    }}
    
                    .email-footer p {{
                        color: #A8AAAF;
                    }}
    
                    .body-action {{
                        width: 100%;
                        margin: 30px auto;
                        padding: 0;
                        -premailer-width: 100%;
                        -premailer-cellpadding: 0;
                        -premailer-cellspacing: 0;
                        text-align: center;
                    }}
    
                    .body-sub {{
                        margin-top: 25px;
                        padding-top: 25px;
                        border-top: 1px solid #EAEAEC;
                    }}
    
                    .content-cell {{
                        padding: 45px;
                    }}
                    /*Media Queries ------------------------------ */
    
                    @media only screen and (max-width: 600px) {{
                        .email-body_inner,
                        .email-footer {{
                        width: 100% !important;
                        }}
                    }}
    
                    @media (prefers-color-scheme: dark) {{
                        body,
                        .email-body,
                        .email-body_inner,
                        .email-content,
                        .email-wrapper,
                        .email-masthead,
                        .email-footer {{
                        background-color: #333333 !important;
                        color: #FFF !important;
                        }}
                        p,
                        ul,
                        ol,
                        blockquote,
                        h1,
                        h2,
                        h3,
                        span,
                        .purchase_item {{
                        color: #FFF !important;
                        }}
                        .attributes_content,
                        .discount {{
                        background-color: #222 !important;
                        }}
                        .email-masthead_name {{
                        text-shadow: none !important;
                        }}
                    }}
    
                    :root {{
                        color-scheme: light dark;
                        supported-color-schemes: light dark;
                    }}
                    </style>
                    <!--[if mso]>
                    <style type=""text/css"">
                        .f-fallback  {{
                        font-family: Arial, sans-serif;
                        }}
                    </style>
                    <![endif]-->
                    </head>
                    <body>
                    <span class=""preheader"">Use this link to reset your password. The link is only valid for 24 hours.</span>
                    <table class=""email-wrapper"" width=""100%"" cellpadding=""0"" cellspacing=""0"" role=""presentation"">
                        <tr>
                        <td align=""center"">
                            <table class=""email-content"" width=""100%"" cellpadding=""0"" cellspacing=""0"" role=""presentation"">
                            <tr>
                                <td class=""email-masthead"">
                                <a href=""{_emailSettings.Client}"" class=""f-fallback email-masthead_name"">
                                Alize
                                </a>
                                </td>
                            </tr>
                            <!-- Email Body -->
                            <tr>
                                <td class=""email-body"" width=""570"" cellpadding=""0"" cellspacing=""0"">
                                <table class=""email-body_inner"" align=""center"" width=""570"" cellpadding=""0"" cellspacing=""0"" role=""presentation"">
                                    <!-- Body content -->
                                    <tr>
                                    <td class=""content-cell"">
                                        <div class=""f-fallback"">
                                        <h1>Hi {user.FirstName},</h1>
                                        <p>You recently requested to reset your password for your Alize account. Use the button below to reset it. <strong>This password reset is only valid for the next 24 hours.</strong></p>
                                        <!-- Action -->
                                        <table class=""body-action"" align=""center"" width=""100%"" cellpadding=""0"" cellspacing=""0"" role=""presentation"">
                                            <tr>
                                            <td align=""center"">
                                                <!-- Border based button
                            https://litmus.com/blog/a-guide-to-bulletproof-buttons-in-email-design -->
                                                <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" role=""presentation"">
                                                <tr>
                                                    <td align=""center"">
                                                    <a href=""{_emailSettings.Client}/password-reset?email={email}&token={resetToken}"" class=""f-fallback button button--green"" target=""_blank"">Reset your password</a>
                                                    </td>
                                                </tr>
                                                </table>
                                            </td>
                                            </tr>
                                        </table>
                                        <p>If you did not request a password reset, please ignore this email or <a href=""{{{{support_url}}}}"">contact support</a> if you have questions.</p>
                                        <p>Thanks,
                                            <br>The Alize team</p>
                                        <!-- Sub copy -->
                                        <table class=""body-sub"" role=""presentation"">
                                            <tr>
                                            <td>
                                                <p class=""f-fallback sub"">If you’re having trouble with the button above, copy and paste the URL below into your web browser.</p>
                                                <p class=""f-fallback sub"">{_emailSettings.Client}/password-reset?email={email}&token={resetToken}</p>
                                            </td>
                                            </tr>
                                        </table>
                                        </div>
                                    </td>
                                    </tr>
                                </table>
                                </td>
                            </tr>
                            </table>
                        </td>
                        </tr>
                    </table>
                    </body>
                </html>
            ";

            using var client = new SmtpClient(host, port)
            {
                Credentials = new NetworkCredential(username, password),
                EnableSsl = true
            };            

            client.Send(mail);
        }

        public async Task ResetUserPasswordAsync(string email, string token, string newPassword)
        {
            var user = await _userManager.FindByEmailAsync(email);
            await _userManager.ResetPasswordAsync(user, token, newPassword);
        }
    }
}
