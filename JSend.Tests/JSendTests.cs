using Newtonsoft.Json;
using Xunit;

namespace Ajax.Tests
{
    public class JSendTests
    {
        public struct Model
        {
            public string ABC { get; set; }
        }

        [Fact]
        public void GeneralTest()
        {
            Test(JSend.Success());
            Test(JSend.Fail());
            Test(JSend.Error("error message"));
            Test(JSend.Error("error message", "#0"));
            Test(JSend.Success(new Model { ABC = "\"abc\"" }));
            Test(JSend.Fail(new Model { ABC = "\"abc\"" }));
            Test(JSend.Error("error message", "#0", new Model { ABC = "\"abc\"" }));
        }

        [Fact]
        public void JSendTest()
        {
            Test(JSend.Success() as JSend);
            Test(JSend.Fail() as JSend);
            Test(JSend.Error("error message") as JSend);
            Test(JSend.Error("error message", "#0") as JSend);
            Test(JSend.Success(new Model { ABC = "\"abc\"" }) as JSend);
            Test(JSend.Fail(new Model { ABC = "\"abc\"" }) as JSend);
            Test(JSend.Error("error message", "#0", new Model { ABC = "\"abc\"" }) as JSend);
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

        private void Test(JSend jsend)
        {
            var clone = JsonConvert.DeserializeObject<DeserializedJSend>(JsonConvert.SerializeObject(jsend));
            Assert.Equal(jsend.Status, clone.Status);
            Assert.Equal((jsend as IJSend).Data, clone.Data);
            Assert.Equal((jsend as IJSend).Code, clone.Code);
            Assert.Equal((jsend as IJSend).Message, clone.Message);
        }

        private void Test(JSuccess jsend)
        {
            var clone = JsonConvert.DeserializeObject<JSuccess>(JsonConvert.SerializeObject(jsend));
            Assert.Equal(jsend.Status, clone.Status);
            Assert.Equal(jsend.Data, clone.Data);
        }
        private void Test<TData>(JSuccess<TData> jsend)
        {
            var clone = JsonConvert.DeserializeObject<JSuccess<TData>>(JsonConvert.SerializeObject(jsend));
            Assert.Equal(jsend.Status, clone.Status);
            Assert.Equal(jsend.Data, clone.Data);
        }

        private void Test(JFail jsend)
        {
            var clone = JsonConvert.DeserializeObject<JFail>(JsonConvert.SerializeObject(jsend));
            Assert.Equal(jsend.Status, clone.Status);
            Assert.Equal(jsend.Data, clone.Data);
        }
        private void Test<TData>(JFail<TData> jsend)
        {
            var clone = JsonConvert.DeserializeObject<JFail<TData>>(JsonConvert.SerializeObject(jsend));
            Assert.Equal(jsend.Status, clone.Status);
            Assert.Equal(jsend.Data, clone.Data);
        }

        private void Test(JError jsend)
        {
            var clone = JsonConvert.DeserializeObject<JError>(JsonConvert.SerializeObject(jsend));
            Assert.Equal(jsend.Status, clone.Status);
            Assert.Equal(jsend.Data, clone.Data);
            Assert.Equal(jsend.Code, clone.Code);
            Assert.Equal(jsend.Message, clone.Message);
        }
        private void Test<TData>(JError<TData> jsend)
        {
            var clone = JsonConvert.DeserializeObject<JError<TData>>(JsonConvert.SerializeObject(jsend));
            Assert.Equal(jsend.Status, clone.Status);
            Assert.Equal(jsend.Data, clone.Data);
            Assert.Equal(jsend.Code, clone.Code);
            Assert.Equal(jsend.Message, clone.Message);
        }

    }
}
