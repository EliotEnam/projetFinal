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

        public ObservableCollection<Adherent> afficherAdherents()
        {

            liste.Clear();
            ObservableCollection<Adherent> liste2 = new ObservableCollection<Adherent>();
            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select * from adherent";
            con.Open();
            commande.Prepare();
            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {
                string id = r[0].ToString();
                string nom = r.GetString(1);
                string prenom = r[2].ToString();
                string adr = r[3].ToString();
                string date = r[4].ToString();
                int age =Convert.ToInt32(r[5].ToString());

                Adherent adherent = new Adherent(id,nom,prenom,adr,date,age);

                liste2.Add(adherent);

            }

            r.Close();
            con.Close();
            return liste2;
        }

        public ObservableCollection<Sceance> afficherSceances()
        {

            liste.Clear();
            MySqlCommand commande = new MySqlCommand();
            ObservableCollection<Sceance> liste2 = new ObservableCollection<Sceance>();
            commande.Connection = con;
            commande.CommandText = "Select * from sceance";
            con.Open();
            commande.Prepare();
            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {
                int idSce = Convert.ToInt32(r[0].ToString());
                string date = r[1].ToString();
                string heure = r[2].ToString();
                int nbPlace = Convert.ToInt32(r[3].ToString());
                double note = Convert.ToDouble(r[4].ToString());
                int idAct = Convert.ToInt32(r[5].ToString());

                Sceance sceance = new Sceance(idSce, idAct, nbPlace, note, date,heure);

                liste2.Add(sceance);

            }

            r.Close();
            con.Close();
            return liste2;
        }

        public void ajoutAdherent(string lnom,string lprenom, string ladresse, string ldate)
        {

            string nom = lnom;
            string prenom = lprenom;
            string adresse = ladresse;
            string dateNaiss = ldate;

            try
            {
                MySqlCommand commande = new MySqlCommand("ajout_adherent");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                commande.Parameters.AddWithValue("@nom", nom);
                commande.Parameters.AddWithValue("@prenom", prenom);
                commande.Parameters.AddWithValue("@adresse", adresse);
                commande.Parameters.AddWithValue("@dateNaiss", dateNaiss);

                con.Open();
                commande.Prepare();
                commande.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }

        }
    }
}
