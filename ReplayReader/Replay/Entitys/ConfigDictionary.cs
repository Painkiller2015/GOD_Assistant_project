﻿using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplayReader.Replay.Data.Replay.Entitys
{
    public class ConfigDictionary<T> : ConfigBase where T : ConfigDictionary<T>, new()
    {
        public static readonly Dictionary<string, T> Dictionary;

        public static readonly List<T> List;

        private static readonly Action Clear;
    }
}
