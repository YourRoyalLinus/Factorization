using System;
using System.Collections.Generic;
using Factorization.NumberTypes;
using Factorization.NumberTypes.Interfaces;

namespace Factorization.Factoring
{
    public static class Factorize 
    {
        //The Factoring algorithm was created by Sam007 of www.geeksforgeeks.org on the post: https://www.geeksforgeeks.org/print-all-prime-factors-of-a-given-number/
        //Changes were made to incorporate adding the derived numbers to a list rather than printing them to console directly
        
        public static LinkedList<IFactor> Factor(CompositeNumber compNum)
        {
            LinkedList<IFactor> factors = new LinkedList<IFactor>();
            factors.AddFirst(new CompositeNumber(compNum.Value));
            
            while (compNum.Value % 2 == 0)
            {
                compNum.Value /= 2;
                factors.AddLast(new PrimeNumber(2));

                if (compNum.Value % 2 == 0)
                {
                    factors.AddLast(new CompositeNumber(compNum.Value));
                }
            }
            
            for (long i = 3; i <= Math.Sqrt(compNum.Value); i += 2)
            {
                while (compNum.Value % i == 0)
                {
                    if (compNum.Value != i && compNum.Value != factors.First.Value.Value) //factors.First.FirstNodeValue<IFactor>.IFactor.Value
                    {
                        factors.AddLast(new CompositeNumber(compNum.Value));
                    }
                    
                    compNum.Value /= i;
                    factors.AddLast(new PrimeNumber(i));
                }
            }

            if (compNum.Value > 2)
            {
                factors.AddLast(new PrimeNumber(compNum.Value));
            }
            
            return factors;
        }
        
    }
}