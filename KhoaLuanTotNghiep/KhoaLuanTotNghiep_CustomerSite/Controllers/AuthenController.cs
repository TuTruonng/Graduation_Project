
using KhoaLuanTotNghiep_CustomerSite.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShareModel;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_CustomerSite.Controllers
{
    public class AuthenController : Controller
    {
        private readonly IAuthenApiClient _authenApiClient;


        public AuthenController(IAuthenApiClient authenApiClient)
        {
            _authenApiClient = authenApiClient;

        }

        [HttpGet]
        [Route("/Login")]
        public IActionResult Login()
        {
            LoginModel model = new LoginModel();
            return View(model);
        }

        [HttpPost]
        [Route("/Login")]
        public async Task<IActionResult> Login(LoginModel Request)
        {

            var result = await _authenApiClient.Login(Request);
            if (result == null)
            {
                TempData["FailMessage"] = "Username hoặc password không đúng!";
                return RedirectToAction("Login", "Authen");
            }

            TempData["SuccessMessage"] = "Đăng nhập thành công";
            HttpContext.Session.SetString("JWToken", result.token);
            HttpContext.Session.SetString("Username", result.UserName);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("/Register")]
        public IActionResult Register()
        {
            RegisterRequest model = new RegisterRequest();
            return View(model);
        }

        [HttpPost]
        [Route("/Register")]
        public async Task<IActionResult> Register(RegisterRequest Request)
        {
            var result = await _authenApiClient.Register(Request);
            if (result == false)
            {
                TempData["FailMessage"] = "Thông tin email hoặc tên đăng nhập đã tồn tại!";
                return RedirectToAction("Register", "Authen");
            }
            TempData["SuccessMessage"] = "Đăng ký thành công";
            return RedirectToAction("Login", "Authen");
        }

        [Route("/Logout")]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            TempData["SuccessMessage"] = "Đăng xuất thành công";
            //await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Authen");
        }
    }
}
