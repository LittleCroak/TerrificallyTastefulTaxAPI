using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxAPI.Models;

namespace TaxAPI.Calculators
{
    public class MedicareLevyCalculator
    {
        public SalaryItems calculateMedicareLevy(SalaryItems salary)
        {
            return getMedicareLevy(salary);
        }

        private SalaryItems getMedicareLevy(SalaryItems salary)
        {
            //define the deduction parameter object
            DeductionParameterItems deductionParameterItems = new DeductionParameterItems();
            MedicareBrackets medicareBrackets = new MedicareBrackets();

            medicareBrackets = defineMedicareBracket(medicareLevyItems, salary.taxableIncome, deductionParameterItems);

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

        private MedicareLevyItems defineMedicareBracket(MedicareLevyItems medicareLevyItems, double taxableIncome, DeductionParameterItems deductionParameterItems)
        {
            switch (taxableIncome)
            {
                case double n when n <= deductionParameterItems.firstMedicareBracket:
                    medicareLevyItems.percentageOfIncome = 0;
                    medicareLevyItems.excessValue = null;
                    break;
                case double n when n > deductionParameterItems.firstMedicareBracket && n <= deductionParameterItems.secondMedicareBracket:
                    medicareLevyItems.percentageOfIncome = 10;
                    medicareLevyItems.excessValue = 21335;
                    break;
                case double n when n >= deductionParameterItems.thirdMedicareBracket:
                    medicareLevyItems.percentageOfIncome = 2;
                    medicareLevyItems.excessValue = null;
                    break;
            }

            return medicareLevyItems;
        }
    }
}
