using System;

namespace Factorization.DataHandling
{
    public static class DataValidation
    {
        public static bool ValidateInput(string input)
        {
            try
            {
                var numericInput = long.Parse(input, System.Globalization.NumberStyles.Integer);
                if (numericInput >= 0)
                {
                    if (numericInput != 0 && numericInput != 1) return true;
                    Console.WriteLine($"{numericInput} is neither Prime nor Composite."); //OUTPUTS?
                    Console.WriteLine("\n");
                    return false;
                }
                Console.WriteLine("Prime Factorization cannot be done on a negative number."); //OUTPUTS?
                Console.WriteLine("\n");
                return false;
            }
            catch (Exception ex) //These should throw their exceptions and a delegate should trigger an output message
            {
                switch (ex)
                {
                    case ArgumentNullException _:        
                        Console.WriteLine("Please enter a number.");  //OUTPUTS
                        Console.WriteLine("\n");
                        break;
                    case ArgumentException _:
                    case FormatException _:
                        Console.WriteLine("The number entered was not in the correct format."); //OUTPUTS?
                        Console.WriteLine("\n");
                        break;
                    case OverflowException _:
                        Console.WriteLine(
                            $"The number entered was too large. Please enter a number less than {long.MaxValue}."); //OUTPUTS?
                        Console.WriteLine("\n");
                        break;
                    default:
                        Console.WriteLine("An error has occured."); //OUTPUTS?
                        Console.WriteLine("\n");
                        break;
                }

                return false;
            }
        }

        //The Factoring algorithm was created by Sam007 of www.geeksforgeeks.org on the post: https://www.geeksforgeeks.org/print-all-prime-factors-of-a-given-number/
        //Changes were made to remove the Console.Write methods as they are not required for this validation method
        public static bool ValidateComposite(long number)
        {
            if (number == 2)
            {
                Console.WriteLine($"{number} is already a prime number.");
                Console.WriteLine("\n");
                return false;
            }
            
            long numberCopy = number;
            while (number % 2 == 0)
            {
                number /= 2;
            }

            for (long i = 3; i <= Math.Sqrt(number); i += 2)
            {
                while (number % i == 0)
                {
                    number /= i;
                }
            }
            
            if (numberCopy != number) return true;
            Console.WriteLine($"{number} is already a prime number.");
            Console.WriteLine("\n");
            return false;
        }
        
    }
}