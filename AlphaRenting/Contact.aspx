<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="AlphaRenting.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your contact page.</h3>
    <asp:FormView runat="server" ID="fvForm" DefaultMode="Insert" OnItemCommand="fvForm_ItemCommand">
        <InsertItemTemplate>
            <span>Nom: </span><asp:TextBox runat="server" ID="txtNom" />
            <span>Prenom: </span><asp:TextBox runat="server" ID="txtPrenom" />
            <asp:Button runat="server" ID="btnSend" CommandName="Insert"/>
        </InsertItemTemplate>
    </asp:FormView>
</asp:Content>
