using System;
using System.Collections.Generic;

namespace PTPMDV_Website.Data;

public partial class Brand
{
    public string MaHangSanXuat { get; set; } = null!;

    public string? TenHangSanXuat { get; set; }

    public virtual ICollection<MotoBike> MotoBikes { get; set; } = new List<MotoBike>();
}
