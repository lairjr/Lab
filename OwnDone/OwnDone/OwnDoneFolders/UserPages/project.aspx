<%@ Page Title="" Language="C#" MasterPageFile="~/OwnDoneFolders/MasterPages/user.Master" AutoEventWireup="true" CodeBehind="project.aspx.cs" Inherits="OwnDone.OwnDoneFolders.UserPages.project" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <strong><asp:Label ID="lblTitulo" runat="server" Text="Projeto Titulo"></asp:Label></strong>
    <br />
    <br />
    <asp:Panel ID="descricao" runat="server" Width="100%" BorderWidth="0px">
        <asp:Label ID="lblDescricao" runat="server" Text="Descrição"></asp:Label>
    </asp:Panel>
</asp:Content>
