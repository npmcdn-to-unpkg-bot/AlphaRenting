using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlphaRenting
{
    public class Comedien
    {
        private int _id;
        private string _nom;
        private string _prenom;
        private string _adresse_mail;
        private string _password;
        private char _secteur;
        private int _age;
        private char _sexe;
        private int _departement;
        private int _video_id;
        private int _photoid_;
        private string _cv;

        public int GetId()
        {
            return this._id;
        }
        public void SetId(int id)
        {
            this._id = id;
        }

        public string GetNom()
        {
            return this._nom;
        }
        public void SetNom(string nom)
        {
            this._nom = nom;
        }

        public string GetPrenom()
        {
            return this._prenom;
        }
        public void SetPrenom(string prenom)
        {
            this._prenom = prenom;
        }

        public string GetMail()
        {
            return this._prenom;
        }
        public void SetMail(string mail)
        {
            this._adresse_mail = mail;
        }

        public string GetPassword()
        {
            return this._password;
        }
        public void SetPassword(string password)
        {
            this._password = PasswordHelper.HashPassword(password);
        }

        public char GetSecteur()
        {
            return this._secteur;
        }
        public void SetSecteur(char secteur)
        {
            this._secteur = secteur;
        }

        public int GetAge()
        {
            return this._age;
        }
        public void SetAge(int age)
        {
            this._age = age;
        }

        public char GetSexe()
        {
            return this._sexe;
        }
        public void SetSexe(char sexe)
        {
            this._sexe = sexe;
        }

        public int GetDepartement()
        {
            return this._departement;
        }
        public void SetDepartement(int departement)
        {
            this._departement = departement;
        }

        public void InitObjectFromCrendentials(string mail, string password)
        {
            MySqlDataReader mdr = DB.ExecuteReader("SELECT id, password from comedien WHERE mail=@p1", mail);
            int id = 0;
            string correctHash = null;
            using (mdr)
            {
                if (mdr.HasRows)
                {
                    mdr.Read();
                    id = Convert.ToInt32(mdr[0]);
                    correctHash = mdr[1] as string;
                }
                else
                    return;
            }
            if(id>0)
            {
                if(PasswordHelper.ValidatePassword(password, correctHash))
                    InitObjectFromId(id);
            }
        }

        public void InitObjectFromId(int id)
        {
            MySqlDataReader mdr = DB.Select("comedien", "*", "id", id);
            using (mdr)
            {
                if(mdr.HasRows)
                {
                    mdr.Read();
                    this._id = Convert.ToInt32(mdr["id"]);
                    this._nom = mdr["nom"] as string;
                    this._prenom = mdr["prenom"] as string;
                    this._adresse_mail = mdr["adresse_mail"] as string;
                    this._password = mdr["password"] as string;
                    this._secteur = Convert.ToChar(mdr["secteur"]);
                    this._age = Convert.ToInt32(mdr["age"]);
                    this._sexe = Convert.ToChar(mdr["sexe"]);
                    this._departement = Convert.ToInt32(mdr["departement"]);
                }
            }
        }
    }
}