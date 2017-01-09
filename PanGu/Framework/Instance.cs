using System;
using System.Reflection;

namespace PanGu.Framework
{
    public class Instance
    {
        static public object CreateInstance(string typeName)
        {
            object obj = null;
            obj = Assembly.GetCallingAssembly().CreateInstance(typeName);

            if (obj != null)
            {
                return obj;
            }

            foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                obj = asm.CreateInstance(typeName);

                if (obj != null)
                {
                    return obj;
                }
            }

            return null;

        }

        static public object CreateInstance(Type type)
        {
            return type.Assembly.CreateInstance(type.FullName);

        }

        static public object CreateInstance(Type type, string assemblyFile)
        {
            Assembly asm;

            asm = Assembly.LoadFrom(assemblyFile);

            return asm.CreateInstance(type.FullName);
        }

        static public Type GetType(string assemblyFile, string typeName)
        {
            Assembly asm;

            asm = Assembly.LoadFrom(assemblyFile);

            return asm.GetType(typeName);
        }

    }

}
