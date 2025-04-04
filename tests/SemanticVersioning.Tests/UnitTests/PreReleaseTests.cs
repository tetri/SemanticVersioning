using Xunit;

namespace SemanticVersioning.Tests.UnitTests
{
    public class PreReleaseTests
    {
        [Theory]
        [InlineData("1.0.0-alpha", "1.0.0-alpha.1", -1)]
        [InlineData("1.0.0-alpha.1", "1.0.0-alpha.beta", -1)]
        [InlineData("1.0.0-alpha.beta", "1.0.0-beta", -1)]
        [InlineData("1.0.0-beta", "1.0.0-beta.2", -1)]
        [InlineData("1.0.0-beta.2", "1.0.0-beta.11", -1)]
        [InlineData("1.0.0-beta.11", "1.0.0-rc.1", -1)]
        [InlineData("1.0.0-rc.1", "1.0.0", -1)]
        public void ComparePreRelease_Versions_CorrectOrdering(string v1, string v2, int expected)
        {
            var version1 = new SemanticVersion(v1);
            var version2 = new SemanticVersion(v2);

            var result = version1.CompareTo(version2);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1.0.0-1", "1.0.0-2", -1)]
        [InlineData("1.0.0-1", "1.0.0-1", 0)]
        [InlineData("1.0.0-2", "1.0.0-1", 1)]
        [InlineData("1.0.0-1", "1.0.0-a", -1)]
        [InlineData("1.0.0-a", "1.0.0-1", 1)]
        public void ComparePreRelease_NumericVsAlpha_CorrectOrdering(string v1, string v2, int expected)
        {
            var version1 = new SemanticVersion(v1);
            var version2 = new SemanticVersion(v2);

            var result = version1.CompareTo(version2);
            Assert.Equal(expected, result);
        }
    }
}