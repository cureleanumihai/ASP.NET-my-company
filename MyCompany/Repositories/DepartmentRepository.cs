using Microsoft.EntityFrameworkCore;
using MyCompany.Data;
using MyCompany.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCompany.Repositories
{
    public class DepartmentRepository : IRepository<Department, int>
    {
        private readonly ApplicationDbContext context;

        public DepartmentRepository(ApplicationDbContext context) => this.context = context;
        public async Task Delete(int id)
        {
            var department = await context.Departments.FirstOrDefaultAsync(b => b.Id == id);
            if (department != null)
            {
                context.Remove(department);
            }
        }

        public async Task Edit(Department department)
        {
            context.Departments.Update(department);

        }
    

        public async Task<IEnumerable<Department>> GetAll()
        {
            return await context.Departments.ToListAsync();
        }

        public async Task<Department> GetById(int id)
        {
            return await context.Departments.FindAsync(id);
        }

        public async Task<Department> Insert(Department entity)
        {
            await context.Departments.AddAsync(entity);
            return entity;
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }
    }
}
