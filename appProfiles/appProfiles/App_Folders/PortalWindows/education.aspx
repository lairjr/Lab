<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="education.aspx.cs" Inherits="appProfiles.App_Folders.PortalWindows.education"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="../../App_Folders/JavaScript/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="../../App_Folders/JavaScript/jquery.superbox.js"></script>
    <script type="text/javascript" language="javascript">
        function alertMe() {
            alert('Me');
            $.superbox.close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server"><%--
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
            <div>
                <table>
                    <tr>
                        <td>
                            Job Name:
                        </td>
                        <td>
                            <asp:TextBox ID="txtJobName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Start Date:
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownList1" runat="server">
                                <asp:ListItem Text="12" Value="12" />
                            </asp:DropDownList>
                            <asp:DropDownList ID="DropDownList2" runat="server">
                                <asp:ListItem Text="2009" Value="2009" />
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            End Date:
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownList3" runat="server">
                                <asp:ListItem Text="12" Value="12" />
                            </asp:DropDownList>
                            <asp:DropDownList ID="DropDownList4" runat="server">
                                <asp:ListItem Text="2009" Value="2009" />
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Company Name:
                        </td>
                        <td>
                            <asp:TextBox ID="txtCompanyName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Job Description:
                        </td>
                        <td>
                            <asp:TextBox ID="txtJobDescription" runat="server" Height="78px" TextMode="MultiLine"
                                Width="246px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"  OnClientClick="alertMe()" />
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" />
                        </td>
                    </tr>
                </table>
            </div><%--
        </ContentTemplate>
    </asp:UpdatePanel>--%>
    </form>
</body>
</html>
