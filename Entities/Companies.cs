using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace aspcorewebapis.Entities
{
    public class Companies
    {
        [Key]
        public int? companyId { get; set; }
        public string companyName { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public int status { get; set; }
       
    }
}
