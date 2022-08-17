using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Beeper
{
    public class PisenInfo
    {
        public int rychlost { private get; set; }
        public string tvurce { private get; set; }
        public string nazev { private get; set; }
        public Dictionary<float, Ton> YNaTon { get; }
        public List<Nota> Noty { get; private set; }
        public PisenInfo()
        {
            rychlost = 100;
            tvurce = "Neznámý";
            nazev = "pisen";
            Noty = new List<Nota>();
            YNaTon = new Dictionary<float, Ton>() 
            { 
                { 0, Ton.E6 }, { 0.5F, Ton.Dsharp6 }, { 1, Ton.D6 }, { 1.5F, Ton.Csharp6 }, { 2, Ton.C6 }, { 3, Ton.H5 }, { 3.5F, Ton.Asharp5 }, { 4, Ton.A5 }, { 4.5F, Ton.Gsharp5 }, { 5, Ton.G5 }, { 5.5F, Ton.Fsharp5 }, { 6, Ton.F5 },
                { 7, Ton.E5 }, { 7.5F, Ton.Dsharp5 }, { 8, Ton.D5 }, { 8.5F, Ton.Csharp5 }, { 9, Ton.C5 }, {10, Ton.H4 }, {10.5F, Ton.Asharp4 }, {11, Ton.A4 }, {11.5F, Ton.Gsharp4 }, {12, Ton.G4 }, { 12.5F, Ton.Fsharp4 }, {13, Ton.F4 },
                {14, Ton.E4 }, {14.5F, Ton.Dsharp4 }, {15, Ton.D4 }, {15.5F, Ton.Csharp4 }, {16, Ton.C4 }, {17, Ton.H3 }, {17.5F, Ton.Asharp3 }, {18, Ton.A3 }, {18.5F, Ton.Gsharp3 }, {19, Ton.G3 }, { 19.5F, Ton.Fsharp3 }, {20, Ton.F3 },
                {21, Ton.E3 }, {21.5F, Ton.Dsharp3 }, {22, Ton.D3 }, {22.5F, Ton.Csharp3 }, {23, Ton.C3 }, {24, Ton.H2 }, {24.5F, Ton.Asharp2 }, {25, Ton.A2 }, {25.5F, Ton.Gsharp2 }, {26, Ton.G2 }, { 26.5F, Ton.Fsharp2 }, {27, Ton.F2 },
                {28, Ton.E2 }, {28.5F, Ton.Dsharp2 }, {29, Ton.D2 }, {29.5F, Ton.Csharp2 }, {30, Ton.C2 }, {31, Ton.H1 }, {31.5F, Ton.Asharp1 }, {32, Ton.A1 }
            };
        }
        public void Prehraj()
        {
            Console.WriteLine("Název: {0}", nazev);
            Console.WriteLine("Tvůrce: {0}", tvurce);
            Console.WriteLine("Rychlost: {0}", rychlost);
            Noty = Noty.OrderBy(x => x.Pozice).ToList();
            float trvani = rychlost / 100F;
            for (int x = 0; x < Noty.Count; x++)
            {
                Console.Beep(Noty[x].Ton, (int)Math.Floor(Noty[x].Delka / trvani));
                if (x + 1 < Noty.Count)
                {
                    var pauza = (Noty[x + 1].Pozice / trvani) - (Noty[x].Pozice / trvani) - (Noty[x].Delka / trvani);
                    if (pauza > 0)
                        Thread.Sleep((int)Math.Floor(pauza));
                }
            }
        }
        public void PridejNotu(Ton ton, Delka del, int pos)
        {
            Nota tempnota = new Nota(ton, del, pos);
            if (Noty.Contains(tempnota)) return;
            Noty.Add(tempnota);
        }
        public void PridejNotu(int y, Delka del, int pos, bool krizek)
        {
            pos *= 100;
            Ton ton = YNaTon[y];
            if (krizek) ton = ton.Next();
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
