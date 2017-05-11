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
            var arena = new Arena(new PlayerFactory());
            arena.Run();

        }
    }
}
