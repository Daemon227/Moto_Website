using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PTPMDV_Website.Data;
using PTPMDV_Website.ViewModels;
using System.Net.Http;

namespace PTPMDV_Website.ViewComponents
{
    public class MenuMotoTypeViewComponent : ViewComponent
    {
        private readonly MotoWebsiteContext db;
        private readonly HttpClient _httpClient;
        public MenuMotoTypeViewComponent(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await _httpClient.GetAsync("https://localhost:7252/api/Type/Types");
            response.EnsureSuccessStatusCode();
            var dataType = await response.Content.ReadAsStringAsync();
            var types = JsonConvert.DeserializeObject<List<TypeVM>>(dataType);

            var response1 = await _httpClient.GetAsync("https://localhost:7252/api/Moto/Motos");
            response1.EnsureSuccessStatusCode();
            var dataMoto = await response1.Content.ReadAsStringAsync();
            var motos = JsonConvert.DeserializeObject<List<MotoVM>>(dataMoto);
            var data = types.Select(type => new MenuMotoTypeVM
            {
                typeId = type.MaLoai,
                typeName = type.TenLoai,
                amount = motos.Count(m=>m.MaLoai == type.MaLoai)
            });
            return View(data);
        }
    }
}
