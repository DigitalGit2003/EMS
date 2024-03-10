<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" Inherits="Client.AddEmployee" %>

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
            <a href="/EmployeeViews/AddEmployee.aspx?deptName=<%= Server.UrlEncode(dept_name) %>">Add Employee</a>
            <a href="/DepartmentViews/DepartmentEmployees.aspx?deptName=<%= Server.UrlEncode(dept_name) %>">Display Employees</a>
            <a href="/DepartmentViews/DisplayDepartments.aspx">Back</a>
        </div>

        <div style="padding: 20px">
            <asp:Label ID="lblAddEmp" runat="server" Text="Add Employee Form"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblName" runat="server" Text="Name : "></asp:Label>
            &nbsp;
            <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblSalary" runat="server" Text="Salary : "></asp:Label>
            &nbsp;<asp:TextBox ID="tbSalary" runat="server" TextMode="Number"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnAddEmp" runat="server" OnClick="btnAddEmp_Click" Text="Add Employee" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
