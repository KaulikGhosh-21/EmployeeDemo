
using EmployeeDemoApp.Data;
using EmployeeDemoApp.Endpoints;
using EmployeeDemoApp.Repository;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDemoApp
{
    public class Program
    {
        public static void Main(string[] args)
        {

            // Kaulik Ghosh 

            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<AppDbContext>(options => 
            options.UseSqlServer(connectionString));


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.MapEmployeeEndpoints();

            app.Run();
        }
    }
}
