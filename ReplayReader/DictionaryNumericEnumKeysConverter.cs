using Newtonsoft.Json;
using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace ReplayReader
{
    public class DictionaryNumericEnumKeysConverter : JsonConverter
    {
        public override bool CanRead => false; // the default converter handles numeric keys fine
        public override bool CanWrite => true;

        public override bool CanConvert(Type objectType)
        {
            return this.TryGetEnumType(objectType, out _);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            throw new NotSupportedException($"Reading isn't implemented by the {nameof(DictionaryNumericEnumKeysConverter)} converter."); // shouldn't be called since we set CanRead to false
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            // handle null
            if (value is null)
            {
                writer.WriteNull();
                return;
            }

            // get dictionary & key type
            if (value is not IDictionary dictionary || !this.TryGetEnumType(value.GetType(), out Type? enumType))
                throw new InvalidOperationException($"Can't parse value type '{value.GetType().FullName}' as a supported dictionary type."); // shouldn't be possible since we check in CanConvert
            Type enumValueType = Enum.GetUnderlyingType(enumType);

            // serialize
            writer.WriteStartObject();
            foreach (DictionaryEntry pair in dictionary)
            {
                writer.WritePropertyName(Convert.ChangeType(pair.Key, enumValueType).ToString()!);
                serializer.Serialize(writer, pair.Value);
            }
            writer.WriteEndObject();
        }

        /// <summary>Get the enum type for a dictionary's keys, if applicable.</summary>
        /// <param name="objectType">The possible dictionary type.</param>
        /// <param name="keyType">The dictionary key type.</param>
        /// <returns>Returns whether the <paramref name="objectType"/> is a supported dictionary and the <paramref name="keyType"/> was extracted.</returns>
        private bool TryGetEnumType(Type objectType, [NotNullWhen(true)] out Type? keyType)
        {
            // ignore if type can't be dictionary
            if (!objectType.IsGenericType || objectType.IsValueType)
            {
                keyType = null;
                return false;
            }

            // ignore if not a supported dictionary
            {
                Type genericType = objectType.GetGenericTypeDefinition();
                if (genericType != typeof(IDictionary<,>) && genericType != typeof(Dictionary<,>))
                {
                    keyType = null;
                    return false;
                }
            }

            // extract key type
            keyType = objectType.GetGenericArguments().First();
            if (!keyType.IsEnum)
                keyType = null;

            return keyType != null;
        }
    }
}
