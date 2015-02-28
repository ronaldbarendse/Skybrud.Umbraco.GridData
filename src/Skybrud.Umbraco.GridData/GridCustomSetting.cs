﻿using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Umbraco.GridData.ExtensionMethods;

namespace Skybrud.Umbraco.GridData
{
    using System.Collections.Generic;

    public class GridCustomSetting
    {
        public static Dictionary<string, string> Parse(JObject obj)
        {
            JObject cfg = obj.GetObject("config");
            
            var settings = new Dictionary<string, string>();
            
            if (cfg != null)
            {
                foreach (JProperty property in cfg.Properties())
                {
                    settings.Add(property.Name, property.Value.ToString());
                }
            }

            return settings;
        }
    }
}