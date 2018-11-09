using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public sealed class POIContext : DbContext
    {
        public POIContext(DbContextOptions<POIContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<POI> POIs { get; set; }
    }
}
