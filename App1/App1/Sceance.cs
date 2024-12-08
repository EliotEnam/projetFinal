 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    internal class Sceance
    {
        int idSce, idAct, nbplace;
        double note;
        string date, heure;

        public Sceance(int idSce, int idAct, int nbplace, double note, string date, string heure)
        {
            this.idSce = idSce;
            this.idAct = idAct;
            this.nbplace = nbplace;
            this.note = note;
            this.date = date.Substring(0,11);
            this.heure = heure;
        }

        public int IdSce { get => idSce; set => idSce = value; }    
        public int IdAct { get => idAct; set => idAct = value; } 
        public double Note { get => note; set => note = value; }
        public string Date { get => date; set => date = value; }
        public int Nbplace { get => nbplace; set => nbplace = value; } 
        public string Heure { get => heure; set => heure = value; }

        public string NomActiv { get => SingletonListe.getInstance().getNomActivite(idAct); }

        public double NoteParAdherent { get => SingletonListe.getInstance().noteActiv(IdSce, SessionUsager.IdAdherent); }
    }
}
