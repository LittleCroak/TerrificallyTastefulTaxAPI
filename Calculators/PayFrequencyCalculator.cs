namespace TaxAPI.Calculators
{
    using TaxAPI.Models;
    using System;
    using Microsoft.AspNetCore.Http;


    public class PayFrequencyCalculator
    {
        // Based on the users inpt, 
        public SalaryItems calculatePayFrequency(SalaryItems salary)
        {
            salary.payFrequencyAmount = Math.Round(payFrequencyCalculator(salary), 2);
            return salary;
        }

        private double defineFrequency(string payFrequencyChoice)
        {
            try
            {
                switch (payFrequencyChoice)
                {
                    case "weekly":
                        return 52;
                    case "fortnightly":
                        return 26;
                    case "monthly":
                        return 12;
                    default:
                        throw new Exception();
                }
            }
            catch (Exception e)
            {
                throw new ArgumentException();
            }

            return 0;
        }

        private double payFrequencyCalculator(SalaryItems salary)
        {
            // given the choice put in by the user capture any errors and
            // assign a division value for the upcoming calculator
            return salary.netIncome / (defineFrequency(salary.payFrequency));
        }


    }
}
