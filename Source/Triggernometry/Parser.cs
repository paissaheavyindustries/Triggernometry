using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Triggernometry
{

    internal class Parser
    {

        private JsonSerializerOptions opts;

        private class ObjectConverter : JsonConverter<object>
        {

            public override object Read(ref Utf8JsonReader reader, Type type, JsonSerializerOptions options)
            {
                switch (reader.TokenType)
                {
                    case JsonTokenType.Null:
                        return null;
                    case JsonTokenType.True:
                        return true;
                    case JsonTokenType.False:
                        return false;
                    case JsonTokenType.String:
                        return reader.GetString();
                    case JsonTokenType.Number:
                        return reader.GetDecimal();
                }
                var converter = options.GetConverter(typeof(JsonElement)) as JsonConverter<JsonElement>;
                if (converter != null)
                {
                    return converter.Read(ref reader, type, options);
                }
                throw new JsonException();
            }


            public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
            {
                throw new InvalidOperationException();
            }

        }

        public Parser()
        {
            opts = new JsonSerializerOptions();
            opts.Converters.Add(new ObjectConverter());
        }

        private void FixComplexTypes(Dictionary<string, object> o)
        {
            List<string> keys = new List<string>(o.Keys);
            foreach (string key in keys)
            {
                if (o[key] is JsonElement)
                {
                    JsonElement ele = (JsonElement)o[key];
                    if (ele.ValueKind == JsonValueKind.Object)
                    {
                        o[key] = FixObject(ele);
                    }
                    if (ele.ValueKind == JsonValueKind.Array)
                    {
                        o[key] = FixArray(ele);
                    }
                }
            }
        }

        private Dictionary<string, object> FixObject(JsonElement ele)
        {
            Dictionary<string, object> ox = JsonSerializer.Deserialize<Dictionary<string, object>>(ele.ToString(), opts);
            FixComplexTypes(ox);
            return ox;
        }

        private List<object> FixArray(JsonElement ele)
        {
            List<object> ox = new List<object>();
            foreach (var ex in ele.EnumerateArray())
            {
                switch (ex.ValueKind)
                {
                    case JsonValueKind.Null:
                        ox.Add(null);
                        break;
                    case JsonValueKind.True:
                        ox.Add(true);
                        break;
                    case JsonValueKind.False:
                        ox.Add(false);
                        break;
                    case JsonValueKind.String:
                        ox.Add(ex.GetString());
                        break;
                    case JsonValueKind.Number:
                        ox.Add(ex.GetDecimal());
                        break;
                    case JsonValueKind.Object:
                        ox.Add(FixObject(ex));
                        break;
                    case JsonValueKind.Array:
                        ox.Add(FixArray(ex));
                        break;
                }
            }
            return ox;
        }

        public Dictionary<string, object> Parse(string json)
        {
            Dictionary<string, object> o = JsonSerializer.Deserialize<Dictionary<string, object>>(json, opts);
            FixComplexTypes(o);
            return o;
        }

    }

}
