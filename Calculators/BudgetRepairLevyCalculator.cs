namespace TaxAPI.Calculators
{
    using System;
    using TaxAPI.Models;

    public class BudgetRepairLevyCalculator
    {
        public SalaryItems calculateBudgetRepairLevy(SalaryItems salary)
        {
            return getBudgetRepairLevy(salary);
        }

        private SalaryItems getBudgetRepairLevy(SalaryItems salary)
        {
            BudgetRepairBrackets budgetRepairBrackets = new BudgetRepairBrackets();
            DefineBracket defineBracket = new DefineBracket();

            budgetRepairBrackets = (BudgetRepairBrackets)defineBracket.defineBracket(salary.taxableIncome, budgetRepairBrackets);

            // Calculate based on the defined Medicare bracket values
            DeductionCalculator deductionCalculator = new DeductionCalculator();
            salary.deductionItems.budgetRepairLevy = deductionCalculator.deductionCalculator(salary.taxableIncome, budgetRepairBrackets, 0);

            return salary;
        }
    }
}
