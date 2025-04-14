using EmployeeDemoApp.Repository;
using EmployeeDemoApp.Models;

namespace EmployeeDemoApp.Endpoints
{
    public static class EmployeeEndpoints
    {
        public static void MapEmployeeEndpoints (this WebApplication webApplication)
        {
            webApplication.MapGet("/employees", async (IEmployeeRepository repo) =>
            {
                var employees = await repo.GetAllEmployeesAsync();
                return Results.Ok(employees);
            }
            );

            webApplication.MapGet("/employee/{id:int}", async (int id, IEmployeeRepository repo) =>
            {
                var employee = await repo.GetEmployeeByIdAsync(id);
                if(employee == null) return Results.NotFound();
                return Results.Ok(employee);
            }
            );

            webApplication.MapPost("/employee", async (Employee data, IEmployeeRepository repo) =>
            {
                return Results.Created($"employee {data.Id} created", 
                    await repo.SaveNewEmployeeAsync(data));
            });

            webApplication.MapPut("/employee/{id:int}", async (int id, Employee data, IEmployeeRepository repo) =>
            {
                return Results.Ok(
                    await repo.UpdateEmployeeAsync(id, data));
            });

            webApplication.MapDelete("/employee/{id:int}", async (int id, IEmployeeRepository repo) =>
            {
                var employee = await repo.DeleteEmployeeAsync(id);
                return employee ? Results.NoContent() : Results.NotFound();
            }
           );
        }
    }
}
