using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanksLibrary
{
    public class Turret : Details
    {
        public bool ProtectiveMask { get; set; }

        public List<Turret> Tur { get; set; } = new List<Turret>();

        public void LoadTurret()
        {
            string path = @"..\Turret.csv";
            var lines = File.ReadAllLines(path);
            for (int i = 0; i < lines.Length - 1; i++)
            {
                var splits = lines[i + 1].Split(';');
                var turret = new Turret();
                turret.Name = splits[0];
                turret.Weight = Convert.ToInt32(splits[1]);
                turret.Price = Convert.ToInt32(splits[2]);
                turret.ProtectiveMask = Convert.ToBoolean(splits[3]);
                Tur.Add(turret);
                //Console.WriteLine(turret.Name + " " + turret.Weight + " " + turret.ProtectiveMask + " " + turret.Price);
            }
        }

        public void SaveTurret()
        {
            string path = @"..\Turret.csv";
            var fileInf1 = new FileInfo(path);
            if (fileInf1.Exists)
            {
                try
                {
                    StreamWriter sw = new StreamWriter(@"..\Turret.csv");
                    sw.WriteLine("Name; Weight; Price; ProtectiveMask");
                    for (int i = 0; i < Tur.Count; i++)
                    {
                        sw.WriteLine($"{Tur[i].Name};{Tur[i].Weight};{Tur[i].Price};{Tur[i].ProtectiveMask}");
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
            for (int i = 0; i < Tur.Count; i++)
            {
                Console.WriteLine(i+1 + " " + Tur[i].Name + " " + Tur[i].Weight + " " + Tur[i].ProtectiveMask + " " + Tur[i].Price);
            }
        }

        public Turret Return(int id)
        {
            var asd = Tur[id];
            return asd;
        }

        public string String(int id)
        {
            var s = Return(id);
            string ss = s.Name + " " + s.Weight + " " + s.ProtectiveMask + " " + s.Price;
            return ss;
        }
    }
}
