using static PaymentProcessorFiled.Utils.ValidationUtil;
using Xunit;
using System;

namespace PaymentProcessorFiled.Test
{
    public class ValidationTest
    {
        [Fact]
        public void SecurityCodeABCFails()
        {
            //arrange
            //act
            bool  result = SecurityCodeIsNotValid("abc");
            //assert
            Assert.True(result);
        }
        [Fact]
        public void SecurityCode123Passes()
        {
            //arrange
            //act
            bool result = SecurityCodeIsNotValid("123");
            //assert
            Assert.False(result);
        }

        [Fact]
        public void CardNumber4916879990961445Passes()
        {
            //arrange
            //act
            bool result = CardNumberIsValid("4916879990961445");
            //assert
            Assert.True(result);
        }

        [Fact]
        public void CardNumber1916879990961445Fails()
        {
            //arrange
            //act
            bool result = CardNumberIsValid("1916879990961445");
            //assert
            Assert.False(result);
        }

        [Fact]
        public void CardNumberABCThrows()
        {
            //arrange
            //act
            //assert
            Assert.Throws<ArgumentException>(() => CardNumberIsValid("ABC"));
        }
    }
}
