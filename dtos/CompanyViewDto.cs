using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspcorewebapis.dtos
{
    public class CompanyViewDto
    {
        public int? companyId { get; set; }
        public string companyName { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public  int status { get; set; }
        
    }
}
