using System;
using System.Text;

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
}
