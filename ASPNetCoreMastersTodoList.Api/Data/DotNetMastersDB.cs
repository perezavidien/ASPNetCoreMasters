using ASPNetCoreMastersTodoList.Api.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreMastersTodoList.Api.Data
{
    public class DotNetMastersDB : IdentityDbContext
    {
        public DotNetMastersDB(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Item> Item { get; set; }
    }
}
