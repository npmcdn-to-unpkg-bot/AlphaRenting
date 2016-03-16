﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Connexion.aspx.cs" Inherits="AlphaRenting.Connexion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:FormView runat="server" ID="fvConnexion" DefaultMode="Insert">
            <InsertItemTemplate>
                </table>
                    <tr>
                        <td>Email : <asp:TextBox runat="server" ID="txtMail" ToolTip="adresse mail" /></td>
                    </tr>
                    <tr>
                        <td>Mot De Passe : <asp:TextBox runat="server" TextMode="Password" ID="txtPassword" ToolTip="Mot de Passe" /></td>
                    </tr>
                    <tr>
                        <td><asp:Button runat="server" ID="btnSubmit" OnClick="btnSubmit_Click" Text="Connexion" /></td>
                        <asp:Label runat="server" ID="lblMessage" Text="" />
                    </tr>
                </table>
              </InsertItemTemplate>
        </asp:FormView>
    </form>
</body>
</html>