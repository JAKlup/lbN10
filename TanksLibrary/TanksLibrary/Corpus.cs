using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanksLibrary
{
    public class Corpus : Details
    {
        public int MaxWeight { get; set; }
        public bool ShNose { get; set; }

        public List<Corpus> Corp { get; set; } = new List<Corpus>();

        public void LoadCorpus()
        {
            string path = @"..\Corpus.csv";
            var lines = File.ReadAllLines(path);
            for (int i = 0; i < lines.Length - 1; i++)
            {
                var splits = lines[i + 1].Split(';');
                var corpus = new Corpus();
                corpus.Name = splits[0];
                corpus.Weight = Convert.ToInt32(splits[1]);
                corpus.Price = Convert.ToInt32(splits[2]);
                corpus.MaxWeight = Convert.ToInt32(splits[3]);
                corpus.ShNose = Convert.ToBoolean(splits[4]);
                Corp.Add(corpus);
                //Console.WriteLine(corpus.Name + " " + corpus.Weight + " " + corpus.MaxWeight + " " + corpus.ShNose + " " + corpus.Price);
            }
        }

        public void SaveCorpus()
        {
            string path = @"..\Corpus.csv";
            var fileInf1 = new FileInfo(path);
            if (fileInf1.Exists)
            {
                try
                {
                    StreamWriter sw = new StreamWriter(@"..\Corpus.csv");
                    sw.WriteLine("Name; Weight; Price; MaxWeight; ShNose");
                    for (int i = 0; i < Corp.Count; i++)
                    {
                        sw.WriteLine($"{Corp[i].Name};{Corp[i].Weight};{Corp[i].Price};{Corp[i].MaxWeight};{Corp[i].ShNose}");
                    }
                    sw.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("\n" + e.Message);
                }
                finally
                {
                    Console.WriteLine("\n");
                }
            }
        }

        public void Spisok()
        {
            for (int i = 0; i < Corp.Count; i++)
            {
                Console.WriteLine(i+1 + " " + Corp[i].Name + " " + Corp[i].Weight + " " + Corp[i].MaxWeight + " " + Corp[i].ShNose + " " + Corp[i].Price);
            }
        }

        public Corpus Return(int id)
        {
            var asd = Corp[id];
            return asd;
        }

        public string String(int id)
        {
            var s = Return(id);
            string ss = s.Name + " " + s.Weight + " " + s.MaxWeight + " " + s.ShNose + " " + s.Price;
            return ss;
        }
    }
}
