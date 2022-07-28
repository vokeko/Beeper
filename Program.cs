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
            Noty note = new Noty();
            Console.ReadKey();
            Console.Beep(note.notyNaFrekvenci[Noty.nota.C4], 300);
            Console.Beep(note.notyNaFrekvenci[Noty.nota.D4], 300);
            Console.Beep(note.notyNaFrekvenci[Noty.nota.E4], 300);
            Console.Beep(note.notyNaFrekvenci[Noty.nota.F4], 300);
            Console.Beep(note.notyNaFrekvenci[Noty.nota.G4], 300);
            Console.Beep(note.notyNaFrekvenci[Noty.nota.A4], 300);
            Console.Beep(note.notyNaFrekvenci[Noty.nota.H4], 300);
            Console.Beep(note.notyNaFrekvenci[Noty.nota.C5], 300);
            Console.ReadKey();
        }

        public class Noty
        {
            public Dictionary<nota, int> notyNaFrekvenci { get; }
            public Noty()
            {
                notyNaFrekvenci = new Dictionary<nota, int>()
                {
                    {nota.D1,37 },{nota.Eb1,39 },{ nota.E1, 41 },{nota.F1,44 },{nota.Gb1,46 },{nota.G1,49 },{nota.Ab1,52 }, {nota.A1,55 }, {nota.Hb1,58 }, {nota.H1,62 },
                         {nota.C2,65 },{nota.Db2,70 },{nota.D2,73 },{nota.Eb2,78 },{ nota.E2, 82 },{nota.F2,87 },{nota.Gb2,92 },{nota.G2,100 },{nota.Ab2,104 }, {nota.A2,110 }, {nota.Hb2,117 }, {nota.H2,123 },
                         {nota.C3,131 },{nota.Db3,139 },{nota.D3,147 },{nota.Eb3,156 },{ nota.E3, 165 },{nota.F3,175 },{nota.Gb3,185 },{nota.G3,196 },{nota.Ab3,208 }, {nota.A3,220 }, {nota.Hb3,233 }, {nota.H3,247 },
                         {nota.C4,262 },{nota.Db4,277 },{nota.D4,294 },{nota.Eb4,311 },{ nota.E4, 330 },{nota.F4,349 },{nota.Gb4,370 },{nota.G4,392 },{nota.Ab4,415 }, {nota.A4,440 }, {nota.Hb4,466 }, {nota.H4,494 },
                         {nota.C5,523 },{nota.Db5,554 },{nota.D5,587 },{nota.Eb5,622 },{ nota.E5, 659 },{nota.F5,698 },{nota.Gb5,740 },{nota.G5,784 },{nota.Ab5,831 }, {nota.A5,880 }, {nota.Hb5,932 }, {nota.H5,988 },
                         {nota.C6,1047 },{nota.Db6,1109 },{nota.D6,1175 },{nota.Eb6,1245 },{ nota.E6, 1319 },{nota.F6,1397 },{nota.Gb6,1480 },{nota.G6,1568 },{nota.Ab6,1661 }, {nota.A6,1760 }, {nota.Hb6,1865 }, {nota.H6,1976 },
                         {nota.C7,2093 },{nota.Db7,2217 },{nota.D7,2349 },{nota.Eb7,2489 },{ nota.E7, 2637 },{nota.F7,2794 },{nota.Gb7,2960 },{nota.G7,3136 },{nota.Ab7,3322 }, {nota.A7,3520 }, {nota.Hb7,3729 }, {nota.H7,3951 },
                         {nota.C8,4186 },{nota.Db8,4435 },{nota.D8,4699 },{nota.Eb8,4978 },{ nota.E8, 5274 },{nota.F8,5588 },{nota.Gb8,5919 },{nota.G8,6272 },{nota.Ab8,6645 }, {nota.A8,7040 }, {nota.Hb8,7459 }, {nota.H8,7902 },
                };
            }
            public enum nota
            {
                D1,
                Eb1,
                E1,
                F1,
                Gb1,
                G1,
                Ab1,
                A1,
                H1,
                Hb1,
                C2,
                Db2,
                D2,
                Eb2,
                E2,
                F2,
                Gb2,
                G2,
                Ab2,
                A2,
                Hb2,
                H2,
                C3,
                Db3,
                D3,
                Eb3,
                E3,
                F3,
                Gb3,
                G3,
                Ab3,
                A3,
                Hb3,
                H3,
                C4,
                Db4,
                D4,
                Eb4,
                E4,
                F4,
                Gb4,
                G4,
                Ab4,
                A4,
                Hb4,
                H4,
                C5,
                Db5,
                D5,
                Eb5,
                E5,
                F5,
                Gb5,
                G5,
                Ab5,
                A5,
                Hb5,
                H5,
                C6,
                Db6,
                D6,
                Eb6,
                E6,
                F6,
                Gb6,
                G6,
                Ab6,
                A6,
                Hb6,
                H6,
                C7,
                Db7,
                D7,
                Eb7,
                E7,
                F7,
                Gb7,
                G7,
                Ab7,
                A7,
                Hb7,
                H7,
                C8,
                Db8,
                D8,
                Eb8,
                E8,
                F8,
                Gb8,
                G8,
                Ab8,
                A8,
                Hb8,
                H8,
            }
        }
    }
}
