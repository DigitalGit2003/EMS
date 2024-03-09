<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DepartmentEmployees.aspx.cs" Inherits="Client.DepartmentViews.DepartmentEmployees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblDeptEmployees" runat="server" Text="Label"></asp:Label>
            <br />
            <br />

            <asp:GridView ID="gvDeptEmployees" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Salary" HeaderText="Salary" />
                </Columns>
            </asp:GridView>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
