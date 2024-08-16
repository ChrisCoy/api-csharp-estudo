using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Infra
{
    public class SqlServerDbContext : DbContext
    {
        //public DbSet<MyEntity> MyEntities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

        public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<MyEntity>(entity =>
            //{
            //    entity.HasKey(e => e.Id);
            //    entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            //    // Add more configurations as needed
            //});
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=localhost;Database=aprendendo;User Id=sa;Password=1234;");
        //}
    }

    public class User 
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<Pedido> Pedidos { get; set; }
    }

    public class Pedido
    {
        [Key]
        public Guid Id { get; set; }

        public string UserId { get; set; }
    }
}
