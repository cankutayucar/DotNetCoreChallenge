using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetChallenge.Application.Utils
{
    public static class CalculeteOrderTime
    {
        public static DateTime SetTime(string time)
        {
            var t = time.Split(':');
            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                int.Parse(t[0]), int.Parse(t[1]), 00);
        }
    }
}
