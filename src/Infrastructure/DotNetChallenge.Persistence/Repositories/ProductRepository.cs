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
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
            
        }
    }
}
