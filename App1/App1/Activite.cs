using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    internal class Activite
    {
        string nom;
        int idCategorie, idActivite;
        double coutOrgCli, coutVentCli;

        public Activite(int idactivite, string nom, int idCategorie, double coutOrgCli, double coutVentCli)
        {
            this.idActivite = idactivite;
            this.nom = nom;
            this.idCategorie = idCategorie;
            this.coutOrgCli = coutOrgCli;
            this.coutVentCli = coutVentCli;
        }

        public int IdActivite
        {
            get => idActivite;
            set => idActivite = value;
        }

        public string Nom
        {
            get => nom;
            set => nom = value;
        }

        public int IdCategorie
        {
            get => idCategorie;
            set => idCategorie = value;
        }

        public double CoutOrgCli
        {
            get => coutOrgCli;
            set => coutOrgCli = value;
        }

        public string CoutOrgCliString
        {
            get => $"Coût organiation : {CoutOrgCli} $";
      
        }
        public string CoutVentCliString
        {
            get => $"Coût vente : {CoutVentCli} $";

        }

        public string CoutVentAdhe
        {
            get => $"Coût : {CoutVentCli} $";

        }
        public double CoutVentCli
        {
            get => coutVentCli;
            set => coutVentCli = value;
        }

        public string StringCSV
        {
            get
            {
                return $"{IdActivite};{Nom};{IdCategorie};{CoutOrgCli};{CoutVentCli}";
            }
        }
        public int NbSceance
        {
            get => SingletonListe.getInstance().statActiv("nomActivite",Nom, "f_nbr_sceance_activite");
        }

        public int NbAdherent
        {
            get => SingletonListe.getInstance().statActiv("nomActivite", Nom, "f_nbr_adherent_activite");
        }

        public string NomCategorie
        {
            get => SingletonListe.getInstance().getNomCategorie(IdCategorie);
        }
        public string Note
        {
            
            get => (SingletonListe.getInstance().noteActivite(idActivite).ToString() == "") ? "Pas encore noté" : SingletonListe.getInstance().noteActivite(idActivite).ToString();
            
    }

    }
}
