﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inscription.aspx.cs" Inherits="AlphaRenting.Inscription" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Projet</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap-theme.min.css" />
    <link href="./assets/css/style.css" rel="stylesheet" type="text/css" />
    <!--       links for photos en the top and apps -->
    <link rel="apple-touch-icon" sizes="57x57" href="./assets/img/favicons/apple-touch-icon-57x57.png" />
    <link rel="apple-touch-icon" sizes="60x60" href="./assets/img/favicons/apple-touch-icon-60x60.png" />
    <link rel="apple-touch-icon" sizes="72x72" href="./assets/img/favicons/apple-touch-icon-72x72.png" />
    <link rel="apple-touch-icon" sizes="76x76" href="./assets/img/favicons/apple-touch-icon-76x76.png" />
    <link rel="apple-touch-icon" sizes="114x114" href="./assets/img/favicons/apple-touch-icon-114x114.png" />
    <link rel="apple-touch-icon" sizes="120x120" href="./assets/img/favicons/apple-touch-icon-120x120.png" />
    <link rel="apple-touch-icon" sizes="144x144" href="./assets/img/favicons/apple-touch-icon-144x144.png" />
    <link rel="apple-touch-icon" sizes="152x152" href="./assets/img/favicons/apple-touch-icon-152x152.png" />
    <link rel="apple-touch-icon" sizes="180x180" href="./assets/img/favicons/apple-touch-icon-180x180.png" />
    <link rel="icon" type="image/png" href="./assets/img/favicons/favicon-32x32.png" sizes="32x32" />
    <link rel="icon" type="image/png" href="./assets/img/favicons/android-chrome-192x192.png" sizes="192x192" />
    <link rel="icon" type="image/png" href="./assets/img/favicons/favicon-96x96.png" sizes="96x96" />
    <link rel="icon" type="image/png" href="./assets/img/favicons/favicon-16x16.png" sizes="16x16" />
    <link rel="manifest" href="./assets/img/favicons/manifest.json" />
    <link rel="mask-icon" href="./assets/img/favicons/safari-pinned-tab.svg" color="#6e0070" />
    <link rel="shortcut icon" href="./assets/img/favicons/favicon.ico" />
    <meta name="msapplication-TileColor" content="#da532c" />
    <meta name="msapplication-TileImage" content="./assets/img/favicons/mstile-144x144.png" />
    <meta name="msapplication-config" content="./assets/img/favicons/browserconfig.xml" />
    <meta name="theme-color" content="#6e007e" />
</head>
<body>
    <header>
        <nav class=" navbar navbar-fixed-top navbar-inverse colornav ">
        <!-- barre de navigation -->
        <div class="container-fluid colornav ">
            <div class="navbar-header ">
                <button data-toggle="collapse-side" data-target=".side-collapse" data-target-2=".side-collapse-container" type="button" class="navbar-toggle ">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
            </div>
        </div>
        <div class="navbar-inverse side-collapse in  navbar-fixed-top">
            <div class="container-fluid colornav" style="height 100%">
                <div role="navigation" id="nav" class="navbar-collapse">
                    <ul class="nav navbar-nav">
                        <li>
                            <a href="accueil.aspx">Accueil</a>
                        </li>
                        <li>
                            <a href="rechercher.aspx">Rechercher</a>
                        </li>
                        <li>
                            <a href="Voirprofil.aspx">Voir Profil</a>
                        </li>
                        <li>
                            <a href="Contact.html">Contact</a>
                        </li>
                    </ul>
                    <a href="inscription.aspx"><button type="button" class="btn btn-primary navbar-btn navButt">Register</button></a>
                    <a href="connection.aspx"><button type="button" class="btn btn-primary navbar-btn navButt">Login</button></a>
                </div>
            </div>
        </div>
    </nav>
    </header>
    <form runat="server" class="form-group">
        <asp:FormView runat="server" ID="inscription" OnItemCommand="fvInscription_ItemCommand" DefaultMode="Insert">
            <EditItemTemplate>
                <div class="container-fluid side-collapse-container">
                    <div id="gallery">
                        <div class="inscription">
                            <h1>Modification du profil </h1>
                            <hr class="separation" />
                            <div class="col-md-9 personal-info">
                                <label class="col-lg-3 control-label">Vous êtes </label>
                                <asp:DropDownList runat="server" ID="ddlSexe" CssClass="inlinechoice">
                                    <asp:ListItem Selected="true" Value="M" Text="Homme"></asp:ListItem>
                                    <asp:ListItem Value="F" Text="Femme"></asp:ListItem>
                                </asp:DropDownList>
                            </div>

                            <div class="form-horizontal">
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Nom:</label>
                                    <div class="col-lg-8">
                                        <asp:TextBox runat="server" CssClass="form-control" ID="txtNom" ToolTip="nom" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Prénom:</label>
                                    <div class="col-lg-8">
                                        <asp:TextBox runat="server" ID="txtPrenom" CssClass="form-control" ToolTip="prenom" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-3 control-label">Mot de passe:</label>
                                    <div class="col-md-8">
                                        <asp:TextBox runat="server" CssClass="form-control" TextMode="Password" ID="txtPassword" ToolTip="Mot de Passe" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-3 control-label">Mot de passe confirmation:</label>
                                    <div class="col-md-8">
                                        <asp:TextBox runat="server" TextMode="Password" ID="txtPasswordConf" CssClass="form-control" ToolTip="Confirmation Mot de Passe" />
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Email:</label>
                                    <div class="col-lg-8">
                                        <asp:TextBox runat="server" ID="txtMail" CssClass="form-control" TextMode="Email" ToolTip="adresse mail" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-lg-3   control-label ">Age : </label>
                                    <div class="col-lg-8">
                                        <asp:TextBox runat="server" ID="txtAge" TextMode="Number" ToolTip="age" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-3 control-label"></label>
                                    <div class="col-md-8">
                                        <asp:Button runat="server" CssClass="btn btn-primary navbar-btn navButt" ID="btnSend" CommandName="Insert" Text="Submit" />
                                        <asp:Label runat="server" ID="lblMessage" Text="" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                </div>
            </EditItemTemplate>
        </asp:FormView>
    </form>


   <footer class="footer-distributed">
        <div class="row">
            <div class="col-md-4 footer-left">
                <h3>Alpha<span>Renting</span></h3>
                <p class="footer-links">
                    <a href="Accueil.aspx">Accueil</a>
                    ·
                    <a href="contact.html">Contact</a>
                </p>
                <p class="footer-company-name">AlphaRenting &copy; 2016</p>
            </div>
            <div class="col-md-4 footer-center">
                <div>
                    <i class="fa fa-map-marker"></i>
                    <p><span>135 Rue des Pyrénées</span> Paris, France</p>
                </div>
                <div>
                    <i class="fa fa-envelope"></i>
                    <p><a href="mailto:support@company.com">support@alpharenting.com</a></p>
                </div>
            </div>
            <div class=" col-md-4 footer-right">
                <p class="footer-company-about">
                    <span>About the company</span>
                    Si vous souhaitez déposer un dossier de candidature pour vous inscrire à cette formation, remplissez directement le formulaire de candidature
                </p>
            </div>
        </div>
    </footer>
    <script src="https://code.jquery.com/jquery-2.2.1.min.js"></script>
    <script src="https://npmcdn.com/masonry-layout@4.0/dist/masonry.pkgd.min.js"></script>



    <script type="text/javascript" src="./assets/js/isotope.min.js"></script>

    <!--	<-- // get  by net -->





    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>

    <script type="text/javascript" src="./assets/js/navbar.script"></script>
    <script type="text/javascript" src="./assets/js/main.js"></script>



</body>
</html>
