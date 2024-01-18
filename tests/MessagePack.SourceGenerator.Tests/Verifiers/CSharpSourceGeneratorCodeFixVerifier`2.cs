﻿// Copyright (c) All contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Testing;
using Microsoft.CodeAnalysis.Testing.Verifiers;

internal class CSharpSourceGeneratorCodeFixVerifier<TSourceGenerator, TCodeFix>
    where TCodeFix : CodeFixProvider, new()
{
    public class Test : CSharpCodeFixTest<EmptyDiagnosticAnalyzer, TCodeFix, XUnitVerifier>
    {
        public Test()
        {
            this.ReferenceAssemblies = ReferencesHelper.DefaultReferences;
            this.CompilerDiagnostics = CompilerDiagnostics.Warnings;
        }

        public LanguageVersion LanguageVersion { get; set; } = LanguageVersion.CSharp9;

        protected override CompilationOptions CreateCompilationOptions()
        {
            var compilationOptions = (CSharpCompilationOptions)base.CreateCompilationOptions();
            return compilationOptions
               .WithWarningLevel(99)
               .WithSpecificDiagnosticOptions(compilationOptions.SpecificDiagnosticOptions.SetItem("CS1591", ReportDiagnostic.Suppress));
        }

        protected override ParseOptions CreateParseOptions()
        {
            return ((CSharpParseOptions)base.CreateParseOptions()).WithLanguageVersion(this.LanguageVersion);
        }

        protected override IEnumerable<Type> GetSourceGenerators()
        {
            yield return typeof(TSourceGenerator);
        }
    }

    public static Task VerifyAnalyzerWithoutMessagePackReferenceAsync(string source)
    {
        var test = new Test { TestCode = source, ReferenceAssemblies = ReferenceAssemblies.NetFramework.Net472.Default };
        return test.RunAsync();
    }

    public static Task VerifyAnalyzerAsync(string source, params DiagnosticResult[] expected)
    {
        var test = new Test { TestCode = source };
        test.ExpectedDiagnostics.AddRange(expected);
        return test.RunAsync();
    }

    public static Task VerifyCodeFixAsync(string source, string fixedSource)
        => VerifyCodeFixAsync(source, DiagnosticResult.EmptyDiagnosticResults, fixedSource);

    public static Task VerifyCodeFixAsync(string source, DiagnosticResult expected, string fixedSource)
        => VerifyCodeFixAsync(source, new[] { expected }, fixedSource);

    public static Task VerifyCodeFixAsync(string source, DiagnosticResult[] expected, string fixedSource)
    {
        var test = new Test
        {
            TestCode = source,
            FixedCode = fixedSource,
        };

        test.ExpectedDiagnostics.AddRange(expected);
        return test.RunAsync();
    }

    public static Task VerifyCodeFixAsync(string[] source, string[] fixedSource)
    {
        var test = new Test
        {
        };

        foreach (var src in source)
        {
            test.TestState.Sources.Add(src);
        }

        foreach (var src in fixedSource)
        {
            test.FixedState.Sources.Add(src);
        }

        return test.RunAsync();
    }
}
