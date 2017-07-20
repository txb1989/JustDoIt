
using Microsoft.VisualStudio.TextTemplating.VSHost;

namespace JstVisxCodeGenerator
{
    [ProvideCodeGenerator(typeof(JstCodeGenerator),
        "JstCodeGenerator",
        "Generates C# Code", true,
        ProjectSystem = ProvideCodeGeneratorAttribute.CSharpProjectGuid,
        RegisterCodeBase = true)]
    internal sealed partial class JstCodeGeneratorPackage
    {
        
    }
}
