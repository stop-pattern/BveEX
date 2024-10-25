﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BveEx.Launcher
{
    /// <summary>
    /// BveEX Caller の互換性バージョンを取得します。
    /// </summary>
    public class CallerCompatibilityVersionAttribute : Attribute
    {
        public int Version { get; }

        public CallerCompatibilityVersionAttribute(int version)
        {
            Version = version;
        }
    }
}
