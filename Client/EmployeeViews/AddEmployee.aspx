<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" Inherits="Client.AddEmployee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
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
            <asp:Label ID="lblDept" runat="server" Text="Department : "></asp:Label>
&nbsp;
            <asp:DropDownList ID="ddlDepts" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="btnAddEmp" runat="server" OnClick="btnAddEmp_Click" Text="Add Employee" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
