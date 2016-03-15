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

        protected void done_Click(object sender, EventArgs e)
        {
            string metier=null, nom = null, prenom = null, sexe=null, mail=null, CVfilename=null, videofilename=null, photofilename=null, mdp=null;
            int age = 0, departement=0;
            bool champvide = false;
            TextBox tb = (TextBox)inscription.FindControl("nom");
            if (string.IsNullOrWhiteSpace(tb.Text)) { champvide = true; }
            else nom = tb.Text;
            DropDownList dd = (DropDownList)inscription.FindControl("Listederoulante");
            metier = dd.SelectedValue;
            dd = (DropDownList)inscription.FindControl("sexe");
            sexe = dd.SelectedValue;
            tb = (TextBox)inscription.FindControl("prenom");
            if (string.IsNullOrWhiteSpace(tb.Text)) { champvide = true;}
            else prenom = tb.Text;
            tb = (TextBox)inscription.FindControl("dep");
            if(!string.IsNullOrWhiteSpace(tb.Text))
                departement = Convert.ToInt32(tb.Text);
            tb = (TextBox)inscription.FindControl("mail");
            if (string.IsNullOrWhiteSpace(tb.Text)) { champvide = true;}
            else mail = tb.Text;
            tb = (TextBox)inscription.FindControl("age");
            if (!string.IsNullOrWhiteSpace(tb.Text))
                age = Convert.ToInt32(tb.Text);
            tb = (TextBox)inscription.FindControl("MDP");
            if (string.IsNullOrWhiteSpace(tb.Text)) { champvide = true; }
            else mdp = tb.Text;
            FileUpload fp = (FileUpload)inscription.FindControl("CV");
            Label lb1 = (Label)inscription.FindControl("LabelCV");
            if (fp.HasFile)
            {
                try
                {
                    if (fp.PostedFile.ContentType == "image/jpeg")
                    {
                        if (fp.PostedFile.ContentLength < 102400)
                        {
                            CVfilename = fp.FileName;
                            fp.SaveAs(Server.MapPath("~/cv") + CVfilename);
                            lb1.Text = "Upload status: File uploaded!";
                        }
                        else {
                            lb1.Text = "Upload status: The file as to be less than 100Kb !";
                            lb1.Focus();
                        }
                    }
                    else {
                        lb1.Text = "Upload status: Only jpeg files are accepted !";
                        lb1.Focus();
                    }
                }
                catch (Exception ex)
                {
                    lb1.Text = "Upload status: the file could not be uploaded. The following error occured: " + ex.Message;
                    lb1.Focus();
                }
            }
            FileUpload fp1 = (FileUpload)inscription.FindControl("photo");
            Label lb2 = (Label)inscription.FindControl("LabelPhoto");
            if (fp1.HasFile)
            {
                string filepath = Server.MapPath("~/photos");
                HttpFileCollection uploadedfile = Request.Files;
                for (int i = 0; i < uploadedfile.Count; i++)
                {
                    HttpPostedFile userpostedfile = uploadedfile[i];
                    try
                    {
                        if (userpostedfile.ContentType == "image/jpeg")
                        {
                            if (userpostedfile.ContentLength < 102400)
                            {
                                photofilename = userpostedfile.FileName;
                                userpostedfile.SaveAs(Server.MapPath("~/photos/") + photofilename);
                                lb2.Text = "Upload status: File uploaded!";
                            }
                            else {
                                lb2.Text = "Upload status: The file as to be less than 100Kb !";
                                lb2.Focus();
                            }
                        }
                        else {
                            lb2.Text = "Upload status: Only jpeg files are accepted !";
                            lb2.Focus();
                        }
                    }
                    catch (Exception ex)
                    {
                        lb2.Text = "Upload status: the file could not be uploaded. The following error occured: " + ex.Message;
                        lb2.Focus();
                    }
                }
            }
            FileUpload fp2 = (FileUpload)inscription.FindControl("video");
            Label lb3 = (Label)inscription.FindControl("LabelVideo");
            if (fp2.HasFile)
            {
                try
                {
                    if (fp2.PostedFile.ContentType == "video/MP4")
                    {
                        if (fp2.PostedFile.ContentLength < 102400)
                        {
                            videofilename = fp2.FileName;
                            fp2.SaveAs(Server.MapPath("~/video") + videofilename);
                            lb3.Text = "Upload status: File uploaded!";
                        }
                        else {
                            lb3.Text = "Upload status: The file as to be less than 100Kb !";
                            lb3.Focus();
                        }
                    }
                    else {
                        lb3.Text = "Upload status: Only jpeg files are accepted !";
                        lb3.Focus();
                    }
                }
                catch (Exception ex)
                {
                    lb3.Text = "Upload status: the file could not be uploaded. The following error occured: " + ex.Message;
                    lb3.Focus();
                }
            }
            if (champvide == false)
            {
                //INSERT DataBase
            }
            Label lb = (Label)inscription.FindControl("label");
            lb.Text = "Merci d'avoir renseigner les informations";
            lb.Focus();
        }
    }
}