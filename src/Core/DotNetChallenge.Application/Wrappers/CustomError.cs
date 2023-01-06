using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetChallenge.Application.Wrappers
{
    public class CustomError
    {
        public List<string>? Errors { get; set; }
        public bool IsShow { get; set; }

        public CustomError()
        {
            this.Errors = new List<string>();
        }

        public CustomError(string error, bool isShow)
        {
            (this.Errors = new List<string>()).Add(error);
            this.IsShow = isShow;
        }

        public CustomError(List<string> errors, bool isShow)
        {
            this.Errors = errors;
            this.IsShow = isShow;
        }
    }
}
