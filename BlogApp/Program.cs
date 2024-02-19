using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EfCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BlogContext>(options=>{
    var config=builder.Configuration;
    var connectionString=config.GetConnectionString("sql_connection");
    options.UseSqlite(connectionString);
    //options.UseSqlite(builder.Configuration["ConnectionStrings:sql_connection"]); // instead of 6,7 and 8th lines...
});
builder.Services.AddScoped<IPostRepository,EfPostRepository>();
builder.Services.AddScoped<ITagRepository,EfTagRepository>();
builder.Services.AddScoped<ICommentRepository,EfCommentRepository>();
builder.Services.AddScoped<IUserRepository,EfUserRepository>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
var app = builder.Build();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

SeedData.TestVerileriniDoldur(app);

//app.MapGet("/", () => "Hello World!"); //instead of this, we'r gonna use default route...
//app.MapDefaultControllerRoute();  

app.MapControllerRoute(
    name:"post_details",
    pattern:"posts/details/{url}",
    defaults:new {controller="Posts", action="Details"}
);
app.MapControllerRoute(
    name:"posts_by_tag",
    pattern:"posts/tag/{tagName}",
    defaults:new {controller="Posts", action="Index"}
);

app.MapControllerRoute(
    name:"default",
    pattern:"{controller=Home}/{action=Index}/{id?}"
);

app.Run();
//branch test