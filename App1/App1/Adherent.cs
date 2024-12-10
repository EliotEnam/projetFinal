using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    internal class Adherent
    {
        string id, nom, prenom, adresse, dateNaiss;
        int age;

        public Adherent(string id, string nom, string prenom, string adresse, string dateNaiss, int age)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.adresse = adresse;
            this.dateNaiss = dateNaiss.Substring(0,11);
            this.age = age;
        }

        public string Id
        {
            get => id;
            set => id = value; 
        }
        public int Age { get => age; set => age = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public string DateNaiss { get => dateNaiss; set => dateNaiss = value; }
        public string Nom { get => nom; set => nom = value; }

        public string StringCSV
        {
            get
            {
                return $"{Id};{Nom};{Prenom};{Adresse};{DateNaiss};{Age}";
            }
        }
    }
}
