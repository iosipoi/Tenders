using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TendersApi.Model;

namespace TendersApi.Data
{
    public class TendersApiContext : DbContext
    {
        public TendersApiContext (DbContextOptions<TendersApiContext> options)
            : base(options)
        {
        }

        public DbSet<TendersApi.Model.Offer> Offer { get; set; }

        public DbSet<TendersApi.Model.Tender> Tender { get; set; }
    }
}
