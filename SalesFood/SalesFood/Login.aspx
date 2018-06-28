<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SalesFood.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contain" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
    <asp:TextBox ID="tbUser" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
    <asp:TextBox ID="tbPass" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" Width="69px" />
    <asp:Button ID="Button2" runat="server" Text="Register" style="margin-left: 76px" OnClick="Button2_Click" />
    <br />
    <asp:Label ID="lbnoti" runat="server" Text="Enter username and password"></asp:Label>
</asp:Content>

