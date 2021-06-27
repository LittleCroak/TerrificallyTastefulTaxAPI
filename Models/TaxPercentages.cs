using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxAPI.Models
{
    public abstract class TaxPercentages
    {
        // Percentage of income used to calculate various tax deduction items (medicare levy etc)
        public double percentageOfIncome { get; set; }
        public double? excessValue { get; set; }
    }
}
