using BlogSN.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.ModelsBlogSN;
using Models.ModelsIdentity.IdentityAuth;

namespace Identity.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser { Id = "88aec81d-b5b0-45f3-8721-8d41560b02f7",UserName = "Vanya", Email = "1@mail.ru", PasswordHash = "EtoHash" }
            );

            builder.Entity<Category>().HasData(
                new Category{ Id = 1, Name = "Спорт"},
                new Category {Id = 2, Name = "Киберспорт" },
                new Category { Id = 3, Name = "Cпортмашины" });

            builder.Entity<Post>().HasData(
                new Post { Id = 1, Title = "Спорт", Description = "Описание спорта", Content = "Про спорт и все такое", CategoryId = 1 , ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b02f7" },
                new Post { Id = 2, Title = "Киберспорт", Description = "Описание киберспорта", Content = "Про киберспорт и все такое", CategoryId = 2, ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b02f7" },
                new Post { Id = 3, Title = "Киберспорт", Description = "Описание киберспорта", Content = "Про киберспорт и все такое", CategoryId = 2, ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b02f7" },
                new Post { Id = 4, Title = "Cпортмашины", Description = "Описание спортмашины", Content = "Про спортмашины и все такое", CategoryId = 3, ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b02f7" });

            builder.Entity<Comment>().HasData(
                new Comment { Id = 1, Content = "Норм тема", PostId = 1, ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b02f7", CreatedDate = DateTime.UtcNow },
                new Comment { Id = 2, Content = "Норм тема", PostId = 1, ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b02f7", CreatedDate = DateTime.UtcNow },
                new Comment { Id = 3, Content = "Норм тема", PostId = 2, ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b02f7", CreatedDate = DateTime.UtcNow },
                new Comment { Id = 4, Content = "Норм тема", PostId = 2, ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b02f7", CreatedDate = DateTime.UtcNow });

            builder.Entity<Rating>().HasData(
                new Rating { Id = 1, LikeStatus = true, PostId = 1, ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b02f7" },
                new Rating { Id = 2, LikeStatus = true, PostId = 1, ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b02f7" },
                new Rating { Id = 3, LikeStatus = false, PostId = 2, ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b02f7" },
                new Rating { Id = 4, LikeStatus = false, PostId = 2, ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b02f7" }
                );
        }
        
    }
}
