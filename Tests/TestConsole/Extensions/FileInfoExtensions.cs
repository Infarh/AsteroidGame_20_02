using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole.Extensions
{
    public static class FileInfoExtensions
    {
        public static IEnumerable<string> GetLines(this FileInfo file)
        {
            using(var reader = file.OpenText())
                while (!reader.EndOfStream)
                    yield return reader.ReadLine();
        }
    }
}
