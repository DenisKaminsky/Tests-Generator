﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using TestsGeneratorLib.DataStructures;

namespace TestsGeneratorLib
{
    public class TestTemplateGenerator
    {
        public List<GeneratedTest> GetTestTemplates(ParsingResultStructure parsingResult)
        {
            List<GeneratedTest> generationResult = new List<GeneratedTest>();

            foreach (ClassInfo classInfo in parsingResult.Classes)
            {

            }
            return generationResult;
        }
    }
}
