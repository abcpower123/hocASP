<%@ Page Title="" Language="C#" MasterPageFile="~/ProductManager.master" AutoEventWireup="true" CodeBehind="List_SearchProduct.aspx.cs" Inherits="SalesFood.WebForm2" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Input anything to search"></asp:Label>
    <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Search" OnClick="Button1_Click" />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="5">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" />
            <asp:BoundField DataField="Name" HeaderText="Tên" />
            <asp:BoundField DataField="Price" HeaderText="Giá" />
            <asp:BoundField DataField="Description" HeaderText="Chi tiết" />
            <asp:ImageField DataImageUrlField="Img" HeaderText="Hình minh họa">
                <ControlStyle Height="200px" Width="250px" />
            </asp:ImageField>
            <asp:BoundField DataField="name2" HeaderText="Phân loại" />
        </Columns>
    </asp:GridView>
    <asp:Label ID="lNoti" runat="server" Text="Noti"></asp:Label>
</asp:Content>

