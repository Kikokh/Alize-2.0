using Alize.Platform.Api.Mapping;
using Alize.Platform.Api.Policies;
using Alize.Platform.Core.Constants;
using Alize.Platform.Core.Models;
using Alize.Platform.Infrastructure;
using Alize.Platform.Infrastructure.Alastria;
using Alize.Platform.Infrastructure.Extensions;
using Alize.Platform.Infrastructure.Repositories;
using Alize.Platform.Infrastructure.Services;
using Alize.Platform.Infrastructure.Services.BlockchainFue;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddSqlServer<ApplicationDbContext>(connectionString)
    .AddIdentityCore<User>()
    .AddRoles<Role>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Default",
    builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});

builder.Services
    .AddHttpContextAccessor()
    .AddAuthorization(options =>
    {
        options.AddPolicy(Modules.Applications, policy => policy.Requirements.Add(new ModuleRequirement(Modules.Applications)));
        options.AddPolicy(Modules.Companies, policy => policy.Requirements.Add(new ModuleRequirement(Modules.Companies)));
        options.AddPolicy(Modules.Roles, policy => policy.Requirements.Add(new ModuleRequirement(Modules.Roles)));
        options.AddPolicy(Modules.ModuleAdmin, policy => policy.Requirements.Add(new ModuleRequirement(Modules.ModuleAdmin)));
        options.AddPolicy(Modules.Users, policy => policy.Requirements.Add(new ModuleRequirement(Modules.Users)));
        options.AddPolicy(Modules.Alerts, policy => policy.Requirements.Add(new ModuleRequirement(Modules.Alerts)));
        options.AddPolicy(Modules.Queries, policy => policy.Requirements.Add(new QueryRequirement(Modules.Applications)));
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

//builder.Services.AddHangfire(configuration => configuration
//.UseMemoryStorage());

//builder.Services.AddHangfireServer();

builder.Services.InitializeCosmosClientInstance(builder.Configuration.GetSection("CosmosDb"));
builder.Services.InitializeBlobServiceClientInstance(builder.Configuration.GetConnectionString("BlobStorage"));
builder.Services.AddHttpClient();
builder.Services.AddHttpClient("HttpClientWithSSLUntrusted").ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
{
    ClientCertificateOptions = ClientCertificateOption.Manual,
    ServerCertificateCustomValidationCallback =
            (httpRequestMessage, cert, cetChain, policyErrors) =>
            {
                return true;
            }
});
builder.Services.AddDataProtection()
    .PersistKeysToDbContext<ApplicationDbContext>();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddScoped<IAuthorizationHandler, ModuleHandler>();
builder.Services.AddScoped<IAuthorizationHandler, QueryHandler>();
builder.Services.AddAutoMapper(typeof(MappingProfile), typeof(AlastriaMappingProfile));

builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
builder.Services.AddScoped<IApplicationCredentialsRepository, ApplicationCredentialsRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IModuleRepository, ModuleRepository>();
builder.Services.AddScoped<IImageRepository, MediaRepository>();
builder.Services.AddScoped<IVideoRepository, MediaRepository>();
builder.Services.AddScoped<IBlockchainRepository, BlockchainRepository>();
builder.Services.AddScoped<IRequestLogEntryRepository, RequestLogEntryRepository>();
builder.Services.AddScoped<ICosmosRepositoryFactory, CosmosRepositoryFactory>();
builder.Services.AddScoped<IBlockchainService, AlastriaService>();
builder.Services.AddScoped<IBlockchainService, BlockchainFueService>();
builder.Services.AddScoped<ISecurityService, SecurityService>();
builder.Services.AddScoped<ICryptographyService, CryptographyService>();
builder.Services.AddScoped<IBlockchainFactory, BlockchainFactory>();

builder.Services.AddControllers().AddJsonOptions(
    x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
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
    app.UseSwaggerUI(
        c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            c.RoutePrefix = "";
        });

    //app.UseHangfireDashboard();
}

app.UseHttpsRedirection();

app.UseCors("Default");
app.UseAuthentication();
app.UseAuthorization();

//app.MapHangfireDashboard();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    //db.Database.EnsureDeleted();
    db.Database.Migrate();
}

//RecurringJob.AddOrUpdate<BlockchainInsertService>(x => x.PersistAssetsAsync(), Cron.Minutely);

app.Run();
