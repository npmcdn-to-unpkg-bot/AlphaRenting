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
            if (!IsPostBack)
            {
                if (Session["user"] != null)
                    Response.Redirect("~/MonProfil.aspx");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string mail, password;

            TextBox txt = (TextBox)fvConnexion.FindControl("txtMail");
            if (!string.IsNullOrWhiteSpace(txt.Text.Trim()))
                mail = txt.Text.Trim();
            else
                return;

            txt = (TextBox)fvConnexion.FindControl("txtPassword");
            if (!string.IsNullOrWhiteSpace(txt.Text.Trim()))
                password = txt.Text.Trim();
            else
                return;

            Comedien obj = new Comedien();
            obj.InitObjectFromCrendentials(mail, password);

            if(obj.Id != 0)
            {
                Tools.StoreObjectInSession(obj, this);
                Response.Redirect("~/MonProfil.aspx");
            }
            else
            {
                Label lbl = (Label)fvConnexion.FindControl("lblMessage");
                lbl.Text = "Erreur de login!";
                lbl.ForeColor = System.Drawing.Color.Red;
                lbl.Focus();
            }
        }
    }
}