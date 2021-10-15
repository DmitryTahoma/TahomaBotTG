using System;
using System.Collections.Generic;

namespace Shell.Models.BotFunctions
{
    [Obsolete]
    internal interface IBotFunctionList : IBotFunction
    {
        IEnumerable<IBotFunction> InnerFunctions { get; }
    }
}
