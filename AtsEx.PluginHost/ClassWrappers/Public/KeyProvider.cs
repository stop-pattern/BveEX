﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Mackoy.Bvets;

using Automatic9045.AtsEx.PluginHost.BveTypeCollection;

namespace Automatic9045.AtsEx.PluginHost.ClassWrappers
{
    public class KeyProvider : ClassWrapperBase
    {
        [InitializeClassWrapper]
        private static void Initialize()
        {
            ClassMemberCollection members = BveTypeCollectionProvider.Instance.GetClassInfoOf<KeyProvider>();

            InputDevicesGetMethod = members.GetSourcePropertyGetterOf(nameof(InputDevices));
        }

        protected KeyProvider(object src) : base(src)
        {
        }

        /// <summary>
        /// オリジナル オブジェクトからラッパーのインスタンスを生成します。
        /// </summary>
        /// <param name="src">ラップするオリジナル オブジェクト。</param>
        /// <returns>オリジナル オブジェクトをラップした <see cref="KeyProvider"/> クラスのインスタンス。</returns>
        public static KeyProvider FromSource(object src) => src is null ? null : new KeyProvider(src);

        private static MethodInfo InputDevicesGetMethod;
        /// <summary>
        /// 読み込まれている入力デバイスプラグインを取得します。
        /// </summary>
        public Dictionary<string, IInputDevice> InputDevices => InputDevicesGetMethod.Invoke(Src, null);
    }
}
