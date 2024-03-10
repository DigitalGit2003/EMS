<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateProject.aspx.cs" Inherits="Client.ProjectViews.UpdateProject" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblUpdateProj" runat="server" Text="Update Project Form"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Label ID="lblTitle" runat="server" Text="Title : "></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tbTitle" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblStatus" runat="server" Text="Status : "></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tbStatus" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnUpdateProj" runat="server" OnClick="btnUpdateProj_Click" OnClientClick="btnUpdateProj" Text="Update Project" />
            <br />
        </div>
    </form>
</body>
</html>
