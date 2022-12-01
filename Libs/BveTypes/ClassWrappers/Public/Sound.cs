﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using TypeWrapping;

namespace BveTypes.ClassWrappers
{
    /// <summary>
    /// サウンドを表します。
    /// </summary>
    public class Sound : ClassWrapperBase
    {
        [InitializeClassWrapper]
        private static void Initialize(BveTypeSet bveTypes)
        {
            ClassMemberSet members = bveTypes.GetClassInfoOf<Sound>();
        }

        /// <summary>
        /// オリジナル オブジェクトから <see cref="Sound"/> クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="src">ラップするオリジナル オブジェクト。</param>
        protected Sound(object src) : base(src)
        {
        }

        /// <summary>
        /// オリジナル オブジェクトからラッパーのインスタンスを生成します。
        /// </summary>
        /// <param name="src">ラップするオリジナル オブジェクト。</param>
        /// <returns>オリジナル オブジェクトをラップした <see cref="Sound"/> クラスのインスタンス。</returns>
        [CreateClassWrapperFromSource]
        public static Sound FromSource(object src) => src is null ? null : new Sound(src);
    }
}