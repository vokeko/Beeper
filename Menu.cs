﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beeper
{
    public static class Menu
    {
        public static bool Nabidka(string[] polozky)
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
            return GetFromNabidka(polozky[zvolenaPolozka]);
        }

        private static bool GetFromNabidka(string polozka)
        {
            switch (polozka)
            {
                case "Nová písnička":
                    PisnickaWindow.ZobrazPisnicku(null);
                    return false;
                case "Import":
                    Console.Clear();
                    Console.WriteLine("Funkce není naimplentována"); //TO DO
                    Console.ReadKey();
                    return false;
                case "Hrát písničku":
                    Console.Clear();
                    Console.WriteLine("Hraje se písnička ♪");
                    var pisen = new PisenInfo();
                    pisen.PridejNotu(Ton.D4, Delka.Ctvrtina, 0);
                    pisen.PridejNotu(Ton.D4, Delka.Ctvrtina, 400);
                    pisen.PridejNotu(Ton.A4, Delka.Ctvrtina, 800);
                    pisen.PridejNotu(Ton.A4, Delka.Ctvrtina, 1200);

                    pisen.PridejNotu(Ton.D4, Delka.Osmina, 1600);
                    pisen.PridejNotu(Ton.E4, Delka.Osmina, 1800);
                    pisen.PridejNotu(Ton.F4, Delka.Osmina, 2000);
                    pisen.PridejNotu(Ton.D4, Delka.Osmina, 2200);

                    pisen.PridejNotu(Ton.A4, Delka.Ctvrtina, 2400);
                    pisen.PridejNotu(Ton.A4, Delka.Ctvrtina, 2800);

                    pisen.PridejNotu(Ton.D4, Delka.Osmina, 3200);
                    pisen.PridejNotu(Ton.E4, Delka.Osmina, 3400);
                    pisen.PridejNotu(Ton.F4, Delka.Osmina, 3600);
                    pisen.PridejNotu(Ton.E4, Delka.Osmina, 3800);
                    pisen.PridejNotu(Ton.D4, Delka.Osmina, 4000);
                    pisen.PridejNotu(Ton.E4, Delka.Osmina, 4200);
                    pisen.PridejNotu(Ton.F4, Delka.Osmina, 4400);
                    pisen.PridejNotu(Ton.D4, Delka.Osmina, 4600);
                    pisen.PridejNotu(Ton.A4, Delka.Pulka, 4800);

                    pisen.PridejNotu(Ton.G4, Delka.Ctvrtina, 6400);
                    pisen.PridejNotu(Ton.G4, Delka.Ctvrtina, 6800);
                    pisen.PridejNotu(Ton.Hb4, Delka.Ctvrtina, 7200);
                    pisen.PridejNotu(Ton.Hb4, Delka.Ctvrtina, 7600);
                    pisen.Prehraj();
                    break;
                case "Info":
                    Console.Clear();
                    Console.WriteLine("Vítejte v aplikaci Beeper. Tato aplikace umožňuje vytváření a přehrávání písniček díky System.Beep.");
                    Console.WriteLine("Nová písnička - vytvořte novou písničku.");
                    Console.WriteLine("Import - nahrajte rozpracovanou melodii ke zpracování");
                    Console.WriteLine("Přehrát písničku - přehraje hotovou písničku");
                    Console.WriteLine("");
                    Console.WriteLine("Režim vytváření:");
                    Console.WriteLine("V režimu vytváření vyberte pozici šipkami nebo WASD.");
                    Console.WriteLine("Přidejte notu s enter");
                    Console.WriteLine("Smažte notu s delete");
                    Console.WriteLine("Prodlužte nebo zkraťte notu s + a -.");
                    Console.WriteLine("Pro další možnosti stiskněte respektivní klávesu na obrazovce v režimu vytváření");
                    Console.ReadKey();
                    return false;
                case "Tvůrce":
                    Console.Clear();
                    Console.WriteLine("Zadejte jméno tvůrce:");
                    string tvurce = Console.ReadLine();
                    return false;
                case "Rychlost":
                    Console.Clear();
                    Console.WriteLine("Zadejte rychlost:");
                    string rychlost = Console.ReadLine();
                    return false;
                case "Zpět":
                case "Odejít":
                    return true;
            }
            return false;
        }
    }
}
