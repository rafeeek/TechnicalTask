using Domain.GroupPermissionsAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class TaskDbContext : DbContext
    {
        #region Ctor
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {

        }
        #endregion

        #region Domain
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupPermission> GroupPermissions { get; set; }
        #endregion
    }
}
