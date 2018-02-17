using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.IO;
using CopyCollector;
using System.Collections.Generic;
using System.Linq;

namespace CopyCollectorTest
{
    [TestClass]
    public class CopyCollectorTest
    {
        
        [TestMethod]
        public void FileComparer_IdentLengthDifferentName()
        {            
            Debug.WriteLine("Test FileComparer with files same length but different name.");

            Assert.AreEqual(true, Program.FileComparer(new FileInfo(@"D:\f1fortestProgram.txt"), new FileInfo(@"D:\f2fortestProgram.txt")));
            
        }
        [TestMethod]
        public void FileOriginalComparer_FilesWithDifferentCreationTime()
        {
            Debug.WriteLine("Test FileOriginalComparer with files different creating time.");

            Assert.AreEqual(false, Program.FileOriginalComparer(new FileInfo(@"D:\f1fortestProgram.txt"), new FileInfo(@"D:\f2fortestProgram.txt")));

        }
        [TestMethod]
        public void MoveFiles_File_ApearInNewDirectory()
        {
            Debug.WriteLine("Test MoveFiles with file that mast move in other directory.");
            List<FileInfo> files = new List<FileInfo>() { new FileInfo(@"D:\test\f1fortestProgram.txt"), new FileInfo(@"D:\test\f2fortestProgram.txt") };
            DirectoryInfo location = new DirectoryInfo(@"D:\test\moveTo");
            Program.MoveFiles(files, location);
            foreach(var f in files)
            {
                Assert.AreEqual(true, File.Exists(location + @"\" + f.Name));
                Assert.AreEqual(false, File.Exists(@"D:\test\"+f.Name));
            }
            foreach(var f in files)
            {
                f.MoveTo(@"D:\test\"+f.Name.Substring(0,16)+f.Extension);
            }

        }
    }
}
