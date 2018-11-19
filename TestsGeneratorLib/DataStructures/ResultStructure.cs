using System.Collections.Generic;

namespace TestsGeneratorLib.DataStructures
{    
    public class ResultStructure
    {
        public List<ClassInfo> classes { get; }

        public ResultStructure(List<ClassInfo> classes)
        {
            this.classes = classes;
        }
    }
}
