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
using System.Web.Http.Description;
using APIEmployee.DTO;

namespace APIEmployee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        //[ResponseType(typeof(EmployeeDetailsDTO))]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees =  _context.Employees.Include(e=>e.Department).Select(e =>
                new EmployeeDetailsDTO(){
                    EmpId = e.EmpId,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Email = e.Email,
                    DateOfBrith = e.DateOfBrith,
                    PhotoPath = e.PhotoPath,
                    DepId = e.DepId,
                    Departement = e.Department.DepName
                }
            ).ToList();
            return Ok(employees);
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
         [ResponseType(typeof(EmployeeDetailsDTO))]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var empl = await _context.Employees.Include(e=>e.Department).FirstOrDefaultAsync(e=>e.EmpId==id);
            if(empl==null){
                return Ok($"Employe not exit by this Id:{id}");
            }
           var employee =  new EmployeeDetailsDTO{
                    EmpId = empl.EmpId,
                    FirstName = empl.FirstName,
                    LastName = empl.LastName,
                    Email = empl.Email,
                    DateOfBrith = empl.DateOfBrith,
                    PhotoPath = empl.PhotoPath,
                    Departement = empl.Department.DepName,
                    DepId = empl.DepId
                } ;
            return Ok(employee);
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, EmployeeUpdateDTO  emplUpDto)
        {
           var empl = await _context.Employees.FindAsync(id);
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            if(empl == null){
                return Ok("Employe Is not Ecist ");
            }

            empl.EmpId = emplUpDto.EmpId;
            empl.FirstName = emplUpDto.FirstName;
            empl.LastName = emplUpDto.LastName;
            empl.Email = emplUpDto.Email;
            empl.DateOfBrith = emplUpDto.DateOfBrith;
            empl.PhotoPath = emplUpDto.PhotoPath;
            empl.DepId = emplUpDto.DepId;

            _context.Entry(empl).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok("Employe Updated succesfully");
        }

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeUpdateDTO>> PostEmployee(EmployeeUpdateDTO emplUpDto)
        {
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var employeNew = new Employee{
               
                FirstName = emplUpDto.FirstName,
                LastName = emplUpDto.LastName,
                Email = emplUpDto.Email,
                DateOfBrith = emplUpDto.DateOfBrith,
                PhotoPath = emplUpDto.PhotoPath,
                DepId = emplUpDto.DepId,
            };
            _context.Employees.Add(employeNew);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employeNew.EmpId }, employeNew);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmpId == id);
        }
    }
}
