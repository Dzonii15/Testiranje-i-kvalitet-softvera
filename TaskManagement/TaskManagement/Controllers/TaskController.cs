using Microsoft.AspNetCore.Mvc;

namespace TaskManagement.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {


        [HttpGet]
        public async Task<IActionResult> Test()
        {

            return Ok("Test");
        }


    }
}
