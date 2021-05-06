using System.Collections.Generic;

namespace SALShell.Parser
{
    static class SALType
    {
        public static readonly Dictionary<string, SALTypeEnum> Types = new Dictionary<string, SALTypeEnum>()
        {
            {"bool", SALTypeEnum.@bool},
            {"number", SALTypeEnum.number},
            {"char", SALTypeEnum.@char},
            {"string", SALTypeEnum.@string},
            {"void", SALTypeEnum.@void},
            {"error", SALTypeEnum.error}
        };
    }
}
