<%@ Page Title="" Language="C#" MasterPageFile="~/ProductManager.master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="SalesFood.WebForm3" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div  >
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
    <asp:Button ID="Button1" runat="server" Text="ADD" OnClick="Button1_Click" />
   

 <br />
    <asp:Label ID="lbNoti" runat="server" Text="Noti here"></asp:Label>

        </div>
</asp:Content>

