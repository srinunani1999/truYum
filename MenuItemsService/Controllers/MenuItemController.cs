using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MenuItemsService.Models;
using MenuItemsService.Repositories;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MenuItemsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(MenuItemController));
        private readonly IRepository<MenuItem> _repository;
        public MenuItemController(IRepository<MenuItem> repository)
        {

            _repository = repository;
        }
        // GET: api/<MenuItemController>
        [HttpGet]
        public ActionResult<IEnumerable< MenuItem>> Get()
        {
            try
            {
                _log4net.Info("Http Get request Initiated");

                var menuitems = _repository.Get();
                if (menuitems != null)
                {
                    _log4net.Info("successfully got details");
                    return Ok(menuitems);


                }

            }
            catch (Exception e)
            {
                _log4net.Error("No result " + e.Message);
                return new NoContentResult();


            }
            return BadRequest();
           
           
        }

        // GET api/<MenuItemController>/5
        [HttpGet("{id}")]
        public  ActionResult<MenuItem> Get(int id)
        {
            try
            {
                _log4net.Info("Http get request initiated with " + id);
                var menuItem = _repository.GetById(id);

                if (menuItem == null)
                {
                    _log4net.Info("Menu item with that Requested Id not Found");

                    return NotFound(id);
                }
                _log4net.Info("Found Matching menu item");


                return Ok(menuItem);
            }
            catch (Exception e)
            {

                _log4net.Error("No content Obtained " + e.Message);
                return NotFound();
            }
       
        }

        // POST api/<MenuItemController>
        [HttpPost]
        public ActionResult<MenuItem> Post([FromBody] MenuItem menuItem)
        {
            try
            {
                _log4net.Info("HttpPost Request Initiated for Id " + menuItem.Id);

                if (ModelState.IsValid)
                {
                    _log4net.Info("Model state is  valid for Id " + menuItem.Id);


                    _repository.Add(menuItem);


                    return CreatedAtAction("Get", new { id = menuItem.Id }, menuItem);

                }


            }
            catch (Exception e)
            {

                _log4net.Error("Model state is not valid for id " + menuItem.Id + e.Message);
                return NotFound();
            }
            return BadRequest();
        }

        // PUT api/<MenuItemController>/5
        [HttpPut("{id}")]
        public ActionResult<MenuItem> Put(int id, [FromBody] MenuItem menuItem)
        {
            try
            {
                _log4net.Info("HttpPost Request Initiated for Id " + menuItem.Id);

                if (ModelState.IsValid)
                {
                    _log4net.Info("Model state is  valid for Id " + menuItem.Id);


                    var updateMenuitem = _repository.Update(menuItem);

                    if (updateMenuitem != null)
                    {
                        return Ok(updateMenuitem);
                    }


                    return BadRequest();

                }


            }
            catch (Exception e)
            {

                _log4net.Error("Model state is not valid for id " + menuItem.Id + e.Message);
                return NotFound();
            }
            return BadRequest();
        }

        // DELETE api/<MenuItemController>/5
        [HttpDelete("{id}")]
        public ActionResult<MenuItem> Delete(int id)
        {
            try
            {
                _log4net.Info("HttpPost Request Initiated for Id " + id);

                if (ModelState.IsValid)
                {
                    _log4net.Info("Model state is  valid for Id " + id);


                    var DeleteMenuitem = _repository.Delete(id);

                    if (DeleteMenuitem == true)
                    {
                        return Ok("Deleted Succesfully");
                    }


                    return BadRequest();

                }


            }
            catch (Exception e)
            {

                _log4net.Error("Model state is not valid for id " + id + e.Message);
                return NotFound();
            }
            return BadRequest();
        }
    }
}
