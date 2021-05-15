using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspcorewebapis.Services;
using aspcorewebapis.Entities;
using Microsoft.EntityFrameworkCore;

namespace aspcorewebapis.Services
{
    public class CompanyRepository: ICompanyRepository
    {
        private MasterDBContext _context;
        public CompanyRepository(MasterDBContext context)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));
        }
        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Companies>> GetCompanies()
        {
            return await _context.Companies.ToListAsync();

        }
        public async Task AddCompany(Entities.Companies company)
        {
            if (company == null)
            {
                throw new ArgumentNullException(nameof(company));
            }
            await _context.AddAsync(company);

        }

        public async Task UpdateCompany(Entities.Companies company)
        {
            if (company == null)
            {
                throw new ArgumentNullException(nameof(company));
            }
            if (_context != null)
            {
                //Delete that post
                _context.Companies.Update(company);

                //Commit the transaction
                await this.SaveChanges();

            }
        }
        public async Task<int> CompanyIfExists(string companyName)
        {
            int result = 0;

            var company = await _context.Companies.FirstOrDefaultAsync(x => x.companyName == companyName);
            if (company == null)
            {
                result = 0;
            }
            else
            {
                result = 1;
            }

            return result;

        }
        public async Task<Companies> GetCompany(int companyId)
        {
            return await _context.Companies.FirstOrDefaultAsync(b => b.companyId == companyId);
        }

        public async Task<int> DeActivateCompany(int companyId)
        {
            int result = 0;
            if (_context != null)
            {
                var company = await _context.Companies.FirstOrDefaultAsync(x => x.companyId == companyId);
                if (company != null)
                {
                    company.status = 0;
                    //  _context.Companies.Update(company);
                    result = await this.SaveChanges();
                }
                return result;
            }
            return result;
        }
    }
}
