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
        private string _video_url;
        private string _photo_url;
        private string _cv_url;
        private int _survey_id;
        private bool _is_complete;

        public int Id
        {
            get
            {
                return this._id; 
            }
            set
            {
                this._id = value;
            }
        }
        public string Nom
        {
            get
            {
                return this._nom;
            }
            set
            {
                this._nom = value;
            }
        }
        public string Prenom
        {
            get
            {
                return this._prenom;
            }
            set
            {
                this._prenom = value;
            }
        }
        public string Mail
        {
            get
            {
                return this._adresse_mail;
            }
            set
            {
                this._adresse_mail = value;
            }
        }
        public string Password
        {
            get
            {
                return this._password;
            }
            set
            {
                if (value != "")
                    this._password = PasswordHelper.HashPassword(value);
                else
                    this._password = "";
            }
        }
        public char Secteur
        {
            get
            {
                return this._secteur;
            }
            set
            {
                this._secteur = value;
            }
        }
        public int Age
        {
            get
            {
                return this._age;
            }
            set
            {
                this._age = value;
            }
        }
        public char Sexe
        {
            get
            {
                return this._sexe;
            }
            set
            {
                this._sexe = value;
            }
        }
        public int Departement
        {
            get
            {
                return this._departement;
            }
            set
            {
                this._departement = value;
            }
        }
        public string Video
        {
            get
            {
                return this._video_url;
            }
            set
            {
                this._video_url = value;
            }
        }
        public string Photo
        {
            get
            {
                return this._photo_url;
            }
            set
            {
                this._photo_url = value;
            }
        }
        public string Cv
        {
            get
            {
                return this._cv_url;
            }
            set
            {
                this._cv_url = value;
            }
        }
        public int Survey
        {
            get
            {
                return this._survey_id;
            }
            set
            {
                this._survey_id = value;
            }
        }
        public bool Complete
        {
            get
            {
                return this._is_complete;
            }
            set
            {
                this._is_complete = value;
            }
        }

        public Comedien()
        {
            this._is_complete = false;
            this._survey_id = 0;
        }

        public bool Synchronize()
        {
            if (DB.Update("Comedien", "nom,prenom,secteur,age,sexe,departement,cv_url,photo_url,video_url,survey_id,has_complete_registration","id",
                this._nom,this._prenom,this._secteur,this._age,this._sexe,this._departement,this._cv_url,this._photo_url,this._video_url,this._survey_id,this._is_complete, this._id))
                return true;
            return false;
        }

        public void InitObjectFromCrendentials(string mail, string password)
        {
            MySqlDataReader mdr = DB.ExecuteReader("SELECT id, password from comedien WHERE adresse_mail=@p1", mail);
            int id = 0;
            string correctHash = null;
            using (mdr)
            {
                if (mdr != null)
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
                    this._cv_url = mdr["cv_url"] as string;
                    this._photo_url = mdr["photo_url"] as string;
                    this._video_url = mdr["video_url"] as string;
                    this._survey_id = Convert.ToInt32(mdr["survey_id"]);
                    this._is_complete = Convert.ToBoolean(mdr["has_complete_registration"]);
                }
            }
        }
    }
}