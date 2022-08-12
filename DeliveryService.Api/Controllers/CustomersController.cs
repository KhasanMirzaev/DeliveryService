using DeliveryService.Domain.Entities.Customers;
using DeliveryService.Service.DTOs.Customers;
using DeliveryService.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DeliveryService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomersController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> Create([FromForm]CustomerForCreationDto creationDto)
        {
            var customer = await customerService.CreateAsync(creationDto);

            if (customer == null)
                return BadRequest();

            return Ok(customer);
        }

        [HttpGet]
        [Route("id")]
        public async Task<ActionResult<Customer>> Get(Guid Id)
        {
            var customer = await customerService.GetAsync(p => p.Id == Id);

            if (customer == null)
                return BadRequest();

            return Ok(customer);
        }

        [HttpGet]
        public async Task<ActionResult<Customer>> GetAll()
        {
            var customers = await customerService.GetAllAsync(null);

            if (customers == null)
                return BadRequest();

            return Ok(customers);
        }

        [HttpDelete]
        public async Task<ActionResult<Customer>> Delete(Guid Id)
        {
            var result = await customerService.DeleteAsync(p => p.Id == Id);

            if (result)
                return Ok();

            return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult<Customer>> Update(Guid Id, [FromForm]CustomerForCreationDto customerDto)
        {
            var cutomer = await customerService.UpdateAsync(Id, customerDto);

            if (cutomer == null)
                return BadRequest();

            return Ok(cutomer);
        }
    }
    
}
