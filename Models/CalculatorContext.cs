using Microsoft.EntityFrameworkCore;


namespace TaxAPI.Models
{
    public class CalculatorContext : DbContext
    {
        public CalculatorContext(DbContextOptions<CalculatorContext> options) : base(options)
        {

        }
        public DbSet<SalaryItems> SalaryItems { get; set; }
    }
}
