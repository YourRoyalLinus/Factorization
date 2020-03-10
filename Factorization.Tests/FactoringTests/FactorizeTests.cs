using System.Collections.Generic;
using Factorization.Factoring;
using Factorization.NumberTypes;
using Factorization.NumberTypes.Interfaces;
using Xunit;

namespace Factorization.Tests.FactoringTests
{
    public class FactorizeTests
    {
        [Theory]
        [InlineData(75)]
        [InlineData(100)]
        [InlineData(1234)]
        [InlineData(12345678910)]
        public void Factorize_CompleteFactoring(long number)
        {
            // Arrange
            CompositeNumber compositeNumber = new CompositeNumber(number);
            
            // Act
            var factors = Factorize.Factor(compositeNumber);
            var expected = new LinkedList<IFactor>();
            // Assert
            Assert.IsType(factors.GetType(), expected);
            Assert.True(factors.Count >= 2);
        }
    }
}