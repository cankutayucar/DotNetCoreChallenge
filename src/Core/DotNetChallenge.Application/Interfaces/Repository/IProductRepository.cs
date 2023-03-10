using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetChallenge.Domain.Entities;

namespace DotNetChallenge.Application.Interfaces.Repository
{
    public interface IProductRepository : IGenericRepository<Product>
    {
    }
}
