using System.IO;

namespace CSVReader
{
    public class LogWriter
    {
        string path;

        public LogWriter(string path)
        {
            this.path = path;
        }

        public void Write(string message)
        {
            using (var writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
            }
        }
    }
}