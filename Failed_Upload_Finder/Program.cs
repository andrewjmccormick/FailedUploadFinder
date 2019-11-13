using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Failed_Upload_Finder
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("file:");
            //var allFiles = Directory.GetFiles("\\\\pr-mcauly-fp01\\backups", "logfile.txt", SearchOption.AllDirectories);
            //Console.WriteLine("file: {0}", allFiles);

            string Logfilelocation = "\\\\pr-mcauly-fp01\\backups\\B5FailedUploads.txt";
            string LogfilelocationOut = "\\\\pr-mcauly-fp01\\backups\\B5FailedUploadsOut.txt";


            if (System.IO.File.Exists(Logfilelocation))
            {
                System.IO.File.Delete(Logfilelocation);
            }
            foreach (string f in Directory.EnumerateFiles("\\\\pr-mcauly-fp01\\backups", "*ogfile.txt", SearchOption.AllDirectories))
            {
                string[] linelocation = f.Split('\\');
                string intnum = linelocation[4];

                foreach (var line in File.ReadAllLines(f))
                {
                    if (line.Contains("FAILED"))
                    {
                        //string[] failedlocation = line.Split(' ');
                        string inserttxt = intnum + line + Environment.NewLine;
                        File.AppendAllText(Logfilelocation, inserttxt);
                        Console.WriteLine("line: {0} {1}", f, line);
                    }
                    if (line.Contains("removed"))
                    {
                        string inserttxt = intnum + line + Environment.NewLine;
                        File.AppendAllText(Logfilelocation, inserttxt);
                        Console.WriteLine("line: {0} {1}", f, line);
                    }
                }
            }

 //           string[] lines = File.ReadAllLines(Logfilelocation);
 //           File.WriteAllLines(LogfilelocationOut, lines.Distinct().ToArray());
        }

        //static void CopyLinesRemovingAllDupes(TextReader reader, TextWriter writer)
        //{
        //    string currentLine;
        //    HashSet<string> previousLines = new HashSet<string>();

        //    while ((currentLine = reader.ReadLine()) != null)
        //    {
        //        // Add returns true if it was actually added,
        //        // false if it was already there
        //        if (previousLines.Add(currentLine))
        //        {
        //            writer.WriteLine(currentLine);
        //        }
        //    }
        //}
    }
}
