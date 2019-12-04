using OrderWritenew.Models;
using System;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            CustomerName C1 = new CustomerName("elam", "sk", "hyderabad");
            CustomerName C2 = new CustomerName("elam", "sk", "hyderabad");
            Assert.Equal(C1, C2);
        }
    }
}
