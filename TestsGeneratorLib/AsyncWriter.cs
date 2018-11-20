using System.IO;
using System.Threading.Tasks;
using TestsGeneratorLib.DataStructures;

namespace TestsGeneratorLib
{
    public static class AsyncWriter
    {
        public static async Task Write(string destination,GeneratedTest generatedTest)
        {
            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
            }
            destination += ("\\" + generatedTest.Name);
            using (StreamWriter writer = new StreamWriter(destination))
            {
                await writer.WriteAsync(generatedTest.Content);
            }
        }
    }
}
