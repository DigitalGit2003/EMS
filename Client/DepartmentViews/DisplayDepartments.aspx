<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DisplayDepartments.aspx.cs" Inherits="Client.DisplayDepartments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="Styles.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="navbar">
            <a href="/DepartmentViews/AddDepartment.aspx">Add Department</a>
            <a href="/DepartmentViews/DisplayDepartments.aspx">Display Departments</a>
        </div>

        <div style="padding:20px">
            <asp:GridView ID="gvDepartments" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Location" HeaderText="Location" />
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            &nbsp
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" CommandArgument='<%# Eval("DeptId") + "," + Container.DataItemIndex %>' ForeColor="Blue" OnClick="btnUpdate_Click" />
                            &nbsp
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandArgument='<%# Eval("DeptId") + "," + Container.DataItemIndex %>' ForeColor="Red" OnClick="btnDelete_Click" />
                            &nbsp
                            <asp:Button ID="btnDeptEmployees" runat="server" Text="Employees" CommandArgument='<%# Eval("DeptId") + "," + Container.DataItemIndex %>' ForeColor="Green" OnClick="btnDeptEmployees_Click" />
                            &nbsp
                            <asp:Button ID="btnDeptProjects" runat="server" Text="Projects" CommandArgument='<%# Eval("DeptId") + "," + Container.DataItemIndex %>' ForeColor="Black" OnClick="btnDeptProjects_Click" />
                            &nbsp
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
