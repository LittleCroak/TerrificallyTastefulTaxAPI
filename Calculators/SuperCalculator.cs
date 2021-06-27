using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxAPI.Models;

namespace TaxAPI.Calculators
{
    public class SuperCalculator
    {
        public double getSuper(SalaryItems salary)
        {
            return subtractSuper(salary);
        }

        private double subtractSuper(SalaryItems salary)
        {
            // formula to get the super component from gross:
            // Gross Package / 1.095 = x
            // Gross Package - x = Super figure

            var superContribution = salary.grossPackage - (salary.grossPackage / 1.095);

            // ensure that super is rounded up to the nearest cent and returned.

            return Math.Round(superContribution, 2);
        }
    }
}
