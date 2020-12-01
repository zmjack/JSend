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
            var deserialized = JsonConvert.DeserializeObject<DeserializedJSend>(json);
            Assert.Equal(jsend.status, deserialized.status);
            Assert.Equal(Any((jsend as IJSend).data), Any(deserialized.data));
            Assert.Equal((jsend as IJSend).code, deserialized.code);
            Assert.Equal((jsend as IJSend).message, deserialized.message);
        }

        internal static void UseSystemJson(JSend jsend)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(jsend);
            var deserialized = System.Text.Json.JsonSerializer.Deserialize<DeserializedJSend>(json);
            Assert.Equal(jsend.status, deserialized.status);
            Assert.Equal(Any((jsend as IJSend).data), Any(deserialized.data));
            Assert.Equal((jsend as IJSend).code, deserialized.code);
            Assert.Equal((jsend as IJSend).message, deserialized.message);
        }

        private static object Any(object obj)
        {
            if (obj is null) return null;
            else if (obj is JsonElement jsonElement) return jsonElement.GetRawText();
            else return JsonConvert.SerializeObject(obj);
        }

    }
}
