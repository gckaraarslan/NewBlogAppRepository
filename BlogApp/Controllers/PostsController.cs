using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EfCore;
using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Controllers
{
    public class PostsController:Controller
    {
        private IPostRepository _postRepository;
        
        public PostsController(IPostRepository postRepository )
        {
            _postRepository=postRepository;
            
        }
        public async Task<IActionResult> Index(string tagName)
        {
            var posts=_postRepository.Posts;
            if(!string.IsNullOrEmpty(tagName))
            {
                posts=posts.Where(x=>x.Tags.Any(t=>t.Url==tagName));
            }
            return View(new PostViewModel{
                Posts= await posts.ToListAsync()
            });  
        }



        public async Task<IActionResult> Details(string url)
        {
            return View(await _postRepository.Posts.Include(x=>x.Tags).FirstOrDefaultAsync(p=>p.Url==url));
        }
    }
}