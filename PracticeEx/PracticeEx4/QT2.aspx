<%@ Page Title="" Language="C#" MasterPageFile="~/QuanTri.master" AutoEventWireup="true" CodeBehind="QT2.aspx.cs" Inherits="PracticeEx4.WebForm2" %>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
    
    <p>
    Đây là nội dung trang quản trị 2: <br />
    VD4: Update bản ghi <br />
    Nhập vào id và các thông tin mới để cập nhật
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
    <asp:Button ID="btnSua" runat="server" Text="Sửa" OnClick="btnSua_Click" />
        </p>
</asp:Content>

