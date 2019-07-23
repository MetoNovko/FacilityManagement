﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FacilityManagement.Web.Areas.Identity
{
    public class EmployeeUser: IdentityUser
    {
        [PersonalData]
        public string Name { get; set; }
        [PersonalData]
        public string Position { get; set; }
        public string ThumbnailUrl { get; set; }
    }
}
