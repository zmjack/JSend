using Newtonsoft.Json;
using System.Text.Json;
using Xunit;

namespace Ajax.Tests.Utils
{
    internal static class TestUtil
    {
        internal static void UseNewtonsoftJson(JSend jsend)
        {
            var json = JsonConvert.SerializeObject(jsend);
            var deserialized = JsonConvert.DeserializeObject<JSend>(json);
            Assert.Equal(jsend.status, deserialized.status);

            if (jsend.IsSuccess())
            {
                Assert.Equal(Any(jsend.data), Any(deserialized.data));
            }
            else if (jsend.IsFail())
            {
                Assert.Equal(Any(jsend.data), Any(deserialized.data));
            }
            else if (jsend.IsError())
            {
                Assert.Equal(jsend.code, deserialized.code);
                Assert.Equal(jsend.message, deserialized.message);
            }
        }

        internal static void UseSystemJson(JSend jsend)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(jsend);
            var deserialized = System.Text.Json.JsonSerializer.Deserialize<JSend>(json);
            Assert.Equal(jsend.status, deserialized.status);

            if (jsend.IsSuccess())
            {
                Assert.Equal(Any(jsend.data), Any(deserialized.data));
            }
            else if (jsend.IsFail())
            {
                Assert.Equal(Any(jsend.data), Any(deserialized.data));
            }
            else if (jsend.IsError())
            {
                Assert.Equal(jsend.code, deserialized.code);
                Assert.Equal(jsend.message, deserialized.message);
            }
        }

        private static object Any(object obj)
        {
            if (obj is null) return null;
            else if (obj is JsonElement jsonElement) return jsonElement.GetRawText();
            else return JsonConvert.SerializeObject(obj);
        }

    }
}
