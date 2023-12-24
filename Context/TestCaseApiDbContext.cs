using Microsoft.EntityFrameworkCore;
using SeyidogluTestCaseAPI.Models;

namespace SeyidogluTestCaseAPI.Data
{
    public class TestCaseApiDbContext : DbContext
    {
        public TestCaseApiDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<CustomerModel> Customer { get; set; } 
    }
}
