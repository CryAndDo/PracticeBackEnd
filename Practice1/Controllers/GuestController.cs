using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Practice1.Models;
using System.Diagnostics;

namespace Practice1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuestController : ControllerBase
    {
        private DataContext db;
        public GuestController(DataContext ctx)
        {
            db = ctx;
        }
        [HttpGet]
        public IEnumerable<Guest> GetGuest()
        {
            return db.Guests.ToList();
        }
        [HttpGet("{id}")]
        public Guest GetGuest(int id)
        {
            return db.Guests.Where(p => p.IdGuest == id).FirstOrDefault()!;
        }
        [HttpPost]
        public void SaveGuest([FromBody] Guest guest)
        {
            if (guest != null)
            {
              
                db.Guests.Add(guest);
               

                db.SaveChanges();
            }
           
        }
        [HttpPut]
        public async Task<ActionResult<Guest>> Put(Guest user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            if (!db.Guests.Any(x => x.IdGuest == user.IdGuest))
            {
                return NotFound();
            }
            db.Update(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }


        [HttpDelete("{id}")]
        public void DeleteGuest(long id)
        {
            db.Guests.Remove(db.Guests.Where(p => p.IdGuest == id).FirstOrDefault()!);
            db.SaveChanges();
        }
    }
}
