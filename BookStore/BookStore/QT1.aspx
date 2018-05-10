<%@ Page Title="" Language="C#" MasterPageFile="~/QuanTri.master" AutoEventWireup="true" CodeBehind="QT1.aspx.cs" Inherits="BookStore.WebForm1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
    <p>
    Đây là nội dung trang quản trị 1: <br />
    VD5:ĐỌC DỮ LIỆU VÀ ĐƯA LÊN GRIDVIEW
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
        </p>
    <p>
    <br />
    <asp:Button ID="btnThem" runat="server" Text="Thêm" OnClick="btnThem_Click" />
        
        </p>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" EmptyDataText="Không có bản ghi nào" HorizontalAlign="Center" PageSize="4" OnPageIndexChanging="GridView1_PageIndexChanging" OnSorting="GridView1_Sorting" Width="25%">
        </asp:GridView>
    
</asp:Content>

