using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesTransactionApplication.Models
{
    public class UserDataViewModel
    {
        public int PersonId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}