using Factorization.Factoring;
using Factorization.NumberTypes;
using Xunit;

namespace Factorization.Tests.FactoringTests
{
    public class FactorizationTreeTests
    {
        [Theory]
        [InlineData(25)]
        public void FactorizationTree_Add_AddRoot(long root)
        {
            // Arrange 
            CompositeNumber compositeNumber = new CompositeNumber(root);
            FactorizationTree testTree = new FactorizationTree();
            
            // Act
            testTree.Add(compositeNumber);
            
            // Assert
            Assert.True(testTree.Count == 1);
            Assert.True( testTree.Root.value == root);
        }
        
        [Theory]
        [InlineData(25, 5, 5)]
        public void FactorizationTree_Add_AddSubNodes(long root, long sub1, long sub2)
        {
            // Arrange 
            PrimeNumber prime1 = new PrimeNumber(sub1);
            PrimeNumber prime2 = new PrimeNumber(sub2);
            CompositeNumber compositeNumber = new CompositeNumber(root);
            
            FactorizationTree testTree = new FactorizationTree();
            
            // Act
            testTree.Add(compositeNumber);
            testTree.Add(prime1);
            testTree.Add(prime2);
            
            // Assert
            Assert.True(testTree.Count == 3);
            Assert.True(testTree.Root.value == root);
        }
    }
}