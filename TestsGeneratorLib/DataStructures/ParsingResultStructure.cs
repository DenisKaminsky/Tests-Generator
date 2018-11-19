using System.Collections.Generic;

namespace TestsGeneratorLib.DataStructures
{    
    public class ParsingResultStructure
    {
        public List<ClassInfo> classes { get; }

        public ParsingResultStructure(List<ClassInfo> classes)
        {
            this.classes = classes;
        }
    }
}
