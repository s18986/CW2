using Cw2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Cw2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter streamwriter = new StreamWriter("log.txt");
            string path = @"Data\dane.csv";
            Console.WriteLine("Hello World");
            var fi = new FileInfo(path);
            var list = new List<Student>();
            try
            {
                using (var stream = new StreamReader(fi.OpenRead()))
                {
                    string line = null;
                    while ((line = stream.ReadLine()) != null)
                    {
                        string[] kolumny = line.Split(',');
                        int len = kolumny.Length;
                        if (len == 9)
                        {
                            if(!sprawdzPowtorzenie(kolumny,list))
                            {
                                var temp = new Student
                                {
                                    Imie = kolumny[0],
                                    Nazwisko = kolumny[1],
                                    Email = kolumny[6]
                                };
                                list.Add(temp);
                            }
                        }
                        else
                        {
                            streamwriter.Write(line);
                        }
                    }
                }
            }catch( System.IO.DirectoryNotFoundException e)
            {
                Console.WriteLine(e);
            }
            FileStream writer = new FileStream(@"data.xml", FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>),
                                       new XmlRootAttribute("uczelnia"));
            serializer.Serialize(writer, list);
            serializer.Serialize(writer, list);

            var jsonString = JsonSerializer.Serialize(list);
            File.WriteAllText("data.json", jsonString);

        }
        static bool sprawdzPowtorzenie(String[] line, List<Student> list)
        {
            bool powtarzalna = false;
            for(int i=0;i<list.Count;i++)
            {
                if(line[0].Equals(list[i].Imie) && line[6].Equals(list[i].Email))
                    {
                    powtarzalna = true;
                    }
            }
            return powtarzalna;
        }
    }
    
}
