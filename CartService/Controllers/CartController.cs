using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CartService.Models;
using CartService.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CartService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        public static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(CartController));
        // GET: DonarController
        private readonly IRepository _repository;

        public CartController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<CartController>
        [HttpGet]
        public ActionResult<IEnumerable<MenuItem>> Get()
        {
           

            return BadRequest();
        }
        [HttpGet("user")]
        public ActionResult RemoveAfterOrder(int userid)
        {
            var truth=_repository.RemoveAfterOrder(userid);
            if (truth==true)
            {
                return Ok();
            }

            return NoContent();
        }

        // GET api/<CartController>/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<MenuItem>> Get(int id)
        {
            try
            {

                _log4net.Info("Http get request initiated for all cart Items");


                var ItemsList = _repository.getCartItems(id);
                if (ItemsList != null)
                {
                    _log4net.Info("All the MenuItems were displayed");

                    return Ok(ItemsList);


                }
                else
                {
                    _log4net.Error("No user Found ");
                    return NotFound("No User Found");
                }

            }
            catch (Exception e)
            {
                _log4net.Error("Http get Request Failed Due to " + e.Message);

                return NotFound("No User Found");
            }
           
        }

        // POST api/<CartController>
        [HttpPost("{id}")]
        public ActionResult<MenuItem> Post(int id,[FromBody] MenuItem menuItem)
        {
            try
            {
                _log4net.Info("Http post Request Initiated for the user Id " + id);
                if (ModelState.IsValid)
                {
                    _log4net.Info("Obtained Valid Model");

                    var item = _repository.AddToCart(id, menuItem);



                    return Ok(item);





                }

            }
            catch (Exception e)
            {
                _log4net.Error("Http post Request Failed Due to " + e.Message);


                return NotFound();
            }
            return BadRequest();
           
        }

        // DELETE api/<CartController>/5
        [HttpDelete("{id}")]
        public ActionResult<MenuItem> Delete(int id,int menuitemid)
        {
            try
            {
                _log4net.Info("Http Delete Request Initiated for the user Id " + id);
                var IsDeleted = _repository.Delete(id, menuitemid);
                if (IsDeleted)
                {
                    return Ok("Removed From the cart succesfully");
                }

            }
            catch (Exception e)
            {
                _log4net.Error("Http Delete Request Failed Due to " + e.Message);


                return NotFound();
            }
            return BadRequest();
          
        }
    }
}
