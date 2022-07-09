﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatic9045.AtsEx.PluginHost.ClassWrappers
{

    internal sealed class ClassWrapperConverter<T> : ITwoWayConverter<object, T>
    {
        public ClassWrapperConverter()
        {
        }

        public T Convert(object value)
        {
            ClassWrapperBase wrapper = ClassWrapperBase.CreateFromSource(value);
            switch (wrapper)
            {
                case null: return default;
                case T valueWrapper: return valueWrapper;
                default: throw new ArgumentException();
            }
        }

        public object ConvertBack(T value) => (value as ClassWrapperBase).Src;
    }
}