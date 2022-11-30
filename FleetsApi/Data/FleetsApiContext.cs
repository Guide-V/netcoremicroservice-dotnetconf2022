using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FleetsApi.Models;

namespace FleetsApi.Data
{
    public class FleetsApiContext : DbContext
    {
        public FleetsApiContext (DbContextOptions<FleetsApiContext> options)
            : base(options)
        {
        }

        public DbSet<Fleet> Fleet { get; set; } = default!;
        public DbSet<Driver> Driver { get; set; } = default!;
    }
}
