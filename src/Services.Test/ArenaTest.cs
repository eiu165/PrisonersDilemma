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
            Assert.True(false);
            var generation = new Generation(new PlayerFactory());
            generation.Run();

        }
    }


    [TestFixture]
    public class ColorServiceTest
    {
        [Test]
        public void ColorLoopTest()
        { 
            //arrange
            var colorService = new ColorService( );

            //act
            var result = colorService.ColorLoop();

            //assert
            Assert.AreEqual("", result);

        }
    }


}
