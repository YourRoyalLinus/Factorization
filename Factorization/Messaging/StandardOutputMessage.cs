using System;
using System.Collections.Generic;
using System.Linq;
using Factorization.Factoring;
using Factorization.Factoring.BinaryTree;
using Factorization.NumberTypes;
using Factorization.NumberTypes.Interfaces;

namespace Factorization.Messaging
{
    public static class StandardOutputMessage
    {
        public static void OutputFactors(IEnumerable<IFactor> factors, long userNumber)
        {
            var enumerable = factors.ToList();
            if (enumerable.First().GetType() == typeof(CompositeNumber)) //refactor into one changing type with sign
            {
                Console.Write($"The Composite factors of {userNumber} are: ");

                foreach (IFactor factor in enumerable)
                {
                    if (factor == enumerable.Last())
                    {
                        Console.Write($"{factor.Value.ToString()}.");
                    }
                    else
                    {
                        Console.Write($"{factor.Value.ToString()}, ");  
                    }
                }

                Console.WriteLine("\n");
                return;
            }

            if (enumerable.First().GetType() == typeof(PrimeNumber)) //refactor into one changing type with sign
            {
                Console.Write($"The Prime factors of {userNumber} are: ");

                foreach (IFactor factor in enumerable)
                {
                    if (factor == enumerable.Last())
                    {
                        Console.Write($"{factor.Value.ToString()}.");
                    }
                    else
                    {
                        Console.Write($"{factor.Value.ToString()}, ");
                    }
                }

                Console.WriteLine("\n");
                return;
            }
        }
        
        public static void OutputFactorizationTree(FactorizationTree tree, long userNumber)
        {
            Console.Write($"Factorization Tree of {userNumber}: ");
            tree.Root.Print();
            Console.WriteLine("\n");
            return;
        }
    }
}