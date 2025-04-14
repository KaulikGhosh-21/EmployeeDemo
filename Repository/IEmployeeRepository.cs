using EmployeeDemoApp.Models;

namespace EmployeeDemoApp.Repository
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllEmployeesAsync();
        Task<Employee?> GetEmployeeByIdAsync(int id);

        Task<Employee> SaveNewEmployeeAsync(Employee data);

        Task<Employee> UpdateEmployeeAsync(int id, Employee data);

        Task<bool> DeleteEmployeeAsync(int id);

    }
}
