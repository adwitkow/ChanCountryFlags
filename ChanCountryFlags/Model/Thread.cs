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
        public long No { get; set; }

        [JsonProperty("sticky", NullValueHandling = NullValueHandling.Ignore)]
        public long? Sticky { get; set; }

        [JsonProperty("closed", NullValueHandling = NullValueHandling.Ignore)]
        public long? Closed { get; set; }

        [JsonProperty("now")]
        public DateTime Now { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("sub", NullValueHandling = NullValueHandling.Ignore)]
        public string Sub { get; set; }

        [JsonProperty("com")]
        public string Com { get; set; }

        [JsonProperty("filename")]
        public string Filename { get; set; }

        [JsonProperty("ext")]
        public string Ext { get; set; }

        [JsonProperty("w")]
        public long W { get; set; }

        [JsonProperty("h")]
        public long H { get; set; }

        [JsonProperty("tn_w")]
        public long TnW { get; set; }

        [JsonProperty("tn_h")]
        public long TnH { get; set; }

        [JsonProperty("tim")]
        public long Tim { get; set; }

        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("md5")]
        public string Md5 { get; set; }

        [JsonProperty("fsize")]
        public long Fsize { get; set; }

        [JsonProperty("resto")]
        public long Resto { get; set; }

        [JsonProperty("capcode")]
        public string Capcode { get; set; }

        [JsonProperty("semantic_url", NullValueHandling = NullValueHandling.Ignore)]
        public string SemanticUrl { get; set; }

        [JsonProperty("replies", NullValueHandling = NullValueHandling.Ignore)]
        public long? Replies { get; set; }

        [JsonProperty("images", NullValueHandling = NullValueHandling.Ignore)]
        public long? Images { get; set; }

        [JsonProperty("unique_ips", NullValueHandling = NullValueHandling.Ignore)]
        public long? UniqueIps { get; set; }
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
