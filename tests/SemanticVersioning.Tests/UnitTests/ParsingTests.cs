using System;

using Xunit;

namespace SemanticVersioning.Tests.UnitTests
{
    public class ParsingTests
    {
        [Theory]
        [InlineData("1.2.3", 1, 2, 3, "", "")]
        [InlineData("1.0.0-alpha", 1, 0, 0, "alpha", "")]
        [InlineData("1.0.0-alpha.1", 1, 0, 0, "alpha.1", "")]
        [InlineData("1.0.0-0.3.7", 1, 0, 0, "0.3.7", "")]
        [InlineData("1.0.0-x.7.z.92", 1, 0, 0, "x.7.z.92", "")]
        [InlineData("1.0.0-alpha+001", 1, 0, 0, "alpha", "001")]
        [InlineData("1.0.0+20130313144700", 1, 0, 0, "", "20130313144700")]
        public void Parse_ValidVersions_ParsesCorrectly(
            string versionString,
            int expectedMajor,
            int expectedMinor,
            int expectedPatch,
            string expectedPreRelease,
            string expectedBuild)
        {
            var version = new SemanticVersion(versionString);

            Assert.Equal(expectedMajor, version.Major);
            Assert.Equal(expectedMinor, version.Minor);
            Assert.Equal(expectedPatch, version.Patch);
            Assert.Equal(expectedPreRelease, version.Prerelease);
            Assert.Equal(expectedBuild, version.Build);
        }

        [Theory]
        [InlineData("1")]
        [InlineData("1.2")]
        [InlineData("1.2.3-")]
        [InlineData("1.2.3-+build")]
        [InlineData("a.b.c")]
        [InlineData("1.0.0-alpha_beta")]
        [InlineData("1.0.0-alpha..1")]
        public void Parse_InvalidVersions_ThrowsException(string invalidVersion)
        {
            Assert.Throws<ArgumentException>(() => new SemanticVersion(invalidVersion));
        }

        [Theory]
        [InlineData("1.0.0-01")]
        [InlineData("1.0.0-alpha.01")]
        public void Parse_InvalidPrereleaseLeadingZero_ThrowsException(string invalidVersion)
        {
            Assert.Throws<ArgumentException>(() => new SemanticVersion(invalidVersion));
        }

        [Fact]
        public void Parse_Null_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new SemanticVersion(null!));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("\t")]
        [InlineData("\r\n")]
        public void Parse_Whitespace_ThrowsArgumentException(string invalidVersion)
        {
            Assert.Throws<ArgumentException>(() => new SemanticVersion(invalidVersion));
        }
    }
}