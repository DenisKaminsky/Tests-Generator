using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsGeneratorLib.DataStructures
{
    public class ClassInfo
    {
        private string _name;

        public string Name
        {
            get { return _name; }
        }

        public ClassInfo(string className)
        {
            _name = className;
        }
    }
}
