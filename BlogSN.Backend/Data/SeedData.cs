using BlogSN.Backend.Data;
using BlogSN.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogSN.Backend.Data;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new BlogSnDbContext(
                   serviceProvider.GetRequiredService<
                       DbContextOptions<BlogSnDbContext>>()))
        {
            if (context == null || context.Posts == null)
            {
                throw new ArgumentNullException("DbContext doesn't exist");
            }

            if (context.Posts.Any())
            {
                return; // DB has been seeded
            }

            context.Roles.Add(
                new Role()
                {
                    Id = 1,
                    Name = "admin"
                }
            );
            context.Users.Add(
                new User()
                {
                    Id = 1,
                    DateOfBirthday = DateTime.Now,
                    Email = @"admin@gmail.com",
                    Name = "Ivan",
                    Password = "123",
                    RoleId = 1,
                    Surname = "Silvestrov"
                });
            context.Posts.AddRange(
                new Post()
                {
                    Id = 1,
                    UserId = 1,
                    Title = "It's test title",
                    Description = @"about post description",
                    Content =
                        @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer purus erat, viverra eu dolor 
                          et, fringilla faucibus turpis. Vestibulum maximus fermentum ante.",
                    DateCreated = DateTime.Now,
                },
                new Post()
                {
                    Id = 2,
                    UserId = 1,
                    Title = "It's test 2 title",
                    Description = @"about post description 2",
                    Content =
                        @"Nullam quam justo, imperdiet eu interdum nec, dapibus vitae lectus. Etiam vitae mollis justo, bibendum vestibulum eros. Nullam nec euismod velit. Nunc tristique consectetur turpis vel dictum. Morbi finibus quis nulla sit amet faucibus.",
                    DateCreated = DateTime.Now,
                },
                new Post()
                {
                    Id = 3,
                    UserId = 1,
                    Title = "It's test 3 title",
                    Description = @"about post description 3",
                    Content =
                        @"Aenean quis purus in lacus laoreet faucibus. Phasellus et sem condimentum, fringilla tellus at, tincidunt dolor. Integer mollis quis mauris a vehicula.",
                    DateCreated = DateTime.Now,
                }
            );
            context.SaveChanges();
        }
    }
}