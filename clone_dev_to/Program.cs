using clone_dev_to.Data;
using clone_dev_to.Models;
using clone_dev_to.Repositories;
using clone_dev_to.Services;
using clone_dev_to.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);


// allow cors
builder.Services.AddCors();

// register db context
var connectionString = builder.Configuration["ConnectionStrings:Postgres"];
builder.Services.AddDbContext<BloggerContext>(
    opts => opts.UseNpgsql(connectionString));

// Add services to the container.
builder.Services.AddScoped<IRepository<PostTagModel>,PostTagRepository>();
builder.Services.AddScoped<IRepository<PostModel>, PostRepository>();
builder.Services.AddScoped<IPostTagService, PostTagService>();
builder.Services.AddScoped<IPostService, PostService>();

builder.Services.AddControllers().AddNewtonsoftJson();
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

app.UseHttpsRedirection();

// global cors policy
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials()); // allow credentials

app.UseAuthorization();

app.MapControllers();

app.Run();