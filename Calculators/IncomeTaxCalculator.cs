namespace TaxAPI.Calculators
{
    using System;
    using TaxAPI.Models;

    public class IncomeTaxCalculator
    {
        public SalaryItems calculateIncomeTax(SalaryItems salary)
        {
            return getIncomeTax(salary);
        }

        private SalaryItems getIncomeTax(SalaryItems salary)
        {
            IncomeTaxBrackets incomeTaxBrackets = new IncomeTaxBrackets();
            DefineBracket defineBracket = new DefineBracket();

            incomeTaxBrackets = (IncomeTaxBrackets)defineBracket.defineBracket(salary.taxableIncome, incomeTaxBrackets);

            // Calculate based on the defined Medicare bracket values
            DeductionCalculator deductionCalculator = new DeductionCalculator();
            salary.deductionItems.incomeTax = deductionCalculator.deductionCalculator(salary.taxableIncome, incomeTaxBrackets);

            return salary;
        }
    }
}
