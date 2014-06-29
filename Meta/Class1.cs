using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Framework.Runtime;

namespace Meta
{
    public class Processor : IMetaProcessor
    {
        public Processor() { }

        public CSharpCompilation Process(CSharpCompilation compilation)
        {
            Console.WriteLine("Did it works?");
            var trees = compilation.SyntaxTrees;
            foreach(var st in trees)
            {
                var rewriter = new RewriteHelloWorld();
                var newRoot = rewriter.Visit(st.GetRoot());
                compilation = compilation.ReplaceSyntaxTree(st, st.WithRootAndOptions(newRoot, st.Options));
            }

            return compilation;
        }
    }

    public class RewriteHelloWorld : CSharpSyntaxRewriter
    {
        public override SyntaxNode VisitParameter(ParameterSyntax node)
        {
            return base.VisitParameter(node);
        }
    }
}
