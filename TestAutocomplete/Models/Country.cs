﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAutocomplete.Models
{
    public class Country
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
