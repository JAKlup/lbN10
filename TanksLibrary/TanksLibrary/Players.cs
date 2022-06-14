using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanksLibrary
{
    public class Players
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Balance { get; set; }
        public int Motor { get; set; }
        public int Armor { get; set; }
        public int Corpus { get; set; }
        public int Gun { get; set; }
        public int Turret { get; set; }
        public int FullSum { get; set; }

        public List<Players> Player { get; set; } = new List<Players>();

        public void LoadPlayers()
        {
            string path = @"..\Players.csv";
            var lines = File.ReadAllLines(path);
            for (int i = 0; i < lines.Length - 1; i++)
            {
                var splits = lines[i + 1].Split(';');
                var player = new Players();
                player.Name = splits[0];
                player.Login = splits[1];
                player.Password = splits[2];
                player.Balance = Convert.ToInt32(splits[3]);
                player.Motor = Convert.ToInt32(splits[4]);
                player.Corpus = Convert.ToInt32(splits[5]);
                player.Turret = Convert.ToInt32(splits[6]);
                player.Gun = Convert.ToInt32(splits[7]);
                player.Armor = Convert.ToInt32(splits[8]);
                player.FullSum = Convert.ToInt32(splits[9]);
                Player.Add(player);
                Console.WriteLine(player.Name + " " + player.Login + " " + player.Password + " " + player.Balance);
            }
        }

        public void SavePlayers()
        {
            string path = @"..\Players.csv";
            var fileInf1 = new FileInfo(path);
            if (fileInf1.Exists)
            {
                try
                {
                    StreamWriter sw = new StreamWriter(@"..\Players.csv");
                    sw.WriteLine("Name; Login; Password; Balance; Motor; Corpus; Turret; Gun; Armor; fullsum");
                    for (int i = 0; i < Player.Count; i++)
                    {
                        sw.WriteLine($"{Player[i].Name};{Player[i].Login};{Player[i].Password};{Player[i].Balance};{Player[i].Motor};{Player[i].Corpus};{Player[i].Turret};{Player[i].Gun};{Player[i].Armor};{Player[i].FullSum}");
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

        public Players LogIn(string login, string pass)     //Проверка логина и пароля.
        {
            var customer = Player.FirstOrDefault(x => x.Login == login & x.Password == pass);
            return customer;
        }

        public void Console_CancelKeyPress(object? sender, ConsoleCancelEventArgs e)  //Отмена программы.
        {
            SavePlayers();
        }
    }
}
