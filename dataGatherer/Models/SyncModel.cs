using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dataGatherer.Models
{
    public class SyncModel
    {
        public IList<JToken> Items { get; set; }
        public int Count { get; set; }
    }
}
