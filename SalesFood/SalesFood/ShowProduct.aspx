<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/Custormer.master" AutoEventWireup="true" CodeBehind="ShowProduct.aspx.cs" Inherits="SalesFood.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:DataList ID="DataList1" runat="server" RepeatColumns="3" GridLines="Both" OnSelectedIndexChanged="DataList1_SelectedIndexChanged">
        <ItemTemplate>
                <asp:Table ID="Table1" runat="server">
                    <asp:TableRow runat="server" >
                        <asp:TableCell runat="server" Width="200">
                    
                    Name:        <asp:Label ID="lbName" runat="server" Text='<%# Eval("Name") %>'></asp:Label><br />
                    Price:        <asp:Label ID="lbPrice" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                            <br />
                            <asp:Button  ButtonType="LinkButton" ID="btnOrder" runat="server" OnClick="btnOrder_Click" Text="Order" ToolTip='<%# Eval("Id") %>'/>
                        </asp:TableCell>
                        <asp:TableCell runat="server" Width="200">
                            <asp:Image ID="hinhAnh" runat="server" Height="90" Width="200" ImageUrl='<%#Eval("Img")%>' />

                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </ItemTemplate>
    </asp:DataList>
    
    <asp:Label ID="lbnoti" runat="server" Text="Welcome"></asp:Label>
    
</asp:Content>
