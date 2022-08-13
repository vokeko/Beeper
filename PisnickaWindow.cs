using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beeper
{
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
                switch (key.Key)
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
            Console.WriteLine("[Z]pět");
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
}
