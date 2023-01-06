using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetChallenge.Domain.Common;

namespace DotNetChallenge.Domain.Entities
{
    public class Company : BaseEntity
    {
        public string CompanyName { get; set; }
        public bool IsCompanyConfirmed { get; set; }
        public DateTime OrderStartTime { get; set; }
        public DateTime OrderEndTime { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
