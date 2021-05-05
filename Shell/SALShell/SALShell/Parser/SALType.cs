using System.Collections.Generic;

namespace SALShell.Parser
{
    static class SALType
    {
        public static readonly Dictionary<SALTypeEnum, string> Types = new Dictionary<SALTypeEnum, string>()
        {
            {SALTypeEnum.@bool, "bool"},
            {SALTypeEnum.number, "number"},
            {SALTypeEnum.@char, "char"},
            {SALTypeEnum.@string, "string"},
            {SALTypeEnum.@void, "void"},
            {SALTypeEnum.error, "error"},
        };
    }
}
