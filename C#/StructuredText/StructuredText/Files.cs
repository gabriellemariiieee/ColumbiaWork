using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuredText
{
    public class Files : IStructuredFile
    {
        public string Path { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public string Delimiter { get; set; }

        public Files(string path, string filename, string extension, string delimiter)
        {
            Path = path;
            FileName = filename;
            Extension = extension;
            Delimiter = delimiter;
        }
    }
}
