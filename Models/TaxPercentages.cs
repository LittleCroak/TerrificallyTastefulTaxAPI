namespace TaxAPI.Models
{
    public abstract class TaxPercentages
    {
        // Percentage of income used to calculate various tax deduction items (medicare levy etc)
        public double percentageOfIncome { get; set; }

        // Excess values are used to calculate how much of a percentage to use when over a certain threshold
        public double? excessValue { get; set; }
    }
}
