namespace TaxAPI.Models
{
    public class IncomeTaxBrackets : TaxBrackets
    {
        public IncomeTaxBrackets()
        {
            // Define the brakcets
            firstBracket = 18200;
            secondBracket = 37000;
            thirdBracket = 87000;
            fourthBracket = 180000;
            fifthBracket = 1800001;


            // define the percentage of income, some of these may be zero but are kept as values to ensure easy change later:
            firstBracketPercent = 0;
            secondBracketPercent = 19;
            thirdBracketPercent = 32.5;
            fourthBracketPercent = 37;
            fifthBracketPercent = 47;

            // defines the excess value cut off, again some may be 0/null but are open to be expanded upon later if necessary:
            firstExcessValue = null;
            secondExcessValue = 18200;
            thirdExcessValue = 37000;
            fourthExcessValue = 87000;
            fifthExcessValue = 180000;

            // The flat rates for each tax addition for each bracket
            firstTaxAddition = 0;
            secondTaxAddition = 0;
            thirdTaxAddition = 3572;
            fourthTaxAddition = 19822;
            fifthTaxAddition = 54232;

            // Label to define logic flow <dont really like this solution, should change later>
            bracketLabel = "income_tax";
        }

    }
}
