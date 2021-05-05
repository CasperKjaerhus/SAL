using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.Parser
{
    class ValueAstNode : ExprAstNode
    {
        public SALTypeEnum Type { get; set; }
        public ValueAstNode(IToken value) : base(value)
        {
            string EBNFType = p4Lexer.DefaultVocabulary.GetSymbolicName(value.Type);
            switch (EBNFType.ToLower())
            {
                case "string":
                    Type = SALTypeEnum.@string;
                    break;
                case "number":
                    Type = SALTypeEnum.number;
                    break;
                case "true":
                case "false":
                    Type = SALTypeEnum.@bool;
                    break;
                case "char":
                    Type = SALTypeEnum.@char;
                    break;
                case "void":
                    Type = SALTypeEnum.@void;
                    break;
                default:
                    Type = SALTypeEnum.error;
                    break;
            }
            
        }
    }
}
