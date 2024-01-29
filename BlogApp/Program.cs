using BlogApp.Data.Concrete.EfCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BlogContext>(options=>{
    var config=builder.Configuration;
    var connectionString=config.GetConnectionString("sql_connection");
    options.UseSqlite(connectionString);
    //options.UseSqlite(builder.Configuration["ConnectionStrings:sql_connection"]); // instead of 6,7 and 8th lines...
});
var app = builder.Build();

SeedData.TestVerileriniDoldur(app);

//app.MapGet("/", () => "Hello World!"); //instead of this, we'r gonna use default route...
app.MapDefaultControllerRoute();

app.Run();
//branch test