<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEmployees.aspx.cs" Inherits="Client.ProjectViews.AddEmployees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblAddEmployees" runat="server"></asp:Label>
            <br />
            <asp:CheckBoxList ID="cblEmployees" runat="server"></asp:CheckBoxList>

            <br />
            <asp:Button ID="btnAddEmployees" runat="server" OnClick="btnAddEmployees_Click" Text="Add Employees" />
&nbsp;&nbsp;&nbsp;&nbsp;

            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
