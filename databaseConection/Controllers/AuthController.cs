using databaseConection.Data;
using databaseConection.Models.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace databaseConection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly AppDbContext _context;


        //Di container
        public AuthController( AppDbContext context)
        {
            _context = context; 
        }


        [HttpGet]
        [Route("getAllUsers")]
        public async Task<IActionResult> getAllEmployee()
        {
            var resp = await _context.Users.ToListAsync();
            return Ok(new
            {
                response = resp
            });
        }

        [HttpPost]
        [Route("RegisterUser")]

        public async Task<IActionResult> registerEmp(User users)
        {

            var res = new User
            {
                Name = users.Name
            };
            await _context.Users.AddAsync(res);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "User register sucessfully !!"
            });
        }

        [HttpGet ("getUserById/{id}")]

        public async Task<IActionResult> getUserById(Guid id)
        {
            var res = await _context.Users.FindAsync(id);

            if (res == null) NotFound();

            return Ok(res);
        }


        [HttpPut("updateUser/{id}") ]


        public async Task<IActionResult> updateUser(Guid id, User users)
        {
            var res = await _context.Users.FindAsync(id);

            if (res == null) NotFound();

            res.Name = users.Name;

            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "user updated sucessfully!"
            });
        }




        [HttpDelete ("deleteUser/{id}")]

        public async Task<IActionResult> deleteUser(Guid id)
        {
            var res = await _context.Users.FindAsync(id);

             _context.Users.Remove(res);

            await _context.SaveChangesAsync();

            return Ok(new
            {
                message= "user deleted sucessfully !"
            });
        }

    }
}
