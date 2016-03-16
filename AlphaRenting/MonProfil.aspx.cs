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
                    Response.Redirect("~/MonProfil.aspx");
                else
                    _user = (Comedien)Session["user"];
            }
        }

        protected void modifier_Click(object sender, EventArgs e)
        {
            bool connecter = false;
            if (Session["adresse_mail"] != null)
            {
                connecter = true;
            }
            if (connecter == true) { 
                string CVfilename = null, photofilename = null, videofilename = null;
                string metier = null, mail = null;
                int age = 0, departement=0;
                DropDownList dd = (DropDownList)modifprofil.FindControl("Listederoulante");
                metier = dd.SelectedValue;
                if (!string.IsNullOrWhiteSpace(metier))
                    DB.Update("comedien", "secteur", "adresse_mail", metier, Session["adresse_mail"]);
                TextBox tb = (TextBox)modifprofil.FindControl("dep");
                if (!string.IsNullOrWhiteSpace(tb.Text))
                {
                    departement = Convert.ToInt32(tb.Text);
                    DB.Update("comedien", "departement", "adresse_mail", departement, Session["adresse_mail"]);
                }
                tb = (TextBox)modifprofil.FindControl("mail");
                if (!string.IsNullOrWhiteSpace(tb.Text))
                {
                    mail = tb.Text;
                    DB.Update("comedien", "adresse_mail", "adresse_mail", mail, Session["adresse_mail"]);
                    Session["adresse_mail"] = mail;
                }
                tb = (TextBox)modifprofil.FindControl("age");
                if (!string.IsNullOrWhiteSpace(tb.Text))
                {
                    age = Convert.ToInt32(tb.Text);
                    DB.Update("comedien", "age", "adresse_mail", age, Session["adresse_mail"]);
                }
                FileUpload fp = (FileUpload)modifprofil.FindControl("CV");
                Label lb1 = (Label)modifprofil.FindControl("LabelCV");
                if (fp.HasFile)
                {
                    try
                    {
                        if (fp.PostedFile.ContentType == "image/jpeg")
                        {
                            if (fp.PostedFile.ContentLength < 102400)
                            {
                                CVfilename = fp.FileName;
                                fp.SaveAs(Server.MapPath("~/cv/") + CVfilename);
                                lb1.Text = "Upload status: File uploaded!";
                                CVfilename = ("~/cv/" + fp.FileName);
                                DB.Update("Comedien", "CV", "adress_mail", CVfilename, Session["adresse_mail"]);
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
                FileUpload fp1 = (FileUpload)modifprofil.FindControl("photo");
                Label lb2 = (Label)modifprofil.FindControl("LabelPhoto");
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
                                    photofilename = "~/photos/" + userpostedfile.FileName;
                                    userpostedfile.SaveAs(Server.MapPath("~/photos/") + userpostedfile.FileName);
                                    lb2.Text = "Upload status: File uploaded!";
                                    DB.Insert("photo", "photo_path", photofilename);
                                    int idcomedien = 0, idphoto = 0;
                                    MySqlDataReader Dr = DB.Select("comedien", "id", "adresse_mail", Session["adresse_mail"]);
                                    if (Dr.HasRows) { idcomedien = Convert.ToInt32(Dr.Read()); }
                                    Dr = DB.Select("photo", "idphoto", "photo_path", photofilename);
                                    if (Dr.HasRows) { idphoto = Convert.ToInt32(Dr.Read()); }
                                    DB.Insert("comedien_photo", "idphoto,idcomedien", idphoto, idcomedien);
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
                FileUpload fp2 = (FileUpload)modifprofil.FindControl("video");
                Label lb3 = (Label)modifprofil.FindControl("LabelVideo");
                if (fp2.HasFile)
                {
                    try
                    {
                        if (fp2.PostedFile.ContentType == "video/MP4")
                        {
                            if (fp2.PostedFile.ContentLength < 102400)
                            {
                                videofilename = "~/video/" + fp2.FileName;
                                fp2.SaveAs(Server.MapPath("~/video/") + fp2.FileName);
                                lb3.Text = "Upload status: File uploaded!";
                                DB.Insert("video", "video_path", videofilename);
                                int idcomedien = 0, idvideo = 0;
                                MySqlDataReader Dr = DB.Select("comedien", "id", "adresse_mail", Session["adresse_mail"]);
                                if (Dr.HasRows) { idcomedien = Convert.ToInt32(Dr.Read()); }
                                Dr = DB.Select("video", "idvideo", "video_path", videofilename);
                                if (Dr.HasRows) { idvideo = Convert.ToInt32(Dr.Read()); }
                                DB.Insert("comedien_video", "idvideo,idcomedien", idvideo, idcomedien);
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
            }else
            {
                Server.Transfer("Connexion.aspx");
            }
        }
    }
}