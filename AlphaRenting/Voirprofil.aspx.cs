using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlphaRenting
{
    public partial class VoirProfil : System.Web.UI.Page
    {

        public List<Comedien> GetAllProfile()
        {
            List<Comedien> lst = new List<Comedien>();

            MySqlDataReader msql = DB.ExecuteReader("SELECT id FROM comedien");
            if(msql!=null)
            {
                using (msql)
                {
                    if(msql.HasRows)
                    {
                        while (msql.Read())
                        {
                            int id = Convert.ToInt32(msql["id"]);
                            Comedien obj = new Comedien();
                            obj.InitObjectFromId(id);
                            lst.Add(obj);
                        }
                    }
                }
            }
            return lst;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            List<Comedien> lst = GetAllProfile();
            voirprofil.DataSource = lst;
            voirprofil.DataBind();
        }

        protected void homme_Click(object sender, EventArgs e)
        {

        }

        protected void femme_Click(object sender, EventArgs e)
        {

        }

        protected void selec_metier_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void tout_Click(object sender, EventArgs e)
        {

        }
    }
}