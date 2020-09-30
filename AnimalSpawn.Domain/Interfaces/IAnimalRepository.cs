using AnimalSpawn.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnimalSpawn.Domain.Interfaces
{
    public interface IAnimalRepository
    {
        public Task<IEnumerable<Animal>> GetAnimals();
    }
}
