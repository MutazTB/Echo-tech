using AutoMapper;
using Complaints_Task_Repository.Repo_Implementation;
using Complaints_Task_Repository.Repo_Interface;
using Compliants_Task_Domain.Data;
using Compliants_Task_Domain.DTOs;
using Compliants_Task_Domain.Entities;
using Compliants_Task_Service.Svc_Implementation;
using Compliants_Task_Service.Svc_Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

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

builder.Services.AddTransient<IUserRepo, UserRepo>();
builder.Services.AddTransient<IUserSvc, UserSvc>();
builder.Services.AddTransient<IComplaintRepo, ComplaintRepo>();
builder.Services.AddTransient<IComplaintSvc, ComplaintSvc>();
builder.Services.AddTransient<IDemandRepo, DemandRepo>();
builder.Services.AddTransient<IDemandSvc, DemandSvc>();

var mappingConfig = new MapperConfiguration(mc =>
{
    mc.CreateMap<ComplaintDto, Complaint>();
    mc.CreateMap<Complaint, ComplaintDto>();
});

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddCors(policy => {
    policy.AddPolicy("OpenCorsPolicy", opt => opt.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("OpenCorsPolicy");
app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
