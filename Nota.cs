using System;

namespace Beeper
{
    [Serializable]
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
