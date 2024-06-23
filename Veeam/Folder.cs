using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Veeam
{
    public class Folder
    {
        public string Path { get; set; }

        public Folder(string path)
        {
            Path = path;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public List<FileInfo> GetFiles()
        {
            return new DirectoryInfo(Path).GetFiles("*.*", SearchOption.AllDirectories).ToList();
        }

        public List<FileInfo> GetModifiedFiles(DateTime date)
        {
            return new DirectoryInfo(Path).GetFiles("*.*", SearchOption.AllDirectories).Where(x => x.LastWriteTime > date).ToList();
        }

    }
}
