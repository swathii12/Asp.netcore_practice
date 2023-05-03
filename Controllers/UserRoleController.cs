using Asp.netcore_practice.Context;
using Asp.netcore_practice.Models;
using Asp.netcore_practice.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Asp.netcore_practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserRoleController:ControllerBase
    {
       
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _context;

        public UserRoleController(UserManager<ApplicationUser> user, RoleManager<IdentityRole> roleManager,AppDbContext context)
        {
            
            _userManager = user;
            _roleManager = roleManager;
            _context = context;
        }


        [HttpPost("addUser")]
        public async Task<IActionResult> AddUser(RegisterViewModel user)
        {
            var userExists = await _userManager.FindByEmailAsync(user.Email);
            if (userExists != null)
            {
                return BadRequest($"User {user.Email} already exists");
            }

            ApplicationUser newUser = new ApplicationUser()
            {
                FullName = user.FullName,
                UserName = user.UserName,
                Email=user.Email,
                EmailConfirmed = user.EmailConfirmed,
                
            };

            var result = await _userManager.CreateAsync(newUser,user.Password);

            if (result.Succeeded)
            {
                if (user.Role == "Admin")
                {
                    await _userManager.AddToRoleAsync(newUser, "Admin");
                }
                else
                {
                    await _userManager.AddToRoleAsync(newUser, "User");
                }


                return Ok("user created");
            }

            return BadRequest();
        }

        [HttpPost("addRoles")]
        public async Task<IActionResult> AddRole(RoleViewModel role)
        {
            /* var addRole = _service.AddRoles(role);
             return Ok(role +"Created");*/

            var roleExists = await  _roleManager.FindByNameAsync(role.RoleName);
            if (roleExists != null)
            {
                return BadRequest($"Role {role.RoleName} already exists");
            }

            IdentityRole newRole = new IdentityRole()
            {
                Name = role.RoleName
            };

            var result =await _roleManager.CreateAsync(newRole);

            if (result.Succeeded)
            {
                return Ok("Role Created");
            }

            return BadRequest("Role could not be created " + result);
        }

    }
}
