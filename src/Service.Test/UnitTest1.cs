using System;
using Xunit;
using NSubstitute;
using NSubstitute.Core;
 

namespace Service.Test
{
    
    
    public class Class1
    {
        [Fact]
        public void PassingTest()
        {
            Assert.Equal(4, Add(2, 2));
        }




        int Add(int x, int y)
        {
            return x + y;
        }

        [Fact]
        public void NSubstituteTest()
        {
            var calculator = Substitute.For<ICalculator>();
            calculator.Add(1, 2).Returns(3);
            Assert.Equal(3, calculator.Add(1, 2) );
        }
    }


    public interface ICalculator
    {
        int Add(int a, int b);
        string Mode { get; set; }
        event EventHandler PoweringUp;
    }


}
