using AnimalSpawn.Domain.Interfaces;
using AnimalSpawn.Infraestruture.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace AnimalSpawn.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalRepository _repository;
        public AnimalController(IAnimalRepository repository)
        {
            this._repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var animals = await _repository.GetAnimals();
            return Ok(animals);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var animal = await _repository.GetAnimal(id);
            return Ok(animal);
        }
        ///Siguiente clase 25 de Septiembre
    }
}