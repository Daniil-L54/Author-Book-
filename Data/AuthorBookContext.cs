using Microsoft.EntityFrameworkCore;
using AuthorBookApi.Models;

namespace AuthorBookApi.Data
{
    public class AuthorBookContext : DbContext
    {
        public AuthorBookContext(DbContextOptions<AuthorBookContext> options) : base(options) { }

        public DbSet<TacGia> TacGias { get; set; }
        public DbSet<Sach> Sachs { get; set; }
        public DbSet<TacGiaSach> TacGiaSachs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TacGiaSach>()
                .HasKey(ts => new { ts.TacGiaId, ts.SachId });

            modelBuilder.Entity<TacGiaSach>()
                .HasOne(ts => ts.TacGia)
                .WithMany(t => t.TacGiaSachs)
                .HasForeignKey(ts => ts.TacGiaId);

            modelBuilder.Entity<TacGiaSach>()
                .HasOne(ts => ts.Sach)
                .WithMany(s => s.TacGiaSachs)
                .HasForeignKey(ts => ts.SachId);
        }
    }
}
