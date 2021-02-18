using PaymentProcessorFiled.Controllers;
using System.Reflection;
using Xunit;

namespace PaymentProcessorFiled.Test
{
    public class UnitTest1
    {
        [Fact]
        public void ItExists()
        {
            //arrange
            var paymentsController = new PaymentsController();
            //act
            MethodInfo methodInfo = paymentsController.GetType().GetMethod("ProcessPayment");
            //assert
            Assert.True(methodInfo is object);
        }
    }
}
