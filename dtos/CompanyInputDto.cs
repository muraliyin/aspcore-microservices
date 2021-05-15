using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspcorewebapis.dtos
{
    public class CompanyInputDto
    {
        public string companyName { get; set; }
        public string phone { get; set; }
        public string email { get; set; }

        public int status { get; set; }
    }
    public class CompanyInputUpdateDto
    {
        
        public int? CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string phone { get; set;  }
        public string email { get; set; }
        public int status { get; set; }

    }
}
