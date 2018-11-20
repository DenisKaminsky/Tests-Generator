using System.Linq;
using System.IO;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestsGeneratorLib;

namespace TestsGeneratorUnitTest
{
    [TestClass]
    public class TestsGeneratorTest
    {
        private CompilationUnitSyntax _root;

        [TestInitialize]
        public void SetUp()
        {
            int readingLimit = 3, writingLimit = 3, processingLimit = 8;
            string sourceCode;
            SyntaxTree codeTree;
            List<string> pathes = new List<string>();
            TestsGeneratorConfig config;
            TestsGenerator generator;

            pathes.Add(@"D:\files\TestsGenerator.cs");
            config = new TestsGeneratorConfig(readingLimit, processingLimit, writingLimit);
            generator = new TestsGenerator(config);
            generator.Generate(pathes,"D:\\files\\Tests").Wait();

            sourceCode = File.ReadAllText("D:\\files\\Tests\\TestsGeneratorTest.cs");
            codeTree = CSharpSyntaxTree.ParseText(sourceCode);
            _root = codeTree.GetCompilationUnitRoot();
        }

        [TestMethod]
        public void UsingDeclarationsTest()
        {
            Assert.AreEqual("System", _root.Usings[0].Name.ToString());
            Assert.AreEqual("System.Collections.Generic", _root.Usings[1].Name.ToString());
            Assert.AreEqual("System.Linq", _root.Usings[2].Name.ToString());
            Assert.AreEqual("System.Text", _root.Usings[3].Name.ToString());
            Assert.AreEqual("Microsoft.VisualStudio.TestTools.UnitTesting", _root.Usings[4].Name.ToString());
            Assert.AreEqual("TestsGenerator", _root.Usings[5].Name.ToString());
        }

        [TestMethod]
        public void NamespaceDeclarationsTest()
        {
            IEnumerable<NamespaceDeclarationSyntax>  namespaces = _root.DescendantNodes().OfType<NamespaceDeclarationSyntax>();

            Assert.AreEqual(1, namespaces.Count());
            Assert.AreEqual("TestsGenerator.Tests", namespaces.ElementAt<NamespaceDeclarationSyntax>(0).Name.ToString());
        }

        [TestMethod]
        public void ClassTest()
        {
            IEnumerable<ClassDeclarationSyntax> classes = _root.DescendantNodes().OfType<ClassDeclarationSyntax>();

            Assert.AreEqual(1, classes.Count());
            Assert.AreEqual("TestsGeneratorTests", classes.ElementAt<ClassDeclarationSyntax>(0).Identifier.ToString());
        }


    }
}
