using SALShell.Parser;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.CodeGen
{
    class CodeFormatter
    {
        public void ConvertTypes(ASTNode node)
        {
            switch (node)
            {
                case DeclareAstNode DclNode:
                    break;
                case AssignAstNode AsmntNode:
                    break;
                default:
                    break;
            }

            foreach (ASTNode child in node.Children)
            {
                ConvertTypes(node);
            }
        }

    }
}
