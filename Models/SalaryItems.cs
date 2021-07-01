namespace TaxAPI.Models
{
    public class SalaryItems
    {
        public long Id { get; set; }
        public double grossPackage { get; set; }
        public double superContribution { get; set; }
        public double taxableIncome { get; set; }
        public DeductionItems deductionItems { get; set; }
        public double netIncome { get; set; }
        public string payFrequency { get; set; }
        public double payFrequencyAmount { get; set; }

        public SalaryItems()
        {
            deductionItems = new DeductionItems();
        }
    }
}
