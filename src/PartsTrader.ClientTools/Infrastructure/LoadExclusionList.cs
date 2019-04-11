using System;
using System.Collections.Generic;
using System.IO;
using PartsTrader.ClientTools.Api.Entities;
using Newtonsoft.Json;

namespace PartsTrader.ClientTools.Infrastructure
{
    static class LoadExclusionList
    {
        public static List<PartSummary> LoadJson()
        {
            using (StreamReader r = new StreamReader(@".\Exclusions.json"))
            {
                string json = r.ReadToEnd();
                List<PartSummary> items = JsonConvert.DeserializeObject<List<PartSummary>>(json);
                return items;
            }
        }
    }
}
