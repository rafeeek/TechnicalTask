using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers
{
    public class ResponseOfQqueries<T>
    {
        public object? Data { get; set; }
        public string? Message { get; set; }
        public bool Status { get; set; }
    }
}
