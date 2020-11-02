using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Globalization;

namespace ChanCountryFlags.Model
{
    public partial class CatalogPage
    {
        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("threads")]
        public Thread[] Threads { get; set; }
    }

    public partial class Thread
    {
        [JsonProperty("no")]
        public int No { get; set; }

        [JsonProperty("sticky", NullValueHandling = NullValueHandling.Include)]
        public bool Sticky { get; set; }

        [JsonProperty("closed", NullValueHandling = NullValueHandling.Include)]
        public bool Closed { get; set; }

        [JsonProperty("now")]
        public DateTime TimeStamp { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("sub", NullValueHandling = NullValueHandling.Ignore)]
        public string Subject { get; set; }

        [JsonProperty("com", NullValueHandling = NullValueHandling.Ignore)]
        public string Body { get; set; }

        [JsonProperty("filename", NullValueHandling = NullValueHandling.Ignore)]
        public string Filename { get; set; }

        [JsonProperty("ext", NullValueHandling = NullValueHandling.Ignore)]
        public Ext? Ext { get; set; }

        [JsonProperty("w", NullValueHandling = NullValueHandling.Ignore)]
        public int? Width { get; set; }

        [JsonProperty("h", NullValueHandling = NullValueHandling.Ignore)]
        public int? Height { get; set; }

        [JsonProperty("tn_w", NullValueHandling = NullValueHandling.Ignore)]
        public int? ThumbnailWidth { get; set; }

        [JsonProperty("tn_h", NullValueHandling = NullValueHandling.Ignore)]
        public int? ThumbnailHeight { get; set; }

        [JsonProperty("time")]
        public string UnixTime { get; set; }

        [JsonProperty("fsize", NullValueHandling = NullValueHandling.Ignore)]
        public int? FileSize { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; }

        [JsonProperty("country_name", NullValueHandling = NullValueHandling.Ignore)]
        public string CountryName { get; set; }

        [JsonProperty("replies")]
        public int Replies { get; set; }

        [JsonProperty("images")]
        public int Images { get; set; }

        [JsonProperty("last_modified")]
        public long LastModified { get; set; }

        [JsonProperty("capcode", NullValueHandling = NullValueHandling.Ignore)]
        public string Capcode { get; set; }

        [JsonProperty("troll_country", NullValueHandling = NullValueHandling.Ignore)]
        public string TrollCountry { get; set; }

        [JsonProperty("trip", NullValueHandling = NullValueHandling.Ignore)]
        public string Trip { get; set; }

        [JsonProperty("filedeleted", NullValueHandling = NullValueHandling.Include)]
        public bool Filedeleted { get; set; }
    }

    public enum Ext { Gif, Jpg, Png, Webm };

    internal static class CatalogConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            DateFormatString = "MM/dd/yy(ddd)HH:mm:ss",
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = { ExtConverter.Singleton },
        };
    }

    internal class ExtConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Ext) || t == typeof(Ext?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case ".gif":
                    return Ext.Gif;
                case ".jpg":
                    return Ext.Jpg;
                case ".png":
                    return Ext.Png;
                case ".webm":
                    return Ext.Webm;
            }
            throw new Exception("Cannot unmarshal type Ext");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Ext)untypedValue;
            switch (value)
            {
                case Ext.Gif:
                    serializer.Serialize(writer, ".gif");
                    return;
                case Ext.Jpg:
                    serializer.Serialize(writer, ".jpg");
                    return;
                case Ext.Png:
                    serializer.Serialize(writer, ".png");
                    return;
                case Ext.Webm:
                    serializer.Serialize(writer, ".webm");
                    return;
            }
            throw new Exception("Cannot marshal type Ext");
        }

        public static readonly ExtConverter Singleton = new ExtConverter();
    }
}
