using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetChallenge.Application.Features.Queries.GetAllCompany
{
    public class GelAllCompanyQueryResponse
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public bool IsCompanyConfirmed { get; set; }
        public string OrderStartTime { get; set; }
        public string OrderEndTime { get; set; }
    }
}
