using Microsoft.EntityFrameworkCore;
using MyCompany.Data;
using MyCompany.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCompany.Repositories
{
    public class CityRepository : IRepository<City, int>
    {
        private readonly ApplicationDbContext context;

        public CityRepository(ApplicationDbContext context) => this.context = context;
        public async Task Delete(int id)
        {
            var city = await context.Cities.FirstOrDefaultAsync(b => b.Id == id);
            if (city != null)
            {
                context.Remove(city);
            }
        }

        public async Task Edit(City city)
        {
            context.Cities.Update(city);

        }

        public async Task<IEnumerable<City>> GetAll()
        {
            return await context.Cities.ToListAsync();
        }

        public async Task<City> GetById(int id)
        {
            return await context.Cities.FindAsync(id);
        }

        public async Task<City> Insert(City entity)
        {
            await context.Cities.AddAsync(entity);
            return entity;
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }
    }
}
