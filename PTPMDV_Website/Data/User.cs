﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PTPMDV_Website.Data
{
    public partial class User
    {
        public string UserId { get; set; } = null!;

        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Email { get; set; } = null!;
        public string Role { get; set; } = null!;
    }
}
