using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetChallenge.Application.Interfaces.Repository;
using DotNetChallenge.Domain.Entities;
using DotNetChallenge.Persistence.Context;

namespace DotNetChallenge.Persistence.Repositories
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(AppDbContext context) : base(context)
        {
        }
        public void UpdateOrderDate(Company company)
        {
            base.Update(company);
        }
    }
}
