using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice1.Models;

namespace Practice1.Controllers
{
    [Route("api/[controller]")]
    public class FondController : ControllerBase
    {
        private DataContext db;
        public FondController(DataContext ctx)
        {
            db = ctx;
        }
        [HttpGet]
        public IEnumerable<Fond> GetFond()
        {
            return db.Fonds.ToList();
        }
        [HttpGet("{id}")]
        public Fond GetFonds(int id)
        {
            return db.Fonds.Where(p => p.TableId == id).FirstOrDefault()!;
        }
        [HttpPost]
        public void SaveFonds([FromBody] Fond fond)
        {
            db.Fonds.Add(fond);
            db.SaveChanges();
        }
        [HttpPut]
        public void UpdateFonds([FromBody] Fond fond)
        {
            db.Fonds.Update(fond);
            db.SaveChanges();
        }
        [HttpDelete("{id}")]
        public void DeleteFonds(long id)
        {
            db.Fonds.Remove(db.Fonds.Where(p => p.TableId == id).FirstOrDefault()!);
            db.SaveChanges();
        }
    }
}
