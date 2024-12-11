using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;
using static Mysqlx.Expect.Open.Types.Condition.Types;

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

        public ObservableCollection<Sceance> afficherSeancesParActiv(int lid)
        {
            int idt = lid;
            ObservableCollection<Sceance> liste2 = new ObservableCollection<Sceance>();
            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select * from sceance where idActivite = @idActivite";
            commande.Parameters.AddWithValue("@idActivite", idt);
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

                Sceance sceance = new Sceance(idSce, idAct, nbPlace, note, date, heure);

                liste2.Add(sceance);

            }

            r.Close();
            con.Close();
            return liste2;
        }
        public ObservableCollection<Sceance> afficherSeancesParAdherent(string lid)
        {
            string idt = lid;
            ObservableCollection<Sceance> liste2 = new ObservableCollection<Sceance>();
            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select * from sceance where idSceance in (select idSceance from participationsceance where idAdherent = @idAdherent)";
            commande.Parameters.AddWithValue("@idAdherent", idt);
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

                Sceance sceance = new Sceance(idSce, idAct, nbPlace, note, date, heure);

                liste2.Add(sceance);

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

        public void ListeCategorie(ComboBox cbx)
        {

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select nomCategorie,idCategorie from categorie";
            con.Open();
            commande.Prepare();
            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {
                string nom = r[0].ToString();
                string ID = r[1].ToString();
                cbx.Items.Add(nom);
                cbx.Name = ID;

            }

            r.Close();
            con.Close();
        }

        public void ListeActivite(ComboBox cbx)
        {

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select nom from activite";
            con.Open();
            commande.Prepare();
            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {
                string nom = r[0].ToString();
                cbx.Items.Add(nom);

            }

            r.Close();
            con.Close();
        }


        public int getIdCategorie(string lnom)
        {
            string nom = lnom;
            int id = 0;
            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select f_idCat(@lnomCategorie)";
            commande.Parameters.AddWithValue("@lnomCategorie", nom);
            con.Open();
            commande.Prepare();
            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {
                id = Convert.ToInt32(r[0].ToString());
              
            }

            r.Close();
            con.Close();
            return id;
        }

        public int getIdActivite(string lnom)
        {
            string nom = lnom;
            int id = 0;
            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select f_id_act(@lnom)";
            commande.Parameters.AddWithValue("@lnom", nom);
            con.Open();
            commande.Prepare();
            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {
                id = Convert.ToInt32(r[0].ToString());

            }

            r.Close();
            con.Close();
            return id;
        }
        public string getNomCategorie(int lid)
        {
            int id = lid;
            string nom = "";
            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select f_nomcat(@lid)";
            commande.Parameters.AddWithValue("@lid", id);
            con.Open();
            commande.Prepare();
            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {
                nom = r[0].ToString();

            }

            r.Close();
            con.Close();
            return nom;
        }

        public string getNomActivite(int lid)
        {
            int id = lid;
            string nom = "";
            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select f_nomActiv(@lid)";
            commande.Parameters.AddWithValue("@lid", id);
            con.Open();
            commande.Prepare();
            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {
                nom = r[0].ToString();

            }

            r.Close();
            con.Close();
            return nom;
        }

        public string connexionAdherent(string lid)
        {
            string id = lid;
            string nom = "";
            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select f_sonnec_adher(@lid)";
            commande.Parameters.AddWithValue("@lid", id);
            con.Open();
            commande.Prepare();
            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {
        
                    nom = r[0].ToString();
               

            }

            r.Close();
            con.Close();
            return nom;
        }

        public string connexionAdmin(string lnom, string lpass)
        {
            string id= "";
            string nom = lnom;
            string pass = lpass;
            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select f_sonnec_admin(@lnom,@pass)";
            commande.Parameters.AddWithValue("@lnom", nom);
            commande.Parameters.AddWithValue("@pass", pass);
            con.Open();
            commande.Prepare();
            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {

                id = r[0].ToString();


            }

            r.Close();
            con.Close();
            return id;
        }

        public double noteActiv(int lidSce, string lidAd)
        {
            int idSce = lidSce;
            string idAd = lidAd;
            double note = 0;
            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select f_note(@lidSe,@lidAd)";
            commande.Parameters.AddWithValue("@lidSe", idSce);
            commande.Parameters.AddWithValue("@lidAd", idAd);
            con.Open();
            commande.Prepare();
            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {

                note = Convert.ToDouble(r[0].ToString());


            }

            r.Close();
            con.Close();
            return note;
        }
        public string adherenDejaParticip(string lidAd, int lidAc)
        {
            string idA = lidAd;
            int idAc = lidAc;
            string nom = "";
            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select f_adherent_deja_activite(@lidA, @lidActivite)";
            commande.Parameters.AddWithValue("@lidA", idA);
            commande.Parameters.AddWithValue("@lidActivite", idAc);
            con.Open();
            commande.Prepare();
            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {

                nom = r[0].ToString();


            }

            r.Close();
            con.Close();
            return nom;
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
                commande.Parameters.AddWithValue("@lnom", nom);
                commande.Parameters.AddWithValue("@lprenom", prenom);
                commande.Parameters.AddWithValue("@laddresse", adresse);
                commande.Parameters.AddWithValue("@ldatenaiss", dateNaiss);

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

        public void ajoutParticipSceance(int lidSce, string lidAd)
        {

            int idSce = lidSce;
            string idAd = lidAd;
            double note = 0;
         

            try
            {
                MySqlCommand commande = new MySqlCommand("ajout_particip_sceance");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                commande.Parameters.AddWithValue("@lidSceance", idSce);
                commande.Parameters.AddWithValue("@lidAdherent", idAd);
                commande.Parameters.AddWithValue("@lnoteAppreciation", note);

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

        public void ajoutActivite(string lnom, double lco, double lcv, int lcat,int lnb, string ldate)
        {

            string nom = lnom;
            double co = lco;
            double cv = lcv;
            int cat = lcat;
            int nb = lnb;
            string dateDebut = ldate;

            try
            {
                MySqlCommand commande = new MySqlCommand("ajout_activite");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                commande.Parameters.AddWithValue("@lnom", nom);
                commande.Parameters.AddWithValue("@lcouOrg", co);
                commande.Parameters.AddWithValue("@lcoutVente", cv);
                commande.Parameters.AddWithValue("@lidCategorie", cat);
                commande.Parameters.AddWithValue("@nbSceance", nb);
                commande.Parameters.AddWithValue("@dateDebut", dateDebut);

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

        public void supprimer( string lid, string nomProcedure)
        {

            string id = lid;
            string nom = nomProcedure;
   
           
            try
            {
                MySqlCommand commande = new MySqlCommand(nom);
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                commande.Parameters.AddWithValue("@id", id);

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

        public void modActivite(int idA, string lnom,double co,double cv, int idca)
        {

            int idAc = idA;
            string nom = lnom;
            double coAc = co;
            double cvAc = cv;
            int idcaAc = idca;


            try
            {
                MySqlCommand commande = new MySqlCommand("ModActivite");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                commande.Parameters.AddWithValue("@lidActivite", idAc);
                commande.Parameters.AddWithValue("@lnom", nom);
                commande.Parameters.AddWithValue("@lcoutOrgCli", coAc);
                commande.Parameters.AddWithValue("@lcoutVentCli", cvAc);
                commande.Parameters.AddWithValue("@lidCategorie", idcaAc);

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

        public void modAdherent(string lid, string lnom, string lprenom, string ladresse, string ldateNaiss)
        {

            string id = lid;
            string nom = lnom;
            string prenom = lprenom;
            string adresse = ladresse;
            string date = ldateNaiss;


            try
            {
                MySqlCommand commande = new MySqlCommand("ModAdherent");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                commande.Parameters.AddWithValue("@lidAdherent", id);
                commande.Parameters.AddWithValue("@lnom", nom);
                commande.Parameters.AddWithValue("@lprenom", prenom);
                commande.Parameters.AddWithValue("@ladresse", adresse);
                commande.Parameters.AddWithValue("@ldateNaiss", date);

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

        public void modSceance(int lid, string ldate, string lheure, int lnb)
        {

            int id = lid;
            string date = ldate;
            string heure = lheure;
            int nb = lnb;
    


            try
            {
                MySqlCommand commande = new MySqlCommand("ModSceance");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                commande.Parameters.AddWithValue("@lidSceance", id);
                commande.Parameters.AddWithValue("@ldate", date);
                commande.Parameters.AddWithValue("@lheure", heure);
                commande.Parameters.AddWithValue("@lnbPlaceDispo", nb);
   

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
        public void noteParticipation(int lidSce, string lidAdhe, double note)
        {

            int idS = lidSce;
            string idA = lidAdhe;
            double not = note;
            try
            {
                MySqlCommand commande = new MySqlCommand("p_Noter");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                commande.Parameters.AddWithValue("@lidSceance", idS);
                commande.Parameters.AddWithValue("@lidAdherent", idA);
                commande.Parameters.AddWithValue("@lnote", not);
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
        public int statActiv(string lkey, string lval, string lfname)
        {

            string key = lkey;
            string val = lval;
            string fname = lfname;
            int nbr = 0;


            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = $"Select {fname}(@{key})";
            commande.Parameters.AddWithValue($"@{key}", val);
            con.Open();
            commande.Prepare();
            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {
                nbr = Convert.ToInt32(r[0].ToString());

            }

            r.Close();
            con.Close();
            return nbr;
        }
        public string noteActivite(int lid)
        {

            int id = lid;

            string nbr = "";


            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = $"Select f_noteActivi(@lid)";
            commande.Parameters.AddWithValue($"@lid", id);
            con.Open();
            commande.ExecuteScalar().ToString();
            nbr = commande.ExecuteScalar().ToString();
            con.Close();
            return nbr;

        }

        public string vues(string lvue)
        {

            string vue = lvue;

            string nbr = "";

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = $"Select * from {vue}";
            con.Open();
            commande.Prepare();
            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {
                nbr = r[0].ToString();

            }

            r.Close();
            con.Close();
            return nbr;

        }


    }
}
