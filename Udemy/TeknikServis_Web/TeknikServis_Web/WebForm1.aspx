<%@ Page Title="" Language="C#" MasterPageFile="~/Kullanici.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="TeknikServis_Web.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="Label1" runat="server" Text="Ürün Seri No :" Font-Bold="true"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Ara" OnClick="Button1_Click" CssClass="btn btn-primary" />

    <table class="table table-bordered"; style="margin-top:15px">
        <tr>
            <th>AÇIKLAMA</th>
            <th>TARİH</th>
        </tr>
        
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <tr>
                <td><%# Eval("ACIKLAMA") %></td>
                <td><%# Eval("TARIH") %></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>

    </table>

</asp:Content>
