using BlazorApp.Server.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipsController : ControllerBase
    {
        // GET: api/<ShipsController>
        [HttpGet]
        public IEnumerable<Ship> Get()
        {
            return new Ship[2] { 
                new Ship { Id=1,Name="Oceanbreeze",Hold=2 }, 
                new Ship { Id = 2, Name = "Oceanbreeze II", Hold = 4 } };
        }

        // GET api/<ShipsController>/5
        [HttpGet("{id}")]
        public Ship Get(int id)
        {
            return new Ship { Id = id, Name = "Oceanbreeze", Hold = 2 };
        }

        // POST api/<ShipsController>
        [HttpPost]
        public void Post([FromBody] Ship ship)
        {
            if(ModelState.IsValid)
            {
                Console.WriteLine($"{ship.Id}");
            }
        }

        // PUT api/<ShipsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Ship ship)
        {
            Console.WriteLine($"{ship.Id}");
        }

        // DELETE api/<ShipsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Console.WriteLine($"{id}");
        }
    }
}
