<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProject.aspx.cs" Inherits="Client.AddProject" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="Styles.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="navbar">
            <%
                string dept_name = Request.QueryString["deptName"];
            %>
            <a href="/ProjectViews/AddProject.aspx?deptName=<%= Server.UrlEncode(dept_name) %>">Add Project</a>
            <a href="/DepartmentViews/DepartmentProjects.aspx?deptName=<%= Server.UrlEncode(dept_name) %>">Display Projects</a>
            <a href="/DepartmentViews/DisplayDepartments.aspx">Back</a>
        </div>

        <div style="padding: 20px">
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
            <asp:Button ID="btnAddProj" runat="server" OnClick="btnAddProj_Click" Text="Add Project" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
