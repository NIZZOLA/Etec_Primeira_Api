using Microsoft.EntityFrameworkCore;

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
