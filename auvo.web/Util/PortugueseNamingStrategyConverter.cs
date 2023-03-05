using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace auvo.web.Util
{
    public class PortugueseNamingStrategyConverter : JsonConverter
    {
        private readonly NamingStrategy _namingStrategy;

        public PortugueseNamingStrategyConverter(NamingStrategy namingStrategy)
        {
            _namingStrategy = namingStrategy;
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var contract = serializer.ContractResolver.ResolveContract(value.GetType()) as JsonObjectContract;
            if (contract == null)
            {
                throw new InvalidOperationException("Invalid contract type: " + value.GetType());
            }

            writer.WriteStartObject();

            foreach (var property in contract.Properties)
            {
                writer.WritePropertyName(_namingStrategy.GetPropertyName(property.PropertyName, false));
                serializer.Serialize(writer, property.ValueProvider.GetValue(value));
            }

            writer.WriteEndObject();
        }
    }
}
