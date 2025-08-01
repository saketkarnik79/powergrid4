using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Web_DemoMVCWithEFCoreCodeFirst.Models;

namespace Web_DemoMVCWithEFCoreCodeFirst.Controllers.Auth
{
    //[Authorize(Roles = "Admins")]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        // GET: RolesList
        [HttpGet]
        public ActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }

        // GET: RolesController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: RolesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(string roleName)
        {
            try
            {
                if(!string.IsNullOrEmpty(roleName))
                {
                    var role = new IdentityRole(roleName);
                    var result = await _roleManager.CreateAsync(role);
                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, string.Join(", ", result.Errors.Select(e => e.Description)));
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Role name cannot be empty.");
                }
            }
            catch(Exception ex)
            {
                // Handle exceptions here, e.g., log the error
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View();
        }

        // GET: RolesController/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            return View(role);
        }

        // POST: RolesController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(id);
                if (role != null)
                {
                    var result = await _roleManager.DeleteAsync(role);
                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, string.Join(", ", result.Errors.Select(e => e.Description)));
                    }
                }
            }
            catch(Exception ex)
            {
                // Handle exceptions here, e.g., log the error
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View();
        }

        // GET: RolesController/ManageUsers/5
        [HttpGet]
        public async Task<IActionResult> ManageUsers(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            var users = _userManager.Users.ToList();
            var model = users.Select(user => new UserRoleViewModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                IsSelected = _userManager.IsInRoleAsync(user, role.Name).Result
            }).ToList();
            ViewBag.RoleId = id;
            ViewBag.RoleName = role.Name;
            return View(model);
        }

        // POST: RolesController/ManageUsers/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManageUsers(string id, List<UserRoleViewModel> model)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            foreach (var userRole in model)
            {
                var user = await _userManager.FindByIdAsync(userRole.UserId);
                if (user != null)
                {
                    if (userRole.IsSelected && !(await _userManager.IsInRoleAsync(user, role.Name)))
                    {
                        await _userManager.AddToRoleAsync(user, role.Name);
                    }
                    else if (!userRole.IsSelected && (await _userManager.IsInRoleAsync(user, role.Name)))
                    {
                        await _userManager.RemoveFromRoleAsync(user, role.Name);
                    }
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
