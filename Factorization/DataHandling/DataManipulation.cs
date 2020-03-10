using System.Collections.Generic;
using System.Linq;
using Factorization.Factoring;
using Factorization.NumberTypes;
using Factorization.NumberTypes.Interfaces;

namespace Factorization.DataHandling
{
    public static class DataManipulation
    {
        public static long ReturnValue(string input)
        {
            return long.Parse(input);
        }

        public static List<IFactor> ReturnPrimes(LinkedList<IFactor> factors) //These two can be overloaded?
        {
            IEnumerable<IFactor> primeNumbers =
                from factor in factors
                where factor.GetType() == typeof(PrimeNumber)
                select factor;
    
            return primeNumbers.ToList();
        }

        public static List<IFactor> ReturnComposites(LinkedList<IFactor> factors)
        {
            IEnumerable<IFactor> compositeNumbers =
                from factor in factors
                where factor.GetType() == typeof(CompositeNumber)
                select factor;

            return compositeNumbers.ToList();
        }

        public static FactorizationTree ReturnPopulatedTree(LinkedList<IFactor> factors)
        {
            FactorizationTree tree = new FactorizationTree();
            foreach (var factor in factors)
            {
                tree.Add(factor);
            }

            return tree;
        }
    }
}