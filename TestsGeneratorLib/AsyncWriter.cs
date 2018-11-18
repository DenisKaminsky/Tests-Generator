using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace TestsGeneratorLib
{
    public static class AsyncWriter
    {
        public static async Task Write(string destination)
        {
            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
            }
            destination += "\\";//obj
            using (StreamWriter writer = new StreamWriter(destination))
            {
                await writer.WriteAsync();//object
            }
        }
    }
}
