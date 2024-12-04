using Microsoft.AspNetCore.Mvc;
using PTPMDV_Website.Data;
using PTPMDV_Website.ViewModels;

namespace PTPMDV_Website.ViewComponents
{
    public class MenuMotoBrandViewComponent : ViewComponent
    {
        private readonly MotoWebsiteContext db;
        public MenuMotoBrandViewComponent(MotoWebsiteContext context) => db = context;
        public IViewComponentResult Invoke()
        {
            var data = db.Brands.Select(brand => new MenuMotoByBrandVM
            {
                brandId = brand.MaHangSanXuat,
                brandName = brand.TenHangSanXuat ?? "",
                amount = brand.MotoBikes.Count()
            });
            return View(data);
        }
    }
}
