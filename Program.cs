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
            Console.ReadKey();
            Console.Beep(notyNaFrekvenci[Noty.C4], 300);
            Console.Beep(notyNaFrekvenci[Noty.D4], 300);
            Console.Beep(notyNaFrekvenci[Noty.E4], 300);
            Console.Beep(notyNaFrekvenci[Noty.F4], 300);
            Console.Beep(notyNaFrekvenci[Noty.G4], 300);
            Console.Beep(notyNaFrekvenci[Noty.A4], 300);
            Console.Beep(notyNaFrekvenci[Noty.H4], 300);
            Console.Beep(notyNaFrekvenci[Noty.C5], 300);
            Console.ReadKey();
        }

        private enum Noty
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

        static Dictionary<Noty, int> notyNaFrekvenci = new Dictionary<Noty, int>()
        {
            {Noty.D1,37 },{Noty.Eb1,39 },{ Noty.E1, 41 },{Noty.F1,44 },{Noty.Gb1,46 },{Noty.G1,49 },{Noty.Ab1,52 }, {Noty.A1,55 }, {Noty.Hb1,58 }, {Noty.H1,62 },
                 {Noty.C2,65 },{Noty.Db2,70 },{Noty.D2,73 },{Noty.Eb2,78 },{ Noty.E2, 82 },{Noty.F2,87 },{Noty.Gb2,92 },{Noty.G2,100 },{Noty.Ab2,104 }, {Noty.A2,110 }, {Noty.Hb2,117 }, {Noty.H2,123 },
                 {Noty.C3,131 },{Noty.Db3,139 },{Noty.D3,147 },{Noty.Eb3,156 },{ Noty.E3, 165 },{Noty.F3,175 },{Noty.Gb3,185 },{Noty.G3,196 },{Noty.Ab3,208 }, {Noty.A3,220 }, {Noty.Hb3,233 }, {Noty.H3,247 },
                 {Noty.C4,262 },{Noty.Db4,277 },{Noty.D4,294 },{Noty.Eb4,311 },{ Noty.E4, 330 },{Noty.F4,349 },{Noty.Gb4,370 },{Noty.G4,392 },{Noty.Ab4,415 }, {Noty.A4,440 }, {Noty.Hb4,466 }, {Noty.H4,494 },
                 {Noty.C5,523 },{Noty.Db5,554 },{Noty.D5,587 },{Noty.Eb5,622 },{ Noty.E5, 659 },{Noty.F5,698 },{Noty.Gb5,740 },{Noty.G5,784 },{Noty.Ab5,831 }, {Noty.A5,880 }, {Noty.Hb5,932 }, {Noty.H5,988 },
                 {Noty.C6,1047 },{Noty.Db6,1109 },{Noty.D6,1175 },{Noty.Eb6,1245 },{ Noty.E6, 1319 },{Noty.F6,1397 },{Noty.Gb6,1480 },{Noty.G6,1568 },{Noty.Ab6,1661 }, {Noty.A6,1760 }, {Noty.Hb6,1865 }, {Noty.H6,1976 },
                 {Noty.C7,2093 },{Noty.Db7,2217 },{Noty.D7,2349 },{Noty.Eb7,2489 },{ Noty.E7, 2637 },{Noty.F7,2794 },{Noty.Gb7,2960 },{Noty.G7,3136 },{Noty.Ab7,3322 }, {Noty.A7,3520 }, {Noty.Hb7,3729 }, {Noty.H7,3951 },
                 {Noty.C8,4186 },{Noty.Db8,4435 },{Noty.D8,4699 },{Noty.Eb8,4978 },{ Noty.E8, 5274 },{Noty.F8,5588 },{Noty.Gb8,5919 },{Noty.G8,6272 },{Noty.Ab8,6645 }, {Noty.A8,7040 }, {Noty.Hb8,7459 }, {Noty.H8,7902 },
        };
    }
}
