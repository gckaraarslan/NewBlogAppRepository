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
                        new Tag{Text="web programlama"},
                        new Tag{Text="backend"},
                        new Tag{Text="frontend"},
                        new Tag {Text="fullstack"},
                         new Tag {Text="php"}
                    );
                    context.SaveChanges();
                }
                if(!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User{UserName="durmuskaraarslan"},
                        new User{UserName="galipcankaraarslan"}
                    );
                    context.SaveChanges();
                }

                if(context.Posts.Any())
                {
                    context.Posts.AddRange(
                        new Post{
                            Title="Asp.net core",
                            Content="Asp.net Core Dersleri",
                            IsActive=true,
                            PublishedOn=DateTime.Now.AddDays(-10),
                            Tags=context.Tags.Take(3).ToList(),
                            UserId=1
                        },
                               new Post{
                            Title="php",
                            Content="php  Dersleri",
                            IsActive=true,
                            PublishedOn=DateTime.Now.AddDays(-20),
                            Tags=context.Tags.Take(2).ToList(),
                            UserId=1
                        },
                               new Post{
                            Title="Django",
                            Content="Django Dersleri",
                            IsActive=true,
                            PublishedOn=DateTime.Now.AddDays(-30),
                            Tags=context.Tags.Take(1).ToList(),
                            UserId=2
                        }
                       
                    );
                    context.SaveChanges();
                }

            }
        }
    }
}