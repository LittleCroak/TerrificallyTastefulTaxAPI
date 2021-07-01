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
            // First switch determines which tax bracket to utilize:

            switch(returnBrackets.bracketLabel)
            {
                case "medicare":
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
                    break;

                case "budget_repair":
                    switch (taxableIncome)
                    {
                        case double n when n <= returnBrackets.firstBracket:
                            returnBrackets.excessValue = returnBrackets.firstExcessValue;
                            returnBrackets.percentageOfIncome = returnBrackets.firstBracketPercent;
                            break;
                        case double n when n > returnBrackets.firstBracket:
                            returnBrackets.excessValue = returnBrackets.secondExcessValue;
                            returnBrackets.percentageOfIncome = returnBrackets.secondBracketPercent;
                            break;
                    }
                    break;

                case "income_tax":
                    switch (taxableIncome)
                    {
                        case double n when n <= returnBrackets.firstBracket:
                            returnBrackets.excessValue = returnBrackets.firstExcessValue;
                            returnBrackets.percentageOfIncome = returnBrackets.firstBracketPercent;
                            returnBrackets.taxAddition = returnBrackets.firstTaxAddition;
                            break;
                        case double n when n > returnBrackets.firstBracket && n <= returnBrackets.secondBracket:
                            returnBrackets.excessValue = returnBrackets.secondExcessValue;
                            returnBrackets.percentageOfIncome = returnBrackets.secondBracketPercent;
                            returnBrackets.taxAddition = returnBrackets.secondTaxAddition;
                            break;
                        case double n when n > returnBrackets.secondBracket && n <= returnBrackets.thirdBracket:
                            returnBrackets.excessValue = returnBrackets.thirdExcessValue;
                            returnBrackets.percentageOfIncome = returnBrackets.thirdBracketPercent;
                            returnBrackets.taxAddition = returnBrackets.thirdTaxAddition;
                            break;
                        case double n when n > returnBrackets.thirdBracket && n <= returnBrackets.fourthBracket:
                            returnBrackets.excessValue = returnBrackets.fourthExcessValue;
                            returnBrackets.percentageOfIncome = returnBrackets.fourthBracketPercent;
                            returnBrackets.taxAddition = returnBrackets.fourthTaxAddition;
                            break;
                        case double n when n >= fifthBracket:
                            returnBrackets.excessValue = returnBrackets.fifthExcessValue;
                            returnBrackets.percentageOfIncome = returnBrackets.fifthBracketPercent;
                            returnBrackets.taxAddition = returnBrackets.fifthTaxAddition;
                            break;
                    }
                    break;
            }

            return returnBrackets;
        }
    }
}
