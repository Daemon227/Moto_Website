﻿using System;
using System.Collections.Generic;

namespace PTPMDV_Website.Models;

public partial class MotoVersion
{
    public string MaVersion { get; set; } = null!;

    public string? TenVersion { get; set; }

    public string? GiaBanVersion { get; set; }

    public string? MaXe { get; set; }

    public virtual MotoBike? MaXeNavigation { get; set; }

    public virtual ICollection<VersionColor>? VersionColors { get; set; }
}
