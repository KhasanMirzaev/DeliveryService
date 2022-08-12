using AutoMapper;
using DeliveryService.Data.IRepositories;
using DeliveryService.Domain.Entities.Customers;
using DeliveryService.Domain.Enums;
using DeliveryService.Service.DTOs.Customers;
using DeliveryService.Service.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Service.Services
{
    public class CustomerService : Interfaces.ICustomerService, IFileSevice
    {
        private readonly ICustomerRepository repository;
        private readonly IMapper mapper;
        private readonly IConfiguration config;
        private readonly IWebHostEnvironment env;

        public CustomerService(ICustomerRepository repository, IMapper mapper, IConfiguration config, IWebHostEnvironment env)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.config = config;
            this.env = env;
        }
        public async Task<Customer> CreateAsync(CustomerForCreationDto customerDto)
        {
            var existCustomer = await repository.GetAsync(p => p.PhoneNumber == customerDto.PhoneNumber);

            if (existCustomer is not null)
                return null;

            var mappedCustomer = mapper.Map<Customer>(customerDto);

            mappedCustomer.Image = await SaveFileAsync(customerDto.Image.OpenReadStream(), customerDto.Image.FileName);
            mappedCustomer.Create();
            
            var customer =  await repository.CreateAsync(mappedCustomer);

            customer.Image = config.GetSection("Storage:ImageUrl").Value + customer.Image;

            return customer;
        }

        public async Task<bool> DeleteAsync(Expression<Func<Customer, bool>> expression)
        {
            var exitCustomer = await repository.GetAsync(expression);

            if(exitCustomer is null)
                return false;

            exitCustomer.Delete();

            await repository.UpdateAsync(exitCustomer);

            return true;
        }

        public async Task<IQueryable<Customer>> GetAllAsync(Expression<Func<Customer, bool>> expression = null)
        {
            return await repository.GetAllAsync(expression => expression.State != ItemState.Deleted);
        }

        public async Task<Customer> GetAsync(Expression<Func<Customer, bool>> expression)
        {
            return await repository.GetAsync(expression => expression.State != ItemState.Deleted);
        }

        public async Task<string> SaveFileAsync(Stream file, string fileName)
        {
            fileName = Guid.NewGuid().ToString("N") + "_" + fileName;
            string storagePath = config.GetSection("Storage:ImageUrl").Value;
            string filePath = Path.Combine(env.WebRootPath, $"{storagePath}/{fileName}");
            FileStream mainFile = File.Create(filePath);
            await file.CopyToAsync(mainFile);
            mainFile.Close();

            return fileName; new NotImplementedException();
        }

        public async Task<Customer> UpdateAsync(Guid Id, CustomerForCreationDto customerDto)
        {
            var existCustomer = await repository.GetAsync(p => p.Id == Id && p.State != ItemState.Deleted);

            if (existCustomer is null)
                return null;

            existCustomer.FirstName = customerDto.FirstName;
            existCustomer.LastName = customerDto.LastName;
            existCustomer.PhoneNumber = customerDto.PhoneNumber;

            existCustomer.Image = await SaveFileAsync(customerDto.Image.OpenReadStream(), customerDto.Image.FileName);

            existCustomer.Update();

            var customer = await repository.UpdateAsync(existCustomer);

            customer.Image = config.GetSection("Storage:ImageUrl").Value + customer.Image;

            return customer;
        }
    }
}
