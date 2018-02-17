using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;

/*
Завданя я зрозумів наступним чином:
Задається певна коренева директорія, у якій можуть знаходитись багато рівнів дирекорій, по яких розкидано файли.
Файли можуть повторятись як по імені так і по змісту.
Я вважаю копією файла файли з однаковим ім’ям і змістом або тільки змістом.
Усі копії потрібно перенести у створену в кореневій директорії директорію COPY, а оригінали залишити.
Під оригіналом я зрозумів такий файл, серед однакових, дата створення якого буде найменшою, тобто найранішою.
В корневій директорії потрібно створити XML файл з отриманою структурою розміщення файлів.
Для наглядності я створюю XML файл з початковою труктурою і кінцевою.
*/
namespace CopyCollector
{
    public class Program
    { 
        static void Main(string[] args)
        {
           DirectoryInfo coreDirectory = new DirectoryInfo(@"D:\Core");

            CopyCollect(coreDirectory);
            
        }
        static void CopyCollect(DirectoryInfo coreDirectory)
        {
            List<FileInfo> allFiles = coreDirectory.GetFiles("*.*", SearchOption.AllDirectories).ToList();//Get lisf of all files
            List<FileInfo> originalFiles = GetOriginals(allFiles);//Select original files from all files

            XDocument beforeCopyCollect = new XDocument();
            beforeCopyCollect.Add(CreateXML(coreDirectory));
            beforeCopyCollect.Save(coreDirectory + "\\Structure(before copycollect).xml");

            MoveFiles(allFiles.Except(originalFiles).ToList(), 
                new DirectoryInfo(coreDirectory.FullName + @"\COPY"));//Move all files(except original files) to COPY directory

            XDocument afterCopyCollect = new XDocument();
            afterCopyCollect.Add(CreateXML(coreDirectory));
            afterCopyCollect.Save(coreDirectory + "\\Structure(after copycollect).xml");

        }
        public static XElement CreateXML(DirectoryInfo core)//Create XML document of files location structure using recursion
        {
            if (core.Exists)
            {
                XElement root = new XElement("directory");
                root.Add(new XAttribute("DirName", core.Name));
                foreach(var file in core.GetFiles().OrderBy(f=>f.Name))
                {
                    root.Add(new XElement("file",file.Name));
                }
                if (core.GetDirectories().Length > 0)
                {
                    foreach (var dir in core.GetDirectories().OrderBy(d=>d.Name))
                    {
                        root.Add(CreateXML(dir));
                    }
                }
                return root;
            }
            return null;
        }
        
        static List<FileInfo> GetOriginals(List<FileInfo> allFiles)
        {
            List<FileInfo> originals = new List<FileInfo>();

            foreach(var file in allFiles)
            {
                var originalFile = originals.FirstOrDefault(f => FileComparer(file, f));//Get same element fromoriginals list or default
                if(originalFile!=null&&FileOriginalComparer(file,originalFile))//Check element exist and compare creation time
                {//Replace original file
                    originals.Remove(originals.First(f => FileComparer(file,f) && FileOriginalComparer(file, f)));
                    originals.Add(file);
                }
                else if(originalFile==null)
                {
                    originals.Add(file);
                }
            }

            return originals;
        }
        public static bool FileComparer(FileInfo f1, FileInfo f2)//Compare only name length and bytes inside
        {
            if (f1.Name == f2.Name || f1.Length == f2.Length)
            {


                FileStream fs1 = new FileStream(f1.FullName, FileMode.Open);
                FileStream fs2 = new FileStream(f2.FullName, FileMode.Open);
                int bytef1;
                int bytef2;
                do
                {
                    bytef1 = fs1.ReadByte();
                    bytef2 = fs2.ReadByte();
                }
                while ((bytef1 == bytef2) && (bytef1 != -1));
                fs1.Close();
                fs2.Close();
                return bytef1 == bytef2;
            }
            else
                return false;
        }
        public static bool FileOriginalComparer(FileInfo f1, FileInfo f2)//Compare date of creation
        {
            return f1.CreationTime < f2.CreationTime;
        }
        
        public static void MoveFiles(List<FileInfo> filesToMove, DirectoryInfo locationTo)
        {
            if (!locationTo.Exists&&filesToMove.Any())
            {
                locationTo.Create();
            }
            foreach(var file in filesToMove)
            {
                //Give to file original name that contain directories where it was contain and date of moving
                string fullName = locationTo.FullName + @"\" + file.Name.Split('.')[0] + "(from-dir-" + 
                    file.Directory.FullName.Replace(locationTo.Parent.FullName, "").Replace("\\", "-") + "-Date-" + 
                    DateTime.Now.ToString("hh-mm-ss--dd-MM-yyy") + ")" + file.Extension;
                if(fullName.Length<260)//Max num of symbols in location+filename mast be less than 260
                {
                    file.MoveTo(fullName);
                }
                else
                {
                    Console.WriteLine(fullName+" - name length mast be less then 260 symbols");
                }
            }
        }
    }
}
