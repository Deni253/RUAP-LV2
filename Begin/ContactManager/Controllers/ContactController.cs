using ContactManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace Begin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        // GET: api/contact
        [HttpGet]
        public Contact[] Get()
        {
            return new Contact[]
         {
            new Contact
            {
                Id = 1,
                Name = "Glenn Block"
            },
            new Contact
            {
                Id = 2,
                Name = "Dan Roth"
            }
         };
        }
    }
}