using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Beeper
{
    public class PisenInfo
    {
        //TO DO: plnění rychlosti a tvůrce
        private int rychlost;
        private string tvurce;
        public Dictionary<float, Ton> YNaTon { get; }
        public List<Nota> Noty { get; private set; }
        public PisenInfo()
        {
            rychlost = 130;
            tvurce = default;
            Noty = new List<Nota>();
            YNaTon = new Dictionary<float, Ton>() 
            { 
                { 0, Ton.E6 }, { 1, Ton.D6 }, { 2, Ton.C6 }, { 3, Ton.H5 }, { 4, Ton.A5 }, { 5, Ton.G5 }, { 6, Ton.F5 },
                { 7, Ton.E5 }, { 8, Ton.D5 }, { 9, Ton.C5 }, {10, Ton.H4 }, {11, Ton.A4 }, {12, Ton.G4 }, {13, Ton.F4 },
                {14, Ton.E4 }, {15, Ton.D4 }, {16, Ton.C4 }, {17, Ton.H3 }, {18, Ton.A3 }, {19, Ton.G3 }, {20, Ton.F3 },
                {21, Ton.E3 }, {22, Ton.D3 }, {23, Ton.C3 }, {24, Ton.H2 }, {25, Ton.A2 }, {26, Ton.G2 }, {27, Ton.F2 },
                {28, Ton.E2 }, {29, Ton.D2 }, {30, Ton.C2 }, {31, Ton.H1 }, {32, Ton.A1 }
            };
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
            Ton ton = YNaTon[y];
            Nota tempnota = new Nota(ton, del, pos);
            if (Noty.Contains(tempnota)) return;
            Noty.RemoveAll(z => z.Pozice == pos);
            Noty.Add(tempnota);
        }
        public void OdeberNotu(int x, int y)
        {
            x *= 100;
            Noty.RemoveAll(z => z.Pozice == x);
            //Noty.RemoveAll(z => z.Ton == y && z.Pozice == x);
        }
        public void VymazPisen()
        {
            Noty.Clear();
        }
    }
}
