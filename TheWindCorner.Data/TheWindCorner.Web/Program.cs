using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TheWindCorner.Data;
using TheWindCorner.Data.Models.User;
using TheWindCorner.Web.Infrastructure.Email;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<ApplicationUser, IdentityRole<Guid>>(options =>
{
    ConfigureIdentity(builder, options);
})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddUserManager<UserManager<ApplicationUser>>()
    .AddSignInManager<SignInManager<ApplicationUser>>();
//.AddRoleManager<RoleManager<IdentityRole<Guid>>>()

// !!! builder.Services.AddTransient<IEmailSender, DummyEmailSender>();  // !!! 


builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();



 static void ConfigureIdentity(WebApplicationBuilder builder, IdentityOptions options)
{
    options.Password.RequireDigit =
        builder.Configuration.GetValue<bool>("Identity:Password:RequireDigit");
    options.Password.RequiredLength =
        builder.Configuration.GetValue<int>("Identity:Password:RequiredLength");
    options.Password.RequireLowercase =
        builder.Configuration.GetValue<bool>("Identity:Password:RequireLowercase");
    options.Password.RequireUppercase =
        builder.Configuration.GetValue<bool>("Identity:Password:RequireUppercase");
    options.Password.RequiredUniqueChars =
        builder.Configuration.GetValue<int>("Identity:Password:RequiredUniqueChars");
    options.Password.RequireNonAlphanumeric =
        builder.Configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");

    options.SignIn.RequireConfirmedEmail =
        builder.Configuration.GetValue<bool>("Identity:Password:RequireConfirmedEmail");
    options.SignIn.RequireConfirmedAccount =
        builder.Configuration.GetValue<bool>("Identity:Password:RequireConfirmedAccount");
    options.SignIn.RequireConfirmedPhoneNumber =
        builder.Configuration.GetValue<bool>("Identity:Password:RequireConfirmedPhoneNumber");

    options.User.RequireUniqueEmail =
        builder.Configuration.GetValue<bool>("Identity:User:RequireUniqueEmail");
}