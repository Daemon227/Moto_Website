using System;
using System.Collections.Generic;

namespace PTPMDV_Website.Data;

public partial class MotoType
{
    public string MaLoai { get; set; } = null!;

    public string? TenLoai { get; set; }

    public virtual ICollection<MotoBike> MotoBikes { get; set; } = new List<MotoBike>();
}
