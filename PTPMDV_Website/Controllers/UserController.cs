using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PTPMDV_Website.Data;
using PTPMDV_Website.Helper;
using PTPMDV_Website.ViewModels;

namespace PTPMDV_Website.Controllers
{
    public class UserController : Controller
    {
        private readonly MotoWebsiteContext db;
        private readonly IMapper _mapper;
        private readonly ILogger<UserController> _logger;
        public UserController(MotoWebsiteContext context, IMapper mapper, ILogger<UserController> logger)
        {
            db = context;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public  IActionResult DangKy(RegisterVM model)
        {
            //_logger.LogError("name: " + model.Username + "pass: " + model.Password);
            var user = new User
            {
                UserId = MyUtil.GenerateRandomKey(),
                Username = model.Username,
                Password = model.Password,
                Role = "user"
            };
            db.Add(user);
            try
            {
                var result = db.SaveChanges();
                if (result > 0)
                {
                    return RedirectToAction("Index", "Moto");
                }
                else
                {
                    _logger.LogError("Không lưu được, không có hàng nào bị ảnh hưởng.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lưu dữ liệu vào cơ sở dữ liệu.");
                throw; // Ném lại lỗi để dễ dàng kiểm tra khi debug
            }
            return View();
        }

        [HttpGet]
        public IActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DangNhap(RegisterVM model)
        {
            // lam tiep o day .......
            var user = new User {
                
            };

            return View();
        }
    }
}
