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
                fvProfil.DataSource = new object[] { _user };
                fvProfil.DataBind();
            }
        }
        protected bool UpdateToDb(out Comedien dbobj)
        {
            FileUpload fImg = (FileUpload)fvProfil.FindControl("fuImg");
            FileUpload fVideo = (FileUpload)fvProfil.FindControl("fuVideo");
            FileUpload fCv = (FileUpload)fvProfil.FindControl("fuCv");
            Comedien obj = Tools.CreateComedienFromFormView(fvProfil, (Comedien)Session["user"]);
            obj.Photo = Tools.SaveFileFromFileUpload(fImg, Server.MapPath("~/uploads/images/"));
            obj.Video = Tools.SaveFileFromFileUpload(fVideo, Server.MapPath("~/uploads/videos/"));
            obj.Cv = Tools.SaveFileFromFileUpload(fCv, Server.MapPath("~/uploads/cv/"));
            dbobj = obj;
            return obj.Synchronize();
        }

        protected void btnClick_Click(object sender, EventArgs e)
        {
            Comedien obj = null;
            if(UpdateToDb(out obj))
            {
                Tools.StoreObjectInSession(obj, this);
                fvProfil.DataSource = new object[] { obj };
                fvProfil.DataBind();
            }
        }
    }
}