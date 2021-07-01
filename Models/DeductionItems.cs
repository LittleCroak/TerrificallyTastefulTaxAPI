namespace TaxAPI.Models
{
    using System.Collections;

    public class DeductionItems
    {
        public long id { get; set; } 
        public long SalaryItemsId { get; set; }
        public double medicareLevy { get; set; }
        public double budgetRepairLevy { get; set; }
        public double incomeTax { get; set; }

    }
}
