<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="SalesFood.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contain" runat="server">
   <h2>List 30 lucky custormer get 30% discount this week:</h2>
    <asp:Button ID="Button1" runat="server" Text="Button" />
    <asp:GridView ID="GridView1" runat="server" HorizontalAlign="Center" AllowPaging="True" PageSize="20" OnPageIndexChanging="GridView1_PageIndexChanging">
    </asp:GridView>
</asp:Content>

