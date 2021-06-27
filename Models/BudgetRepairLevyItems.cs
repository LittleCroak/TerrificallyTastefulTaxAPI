﻿

namespace TaxAPI.Models
{
    public class BudgetRepairLevyItems
    {
        /// <param name="percentageOfIncome"> Used to calculate the value based on percentage of income or excess </param>
        public double percentageOfIncome { get; set; }

        /// <param name="excessValue"> Nullable value: if calculating percentage of excess, how much is the excess </param>
        public double? excessValue { get; set; }

        public  medicareBrackets { get; set; }

        public MedicareLevyItems()
        {
            medicareBrackets = new MedicareBrackets();
        }
    }
}