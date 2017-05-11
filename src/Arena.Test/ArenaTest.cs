using NUnit.Framework;
using Moq; 

namespace Arena.Test
{
    [TestFixture]
    public class ArenaTest
    {
        [Test]
        public void Play100()
        {
            Assert.True(false);
            var generation = new Generation(new PlayerFactory());
            generation.Run();

        }
    }
}
