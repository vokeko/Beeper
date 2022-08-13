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
}
