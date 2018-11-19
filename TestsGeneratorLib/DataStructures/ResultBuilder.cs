﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace TestsGeneratorLib.DataStructures
{
    public class ResultBuilder
    {
        public ResultStructure GetResult(string sourceCode)
        {
            SyntaxTree codeTree = CSharpSyntaxTree.ParseText(sourceCode);
            CompilationUnitSyntax root = codeTree.GetCompilationUnitRoot();
        }
    }
}
