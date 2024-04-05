using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UserArticleApi.Data;
using UserArticleApi.Repertory;
using UserArticleApi.Services;


var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
builder .Services.AddScoped<IUserRepertory,UserRepertory>();
builder .Services.AddScoped<IUserServices,UserServices>();
builder.Services.AddScoped<IArticleRepertory, ArticleRepertory>();
builder.Services.AddScoped<IArticleServices, ArticleServices>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
