using System;
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
        private ParsingResultStructure _parsingResult;

        public TestTemplateGenerator(ParsingResultStructure parsingResult)
        {
            _parsingResult = parsingResult;
        }

        public void GetTestTemplates()
        {

        }
    }
}
