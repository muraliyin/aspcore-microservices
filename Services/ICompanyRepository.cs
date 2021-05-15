using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspcorewebapis.Services
{
   public  interface ICompanyRepository
    {
        Task<int> SaveChanges();
        Task AddCompany(Entities.Companies company);
        Task<IEnumerable<Entities.Companies>> GetCompanies();
        Task<int> CompanyIfExists (string companyName);

        Task UpdateCompany(Entities.Companies company);

        Task<Entities.Companies> GetCompany(int companyId);
        Task<int> DeActivateCompany(int companyId);
    }
}
