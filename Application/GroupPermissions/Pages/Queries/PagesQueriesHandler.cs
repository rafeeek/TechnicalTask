using Application.GroupPermissions.GroupPermission.ViewModels;
using Application.GroupPermissions.Pages.ViewModels;
using Application.Helpers;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.GroupPermissions.Pages.Queries
{
    public class PagesQueriesHandler : IRequestHandler<PagesGetListQuery , ResponseOfQqueries<List<PagesVM>>>
    {
        public async Task<ResponseOfQqueries<List<PagesVM>>> Handle(PagesGetListQuery request, CancellationToken cancellationToken)
        {
            //Get Page Static Tabel from Json File @"Application\Helpers\Pages.json";
            var pages = ReadPageFile();

            return new ResponseOfQqueries<List<PagesVM>>
            {
                Status = true,
                Data = pages,
                Message = ""
            };
        }

        private List<PagesVM> ReadPageFile()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Helpers\Pages.json");
            StreamReader reader = new StreamReader(path);
            var jsonString = reader.ReadToEnd();
            List<PagesVM> data = JsonConvert.DeserializeObject<List<PagesVM>>(jsonString);

            return data;
        }
    }
}
