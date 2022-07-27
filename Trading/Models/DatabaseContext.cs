using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Trading.Models
{
    public partial class DatabaseContext : IdentityDbContext<IdentityUser>
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        private DbSet<UserModel> users = null!;

        public virtual DbSet<UserModel> GetUsers()
        {
            return users;
        }

        public virtual void SetUsers(DbSet<UserModel> value)
        {
            users = value;
        }

        public virtual DbSet<ProfileModel> Profiles { get; set; } = null!;
        public virtual DbSet<TradeModel> Trades { get; set; } = null!;
        public virtual DbSet<WireModel> Wires { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("User");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Email).HasColumnName("email");
                entity.Property(e => e.Password).HasColumnName("password");
            });

            modelBuilder.Entity<ProfileModel>(entity =>
            {
                entity.ToTable("Profile");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.User_id).HasColumnName("user_id");
                entity.Property(e => e.Last_name).HasColumnName("Lastname");
                entity.Property(e => e.First_name).HasColumnName("FirstName");
                entity.Property(e => e.Address).HasColumnName("address");
            });

            modelBuilder.Entity<TradeModel>(entity =>
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

            modelBuilder.Entity<WireModel>(entity =>
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