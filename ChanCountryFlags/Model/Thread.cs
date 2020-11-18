using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChanCountryFlags.Model
{
    public partial class Thread
    {
        [JsonProperty("posts")]
        public Post[] Posts { get; set; }
    }

    public partial class Post
    {
        [JsonProperty("no")]
        public int No { get; set; }

        [JsonProperty("now")]
        public DateTime TimeStamp { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("sub", NullValueHandling = NullValueHandling.Ignore)]
        public string Sub { get; set; }

        [JsonProperty("com", NullValueHandling = NullValueHandling.Ignore)]
        public string Body { get; set; }

        [JsonProperty("filename", NullValueHandling = NullValueHandling.Ignore)]
        public string Filename { get; set; }

        [JsonProperty("ext", NullValueHandling = NullValueHandling.Ignore)]
        public string Ext { get; set; }

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

        [JsonProperty("country_name")]
        public string CountryName { get; set; }

        [JsonProperty("replies", NullValueHandling = NullValueHandling.Ignore)]
        public int Replies { get; set; }

        [JsonProperty("images", NullValueHandling = NullValueHandling.Ignore)]
        public int Images { get; set; }

        [JsonProperty("troll_country", NullValueHandling = NullValueHandling.Ignore)]
        public string TrollCountry { get; set; }

        [JsonProperty("trip", NullValueHandling = NullValueHandling.Ignore)]
        public string Trip { get; set; }

        [JsonProperty("filedeleted", NullValueHandling = NullValueHandling.Include)]
        public bool Filedeleted { get; set; }
    }

    internal static class ThreadConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            DateFormatString = "MM/dd/yy(ddd)HH:mm:ss",
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None
        };
    }
}
