using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    internal class ParticipationSceance
    {
        string idAdherent; int idSceance; double noteApprecaiation;

        public ParticipationSceance(string idAdherent, int idSceance, double noteApprecaiation)
        {
            this.idAdherent = idAdherent;
            this.idSceance = idSceance;
            this.noteApprecaiation = noteApprecaiation;
        }
        public string IdAdherent { get => idAdherent; set => idAdherent = value; }
        public int IdSceance
        {
            get => idSceance;
            set => idSceance = value;
        }
        public double NoteApprecaiation { get => noteApprecaiation; set => noteApprecaiation = value; }

        //public string Activite { get => }
    }
}
