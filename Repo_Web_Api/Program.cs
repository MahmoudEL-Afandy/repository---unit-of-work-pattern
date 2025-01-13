using Microsoft.EntityFrameworkCore;
using RepositoryUOW_DataAccessEF.Data;
using RepositoryUOW_DataAccessEF.RepositoriesImplementation;
using RepositoryUOW_Entities.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// create connectionstring
builder.Services.AddDbContext<ApplicationDbContext>(options=> options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// we should register the generic repository 
//builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>)); // these where i don't need to use IUnitOfWork & UnitOfWork 
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); // these where i need to use the iunitofwork & unitofwork 
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

app.UseAuthorization();

app.MapControllers();

app.Run();
