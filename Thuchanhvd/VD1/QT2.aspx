<%@ Page Title="" Language="C#" MasterPageFile="~/QuanTri.master" AutoEventWireup="true" CodeFile="QT2.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="maincontent">
        Nội dung Quản trị 2

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
            <asp:BoundField DataField="ten" HeaderText="ten" SortExpression="ten" />
            <asp:BoundField DataField="maTheLoai" HeaderText="maTheLoai" SortExpression="maTheLoai" />
            <asp:BoundField DataField="tenTheLoai" HeaderText="tenTheLoai" SortExpression="tenTheLoai" />
        </Columns>
</asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=.;Initial Catalog=Sample;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT HangHoa.*, TheLoai.tenTheLoai FROM HangHoa INNER JOIN TheLoai ON HangHoa.maTheLoai = TheLoai.maTheLoai"></asp:SqlDataSource>
    </asp:Content>


