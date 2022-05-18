using BlogSN.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.ModelsBlogSN;
using Models.ModelsIdentity;
using Models.ModelsIdentity.IdentityAuth;

namespace Identity.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
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
                new Category{ Id = 1, Name = "Спорт", Description = "Спорт (англ. sport, сокращение от первоначального " +
                                                                    "старофранц. desport — «игра», «развлечение») — " +
                                                                    "организованная по определённым правилам деятельность " +
                                                                    "людей (спортсменов), состоящая в сопоставлении их " +
                                                                    "физических и/или интеллектуальных способностей. "},
                new Category {Id = 2, Name = "Киберспорт", Description = "Ки́берспо́рт (также известен как «компью́терный " +
                                                                         "спорт» или «электро́нный спорт», англ. esports) " +
                                                                         "— командное или индивидуальное соревнование на " +
                                                                         "основе компьютерных видеоигр. В России " +
                                                                         "признан официальным видом спорта."},
                new Category { Id = 3, Name = "Аниме", Description = "Аниме́  — японская мультипликация. В отличие от " +
                                                                     "мультфильмов других стран, предназначенных в " +
                                                                     "основном для просмотра детьми, бо́льшая часть " +
                                                                     "выпускаемого аниме рассчитана на подростковую и " +
                                                                     "имеет высокую популярность в мире. "},
                new Category {Id = 4, Name = "Кино и сериалы", Description = "Ну, тут очевидно про кино и сериалы, да?"},
                
                new Category {Id =5, Name = "Шаурма и друзья", Description = "Всем небезразличным к шаурме посвящается"},
                new Category {Id = 6, Name = "Путешествия", Description = "Путеше́ствие — передвижение по какой-либо " +
                                                                          "территории или акватории с целью их изучения, " +
                                                                          "а также с общеобразовательными, познавательными, " +
                                                                          "спортивными и другими целями."},
                new Category {Id = 7, Name = "Музыка", Description = "этот вид «отражает действительность и воздействует " +
                                                                     "на человека посредством осмысленных и особым образом " +
                                                                     "организованных по высоте и во времени звуковых " +
                                                                     "последований"},
                new Category {Id =8, Name = "Арт", Description = "одна из наиболее общих категорий эстетики, " +
                                                                 "искусствознания и художественной практики"},
                new Category {Id = 9, Name = "Мемы", Description = "единица значимой для культуры информации."},
                new Category {Id = 10, Name = "Культура", Description = "под культурой понимают человеческую деятельность " +
                                                                        "в её самых разных проявлениях, включая все формы " +
                                                                        "и способы человеческого самовыражения и самопознания"},
                new Category{Id = 11, Name = "Игры", Description = "форма деятельности в условных ситуациях, направленная " +
                                                                   "на воссоздание и усвоение общественного опыта, " +
                                                                   "фиксированного в социально закрепленных способах " +
                                                                   "осуществления предметных действий, в предметах науки " +
                                                                   "и культуры."}
                
                );

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
                new Rating { Id = "188aec81d-b5b0-45f3-8721-8d41560b02f7", LikeStatus = true, PostId = 1, ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b02f7" },
                new Rating { Id = "288aec81d-b5b0-45f3-8721-8d41560b02f7", LikeStatus = true, PostId = 1, ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b02f7" },
                new Rating { Id = "388aec81d-b5b0-45f3-8721-8d41560b02f7", LikeStatus = false, PostId = 2, ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b02f7" },
                new Rating { Id = "488aec81d-b5b0-45f3-8721-8d41560b02f7", LikeStatus = false, PostId = 2, ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b02f7" }
                );
        }
        
    }
}
