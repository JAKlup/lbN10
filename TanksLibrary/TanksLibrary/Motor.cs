using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanksLibrary
{
    public class Motor<T> : Details  //int
    {
        public T Power { get; set; }

        public List<Motor<int>> Moto { get; set; } = new List<Motor<int>>();

        public void LoadMotor()
        {
            string path = @"..\Motor.csv";
            var lines = File.ReadAllLines(path);
            for (int i = 0; i < lines.Length - 1; i++)
            {
                var splits = lines[i + 1].Split(';');
                var motor = new Motor<int>();
                motor.Name = splits[0];
                motor.Weight = Convert.ToInt32(splits[1]);
                motor.Price = Convert.ToInt32(splits[2]);
                motor.Power = Convert.ToInt32(splits[3]);
                Moto.Add(motor);
                //Console.WriteLine(motor.Name + " " + motor.Weight + " " + motor.Power + " " + motor.Price);
            }
        }

        public void SaveMotor()
        {
            string path = @"..\Motor.csv";
            var fileInf1 = new FileInfo(path);
            if (fileInf1.Exists)
            {
                try
                {
                    StreamWriter sw = new StreamWriter(@"..\Motor.csv");
                    sw.WriteLine("Name; Weight; Price; Power");
                    for (int i = 0; i < Moto.Count; i++)
                    {
                        sw.WriteLine($"{Moto[i].Name};{Moto[i].Weight};{Moto[i].Price};{Moto[i].Power}");
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
            for (int i = 0; i < Moto.Count; i++)
            {
                Console.WriteLine(i+1 + " " + Moto[i].Name + " " + Moto[i].Weight + " " + Moto[i].Power + " " + Moto[i].Price);
            }
        }

        public Motor<int> Return(int id)
        {
            var asd = Moto[id];
            return asd;
        }

        public string String(int id)
        {
            var s = Return(id);
            string ss = s.Name + " " + s.Weight + " " + s.Power + " " + s.Price;
            return ss;
        }
    }
}
