﻿using PTPMDV_Website.Models;

namespace PTPMDV_Website.ViewModels
{
    public class BrandVM
    {
        public string MaHangSanXuat { get; set; } = null!;

        public string? TenHangSanXuat { get; set; }

        public string? QuocGia { get; set; }

        public string? MoTaNgan { get; set; }

        //public virtual ICollection<MotoVM> MotoBikes { get; set; } = new List<MotoVM>();
    }
}
