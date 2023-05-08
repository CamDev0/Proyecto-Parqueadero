using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parking.API.Data;
using Parking.API.Helpers;
using Parking.Shared.DTOs;
using Parking.Shared.Entities;

namespace Parking.API.Controllers
{

    [ApiController]
    [Route("/api/users")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;


        public UsersController(DataContext context)
        {
            _context = context;
        }

        //CRUD


        //CONSULTAR - Devuelve la lista de paises de forma asíncrona

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Users
                .AsQueryable();

            return Ok(await queryable
                .OrderBy(x => x.Name)
                .Paginate(pagination)
                .ToListAsync());
        }

        [HttpGet("totalPages")]
        public async Task<ActionResult> GetPages([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Users.AsQueryable();
            double count = await queryable.CountAsync();
            double totalPages = Math.Ceiling(count / pagination.RecordsNumber);
            return Ok(totalPages);
        }


        //CONSULTAR - con parametro o filtro id (consulta especíica)

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user is null)
            {
                return NotFound();
            }

            return Ok(user);
        }


        //CREAR - Permite agregar un país de forma asíncrona

        [HttpPost]
        public async Task<ActionResult> Post(User user)
        {
            _context.Add(user);
            try
            {

                await _context.SaveChangesAsync();
                return Ok(user);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe el usuario.");
                }
                else
                {
                    return BadRequest(dbUpdateException.InnerException.Message);
                }
            }

            catch (Exception exception)
            {
               return BadRequest(exception.Message);
            }

        }


        //UPDATE

        [HttpPut]
        public async Task<ActionResult> Put(User user)
        {
            _context.Update(user);
            try
            {
                await _context.SaveChangesAsync();
                return Ok(user);

            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe el registro.");
                }
                else
                {
                    return BadRequest(dbUpdateException.InnerException.Message);
                }
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        //DELETE

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectedRows = await _context.Users
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            if (afectedRows == 0)
            {
                return NotFound();
            }

            return NoContent();

        }
    }
}