<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="SalesFood.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contain" runat="server">
    <asp:Label ID="Label1" runat="server" Text="UserName"></asp:Label>

    <asp:TextBox ID="tbUserName" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
    <asp:TextBox ID="tbPass" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label3" runat="server" Text="FullName"></asp:Label>
    <asp:TextBox ID="tbName" runat="server"></asp:TextBox>

    <asp:Button ID="Button1" runat="server" Text="Register" OnClick="Button1_Click" />
    <br />
    <asp:Label ID="lbthongbao" runat="server" Text="Noti"></asp:Label>

</asp:Content>

