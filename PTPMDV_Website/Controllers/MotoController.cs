using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using PTPMDV_Website.Data;
using PTPMDV_Website.ViewModels;

namespace PTPMDV_Website.Controllers
{
    public class MotoController : Controller
    {
        private readonly MotoWebsiteContext db;
        public MotoController(MotoWebsiteContext context)
        {
            db = context;
        }
       
        public IActionResult Index(string? typeId, string? brandId)
        {
            var motos = db.MotoBikes.AsQueryable();
            if (!string.IsNullOrEmpty(brandId))
            {
                motos = motos.Where(p => p.MaHangSanXuat.Equals(brandId));
            }
            if (!string.IsNullOrEmpty(typeId))
            {
                motos = motos.Where(p => p.MaLoai.Equals(typeId));
            }

            var result = motos.Select(p => new MotoListVM
            {
                maXe = p.MaXe,
                tenXe = p.TenXe,
                giaMota = p.GiaBanMoTa ?? "",
                hinhMota = p.AnhMoTaUrl ?? ""
            }).ToList();
            return View(result);
        }

        public IActionResult ProducDetail(string? motoId)
        {
            if (!string.IsNullOrEmpty(motoId))
            {

            }
            var moto = db.MotoBikes.Include(p => p.MotoVersions)
                    .ThenInclude(v=> v.VersionColors)
                        .ThenInclude(i => i.VersionImages)
                    .Include(l => l.MaLibraryNavigation)
                        .ThenInclude(i2 => i2.LibraryImages)
                         .FirstOrDefault(p => p.MaXe == motoId);

            var result = new MotoDetailVM
            {
                MaXe = moto.MaXe,
                TenXe = moto.TenXe ?? "",
                MaHangSanXuat = moto.MaHangSanXuat ?? "",
                AnhMoTaUrl = moto.AnhMoTaUrl ?? "",
                GiaBanMoTa = moto.GiaBanMoTa ?? "",

                TrongLuong = moto.TrongLuong ?? "",
                KichThuoc = moto.KichThuoc ?? "",
                KhoangCachTrucBanhXe = moto.KhoangCachTrucBanhXe ?? "",
                DoCaoYen = moto.DoCaoYen ?? "",
                DoCaoGamXe = moto.DoCaoGamXe ?? "",
                DungTichBinhXang = moto.DungTichBinhXang ?? "",
                KichCoLop = moto.KichCoLop ?? "",
                PhuocTruoc = moto.PhuocTruoc ?? "",
                PhuocSau = moto.PhuocSau ?? "",
                LoaiDongCo = moto.LoaiDongCo ?? "",
                CongSuatToiDa = moto.CongSuatToiDa ?? "",
                MucTieuThuNhienLieu = moto.MucTieuThuNhienLieu ?? "",
                HeThongKhoiDong = moto.HeThongKhoiDong ?? "",
                MomentCucDai = moto.MomentCucDai ?? "",
                DungTichXyLanh = moto.DungTichXyLanh ?? "",
                DuongKinhHanhTrinhPittong = moto.DuongKinhHanhTrinhPittong ?? "",
                TySoNen = moto.TySoNen ?? "",
                MaLibrary = moto.MaLibrary,
                MaHangSanXuatNavigation = moto.MaHangSanXuatNavigation,
                MaLibraryNavigation = new MotoLibrary
                {
                    MaLibrary = moto.MaLibraryNavigation.MaLibrary,
                    LibraryImages = moto.MaLibraryNavigation.LibraryImages.Select(img => new LibraryImage
                    {
                        ImageId = img.ImageId,
                        ImageUrl = img.ImageUrl,
                    }).ToList()
                },
                MaLoaiNavigation = moto.MaLoaiNavigation,
                TienIch = moto.TienIch,
                TinhNangNoiBat = moto.TinhNangNoiBat,
                ThietKe = moto.ThietKe,

                MotoVersions = moto.MotoVersions.Select(v => new MotoVersion
                {
                    MaVersion = v.MaVersion,
                    TenVersion = v.TenVersion ?? "",
                    GiaBanVersion = v.GiaBanVersion ?? "",
                    VersionColors = v.VersionColors.Select(c => new VersionColor
                    {
                        MaVersionColor = c.MaVersionColor,
                        TenMau = c.TenMau,
                        VersionImages = c.VersionImages.Select(i => new VersionImage
                        {
                            ImageId = i.ImageId,
                            ImageUrl = i.ImageUrl,
                        }).ToList()
                    }).ToList()
                }).ToList()

            };
            return View(result);
        }

    }
}
