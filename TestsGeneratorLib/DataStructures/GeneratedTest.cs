namespace TestsGeneratorLib.DataStructures
{
    public class GeneratedTest
    {
        private string _name;
        private string _content;

        public string Name
        {
            get { return _name; }
        }

        public string Content
        {
            get { return _content; }
        }

        public GeneratedTest(string name,string content)
        {
            _name = name;
            _content = content;
        }
    }
}
