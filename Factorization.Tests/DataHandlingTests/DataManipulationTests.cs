using System;
using System.Collections.Generic;
using Factorization.DataHandling;
using Factorization.Factoring;
using Factorization.NumberTypes;
using Factorization.NumberTypes.Interfaces;
using Xunit;

namespace Factorization.Tests.DataHandlingTests
{
    public class DataManipulationTests
    {
        [Fact]
        public void DataManipulation_ReturnValue_ReturnsLong()
        {
            // Arrange
            Random random = new Random(1000000);
            
            // Act
            var actual = DataManipulation.ReturnValue(random.Next().ToString());
            var expected = typeof(long);
            
            // Assert
            Assert.IsType(expected, actual);
        }

        [Theory]
        [InlineData(50, 2, 25, 5, 5)]
        public void DataManipulation_ReturnPrimes_ReturnsPrimes(long c1, long p1, long c2, long p2, long p3)
        {
            // Arrange
            LinkedList<IFactor> testFactors = new LinkedList<IFactor>();
            testFactors.AddLast(new CompositeNumber(c1));
            testFactors.AddLast(new PrimeNumber(p1));
            testFactors.AddLast(new CompositeNumber(c2));
            testFactors.AddLast(new PrimeNumber(p2));
            testFactors.AddLast(new PrimeNumber(p3));
            
            // Act
            List<IFactor> testPrimes = DataManipulation.ReturnPrimes(testFactors);
            
            // Assert
            Assert.True(testPrimes.Count == 3); 
            
            long sum = 0;
            foreach (var factor in testPrimes)
            {
                sum += factor.Value;
                Assert.True(factor.GetType() == typeof(PrimeNumber));
            }
            Assert.True(sum == p1+p2+p3);
        }
        
        [Theory]
        [InlineData(50, 2, 25, 5, 5)]
        public void DataManipulation_ReturnComposites_ReturnsComposites(long c1, long p1, long c2, long p2, long p3)
        {
            // Arrange
            var testFactors = new LinkedList<IFactor>();
            testFactors.AddLast(new CompositeNumber(c1));
            testFactors.AddLast(new PrimeNumber(p1));
            testFactors.AddLast(new CompositeNumber(c2));
            testFactors.AddLast(new PrimeNumber(p2));
            testFactors.AddLast(new PrimeNumber(p3));
            
            // Act
            var testComposites = DataManipulation.ReturnComposites(testFactors);
            
            // Assert
            Assert.True(testComposites.Count == 2); 
            
            long sum = 0;
            foreach (var factor in testComposites)
            {
                sum += factor.Value;
                Assert.True(factor.GetType() == typeof(CompositeNumber));
            }
            Assert.True(sum == c1+c2);
        }

        [Theory]
        [InlineData(50, 2, 25, 5, 5)]
        public void DataManipulation_ReturnPopulatedTree_PopulatesTree(long c1, long p1, long c2, long p2, long p3)
        {
            // Arrange
            var testFactors = new LinkedList<IFactor>();
            testFactors.AddLast(new CompositeNumber(c1));
            testFactors.AddLast(new PrimeNumber(p1));
            testFactors.AddLast(new CompositeNumber(c2));
            testFactors.AddLast(new PrimeNumber(p2));
            testFactors.AddLast(new PrimeNumber(p3));
            
            // Act
            var testTree = DataManipulation.ReturnPopulatedTree(testFactors);
            
            // Assert
            Assert.True(testTree.GetType() == typeof(FactorizationTree));
            Assert.True(testTree.Count == 5);
        }
    }
}