using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlphaRenting
{
    public partial class Connexion : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            bool connecter = false;
            if (Session["adresse_mail"] != null) connecter = true;
            if (connecter == false)
            {
                string Email = null, mdp = null;
                bool vide = false;
                TextBox tb = (TextBox)connection.FindControl("Email");
                if (string.IsNullOrWhiteSpace(tb.Text)) { vide = true; }
                else Email = tb.Text;
                tb = (TextBox)connection.FindControl("MDP");
                if (string.IsNullOrWhiteSpace(tb.Text)) { vide = true; }
                else mdp = tb.Text;
                Label lb = (Label)connection.FindControl("labelcon");
                if (vide == false)
                {
                    string pwd = null;
                    MySqlDataReader dr = DB.Select("comedien", "password", "adresse_mail", Email);
                    if (dr.HasRows)
                    {
                        pwd = Convert.ToString(dr.Read());
                    }
                    if (mdp == pwd)
                    {
                        Session.Add("adresse_mail", Email);
                        lb.Text = "Connexion Reussi";
                        lb.Focus();
                        Server.Transfer("MonProfil.aspx");
                    }
                    else
                    {
                        lb.Text = "Erreur de password veuillez recommencer";
                        lb.Focus();
                    }
                }
            }
        }
    }
}