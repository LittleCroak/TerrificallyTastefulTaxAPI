namespace TaxAPI.Models
{
    public class MedicareBrackets : TaxBrackets
    {
        public MedicareBrackets()
        {
            // Define the brakcets
            firstBracket = 21335;
            secondBracket = 26668;
            thirdBracket = 26669;

            // define the percentage of income, some of these may be zero but are kept as values to ensure easy change later:
            firstBracketPercent = 0;
            secondBracketPercent = 10;
            thirdBracketPercent = 2;

            // defines the excess value cut off, again some may be 0/null but are open to be expanded upon later if necessary:
            firstExcessValue = null;
            secondExcessValue = 21335;
            thirdExcessValue = null;

            bracketLabel = "medicare";
        }
    }
}
