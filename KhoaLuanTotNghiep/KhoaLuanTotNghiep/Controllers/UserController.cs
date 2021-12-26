using KhoaLuanTotNghiep_BackEnd.Interface;
using KhoaLuanTotNghiep_BackEnd.Models;
using KhoaLuanTotNghiep_BackEnd.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShareModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UserController : ControllerBase
    {

        private readonly UserManager<User> _userManager;
        private readonly IUser _user;

        public UserController(IUser user, UserManager<User> userManager)
        {
            _userManager = userManager;
            _user = user;
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<User>>> GetAdminStaff()
        {
            var results = await _user.GetAdminAsync();
            return Ok(results);
        }


        [HttpGet]
        [Route("user")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            var results = await _user.GetUserAsync();
            return Ok(results);
        }


        [HttpGet]
        [Route("user={name}")]
        [AllowAnonymous]
        public async Task<ActionResult<User>> GetUserInfo(string name)
        {
            var results = await _user.GetInfoSalaryAsync(name);
            return Ok(results);
        }

        [HttpGet("export")]
        public async Task<FileContentResult> ExportAsync()
        {
            var users = await _user.GetAdminAsync();
            return ExportFileUser.ExportExcel(users, "User", "User");
        }

        [HttpPost("Client")]
        [AllowAnonymous]
        public async Task<ActionResult<UserModel>> CreateClient(
           [FromBody] CreateClientModel createUserDto)
        {
            UserModel dto = await _user.CreateAsync(createUserDto);
            if (dto == null)
            {
                return Problem(statusCode: 500);
            }

            return CreatedAtAction(nameof(CreateClient), dto);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> CreateUser(
            [FromBody] CreateUserModel createUserDto)
        {
            UserModel dto = await _user.AddAsync(createUserDto);
            if (dto == null)
            {
                return Problem(statusCode: 500);
            }

            return CreatedAtAction(nameof(CreateUser), dto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> EditUser(string id,
        [FromForm] EditUserModel editUserDto)
        {
            if ((await _userManager.FindByIdAsync(id.ToString())) == null)
            {
                return NotFound();
            }

            UserModel dto = await _user.UpdateAsync(id, editUserDto);
            if (dto == null)
            {
                return Problem(statusCode: 500);
            }

            return Ok(dto);
        }

        [HttpPut("disable/{id}")]
        public async Task<ActionResult<bool>> DisableUser(
            [FromRoute] string id)
        {
            var updatedUser = await _user.DisableAsync(id);

            return Ok(updatedUser);
        }

        [HttpPut("password")]
        public async Task<ActionResult> ChangeUserPassword(
            [FromBody] ChangeUserPasswordDto changeUserPasswordDto)
        {
            User user = await _userManager.FindByNameAsync(changeUserPasswordDto.Username);
            if (user == null)
            {
                return NotFound();
            }

            bool succeeded = await _user.ChangeUserPasswordAsync(changeUserPasswordDto);
            if (succeeded)
            {
                return Ok(new { Message = "Your password has been changed successfully" });
            }
            return BadRequest(new { Message = "Password is incorrect" });
        }
    }
}
