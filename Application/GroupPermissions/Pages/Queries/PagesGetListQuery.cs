using Application.GroupPermissions.GroupPermission.ViewModels;
using Application.GroupPermissions.Pages.ViewModels;
using Application.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.GroupPermissions.Pages.Queries
{
    public class PagesGetListQuery : IRequest<ResponseOfQqueries<List<PagesVM>>>
    {

    }
}
