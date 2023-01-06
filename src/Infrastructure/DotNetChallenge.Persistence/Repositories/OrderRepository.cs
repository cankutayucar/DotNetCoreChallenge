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
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
            
        }
    }
}
