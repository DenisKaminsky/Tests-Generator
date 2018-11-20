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
        public List<GeneratedTest> GetTestTemplates(ParsingResultStructure parsingResult)
        {
            List<GeneratedTest> generationResult = new List<GeneratedTest>();

            foreach (ClassInfo classInfo in parsingResult.Classes)
            {
                CompilationUnitSyntax unit = CompilationUnit()
                    .WithUsings(GetUsingDeclarations(classInfo))
                    .WithMembers(SingletonList<MemberDeclarationSyntax>(GetNamespaceDeclaration(classInfo)
                        .WithMembers(SingletonList<MemberDeclarationSyntax>(ClassDeclaration(classInfo.Name + "Tests")
                            .WithAttributeLists(...)
                            .WithModifiers(TokenList(Token(SyntaxKind.PublicKeyword)))
                            .WithMembers(...)))
                        )
                     );
                    
            }
            return generationResult;
        }

        private NamespaceDeclarationSyntax GetNamespaceDeclaration(ClassInfo classInfo)
        {
            NamespaceDeclarationSyntax namespaceDeclaration = NamespaceDeclaration(QualifiedName(
                IdentifierName(classInfo.NamespaceName), IdentifierName("Tests")));

            return namespaceDeclaration;
        }

        private SyntaxList<UsingDirectiveSyntax> GetUsingDeclarations(ClassInfo classInfo)
        {
            SyntaxList<UsingDirectiveSyntax> usings = new SyntaxList<UsingDirectiveSyntax>();

            usings.Add(UsingDirective(IdentifierName("System")));
            usings.Add(UsingDirective(IdentifierName("System.Collections.Generic")));
            usings.Add(UsingDirective(IdentifierName("System.Linq")));
            usings.Add(UsingDirective(IdentifierName("System.Text")));
            usings.Add(UsingDirective(IdentifierName("Microsoft.VisualStudio.TestTools.UnitTesting")));
            usings.Add(UsingDirective(IdentifierName(classInfo.NamespaceName)));

            return usings;
        }

        private SyntaxList<MemberDeclarationSyntax> GetMembersDeclarations(ClassInfo classInfo)
        {
            SyntaxList<MemberDeclarationSyntax> methods = new SyntaxList<MemberDeclarationSyntax>();

            foreach (MethodInfo method in classInfo.Methods)
            {
                methods.Add();
            }
            return methods;
        }

        private 
    }
}
