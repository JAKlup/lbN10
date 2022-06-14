using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanksLibrary
{
    public class Gun : Details
    {
        public int RateOfFire { get; set; }
        public int Percents { get; set; }
        public int Shots { get; set; }

        public List<Gun> Guns { get; set; } = new List<Gun>();

        public void LoadGun()
        {
            string path = @"..\Gun.csv";
            var lines = File.ReadAllLines(path);
            for (int i = 0; i < lines.Length - 1; i++)
            {
                var splits = lines[i + 1].Split(';');
                var guns = new Gun();
                guns.Name = splits[0];
                guns.Weight = Convert.ToInt32(splits[1]);
                guns.Price = Convert.ToInt32(splits[2]);
                guns.RateOfFire = Convert.ToInt32(splits[3]);
                guns.Percents = Convert.ToInt32(splits[4]);
                guns.Shots = Convert.ToInt32(splits[5]);
                Guns.Add(guns);
                //Console.WriteLine(guns.Name + " " + guns.Weight + " " + guns.RateOfFire + " " + guns.Price);
            }
        }

        public void SaveGun()
        {
            string path = @"..\Gun.csv";
            var fileInf1 = new FileInfo(path);
            if (fileInf1.Exists)
            {
                try
                {
                    StreamWriter sw = new StreamWriter(@"..\Gun.csv");
                    sw.WriteLine("Name; Weight; Price; RateOfFire; %; Shots");
                    for (int i = 0; i < Guns.Count; i++)
                    {
                        sw.WriteLine($"{Guns[i].Name};{Guns[i].Weight};{Guns[i].Price};{Guns[i].RateOfFire};{Guns[i].Percents};{Guns[i].Shots}");
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
            for (int i = 0; i < Guns.Count; i++)
            {
                Console.WriteLine(i+1 + " " + Guns[i].Name + " " + Guns[i].Weight + " " + Guns[i].RateOfFire + " " + Guns[i].Price);
            }
        }

        public Gun Return(int id)
        {
            var asd = Guns[id];
            return asd;
        }

        public string String(int id)
        {
            var s = Return(id);
            string ss = s.Name + " " + s.Weight + " " + s.RateOfFire + " " + s.Price;
            return ss;
        }
    }
}
