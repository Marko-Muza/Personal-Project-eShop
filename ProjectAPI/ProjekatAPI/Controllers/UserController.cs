using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DTOs;
using DataAccessLayer;
using BussinesLogicLayer;

namespace ProjekatAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _userManager;
        private readonly IUser _user;
        private readonly IValidation _validation;

        public UserController(IUserManager userManager, IUser user, IValidation validation)
        {
            _user = user;
            _userManager = userManager;
            _validation = validation;
        }
        // GET: api/user
        [HttpGet]
        public IActionResult GetLogin(string username, string password)
        {
            bool isValid = _validation.ValidateLoginInput(username, password);
            if (isValid)
            {
                int idUser;
                idUser = _userManager.LoginUser(username, password);
                if (idUser == 0)
                {
                    return BadRequest("Login info is wrong!");
                }
                return Ok(idUser);
            }
            else
            {
                return BadRequest("Invalid input!");
            }
        }

        // GET: api/user/5
        [HttpGet("{userId}")]
        public IActionResult Get(int userId)
        {
            DTOs.User user = _userManager.GetUser(userId);
            return Ok(user);
        }

        // POST: api/user
        [HttpPost]
        public ActionResult PostRegister([FromBody] DTOs.User user)
        {
            //validate authentication and authorization
            //validate request
            //validate action conditions
            //action


            // Validate request info and check if user exists
            if (user == null)
            {
                return BadRequest("No user info was provided!");
            }
            else
            {
                if (!(_validation.CheckUserExists(user)))
                {
                    return BadRequest("User info is invalid!");
                }
            }

            // Registrating a user and adding a cart
            int result;
            try
            {
                var currentDate = DateTime.Now;
                result = _userManager.RegisterUser(user, currentDate);
                return Ok(result);

            }
            catch (ArgumentNullException noUser)
            {
                return BadRequest(noUser.Message);
            }

        }


        // GET: api/user/5/cart
        [HttpGet("{id}/cart")]
        public ActionResult<Product> GetCart(int id)
        {
            if (id != 0)
            {
                return Ok("Get cart for user with id " + id);

                // Proceed to BLL
            }
            return Unauthorized("Access denied!");
        }

        // POST: api/user/5/cart
        [HttpPost("{id}/cart")]
        public ActionResult PostCart(int id, [FromBody] CartProduct item)
        {
            if (item !=null)
            {
                var date = DateTime.Now;
                _userManager.AddToCart(id, item, date);
                return Ok(item);
                // Proceed to BLL
            }
            else { return Unauthorized("Access denied!"); }
            
        }


        // PUT: api/user/5/cart/5
        [HttpPut("{id}/cart/{idCartItem}")]
        public ActionResult PutCart(int id, int idCartItem, [FromBody] Product item)
        {
            if (id != 0 )
            {
                return Ok("Put cart for user with id " + id);
                // Proceed to BLL
            }
            else { return Unauthorized("Access denied!"); }
        }

        // DELETE: api/5/cart
        [HttpDelete("{id}/cart")]
        public ActionResult DeleteCart(int id)
        {
            if (id != 0)
            {
                return Ok("Delete cart for user with id " + id);
                // Proceed to BLL
            }
            else { return Unauthorized("Access denied!");}
        }


        //GET: api/5/history
        [HttpGet("{id}/history")]
        public ActionResult<Order> GetPurhcaseHistory(int id)
        {
            if (id !=0)
            {
                return Ok("Get history for user with id " + id);
                // Proceed to BLL
            }
            else { return Unauthorized("Access denied!"); }
        }

        // GET: api/user/5/cart/5
        [HttpGet("{id}/cart/{idCartItem}")]
        public ActionResult<OrderItem> GetCart(int id, int idCartItem)
        {
            if (id != 0 && idCartItem != 0)
            {
                return Ok("Get cart item with id " + idCartItem + "for user with cart id " + id);

                // Proceed to BLL
            }
            else { return Unauthorized("Access denied!"); }
        }
    }
}