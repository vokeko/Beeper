using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Beeper
{
    public static class Menu
    {
        public static bool Nabidka(string[] polozky, PisenInfo pisen)
        {
            int zvolenaPolozka = 0;
            bool vyberdokoncen = false;
            Console.Clear();
            while (!vyberdokoncen)
            {
                Console.SetCursorPosition(0, 3);
                for (int I = 0; I < polozky.Length; I++)
                {
                    if (zvolenaPolozka == I)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    Console.WriteLine(polozky[I]);
                    Console.ResetColor();
                }
                ConsoleKeyInfo stisknutaKlavesa = Console.ReadKey(true);
                switch (stisknutaKlavesa.Key)
                {
                    case ConsoleKey.UpArrow:
                        zvolenaPolozka--;
                        if (zvolenaPolozka < 0)
                        {
                            zvolenaPolozka = polozky.Length - 1;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        zvolenaPolozka++;
                        if (zvolenaPolozka > polozky.Length - 1)
                        {
                            zvolenaPolozka = 0;
                        }
                        break;
                    case ConsoleKey.Enter:
                        vyberdokoncen = true;
                        break;
                    default:
                        break;
                }
            }
            return GetFromNabidka(polozky[zvolenaPolozka], pisen);
        }

        private static bool GetFromNabidka(string polozka, PisenInfo savedPisen)
        {
            switch (polozka)
            {
                case "Nová písnička":
                    PisnickaWindow.ZobrazPisnicku(null);
                    return false;
                case "Nahrát":
                    Console.Clear();
                    try
                    {
                        string filePath = Extensions.GetFile();
                        using (Stream stream = File.Open(filePath , FileMode.Open))
                        {
                            BinaryFormatter bin = new BinaryFormatter();

                            {
                                object deseri = bin.Deserialize(stream);

                                switch (deseri)
                                {
                                    case PisenInfo pis:
                                        PisnickaWindow.ZobrazPisnicku(pis);
                                        break;
                                    default:
                                        Console.WriteLine("Nesprávný formát!");
                                        break;
                                }
                            }
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Nesprávný formát!");
                    }
                    return false;
                case "Hrát písničku":
                    Console.Clear();
                    Console.WriteLine("Hraje se písnička ♪");
                    PisenInfo pisen = new PisenInfo()
                    {
                        nazev = "Babička Mary",
                        tvurce = "Jiří Voskovec",
                        rychlost = 110,
                    };
                    pisen.PridejNotu(Ton.D4, Delka.Čtvrtina, 0);
                    pisen.PridejNotu(Ton.D4, Delka.Čtvrtina, 400);
                    pisen.PridejNotu(Ton.A4, Delka.Čtvrtina, 800);
                    pisen.PridejNotu(Ton.A4, Delka.Čtvrtina, 1200);

                    pisen.PridejNotu(Ton.D4, Delka.Osmina, 1600);
                    pisen.PridejNotu(Ton.E4, Delka.Osmina, 1800);
                    pisen.PridejNotu(Ton.F4, Delka.Osmina, 2000);
                    pisen.PridejNotu(Ton.D4, Delka.Osmina, 2200);

                    pisen.PridejNotu(Ton.A4, Delka.Čtvrtina, 2400);
                    pisen.PridejNotu(Ton.A4, Delka.Čtvrtina, 2800);

                    pisen.PridejNotu(Ton.D4, Delka.Osmina, 3200);
                    pisen.PridejNotu(Ton.E4, Delka.Osmina, 3400);
                    pisen.PridejNotu(Ton.F4, Delka.Osmina, 3600);
                    pisen.PridejNotu(Ton.E4, Delka.Osmina, 3800);
                    pisen.PridejNotu(Ton.D4, Delka.Osmina, 4000);
                    pisen.PridejNotu(Ton.E4, Delka.Osmina, 4200);
                    pisen.PridejNotu(Ton.F4, Delka.Osmina, 4400);
                    pisen.PridejNotu(Ton.D4, Delka.Osmina, 4600);
                    pisen.PridejNotu(Ton.A4, Delka.Půlka, 4800);

                    pisen.PridejNotu(Ton.G4, Delka.Čtvrtina, 6400);
                    pisen.PridejNotu(Ton.G4, Delka.Čtvrtina, 6800);
                    pisen.PridejNotu(Ton.Asharp4, Delka.Čtvrtina, 7200);
                    pisen.PridejNotu(Ton.Asharp4, Delka.Čtvrtina, 7600);
                    pisen.Prehraj();
                    break;
                case "Info":
                    Console.Clear();
                    Console.WriteLine("Vítejte v aplikaci Beeper. Tato aplikace umožňuje vytváření a přehrávání písniček díky System.Beep.");
                    Console.WriteLine("Nová písnička - vytvořte novou písničku.");
                    Console.WriteLine("Nahrát - nahrajte rozpracovanou melodii ke zpracování");
                    Console.WriteLine("Přehrát písničku - přehraje hotovou písničku");
                    Console.WriteLine("");
                    Console.WriteLine("Režim vytváření:");
                    Console.WriteLine("V režimu vytváření vyberte pozici šipkami nebo WASD.");
                    Console.WriteLine("Přidejte notu s enter");
                    Console.WriteLine("Smažte notu s delete");
                    Console.WriteLine("Prodlužte nebo zkraťte notu s + a -.");
                    Console.WriteLine("Přidejte křížek s X.");
                    Console.WriteLine("Pro další možnosti stiskněte respektivní klávesu na obrazovce v režimu vytváření");
                    Console.ReadKey();
                    return false;
                case "Tvůrce":
                    Console.Clear();
                    Console.WriteLine("Zadejte jméno tvůrce:");
                    savedPisen.tvurce = Console.ReadLine();
                    return false;
                case "Rychlost":
                    Console.Clear();
                    Console.WriteLine("Zadejte rychlost:");
                    savedPisen.rychlost = int.Parse(Console.ReadLine());
                    return false;
                case "Název":
                    Console.Clear();
                    Console.WriteLine("Zadejte název písničky:");
                    savedPisen.nazev = Console.ReadLine();
                    return false;
                case "Zpět":
                case "Odejít":
                    return true;
            }
            return false;
        }
    }
}
