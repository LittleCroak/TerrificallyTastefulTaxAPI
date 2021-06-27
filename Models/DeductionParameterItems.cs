using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxAPI.Models
{
    public class DeductionParameterItems
    {
        // Medicare Section
        // Medicare Bracket definitons:
        public double firstMedicareBracket { get; }
        public double secondMedicareBracket { get; }
        public double thirdMedicareBracket { get; }


        // Constructor:
        // Here any values can be changed to easily allow for new tax years
        public DeductionParameterItems()
        {
            // set Medicare Bracket Defintions
            firstMedicareBracket = 21335;
            secondMedicareBracket = 26668;
            thirdMedicareBracket = 26669;

        }
    }
}
