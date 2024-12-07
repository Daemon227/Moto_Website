using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PTPMDV_Website.Data;
using PTPMDV_Website.ViewModels;
using System.Drawing.Printing;

namespace PTPMDV_Website.ViewComponents
{
    public class MenuMotoBrandViewComponent : ViewComponent
    {
        
        private readonly HttpClient _httpClient;
        public MenuMotoBrandViewComponent(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await _httpClient.GetAsync("https://localhost:7252/api/Brand/Brands");
            response.EnsureSuccessStatusCode();
            var dataBrand = await response.Content.ReadAsStringAsync();
            var brands = JsonConvert.DeserializeObject<List<BrandVM>>(dataBrand);

            var response1 = await _httpClient.GetAsync("https://localhost:7252/api/Moto/Motos");
            response1.EnsureSuccessStatusCode();
            var dataMoto = await response1.Content.ReadAsStringAsync();
            var motos = JsonConvert.DeserializeObject<List<MotoVM>>(dataMoto);


            var data = brands.Select(brand => new MenuMotoByBrandVM
            {
                brandId = brand.MaHangSanXuat,
                brandName = brand.TenHangSanXuat ?? "",
                amount = motos.Count(m => m.MaHangSanXuat == brand.MaHangSanXuat)
            });
            
            return View(data);
        }
    }
}
