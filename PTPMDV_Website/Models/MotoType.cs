﻿using System;
using System.Collections.Generic;

namespace PTPMDV_Website.Models;

public partial class MotoType
{
    public string MaLoai { get; set; } = null!;

    public string? TenLoai { get; set; }

    public string? DoiTuongSuDung { get; set; }

    public string? MoTaNgan { get; set; }

    public virtual ICollection<MotoBike> MotoBikes { get; set; } = new List<MotoBike>();
}
