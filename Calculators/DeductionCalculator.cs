namespace TaxAPI.Calculators
{
    using System;
    using TaxAPI.Models;

    public class DeductionCalculator
    {
        public double deductionCalculator(double taxableIncome, TaxBrackets xBrackets, double taxAddition)
        {
            return calculateDeductions(taxableIncome, xBrackets, taxAddition);
        }
        private double calculateDeductions(double taxableIncome, TaxBrackets xBrackets, double taxAddition)
        {
            // Calculate based on the defined Medicare bracket values
            var deduction = 0.00;
            if (xBrackets.excessValue == null)
            {
                // calculate the Taxable income * medicare levy bracket percentage / 100
                deduction = taxableIncome * (xBrackets.percentageOfIncome / 100);
            }
            else
            {
                // in the case of being in the second bracket, it is percentage of excess over x:
                // Taxable Income - Excess value defined by ATO * percentage of income
                deduction = ((double)((taxableIncome - xBrackets.excessValue) * ((taxAddition + xBrackets.percentageOfIncome) / 100)));
            }
            return Math.Ceiling(deduction);
        }
    }
}
