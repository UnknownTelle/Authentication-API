using System;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace COMP2001_API.Models
{
    public partial class COMP2001_CAbbottContext : DbContext
    {
        public COMP2001_CAbbottContext()
        {
        }

        public COMP2001_CAbbottContext(DbContextOptions<COMP2001_CAbbottContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Password> Passwords { get; set; }
        public virtual DbSet<SessionTable> SessionTables { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Password>(entity =>
            {
                entity.ToTable("passwords");

                entity.Property(e => e.PasswordId).HasColumnName("password_id");

                entity.Property(e => e.DateChanged)
                    .HasColumnType("datetime")
                    .HasColumnName("date_changed");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Passwords)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__passwords__date___6442E2C9");
            });

            modelBuilder.Entity<SessionTable>(entity =>
            {
                entity.HasKey(e => e.SessionId)
                    .HasName("PK__session___69B13FDC5F8F33D1");

                entity.ToTable("session_table");

                entity.Property(e => e.SessionId).HasColumnName("session_id");

                entity.Property(e => e.SessionTime)
                    .HasColumnType("datetime")
                    .HasColumnName("session_time");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SessionTables)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__session_t__sessi__671F4F74");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("user_email");

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("user_password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        public bool Validate(User user)
        {
            Database.ExecuteSqlRaw("EXEC validate_user  @user_email, @user_password",
                new SqlParameter("@user_email", user.UserEmail),
                new SqlParameter("@user_password", user.UserPassword)
                );

            throw new NotImplementedException();
        }

        public void Register(User user, out string register)
        {
            SqlParameter parameter = new SqlParameter();

            Database.ExecuteSqlRaw("EXEC register @first_name, @last_name, @user_email, @user_password, @response_message",
                new SqlParameter("@first_name", user.FirstName),
                new SqlParameter("@last_name", user.LastName),
                new SqlParameter("@user_email", user.UserEmail),
                new SqlParameter("@user_password", user.UserPassword),
                new SqlParameter("@responce_message", user.ResponceMessage.ToString()), 
                parameter);

            register = parameter.Value.ToString();

            throw new NotImplementedException();
        }

        public void Update(User user, int id)
        {
            Database.ExecuteSqlRaw("EXEC update_user @user_id, @first_name, @last_name, @user_email, @user_password",
                new SqlParameter("@user_id", id),
                new SqlParameter("@first_name", user.FirstName),
                new SqlParameter("@last_name", user.LastName),
                new SqlParameter("@user_email", user.UserEmail),
                new SqlParameter("@user_password", user.UserPassword)
                );

            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            Database.ExecuteSqlRaw("EXEC delete_user @user_id",
                new SqlParameter("@user_id", id)
                );

            throw new NotImplementedException();
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
