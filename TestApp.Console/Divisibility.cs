namespace TestApp.Console
{
    public class Divisibility
    {
        public string CheckDivisibility(string userInput)
        {
            var isInteger = int.TryParse(userInput, out var input);

            if(!isInteger)
            {
                return "";
            }

            if(input % 3 == 0 && input % 5 == 0)
            {
                return "FizzBuzz";
            }
            else if (input % 3 == 0)
            {
                return "Fizz";
            }
            else if (input % 5 == 0)
            {
                return "Buzz";
            }
            else
            {
                return "";
            }
        }
    }
}
