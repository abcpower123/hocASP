<%@ Page Title="" Language="C#" MasterPageFile="~/QuanTri.master" AutoEventWireup="true" CodeBehind="QT1.aspx.cs" Inherits="PracticeEx2.WebForm1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
    <p>
    Đây là nội dung trang quản trị 1: <br />
    VD2: Đọc dữ liệu và đưa vào dropdownlist
    </p>
     <asp:Label ID="Label1" runat="server" Text="ID hàng:"></asp:Label>
        <asp:TextBox ID="tbIdHang" runat="server"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Text="Tên hàng: "></asp:Label>
        <asp:TextBox ID="tbTenHang" runat="server"></asp:TextBox>
        <asp:Label ID="Label3" runat="server" Text="Thể loại: "></asp:Label>
        <asp:DropDownList ID="ddlLoaiHang" runat="server"></asp:DropDownList>
    
</asp:Content>

