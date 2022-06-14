using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanksLibrary
{
    public class Armor : Details
    {
        public int ArmorWidth { get; set; }
        public int Percents { get; set; }

        public List<Armor> Arm { get; set; } = new List<Armor>();

        public void LoadArmor()
        {
            string path = @"..\Armor.csv";
            var lines = File.ReadAllLines(path);
            for (int i = 0; i < lines.Length - 1; i++)
            {
                var splits = lines[i + 1].Split(';');
                var armor = new Armor();
                armor.Name = splits[0];
                armor.Weight = Convert.ToInt32(splits[1]);
                armor.Price = Convert.ToInt32(splits[2]);
                armor.ArmorWidth = Convert.ToInt32(splits[3]);
                armor.Percents = Convert.ToInt32(splits[4]);
                Arm.Add(armor);
                //Console.WriteLine(armor.Name + " " + armor.Weight + " " + armor.ArmorWidth + " " + armor.Price);
            }
        }

        public void SaveArmor()
        {
            string path = @"..\Armor.csv";
            var fileInf1 = new FileInfo(path);
            if (fileInf1.Exists)
            {
                try
                {
                    StreamWriter sw = new StreamWriter(@"..\Armor.csv");
                    sw.WriteLine("Name; Weight; Price; ArmorWidth; %");
                    for (int i = 0; i < Arm.Count; i++)
                    {
                        sw.WriteLine($"{Arm[i].Name};{Arm[i].Weight};{Arm[i].Price};{Arm[i].ArmorWidth};{Arm[i].Percents}");
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
            for (int i = 0; i < Arm.Count; i++)
            {
                Console.WriteLine(i + 1 + " " + Arm[i].Name + " " + Arm[i].Weight + " " + Arm[i].ArmorWidth + " " + Arm[i].Price);
            }
        }

        public Armor Return(int id)
        {
            var asd = Arm[id];
            return asd;
        }

        public Armor Return(string id)
        {
            int id1 = Convert.ToInt32(id);
            var asd = Arm[id1];
            return asd;
        }

        public string String(int id)
        {
            var s = Return(id);
            string ss = s.Name + " " + s.Weight + " " + s.ArmorWidth + " " + s.Price;
            return ss;
        }
    }
}
