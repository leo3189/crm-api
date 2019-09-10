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
    [Route("api/serialNumbers")]
    [ApiController]
    public class SerialNumberController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private ILoggerManager _logger;

        public SerialNumberController(IRepositoryWrapper repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAllSerialNumbers()
        {
            try
            {
                var serialNumbers = _repository.SerialNumber.GetAllSerialNumbers();

                _logger.LogInfo("Returned all serial numbers");

                return Ok(serialNumbers);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error from GetAllSerialNumbers action: {ex.Message}");

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "SerialNumberById")]
        public IActionResult GetSerialNumberById(Guid id)
        {
            _logger.LogInfo($"Serial number id: {id}");

            var serialNumber = _repository.SerialNumber.GetSerialNumberById(id);

            try
            {
                if (serialNumber.Id.Equals(Guid.Empty))
                {
                    _logger.LogError($"Serial number id: {id}, not found");

                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned serial number id: {id}");

                    return Ok(serialNumber);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error from GetSerialNumberById: {ex.Message}");

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateSerialNumber([FromBody]SerialNumber serialNumber)
        {
            try
            {
                if (serialNumber == null)
                {
                    _logger.LogError("Serial number object sent from client is null");

                    return BadRequest("Serial number object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid object sent from client");

                    return BadRequest("Invalid model object");
                }

                _repository.SerialNumber.CreateSerialNumber(serialNumber);
                _repository.Save();

                return CreatedAtRoute("SerialNumberById", new { id = serialNumber.Id }, serialNumber);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error from CreateSerialNumber: {ex.Message}");

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSerialNumber(Guid Id, [FromBody]SerialNumber serialNumber)
        {
            try
            {
                if (serialNumber == null)
                {
                    return BadRequest("Serial number object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var dbSerialNumber = _repository.SerialNumber.GetSerialNumberById(Id);

                if (serialNumber == null)
                {
                    return NotFound();
                }

                _repository.SerialNumber.UpdateSerialNumber(dbSerialNumber, serialNumber);
                _repository.Save();

                return NoContent();
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSerialNumber(Guid id)
        {
            try
            {
                var serialNumber = _repository.SerialNumber.GetSerialNumberById(id);
                if (serialNumber == null)
                {
                    return NotFound();
                }

                _repository.SerialNumber.DeleteSerialNumber(serialNumber);
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
