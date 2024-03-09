<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DepartmentProjects.aspx.cs" Inherits="Client.DepartmentViews.DepartmentProjects" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblDeptProjects" runat="server" Text="Label"></asp:Label>
            <br />
            <br />

            <asp:GridView ID="gvDeptProjects" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Title" HeaderText="Title" />
                    <asp:BoundField DataField="Status" HeaderText="Status" />
                </Columns>
            </asp:GridView>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
