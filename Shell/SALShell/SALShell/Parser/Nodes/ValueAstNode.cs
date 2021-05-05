using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.Parser
{
    class ValueAstNode : ExprAstNode
    {
        public SALType Type { get; set; }
        public ValueAstNode(IToken value) : base(value)
        {
            string EBNFType = p4Lexer.DefaultVocabulary.GetSymbolicName(value.Type);
            switch (EBNFType.ToLower())
            {
                case "string":
                    Type = SALType.@string;
                    break;
                case "number":
                    Type = SALType.number;
                    break;
                case "true":
                case "false":
                    Type = SALType.@bool;
                    break;
                case "char":
                    Type = SALType.@char;
                    break;
                case "void":
                    Type = SALType.@void;
                    break;
                default:
                    Type = SALType.error;
                    break;
            }
            
        }
    }
}
