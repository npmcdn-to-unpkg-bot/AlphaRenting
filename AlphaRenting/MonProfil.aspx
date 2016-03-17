<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MonProfil.aspx.cs" Inherits="AlphaRenting.MonProfil" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:FormView runat="server" ID="fvProfil" DefaultMode="Edit">
            <EditItemTemplate>
                <asp:TextBox runat="server" ID="txtNom" Text='<%# Eval("Nom") %>'></asp:TextBox>
                <asp:TextBox runat="server" ID="txtPrenom" Text='<%# Eval("Prenom") %>'></asp:TextBox>
                <asp:TextBox runat="server" ID="txtAge" Text='<%# Eval("Age") %>' TextMode="Number"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtMail" Text='<%# Eval("Mail") %>' TextMode="Email"></asp:TextBox>
                <asp:DropDownList runat="server" ID="ddlSecteur" SelectedValue='<%# Bind("Secteur") %>'>
                    <asp:ListItem Value="C" Text="Comedien"></asp:ListItem>
                    <asp:ListItem Value="M" Text="Magicien"></asp:ListItem>
                    <asp:ListItem Value="H" Text="Hotesse"></asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList runat="server" ID="ddlSexe" SelectedValue='<%# Bind("Sexe") %>'>
                    <asp:ListItem Value="M" Text="Homme"></asp:ListItem>
                    <asp:ListItem Value="F" Text="Femme"></asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox runat="server" ID="txtDept" Text='<%# Eval("Departement") %>' TextMode="Number"></asp:TextBox>
                
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="conditional">
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnClick" />
                    </Triggers>
                    <ContentTemplate>
                        <asp:FileUpload ID="fuVideo" runat="server" />
                        <asp:FileUpload ID="fuCv" runat="server" />
                        <asp:FileUpload ID="fuImg" runat="server" />
                        <asp:Button runat="server" ID="btnClick" Text="Envoyer" OnClick="btnClick_Click" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </EditItemTemplate>
        </asp:FormView>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
    </form>
</body>
</html>
