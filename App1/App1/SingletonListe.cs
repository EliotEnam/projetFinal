using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    internal class SingletonListe
    {
        ObservableCollection<Activite> liste;
        static SingletonListe instance = null;
        MySqlConnection con = new MySqlConnection("Server=cours.cegep3r.info;Database=a2024_420335ri_eq9;Uid=6236158;Pwd=6236158;");

        public SingletonListe()
        {
            liste = new ObservableCollection<Activite>();
        }
        public static SingletonListe getInstance()
        {
            if (instance == null)
                instance = new SingletonListe();

            return instance;
        }

        public ObservableCollection<Activite> Liste { get { return liste; } }

        public void afficherActivites()
        {

            liste.Clear();
            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select * from activite";
            con.Open();
            commande.Prepare();
            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {
                int idActivite = Convert.ToInt32(r[0].ToString());
                string nom = r.GetString(1);
                double org = Convert.ToDouble(r[2].ToString());
                double vent = Convert.ToDouble(r[3].ToString());
                int cat = Convert.ToInt32(r[4].ToString());

                Activite activite = new Activite(idActivite, nom, cat, org, vent);

                liste.Add(activite);

            }

            r.Close();
            con.Close();
        }

        public void afficherAdherents()
        {

            liste.Clear();
            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select * from adherent";
            con.Open();
            commande.Prepare();
            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {
                int idActivite = Convert.ToInt32(r[0].ToString());
                string nom = r.GetString(1);
                double org = Convert.ToDouble(r[2].ToString());
                double vent = Convert.ToDouble(r[3].ToString());
                int cat = Convert.ToInt32(r[4].ToString());

                Activite activite = new Activite(idActivite, nom, cat, org, vent);

                liste.Add(activite);

            }

            r.Close();
            con.Close();
        }

        public void afficherSceances()
        {

            liste.Clear();
            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select * from sceance";
            con.Open();
            commande.Prepare();
            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {
                int idActivite = Convert.ToInt32(r[0].ToString());
                string nom = r.GetString(1);
                double org = Convert.ToDouble(r[2].ToString());
                double vent = Convert.ToDouble(r[3].ToString());
                int cat = Convert.ToInt32(r[4].ToString());

                Activite activite = new Activite(idActivite, nom, cat, org, vent);

                liste.Add(activite);

            }

            r.Close();
            con.Close();
        }
    }
}
