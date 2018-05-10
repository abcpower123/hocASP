<%@ Page Title="" Language="C#" MasterPageFile="~/NhanVien.master" AutoEventWireup="true" CodeBehind="NhanVien.aspx.cs" Inherits="PracticeEx7.WebForm3" %>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
    <p>
        Đây là nội dung trang quản lí nhân viên</p>

    <asp:GridView ID="GridView1" runat="server" HorizontalAlign="Center" AllowPaging="True" PageSize="20" OnPageIndexChanging="GridView1_PageIndexChanging">
    </asp:GridView>
</asp:Content>

