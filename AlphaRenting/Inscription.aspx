<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inscription.aspx.cs" Inherits="AlphaRenting.Inscription" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form" runat="server">
    <asp:FormView ID="fvInscription" runat="server" DefaultMode="Insert" OnItemCommand="fvInscription_ItemCommand">
        <InsertItemTemplate>
            <table>
                <tr>
                    <td>Choisissez votre secteur : </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlSecteur" >
                            <asp:ListItem Selected="true" Value="C" Text="Comedien"></asp:ListItem>
                            <asp:ListItem Value="M" Text="Magicien"></asp:ListItem>
                            <asp:ListItem Value="H" Text="Hotesse"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Nom :</td>
                    <td><asp:TextBox runat="server" ID="txtNom" ToolTip="nom"/></td>
                </tr>
                <tr>
                    <td>Prenom : </td>
                    <td><asp:TextBox runat="server" ID="txtPrenom" ToolTip="prenom" /></td>
                    </tr>
                <tr>
                    <td>Age : </td>
                    <td><asp:TextBox runat="server" ID="txtAge" TextMode="Number" ToolTip="age" /></td>
                </tr>
                <tr>
                    <td>Sexe : </td>
                    <td><asp:DropDownList runat="server" ID="ddlSexe" >
                        <asp:ListItem Selected="true" Value="M" Text="Homme"></asp:ListItem>
                        <asp:ListItem Value="F" Text="Femme"></asp:ListItem>
                    </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>Adresse mail : </td>
                    <td><asp:TextBox runat="server" ID="txtMail" TextMode="Email" ToolTip="adresse mail" /></td>
                </tr>
                <tr>
                    <td>Departement : </td>
                    <td><asp:TextBox runat="server" ID="txtDep" TextMode="Number" ToolTip="Departement" /></td>
                </tr>
                <tr>
                    <td>Mot De Passe : </td>
                    <td><asp:TextBox runat="server" TextMode="Password" ID="txtPassword" ToolTip="Mot de Passe" /></td>
                </tr>
                <tr>
                    <td>Confirmation du Mot De Passe :</td>
                    <td><asp:TextBox runat="server" TextMode="Password" ID="txtPasswordConf" ToolTip="Confirmation Mot de Passe" /></td>
                </tr>
            </table>
            <asp:Button runat="server" ID="btnSend" CommandName="insert" Text="Submit" />
            <asp:Label runat="server" ID="lblMessage" Text="" />
        </InsertItemTemplate>
    </asp:FormView>
    </form>
</body>
</html>
