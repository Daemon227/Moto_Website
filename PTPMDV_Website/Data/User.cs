using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PTPMDV_Website.Data
{
    public partial class User
    {
        public string UserId { get; set; }
   
        public string Username { get; set; }

        public string Password { get; set; }  

        public string Role { get; set; }  // 'admin' hoặc 'customer'
    }
}
