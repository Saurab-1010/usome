﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesTransactionApplication.Models
{
    public class LoginViewModel
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}