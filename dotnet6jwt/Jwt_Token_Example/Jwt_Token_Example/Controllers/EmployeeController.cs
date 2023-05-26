using Jwt_Token_Example.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace Jwt_Token_Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        [Route("GetData")]

        public IActionResult GetData()
        {
            try
            {
                // JWT token doğrulaması ve diğer işlemler
                return Ok("Authenticated with JWT");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

                var problemDetails = new ProblemDetails
                {
                    Title = "Internal Server Error",
                    Status = 500,
                    Detail = "An internal server error occurred."
                };

                return Problem(problemDetails.Title, null, problemDetails.Status, problemDetails.Detail);
            }
        }


        [HttpGet]
        [Route("Details")]
        public string Details()
        {

            return "Authenticated with JWT";

        }

        [Authorize]
        [HttpPost]
        
        public string AddUser(Users user)
        {

            return "Authenticated with JWT username" +user.Username;

        }
    }
}
