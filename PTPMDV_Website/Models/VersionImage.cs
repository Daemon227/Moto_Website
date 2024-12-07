﻿using System;
using System.Collections.Generic;

namespace PTPMDV_Website.Models;

public partial class VersionImage
{
    public int ImageId { get; set; }

    public string? MaVersionColor { get; set; }

    public string? ImageUrl { get; set; }

    public virtual VersionColor? MaVersionColorNavigation { get; set; }
}
