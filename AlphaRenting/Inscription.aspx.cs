using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlphaRenting
{
    public partial class Inscription : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void done_Click(object sender, EventArgs e)
        {
            string metier=null, nom = null, prenom = null, sexe=null, mail=null, mdp=null, mdpc=null;
            int age = 0, departement=0;
            bool champvide = false;
            TextBox tb = (TextBox)inscription.FindControl("nom");
            if (string.IsNullOrWhiteSpace(tb.Text)) { champvide = true; }
            else nom = tb.Text;
            DropDownList dd = (DropDownList)inscription.FindControl("Listederoulante");
            metier = dd.SelectedValue;
            dd = (DropDownList)inscription.FindControl("sexe");
            sexe = dd.SelectedValue;
            tb = (TextBox)inscription.FindControl("prenom");
            if (string.IsNullOrWhiteSpace(tb.Text)) { champvide = true;}
            else prenom = tb.Text;
            tb = (TextBox)inscription.FindControl("dep");
            if(!string.IsNullOrWhiteSpace(tb.Text))
                departement = Convert.ToInt32(tb.Text);
            tb = (TextBox)inscription.FindControl("mail");
            if (string.IsNullOrWhiteSpace(tb.Text)) { champvide = true;}
            else mail = tb.Text;
            tb = (TextBox)inscription.FindControl("age");
            if (!string.IsNullOrWhiteSpace(tb.Text))
                age = Convert.ToInt32(tb.Text);
            tb = (TextBox)inscription.FindControl("MDP");
            if (string.IsNullOrWhiteSpace(tb.Text)) { champvide = true; }
            else mdp = tb.Text;
            tb = (TextBox)inscription.FindControl("MDPC");
            if (string.IsNullOrWhiteSpace(tb.Text)) { champvide = true; }
            else mdpc = tb.Text;
            if (mdpc != mdp)
            {
                champvide = true;
                Label l = (Label)inscription.FindControl("labelmdp");
                l.Text = "Veuillez mettre deux mots de passe identiques";
                l.Focus();
            }
            if (champvide == false)
            {
                DB.Insert("Comedien", "nom,prenom,adresse_mail,password,secteur,age,sexe,departement", nom, prenom, mail, mdp, metier, age, sexe, departement);
                Session.Add("adresse_mail", mail);
                Label lb = (Label)inscription.FindControl("label");
                lb.Text = "Merci d'avoir renseigner les informations";
                lb.Focus();
                Server.Transfer("~/MonProfil.aspx");
                //INSERT DataBase
            }
        }
    }
}