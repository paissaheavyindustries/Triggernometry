using Microsoft.CodeAnalysis.Scripting;
using System.Collections.Generic;

namespace Triggernometry.Scripting
{

    public class Script
    {

        internal string Code { get; set; } = "";

        internal Script<object> Compiled { get; set; } = null;

        internal List<string> Imports { get; set; } = new List<string>();
        internal List<string> References { get; set; } = new List<string>();

        /*Scripting.Engine ecc = new Scripting.Engine(this);
        Scripting.Script scc = new Scripting.Script() { Code = "VariableScalar v = TrigInstance.Variables.GetScalarVariable(\"jepso\", true); DateTime dt = DateTime.Now; List<int> x = new List<int>(); Math.Min(1, 2); StringBuilder sb; Directory.Exists(\"abc\"); return TrigContext;" };
        ecc.Compile(scc);
        string temp = ecc.Run(this, new Context(), scc);*/

    }

}
