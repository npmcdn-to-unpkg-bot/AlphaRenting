<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MonProfil.aspx.cs" Inherits="AlphaRenting.MonProfil" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:FormView runat="server" ID="modifprofil" DefaultMode="Edit">
            <InsertItemTemplate>
                <table>                   
                    <tr><td>Choisissez votre secteur : </td>
                    <td>
                        <asp:DropDownList runat="server" ID="Listederoulante" >
                            <asp:ListItem Selected="true" Value="Comedien">Comedien</asp:ListItem>
                            <asp:ListItem Value="Magicien">Magicien</asp:ListItem>
                            <asp:ListItem Value="Hotesse">Hotesse</asp:ListItem>
                        </asp:DropDownList></td>
                    </tr>
                    <tr><td>Age : </td>
                        <td><asp:TextBox runat="server" ID="age" ToolTip="age" /></td>
                    </tr>
                    <tr><td>Adresse mail : </td>
                        <td><asp:TextBox runat="server" ID="mail" ToolTip="adresse mail" /></td>
                    </tr>
                    <tr><td>Departement : </td>
                    <td><asp:TextBox runat="server" ID="dep" ToolTip="Departement" /></td>
                    </tr>
                    <tr>
                        <td> CV : <asp:FileUpload runat="server" ID="CV" /></br>
                            <asp:Label runat="server" ID="LabelCV" Text="" /></td>
                    </tr>
                    <tr>
                        <td>Photo : <asp:FileUpload runat="server" ID="photo" AllowMultiple="true" /></br>
                            <asp:Label runat="server" ID="LabelPhoto" Text="" /></td>
                    </tr>
                    <tr>
                        <td>Video : <asp:FileUpload runat="server" ID="video" /></br>
                            <asp:Label runat="server" ID="LabelVideo" Text="" /></td>
                    </tr>
                    <tr>
                        <td>
                        <asp:Button runat="server" ID="modifier" OnClick="modifier_Click" Text="Modifier Profil" /></td>
                    </tr>
                </table>
            </InsertItemTemplate>
        </asp:FormView>
    </form>
</body>
</html>
