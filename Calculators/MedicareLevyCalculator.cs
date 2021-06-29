namespace TaxAPI.Calculators
{
    using System;
    using TaxAPI.Models;

    public class MedicareLevyCalculator : TaxBrackets
    {
        public SalaryItems calculateMedicareLevy(SalaryItems salary)
        {
            return getMedicareLevy(salary);
        }

        private SalaryItems getMedicareLevy(SalaryItems salary)
        {
            MedicareBrackets medicareBrackets = new MedicareBrackets();
            DefineBracket defineBracket = new DefineBracket();

            medicareBrackets = (MedicareBrackets)defineBracket.defineBracket(salary.taxableIncome, medicareBrackets);

            // Calculate based on the defined Medicare bracket values
            DeductionCalculator deductionCalculator = new DeductionCalculator();
            salary.deductionItems.medicareLevy = deductionCalculator.deductionCalculator(salary.taxableIncome, medicareBrackets, 0);

            return salary;
        }
    }
}
