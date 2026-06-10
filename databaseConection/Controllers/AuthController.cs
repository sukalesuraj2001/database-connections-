using databaseConection.Data;
using databaseConection.Models.Entity;
using databaseConection.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace databaseConection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthservice _authService;


        //Di container
        public AuthController( IAuthservice authService)
        {
            _authService = authService;
        }


        [HttpGet]
        [Route("getAllUsers")]
        public async Task<IActionResult> getAllEmployee()
        {
            var resp = await _authService.getAllUsers();
            return Ok(new
            {
                message="All users fetch successfully !!",  
                response = resp
            });
        }

        [HttpPost]
        [Route("RegisterUser")]

        public async Task<IActionResult> registerEmp(User users)
        {

            var resp = await _authService.AddUser(users);

            return Ok(new
            {
                message = "User register sucessfully !!"
            });
        }

        [HttpGet ("getUserById/{id}")]

        public async Task<IActionResult> getUserById(Guid id)
        {
            var res = await _authService.FineUserById(id);

            if (res == null) NotFound();

            return Ok(res);
        }


        [HttpPut("updateUser/{id}") ]


        public async Task<IActionResult> updateUser(Guid id, User users)
        {
            var res = await _authService.UpdateUser(id, users);
            return Ok(new
            {
                message = "user updated sucessfully!"
            });
        }




        [HttpDelete ("deleteUser/{id}")]

        public async Task<IActionResult> deleteUser(Guid id)
        {
            var res = await _authService.deleteUser(id);

            return Ok(new
            {
                message= "user deleted sucessfully !"
            });
        }

    }
}
