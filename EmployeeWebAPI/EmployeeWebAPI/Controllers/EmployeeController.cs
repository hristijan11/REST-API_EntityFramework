using EmployeeWebAPI.EmpContext;
using EmployeeWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeDbContext _EmployeeDbContext;


        public EmployeeController(EmployeeDbContext EmployeeDbContext)
        {
            _EmployeeDbContext = EmployeeDbContext;
        }




        // GET: api/<EmployeeController>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _EmployeeDbContext.Employees;
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}", Name = "Get")]
        public Employee Get(int id)
        {
            return _EmployeeDbContext.Employees.SingleOrDefault(x => x.EmployeeId == id);
        }
        // POST api/<EmployeeController>
        [HttpPost]
        public void Post([FromBody] Employee employee)
        {
            _EmployeeDbContext.Employees.Add(employee);
            _EmployeeDbContext.SaveChanges();
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id,[FromBody] Employee employee)
        {
            employee.EmployeeId = id;
            _EmployeeDbContext.Employees.Update(employee);
            _EmployeeDbContext.SaveChanges();
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _EmployeeDbContext.Employees.FirstOrDefault(x => x.EmployeeId == id);
            if(item != null)
            {
                _EmployeeDbContext.Employees.Remove(item);
                _EmployeeDbContext.SaveChanges();
            }
        }
    }
}
