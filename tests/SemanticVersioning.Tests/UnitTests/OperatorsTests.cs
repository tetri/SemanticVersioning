using Xunit;

namespace SemanticVersioning.Tests.UnitTests
{
    public class OperatorsTests
    {
        [Theory]
        [InlineData("1.0.0", "1.0.0", true)]
        [InlineData("1.0.0", "2.0.0", false)]
        public void EqualityOperator_ComparesCorrectly(string v1, string v2, bool expected)
        {
            var version1 = new SemanticVersion(v1);
            var version2 = new SemanticVersion(v2);

            Assert.Equal(expected, version1 == version2);
        }

        [Theory]
        [InlineData("1.0.0", "1.0.0", false)]
        [InlineData("1.0.0", "2.0.0", true)]
        public void InequalityOperator_ComparesCorrectly(string v1, string v2, bool expected)
        {
            var version1 = new SemanticVersion(v1);
            var version2 = new SemanticVersion(v2);

            Assert.Equal(expected, version1 != version2);
        }

        [Theory]
        [InlineData("1.0.0", "2.0.0", true)]
        [InlineData("2.0.0", "1.0.0", false)]
        [InlineData("1.0.0", "1.0.0", false)]
        public void LessThanOperator_ComparesCorrectly(string v1, string v2, bool expected)
        {
            var version1 = new SemanticVersion(v1);
            var version2 = new SemanticVersion(v2);

            Assert.Equal(expected, version1 < version2);
        }

        // Testes similares para >, <=, >=
    }
}