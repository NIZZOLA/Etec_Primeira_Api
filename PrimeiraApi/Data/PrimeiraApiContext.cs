using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PrimeiraApi.Models;

namespace PrimeiraApi.Data
{
    public class PrimeiraApiContext : DbContext
    {
        public PrimeiraApiContext (DbContextOptions<PrimeiraApiContext> options)
            : base(options)
        {
        }

        public DbSet<PrimeiraApi.Models.Cliente> Cliente { get; set; }

        public DbSet<PrimeiraApi.Models.Produto> Produto { get; set; }
    }
}
