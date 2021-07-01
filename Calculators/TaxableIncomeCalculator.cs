using System;

using TaxAPI.Models;

namespace TaxAPI.Calculators
{
    public class TaxableIncomeCalculator
    {
        public SalaryItems calculateTaxableIncome(SalaryItems salary)
        {
            // calculate the taxable income using the Gross package provided by user
            // store the values for super contribution and taxable income in salary object
            getTaxableIncome(salary);

            return salary;
        }

        private SalaryItems getTaxableIncome(SalaryItems salary)
        {
            // Get Super contribution from Gross Package
            SuperCalculator calculateSuper = new SuperCalculator();

            salary.superContribution = calculateSuper.getSuper(salary);

            // Define Taxable income
            salary.taxableIncome = Math.Round(salary.grossPackage - salary.superContribution, 2);

            return salary;
        }
    }
}

