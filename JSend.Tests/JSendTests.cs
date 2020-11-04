using Ajax.Tests.Utils;
using Xunit;

namespace Ajax.Tests
{
    public class JSendTests
    {
        [Fact]
        public void NewtonsoftTest()
        {
            TestUtil.UseNewtonsoftJson(JSend.Success());
            TestUtil.UseNewtonsoftJson(JSend.Success(new { ABC = "abc" }));
            TestUtil.UseNewtonsoftJson(JSend.Fail());
            TestUtil.UseNewtonsoftJson(JSend.Fail(new { ABC = "abc" }));
            TestUtil.UseNewtonsoftJson(JSend.Error("error message"));
            TestUtil.UseNewtonsoftJson(JSend.Error("error message", "#0"));
            TestUtil.UseNewtonsoftJson(JSend.Error("error message", "#0", new { ABC = "abc" }));
        }

        [Fact]
        public void SystemTest()
        {
            TestUtil.UseSystemJson(JSend.Success());
            TestUtil.UseSystemJson(JSend.Success(new { ABC = "abc" }));
            TestUtil.UseSystemJson(JSend.Fail());
            TestUtil.UseSystemJson(JSend.Fail(new { ABC = "abc" }));
            TestUtil.UseSystemJson(JSend.Error("error message"));
            TestUtil.UseSystemJson(JSend.Error("error message", "#0"));
            TestUtil.UseSystemJson(JSend.Error("error message", "#0", new { ABC = "abc" }));
        }

        [Fact]
        public void StatusTest()
        {
            Assert.True(JSend.Success().IsSuccess());
            Assert.False(JSend.Success().IsFail());
            Assert.False(JSend.Success().IsError());

            Assert.False(JSend.Fail().IsSuccess());
            Assert.True(JSend.Fail().IsFail());
            Assert.False(JSend.Fail().IsError());

            Assert.False(JSend.Error("").IsSuccess());
            Assert.False(JSend.Error("").IsFail());
            Assert.True(JSend.Error("").IsError());
        }

    }
}
