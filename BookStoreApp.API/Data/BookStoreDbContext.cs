using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.API.Data
{
    public partial class BookStoreDbContext : IdentityDbContext<ApiUser>
    {
        public BookStoreDbContext()
        {
        }

        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.Bio)
                    .HasMaxLength(250)
                    .IsFixedLength();

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasIndex(e => e.Isbn, "UQ__Books__447D36EAF1D725E0")
                    .IsUnique();

                entity.Property(e => e.Image)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Isbn)
                    .HasMaxLength(50)
                    .HasColumnName("ISBN")
                    .IsFixedLength();

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Summary)
                    .HasMaxLength(250)
                    .IsFixedLength();

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK_Books_ToTable");
            });

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER",
                    Id = "94c252a6-9a2d-4236-a5b9-a5daefe55cbd"
                },
                new IdentityRole
                {
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR",
                    Id = "cf90e635-2edd-429d-871f-e1bd28dcd30e"
                }
            );

            var hasher = new PasswordHasher<ApiUser>(); 

            modelBuilder.Entity<ApiUser>().HasData(
                new ApiUser
                {
                    Id = "34c434ac-ad11-4d05-82f7-a39ccea6045d",
                    Email = "admin@bookstore.com",
                    NormalizedEmail = "ADMIN@BOOKSTORE.COM",
                    UserName = "admin@bookstore.com",
                    NormalizedUserName = "ADMIN@BOOKSTORE.COM",
                    FirstName = "Admin",
                    LastName = "Admin",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                },
                new ApiUser
                {
                    Id = "74f518ec-b5aa-48b8-aa8a-3de90a93be2d",
                    Email = "user@bookstore.com",
                    NormalizedEmail = "USER@BOOKSTORE.COM",
                    UserName = "user@bookstore.com",
                    NormalizedUserName = "USER@BOOKSTORE.COM",
                    FirstName = "System",
                    LastName = "User",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1")
                }
            );

            modelBuilder.Entity<IdentityUserRole<string>> ().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "94c252a6-9a2d-4236-a5b9-a5daefe55cbd",
                    UserId = "74f518ec-b5aa-48b8-aa8a-3de90a93be2d"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "cf90e635-2edd-429d-871f-e1bd28dcd30e",
                    UserId = "34c434ac-ad11-4d05-82f7-a39ccea6045d"
                }
            );

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
