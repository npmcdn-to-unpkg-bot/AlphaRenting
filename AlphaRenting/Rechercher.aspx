<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rechercher.aspx.cs" Inherits="AlphaRenting.Rechercher" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:FormView runat="server" ID="rechercher" DefaultMode="Insert" >
            <InsertItemTemplate>
                <table>
                    <tr>
                        <td>Nom : <asp:TextBox runat="server" ID="nom" ToolTip="Nom" /></td>
                    </tr>
                    <tr>
                        <td>
                            Metier : <asp:DropDownList runat="server" ID="metier">
                                <asp:ListItem Selected="True" Value="Magicien">Magicien</asp:ListItem>
                                <asp:ListItem Value="Comedien">Comedien</asp:ListItem>
                                <asp:ListItem Value="Hotesse">Hotesse</asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td>
                            Sexe : <asp:DropDownList runat="server" ID="sexe" >
                                <asp:ListItem Selected="false" Value="male">Homme</asp:ListItem>
                                <asp:ListItem Selected="false" Value="femelle">Femme</asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td>Mieux Notés : <asp:CheckBox runat="server" ID="Bestnote" ToolTip="OUI" /></td>
                    </tr>
                    <tr>
                        <td> <asp:Button runat="server" ID="submit" OnClick="submit_Click" Text="Rechercher" /></td>
                    </tr>
                </table>
            </InsertItemTemplate>
        </asp:FormView>
    </form>
</body>
</html>
