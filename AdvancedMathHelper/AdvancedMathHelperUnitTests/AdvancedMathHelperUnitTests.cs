using AdvancedMathHelper;

namespace AdvancedMathHelperUnitTests
{
    public class AdvancedMathHelperUnitTests
    {
        private readonly AdvancedMathHelperCore AdvancedMathHelper;

        public AdvancedMathHelperUnitTests()
        {
            AdvancedMathHelper = new AdvancedMathHelperCore();
        }


        [Theory]
        [InlineData(10, 55)]
        [InlineData(3, 6)]
        public void SumOfAllNaturalNumbersUpTo_ShouldReturnResult_WhenGivenNaturalNumber(int target, int expectedResult)
        {

            Assert.Equal(AdvancedMathHelperCore.SumOfAllNaturalNumbersUpTo(target), expectedResult);

        }
    }
}