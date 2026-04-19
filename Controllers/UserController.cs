using dotnet_store.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet_store.Controllers;

public class UserController : Controller
{
    private UserManager<AppUser> _userManager;
    private RoleManager<AppRole> _roleManager;
    public UserController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public ActionResult Index()
    {
        return View(_userManager.Users);
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(UserCreateModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new AppUser { UserName = model.Email, Email = model.Email, AdSoyad = model.AdSoyad };

            var result = await _userManager.CreateAsync(user);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

        return View(model);
    }

    public async Task<ActionResult> Edit(string id)
    {
        var user = await _userManager.FindByIdAsync(id);

        if (user == null)
        {
            RedirectToAction("Index");
        }

        ViewBag.Roles = await _roleManager.Roles.Select(i => i.Name).ToListAsync();

        return View(
            new UserEditModel
            {
                AdSoyad = user!.AdSoyad,
                Email = user.Email!,
                SelectedRoles = await _userManager.GetRolesAsync(user)
            }
        );
    }

    [HttpPost]
    public async Task<ActionResult> Edit(string id, UserEditModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                user.Email = model.Email;
                user.AdSoyad = model.AdSoyad;

                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded && !string.IsNullOrEmpty(model.Password))
                {
                    // parola güncellemesi
                    await _userManager.RemovePasswordAsync(user);
                    await _userManager.AddPasswordAsync(user, model.Password);
                }

                if (result.Succeeded)
                {
                    await _userManager.RemoveFromRolesAsync(user, await _userManager.GetRolesAsync(user));
                    if(model.SelectedRoles != null)
                    {
                        await _userManager.AddToRolesAsync(user, model.SelectedRoles);
                    }
                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
        }

        return View(model);
    }
}