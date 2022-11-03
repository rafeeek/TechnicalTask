﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.GroupPermissionsAggregate
{
    public class GroupPermission
    {

        [Key]
        public int Id { get; set; }

        public int GroupId { get; set; }
        public Group? Group { get; set; }
        public int PageId { get; set; }
        public bool CanView { get; set; }
        public bool CanAdd { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }


    }
}
