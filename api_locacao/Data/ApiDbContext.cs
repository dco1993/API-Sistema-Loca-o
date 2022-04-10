using api_locacao.Model;
using Microsoft.EntityFrameworkCore;

namespace api_locacao.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }

        public DbSet<ClienteModel> Cliente { get; set; }
        public DbSet<FilmeModel> Filme { get; set; }
        public DbSet<LocacaoModel> Locacao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LocacaoModel>()
            .HasOne(c => c.Cliente)
            .WithOne()
            .HasForeignKey<LocacaoModel>(c => c.Id_Cliente);

            modelBuilder.Entity<LocacaoModel>()
            .HasOne(f => f.Filme)
            .WithOne()
            .HasForeignKey<LocacaoModel>(f => f.Id_Filme);
        }
    }
}
