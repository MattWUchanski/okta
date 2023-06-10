using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationOkta1.Models;

namespace WebApplicationOkta1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Task2137Controller : ControllerBase
    {
        private readonly TaskContext _context;

        public Task2137Controller(TaskContext context)
        {
            _context = context;
        }

        // GET: api/Task2137
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Task2137>>> GetTasks()
        {
            return await _context.Tasks.ToListAsync();
        }

        // GET: api/Task2137/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Task2137>> GetTask2137(int id)
        {
            var task2137 = await _context.Tasks.FindAsync(id);

            if (task2137 == null)
            {
                return NotFound();
            }

            return task2137;
        }

        // PUT: api/Task2137/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask2137(int id, Task2137 task2137)
        {
            if (id != task2137.Id)
            {
                return BadRequest();
            }

            _context.Entry(task2137).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Task2137Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Task2137
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Task2137>> PostTask2137(Task2137 task2137)
        {
            _context.Tasks.Add(task2137);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTask2137", new { id = task2137.Id }, task2137);
        }

        // DELETE: api/Task2137/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Task2137>> DeleteTask2137(int id)
        {
            var task2137 = await _context.Tasks.FindAsync(id);
            if (task2137 == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(task2137);
            await _context.SaveChangesAsync();

            return task2137;
        }

        private bool Task2137Exists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}
