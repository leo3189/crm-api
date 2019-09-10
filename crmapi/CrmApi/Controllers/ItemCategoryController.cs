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
    [Route("api/itemCategories")]
    public class ItemCategoryController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;

        public ItemCategoryController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllItemCategories()
        {
            try
            {
                var itemCat = _repository.ItemCategory.GetAllItemCategories();

                _logger.LogInfo("Returned all item categories from database.");

                return Ok(itemCat);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllItemCategories action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "ItemCategoryById")]
        public IActionResult GetItemCategoryById(Guid id)
        {
            try
            {
                var itemCat = _repository.ItemCategory.GetItemCategoryById(id);

                if (itemCat == null)
                {
                    _logger.LogError($"Item category with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned item category with id: {id}");
                    return Ok(itemCat);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetItemCategoryById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/item")]
        public IActionResult GetItemCategoryWithItems(Guid id)
        {
            try
            {
                var itemCat = _repository.ItemCategory.GetCategoryWithItems(id);

                if (itemCat.Id.Equals(Guid.Empty))
                {
                    _logger.LogError($"Item category with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned item category with items for id: {id}");
                    return Ok(itemCat);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetItemCategoryWithItems action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateItemCategory([FromBody]ItemCategory itemCategory)
        {
            try
            {
                if (itemCategory == null)
                {
                    _logger.LogError("Item category sent from client is null.");
                    return BadRequest("Item category is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid item category object sent from client.");
                    return BadRequest("Invalid model object");
                }

                _repository.ItemCategory.CreateItemCategory(itemCategory);
                _repository.Save();

                return CreatedAtRoute("ItemCategoryById", new { id = itemCategory.CategoryId }, itemCategory);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateItemCategory action: {ex.Message}");
                return StatusCode(500, "Invalid server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateItemCategory(Guid id, [FromBody]ItemCategory itemCat)
        {
            try
            {
                if (itemCat == null)
                {
                    _logger.LogError("Item category sent from client is null.");
                    return BadRequest("Item category is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid item category object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var dbItemCategory = _repository.ItemCategory.GetItemCategoryById(id);
                if (dbItemCategory == null)
                {
                    _logger.LogError($"Item category with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.ItemCategory.UpdateItemCategory(dbItemCategory, itemCat);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateItemCategory action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteItemCategory(Guid id)
        {
            try
            {
                var itemCat = _repository.ItemCategory.GetItemCategoryById(id);
                if (itemCat == null)
                {
                    _logger.LogError($"Item category with idL {id}, hasn't been found in db");
                    return NotFound();
                }

                if (_repository.Item.ItemsByItemCategory(id).Any())
                {
                    _logger.LogError($"Cannot delete item category with id: {id}. It has related items. Delete those items first");
                    return BadRequest("Cannot delete item category. It has related items. Delete those items first");
                }

                _repository.ItemCategory.DeleteItemCategory(itemCat);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteItemCategory action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
