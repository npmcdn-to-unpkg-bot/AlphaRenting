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
            
        }

        protected void btnTest_Click(object sender, EventArgs e)
        {
            //Example d'insert
            DB.Update("tabletest", "nom,prenom", "tanguy", "sueur");

            //Example d'update, insert dans la table 'tabletest' les champs prenom et nom, ou le nom='test'
            DB.Update("tabletest", "prenom,nom", "nom", "jean", "perret", "test");
        }
    }
}