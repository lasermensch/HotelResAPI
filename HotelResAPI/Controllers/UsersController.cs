﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelResAPI.Data;
using HotelResAPI.Models;
using HotelResAPI.Services;
using Microsoft.AspNetCore.Authorization;

namespace HotelResAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [UserAuth]
    public class UsersController : ControllerBase
    {
        private readonly HotelResDbContext _context;

        public UsersController(HotelResDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(Guid id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
        [HttpGet("userfromtoken")]
        public async Task<ActionResult<User>> GetUserFromToken()
        {
            Guid id = Guid.Parse(HttpContext.Items["extractId"].ToString());

            User u = await _context.Users.FindAsync(id);

            if (u == null)
                return NotFound();

            return u;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(Guid id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {

            if (user == null)
                return BadRequest();

            if (_context.Users.Any(u => u.Email == user.Email))
                return BadRequest();

            user.UserId = Guid.NewGuid();
            user.Salt = SecurityService.getSalt();

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete]
        public async Task<IActionResult> DeleteUser()
        {
            Guid id = Guid.Parse(HttpContext.Items["ExtractId"].ToString());
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(Guid id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}
