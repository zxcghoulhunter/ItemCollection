using ItemCollection.Areas.Identity.Data;
using ItemCollection.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemCollection.Controllers
{
    public class AdminController : Controller
    {
        RoleManager<IdentityRole> _roleManager;
        UserManager<ItemCollectionUser> _userManager;

        public AdminController(RoleManager<IdentityRole> roleManager, UserManager<ItemCollectionUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public IActionResult Index() => View(_userManager.Users.ToList());

        public IActionResult Create() => View();
        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(name);
        }

        public async Task<IActionResult> Ban(string name)
        {
            var user = await _userManager.FindByNameAsync(name);

            var ban = new string[] { "ban" };
                await _userManager.AddToRolesAsync(user, ban);


            return RedirectToAction("Index");
        }
        public async Task<IActionResult> MakeAdmin(string name)
        {
            var user = await _userManager.FindByNameAsync(name);

            await _userManager.AddToRoleAsync(user, "admin");


            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Unban(string name)
        {
            var user = await _userManager.FindByNameAsync(name);
            var ban = new string[] { "ban" };
                await _userManager.RemoveFromRolesAsync(user, ban);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(string name)
        {
                var user = await _userManager.FindByNameAsync(name);
            IdentityResult result = await _userManager.DeleteAsync(user);

            return RedirectToAction("Index");
        }
    }
}

