using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tender.Models;

namespace Tender.Data
{
    public class TenderContext : DbContext
    {
        public TenderContext (DbContextOptions<TenderContext> options)
            : base(options)
        {
        }

        public DbSet<Tender.Models.TenderDetails> Tender { get; set; }
    }
}
