using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concrete.EfCore
{
    public class SeedData
    {
        public static void TestVerileriniDoldur(IApplicationBuilder app)
        {
            var context=app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();
            if(context!=null)
            {
                if(context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
                if(!context.Tags.Any())
                {
                    context.Tags.AddRange(
                        new Tag{Text="web programlama",Url="web-programlama",Color=TagColors.warning},
                        new Tag{Text="backend",Url="backend",Color=TagColors.info},
                        new Tag{Text="frontend",Url="frontend",Color=TagColors.success},
                        new Tag {Text="fullstack",Url="fullstack",Color=TagColors.secondary},
                         new Tag {Text="php",Url="php",Color=TagColors.primary}
                    );
                    context.SaveChanges();
                }
                if(!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User{UserName="durmuskaraarslan",Name="Durmuş Karaarslan",Email="durmuskaraarslan@gmail.com",Password="123456",Image="p1.jpg"},
                        new User{UserName="galipcankaraarslan",Name="Galip Can Karaarslan",Email="gckaraarslan@gmail.com",Password="123456",Image="p2.jpg"}
                    );
                    context.SaveChanges();
                }

                if(!context.Posts.Any())
                {
                    context.Posts.AddRange(
                        new Post{
                            Title="Asp.net core",
                             Description="Asp.net core",
                            Content="Asp.net Core Dersleri",
                            Url="aspnet-core",
                            IsActive=true,
                            PublishedOn=DateTime.Now.AddDays(-10),
                            Tags=context.Tags.Take(3).ToList(),
                            Image="1.jpg",
                            UserId=1,
                            Comments=new List<Comment> {
                                new Comment{Text="iyi bir kurs", PublishedOn=DateTime.Now.AddDays(-20),UserId=1},
                                new Comment{Text="çok faydalandığım bir kurs", PublishedOn=DateTime.Now.AddDays(-10),UserId=2}

                            }
                        },
                               new Post{
                            Title="php",
                             Description="php ders tanımı",
                            Content="php  Dersleri",
                             Url="php",
                            IsActive=true,
                            PublishedOn=DateTime.Now.AddDays(-20),
                            Tags=context.Tags.Take(2).ToList(),
                            Image="3.jpg",
                            UserId=1
                        },
                               new Post{
                            Title="java",
                             Description="java ders tanımı",
                            Content="java Dersleri",
                             Url="java",
                            IsActive=true,
                            PublishedOn=DateTime.Now.AddDays(-30),
                            Tags=context.Tags.Take(1).ToList(),
                             Image="2.jpg",
                            UserId=2
                        }
                        ,
                               new Post{
                            Title="react",
                             Description="react ders tanımı",
                            Content="raect Dersleri",
                             Url="react",
                            IsActive=true,
                            PublishedOn=DateTime.Now.AddDays(-40),
                            Tags=context.Tags.Take(1).ToList(),
                             Image="2.jpg",
                            UserId=2
                        }
                        ,
                               new Post{
                            Title="c++",
                             Description="c++ ders tanımı",
                            Content="c++ Dersleri",
                             Url="c++",
                            IsActive=true,
                            PublishedOn=DateTime.Now.AddDays(-50),
                            Tags=context.Tags.Take(1).ToList(),
                             Image="2.jpg",
                            UserId=2
                        }
                       
                    );
                    context.SaveChanges();
                }

            }
        }
    }
}