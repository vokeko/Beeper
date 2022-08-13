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
            Console.WindowHeight = 42;
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

    public static class PisnickaWindow
    {
        public static void ZobrazPisnicku(PisenInfo pisen)
        {
            ConsoleKeyInfo key;
            int xTotal = 0;
            short xPos = 0;
            short yPos = 0;
            Delka delka = Delka.Ctvrtina;
            if (pisen == null) pisen = new PisenInfo();
            
            do
            {
                VykresliPisnicku(pisen, xPos, yPos, xTotal);
                key = Console.ReadKey();
                switch(key.Key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        yPos--;
                        if (yPos < 0) yPos = 0;
                        break;
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        yPos++;
                        if (yPos > 32) yPos = 32;
                        break;
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        xPos -= 2; xTotal -= 2;
                        if (xPos < 0)
                        {
                            if (xTotal <= 0) xPos = 0;
                            else xPos = 126;
                        } 
                        if (xTotal < 0) xTotal = 0;
                        break;
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        xPos += 2; xTotal += 2;
                        if (xPos >= 128) xPos = 0;
                        break;
                    case ConsoleKey.Enter:
                        pisen.PridejNotu(yPos, delka, xTotal);
                        break;
                    case ConsoleKey.Delete:
                        pisen.OdeberNotu(xTotal, yPos);
                        break;
                    case ConsoleKey.Add:
                        delka = delka.Next();
                        break;
                    case ConsoleKey.Subtract:
                        delka = delka.Prev();
                        break;
                    case ConsoleKey.P:
                        PrehrajPisnicku(pisen);
                        break;
                    case ConsoleKey.U:
                        Console.Clear(); 
                        Console.WriteLine("Funkce není implementována"); 
                        Console.ReadKey(); //TO DO
                        break;
                    case ConsoleKey.M:
                        Menu.Nabidka(new string[3] { "Rychlost", "Tvůrce", "Zpět" });
                        break;
                    case ConsoleKey.E:
                        Console.Clear();
                        Console.WriteLine("Funkce není implementována");
                        Console.ReadKey(); //TO DO
                        break;
                    case ConsoleKey.R:
                        Console.Clear();
                        Console.WriteLine("Opravdu chcete vymazat celou písničku?!?");
                        Console.WriteLine("[A]no/[N]e");
                        var x = Console.ReadKey();
                        if (x.Key == ConsoleKey.A) pisen.VymazPisen();
                        break;
                }
            }
            while (key.Key != ConsoleKey.Z);
        }

        private static void VykresliPisnicku(PisenInfo pisen, short x, short y, int totalX)
        {
            Console.Clear();
            if (Console.WindowHeight < 42) Console.WindowHeight = 42;
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

            //Naplnění existujícími notami
            //var noticky = pisen.Noty.Where(z => Math.Floor((double)z.Delka / 12800) == Math.Floor((double)totalX / 128));
            foreach (Nota nota in pisen.Noty)
            {
                //TO DO: Vykreslování pro jen ty noty, které jsou zrovna na obrazovce, ne všechny
                //if (nota.Pozice) continue;
                //TO DO: nefunguje při překročení
                //TO DO: označení pro dlouhé noty
                Console.SetCursorPosition(nota.Pozice / 100, nota.Ton);
                Console.Write("#♪");
            }

            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("#♪");
            Console.ResetColor();
        }

        private static void PrehrajPisnicku(PisenInfo pisen)
        {
            Console.Clear();
            Console.WriteLine("Přehrává se");
            pisen.Prehraj();
            Console.WriteLine("Hotovo!");
            Console.ReadKey();
        }
    }
    
    public class PisenInfo
    {
        //TO DO: plnění rychlosti a tvůrce
        private int rychlost;
        private string tvurce;
        public List<Nota> Noty { get; private set; }
		public PisenInfo()
        {
            rychlost = 130;
            tvurce = default;
            Noty = new List<Nota>();
        }
        public void Prehraj()
        {
            Noty = Noty.OrderBy(x => x.Pozice).ToList();
            for (int x = 0; x < Noty.Count; x++)
            {
                Console.Beep(Noty[x].Ton, Noty[x].Delka);
                if (x + 1 < Noty.Count)
                {
                    int pauza = Noty[x + 1].Pozice - Noty[x].Pozice - Noty[x].Delka;
                    if (pauza > 0)
                        Thread.Sleep(pauza);
                }
            }
        }
        public void PridejNotu(Ton ton, Delka del, int pos)
        {
            //pos *= 100;
            Nota tempnota = new Nota(ton, del, pos);
            if (Noty.Contains(tempnota)) return;
            Noty.Add(tempnota);
        }
        public void PridejNotu(int y, Delka del, int pos)
        {
            pos *= 100;
            Nota tempnota = new Nota((Ton)y, del, pos);
            //to do y na ton
            if (Noty.Contains(tempnota)) return;
            Noty.Add(tempnota);
        }
        public void OdeberNotu(int x, int y)
        {
            x *= 100;
            Noty.RemoveAll(z => z.Ton == y && z.Pozice == x);
        }
        public void VymazPisen()
        {
            Noty.Clear();
        }
    }
    public class Nota
    {
        private readonly Ton _ton;
        internal int Ton { get { return (int)_ton; } }
        private readonly Delka _delka;
        internal int Delka { get { return (int)_delka; } }
        internal int Pozice { get; }
        public Nota(Ton _ton, Delka _delka, int pos)
        {
            this._ton = _ton;
            this._delka = _delka;
            this.Pozice = pos;
        }
    }
}
