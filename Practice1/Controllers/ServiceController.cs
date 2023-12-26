using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice1.Models;

namespace Practice1.Controllers
{
    [Route("api/[controller]")]
    public class ServiceController : Controller
    {
        private DataContext db;
        public ServiceController(DataContext ctx)
        {
            db = ctx;
        }
        [HttpGet]
        public IEnumerable<Service> GetService()
        {
            return db.Services.ToList();
        }
        [HttpGet("{id}")]
        public Service GetService(int id)
        {
            return db.Services.Where(p => p.IdService == id).FirstOrDefault()!;
        }
        [HttpPost]
        public void SaveService([FromBody] Service service)
        {
            db.Services.Add(service);
           db.SaveChanges();
        }
        [HttpPut]
        public void UpdateService([FromBody] Service service)
        {
            db.Services.Update(service);
            db.SaveChanges();
        }
        [HttpDelete("{id}")]
        public void DeleteService(long id)
        {
            db.Services.Remove(db.Services.Where(p => p.IdService == id).FirstOrDefault()!);
            db.SaveChanges();
        }
    }
}
