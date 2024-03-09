<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProject.aspx.cs" Inherits="Client.AddProject" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblAddProj" runat="server" Text="Add Project Form"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblTitle" runat="server" Text="Title : "></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tbTitle" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblStatus" runat="server" Text="Status : "></asp:Label>
&nbsp;
            <asp:TextBox ID="tbStatus" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblDept" runat="server" Text="Department : "></asp:Label>
&nbsp;<asp:DropDownList ID="ddlDepts" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="btnAddProj" runat="server" OnClick="btnAddProj_Click" Text="Add Project" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
