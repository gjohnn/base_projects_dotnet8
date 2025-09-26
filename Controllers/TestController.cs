using base_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace base_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TestController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/test/db
        [HttpGet("db")]
        public async Task<IActionResult> TestDb()
        {
            try
            {
                // Intentamos contar usuarios como prueba de conexión
                var count = await _context.Users.CountAsync();
                return Ok(new { message = "Conexión OK", usersCount = count });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al conectar a la DB", error = ex.Message });
            }
        }
    }
}
