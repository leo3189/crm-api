using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrmApi.Controllers
{
    [Route("api/inventory")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private ILoggerManager _logger;

        public InventoryController(IRepositoryWrapper repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult CreateInventory([FromBody] Inventory inventory)
        {
            try
            {
                if (inventory == null)
                {
                    return BadRequest("Inventory object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Inventory model is invalid");
                }

                _repository.Inventory.CreateInventory(inventory);
                _repository.Save();

                return CreatedAtRoute("", new { id = inventory.InventoryId }, inventory);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
