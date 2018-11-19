using System.Collections.Generic;

namespace TestsGeneratorLib.DataStructures
{
    public class ClassInfo
    {
        private string _name;

        public List<MethodInfo> methods { get; }

        public string Name
        {
            get { return _name; }
        }

        public ClassInfo(string className, List<MethodInfo> methods)
        {
            _name = className;
            this.methods = methods;
        }
    }
}
