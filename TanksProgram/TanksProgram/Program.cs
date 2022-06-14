using System;
using System.Threading;
using TanksLibrary;

namespace TanksProgram
{

    class MyEventArgs : EventArgs
    {
        public char ch;
    }

    class KeyEvent
    {
        // Создадим событие, используя обобщенный делегат.
        public event EventHandler<MyEventArgs> KeyDown;

        public void OnKeyDown(char ch)
        {
            MyEventArgs c = new MyEventArgs();

            if (KeyDown != null)
            {
                c.ch = ch;
                KeyDown(this, c);
            }
        }
    }
    internal class Program
    {
        private static void Console_CancelKeyPress(object? sender, ConsoleCancelEventArgs e) //Метод для закрытия программы.
        {
            Console.WriteLine("Программа отменена, все данные сохранены.");
        }

        static void Main(string[] args)
        {
            const int MULTIPLIER = 7;
            int fullweight = 0;
            int turretweight = 0;
            int load = 0;
            int lastsum = 0;
            int gas = 0;
            int shell = 0;
            int nagrada = 0;

            var players = new Players();   //Загружаем списки.
            players.LoadPlayers();

            var corpus = new Corpus();
            corpus.LoadCorpus();

            var turret = new Turret();
            turret.LoadTurret();

            var gun = new Gun();
            gun.LoadGun();

            var armor = new Armor();
            armor.LoadArmor();

            var motor = new Motor<int>();
            motor.LoadMotor();

            Random rnd = new Random();
            var plmotor = new Motor<int>();
            var plcorpus = new Corpus();
            var plturret = new Turret();
            var plgun = new Gun();
            var plarmor = new Armor();

            Console.CancelKeyPress += Console_CancelKeyPress;            //Методы для сохранении при закрытии программы.
            Console.CancelKeyPress += players.Console_CancelKeyPress;

            Console.WriteLine("Приветствуем! Войдите в свой аккаунт!"); //Вход в акк.
            int avtorizacia = 1;
            var player = new Players();
            while (avtorizacia == 1)
            {
                Console.Write("\nВаш логин:");
                string login = Console.ReadLine();
                Console.Write("\nВаш пароль:");
                string pass = Console.ReadLine();
                player = players.LogIn(login, pass);
                if (player == null)
                {
                    Console.WriteLine("Такого пользователя нет.");
                    Thread.Sleep(500);
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Добро пожаловать!");
                    Console.WriteLine(player.Name);
                    Console.WriteLine(player.Balance);
                    avtorizacia = 0;
                    Thread.Sleep(1000);
                    Console.Clear();
                }
            }

            int menu = 1;
            player.Balance += player.FullSum;
            player.FullSum = 0;
            while (menu != 0)
            {
                if (menu == 1)
                {
                    Console.WriteLine("Ваш баланс: " + player.Balance);
                    Console.WriteLine("Выберите мотор для танка:");
                    Console.WriteLine("Name Weight Price Power");
                    motor.Spisok();
                    int mot = -1;
                    while (mot != 0)
                    {
                        mot = Convert.ToInt32(Console.ReadLine());
                        if (mot == 1)
                        {
                            var m = motor.Return(0);
                            if (player.Balance < m.Price)
                            {
                                Console.WriteLine("У вас недостаточно средств");
                            }
                            else
                            {
                                player.Motor = 1;
                                plmotor = m;
                                player.Balance -= m.Price;
                                lastsum = m.Price;
                                player.FullSum += m.Price;
                                load = m.Price * MULTIPLIER;
                                fullweight += m.Weight;
                                
                                mot = 0;
                                menu++;
                            }
                        }
                        else if (mot == 2)
                        {
                            var m = motor.Return(1);
                            if (player.Balance < m.Price)
                            {
                                Console.WriteLine("У вас недостаточно средств");
                            }
                            else
                            {
                                player.Motor = 2;
                                plmotor = m;
                                player.Balance -= m.Price;
                                lastsum = m.Price;
                                player.FullSum += m.Price;
                                load = m.Price * MULTIPLIER;
                                fullweight += m.Weight;
                                mot = 0;
                                menu++;
                            }
                        }
                        else if (mot == 3)
                        {
                            var m = motor.Return(2);
                            if (player.Balance < m.Price)
                            {
                                Console.WriteLine("У вас недостаточно средств");
                            }
                            else
                            {
                                player.Motor = 3;
                                plmotor = m;
                                player.Balance -= m.Price;
                                lastsum = m.Price;
                                player.FullSum += m.Price;
                                load = m.Price * MULTIPLIER;
                                fullweight += m.Weight;
                                mot = 0;
                                menu++;
                            }
                        }
                        else if (mot == 4)
                        {
                            var m = motor.Return(3);
                            if (player.Balance < m.Price)
                            {
                                Console.WriteLine("У вас недостаточно средств");
                            }
                            else
                            {
                                player.Motor = 4;
                                plmotor = m;
                                player.Balance -= m.Price;
                                lastsum = m.Price;
                                player.FullSum += m.Price;
                                load = m.Price * MULTIPLIER;
                                fullweight += m.Weight;
                                mot = 0;
                                menu++;
                            }
                        }
                        else if (mot == 5)
                        {
                            var m = motor.Return(4);
                            if (player.Balance < m.Price)
                            {
                                Console.WriteLine("У вас недостаточно средств");
                            }
                            else
                            {
                                player.Motor = 5;
                                plmotor = m;
                                player.Balance -= m.Price;
                                lastsum = m.Price;
                                player.FullSum += m.Price;
                                load = m.Price * MULTIPLIER;
                                fullweight += m.Weight;
                                mot = 0;
                                menu++;
                            }
                        }
                    }
                    Console.Clear();
                }   //Выбор мотора.
                if (menu == 2)
                {
                    Console.WriteLine("Ваш баланс: " + player.Balance);
                    Console.WriteLine("Выберите корпус для танка:");
                    Console.WriteLine("Name Weight Price MaxWeight SharkNose");
                    corpus.Spisok();
                    int corp = -1;
                    while (corp != 0)
                    {
                        corp = Convert.ToInt32(Console.ReadLine());
                        if (corp == 1)
                        {
                            var c = corpus.Return(0);
                            if (load < fullweight + c.Weight)
                            {
                                Console.WriteLine("Превышен допустимый вес");
                            }
                            else if (player.Balance < c.Price)
                            {
                                Console.WriteLine("У вас недостаточно средств");
                            }
                            else
                            {
                                player.Corpus = 1;
                                plcorpus = c;
                                player.Balance -= c.Price;
                                lastsum = c.Price;
                                player.FullSum += c.Price;
                                fullweight += c.Weight;
                                turretweight = c.MaxWeight;
                                corp = 0;
                                menu++;
                            }
                        }
                        else if (corp == 2)
                        {
                            var c = corpus.Return(1);
                            if (load < fullweight + c.Weight)
                            {
                                Console.WriteLine("Превышен допустимый вес");
                            }
                            else if (player.Balance < c.Price)
                            {
                                Console.WriteLine("У вас недостаточно средств");
                            }
                            else
                            {
                                player.Corpus = 2;
                                plcorpus = c;
                                player.Balance -= c.Price;
                                lastsum = c.Price;
                                player.FullSum += c.Price;
                                fullweight += c.Weight;
                                turretweight = c.MaxWeight;
                                corp = 0;
                                menu++;
                            }
                        }
                        else if (corp == 3)
                        {
                            var c = corpus.Return(2);
                            if (load < fullweight + c.Weight)
                            {
                                Console.WriteLine("Превышен допустимый вес");
                            }
                            else if (player.Balance < c.Price)
                            {
                                Console.WriteLine("У вас недостаточно средств");
                            }
                            else
                            {
                                player.Corpus = 3;
                                plcorpus = c;
                                player.Balance -= c.Price;
                                lastsum = c.Price;
                                player.FullSum += c.Price;
                                fullweight += c.Weight;
                                turretweight = c.MaxWeight;
                                corp = 0;
                                menu++;
                            }
                        }
                        else if (corp == 4)
                        {
                            var c = corpus.Return(3);
                            if (load < fullweight + c.Weight)
                            {
                                Console.WriteLine("Превышен допустимый вес");
                            }
                            else if (player.Balance < c.Price)
                            {
                                Console.WriteLine("У вас недостаточно средств");
                            }
                            else
                            {
                                player.Corpus = 4;
                                plcorpus = c;
                                player.Balance -= c.Price;
                                lastsum = c.Price;
                                player.FullSum += c.Price;
                                fullweight += c.Weight;
                                turretweight = c.MaxWeight;
                                corp = 0;
                                menu++;
                            }
                        }
                        else if (corp == 5)
                        {
                            var c = corpus.Return(4);
                            if (load < fullweight + c.Weight)
                            {
                                Console.WriteLine("Превышен допустимый вес");
                            }
                            else if (player.Balance < c.Price)
                            {
                                Console.WriteLine("У вас недостаточно средств");
                            }
                            else
                            {
                                player.Corpus = 5;
                                plcorpus = c;
                                player.Balance -= c.Price;
                                lastsum = c.Price;
                                player.FullSum += c.Price;
                                fullweight += c.Weight;
                                turretweight = c.MaxWeight;
                                corp = 0;
                                menu++;
                            }
                        }
                        else if (corp == 6)
                        {
                            player.Balance += lastsum;
                            menu--;
                            corp = 0;
                        }
                    }
                    Console.Clear();
                }   //Выбор корпуса.
                if (menu == 3)
                {
                    Console.WriteLine("Ваш баланс: " + player.Balance);
                    Console.WriteLine("Выберите башню для танка:");
                    Console.WriteLine("Name Weight Price ProtectiveMask");
                    turret.Spisok();
                    int turr = -1;
                    while (turr != 0)
                    {
                        turr = Convert.ToInt32(Console.ReadLine());
                        if (turr == 1)
                        {
                            var t = turret.Return(0);
                            if (load < fullweight + t.Weight)
                            {
                                Console.WriteLine("Превышен допустимый вес");
                            }
                            else if (player.Balance < t.Price)
                            {
                                Console.WriteLine("У вас недостаточно средств");
                            }
                            else if (turretweight < t.Weight)
                            {
                                Console.WriteLine("Выбранный корпус не расчитан на эту башню");
                            }
                            else
                            {
                                player.Turret = 1;
                                plturret = t;
                                player.Balance -= t.Price;
                                lastsum = t.Price;
                                player.FullSum += t.Price;
                                fullweight += t.Weight;
                                turr = 0;
                                menu++;
                            }
                        }
                        else if (turr == 2)
                        {
                            var t = turret.Return(1);
                            if (load < fullweight + t.Weight)
                            {
                                Console.WriteLine("Превышен допустимый вес");
                            }
                            else if (player.Balance < t.Price)
                            {
                                Console.WriteLine("У вас недостаточно средств");
                            }
                            else if (turretweight < t.Weight)
                            {
                                Console.WriteLine("Выбранный корпус не расчитан на эту башню");
                            }
                            else
                            {
                                player.Turret = 2;
                                plturret = t;
                                player.Balance -= t.Price;
                                lastsum = t.Price;
                                player.FullSum += t.Price;
                                fullweight += t.Weight;
                                turr = 0;
                                menu++;
                            }
                        }
                        else if (turr == 3)
                        {
                            var t = turret.Return(2);
                            if (load < fullweight + t.Weight)
                            {
                                Console.WriteLine("Превышен допустимый вес");
                            }
                            else if (player.Balance < t.Price)
                            {
                                Console.WriteLine("У вас недостаточно средств");
                            }
                            else if (turretweight < t.Weight)
                            {
                                Console.WriteLine("Выбранный корпус не расчитан на эту башню");
                            }
                            else
                            {
                                player.Turret = 3;
                                plturret = t;
                                player.Balance -= t.Price;
                                lastsum = t.Price;
                                player.FullSum += t.Price;
                                fullweight += t.Weight;
                                turr = 0;
                                menu++;
                            }
                        }
                        else if (turr == 4)
                        {
                            var t = turret.Return(3);
                            if (load < fullweight + t.Weight)
                            {
                                Console.WriteLine("Превышен допустимый вес");
                            }
                            else if (player.Balance < t.Price)
                            {
                                Console.WriteLine("У вас недостаточно средств");
                            }
                            else if (turretweight < t.Weight)
                            {
                                Console.WriteLine("Выбранный корпус не расчитан на эту башню");
                            }
                            else
                            {
                                player.Turret = 4;
                                plturret = t;
                                player.Balance -= t.Price;
                                lastsum = t.Price;
                                player.FullSum += t.Price;
                                fullweight += t.Weight;
                                turr = 0;
                                menu++;
                            }
                        }
                        else if (turr == 5)
                        {
                            var t = turret.Return(4);
                            if (load < fullweight + t.Weight)
                            {
                                Console.WriteLine("Превышен допустимый вес");
                            }
                            else if (player.Balance < t.Price)
                            {
                                Console.WriteLine("У вас недостаточно средств");
                            }
                            else if (turretweight < t.Weight)
                            {
                                Console.WriteLine("Выбранный корпус не расчитан на эту башню");
                            }
                            else
                            {
                                player.Turret = 5;
                                plturret = t;
                                player.Balance -= t.Price;
                                lastsum = t.Price;
                                player.FullSum += t.Price;
                                fullweight += t.Weight;
                                turr = 0;
                                menu++;
                            }
                        }
                        else if (turr == 6)
                        {
                            player.Balance += lastsum;
                            menu--;
                            turr = 0;
                        }
                    }
                    Console.Clear();
                }   //Выбор башни.
                if (menu == 4)
                {
                    Console.WriteLine("Ваш баланс: " + player.Balance);
                    Console.WriteLine("Выберите пушку для танка:");
                    Console.WriteLine("Name Weight Price RateOfFire");
                    gun.Spisok();
                    int guns = -1;
                    while (guns != 0)
                    {
                        guns = Convert.ToInt32(Console.ReadLine());
                        if (guns == 1)
                        {
                            var g = gun.Return(0);
                            if (load < fullweight + g.Weight)
                            {
                                Console.WriteLine("Превышен допустимый вес");
                            }
                            else if (player.Balance < g.Price)
                            {
                                Console.WriteLine("У вас недостаточно средств");
                            }
                            else
                            {
                                player.Gun = 1;
                                plgun = g;
                                player.Balance -= g.Price;
                                lastsum = g.Price;
                                player.FullSum += g.Price;
                                fullweight += g.Weight;
                                guns = 0;
                                menu++;
                            }
                        }
                        else if (guns == 2)
                        {
                            var g = gun.Return(1);
                            if (load < fullweight + g.Weight)
                            {
                                Console.WriteLine("Превышен допустимый вес");
                            }
                            else if (player.Balance < g.Price)
                            {
                                Console.WriteLine("У вас недостаточно средств");
                            }
                            else
                            {
                                player.Gun = 2;
                                plgun = g;
                                player.Balance -= g.Price;
                                lastsum = g.Price;
                                player.FullSum += g.Price;
                                fullweight += g.Weight;
                                guns = 0;
                                menu++;
                            }
                        }
                        else if (guns == 3)
                        {
                            var g = gun.Return(2);
                            if (load < fullweight + g.Weight)
                            {
                                Console.WriteLine("Превышен допустимый вес");
                            }
                            else if (player.Balance < g.Price)
                            {
                                Console.WriteLine("У вас недостаточно средств");
                            }
                            else
                            {
                                player.Gun = 3;
                                plgun = g;
                                player.Balance -= g.Price;
                                lastsum = g.Price;
                                player.FullSum += g.Price;
                                fullweight += g.Weight;
                                guns = 0;
                                menu++;
                            }
                        }
                        else if (guns == 4)
                        {
                            var g = gun.Return(3);
                            if (load < fullweight + g.Weight)
                            {
                                Console.WriteLine("Превышен допустимый вес");
                            }
                            else if (player.Balance < g.Price)
                            {
                                Console.WriteLine("У вас недостаточно средств");
                            }
                            else
                            {
                                player.Gun = 4;
                                plgun = g;
                                player.Balance -= g.Price;
                                lastsum = g.Price;
                                player.FullSum += g.Price;
                                fullweight += g.Weight;
                                guns = 0;
                                menu++;
                            }
                        }
                        else if (guns == 5)
                        {
                            var g = gun.Return(4);
                            if (load < fullweight + g.Weight)
                            {
                                Console.WriteLine("Превышен допустимый вес");
                            }
                            else if (player.Balance < g.Price)
                            {
                                Console.WriteLine("У вас недостаточно средств");
                            }
                            else
                            {
                                player.Gun = 5;
                                plgun = g;
                                player.Balance -= g.Price;
                                lastsum = g.Price;
                                player.FullSum += g.Price;
                                fullweight += g.Weight;
                                guns = 0;
                                menu++;
                            }
                        }
                        else if (guns == 6)
                        {
                            player.Balance += lastsum;
                            menu--;
                            guns = 0;
                        }
                    }
                    Console.Clear();
                }   //Выбор пушки.
                if (menu == 5)
                {
                    Console.WriteLine("Ваш баланс: " + player.Balance);
                    Console.WriteLine("Выберите броню для танка:");
                    Console.WriteLine("Name Weight Price Width");
                    armor.Spisok();
                    int arm = -1;
                    while (arm != 0)
                    {
                        arm = Convert.ToInt32(Console.ReadLine());
                        if (arm == 1)
                        {
                            var a = armor.Return(0);
                            if (load < fullweight + a.Weight)
                            {
                                Console.WriteLine("Превышен допустимый вес");
                            }
                            else if (player.Balance < a.Price)
                            {
                                Console.WriteLine("У вас недостаточно средств");
                            }
                            else
                            {
                                player.Armor = 1;
                                plarmor = a;
                                player.Balance -= a.Price;
                                lastsum = a.Price;
                                player.FullSum += a.Price;
                                fullweight += a.Weight;
                                arm = 0;
                                menu++;
                            }
                        }
                        else if (arm == 2)
                        {
                            var a = armor.Return(1);
                            if (load < fullweight + a.Weight)
                            {
                                Console.WriteLine("Превышен допустимый вес");
                            }
                            else if (player.Balance < a.Price)
                            {
                                Console.WriteLine("У вас недостаточно средств");
                            }
                            else
                            {
                                player.Armor = 2;
                                plarmor = a;
                                player.Balance -= a.Price;
                                lastsum = a.Price;
                                player.FullSum += a.Price;
                                fullweight += a.Weight;
                                arm = 0;
                                menu++;
                            }
                        }
                        else if (arm == 3)
                        {
                            var a = armor.Return(2);
                            if (load < fullweight + a.Weight)
                            {
                                Console.WriteLine("Превышен допустимый вес");
                            }
                            else if (player.Balance < a.Price)
                            {
                                Console.WriteLine("У вас недостаточно средств");
                            }
                            else
                            {
                                player.Armor = 3;
                                plarmor = a;
                                player.Balance -= a.Price;
                                lastsum = a.Price;
                                player.FullSum += a.Price;
                                fullweight += a.Weight;
                                arm = 0;
                                menu++;
                            }
                        }
                        else if (arm == 4)
                        {
                            var a = armor.Return(3);
                            if (load < fullweight + a.Weight)
                            {
                                Console.WriteLine("Превышен допустимый вес");
                            }
                            else if (player.Balance < a.Price)
                            {
                                Console.WriteLine("У вас недостаточно средств");
                            }
                            else
                            {
                                player.Armor = 4;
                                plarmor = a;
                                player.Balance -= a.Price;
                                lastsum = a.Price;
                                player.FullSum += a.Price;
                                fullweight += a.Weight;
                                arm = 0;
                                menu++;
                            }
                        }
                        else if (arm == 5)
                        {
                            var a = armor.Return(4);
                            if (load < fullweight + a.Weight)
                            {
                                Console.WriteLine("Превышен допустимый вес");
                            }
                            else if (player.Balance < a.Price)
                            {
                                Console.WriteLine("У вас недостаточно средств");
                            }
                            else
                            {
                                player.Armor = 5;
                                plarmor = a;
                                player.Balance -= a.Price;
                                lastsum = a.Price;
                                player.FullSum += a.Price;
                                fullweight += a.Weight;
                                arm = 0;
                                menu++;
                            }
                        }
                        else if (arm == 6)
                        {
                            player.Balance += lastsum;
                            menu--;
                            arm = 0;
                        }
                    }
                    Console.Clear();
                }   //Выбор брони.
                if (menu == 6)
                {
                    Console.WriteLine("Конфигурация вашего танка:" + "\n" + motor.String(player.Motor - 1) + "\n" + corpus.String(player.Corpus - 1) + "\n" + turret.String(player.Turret - 1) + "\n" + gun.String(player.Gun - 1) + "\n" + armor.String(player.Armor - 1));
                    Console.WriteLine("1) В бой!\n2) Пересобрaть танк.\n3) Сохранить и выйти");
                    int menu1 = Convert.ToInt32(Console.ReadLine());
                    if (menu1 == 1)
                    {
                        Console.WriteLine("Ваш баланс: " + player.Balance);
                        Console.WriteLine("Введите количество топлива, которое хотите купить, единица топлива стоит 100$, на единице топлива можно проехать 10 км.");
                        gas = Convert.ToInt32(Console.ReadLine());
                        if (gas * 100 > player.Balance)
                        {
                            Console.WriteLine("У вас недостаточно средств");
                        }
                        else
                        {
                            player.Balance -= gas * 100;
                            Console.WriteLine("Приобретено " + gas + " топлива.");
                        }
                        Console.WriteLine("Введите количество cнарядов, которое хотите купить, один снаряд стоит 10$");
                        shell = Convert.ToInt32(Console.ReadLine());
                        if (shell * 10 > player.Balance)
                        {
                            Console.WriteLine("У вас недостаточно средств");
                        }
                        else
                        {
                            player.Balance -= shell * 10;
                            Console.WriteLine("Приобретено " + shell + " снарядов.");
                        }
                        int doparmor = 0;
                        if (plcorpus.ShNose)
                        {
                            doparmor += 2;
                        }
                        if (plturret.ProtectiveMask)
                        {
                            doparmor += 2;
                        }
                        int protivniki = 0;
                        nagrada = 0;
                        int destroy = 0;
                        Console.Clear();
                        Console.WriteLine("Для того чтобы выехать нажмите 1");
                        KeyEvent @event = new KeyEvent();
                            @event.KeyDown += (sender, e) =>       //Используем EventArgs для нажатия кнопок в меню.
                            {
                                switch (e.ch)
                                {
                                    case '1':
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Остаток топлива: " + gas + "\nОстаток снарядов: " + shell);
                                            if (destroy == 1)
                                            {
                                                Console.WriteLine("Ваш танк уничтожен, нажмите е для выхода.");
                                            }
                                            if (gas == 0)
                                            {
                                                Console.WriteLine("У вас закончилось топливо");
                                            }
                                            else if (protivniki > 0)
                                            {
                                                Console.WriteLine("Одолейте всех противников!");
                                            }
                                            else
                                            {
                                                gas--;
                                                protivniki = rnd.Next(0, 3);
                                                Console.WriteLine("Вы встретили " + protivniki + " противников!");
                                                Console.WriteLine("1) Двигаться дальше\n2) Стрелять\ne) Бежать с поля боя");
                                            }
                                            break;
                                        }
                                    case '2':
                                        {
                                            Console.Clear();
                                            if (destroy == 1)
                                            {
                                                Console.WriteLine("Ваш танк уничтожен, нажмите е для выхода.");
                                            }
                                            if (shell == 0)
                                            {
                                                Console.WriteLine("Снаряды кончились бегите!");
                                            }
                                            else
                                            {
                                                if (protivniki > 0)
                                                {
                                                    if (rnd.Next(0, 100) < plgun.Percents)
                                                    {
                                                        Console.WriteLine("Противник Уничтожен!");
                                                        nagrada += 800;
                                                        protivniki--;
                                                        shell--;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Не пробил!");
                                                        shell--;
                                                    }
                                                    if (protivniki > 0)
                                                    {
                                                        for (int i = 0; i < plgun.Shots; i++)
                                                        {
                                                            if (rnd.Next(0, 100) < plarmor.Percents + doparmor)
                                                            {
                                                                Console.WriteLine("Противник не пробил!");
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Ваш танк уничтожен!");
                                                                destroy = 1;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("На данном этапе все противник повержены.");
                                                }
                                            }
                                            break;
                                        }
                                    case 'e':
                                        {
                                            Console.Clear();
                                            int pobeg = rnd.Next(0, 1);
                                            if (pobeg == 0 || protivniki == 0)
                                            {
                                                Console.WriteLine("Вы успешно сбежали!");
                                                Thread.Sleep(500);
                                            }
                                            else if (pobeg == 1)
                                            {
                                                Console.WriteLine("Ваш танк уничтожили при побеге, вы потеряли все награды!");
                                                Thread.Sleep(500);
                                                nagrada = 0;
                                            }
                                            menu = 7;
                                            break;
                                            
                                        }
                                        }
                            };
                        char ch;
                        do
                        {
                            Console.Write("Ваш ход:");
                            ConsoleKeyInfo key;
                            key = Console.ReadKey();
                            ch = key.KeyChar;
                            @event.OnKeyDown(key.KeyChar);
                        }
                        while (ch != 'e');
                    }
                    else if (menu1 == 2)
                    {
                        menu = 1;
                        player.Balance += player.FullSum;
                        player.Motor = 0;
                        player.Corpus = 0;
                        player.Turret = 0;
                        player.Gun = 0;
                        player.Armor = 0;
                        player.FullSum = 0;
                        fullweight = 0;
                        load = 0;
                        turretweight = 0;
                    }
                    else if (menu1 == 3)
                    {
                        players.SavePlayers();
                        menu = 0;
                    }
                }   //Меню + бой.
                if (menu == 7)
                {
                    Console.Clear();
                    Console.WriteLine("Вы заработали " + nagrada + "\nНажмите e для продолжения.");
                    player.Balance += nagrada;
                    string e = Console.ReadLine();
                    if (e == "e")
                    {
                        menu = 6;
                        Console.Clear();
                    }
                }   //Награды за бой.
            }
        }
    }
}
