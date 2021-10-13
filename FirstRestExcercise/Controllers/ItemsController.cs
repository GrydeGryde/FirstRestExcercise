using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstRestExcercise.Manager;
using FirstRestExcercise.Models;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstRestExcercise.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {

        private readonly ItemsManager _manager = new ItemsManager();


        // GET: api/<ItemController> ? substring=input
        [Route("Name/{substring}")] //kan bruge [HttpGet("Name/{substring}")] i stedet.
        [HttpGet]
            public IEnumerable<Item> Get([FromQuery] string substring)
            {
                return _manager.GetAll(substring);
            }


        // GET: api/<ItemController> ? substring=input    
        [Route("Itemquality")] //kan bruge [HttpGet("Itemquality/{substring}")] i stedet.
        [HttpGet]
        public IEnumerable<Item> GetAllQuality([FromQuery] int quality)
        {
            return _manager.GetAllQuality(quality);
        }


        // GET api/<ItemController>/
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
            public ActionResult<Item> Get(int id)
            {
                Item item = _manager.GetById(id);
                 if (item == null) return NotFound("No such item, id: " + id);
                 return Ok(item);

        }

        // POST api/<ItemsController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [HttpPost]
            public ActionResult<Item> Post([FromBody] Item value)
            {
                _manager.Add(value);
                return Created("http://localhost:42692/items/" + value.Id, value);
            }

        // PUT api/<ItemController>/5
        [HttpPut("{id}")]
            public Item Put(int id, [FromBody] Item value)
            {
                return _manager.Update(id, value);
            }

        // DELETE api/<ItemsController>/5
        [HttpDelete("{id}")]
            public Item Delete(int id)
            {
                return _manager.Delete(id);
            }
    }
    
}
