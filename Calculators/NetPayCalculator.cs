namespace TaxAPI.Calculators
{
    using TaxAPI.Models;
    public class NetPayCalculator
    {
        public SalaryItems netPayCalculator(SalaryItems salary)
        {
            return calculateNetPay(salary);
        }
        private SalaryItems calculateNetPay(SalaryItems salary)
        {
            TotalDeductions totalDeductions = new TotalDeductions();
            var deductions = totalDeductions.totalDeductions(salary);

            salary.netIncome = (salary.grossPackage - salary.superContribution - deductions);

            return salary;
        }
    }
}
