using System;
using System.Collections.Generic;

namespace Shell.Models.BotFunctions
{
    [Obsolete]
    internal abstract class BaseBotFunctionList : BaseBotFunction, IBotFunctionList
    {
        protected List<IBotFunction> innerFunctions;

        public BaseBotFunctionList(params IBotFunction[] botFunction)
        {
            innerFunctions = new List<IBotFunction>();
            if(botFunction != null && botFunction.Length > 0)
            {
                innerFunctions.AddRange(botFunction);
            }
        }

        public IEnumerable<IBotFunction> InnerFunctions => innerFunctions;
    }
}
