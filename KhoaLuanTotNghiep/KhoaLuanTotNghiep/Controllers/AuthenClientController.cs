using KhoaLuanTotNghiep_BackEnd.Models;
using KhoaLuanTotNghiep_BackEnd.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShareModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_BackEnd.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenClientController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        public AuthenClientController(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost("register/request")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterClient([FromBody] RegisterRequest request)
        {
            if (ModelState.IsValid)
            {
                var userCheck = await _userManager.FindByEmailAsync(request.Email);
                var userCheckName = await _userManager.FindByNameAsync(request.UserName);
                if (userCheck == null && userCheckName == null)
                {
                    var user = new User
                    {
                        UserName = request.UserName,
                        NormalizedUserName = request.UserName,
                        Email = request.Email,
                        PhoneNumber = request.PhoneNumber,
                        EmailConfirmed = true,
                        FullName = request.FullName,
                        Status = true,
                        CreateDate = DateTime.Now,
                        JoinedDate = DateTime.Now,
                    };
                    var result = await _userManager.CreateAsync(user, request.Password);
                    if (result.Succeeded)
                    {
                        user = await _userManager.FindByNameAsync(user.UserName);
                        var result2 = await _userManager.AddToRoleAsync(user,
                           Roles.User);
                        var userRoles = await _userManager.GetRolesAsync(user);

                        if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
                        {
                            //var userRoles = await _userManager.GetRolesAsync(user);
                            var authClaims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, request.UserName),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                        };
                            foreach (var userRole in userRoles)
                            {
                                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                            }
                            return Ok();
                        }
                    }
                }
            }
            return null;
        }


        [HttpPost]
        [Route("login/request")]
        [AllowAnonymous]
        public async Task<TokenModel> LoginClient([FromBody] LoginModel request)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(request.Username);
                if (user == null)
                {
                    //return BadRequest(new
                    //{
                    //    message = "Username or password is incorrect. Please try again"
                    //}
                    //);
                    return null;
                }
                var isCorrect = await _userManager.CheckPasswordAsync(user, request.Password);
                if (!isCorrect)
                {
                    return null;
                    //return BadRequest(new
                    //{
                    //    message = "password is incorrect. Please try again"
                    //}
                    // );
                }
                var userRoles = await _userManager.GetRolesAsync(user);
                if (_userManager.FindByNameAsync(request.Username).Result.Status == false)
                {
                    //return BadRequest(new
                    //{
                    //    message = "Your account is disabled. Please contact with IT Team"
                    //}
                    //);
                    return null;
                }

                if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
                {
                    var authClaims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, request.Username),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    };
                    foreach (var userRole in userRoles)
                    {
                        authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                    }
                    var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var JWToken = new JwtSecurityToken(
                        issuer: _configuration["Jwt:Issuer"],
                        audience: _configuration["Jwt:Audience"],
                        expires: DateTime.Now.AddHours(3),
                        claims: authClaims,
                        signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256)
                        );
                    var token = new JwtSecurityTokenHandler().WriteToken(JWToken);

                    var tokenCreate = new TokenModel();
                    tokenCreate.token = token;
                    tokenCreate.UserName = request.Username;
                    return tokenCreate;

                    //return Ok(new ObjectResult(token));
                    //{
                    //    token = new JwtSecurityTokenHandler().WriteToken(JWToken),
                    //    User = user.UserName,
                    //    Status = user.ChangePassword,
                    //    Active = user.Status,
                    //    Role = userRoles,
                    //    //Location = user.Location,
                    //});
                }
            }
            return null;
        }
    }
}

