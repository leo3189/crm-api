using System;
using Contracts;
using Entities.Extensions;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrmApi.Controllers
{
    [Route("api/Customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private ILoggerManager _logger;
      
        public CustomerController(IRepositoryWrapper repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            try
            {
                var customers = _repository.Customer.GetAllCustomers();

                _logger.LogInfo($"Returned all customer");

                return Ok(customers);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error from GetAllCustomers: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
       
        [HttpGet("{id}", Name = "CustomerById")]
        public IActionResult GetCustomerById(Guid id)
        {
            try
            {
                var customer = _repository.Customer.GetCustomerById(id);

                if (customer.Id.Equals(Guid.Empty))
                {
                    _logger.LogError($"Customer id: {id}, not found");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned customer id {id}");
                    return Ok(customer);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error from GetCustomerById: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromBody]Customer customer)
        {
            try
            {
                if (customer == null)
                {
                    _logger.LogError("Customer object sent from client is null");
                    return BadRequest("Customer object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid customer object sent from client");
                    return BadRequest("Invalid model object");
                }

                _repository.Customer.CreateCustomer(customer);
                _repository.Save();

                return CreatedAtRoute("CustomerById", new { id = customer.Id }, customer);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error from CreateCustomer: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(Guid id, [FromBody]Customer customer)
        {
            try
            {
                if (customer.IsObjectNull ())
                {
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var dbCustomer = _repository.Customer.GetCustomerById(id);
                if (dbCustomer.IsEmptyObject())
                {
                    return NotFound();
                }

                _repository.Customer.UpdateCustomer(dbCustomer, customer);
                _repository.Save();

                return NoContent();
            }
            catch
            {
                return StatusCode(500, "Invalid server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(Guid id)
        {
            try
            {
                var customer = _repository.Customer.GetCustomerById(id);
                if (customer.IsEmptyObject())
                {
                    return NotFound();
                }

                _repository.Customer.DeleteCustomer(customer);
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
