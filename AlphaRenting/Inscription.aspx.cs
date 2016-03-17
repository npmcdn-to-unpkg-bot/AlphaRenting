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
            if (!IsPostBack)
            {
                if (Session["user"] != null)
                    Response.Redirect("~/MonProfil.aspx");
            }
        }

        public bool VerifyFormFields(FormView fv)
        {
            bool HasError = false;
            foreach (Control ctl in fv.Controls[0].Controls[1].Controls[0].Controls)
            {
                if (ctl.GetType() == typeof(TextBox))
                {
                    TextBox txt = (TextBox)ctl;
                    if (string.IsNullOrWhiteSpace(txt.Text.Trim()))
                    {
                        HasError = true;
                        txt.Focus();
                    }
                }
            }
            return HasError;
        }

        public bool VerifyFormPassword(FormView fv)
        {
            string passwd, passwdconf;
            TextBox txt = (TextBox)fv.FindControl("txtPassword");
            passwd = txt.Text.Trim();
            txt = (TextBox)fv.FindControl("txtPasswordConf");
            passwdconf = txt.Text.Trim();

            return (passwd == passwdconf);
        }

        public void ThrowLabelError(string error, FormView fv)
        {
            Label lbl = (Label)fv.FindControl("lblMessage");
            lbl.Text = error;
            lbl.ForeColor = System.Drawing.Color.Red;
            lbl.Focus();
        }

        protected void fvInscription_ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            FormView fv = (FormView)sender;
            if (e.CommandName == "insert")
            {
                if (VerifyFormFields(fv))
                {
                    ThrowLabelError("Un des champs est vide!", fv);
                    e.Handled = true;
                    return;
                }

                if (!VerifyFormPassword(fv))
                {
                    ThrowLabelError("Les mots de passes ne sont pas identiques!", fv);
                    e.Handled = true;
                    return;
                }

                Comedien obj = Tools.CreateComedienFromFormView(fv);

                if (DB.Insert("Comedien", "nom,prenom,adresse_mail,password,secteur,age,sexe,departement,has_complete_registration", obj.Nom, obj.Prenom,
                                                                                                       obj.Mail, obj.Password,
                                                                                                       obj.Secteur, obj.Age,
                                                                                                       obj.Sexe, obj.Departement, obj.Complete))
                {
                    Tools.StoreObjectInSession(obj, this);
                    Response.Redirect("~/MonProfil.aspx");
                }
                else
                {
                    ThrowLabelError("Problème d'insertion en base!", fv);
                    e.Handled = true;
                    return;
                }
            }
            e.Handled = true;
        }
    }
}