using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beeper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Beeper - pípací skladatel";
            string[] polozky = new string[5] { "Nová písnička", "Import", "Hrát písničku", "Info", "Odejít" };
            bool exit = false;
            while (!exit)
            {
                exit = Menu.Nabidka(polozky);
            }
        }
        
    }

    public enum Ton
    {
        D1=37,
        Eb1=39,
        E1=41,
        F1=44,
        Gb1=46,
        G1=49,
        Ab1=52,
        A1=55,
        H1=58,
        Hb1=62,
        C2=65,
        Db2=70,
        D2=73,
        Eb2=78,
        E2=82,
        F2=87,
        Gb2=92,
        G2=100,
        Ab2=104,
        A2=110,
        Hb2=117,
        H2=123,
        C3=131,
        Db3=139,
        D3=147,
        Eb3=156,
        E3=165,
        F3=175,
        Gb3=185,
        G3=196,
        Ab3=208,
        A3=220,
        Hb3=233,
        H3=247,
        C4=262,
        Db4=277,
        D4=294,
        Eb4=311,
        E4=330,
        F4=349,
        Gb4=370,
        G4=192,
        Ab4=415,
        A4=440,
        Hb4=466,
        H4=494,
        C5=523,
        Db5=554,
        D5=587,
        Eb5=622,
        E5=659,
        F5=698,
        Gb5=740,
        G5=784,
        Ab5=831,
        A5=880,
        Hb5=932,
        H5=988,
        C6=1047,
        Db6=1109,
        D6=1175,
        Eb6=1245,
        E6=1319,    
        F6=1397,
        Gb6=1480,
        G6=1568,
        Ab6=1661,
        A6=1760,
        Hb6=1865,
        H6=1976,
        C7=2093,
        Db7=2217,
        D7=2349,
        Eb7=2489,
        E7=2637,
        F7=2794,
        Gb7=2960,
        G7=3136,
        Ab7=3322,
        A7=3520,
        Hb7=3729,
        H7=3951,
        C8=4186,
        Db8=4435,
        D8=4699,
        Eb8=4978,
        E8=5274,
        F8=5588,
        Gb8=5919,
        G8=6272,
        Ab8=6645,
        A8=7040,
        Hb8=7459,
        H8=7902,
    }

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
            switch(polozka)
            {
                case "Nová písnička":
                    Console.Clear();
                    Console.WriteLine("Funkce není naimplentována");
                    Console.ReadKey();
                    return false;
                case "Import":
                    Console.Clear();
                    Console.WriteLine("Funkce není naimplentována");
                    Console.ReadKey();
                    return false;
                case "Hrát písničku":
                    Console.Clear();
                    Console.WriteLine("Hraju :)");
                    Console.Beep((int)Ton.C4, 300);
                    Console.Beep((int)Ton.D4, 300);
                    Console.Beep((int)Ton.E4, 300);
                    Console.Beep((int)Ton.F4, 300);
                    Console.Beep((int)Ton.G4, 300);
                    Console.Beep((int)Ton.A4, 300);
                    Console.Beep((int)Ton.H4, 300);
                    Console.Beep((int)Ton.C5, 300);
                    break;
                case "Info":
                    Console.Clear();
                    Console.WriteLine("Vítejte v aplikaci Beeper. Tato aplikace umožňuje vytváření a přehrávání písniček díky System.Beep.");
                    Console.WriteLine("Nová písnička - vytvořte novou písničku.");
                    Console.WriteLine("Import - nahrajte rozpracovanou melodii ke zpracování");
                    Console.WriteLine("Přehrát písničku - přehraje hotovou písničku");
                    Console.WriteLine("");
                    //Console.WriteLine("Režim vytváření:");
                    //Console.WriteLine("V režimu vytváření vyberte pozici šipkami nebo WASD.");
                    //Console.WriteLine("Přidejte notu s enter");
                    //Console.WriteLine("Přidejte mezeru s mezerníkem");
                    //Console.WriteLine("Smažte notu nebo mezeru s delete");
                    //Console.WriteLine("Navyšte notu nebo mezeru s + a -.");
                    //Console.WriteLine("Prodlužte notu nebo mezeru s 1 a 2.");
                    //Console.WriteLine("Klikněte S, O, E, P nebo Q pro respektivní možnosti");
                    Console.ReadKey();
                    return false;
                case "Odejít":
                    return true;
            }
            return false;
        }
    }

    public static class PisnickaWindow
    {
        public static void ZobrazPisnicku()
        {
            VykresliPisnicku();
            var key = Console.ReadKey();
        }

        private static void VykresliPisnicku()
        {
            Console.Clear();
        }
    }

    class PisenInfo
    {
        int rychlost;
        List<Pisen> pisen;
		PisenInfo()
        {
            rychlost = 130;
            pisen = new List<Pisen>();
        }
        class Pisen
        {
            Ton ton;
            int delka;
            int pozice;
        }
    }
}
