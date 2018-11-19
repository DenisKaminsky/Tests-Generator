using System;
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

            return new ResultStructure(GetClasses(root));
        }

        public List<ClassInfo> GetClasses(CompilationUnitSyntax root)
        {
            string className,namespaceName;
            List<ClassInfo> classes = new List<ClassInfo>();

            foreach (ClassDeclarationSyntax classDeclaration in root.DescendantNodes().OfType<ClassDeclarationSyntax>())
            {
                namespaceName = ((NamespaceDeclarationSyntax)classDeclaration.Parent).Name.ToString();//namespace
                className = classDeclaration.Identifier.ValueText;//имя класса

                classes.Add(new ClassInfo());
            }
            return classes;
        }
    }
}
