﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mackoy.Bvets;

namespace Automatic9045.AtsEx.PluginHost.Input.Native
{
    /// <summary>
    /// BVE が ATS プラグイン向けに提供するキーの入力情報を表します。
    /// </summary>
    public class NativeKeySet
    {
        /// <summary>
        /// ATS キーの入力情報を取得します。
        /// </summary>
        public ReadOnlyDictionary<NativeAtsKey, KeyState> AtsKeys { get; }

        /// <summary>
        /// <see cref="NativeKeySet"/> クラスの新しいインスタンスを初期化します。
        /// </summary>
        public NativeKeySet()
        {
            {
                NativeAtsKey[] allKeyNames = Enum.GetValues(typeof(NativeAtsKey)) as NativeAtsKey[];
                Dictionary<NativeAtsKey, KeyState> keys = allKeyNames.ToDictionary(keyName => keyName, _ => new KeyState());

                AtsKeys = new ReadOnlyDictionary<NativeAtsKey, KeyState>(keys);
            }
        }
    }
}