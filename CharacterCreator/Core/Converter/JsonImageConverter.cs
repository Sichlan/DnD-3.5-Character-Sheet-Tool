﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator.Core.Converter
{
    public class JsonImageConverter : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var base64 = (string)reader.Value;

            if (base64 == null)
                return null;

            // convert base64 to byte array, put that into memory stream and feed to image
            return Image.FromStream(new MemoryStream(Convert.FromBase64String(base64)));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var image = (Image)value;
            // save to memory stream in original format
            using (var ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                byte[] imageBytes = ms.ToArray();
                // write byte array, will be converted to base64 by JSON.NET
                writer.WriteValue(imageBytes);
            }
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Image);
        }
    }
}
