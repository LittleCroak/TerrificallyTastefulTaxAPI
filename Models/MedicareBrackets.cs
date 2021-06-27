namespace TaxAPI.Models
{
    public class MedicareBrackets
    {
        // defines the actual medicare brackey cut offs
        public double first = 21335;
        public double second = 26668;
        public double third = 26669;

        // defines the percentage of income, some of these may be zero but are kept as values to change if necessary later.
        public double firstBracketPercent = 0;
        public double secondBracketPercent = 10;
        public double thirdBracketPercent = 2;

        // defines the excess value cut off, again some may be 0/null but are open to be expanded upon later if necessary.
        public double? firstExcessValue = null;
        public double? secondExcessValue = 21335;
        public double? thirdExcessValue = null;
    }
}
