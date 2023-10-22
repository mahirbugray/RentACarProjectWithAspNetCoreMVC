using BAU_Project_RentACarPortal.App.DataAccess.Contexts;
using BAU_Project_RentACarPortal.App.Service.Extensions ;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<RentalDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr"))
    );


builder.Services.AddExtensions();

builder.Services.AddSession(
    options => options.IdleTimeout = TimeSpan.FromMinutes(120)  //session'larýn ömrünü uzatýyoruz (default 20 dk (oturum sona ermezse))
    );

builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = new PathString("/Account/AccessDenied");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1", "?code={0}");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Anasayfa}/{action=Index}/{id?}");


app.Run();
