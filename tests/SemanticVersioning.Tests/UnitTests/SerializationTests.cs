using System.Text.Json;

using Xunit;

namespace SemanticVersioning.Tests.UnitTests
{
    public class SerializationTests
    {
        [Fact]
        public void CanRoundTripSerialize_WithSystemTextJson()
        {
            var original = new SemanticVersion("1.2.3-alpha.1+build");
            var json = JsonSerializer.Serialize(original);
            var deserialized = JsonSerializer.Deserialize<SemanticVersion>(json);

            Assert.Equal(original, deserialized);
        }

        [Fact]
        public void Deserialize_Null_ThrowsJsonException()
        {
            Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<SemanticVersion>("null"));
        }
    }
}