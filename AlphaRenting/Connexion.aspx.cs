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
            string Email=null, mdp=null;
            bool vide = false;
            TextBox tb = (TextBox)connection.FindControl("Email");
            if (string.IsNullOrWhiteSpace(tb.Text)) { vide = true; }
            else Email = tb.Text;
            tb = (TextBox)connection.FindControl("MDP");
            if (string.IsNullOrWhiteSpace(tb.Text)) { vide = true; }
            else mdp = tb.Text;
            if (vide == false)
            {
                //appel Base de données
            }
        }
    }
}