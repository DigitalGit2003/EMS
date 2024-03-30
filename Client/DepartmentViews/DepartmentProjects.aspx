<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DepartmentProjects.aspx.cs" Inherits="Client.DepartmentViews.DepartmentProjects" %>

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
                string dept_id = Request.QueryString["deptId"];
            %>
            <a href="/ProjectViews/AddProject.aspx?deptId=<%= Server.UrlEncode(dept_id) %>">Add Project</a>
            <a href="/DepartmentViews/DepartmentProjects.aspx?deptId=<%= Server.UrlEncode(dept_id) %>">Display Projects</a>
            <a href="/DepartmentViews/DisplayDepartments.aspx">Back</a>
        </div>

        <div style="padding: 20px">
            <asp:Label ID="lblDeptProjects" runat="server" Text="Label"></asp:Label>
            <br />
            <br />

            <asp:GridView ID="gvDeptProjects" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Title" HeaderText="Title" />
                    <asp:BoundField DataField="Status" HeaderText="Status" />
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            &nbsp
        <asp:Button ID="btnUpdate" runat="server" Text="Update" CommandArgument='<%# Eval("ProjId") + "," + Container.DataItemIndex %>' ForeColor="Blue" OnClick="btnUpdate_Click" />
                            &nbsp
        <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandArgument='<%# Eval("ProjId") + "," + Container.DataItemIndex %>' ForeColor="Red" OnClick="btnDelete_Click" />
                            &nbsp
        <asp:Button ID="btnAddEmployees" runat="server" Text="Add Employees" CommandArgument='<%# Eval("ProjId") + "," + Container.DataItemIndex %>' ForeColor="Black" OnClick="btnAddEmployees_Click" />
                            &nbsp
        <asp:Button ID="btnViewEmployees" runat="server" Text="View Employees" CommandArgument='<%# Eval("ProjId") + "," + Container.DataItemIndex %>' ForeColor="Green" OnClick="btnViewEmployees_Click" />
                            &nbsp
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
