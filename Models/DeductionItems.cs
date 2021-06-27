using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxAPI.Models
{
    public class DeductionItems
    {
        public long id { get; set; } 
        public long SalaryItemsId { get; set; }
        public double medicareLevy { get; set; }
        public double budgetRepairLevy { get; set; }
        public double incomeTax { get; set; }
    }
}
