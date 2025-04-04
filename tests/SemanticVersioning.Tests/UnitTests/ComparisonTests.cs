using Xunit;

namespace SemanticVersioning.Tests.UnitTests
{
    public class ComparisonTests
    {
        [Theory]
        // Testes básicos
        [InlineData("1.0.0", "2.0.0", -1)]
        [InlineData("2.0.0", "1.0.0", 1)]
        [InlineData("1.0.0", "1.0.0", 0)]
        // Testes de patch
        [InlineData("1.0.0", "1.0.1", -1)]
        [InlineData("1.0.1", "1.0.0", 1)]
        // Testes de minor
        [InlineData("1.0.0", "1.1.0", -1)]
        [InlineData("1.1.0", "1.0.0", 1)]
        // Pré-releases
        [InlineData("1.0.0-alpha", "1.0.0", -1)]
        [InlineData("1.0.0-alpha", "1.0.0-beta", -1)]
        [InlineData("1.0.0-beta", "1.0.0-alpha", 1)]
        [InlineData("1.0.0-alpha", "1.0.0-alpha.1", -1)]
        [InlineData("1.0.0-alpha.1", "1.0.0-alpha.beta", -1)]
        [InlineData("1.0.0-alpha.beta", "1.0.0-beta", -1)]
        [InlineData("1.0.0-beta", "1.0.0-beta.2", -1)]
        [InlineData("1.0.0-beta.2", "1.0.0-beta.11", -1)]
        [InlineData("1.0.0-beta.11", "1.0.0-rc.1", -1)]
        [InlineData("1.0.0-rc.1", "1.0.0", -1)]
        // Numéricos vs alfabéticos
        [InlineData("1.0.0-1", "1.0.0-a", -1)]
        public void CompareTo_VariousVersions_ReturnsCorrectResult(
            string version1, string version2, int expected)
        {
            var v1 = new SemanticVersion(version1);
            var v2 = new SemanticVersion(version2);

            var result = v1.CompareTo(v2);
            Assert.Equal(expected, result);
        }
    }
}