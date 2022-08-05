using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bai4.Models
{
    public class Staff
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime dob { get; set; }
        public decimal salary { get; set; }
        public string image { get; set; }
    }
}