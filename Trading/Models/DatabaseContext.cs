using Microsoft.EntityFrameworkCore;

namespace TradingApp.Models
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("User");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.email).HasColumnName("email");
                entity.Property(e => e.password).HasColumnName("password");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.ToTable("Profile");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.User_id).HasColumnName("user_id");
                entity.Property(e => e.Last_name).HasColumnName("Lastname");
                entity.Property(e => e.First_name).HasColumnName("FirstName");
                entity.Property(e => e.Address).HasColumnName("address");
            });

            modelBuilder.Entity<Trade>(entity =>
            {
                entity.ToTable("Trade");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Profile_id).HasColumnName("profile_id");
                entity.Property(e => e.Symbol).HasColumnName("symbol");
                entity.Property(e => e.Quanity).HasColumnName("quantity");
                entity.Property(e => e.Open_price).HasColumnName("open_price");
                entity.Property(e => e.Close_price).HasColumnName("close_price");
                entity.Property(e => e.Open_datetime).HasColumnName("open_datetime");
                entity.Property(e => e.Close_datetime).HasColumnName("close_datetime");
                entity.Property(e => e.Open).HasColumnName("open");
            });

            modelBuilder.Entity<Wire>(entity =>
            {
                entity.ToTable("Wire");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Profile_id).HasColumnName("profile_id");
                entity.Property(e => e.Amount).HasColumnName("amount");
                entity.Property(e => e.Withdrawal).HasColumnName("withdrawal");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}