<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateEmployee.aspx.cs" Inherits="Client.EmployeeViews.UpdateEmployee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblUpdateEmp" runat="server" Text="Update Employee Form"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Label ID="lblName" runat="server" Text="Name : "></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblSalary" runat="server" Text="Salary : "></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tbSalary" runat="server" TextMode="Number"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnUpdateEmp" runat="server" OnClick="btnUpdateEmp_Click" OnClientClick="btnUpdateEmp" Text="Update Employee" />
            <br />
        </div>
    </form>
</body>
</html>
