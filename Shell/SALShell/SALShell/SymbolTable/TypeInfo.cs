using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;
using SALShell.Parser;

namespace SALShell.SymbolTable
{
    public abstract class TypeInfo
    {
        public SALTypeEnum Type { get; }

        public TypeInfo(IToken type)
        {
            Type = ResolveType(type);
        }


        private SALTypeEnum ResolveType(IToken type)
        {
            SALTypeEnum returnType;
            switch (type?.Text.ToLower())
            {
                case "string":
                    returnType = SALTypeEnum.@string;
                    break;
                case "number":
                    returnType = SALTypeEnum.number;
                    break;
                case "true":
                case "false":
                    returnType = SALTypeEnum.@bool;
                    break;
                case "char":
                    returnType = SALTypeEnum.@char;
                    break;
                case "void":
                    returnType = SALTypeEnum.@void;
                    break;
                default:
                    returnType = SALTypeEnum.error;
                    break;
            }

            return returnType;
        }

    }
}
