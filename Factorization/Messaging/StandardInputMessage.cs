using System;

namespace Factorization.Messaging
{
    public static class StandardInputMessage
    {
        public static string RequestInput()
        {
            Console.Write("Please enter a rational number to be factorized: ");
            var input = Console.ReadLine();
            Console.WriteLine("\n");
            return input;
        }

        public static bool RePrompt()
        {
            Console.Write("Would you like to enter another number?");
            var input = Console.ReadLine();
            Console.WriteLine("\n");
            
            return input != null && (input.ToUpper().Contains("Y") && !input.ToUpper().Contains("N"));
        }
    }
}