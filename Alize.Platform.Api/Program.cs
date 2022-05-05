using Alize.Platform.Api.Extensions;
using Alize.Platform.Api.Policies;
using Alize.Platform.Data;
using Alize.Platform.Data.Constants;
using Alize.Platform.Data.Models;
using Alize.Platform.Data.Repositories;
using Alize.Platform.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddSqlServer<ApplicationDbContext>(connectionString)
    .AddIdentityCore<User>()
    .AddRoles<Role>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services
    .AddHttpContextAccessor()
    .AddAuthorization(options =>
    {
        options.AddPolicy(Modules.Applications, policy => policy.Requirements.Add(new ModuleRequirement(Modules.Applications)));
        options.AddPolicy(Modules.Companies, policy => policy.Requirements.Add(new ModuleRequirement(Modules.Companies)));
        options.AddPolicy(Modules.Groups, policy => policy.Requirements.Add(new ModuleRequirement(Modules.Groups)));
        options.AddPolicy(Modules.ModuleAdmin, policy => policy.Requirements.Add(new ModuleRequirement(Modules.ModuleAdmin)));
        options.AddPolicy(Modules.Users, policy => policy.Requirements.Add(new ModuleRequirement(Modules.Users)));
        options.AddPolicy(Modules.Alerts, policy => policy.Requirements.Add(new ModuleRequirement(Modules.Alerts)));
        options.AddPolicy(Modules.Queries, policy => policy.Requirements.Add(new ModuleRequirement(Modules.Queries)));
        options.AddPolicy(Modules.ControlPanel, policy => policy.Requirements.Add(new ModuleRequirement(Modules.ControlPanel)));
        options.AddPolicy(Modules.UserAudit, policy => policy.Requirements.Add(new ModuleRequirement(Modules.UserAudit)));
        options.AddPolicy(Modules.TransactionLog, policy => policy.Requirements.Add(new ModuleRequirement(Modules.TransactionLog)));
        options.AddPolicy(Modules.Help, policy => policy.Requirements.Add(new ModuleRequirement(Modules.Help)));
    })
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

builder.Services.InitializeCosmosClientInstance(builder.Configuration.GetSection("CosmosDb"));
builder.Services.AddHttpClient();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddScoped<IAuthorizationHandler, ModuleHandler>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IModuleRepository, ModuleRepository>();
builder.Services.AddScoped<IBlockChainService, BlockChainFueService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
         {
               new OpenApiSecurityScheme
               {
                   Reference = new OpenApiReference
                   {
                       Type = ReferenceType.SecurityScheme,
                       Id = "Bearer"
                   }
               },
               new string[] {}
         }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    //db.Database.EnsureDeleted();
    db.Database.Migrate();
}

app.Run();
