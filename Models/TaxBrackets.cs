namespace TaxAPI.Models
{
    public abstract class TaxBrackets : TaxPercentages
    {
        // These values are abstract values that are commonly tuned for bracket calculations, such as income tax, medicare levy and budget repair levy.
        // out of all the above there is a total number of brackets (tax income highest at the moment with five)
        // However not all use five, budget repair only has two brackets for example and as such the inheriting values may not need to use all of them.

        // defines the actual medicare brackey cut offs
        public double firstBracket { get; set; }
        public double secondBracket { get; set; }
        public double thirdBracket { get; set; }

        // defines the percentage of income, some of these may be zero but are kept as values to change if necessary later.
        public double firstBracketPercent { get; set;                       }
        public double secondBracketPercent { get; set; }
        public double thirdBracketPercent { get; set; }

        // defines the excess value cut off, again some may be 0/null but are open to be expanded upon later if necessary.
        public double? firstExcessValue { get; set; }
        public double? secondExcessValue { get; set; }
        public double? thirdExcessValue { get; set; }

        public double numOfBrackets { get; set; }
    }
}
