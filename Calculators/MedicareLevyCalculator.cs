using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxAPI.Models;

namespace TaxAPI.Calculators
{
    public class MedicareLevyCalculator : TaxPercentages
    {
        public SalaryItems calculateMedicareLevy(SalaryItems salary)
        {
            return getMedicareLevy(salary);
        }

        private SalaryItems getMedicareLevy(SalaryItems salary)
        {
            MedicareLevyItems medicareLevyItems = new MedicareLevyItems();

            medicareLevyItems = defineMedicareBracket(medicareLevyItems, salary.taxableIncome);

            // Calculate based on the defined Medicare bracket values
            salary.deductionItems.medicareLevy = calculateMedicareLevy(medicareLevyItems, salary.taxableIncome);

            return salary;
        }

        private double calculateMedicareLevy(MedicareLevyItems medicareLevyItems, double taxableIncome)
        {
            // Calculate based on the defined Medicare bracket values
            var medicareLevy = 0.00;
            if (medicareLevyItems.excessValue == null)
            {
                // calculate the Taxable income * medicare levy bracket percentage / 100
                medicareLevy = taxableIncome * (medicareLevyItems.percentageOfIncome / 100);
            }
            else
            {
                // in the case of being in the second bracket, it is percentage of excess over x:
                // Taxable Income - Excess value defined by ATO * percentage of income
                medicareLevy = ((double)(taxableIncome - medicareLevyItems.excessValue) * (medicareLevyItems.percentageOfIncome / 100));
            }
            return Math.Ceiling(medicareLevy);
        }

        private MedicareLevyItems defineMedicareBracket(MedicareLevyItems medicareLevyItems, double taxableIncome)
        {
            MedicareBrackets medicareBrackets = new MedicareBrackets();

            switch (taxableIncome)
            {
                case double n when n <= medicareBrackets.first:
                    medicareLevyItems.percentageOfIncome = medicareBrackets.firstBracketPercent;
                    medicareLevyItems.excessValue = medicareBrackets.firstExcessValue;
                    break;
                case double n when n > medicareBrackets.first && n <= medicareBrackets.second:
                    medicareLevyItems.percentageOfIncome = medicareBrackets.secondBracketPercent;
                    medicareLevyItems.excessValue = medicareBrackets.secondExcessValue;
                    break;
                case double n when n >= medicareBrackets.third:
                    medicareLevyItems.percentageOfIncome = medicareBrackets.thirdBracketPercent;
                    medicareLevyItems.excessValue = medicareBrackets.thirdExcessValue;
                    break;
            }

            return medicareLevyItems;
        }
    }
}
