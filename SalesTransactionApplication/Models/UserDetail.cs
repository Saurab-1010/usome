using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesTransactionApplication.Models
{
    public class UserDetail
    {
        public int PersonId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public bool RememberMe { get; set; }
    }
}