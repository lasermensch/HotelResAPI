using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelResAPI.Data;
using HotelResAPI.Models;
using Microsoft.AspNetCore.Authorization;
using HotelResAPI.Services;

namespace HotelResAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [UserAuth]
    public class ReservationsController : ControllerBase
    {
        private readonly HotelResDbContext _context;

        public ReservationsController(HotelResDbContext context)
        {
            _context = context;
        }

        // GET: api/Reservations/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservations()
        {
            string userId = HttpContext.Items["extractId"].ToString();

            List<Reservation> usersReservations = await _context.Reservations.Where(r => r.UserId.ToString() == userId).ToListAsync();

            return usersReservations;
        }

        // GET: api/Reservations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> GetReservation(Guid id)
        {
            var reservation = await _context.Reservations.FindAsync(id);

            
            if (reservation == null)
                return NotFound();
            
            if (reservation.UserId != Guid.Parse(HttpContext.Items["extractId"].ToString()))
                return Forbid();

            return reservation;
        }

        // PUT: api/Reservations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservation(Guid id, Reservation reservation)
        {
            if (reservation.UserId != Guid.Parse(HttpContext.Items["extractId"].ToString()))
                return Forbid();
            if (id != reservation.ReservationId)
            {
                return BadRequest();
            }

            _context.Entry(reservation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationExists(id))
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

        // POST: api/Reservations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reservation>> PostReservation(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReservation", new { id = reservation.ReservationId }, reservation);
        }

        // DELETE: api/Reservations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(Guid id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }

            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReservationExists(Guid id)
        {
            return _context.Reservations.Any(e => e.ReservationId == id);
        }
    }
}
