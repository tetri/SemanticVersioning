using System.Diagnostics;

using Xunit;

namespace SemanticVersioning.Tests.UnitTests
{
    public class PerformanceTests
    {
        [Fact]
        public void Parse_StandardVersion_Under1ms()
        {
            var sw = Stopwatch.StartNew();
            for (int i = 0; i < 1000; i++)
            {
                var version = new SemanticVersion("1.2.3");
            }
            sw.Stop();

            Assert.True(sw.ElapsedMilliseconds < 100);
        }
    }
}