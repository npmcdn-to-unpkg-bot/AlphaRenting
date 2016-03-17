using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlphaRenting
{
    public class Tools
    {
        public static int ConvertIntFromString(string text)
        {
            if (Regex.IsMatch(text, @"^[a-zA-Z]+$"))
                return 0;
            else if (text.All(c => Char.IsDigit(c)))
            {
                return Convert.ToInt32(text);
            }
            else
                return 0;
        }
        public static Comedien CreateComedienFromFormView(FormView fv)
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
                            obj.Nom = txt.Text.Trim();
                            break;
                        case "txtPrenom":
                            obj.Prenom = txt.Text.Trim();
                            break;
                        case "txtAge":
                            obj.Age = Tools.ConvertIntFromString(txt.Text.Trim());
                            break;
                        case "txtMail":
                            obj.Mail = txt.Text.Trim();
                            break;
                        case "txtDep":
                            obj.Departement = Tools.ConvertIntFromString(txt.Text.Trim());
                            break;
                        case "txtPassword":
                            obj.Password = txt.Text.Trim();
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
                            obj.Sexe = (Convert.ToChar(ddl.SelectedValue));
                            break;
                        case "ddlSecteur":
                            obj.Secteur = (Convert.ToChar(ddl.SelectedValue));
                            break;
                        default:
                            break;
                    }
                }
            }
            return obj;
        }
        public static bool SaveFileFromFileUpload(FileUpload fu, string save_path)
        {   
            if (fu.HasFile)
            {
                int fileSize = fu.PostedFile.ContentLength;
                if (fileSize < 2100000)
                {
                    save_path += fu.FileName;
                    fu.SaveAs(save_path);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}