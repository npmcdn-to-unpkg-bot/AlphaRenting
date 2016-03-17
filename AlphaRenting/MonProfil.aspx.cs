using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlphaRenting
{
    public partial class MonProfil : System.Web.UI.Page
    {
        private Comedien _user = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] == null)
                    Response.Redirect("~/Connexion.aspx");
                else
                    _user = (Comedien)Session["user"];
            }
            fvProfil.DataSource = new object[] { _user };
            fvProfil.DataBind();
        }
        protected void UpdateToDb()
        {
            Comedien obj = Tools.CreateComedienFromFormView(fvProfil);
            obj.Synchronize();
        }

        protected void btnClick_Click(object sender, EventArgs e)
        {
            UpdateToDb();
        }
    }
}