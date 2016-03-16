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

        public Comedien CreateComedienFromFormView(FormView fv)
        {
            Comedien obj = new Comedien();
            foreach (Control ctl in fv.Controls[0].Controls[1].Controls[0].Controls)
            {
                if (ctl.GetType() == typeof(TextBox))
                {
                    TextBox txt = (TextBox)ctl;
                    switch (txt.ID)
                    {
                        case "txtNom":
                            obj.SetNom(txt.Text.Trim());
                            break;
                        case "txtPrenom":
                            obj.SetPrenom(txt.Text.Trim());
                            break;
                        case "txtAge":
                            obj.SetAge(Tools.ConvertIntFromString(txt.Text.Trim()));
                            break;
                        case "txtMail":
                            obj.SetMail(txt.Text);
                            break;
                        case "txtDep":
                            obj.SetDepartement(Tools.ConvertIntFromString(txt.Text.Trim()));
                            break;
                        case "txtPassword":
                            obj.SetPassword(txt.Text.Trim());
                            break;
                        default:
                            break;
                    }
                }
                else if (ctl.GetType() == typeof(DropDownList))
                {
                    DropDownList ddl = (DropDownList)ctl;
                    switch (ddl.ID)
                    {
                        case "ddlSexe":
                            obj.SetSexe(Convert.ToChar(ddl.SelectedValue));
                            break;
                        case "ddlSecteur":
                            obj.SetSecteur(Convert.ToChar(ddl.SelectedValue));
                            break;
                        default:
                            break;
                    }
                }
            }
            return obj;
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

                Comedien obj = CreateComedienFromFormView(fv);

                if (DB.Insert("Comedien", "nom,prenom,adresse_mail,password,secteur,age,sexe,departement", obj.GetNom(), obj.GetPrenom(),
                                                                                                       obj.GetMail(), obj.GetPassword(),
                                                                                                       obj.GetSecteur(), obj.GetAge(),
                                                                                                       obj.GetSexe(), obj.GetDepartement()))
                {
                    Session.Add("user", obj);
                    Server.Transfer("~/MonProfil.aspx", false);
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