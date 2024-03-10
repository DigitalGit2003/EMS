<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateDepartment.aspx.cs" Inherits="Client.UpdateDepartment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblUpdateDept" runat="server" Text="Update Department Form"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Label ID="lblName" runat="server" Text="Name : "></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblLocation" runat="server" Text="Location : "></asp:Label>
            &nbsp;&nbsp;
            <asp:TextBox ID="tbLocation" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnUpdateDept" runat="server" OnClick="btnUpdateDept_Click" OnClientClick="btnUpdateDept" Text="Update Department" />
            <br />
        </div>
    </form>
</body>
</html>
