namespace TaxAPI.Models
{
    public class BudgetRepairBrackets : TaxBrackets
    {
        public BudgetRepairBrackets()
        {
            // define first bracket, only one value required for budget repair levy
            firstBracket = 180000;

            // define the percentages for budget repair, some may be zero but are listed for ease of change later if necessary.
            firstBracketPercent = 0;
            secondBracketPercent = 2;

            // Define the excess value:
            firstExcessValue = null;
            secondExcessValue = 180000;

            bracketLabel = "budget_repair";
        }
    }
}
