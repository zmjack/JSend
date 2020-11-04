using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NStandard;
using System.Collections.Generic;
using System.Reflection;
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
            Assert.Equal(jsend.Status, deserialized.Status);
            Assert.Equal(Any((jsend as IJSend).Data), Any(deserialized.Data));
            Assert.Equal((jsend as IJSend).Code, deserialized.Code);
            Assert.Equal((jsend as IJSend).Message, deserialized.Message);
        }

        internal static void UseSystemJson(JSend jsend)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(jsend);
            var deserialized = System.Text.Json.JsonSerializer.Deserialize<DeserializedJSend>(json);
            Assert.Equal(jsend.Status, deserialized.Status);
            Assert.Equal(Any((jsend as IJSend).Data), Any(deserialized.Data));
            Assert.Equal((jsend as IJSend).Code, deserialized.Code);
            Assert.Equal((jsend as IJSend).Message, deserialized.Message);
        }

        private static object Any(object obj)
        {
            if (obj is null) return null;
            else if (obj is JsonElement jsonElement) return jsonElement.GetRawText();
            else return JsonConvert.SerializeObject(obj);
        }

    }
}
