using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NewtonSoft_Json.Converter
{
    internal class FamilyJsonConverter<T> : JsonConverter
        where T : new()
    {
        private const string ParentNodeName = "Family";

        public override bool CanConvert(Type objectType) => typeof(T) == objectType;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (JToken.ReadFrom(reader) is JToken token && token.HasValues)
            {
                var obj = token[ParentNodeName];

                return obj.ToObject<T>();
            }

            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {            
            if (JToken.FromObject(value) is JToken token)
            {
                var obj = new JObject();
                obj.Add(ParentNodeName, token);
                obj.WriteTo(writer);
            }
        }
    }
}
