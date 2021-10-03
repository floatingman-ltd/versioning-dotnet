using System;
using Floatingman.Common;

namespace Versioner
{
    public class Version
    {
public bool ShouldBe(SemVer semVer)
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;

            var v = new SemVer(version);

            return semVer == v;
        }
    }
}
