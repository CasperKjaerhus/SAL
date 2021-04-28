using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.SymbolTable
{
    class ExprListTypeInfo : TypeInfo
    {
        public ExprListTypeInfo(List<TypeInfo> values): base(null)
        {
            Values = values;
        }

        List<TypeInfo> Values { get; }

        public override string ToString()
        {
            string returnString = "";
            foreach (TypeInfo value in Values)
            {
                returnString += value + " ";
            }

            return returnString;
        }
    }
}
