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

        [Fact]
        public void ToStringTest()
        {
            var error = JSend.Error.Create("error message", "#0", new { ABC = "\"abc\"" });
            Assert.Equal("{ \"status\": \"error\", \"data\": \"{ ABC = \\\"abc\\\" }\", \"code\": \"#0\", \"message\": \"error message\" }", error.ToString());

            var success = JSend.Success.Create(new { ABC = "\"abc\"" });
            Assert.Equal("{ \"status\": \"success\", \"data\": \"{ ABC = \\\"abc\\\" }\" }", success.ToString());

            var fail = JSend.Fail.Create(new { ABC = "\"abc\"" });
            Assert.Equal("{ \"status\": \"fail\", \"data\": \"{ ABC = \\\"abc\\\" }\" }", fail.ToString());
        }

    }
}
