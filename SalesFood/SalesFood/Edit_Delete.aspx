<%@ Page Title="" Language="C#" MasterPageFile="~/ProductManager.master" AutoEventWireup="true" CodeBehind="Edit_Delete.aspx.cs" Inherits="SalesFood.WebForm4" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <p>Please input id to identity Product for Delete or Update</p>
    <asp:Label ID="Label6" runat="server" Text="ID">

    </asp:Label><asp:TextBox ID="txtID" runat="server"></asp:TextBox>
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

