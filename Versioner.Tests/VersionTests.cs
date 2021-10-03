using System;
using Xunit;

using Versioner;

namespace Versioner.Tests
{
    public class VersionTests
    {
        [Fact]
        public void ShouldBe()
        {
            var v = new Version();
            Assert.True(v.ShouldBe("0.0.1"));
        }
    }
}
