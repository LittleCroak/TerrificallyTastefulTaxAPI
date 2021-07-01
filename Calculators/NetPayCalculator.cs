namespace TaxAPI.Calculators
{
    using TaxAPI.Models;
    using System;

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

            salary.netIncome = Math.Round((salary.grossPackage - salary.superContribution - deductions), 2);

            return salary;
        }
    }
}
