using NUnit.Framework;
using Moq;
using Services;

namespace Arena.Test
{
    [TestFixture]
    public class ArenaTest
    {
        [Test]
        public void Play100()
        {
            var generation = new Generation(new PlayerFactory());
            generation.Run();
            Assert.True(true);

        }
    }
}
