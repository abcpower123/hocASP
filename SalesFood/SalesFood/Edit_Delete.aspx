<%@ Page Title="" Language="C#" MasterPageFile="~/ProductManager.master" AutoEventWireup="true" CodeBehind="Edit_Delete.aspx.cs" Inherits="SalesFood.WebForm4" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <p>Please input id to identity Product for Delete or Update</p>
    <asp:Label ID="Label6" runat="server" Text="ID">

    </asp:Label><asp:TextBox ID="txtID" runat="server"></asp:TextBox>
     <asp:Button ID="Button3" runat="server" Text="check" OnClick="Button3_Click" />
     <asp:DataList ID="DataList1" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" ShowFooter="False" ShowHeader="False">
         <ItemTemplate>
                <asp:Table ID="Table1" runat="server">
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">
                    
                    Name:        <asp:Label ID="lbName" runat="server" Text='<%# Eval("Name") %>'></asp:Label><br />
                    Price:        <asp:Label ID="lbPrice" runat="server" Text='<%# Eval("Price") %>'></asp:Label>

                        </asp:TableCell>
                        <asp:TableCell runat="server" Width="200px">
                            <asp:Image ID="hinhAnh" runat="server" Height="90" Width="180" ImageUrl='<%#Eval("Img")%>' />

                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </ItemTemplate>
     </asp:DataList>
    <br />
    <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
     <br />
    
    <asp:Label ID="Label3" runat="server" Text="Price">

    </asp:Label><asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label4" runat="server" Text="Category">

    </asp:Label><asp:DropDownList ID="dpCategory" runat="server"></asp:DropDownList>
    
    <br />
        
      <asp:Label ID="Label5" runat="server" Text="Choose image"></asp:Label>
        <asp:FileUpload ID="FileUpload1" runat="server" />
         <br />
        
    <asp:Label ID="Label2" runat="server" Text="Description"></asp:Label>
    
    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine"></asp:TextBox>
        <br />
    <asp:Button ID="Button1" runat="server" Text="Update" OnClick="Button1_Click" />
    <asp:Button ID="Button2" runat="server" Text="Delete" OnClick="Button2_Click" />

 <br />
    <asp:Label ID="lbNoti" runat="server" Text="Noti here"></asp:Label>
</asp:Content>

