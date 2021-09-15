using Expenser_Tracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Expenser_Tracker.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Transacao> Transacoes { get; set; }
    }
}
