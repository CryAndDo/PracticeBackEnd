using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice1.Models;

namespace Practice1.Controllers
{
    [Route("api/[controller]")]
    public class Prices_and_accommodationsEmployeesController : ControllerBase
    {
        private DataContext db;
        public Prices_and_accommodationsEmployeesController(DataContext ctx)
        {
            db = ctx;
        }
        [HttpGet]
        public IEnumerable<PricesAndAccommodationsEmployee> GetPricesAndAccommodationsEmployee()
        {
            return db.PricesAndAccommodationsEmployees.ToList();
        }
        [HttpGet("{id}")]
        public PricesAndAccommodationsEmployee GetPricesAndAccommodationsEmployee(int id)
        {
            return db.PricesAndAccommodationsEmployees.Where(p => p.IdPriceAccomodations == id).FirstOrDefault()!;
        }
        [HttpPost]
        public void SavePricesAndAccommodationsEmployee([FromBody] PricesAndAccommodationsEmployee pricesAndAccommodationsEmployee)
        {
            db.PricesAndAccommodationsEmployees.Add(pricesAndAccommodationsEmployee);
            db.SaveChanges();
        }
        [HttpPut]
        public void UpdatePricesAndAccommodationsEmployee([FromBody] PricesAndAccommodationsEmployee pricesAndAccommodationsEmployee)
        {
            db.PricesAndAccommodationsEmployees.Update(pricesAndAccommodationsEmployee);
            db.SaveChanges();
        }
        [HttpDelete("{id}")]
        public void DeletePricesAndAccommodationsEmployee(long id)
        {
            db.PricesAndAccommodationsEmployees.Remove(db.PricesAndAccommodationsEmployees.Where(p => p.IdPriceAccomodations == id).FirstOrDefault()!);
            db.SaveChanges();
        }
    }

}
