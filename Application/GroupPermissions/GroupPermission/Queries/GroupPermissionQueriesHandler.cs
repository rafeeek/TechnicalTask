using Application.GroupPermissions.Group.ViewModels;
using Application.GroupPermissions.GroupPermission.ViewModels;
using Application.GroupPermissions.Pages.ViewModels;
using Application.Helpers;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Application.GroupPermissions.GroupPermission.Queries
{
    public class GroupPermissionQueriesHandler : IRequestHandler<GroupPermissionGetListQuery, ResponseOfQqueries<List<GroupPermissionVM>>>
    {

        #region Ctor
        private readonly TaskDbContext _context;
        private readonly IMapper _mapper;

        public GroupPermissionQueriesHandler(TaskDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }
        #endregion

        public async Task<ResponseOfQqueries<List<GroupPermissionVM>>> Handle(GroupPermissionGetListQuery request, CancellationToken cancellationToken)
        {
            if (request.GroupId > 0)
            {
                var data = await _context.GroupPermissions.Where(a => a.GroupId == request.GroupId).ToListAsync();
                var dataVm = _mapper.Map<List<GroupPermissionVM>>(data);

                //Get Page Static Tabel from Json File @"Application\Helpers\Pages.json";
                var pages = ReadPageFile();

                var pagePermission = from page in pages
                                     join permission in dataVm
                                     on page.Id equals permission.PageId into obj
                                     from pagePermissin in obj.DefaultIfEmpty()
                                     select new
                                     {
                                         page,
                                         pageId = page.Id,
                                         canDelete = pagePermissin?.CanDelete == null ? false : pagePermissin.CanDelete,
                                         canAdd = pagePermissin?.CanAdd == null ? false : pagePermissin.CanAdd,
                                         canEdit = pagePermissin?.CanEdit == null ? false : pagePermissin.CanEdit,
                                         canView = pagePermissin?.CanView == null ? false : pagePermissin.CanView,
                                         groupId = request.GroupId,
                                         id = pagePermissin?.Id 
                                     };
                return new ResponseOfQqueries<List<GroupPermissionVM>>
                {
                    Status = true,
                    Data = pagePermission,
                    Message = ""
                };
            }
            else
            {
                var data = await _context.GroupPermissions.ToListAsync();
                var dataVm = _mapper.Map<List<GroupPermissionVM>>(data);

                //Get Page Static Tabel from Json File @"Application\Helpers\Pages.json";
                var pages = ReadPageFile();

                var pagePermission = from permission in dataVm
                                     join page in pages
                                     on permission.PageId equals page.Id
                                     select new { page, permission };
                return new ResponseOfQqueries<List<GroupPermissionVM>>
                {
                    Status = true,
                    Data = pagePermission,
                    Message = ""
                };
            }
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
