namespace TaxAPI.Calculators
{
    using TaxAPI.Models;

    public class DefineBracket : TaxBrackets
    {
        public TaxBrackets defineBracket(double taxableIncome, TaxBrackets returnBrackets)
        {
            returnBrackets = determineTaxBracket(taxableIncome, returnBrackets);
            return returnBrackets;
        }

        private TaxBrackets determineTaxBracket(double taxableIncome, TaxBrackets returnBrackets)
        {
            switch (taxableIncome)
            {
                case double n when n <= returnBrackets.firstBracket:
                    returnBrackets.excessValue = returnBrackets.firstExcessValue;
                    returnBrackets.percentageOfIncome = returnBrackets.firstBracketPercent;
                    break;
                case double n when n > returnBrackets.firstBracket && n <= returnBrackets.secondBracket:
                    returnBrackets.excessValue = returnBrackets.secondExcessValue;
                    returnBrackets.percentageOfIncome = returnBrackets.secondBracketPercent;
                    break;
                case double n when n >= thirdBracket:
                    returnBrackets.excessValue = returnBrackets.thirdExcessValue;
                    returnBrackets.percentageOfIncome = returnBrackets.thirdBracketPercent;
                    break;
            }

            return returnBrackets;
        }
    }
}
