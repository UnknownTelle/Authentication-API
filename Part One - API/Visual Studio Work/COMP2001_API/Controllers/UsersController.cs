using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using COMP2001_API.Models;
using System.Data.SqlClient;

namespace COMP2001_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly COMP2001_CAbbottContext _context;

        public UsersController(COMP2001_CAbbottContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get(User user)
        {
            bool Check = _context.Validate(user);

            if (Check == true)
            {
                return StatusCode(200);
            } 
            else
            {
                return StatusCode(406);
            }
        }

        [HttpPut]
        public ActionResult<IActionResult> Put(int id, User user)
        {
            if (user.UserId == id)
            {
                _context.Update(user);
                _context.SaveChanges();
                return StatusCode(200);
            }
            else
            {
                return StatusCode(406);
            }
        }

        [HttpPost]

        public ActionResult<IActionResult> Post(User user)
        {
            string register = "";
            _context.Register(user, out register);
            int register_int = Int32.Parse(register);

            if (register_int >= 1)
            {
                return StatusCode(200);
            }
            else
            {
                return StatusCode(406);
            }
        }
        [HttpDelete]
        public ActionResult<User> DeleteUser(int id)
        {
            _context.Delete(id);
            _context.SaveChanges();
            return StatusCode(200);
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }


        // Class diagram shows these are supposed to be here
        private bool GetValidation(User user)
        {
            return (_context.Validate(user));
        }
        private void Register(User user, out string register)
        {
            _context.Register(user, out register);
        }
    }

}
