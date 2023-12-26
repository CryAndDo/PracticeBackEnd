using Microsoft.AspNetCore.Mvc;
using Practice1.Models;
using System.Diagnostics;

namespace Practice1.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private DataContext db;
        public EmployeeController(DataContext ctx)
        {
            db = ctx;
        }
        [HttpGet]
        public IEnumerable<Employee> GetEmployee()
        {
            return db.Employees.ToList();
        }
        [HttpGet("{id}")]
        public Employee GetEmployees(int id)
        {
            return db.Employees.Where(p => p.IdEmpleyee == id).FirstOrDefault()!;
        }
        [HttpPost]
        public void SaveEmployee([FromBody] Employee employee)
        {
            if (employee != null)
                db.Employees.Add(employee);
            db.SaveChanges();
        }
        [HttpPut]
        public void UpdateEmployee([FromBody] Employee employee)
        {
            db.Employees.Update(employee);
            db.SaveChanges();
        }
        [HttpDelete("{id}")]
        public void DeleteEmployee(long id)
        {
            db.Employees.Remove(db.Employees.Where(p => p.IdEmpleyee == id).FirstOrDefault()!);
            db.SaveChanges();
        }
    }
}
