namespace TestApp.Conosle.Tests
{
    using TestApp.Console;
    using Xunit;

    public class DivisibilityTests
    {
        [Theory]
        [InlineData("6")]
        [InlineData("18")]
        public void WhenInputIsDivisibleBy3_PrintsFizz(string input)
        {
            var divisibility = new Divisibility();
            var result = divisibility.CheckDivisibility(input);

            Assert.Equal("Fizz", result);
        }

        [Theory]
        [InlineData("10")]
        [InlineData("25")]
        public void WhenInputIsDivisibleBy5_PrintsBuzz(string input)
        {
            var divisibility = new Divisibility();
            var result = divisibility.CheckDivisibility(input);

            Assert.Equal("Buzz", result);
        }

        [Theory]
        [InlineData("15")]
        [InlineData("30")]
        public void WhenInputIsDivisibleByBoth3And5_PrintsFizzBuzz(string input)
        {
            var divisibility = new Divisibility();
            var result = divisibility.CheckDivisibility(input);

            Assert.Equal("FizzBuzz", result);
        }

        [Theory]
        [InlineData("13")]
        [InlineData("19")]
        public void WhenInputIsNotDivisibleByBoth3And5_DoesNotPrintAnything(string input)
        {
            var divisibility = new Divisibility();
            var result = divisibility.CheckDivisibility(input);

            Assert.Equal("", result);
        }

        [Theory]
        [InlineData("-5")]
        [InlineData("12")]
        public void WhenInputIsANegativeNumber_RunsTheLogicForDivisibility(string input)
        {
            var divisibility = new Divisibility();
            var result = divisibility.CheckDivisibility(input);

            Assert.IsType<string>(result);
        }

        [Theory]
        [InlineData("Test")]
        public void WhenInputIsNotAnInteger_DoesNotPrintAnything(string input)
        {
            var divisibility = new Divisibility();
            var result = divisibility.CheckDivisibility(input);

            Assert.Equal("", result);
        }
    }
}
