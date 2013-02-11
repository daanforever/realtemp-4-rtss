using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RealTemp4RTSS
{
    public static class GenericExtensions
    {
        /// <summary>
        /// Gets the descriptive text associated with an enumerated value, if any, or the name of the value otherwise.
        /// </summary>
        /// <remarks>
        /// This method uses the text from the Description attribute (if present) but will fall back to using
        /// the name of the enumerated value if there is no Description provided for a given enumerated value.
        /// </remarks>
        /// <param name="value">An enumerated value</param>
        /// <returns>A textual description of the enum value</returns>
        public static string GetDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return value.ToString();
            }
        }

        /// <summary>
        /// Allows you to load an Assembly which has been embedded in to another assembly as a resource.
        /// </summary>
        /// <remarks>
        /// This method is based on the code from:
        /// http://blogs.msdn.com/b/microsoft_press/archive/2010/02/03/jeffrey-richter-excerpt-2-from-clr-via-c-third-edition.aspx
        /// </remarks>
        /// <param name="resourceEmbeddedIn">An Assembly which contains an embedded Assembly</param>
        /// <param name="embeddedAssemblyName">The name of the embedded assembly, as returned by AssemblyName</param>
        /// <returns>The embedded Assembly or null if it could not find or load the specified Assembly</returns>
        public static Assembly LoadEmbeddedAssembly(this Assembly resourceEmbeddedIn, string embeddedAssemblyName)
        {
            // Because we don't specifically know the whereabouts of the embedded assembly when it was compiled
            // it's resource name may contain path information that we don't know and hence the only way to find
            // it is look for a pattern which starts with the current assembly's name and ends with the embedded
            // assembly's name and ".dll"... this does of course mean we could get it wrong but it's that or
            // force the caller to supply additional path information (if any) and this seems more user-friendly,
            // albeit at the cost of flexibility.
            string prefix = resourceEmbeddedIn.GetName().Name;
            string suffix = new AssemblyName(embeddedAssemblyName).Name + ".dll";
            string fullyResolvedName = (from rn in resourceEmbeddedIn.GetManifestResourceNames()
                                        where rn.StartsWith(prefix) && rn.EndsWith(suffix)
                                        select rn).FirstOrDefault();
            
            if (fullyResolvedName != null)
            {
                using (var resourceStream = resourceEmbeddedIn.GetManifestResourceStream(fullyResolvedName))
                {
                    if (resourceStream != null)
                    {
                        byte[] assemblyBytes = new byte[resourceStream.Length];
                        resourceStream.Read(assemblyBytes, 0, assemblyBytes.Length);

                        return Assembly.Load(assemblyBytes);
                    }
                }
            }
            return null;
        }
    }
}
