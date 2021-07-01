namespace TaxAPI.Calculators
{
    using TaxAPI.Models;
    public class TotalDeductions
    {
        public double totalDeductions(SalaryItems salary)
        {
            return addAllDeductions(salary);
        }

        private double addAllDeductions(SalaryItems salary)
        {
            return (salary.deductionItems.medicareLevy + salary.deductionItems.budgetRepairLevy + salary.deductionItems.incomeTax);
        }
    }
}
