﻿using System;
using System.Collections.Generic;

namespace PTPMDV_Website.Data;

public partial class LibraryImage
{
    public int ImageId { get; set; }

    public string? MaLibrary { get; set; }

    public string? ImageUrl { get; set; }

    public virtual MotoLibrary? MaLibraryNavigation { get; set; }
}
