using Microsoft.AspNetCore.Identity;
using System.Data;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.IdentityModel.Tokens;
using HRVacancies.Repositories;
using Microsoft.AspNetCore.Http.Features;
using HRVacancies.Data;
using HRVacancies.Models;
using HRVacancies.Services;

var builder = WebApplication.CreateBuilder(args);

var provider = builder.Services.BuildServiceProvider();

var configuration = provider.GetRequiredService<IConfiguration>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddMvc();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(15);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.SameSite = SameSiteMode.None;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.Cookie.MaxAge = TimeSpan.FromMinutes(15);
    options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;

});


//builder.Services.AddIdentity<ApplicationUser, AppRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

builder.Services.AddIdentityCore<ApplicationUser>(opt =>
{
    opt.Password.RequireNonAlphanumeric = false;
}).AddRoles<AppRole>()
           .AddRoleManager<RoleManager<AppRole>>()
           .AddSignInManager<SignInManager<ApplicationUser>>()
           .AddRoleValidator<RoleValidator<AppRole>>()
           .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    //options.Password.RequiredUniqueChars = 1;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+ ";
    options.User.RequireUniqueEmail = false;
});

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    builder.Services.AddHttpContextAccessor();
    builder.Services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();

});

// auth middleware
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
{
    ValidateIssuerSigningKey = true,
    ValidateIssuer = false,
    ValidateAudience = false,
    ValidateLifetime = true,
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration.GetSection("AppSettings:Key").Value)),
  });

// add authorization for policy based
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
    options.AddPolicy("NormalUserOnly", policy => policy.RequireRole("NormalUser"));
});

// every request is auth, the [Authorize] attribute can be removed because this is a setting for global authorization and for Policy
builder.Services.AddMvc(options =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser() // requires auth globally
        .Build();

    options.Filters.Add(new AuthorizeFilter(policy));
});


// add automapper
builder.Services.AddAutoMapper();

// services
builder.Services.AddTransient<IJwtTokenGenerator, JwtTokenGenerator>();

// repositories
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IHRVacancyRepository, HRVacancyRepository>();
builder.Services.AddScoped<IHRRequisitionRepository, HRRequisitionRepository>();
builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();

builder.Services
       .AddControllers(options =>
       {
           options.Filters.Add(new AuthorizeFilter());
       });

// add cors
builder.Services.AddCors();

// Add DbContext
builder.Services.AddDbContext<ApplicationDbContext>();

var app = builder.Build();
 
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseCors(o => o.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.Use(async (context, next) =>
{
    // upload max 2 megabytes  
    context.Features.Get<IHttpMaxRequestBodySizeFeature>().MaxRequestBodySize = 200_000_0;

    var token = context.Session.GetString("Token");
    if (!string.IsNullOrEmpty(token))
    {
        context.Request.Headers.Add("Authorization", "Bearer " + token);
    }
    await next();
});

app.UseAuthentication();

app.UseAuthorization();



app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
