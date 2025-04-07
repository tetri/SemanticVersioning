using Xunit;

namespace SemanticVersioning.Tests.UnitTests
{
    public class EdgeCasesTests
    {
        [Fact]
        public void DefaultConstructor_CreatesVersion0_0_0()
        {
            var version = new SemanticVersion();

            Assert.Equal(0, version.Major);
            Assert.Equal(0, version.Minor);
            Assert.Equal(0, version.Patch);
            Assert.Equal("", version.Prerelease);
            Assert.Equal("", version.Build);
        }

        [Fact]
        public void GetHashCode_EqualVersions_ReturnsSameHashCode()
        {
            var v1 = new SemanticVersion("1.2.3-alpha.1+build");
            var v2 = new SemanticVersion("1.2.3-alpha.1+build");

            Assert.Equal(v1.GetHashCode(), v2.GetHashCode());
        }

        [Fact]
        public void Equals_WithNonVersionObject_ReturnsFalse()
        {
            var version = new SemanticVersion("1.0.0");
            var notVersion = new object();

            Assert.False(version.Equals(notVersion));
        }

        [Theory]
        [InlineData("1.0.0+build", "1.0.0+different")]
        public void BuildMetadata_DoesNotAffectEquality(string v1, string v2)
        {
            var version1 = new SemanticVersion(v1);
            var version2 = new SemanticVersion(v2);

            Assert.True(version1 == version2);
        }
    }
}