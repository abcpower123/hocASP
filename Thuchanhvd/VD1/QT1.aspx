<%@ Page Title="" Language="C#" MasterPageFile="~/QuanTri.master" AutoEventWireup="true" CodeFile="QT1.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="maincontent">
       <p> Nội dung Quản trị 1
           </p>
     <table>
        <tr>
            <td>ID:</td><td>
            <asp:TextBox ID="tbID" runat="server" Width="83px"></asp:TextBox>
            </td>
            <td>Tên:</td><td>
            <asp:TextBox ID="tbTen" runat="server"></asp:TextBox>
            </td>
            <td>Thể loại:</td><td>
            <asp:DropDownList ID="ddlTheLoai" runat="server">
            </asp:DropDownList>
            </td>
        </tr>
    </table>
    <asp:Label ID="lThongBao" runat="server" Text="Chỗ hiện thông báo"></asp:Label>
    <br />
    <asp:Button ID="bThemMoi" runat="server" OnClick="bThemMoi_Click" Text="Thêm" />
       <br />
    </asp:Content>


