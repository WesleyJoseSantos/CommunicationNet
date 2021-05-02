using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communication
{
    public class JsonMsg : IJson
    {
        [JsonProperty(Order = -2)]
        public int msgId { get; set; }

        public static JsonMsg FromJson(string data)
        {
            return JsonConvert.DeserializeObject<JsonMsg>(data);
        }

        string IJson.ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
