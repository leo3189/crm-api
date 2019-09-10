using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Entities.Extensions;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrmApi.Controllers
{
    [Route("api/Items")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private ILoggerManager _logger;

        public ItemController(IRepositoryWrapper repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAllItems()
        {
            try
            {
                var items = _repository.Item.GetAllItems();

                _logger.LogInfo("Returned all items");

                return Ok(items);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error from GetAllItems: {ex.Message}");

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "ItemById")]
        public IActionResult GetItemById(Guid id)
        {
            var item = _repository.Item.GetItemById(id);

            try
            {
                if (item.Id.Equals(Guid.Empty))
                {
                    _logger.LogError($"Item id: {id}, not found");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned item id: {id}");
                    return Ok(item);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error from GetItemById: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
            
        }

        [HttpGet("{id}/inventory")]
        public IActionResult GetItemWithSerialNumbers(Guid id)
        {
            try
            {
                var item = _repository.Item.GetItemWithInventoryItem(id);

                if (item == null)
                {
                    _logger.LogError($"Item: {id}, not found");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned item with inventory: {item}");
                    return Ok(item);
                }
                
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetItemWithInventoryNumber action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateItem([FromBody]Item item)
        {
            try
            {
                if (item == null)
                {
                    _logger.LogError("Item object sent from client is null");
                    return BadRequest("Item object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid item object sent from client");
                    return BadRequest("Invalid model object");
                }

                _repository.Item.CreateItem(item);
                _repository.Save();

                return CreatedAtRoute("ItemById", new { id = item.Id }, item);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error from CreateItem: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateItem(Guid id, [FromBody]Item item)
        {
            try
            {
                if (item.IsObjectNull())
                {
                    return BadRequest("Item object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var dbItem = _repository.Item.GetItemById(id);
                if (dbItem.IsEmptyObject())
                {
                    return NotFound();
                }

                _repository.Item.UpdateItem(dbItem, item);
                _repository.Save();

                return NoContent();
            }
            catch
            {
                return StatusCode(500, "Invalid server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteItem(Guid id)
        {
            try
            {
                var item = _repository.Item.GetItemById(id);
                if (item.IsEmptyObject())
                {
                    return NotFound();
                }

                _repository.Item.DeleteItem(item);
                _repository.Save();

                return NoContent();
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
