﻿using TaxAPI.Models;
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

            // Calculate taxable income (also calculates super contribution)
            salary = taxableIncomeCalculator.calculateTaxableIncome(salary);
            // Calculate Medicare Levy
            salary = medicareLevyCalculator.calculateMedicareLevy(salary);

            return salary;
        }
    }
}