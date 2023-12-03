using Holiday.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Holiday.Data
{
    public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApplicationUser> ApplicationUser { get; set; } = null!;
        public virtual DbSet<Richiesta> Richiesta { get; set; } = null!;
        public virtual DbSet<Scelta> Scelta { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Holiday;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Richiesta>(entity =>
            {
                entity.HasKey(e => e.IdRichiesta);

                entity.HasIndex(e => e.TipoRichiesta, "IX_Richiesta_TipoRichiesta");

                entity.HasIndex(e => e.UserId, "IX_Richiesta_UserID");

                entity.Property(e => e.FineRichiesta).HasColumnType("datetime");

                entity.Property(e => e.InizioRichiesta).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.TipoRichiestaNavigation)
                    .WithMany(p => p.Richiesta)
                    .HasForeignKey(d => d.TipoRichiesta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Richiesta_Scelta");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Richiesta)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Richiesta_AspNetUsers");

            });

            modelBuilder.Entity<Scelta>(entity =>
            {
                entity.HasKey(e => e.IdScelta);

                entity.Property(e => e.TipoScelta).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}