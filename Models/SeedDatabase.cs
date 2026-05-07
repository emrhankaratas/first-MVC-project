using Microsoft.AspNetCore.Identity;

namespace dotnet_store.Models;

public static class SeedDatabase
{
    public static async void Initialize(IApplicationBuilder app)
    {
        var userManagar = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<AppUser>>();
        var roleManagar = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<RoleManager<AppRole>>();

        if (!roleManagar.Roles.Any())
        {
            var admin = new AppRole { Name = "Admin" };
            await roleManagar.CreateAsync(admin);
        }

        if (!userManagar.Users.Any())
        {
            var admin = new AppUser
            {
                AdSoyad = "Emirhan Karataş",
                UserName = "emirhankaratas",
                Email = "info@emirhankaratas.com"
            };

            await userManagar.CreateAsync(admin, "12345678");
            await userManagar.AddToRoleAsync(admin, "Admin");

            var customer = new AppUser
            {
                AdSoyad = "Selim Serez",
                UserName = "selimserez",
                Email = "info@selimserez.com"
            };

            await userManagar.CreateAsync(customer, "12345678");
        }
    }
}