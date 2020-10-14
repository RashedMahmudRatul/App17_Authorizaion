using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App16_Authorization.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace App16_Authorization.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(string rname)
        {
            //Null or Empty rname ?
            //{ 
            //Check If Role is Exists with same name

            // If not found then create it

            // If found then show message
            //}

            if (string.IsNullOrEmpty(rname))
            {
                ViewBag.msg = "Role Name is Empty or Null.";
            }
            else
            {
                bool exists = await _roleManager.RoleExistsAsync(rname);

                if (exists)
                {
                    ViewBag.msg = "Role Name is already Exists.";
                }
                else
                {
                    IdentityRole r = new IdentityRole(rname);
                    await _roleManager.CreateAsync(r);
                    ViewBag.msg = "Role Name is Created Successfully.";
                }
            }
            return View("Create");
        }

        public IActionResult AssignRole()
        {
            var userlist = _userManager.Users;
            var rolelist = _roleManager.Roles;

            ViewBag.users = userlist;
            ViewBag.roles = rolelist;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(string appuser, string approle)
        {
            //Check role is assigned this user?
            //If yes show message
            //No Assign this role to this user

            var userlist = _userManager.Users;
            var rolelist = _roleManager.Roles;

            ViewBag.users = userlist;
            ViewBag.roles = rolelist;

            IdentityUser u = await _userManager.FindByEmailAsync(appuser);
            if (u != null)
            {
                bool ext = await _roleManager.RoleExistsAsync(approle);
                if (ext)
                {
                    bool IsAssigned = await _userManager.IsInRoleAsync(u, approle);
                    if (IsAssigned)
                    {
                        ViewBag.msg = "Role is already assigned to this user.";
                        return View();
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(u, approle);
                        ViewBag.msg = "Role is assigned to this user Successfully.";
                        return View();
                    }
                }
                else
                {
                    ViewBag.msg = "Role does not exist. Try another Role.";
                    return View();
                }
            }
            else
            {
                ViewBag.msg = "User does not exist.";
                return View();
            }
        }
    }
}
