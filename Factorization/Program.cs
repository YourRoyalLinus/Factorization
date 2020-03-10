using System;
using System.Collections.Generic;
using Factorization.DataHandling;
using Factorization.Factoring;
using Factorization.Messaging;
using Factorization.NumberTypes;
using Factorization.NumberTypes.Interfaces;

namespace Factorization
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput = null;
            bool userContinue = true;
            while (userContinue)
            {
                userInput = StandardInputMessage.RequestInput();
                
                if (DataValidation.ValidateInput(userInput) == false)
                {
                    bool retry = StandardInputMessage.RePrompt();
                    if (retry == false)
                    {
                        userContinue = false;
                        Environment.ExitCode = 22;
                    }
                }
                else
                {
                    long userNumber = DataManipulation.ReturnValue(userInput);
                    if (DataValidation.ValidateComposite(userNumber) == false)
                    {
                        bool retry = StandardInputMessage.RePrompt(); //refactor using userContinue from RePrompt()
                        if (retry == false)
                        {
                            userContinue = false;
                            Environment.ExitCode =  44;
                        }
                    }
                    else
                    {
                        CompositeNumber userComposite = new CompositeNumber(userNumber);
                        
                        LinkedList<IFactor> factors = Factorize.Factor(userComposite);

                        List<IFactor> primeNumbers = DataManipulation.ReturnPrimes(factors); //Should be list of primes
                        List<IFactor> compositeNumbers = DataManipulation.ReturnComposites(factors); //Should be list of composites
                        FactorizationTree factorTree = DataManipulation.ReturnPopulatedTree(factors);

                        StandardOutputMessage.OutputFactors(compositeNumbers, userNumber); 
                        StandardOutputMessage.OutputFactors(primeNumbers, userNumber); 
                        StandardOutputMessage.OutputFactorizationTree(factorTree, userNumber);
                        
                        bool retry = StandardInputMessage.RePrompt(); 
                        if (retry == false)
                        {
                            userContinue = false;
                            Environment.ExitCode =  100;
                        }
                    }
                }
            }
        }
    }
}