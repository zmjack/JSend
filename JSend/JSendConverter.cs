using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ajax
{
    public class JSendConverter : JsonConverter<JSend<object>>
    {
        public override JSend<object> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return JsonSerializer.Deserialize(ref reader, typeToConvert, options) as JSend<object>;
        }

        public override void Write(Utf8JsonWriter writer, JSend<object> value, JsonSerializerOptions options)
        {
            var type = value.GetType();
            JsonSerializer.Serialize(writer, value, type, options);
        }
    }
}
