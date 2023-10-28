using Complaints_Task_Repository.Repo_Implementation;
using Complaints_Task_Repository.Repo_Interface;
using Compliants_Task_Domain.Data;
using Compliants_Task_Domain.Entities;
using Compliants_Task_Domain.Refit;
using Compliants_Task_Service.Svc_Implementation;
using Compliants_Task_Service.Svc_Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Refit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddMvc();
ConfigurationManager Configuration = builder.Configuration;
IWebHostEnvironment environment = builder.Environment;

builder.Services.AddDbContext<ComplaintDBContext>(options => {
    // Our DATABASE_URL from js days
    string connectionString = Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
        .AddEntityFrameworkStores<ComplaintDBContext>()
        .AddDefaultTokenProviders();

builder.Services.AddHttpClient<IComplaintAPI>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7099/api/Complaint");
}).AddTypedClient(client => RestService.For<IComplaintAPI>(client));

builder.Services.AddHttpClient<IDemandAPI>(client =>
{
    client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
}).AddTypedClient(client => RestService.For<IDemandAPI>(client));

builder.Services.AddTransient<IUserRepo, UserRepo>();
builder.Services.AddTransient<IUserSvc, UserSvc>();
builder.Services.AddTransient<IComplaintRepo, ComplaintRepo>();
builder.Services.AddTransient<IComplaintSvc, ComplaintSvc>();
builder.Services.AddTransient<IDemandRepo, DemandRepo>();
builder.Services.AddTransient<IDemandSvc, DemandSvc>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
