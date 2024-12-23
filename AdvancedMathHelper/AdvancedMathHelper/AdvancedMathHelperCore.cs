using AdvancedMathHelper.Exceptions;

namespace AdvancedMathHelper
{
    public class AdvancedMathHelperCore
    {
        public static int SumOfAllNaturalNumbersUpTo(int target)
        {
            if (target <= 0)
                throw new InvalidInputDataException();

            /* 
            int result = Enumerable.Range(1, target).Sum();
            return result;
             */

            return target * (target + 1) / 2;
        }

    }
}
