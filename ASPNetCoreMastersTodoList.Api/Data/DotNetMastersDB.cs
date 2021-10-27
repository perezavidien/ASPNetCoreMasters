using ASPNetCoreMastersTodoList.Api.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreMastersTodoList.Api.Data
{
    public class DotNetMastersDB : DbContext
    {
        public DotNetMastersDB(DbContextOptions options) : base(options)
        {
        }

        DbSet<User> User { get; set; }
    }
}
