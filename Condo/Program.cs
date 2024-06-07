using System.Security.Claims;
using System.Text;
using Condo.Context;
using Condo.Context.Interfaces;
using Condo.Filters;
using Condo.Repository;
using Condo.Repository.Interfaces;
using Condo.UseCases;
using Condo.UseCases.AccessControl.ChangeAccessRelease;
using Condo.UseCases.AccessControl.CreateAccessRelease;
using Condo.UseCases.AccessControl.GetAccessReleaseByCondominium;
using Condo.UseCases.AccessControl.GetAccessReleaseById;
using Condo.UseCases.Interfaces;
using Condo.UseCases.MailService.SendAccessCreatedMail;
using Condo.UseCases.MailService.SendEmail;
using Condo.UseCases.MailService.SendUserCreatedMail;
using Condo.UseCases.MailService.SendUserVerifiedMail;
using Condo.UseCases.People.CreatePerson;
using Condo.UseCases.Users.ChangePassword;
using Condo.UseCases.Users.CreateUser;
using Condo.UseCases.Users.Login;
using Condo.UseCases.Users.VerifyUser;
using Condo.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => {
    options.Filters.Add<ExceptionFilter>();
});

builder.Services.Configure<ApiBehaviorOptions>(options => {
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DatabaseContext>();
builder.Services.AddScoped<IDatabaseContext, DatabaseContext>();
builder.Services.AddScoped<ICondominiumRepository, CondominiumRepository>();
builder.Services.AddScoped<ICondominiumUseCase, CondominiumUseCase>();
builder.Services.AddScoped<IUnityRepository, UnityRepository>();
builder.Services.AddScoped<IUnityUseCase, UnityUseCase>();
builder.Services.AddScoped<IResidentUseCase, ResidentUseCase>();
builder.Services.AddScoped<IResidentRepository, ResidentRepository>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICreateUser, CreateUser>();
builder.Services.AddScoped<IVerifyUser, VerifyUser>();
builder.Services.AddScoped<IChangePasswordUser, ChangePasswordUser>();
builder.Services.AddScoped<ILoginUser, LoginUser>();
builder.Services.AddScoped<ICreatePerson, CreatePerson>();

builder.Services.AddScoped<IAccessRepository, AccessRepository>();
builder.Services.AddScoped<ICreateAccessRelease, CreateAccessRelease>();
builder.Services.AddScoped<IChangeAccessRelease, ChangeAccessRelease>();
builder.Services.AddScoped<IGetAccessReleaseByCondominium, GetAccessReleaseByCondominium>();
builder.Services.AddScoped<IGetAccessReleaseById, GetAccessReleaseById>();

builder.Services.AddHttpClient<ISendEmail, SendEmail>();
builder.Services.AddScoped<ISendUserCreatedMail, SendUserCreatedMail>();
builder.Services.AddScoped<ISendUserVerifiedMail, SendUserVerifiedMail>();
builder.Services.AddScoped<ISendAccessCreatedMail, SendAccessCreatedMail>();

builder.Services.AddScoped<ValidationFilter>();

builder.Services.AddAutoMapper(typeof(MapperProfile));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("4d82a63bbdc67c1e4784ed6587f3730c"))
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Administrator", policy => policy.RequireClaim(ClaimTypes.Email).RequireClaim(ClaimTypes.Role, "Administrator"));
    options.AddPolicy("Employee", policy => policy.RequireClaim(ClaimTypes.Email).RequireClaim(ClaimTypes.Role, "Employee"));
    options.AddPolicy("Resident", policy => policy.RequireClaim(ClaimTypes.Email).RequireClaim(ClaimTypes.Role, "Resident"));
}).AddSingleton<IAuthorizationMiddlewareResultHandler, AuthorizationFilter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
