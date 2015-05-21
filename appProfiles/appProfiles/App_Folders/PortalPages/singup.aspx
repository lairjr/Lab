<%@ Page Title="" Language="C#" MasterPageFile="~/App_Folders/PortalMasterPages/mPage1.Master" AutoEventWireup="true" CodeBehind="singup.aspx.cs" Inherits="appProfiles.App_Folders.PortalPages.singup" %>
<%@ Register src="../PortalUserControl/signForm.ascx" tagname="signForm" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="singUpForm">
        <uc1:signForm ID="signForm1" runat="server" />
    </div>
</asp:Content>
