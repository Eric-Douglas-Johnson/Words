
using Permutation.BackEnd;
using Xunit.Abstractions;

namespace BackEndUnitTests
{
    public class PermutationTests
    {
        private readonly ITestOutputHelper _outputHelper;

        public PermutationTests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [Fact]
        public void GetRandomPermutation_ReturnsValidString_WhenValidInput()
        {
            // Arrange
            var inputStr = "helloworld";

            // Act
            var randomPermutation = PermutationGenerator.GetRandomPermutation(inputStr);

            // Assert
            foreach (var character in inputStr)
            {
                Assert.Contains(character, randomPermutation);
            }
        }

        [Fact]
        public void GetRandomPermutation_ReturnsSingleChar_WhenSingleCharInput()
        {
            // Arrange
            var inputStr = "h";

            // Act
            var randomPermutation = PermutationGenerator.GetRandomPermutation(inputStr);

            // Assert
            Assert.Equal(randomPermutation, inputStr);
        }

        [Fact]
        public void GetRandomPermutation_ThrowsArgNullEx_WhenWordArgIsNull()
        {
            // Arrange
            string? inputStr = null;

            // Act and Assert
            var ex = Assert.Throws<ArgumentNullException>(() => PermutationGenerator.GetRandomPermutation(inputStr!));
            Assert.Equal("Value cannot be null. (Parameter 'word')", ex.Message);
        }

        [Fact]
        public void GetRandomPermutation_ThrowsArgNullEx_WhenWordArgIsEmpty()
        {
            // Arrange
            var inputStr = string.Empty;

            // Act and Assert
            var ex = Assert.Throws<ArgumentNullException>(() => PermutationGenerator.GetRandomPermutation(inputStr));
            Assert.Equal("Value cannot be null. (Parameter 'word')", ex.Message);
        }
    }
}