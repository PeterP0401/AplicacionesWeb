using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalSpawn.Domain.Entities;
using AnimalSpawn.Domain.Interfaces;
using AnimalSpawn.Infraestruture.Data;
using Microsoft.EntityFrameworkCore;

namespace AnimalSpawn.Infraestruture.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {

        private readonly AnimalSpawnContext _context;

        public AnimalRepository(AnimalSpawnContext context)
        {
            this._context = context;

        }
        public async Task<IEnumerable<Animal>> GetAnimals()
        {
            var animals = await _context.Animal.ToListAsync();
            return animals;
        }
    }
}
