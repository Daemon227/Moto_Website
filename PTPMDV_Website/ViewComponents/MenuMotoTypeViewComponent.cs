using Microsoft.AspNetCore.Mvc;
using PTPMDV_Website.Data;
using PTPMDV_Website.ViewModels;

namespace PTPMDV_Website.ViewComponents
{
    public class MenuMotoTypeViewComponent : ViewComponent
    {
        private readonly MotoWebsiteContext db;

        public MenuMotoTypeViewComponent(MotoWebsiteContext context) => db = context;

        public IViewComponentResult Invoke()
        {
            var data = db.MotoTypes.Select(type => new MenuMotoTypeVM
            {
                typeId = type.MaLoai,
                typeName = type.TenLoai,
                amount = type.MotoBikes.Count
            });
            return View(data);
        }
    }
}
