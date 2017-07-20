using Microsoft.VisualStudio.TextTemplating.VSHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JstVisxCodeGenerator
{
    [System.Runtime.InteropServices.Guid("EA25D74C-E0F6-4BD7-9349-48A117A234A4")]
    public class JstCodeGenerator: TemplatedCodeGenerator
    {
        protected override byte[] GenerateCode(string inputFileName, string inputFileContent)
        {
            return base.GenerateCode(inputFileName, inputFileContent);
        }
    }
}
