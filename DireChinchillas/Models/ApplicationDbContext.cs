using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace DireChinchillas.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<ColourMutation> ColorMutations { get; set; }

        public DbSet<Chinchilla> Chinchillas { get; set; }

        public DbSet<Weight> WeightHistory { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ColourMutation>()
                .HasKey(c => c.ColourId)
                .Property(n=>n.Name).HasMaxLength(250).IsRequired();

            modelBuilder.Entity<Chinchilla>()
                .HasKey(c => c.ChinchillaId)
                .Property(n => n.Name).HasMaxLength(250).IsRequired();
            modelBuilder.Entity<Chinchilla>().HasRequired(c => c.Colour).WithMany().HasForeignKey(c => c.ColourId);
            modelBuilder.Entity<Chinchilla>().HasOptional(f => f.Father).WithMany().HasForeignKey(f => f.FatherId);
            modelBuilder.Entity<Chinchilla>().HasOptional(m => m.Mother).WithMany().HasForeignKey(m => m.MotherId);
            modelBuilder.Entity<Chinchilla>().HasMany(c => c.Children).WithMany()
            .Map(m =>
            {
                m.MapLeftKey("ParentId");
                m.MapRightKey("ChildId");
                m.ToTable("ChinchillaChildren");
            });

            modelBuilder.Entity<Weight>().HasKey(w => new { w.ChinchillaId, w.Date });
            modelBuilder.Entity<Weight>().HasRequired(w => w.Chinchilla).WithMany(c => c.WeightHistory).HasForeignKey(w => w.ChinchillaId);
        }
    }
}