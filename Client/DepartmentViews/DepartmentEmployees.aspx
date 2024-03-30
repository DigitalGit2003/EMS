<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DepartmentEmployees.aspx.cs" Inherits="Client.DepartmentViews.DepartmentEmployees" %>

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
            <a href="/EmployeeViews/AddEmployee.aspx?deptId=<%= Server.UrlEncode(dept_id) %>">Add Employee</a>
            <a href="/DepartmentViews/DepartmentEmployees.aspx?deptId=<%= Server.UrlEncode(dept_id) %>">Display Employees</a>
            <a href="/DepartmentViews/DisplayDepartments.aspx">Back</a>
        </div>

        <div style="padding: 20px">
            <asp:Label ID="lblDeptEmployees" runat="server" Text="Label"></asp:Label>
            <br />
            <br />

            <asp:GridView ID="gvDeptEmployees" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Salary" HeaderText="Salary" />
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            &nbsp
        <asp:Button ID="btnUpdate" runat="server" Text="Update" CommandArgument='<%# Eval("EmpId") + "," + Container.DataItemIndex %>' ForeColor="Blue" OnClick="btnUpdate_Click" />
                            &nbsp
        <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandArgument='<%# Eval("EmpId") + "," + Container.DataItemIndex %>' ForeColor="Red" OnClick="btnDelete_Click" />
                            &nbsp
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
        </div>
    </form>
</body>
</html>
