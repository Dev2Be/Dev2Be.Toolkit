using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dev2Be.Toolkit
{
    /// <summary>
    /// Récuperer l'ensemble des informations comprise dans l'assembly d'une application.
    /// </summary>
    public class AssemblyInformations
    {
        private string assemblyFullName;

        public static int StackTraceLevel { get; set; }

        public string Company { get { return GetCallingAssemblyAttribute<AssemblyCompanyAttribute>(a => a.Company); } }
        public string Product { get { return GetCallingAssemblyAttribute<AssemblyProductAttribute>(a => a.Product); } }
        public string Copyright { get { return GetCallingAssemblyAttribute<AssemblyCopyrightAttribute>(a => a.Copyright); } }
        public string Trademark { get { return GetCallingAssemblyAttribute<AssemblyTrademarkAttribute>(a => a.Trademark); } }
        public string Title { get { return GetCallingAssemblyAttribute<AssemblyTitleAttribute>(a => a.Title); } }
        public string Description { get { return GetCallingAssemblyAttribute<AssemblyDescriptionAttribute>(a => a.Description); } }
        public string Configuration { get { return GetCallingAssemblyAttribute<AssemblyDescriptionAttribute>(a => a.Description); } }
        public string FileVersion { get { return GetCallingAssemblyAttribute<AssemblyFileVersionAttribute>(a => a.Version); } }
        public string InformationalVersion { get { return GetCallingAssemblyAttribute<AssemblyInformationalVersionAttribute>(a => a.InformationalVersion); } }
        public static Version Version { get { return GetAssembly(StackTraceLevel) == null ? new Version() : GetAssembly(StackTraceLevel).GetName().Version; } }
        public string VersionFull { get { return Version.ToString(); } }
        public string VersionMajor { get { return Version.Major.ToString(); } }
        public string VersionMinor { get { return Version.Minor.ToString(); } }
        public string VersionBuild { get { return Version.Build.ToString(); } }
        public string VersionRevision { get { return Version.Revision.ToString(); } }

        public AssemblyInformations(string assemblyFullName)
        {
            if (string.IsNullOrEmpty(assemblyFullName)) throw new NullReferenceException(assemblyFullName);

            this.assemblyFullName = assemblyFullName;
        }

        private static Assembly GetAssembly(int stackTraceLevel)
        {
            StackTrace stackTrace = new StackTrace();
            StackFrame[] stackFrames = stackTrace.GetFrames();

            if (stackFrames == null) return null;

            var declaringType = stackFrames[stackTraceLevel].GetMethod().DeclaringType;

            if (declaringType == null) return null;

            return declaringType.Assembly;
        }

        protected string GetCallingAssemblyAttribute<T>(Func<T, string> value) where T : Attribute => value.Invoke((T)Attribute.GetCustomAttribute(Assembly.Load(assemblyFullName), typeof(T)));
    }
}
