<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="SalesFood.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contain" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Are you sure to logout?"></asp:Label>
    <br />
    <asp:Button ID="Button1" runat="server" Text="Logout" OnClick="Button1_Click" />
</asp:Content>

