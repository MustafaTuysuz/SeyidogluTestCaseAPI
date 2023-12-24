using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeyidogluTestCaseAPI.Data;
using SeyidogluTestCaseAPI.DTO;
using SeyidogluTestCaseAPI.Model;
using SeyidogluTestCaseAPI.Models;
using System.Net;

namespace SeyidogluTestCaseAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly TestCaseApiDbContext _dbContext;
        public CustomerController(TestCaseApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddCustomerRequestModel requestModel)
        {
            CustomerModel customerModel = new CustomerModel();
            customerModel.Name = requestModel.Name;
            customerModel.MiddleName = requestModel.MiddleName;
            customerModel.Surname = requestModel.Surname;
            customerModel.IdentificationNumber = requestModel.IdentificationNumber;
            customerModel.GsmNumber = requestModel.GsmNumber;
            customerModel.CreateDate = DateTime.Now;
            customerModel.CreateUser = "system-user";
            customerModel.IsDeleted = false;

            await _dbContext.Customer.AddAsync(customerModel);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        {
            return Ok(await _dbContext.Customer.ToListAsync());
        }

        [HttpGet("{isActive}")]
        public async Task<IActionResult> GetListByDeletedStatuAsync([FromRoute] bool isActive)
        {
            var customers = _dbContext.Customer.Where(x => x.IsDeleted == isActive).ToList();

            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var customer = await _dbContext.Customer.FirstOrDefaultAsync(x => x.Id == id);

            return Ok(customer);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateCustomerRequestModel requestModel)
        {
            CustomerModel? customer = await _dbContext.Customer.FirstOrDefaultAsync(x => x.Id == requestModel.Id);

            if (customer != null)
            {
                customer.Surname = requestModel.Surname ?? customer.Surname;
                customer.Name = requestModel.Name ?? customer.Name;
                customer.GsmNumber = requestModel.GsmNumber ?? customer.GsmNumber;
                customer.IdentificationNumber = requestModel.IdentificationNumber ?? customer.IdentificationNumber;
                customer.MiddleName = requestModel.MiddleName;
                customer.ModifyDate = DateTime.Now;
                customer.ModifyUser = "modify-user";

                await _dbContext.SaveChangesAsync();

                return Ok();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteByIdAsync([FromRoute] int id)
        {
            var customer = await _dbContext.Customer.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);

            if (customer != null)
            {
                customer.IsDeleted = true;
                customer.ModifyDate = DateTime.Now;
                customer.ModifyUser = "delete-user";

                _dbContext.SaveChanges();
                return Ok();
            }

            return NotFound();
        }


        //güncelleme
        //silme
    }
}
