using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlphaRenting
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Example d'insert
            //DB.Insert("tabletest", "nom,prenom", "tanguy", "sueur");

            //Example d'update, insert dans la table 'tabletest' les champs prenom et nom, ou le nom='test'
            //DB.Update("tabletest", "prenom,nom", "nom", "jean", "perret", "test");

            //Example de Select
            /*MySqlDataReader mdr = DB.Select("tabletest", "*");
            using (mdr)
            {
                while (mdr.Read())
                {
                    string nom = mdr["nom"] as string;
                }
            }*/
        }   

        protected void fvForm_ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            FormView fv = (FormView)sender;

            TextBox txt = (TextBox)fv.FindControl("txtNom");
            string nom = txt.Text.Trim();

            txt = (TextBox)fv.FindControl("txtPrenom");
            string prenom = txt.Text.Trim();

            DB.Insert("tabletest", "nom,prenom", nom, prenom);

            e.Handled = true;
        }
    }
}