using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Newtonsoft.Json;
using PTPMDV_Website.Data;
using PTPMDV_Website.Helper;
using PTPMDV_Website.ViewModels;
using System;
using System.Drawing.Printing;
using X.PagedList.Extensions;

namespace PTPMDV_Website.Controllers
{
    public class MotoController : Controller
    {
        private readonly MotoWebsiteContext db;
        private readonly HttpClient _httpClient;
        private readonly ILogger<MotoController> _logger;
        public MotoController(MotoWebsiteContext context, HttpClient httpClient, ILogger<MotoController> logger)
        {
            db = context;
            _httpClient = httpClient;
            _logger = logger;
        }
       
        public async Task<IActionResult> Index(int? page, string? brandID, string? typeID)
        {
            int pageSize = 6;  // Số lượng mục mỗi trang
            int pageNumber = (page ?? 1); // Nếu page là null, gán giá trị mặc định là 1

            try
            {
                if (brandID == null && typeID == null)
                {
                    var response = await _httpClient.GetAsync("https://localhost:7252/api/Moto/Motos");
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();
                    var motos = JsonConvert.DeserializeObject<List<MotoVM>>(data);
                    var pageResult = motos.ToPagedList(pageNumber, pageSize);
                    return View(pageResult);
                }
                else if (brandID != null && typeID== null)
                {
                    var response = await _httpClient.GetAsync("https://localhost:7252/api/Moto/Motos");
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();
                    var motos = JsonConvert.DeserializeObject<List<MotoVM>>(data);
                    var pageResult = motos.Where(m=>m.MaHangSanXuat==brandID).ToPagedList(pageNumber, pageSize);
                    return View(pageResult);
                }
                else if (brandID == null && typeID != null)
                {
                    var response = await _httpClient.GetAsync("https://localhost:7252/api/Moto/Motos");
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();
                    var motos = JsonConvert.DeserializeObject<List<MotoVM>>(data);
                    var pageResult = motos.Where(m => m.MaLoai == typeID).ToPagedList(pageNumber, pageSize);
                    return View(pageResult);
                }
                else
                {
                    var response = await _httpClient.GetAsync("https://localhost:7252/api/Moto/Motos");
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();
                    var motos = JsonConvert.DeserializeObject<List<MotoVM>>(data);
                    var pageResult = motos.Where(m => m.MaHangSanXuat == brandID && m.MaLoai == typeID).ToPagedList(pageNumber, pageSize);
                    return View(pageResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching brands from API");
                return StatusCode(500, "Internal server error");
            }
        }

        public async Task<IActionResult> ProducDetail(string? motoId)
        {
            if (!string.IsNullOrEmpty(motoId))
            {

            }
            var response = await _httpClient.GetAsync("https://localhost:7252/api/Moto/Motos/"+motoId);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            var moto = JsonConvert.DeserializeObject<MotoVM>(data);
            return View(moto);
        }


       public async Task<IActionResult> CompareMotos()
        {
            var response = await _httpClient.GetAsync("https://localhost:7252/api/Moto/Motos");
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            var motos = JsonConvert.DeserializeObject<List<MotoVM>>(data);

            var response1 = await _httpClient.GetAsync("https://localhost:7252/api/Type/Types");
            response1.EnsureSuccessStatusCode();
            var data1 = await response1.Content.ReadAsStringAsync();
            var types = JsonConvert.DeserializeObject<List<TypeVM>>(data1);

            var result = new CompareDataVM
            {
                Motos = motos,
                Types = types
            };
            return View(result);
        }

        public async Task<IActionResult> ShowResult(string motoIds)
        {
            var selectedMotos = motoIds.Split(',').ToList();
            
            var response = await _httpClient.GetAsync("https://localhost:7252/api/Moto/Motos");
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            var motos = JsonConvert.DeserializeObject<List<MotoVM>>(data);

            var motoSelected = new List<MotoVM>();
            foreach (var id in selectedMotos)
            {
                motoSelected.Add(motos.FirstOrDefault(m=>m.MaXe==id));
            }

            var response1 = await _httpClient.GetAsync("https://localhost:7252/api/Type/Types");
            response1.EnsureSuccessStatusCode();
            var data1 = await response1.Content.ReadAsStringAsync();
            var types = JsonConvert.DeserializeObject<List<TypeVM>>(data1);

            var result = new CompareDataVM
            {
                Motos = motos,
                Types = types,
                MotoToCompare = motoSelected
            };
            return View(result);
        }

    }
}
