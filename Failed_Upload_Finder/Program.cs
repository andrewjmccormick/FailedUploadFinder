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
            //string LogfilelocationOut = "\\\\pr-mcauly-fp01\\backups\\B5FailedUploadsOut.txt";


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
                        string[] failedlocation = line.Split(' ');
                        string passtxt1 = failedlocation[1];
                        DateTime MyDateTime = DateTime.ParseExact(passtxt1, "dd/MM/yyyy",null);
                        TimeSpan HowLong = DateTime.Today - MyDateTime;
                        string passtxt3 = failedlocation[3];
                        string passtxt5 = failedlocation[5];
                        string passtxt7 = failedlocation[7];
                        string inserttxt = intnum + " " + passtxt1 + " " + passtxt3 + " " + passtxt5 + " " + passtxt7 + Environment.NewLine;
                        if ((intnum != "INT9999") && (HowLong.Days <= 7))
                          
                        {
                            File.AppendAllText(Logfilelocation, inserttxt);
                            Console.WriteLine("line: {0} {1} {2}", f, line, HowLong);
                        }
                    }
                    if (line.Contains("removed"))
                    {
                        string[] failedlocation = line.Split(' ');
                        string passtxt1 = failedlocation[1];
                        DateTime MyDateTime = DateTime.ParseExact(passtxt1, "dd/MM/yyyy", null);
                        TimeSpan HowLong = DateTime.Today - MyDateTime;
                        string passtxt3 = failedlocation[3];
                        string passtxt5 = failedlocation[5];
                        if ((intnum != "INT9999") && (HowLong.Days <= 7))
                        {
                            string inserttxt = intnum + " " + passtxt1 + " " + passtxt3 + " " + passtxt5 + Environment.NewLine; File.AppendAllText(Logfilelocation, inserttxt);
                            Console.WriteLine("line: {0} {1} {2}", f, line, HowLong);
                        }
                    }
                }
            }

            string[] lines = File.ReadAllLines(Logfilelocation);
            File.WriteAllLines(Logfilelocation, lines.Distinct().ToArray());
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
