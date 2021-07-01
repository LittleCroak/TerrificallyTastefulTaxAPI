using TaxAPI.Models;
using TaxAPI.Calculators;

// A class that will call all other calculators and return SalaryItems with all calculations complete

namespace TaxAPI.Calculators
{
    public class TaxCalculator
    {
        public SalaryItems calculateTax(SalaryItems salary)
        {
            TaxableIncomeCalculator taxableIncomeCalculator = new TaxableIncomeCalculator();
            MedicareLevyCalculator medicareLevyCalculator = new MedicareLevyCalculator();
            BudgetRepairLevyCalculator budgetRepairLevyCalculator = new BudgetRepairLevyCalculator();
            IncomeTaxCalculator incomeTaxCalculator = new IncomeTaxCalculator();
            NetPayCalculator netPayCalculator = new NetPayCalculator();
            PayFrequencyCalculator payFrequencyCalculator = new PayFrequencyCalculator();

            // Calculate taxable income (also calculates super contribution)
            salary = taxableIncomeCalculator.calculateTaxableIncome(salary);
            // Calculate Medicare Levy
            salary = medicareLevyCalculator.calculateMedicareLevy(salary);
            // Calculate Budget repair levy
            salary = budgetRepairLevyCalculator.calculateBudgetRepairLevy(salary);
            // Calculate income tax
            salary = incomeTaxCalculator.calculateIncomeTax(salary);
            // Calculate NetPay
            salary = netPayCalculator.netPayCalculator(salary);
            // Calculate the pay frequency to display
            salary = payFrequencyCalculator.calculatePayFrequency(salary);

            return salary;
        }
    }
}
