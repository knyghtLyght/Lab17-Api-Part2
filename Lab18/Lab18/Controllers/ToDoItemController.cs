using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab18.Models;
using Lab18.Data;

namespace Lab18.Controllers
{
    [Route("api/[controller]")]
    public class ToDoItemController : Controller
    {
        private ToDoAppDbContext _context;

        public ToDoItemController(ToDoAppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<ToDo> GetAll()
        {
            return _context.ToDoItems.ToList();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = _context.ToDoItems.FirstOrDefault(t => t.ID == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ToDo item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.ToDoItems.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetTodo", new { id = item.ID }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]ToDo item)
        {
            if (item == null || item.ID != id)
            {
                return BadRequest();
            }
            var todo = _context.ToDoItems.FirstOrDefault(t => t.ID == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.ToDoItems.Update(todo);
            _context.SaveChanges();
            return new NoContentResult();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.ToDoItems.FirstOrDefault(t => t.ID == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.ToDoItems.Remove(todo);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
