<%@ Page Title="" Language="C#" MasterPageFile="~/Custormer.master" AutoEventWireup="true" CodeBehind="ProductDetail.aspx.cs" Inherits="SalesFood.WebForm9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div >
    <h2 style="text-align:center;">
        Infomation of product</h2>
    
    <asp:Image ID="Image1" runat="server" Height="300px" Width="500px" ImageAlign="Middle"/>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Name: " Font-Bold="True" Font-Size="16pt"></asp:Label>
    
    <asp:Label ID="lbName" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="lbID" runat="server" Text="Label" Visible="False"></asp:Label>
    <br />
    <asp:Label ID="Label4" runat="server" Text="Category: " Font-Bold="True" Font-Size="16pt"></asp:Label>
    <asp:Label ID="lbcate" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Label ID="Label6" runat="server" Text="Price: " Font-Bold="True" Font-Size="16pt"></asp:Label>
    <asp:Label ID="lbprice" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Label ID="Label8" runat="server" Text="Descrpittion: " Font-Bold="True" Font-Size="16pt"></asp:Label>
    <asp:Label ID="lbDes" runat="server" Text="Label"></asp:Label>
        <br />
    <asp:Label ID="Label1" runat="server" Text="Quantitiy" Font-Bold="True" Font-Size="16pt"></asp:Label>    
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
            <asp:ListItem>6</asp:ListItem>
            <asp:ListItem>7</asp:ListItem>
            <asp:ListItem>8</asp:ListItem>
            <asp:ListItem>9</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Order this product" OnClick="Button1_Click" />
        <br />
        <asp:Label ID="lbthongbao" runat="server" Text="Connect success"></asp:Label>
        </div>
</asp:Content>
