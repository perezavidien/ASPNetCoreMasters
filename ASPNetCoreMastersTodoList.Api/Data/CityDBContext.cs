using ASPNetCoreMastersTodoList.Api.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreMastersTodoList.Api.Data
{
    public class CityDBContext : DbContext
    {
        public CityDBContext(DbContextOptions<CityDBContext> options) : base(options)
        {
        }

        DbSet<City> City { get; set; }
    }
}
