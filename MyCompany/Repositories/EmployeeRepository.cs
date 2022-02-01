using Microsoft.EntityFrameworkCore;
using MyCompany.Data;
using MyCompany.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCompany.Repositories
{
    public class EmployeeRepository : IRepository<Employee, int>
    {
        private readonly ApplicationDbContext context;

        public EmployeeRepository(ApplicationDbContext context) => this.context = context;
        public async Task Delete(int id)
        {
            var employee = await context.Employees.FirstOrDefaultAsync(b => b.Id == id);
            if (employee != null)
            {
                context.Remove(employee);
            }
        }

        public async Task Edit(Employee employee)
        {
            context.Employees.Update(employee);

        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await context.Employees.ToListAsync();
        }

        public async Task<Employee> GetById(int id)
        {
            return await context.Employees.FindAsync(id);
        }

        public async Task<Employee> Insert(Employee entity)
        {
            await context.Employees.AddAsync(entity);
            return entity;
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }
    }
}
