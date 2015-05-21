<%@ Page Title="" Language="C#" MasterPageFile="~/App_Folders/UserMasterPages/mPage1.Master"
    AutoEventWireup="true" CodeBehind="resume1.aspx.cs" Inherits="appProfiles.App_Folders.UserPages.resume1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="2" border="0" width="99%">
        <tr>
            <td align="left">
                <asp:Label ID="lblResume" runat="server" Text="Resumé" CssClass="page-name"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="lblGoals" runat="server" Text="Professional Goals" CssClass="resume-section"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td>
                            <asp:TextBox ID="txtResumeGoals" runat="server" CssClass="input-text" Height="100px"
                                Width="100%" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnSaveResumeGoals" runat="server" Text="Save Resume Goals" OnClick="btnSaveResumeGoals_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblResumeGoals" runat="server" Text="" CssClass="resume-datail-description"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="lblProfessionalExpiriences" runat="server" Text="Professional Experiences"
                    CssClass="resume-section"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:DataList ID="profExp" runat="server" Width="100%" OnItemDataBound="profExp_ItemDataBound">
                    <ItemTemplate>
                        <asp:HiddenField ID="hfStartM" runat="server" Value='<%# Eval("startm") %>' />
                        <asp:HiddenField ID="hfStartY" runat="server" Value='<%# Eval("starty") %>' />
                        <asp:HiddenField ID="hfEndM" runat="server" Value='<%# Eval("endm") %>' />
                        <asp:HiddenField ID="hfEndY" runat="server" Value='<%# Eval("endy") %>' />
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblJobName" runat="server" Text='<%# Eval("jobname") %>' CssClass="resume-detail-title"></asp:Label>
                                <asp:Label ID="lblDate" runat="server" CssClass="resume-datail-date"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblCompany" runat="server" Text='<%# Eval("company") %>' CssClass="resume-datail-company"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <div id="resume-description-div">
                                    <asp:Label ID="lblJobDescription" runat="server" Text='<%# Eval("jobdescription") %>'
                                        CssClass="resume-datail-description"></asp:Label>
                                </div>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="lblEducation" runat="server" Text="Education" CssClass="resume-section"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DataList ID="education" runat="server" Width="100%" OnItemDataBound="education_ItemDataBound">
                    <ItemTemplate>
                        <asp:HiddenField ID="hfStartM" runat="server" Value='<%# Eval("startm") %>' />
                        <asp:HiddenField ID="hfStartY" runat="server" Value='<%# Eval("starty") %>' />
                        <asp:HiddenField ID="hfEndM" runat="server" Value='<%# Eval("endm") %>' />
                        <asp:HiddenField ID="hfEndY" runat="server" Value='<%# Eval("endy") %>' />
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblCourse" runat="server" Text='<%# Eval("course") %>' CssClass="resume-detail-title"></asp:Label>
                                <asp:Label ID="lblDate" runat="server" CssClass="resume-datail-date"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <div id="resume-description-div">
                                    <asp:Label ID="lblSchool" runat="server" Text='<%# Eval("school") %>' CssClass="resume-datail-company"></asp:Label>
                                </div>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="lblAdditionalInformation" runat="server" Text="Additional Information"
                    CssClass="resume-section"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td>
                            <asp:TextBox ID="txtAddInfo" runat="server" CssClass="input-text" Height="100px"
                                Width="100%" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnSaveAditionalInfo" runat="server" Text="Save Aditional Info" OnClick="btnSaveAditionalInfo_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblResumeAddInfo" runat="server" Text="Professional Goals" CssClass="resume-datail-description"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
