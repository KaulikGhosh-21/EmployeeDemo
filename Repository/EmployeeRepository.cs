using EmployeeDemoApp.Data;
using EmployeeDemoApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDemoApp.Repository
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly AppDbContext _context;
        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            Employee employee = await _context.Employees.FindAsync(id);
            if (employee == null)  return null;
            return employee;
        }

        public async Task<Employee> SaveNewEmployeeAsync(Employee data)
        {
            _context.Employees.Add(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<Employee> UpdateEmployeeAsync(int id, Employee data)
        {
            Employee employee = await _context.Employees.FindAsync(id);
            if (employee != null) 
            { 
                employee.Name = data.Name;
                employee.Email = data.Email;
                employee.Department = data.Department;
            }
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            Employee employee = await _context.Employees.FindAsync(id);
            if(employee == null)  return false;
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
