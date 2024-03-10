﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddDepartment.aspx.cs" Inherits="Client.AddDepartment" %>

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
            <asp:Label ID="lblAddDept" runat="server" Text="Add Department Form"></asp:Label>
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
            <asp:Button ID="btnAddDept" runat="server" OnClick="btnAddDept_Click" OnClientClick="btnAddDept" Text="Add Department" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
        </div>
    </form>
</body>
</html>
