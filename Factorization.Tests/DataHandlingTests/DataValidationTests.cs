using System;
using Factorization.DataHandling;
using Xunit;

namespace Factorization.Tests.DataHandlingTests
{
    public class DataValidationTests
    {
        [Fact]
        public void DataValidation_ValidateInput_ValidatesPositiveInteger()
        {
            // Arrange
            Random random = new Random(1000000);
            
            //Act
           var actual =  DataValidation.ValidateInput(random.Next().ToString());
           
           //Assert
           Assert.True(actual);
        }

        [Theory]
        [InlineData("-1")]
        public void DataValidation_ValidateInput_NegativeNumber(string number)
        {
            // Arrange
            
            // Act
            var actual = DataValidation.ValidateInput(number);
            
            // Assert
            Assert.False(actual);
        }
        
        [Theory]
        [InlineData("0")]
        [InlineData("1")]
        public void DataValidation_ValidateInput_NeitherZeroOrOne(string number)
        {
            // Arrange
            
            // Act
            var actual = DataValidation.ValidateInput(number);
            
            // Assert
            Assert.False(actual);
        }
        
        [Fact] 
        public void DataValidation_ValidateInput_NoEntry()
       { 
           // Act
           var actual = DataValidation.ValidateInput(null);
            
           // Assert
           Assert.False(actual); 
       }
        
        [Fact]
        public void DataValidation_ValidateInput_BadFormat() 
        { 
            // Act
            var actual = DataValidation.ValidateInput("27.7");
            
            // Assert
            Assert.False(actual); 
        }

        [Theory]
        [InlineData(long.MaxValue)]
        public void DataValidation_ValidateInput_LongOverFlow(long number)
        {
            // Act
            var actual = DataValidation.ValidateInput((number + 1).ToString());
            
            // Assert
            Assert.False(actual);
        }

        [Theory]
        [InlineData(75)]
        public void DataValidation_ValidateComposite_ValidComposite(long number)
        {
            //Act
            var actual = DataValidation.ValidateComposite(number);
            
            // Assert
            Assert.True(actual);
        }
        
        [Theory]
        [InlineData(2)]
        public void DataValidation_ValidateComposite_InValidComposite(long number)
        {
            //Act
            var actual = DataValidation.ValidateComposite(number);
            
            // Assert
            Assert.False(actual);
        }
        
    }
}