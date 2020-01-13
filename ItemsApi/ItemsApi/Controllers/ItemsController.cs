using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItemsApi.Models;
using ItemsApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ItemsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IRepository repository;

        public ItemsController(IRepository repository)
        {
            this.repository = repository;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Item> Get()
        {
            return repository.GetItems();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Item Get(int id)
        {
            return repository.GetItem(id);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Item value)
        {
            var created = repository.CreateItem(value);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Item value)
        {
            try
            {
                return NoContent();
            }
            catch (Exception)
            {
                if (!DoesItemExist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            repository.DeleteItem(id);
            return NoContent();
        }

        private bool DoesItemExist(int id)
        {
            return repository.GetItem(id) != null;
        }
    }
}