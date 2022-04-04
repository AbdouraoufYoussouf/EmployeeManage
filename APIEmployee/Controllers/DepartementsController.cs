#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIEmployee.Models;
using EmployeManagementAPI.Data;
using APIEmployee.DTO;

namespace APIEmployee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartementsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DepartementsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Departements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Departement>>> GetDepartements()
        {
            return await _context.Departements.ToListAsync();
        }

        // GET: api/Departements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Departement>> GetDepartement(int id)
        {
            var departement = await _context.Departements.FindAsync(id);

            if (departement == null)
            {
                return NotFound();
            }

            return departement;
        }

        // PUT: api/Departements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartement(int id, DepartDTO departDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var depart = await _context.Departements.FindAsync(id);
            if(depart==null){
                return Ok($"The departement of id = {id} is not Exist");
            }
            depart.DepId = departDTO.DepId;
            depart.DepName = departDTO.DepName;
            
             _context.Entry(depart).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Departements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DepartDTO>> PostDepartement(DepartDTO departDTO)
        {
            var depart =  _context.Departements.Where(d=>d.DepName == departDTO.DepName).FirstOrDefault();
            if (depart != null)
            {
                return Ok("Departement is already exist");
            }
            Departement departement = new Departement{
                DepName = departDTO.DepName
            };
            _context.Departements.Add(departement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDepartement", new { id = departement.DepId }, departement);
        }

        // DELETE: api/Departements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartement(int id)
        {
            var departement = await _context.Departements.FindAsync(id);
            if (departement == null)
            {
                return NotFound();
            }

            _context.Departements.Remove(departement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DepartementExists(int id)
        {
            return _context.Departements.Any(e => e.DepId == id);
        }
    }
}
