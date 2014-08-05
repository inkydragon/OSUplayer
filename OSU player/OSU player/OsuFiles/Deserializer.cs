﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace OSUplayer.OsuFiles
{
    static class Deserializer
    {
        private static BinaryFormatter _formatter;

        public static Object Deserialize(Stream stream)
        {
            if (_formatter == null)
            {
                _formatter = new BinaryFormatter {AssemblyFormat = FormatterAssemblyStyle.Simple};
            }
            return _formatter.Deserialize(stream);
        }

    }
}