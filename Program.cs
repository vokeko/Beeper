using System;
using System.Text;

namespace Beeper
{
    internal class Program
    {
        [STAThread] static void Main()
        {
            Console.Title = "Beeper - pípací skladatel";
            Console.OutputEncoding = Encoding.UTF8;
            Console.WindowHeight = 43;
            Console.WindowWidth = 129;
            string[] polozky = new string[5] { "Nová písnička", "Nahrát", "Hrát písničku", "Info", "Odejít" };
            bool exit = false;
            while (!exit)
            {
                exit = Menu.Nabidka(polozky, new PisenInfo());
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
        Asharp1 = 58, //A#1
        H1 = 62, //H1
        C2 = 65, //C2
        Csharp2 = 70, //C#2
        D2 = 73, //D2
        Dsharp2 = 78, //D#2
        E2 = 82, //E2
        F2 = 87, //F2
        Fsharp2 = 92, //F#2
        G2 = 100, //G2
        Gsharp2 = 104, //G#2
        A2 = 110, //A2
        Asharp2 = 117, //A#2
        H2 = 123, //H2
        C3 = 131, //C3
        Csharp3 = 139, //C#3
        D3 = 147, //D3
        Dsharp3 = 156,
        E3 = 165,
        F3 = 175,
        Fsharp3 = 185,
        G3 = 196,
        Gsharp3 = 208,
        A3 = 220,
        Asharp3 = 233,
        H3 = 247,
        C4 = 262,
        Csharp4 = 277,
        D4 = 294,
        Dsharp4 = 311,
        E4 = 330,
        F4 = 349,
        Fsharp4 = 370,
        G4 = 392,
        Gsharp4 = 415,
        A4 = 440,
        Asharp4 = 466,
        H4 = 494,
        C5 = 523,
        Csharp5 = 554,
        D5 = 587,
        Dsharp5 = 622,
        E5 = 659,
        F5 = 698,
        Fsharp5 = 740,
        G5 = 784,
        Gsharp5 = 831,
        A5 = 880,
        Asharp5 = 932,
        H5 = 988,
        C6 = 1047,
        Csharp6 = 1109,
        D6 = 1175,
        Dsharp6 = 1245,
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
        //150 > 1600
        //100>2400
        Celá = 2400,
        Půlka = Celá / 2,
        Čtvrtina = Půlka / 2,
        Osmina = Čtvrtina / 2,
        Šestnáctina = Osmina / 2,
    }
}
