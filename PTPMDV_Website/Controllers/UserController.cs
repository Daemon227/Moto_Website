using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PTPMDV_Website.Data;
using PTPMDV_Website.Helper;
using PTPMDV_Website.ViewModels;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace PTPMDV_Website.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly HttpClient _httpClient;

        public UserController(ILogger<UserController> logger, HttpClient httpClient)
        {

            _httpClient = httpClient;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpVM model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserId = MyUtil.GenarateRandomKey(),
                    Username = model.Username,
                    Password = model.Password,
                    Email = model.Email,
                    Role = "khach"
                };
                var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("https://localhost:7252/api/User/Users", content);
                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("Tao Tk Thanh Cong");
                    return RedirectToAction("SignIn", "User");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    ModelState.AddModelError(string.Empty, errorMessage);
                    return View(model);
                }
                else
                {
                    _logger.LogError("Error creating tk");
                    ModelState.AddModelError(string.Empty, "Error creating tk");
                    return View(model);
                }
            }
            else { return View(); }
        }

        [HttpGet]
        public IActionResult SignIn(string? returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInVM model, string? returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            if (ModelState.IsValid)
            {
                var response = await _httpClient.GetAsync("https://localhost:7252/api/User/Users/" + model.Username);
                if (!response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        ModelState.AddModelError("Loi", "Tài khoản không tồn tại");
                    }
                    else
                    {
                        ModelState.AddModelError("Loi", "Lỗi hệ thống. Vui lòng thử lại sau.");
                    }
                    return View(model);
                }
                var data = await response.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<User>(data);
                if (user == null)
                {
                    ModelState.AddModelError("Loi", "Tài Khoản không tồn tại");
                }
                else
                {
                    if (user.Password != model.Password)
                    {
                        ModelState.AddModelError("Loi", "Sai mat khau");
                    }
                    else
                    {
                        /*HttpContext.Session.SetString("Login", user.Username);*/
                        TempData["Login"] = user.Username;

                        return RedirectToAction("Index", "Home");
                    }
                }

            }
            else
            {
                _logger.LogError("Loi con cax");
            }
            return View();
        }

        public async Task<IActionResult> LogOut()
        {

            TempData["Login"] = null;
            return RedirectToAction("SignIn", "User");
        }
    }
}
