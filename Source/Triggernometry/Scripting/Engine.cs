using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System.Reflection;

namespace Triggernometry.Scripting
{

    public class Engine
    {

        public class Globals
        {

            public RealPlugin TrigInstance { get; set; }
            public Context TrigContext { get; set; }

        }

        private ScriptOptions sop { get; set; } = null;

        internal Engine(RealPlugin rp)
        {
            var pi = typeof(RealPlugin).Assembly.GetType().GetMethod("GetRawBytes", BindingFlags.Instance | BindingFlags.NonPublic);
            byte[] b = (byte[])pi.Invoke(typeof(RealPlugin).Assembly, null);
            var mref = MetadataReference.CreateFromImage(b);
            sop = ScriptOptions.Default.AddReferences(mref).AddReferences(new string[]
            {
                "System.Text.RegularExpressions",
            }).AddImports(new string[]
            {
                "System", "System.Text", "System.IO", "System.Text.RegularExpressions", "System.Collections.Generic", "Triggernometry.VariableTypes"
            });
        }

        internal void Compile(Script scp)
        {
            ScriptOptions mysop = sop;
            if (scp.Imports.Count > 0)
            {
                mysop = mysop.WithImports(scp.Imports);
            }
            if (scp.References.Count > 0)
            {
                mysop = mysop.WithReferences(scp.References);
            }
            scp.Compiled = CSharpScript.Create(scp.Code, mysop, typeof(Globals));
        }

        internal string Run(RealPlugin rp, Context ctx, string scp)
        {
            Globals globs = new Globals() { TrigInstance = rp, TrigContext = ctx };
            var result = CSharpScript.RunAsync(scp, sop, globs, typeof(Globals)).Result;
            object rob = result.ReturnValue;
            return rob != null ? rob.ToString() : "";
        }

        internal string Run(RealPlugin rp, Context ctx, Script scp)
        {
            if (scp.Compiled != null)
            {
                Globals globs = new Globals() { TrigInstance = rp, TrigContext = ctx };
                var result = scp.Compiled.RunAsync(globs).Result;
                object rob = result.ReturnValue;
                return rob != null ? rob.ToString() : "";
            }
            else
            {
                return Run(rp, ctx, scp.Code);
            }
        }

    }

}
