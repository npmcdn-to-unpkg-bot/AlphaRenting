<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inscription.aspx.cs" Inherits="AlphaRenting.Inscription" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form" runat="server">
    <asp:FormView ID="inscription" runat="server" DefaultMode="Insert">
        <InsertItemTemplate>
            <table>
                <tr><td>Choisissez votre secteur : </td>
                    <td>
                        <asp:DropDownList runat="server" ID="Listederoulante" >
                            <asp:ListItem Selected="true" Value="C">Comedien</asp:ListItem>
                            <asp:ListItem Value="M">Magicien</asp:ListItem>
                            <asp:ListItem Value="H">Hotesse</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr><td>Nom : </td>
                    <td><asp:TextBox runat="server" ID="nom" ToolTip="nom"/></td>
                </tr>
                <tr><td>Prenom : </td>
                    <td><asp:TextBox runat="server" ID="prenom" ToolTip="prenom" /></td>
                    </tr>
                <tr><td>Age : </td>
                    <td><asp:TextBox runat="server" ID="age" ToolTip="age" /></td>
                </tr>
                <tr><td>Sexe : </td>
                    <td><asp:DropDownList runat="server" ID="sexe" >
                        <asp:ListItem Selected="true" Value="M">Homme</asp:ListItem>
                        <asp:ListItem Value="F">Femme</asp:ListItem>
                    </asp:DropDownList></td>
                </tr>
                <tr><td>Adresse mail : </td>
                    <td><asp:TextBox runat="server" ID="mail" ToolTip="adresse mail" /></td>
                </tr>
                <tr><td>Departement : </td>
                    <td><asp:TextBox runat="server" ID="dep" ToolTip="Departement" /></td>
                </tr>
                <tr>
                    <td>Mot De Passe : <asp:TextBox runat="server" TextMode="Password" ID="MDP" ToolTip="Mot de Passe" /></td>
                <tr />
                <tr>
                    <td>Confirmation du Mot De Passe : <asp:TextBox runat="server" TextMode="Password" ID="MDPC" ToolTip="Confirmation Mot de Passe" /></td>
                    <asp:Label runat="server" ID="labelmdp" Text="" />
                <tr />
            </table>
            <asp:Button runat="server" ID="done" OnClick="done_Click" Text="Submit" />
            <asp:Label runat="server" ID="label" Text="" />
        </InsertItemTemplate>
        <EditItemTemplate>

        </EditItemTemplate>
    </asp:FormView>
    </form>
</body>
</html>
