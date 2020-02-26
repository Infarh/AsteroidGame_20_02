using System;

namespace TestConsole
{
    interface ICloneable<T> : ICloneable
    {
        T CloneObject();
    }
}
