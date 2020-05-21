using System;
using Xunit;

namespace Ajax.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var success = JSend.Success.Create("123");
            JSend jsend = success;
            Assert.Equal("123", jsend.data);
        }
    }
}
