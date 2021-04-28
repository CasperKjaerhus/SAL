﻿using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.SymbolTable
{
    class FuncCallTypeInfo : TypeInfo
    {
        //List<TypeInfo> Arguments { get; }
        public FuncCallTypeInfo(IToken type) : base(type)
        {
            //this.Arguments = arguments;
        }

        public override string ToString()
        {
            return $"Function Reference";
        }
    }
}
