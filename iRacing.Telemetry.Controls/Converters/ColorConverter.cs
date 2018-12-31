using Newtonsoft.Json;
using System;
using System.Drawing;

namespace iRacing.Telemetry.Controls.Converters
{
    public class ColorConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Color));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((Color)value).ToArgb());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return Color.FromArgb(Convert.ToInt32(reader.Value));
        }
    }
}
