using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Beeper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Beeper - pípací skladatel";
            Console.OutputEncoding = Encoding.UTF8;
            Console.WindowHeight = 41;
            Console.WindowWidth = 129;
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
        /*D1=37,
        Eb1=39,
        E1=41,
        F1=44,
        Gb1=46,
        G1=49,
        Ab1=52,*/
        A1 = 55, //A1
        Hb1 = 58, //A#1
        H1 = 62, //H1
        C2 = 65, //C2
        Db2 = 70, //C#2
        D2 = 73, //D2
        Eb2 = 78, //D#2
        E2 = 82, //E2
        F2 = 87, //F2
        Gb2 = 92, //F#2
        G2 = 100, //G2
        Ab2 = 104, //G#2
        A2 = 110, //A2
        Hb2 = 117, //A#2
        H2 = 123, //H2
        C3 = 131, //C3
        Db3 = 139, //C#3
        D3 = 147, //D3
        Eb3 = 156,
        E3 = 165,
        F3 = 175,
        Gb3 = 185,
        G3 = 196,
        Ab3 = 208,
        A3 = 220,
        Hb3 = 233,
        H3 = 247,
        C4 = 262,
        Db4 = 277,
        D4 = 294,
        Eb4 = 311,
        E4 = 330,
        F4 = 349,
        Gb4 = 370,
        G4 = 392,
        Ab4 = 415,
        A4 = 440,
        Hb4 = 466,
        H4 = 494,
        C5 = 523,
        Db5 = 554,
        D5 = 587,
        Eb5 = 622,
        E5 = 659,
        F5 = 698,
        Gb5 = 740,
        G5 = 784,
        Ab5 = 831,
        A5 = 880,
        Hb5 = 932,
        H5 = 988,
        C6 = 1047,
        Db6 = 1109,
        D6 = 1175,
        Eb6 = 1245,
        E6 = 1319,
        /*F6=1397,
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
        H8=7902,*/
    }

    public enum Delka
    {
        Cela = 1600,
        Pulka = Cela / 2,
        Ctvrtina = Pulka / 2,
        Osmina = Ctvrtina / 2,
        Sestnactina = Osmina / 2,
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
                    PisnickaWindow.ZobrazPisnicku(null);
                    return false;
                case "Import":
                    Console.Clear();
                    Console.WriteLine("Funkce není naimplentována");
                    Console.ReadKey();
                    return false;
                case "Hrát písničku":
                    Console.Clear();
                    Console.WriteLine("Hraju :)");
                    Console.Beep((int)Ton.C4, (int)Delka.Ctvrtina);
                    Console.Beep((int)Ton.D4, (int)Delka.Ctvrtina);
                    Console.Beep((int)Ton.E4, (int)Delka.Ctvrtina);
                    Console.Beep((int)Ton.F4, (int)Delka.Ctvrtina);
                    Console.Beep((int)Ton.G4, (int)Delka.Ctvrtina);
                    Console.Beep((int)Ton.A4, (int)Delka.Ctvrtina);
                    Console.Beep((int)Ton.H4, (int)Delka.Ctvrtina);
                    Console.Beep((int)Ton.C5, (int)Delka.Ctvrtina);
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
                case "Odejít":
                    return true;
            }
            return false;
        }
    }

    public static class PisnickaWindow
    {
        public static void ZobrazPisnicku(PisenInfo pisen)
        {
            ConsoleKeyInfo key;
            if (pisen == null) pisen = new PisenInfo();

            do
            {
                VykresliPisnicku(pisen);
                key = Console.ReadKey();
                //if (key.Key == ConsoleKey.U) 
                //if (key.Key == ConsoleKey.M) 
                //if (key.Key == ConsoleKey.E) 
                if (key.Key == ConsoleKey.P) PrehrajPisnicku(pisen);
            }
            while (key.Key != ConsoleKey.O);
        }

        private static void VykresliPisnicku(PisenInfo pisen)
        {
            Console.Clear();
            if (Console.WindowHeight < 41) Console.WindowHeight = 41;
            if (Console.WindowWidth < 129) Console.WindowWidth = 129;
            Console.WriteLine(" - - - - - - - - - - - - - - - -|- - - - - - - - - - - - - - - -|- - - - - - - - - - - - - - - -|- - - - - - - - - - - - - - - -"); //E6
            Console.WriteLine("                                |                               |                               |                               ");
            Console.WriteLine(" - - - - - - - - - - - - - - - -|- - - - - - - - - - - - - - - -|- - - - - - - - - - - - - - - -|- - - - - - - - - - - - - - - -");
            Console.WriteLine("                                |                               |                               |                               ");
            Console.WriteLine(" - - - - - - - - - - - - - - - -|- - - - - - - - - - - - - - - -|- - - - - - - - - - - - - - - -|- - - - - - - - - - - - - - - -");
            Console.WriteLine("                                |                               |                               |                               ");
            Console.WriteLine("--------------------------------+-------------------------------+-------------------------------+-------------------------------");
            Console.WriteLine("                                |                               |                               |                               ");
            Console.WriteLine("--------------------------------+-------------------------------+-------------------------------+-------------------------------");
            Console.WriteLine("                                |                               |                               |                               ");
            Console.WriteLine("--------------------------------+-------------------------------+-------------------------------+-------------------------------");
            Console.WriteLine("                                |                               |                               |                               ");
            Console.WriteLine("--------------------------------+-------------------------------+-------------------------------+-------------------------------");
            Console.WriteLine("                                |                               |                               |                               ");
            Console.WriteLine("--------------------------------+-------------------------------+-------------------------------+-------------------------------");
            Console.WriteLine("                                |                               |                               |                               ");
            Console.WriteLine(" - - - - - - - - - - - - - - - -|- - - - - - - - - - - - - - - -|- - - - - - - - - - - - - - - -|- - - - - - - - - - - - - - - -"); //C4
            Console.WriteLine("                                |                               |                               |                               ");
            Console.WriteLine("--------------------------------+-------------------------------+-------------------------------+-------------------------------");
            Console.WriteLine("                                |                               |                               |                               ");
            Console.WriteLine("--------------------------------+-------------------------------+-------------------------------+-------------------------------");
            Console.WriteLine("                                |                               |                               |                               ");
            Console.WriteLine("--------------------------------+-------------------------------+-------------------------------+-------------------------------");
            Console.WriteLine("                                |                               |                               |                               ");
            Console.WriteLine("--------------------------------+-------------------------------+-------------------------------+-------------------------------");
            Console.WriteLine("                                |                               |                               |                               ");
            Console.WriteLine("--------------------------------+-------------------------------+-------------------------------+-------------------------------");
            Console.WriteLine("                                |                               |                               |                               ");
            Console.WriteLine(" - - - - - - - - - - - - - - - -|- - - - - - - - - - - - - - - -|- - - - - - - - - - - - - - - -|- - - - - - - - - - - - - - - -");
            Console.WriteLine("                                |                               |                               |                               ");
            Console.WriteLine(" - - - - - - - - - - - - - - - -|- - - - - - - - - - - - - - - -|- - - - - - - - - - - - - - - -|- - - - - - - - - - - - - - - -");
            Console.WriteLine("                                |                               |                               |                               ");
            Console.WriteLine(" - - - - - - - - - - - - - - - -|- - - - - - - - - - - - - - - -|- - - - - - - - - - - - - - - -|- - - - - - - - - - - - - - - -"); //A1
            Console.WriteLine("");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("[P]řehrát");
            Console.WriteLine("[U]ložit");
            Console.WriteLine("[E]xport");
            Console.WriteLine("[M]ožnosti");
            Console.WriteLine("[O]dejít");
            Console.WriteLine("[R]eset");
        }

        private static void PrehrajPisnicku(PisenInfo pisen)
        {
            Console.Clear();
            Console.WriteLine("Přehrává se");
            pisen = new PisenInfo();
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
            Console.ReadKey(); 
        }
    }
    
    public class PisenInfo
    {
        private int rychlost;
        private List<Nota> noty;
		public PisenInfo()
        {
            rychlost = 130;
            noty = new List<Nota>();
        }
        public void Prehraj()
        {
            for (int x = 0; x < noty.Count; x++)
            {
                Console.Beep(noty[x].ton, noty[x].delka);
                if (x + 1 < noty.Count)
                {
                    int pauza = noty[x + 1].pozice - noty[x].pozice - noty[x].delka;
                    if (pauza > 0)
                        Thread.Sleep(pauza);
                }
            }
        }
        public void PridejNotu(Ton ton, Delka del, int pos)
        {
            Nota tempnota = new Nota(ton, del, pos);
            noty.Add(tempnota);
        }
        private class Nota
        {
            private Ton _ton;
            internal int ton { get { return (int)_ton; } }
            private Delka _delka;
            internal int delka { get { return (int)_delka; } }
            internal int pozice { get; }
            public Nota(Ton _ton, Delka _delka, int pos)
            {
                this._ton = _ton;
                this._delka = _delka;
                this.pozice = pos;
            }
        }
    }
}
