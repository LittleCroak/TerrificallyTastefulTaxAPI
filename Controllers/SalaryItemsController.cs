using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaxAPI.Calculators;
using TaxAPI.Models;

namespace TaxAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryItemsController : ControllerBase
    {
        private readonly CalculatorContext _context;

        public SalaryItemsController(CalculatorContext context)
        {
            _context = context;
        }

        // GET: api/SalaryItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalaryItems>>> GetSalaryItems()
        {
            return await _context.SalaryItems.ToListAsync();
        }

        // GET: api/SalaryItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalaryItems>> GetSalaryItems(long id)
        {
            var salaryItems = await _context.SalaryItems.FindAsync(id);

            if (salaryItems == null)
            {
                return NotFound();
            }

            return salaryItems;
        }

        // PUT: api/SalaryItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalaryItems(long id, SalaryItems salaryItems)
        {
            if (id != salaryItems.Id)
            {
                return BadRequest();
            }

            _context.Entry(salaryItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalaryItemsExists(id))
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

        // POST: api/SalaryItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SalaryItems>> PostSalaryItems(SalaryItems salaryItems)
        {
            TaxCalculator taxCalculator = new TaxCalculator();

            try
            {
                salaryItems = taxCalculator.calculateTax(salaryItems);
            }
            catch (Exception e)
            {
                return BadRequest();
            }

            _context.SalaryItems.Add(salaryItems);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSalaryItems), new { id = salaryItems.Id }, salaryItems);
        }

        // DELETE: api/SalaryItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalaryItems(long id)
        {
            var salaryItems = await _context.SalaryItems.FindAsync(id);
            if (salaryItems == null)
            {
                return NotFound();
            }

            _context.SalaryItems.Remove(salaryItems);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SalaryItemsExists(long id)
        {
            return _context.SalaryItems.Any(e => e.Id == id);
        }
    }
}
