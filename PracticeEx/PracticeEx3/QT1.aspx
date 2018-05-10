<%@ Page Title="" Language="C#" MasterPageFile="~/QuanTri.master" AutoEventWireup="true" CodeBehind="QT1.aspx.cs" Inherits="PracticeEx3.WebForm1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
    <p>
    Đây là nội dung trang quản trị 1: <br />
    VD3: Thêm bản ghi mới
    </p>
    <p>
     <asp:Label ID="Label1" runat="server" Text="ID hàng:"></asp:Label>
        <asp:TextBox ID="tbIdHang" runat="server"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Text="Tên hàng: "></asp:Label>
        <asp:TextBox ID="tbTenHang" runat="server"></asp:TextBox>
        <asp:Label ID="Label3" runat="server" Text="Thể loại: "></asp:Label>
        <asp:DropDownList ID="ddlLoaiHang" runat="server"></asp:DropDownList>
    </p>
    <p>
    <asp:Label ID="lThongBao" runat="server" Text="Chỗ hiện thông báo!"></asp:Label>
    <br />
    <asp:Button ID="btnThem" runat="server" Text="Thêm" OnClick="btnThem_Click" />
        </p>
</asp:Content>

