using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lugat.Api.Models;

namespace Lugat.Api.Data
{
    public class LugatContext : DbContext
    {
        public LugatContext(DbContextOptions<LugatContext> options) : base(options)
        {

        }

        public DbSet<Models.Lugat> Lugatlar { get; set; }
    }
}
