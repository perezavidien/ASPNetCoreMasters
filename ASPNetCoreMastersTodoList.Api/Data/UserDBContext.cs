﻿using ASPNetCoreMastersTodoList.Api.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreMastersTodoList.Api.Data
{

    public class UserDBContext : IdentityDbContext
    {
        public UserDBContext(DbContextOptions options) : base(options)
        {
        }
        DbSet<User> User { get; set; }
    }

}
