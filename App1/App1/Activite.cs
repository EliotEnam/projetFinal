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
        public double CoutVentCli
        {
            get => coutVentCli;
            set => coutVentCli = value;
        }



    }
}
