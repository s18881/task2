using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;
using CSVReader.Properties;

namespace CSVReader
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\"Welcome to CSV Reader 18.18\"\n");

            string dataPath = @"data.csv";
            string resultPath;
            string logPath;
            string dataType;

            if (args[0] != null)
                dataPath = args[0];
            else
                dataPath = @"data.csv";

            if (args[1] != null)
                resultPath = @"" + args[1];
            else
                resultPath = @"result";

            if (args[2] != null)
                logPath = @"" + args[2];
            else
                logPath = @"log.txt";

            if (args[3] != null)
                dataType = args[3];
            else
                dataType = "xml";

            FileStream log = new FileStream(logPath, FileMode.Create);
            LogWriter logWriter = new LogWriter(logPath);

            if (!dataType.Equals("xml") && !dataType.Equals("json"))
            {
                logWriter.Write("Unsupported Data Type. Try Different one.");
                while (dataType != null && (dataType.Equals("xml") || dataType.Equals("json")))
                {
                    Console.WriteLine("\nSorry but given data type is not supported by our program.");
                    Console.WriteLine("Set different type of file, as program argument and specify it's type:");
                    dataType = Console.ReadLine();
                }
            }

            var fileInfo = new FileInfo(dataPath);
            var students = new HashSet<Student>(new MyComparer());
            var activeStudies = new List<Study>();


            using (var streamReader = new StreamReader(fileInfo.OpenRead()))
            {
                string line = null;
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] st = line.Split(',');
                    try
                    {
                        var student = new Student
                        {
                            Id = "s" + st[4],
                            FirstName = st[0],
                            LastName = st[1],
                            Faculty = st[2],
                            TypeOfStudying = st[3],
                            DateOfBirth = st[5],
                            Email = st[6],
                            NameOfMother = st[7],
                            NameOfFather = st[8],
                            StudiesInformation = new Student.StudiesData(st[2], st[3])
                        };
                        if (!students.Contains(student))
                        {
                            students.Add(student);
                            var study = activeStudies.Find(e =>
                            {
                                return e.Name.Equals(student.StudiesInformation.Faculty);
                            });
                            if (study != null)
                                study++;
                            else
                                activeStudies.Add(new Study(student.StudiesInformation.Faculty));
                        }
                        else
                        {
                            var str = "Student with ID: (" + st[4] + "), is already in the file.\n";
                            log.Write(Encoding.UTF8.GetBytes(str), 0, str.Length);
                        }
                    }
                    catch (ArgumentException ae)
                    {
                        var str = "Student with ID: (" + st[4] + "), has some of the fields not filled in.\n";
                        log.Write(Encoding.UTF8.GetBytes(str), 0, str.Length);
                    }
                }
            }

            /*foreach (Student s in students)
            {
                Console.WriteLine(s);
            }*/
            XmlStructure xmlStructure = new XmlStructure(students, activeStudies);
            if (dataType == "xml")
            {
                FileStream writer = new FileStream(resultPath + "." + dataType , FileMode.Create);
                XmlSerializer serializer = new XmlSerializer(typeof(XmlStructure), new XmlRootAttribute("University"));
                serializer.Serialize(writer, xmlStructure);
            }
            else
            {
                var jsonString = JsonSerializer.Serialize(xmlStructure, typeof(XmlStructure));
                File.WriteAllText(resultPath + "." + dataType, jsonString);
            }
        }
    }
}