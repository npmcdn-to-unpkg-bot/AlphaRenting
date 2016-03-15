using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlphaRenting
{
    public partial class Rechercher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            string nom = null, metier = null, sexe = null;
            bool bestnotes = false;
            TextBox tb = (TextBox)rechercher.FindControl("Nom");
            if (!string.IsNullOrWhiteSpace(tb.Text))
                nom = tb.Text;
            DropDownList dd = (DropDownList)rechercher.FindControl("metier");
            if (!string.IsNullOrWhiteSpace(tb.Text))
                metier = dd.SelectedValue;
            dd = (DropDownList)rechercher.FindControl("sexe");
            if (!string.IsNullOrWhiteSpace(tb.Text))
                sexe = dd.SelectedValue;
            CheckBox cb = (CheckBox)rechercher.FindControl("Bestnote");
            bestnotes = cb.Checked;

        }
    }
}