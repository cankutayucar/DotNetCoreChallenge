using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetChallenge.Domain.Common;

namespace DotNetChallenge.Domain.Entities
{
    public class Order : BaseEntity
    {
        public string NameOfPersonPlacingOrder { get; set; }
        public DateTime OrderDate { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
