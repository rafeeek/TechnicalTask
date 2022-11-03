using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers
{
    public class Helper
    {
        public static ResponseOfQqueries<T> ReturnResponse<T>(T param, bool status, string message)
        {
            return new ResponseOfQqueries<T>
            {
                Data = param,
                Status = status,
                Message = message
            };
        }
    }
}
