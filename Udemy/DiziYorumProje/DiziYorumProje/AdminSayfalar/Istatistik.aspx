<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Istatistik.aspx.cs" Inherits="DiziYorumProje.AdminSayfalar.Istatistik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table class="table table-bordered">
        <tr>
            <td>Toplam Blog Sayısı : <b><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></b></td>
            <td>Toplam Yorum Sayısı : <b><asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></b></td>
            <td>Toplam Film Sayısı : <b><asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></b></td>
        </tr>

        <tr>
            <td>Toplam Dizi Sayısı : <b><asp:Label ID="Label4" runat="server" Text="Label"></asp:Label></b></td>
            <td>Toplam Animasyon Sayısı : <b><asp:Label ID="Label5" runat="server" Text="Label"></asp:Label></b></td>
            <td>En Fazla Yorumlu Blog : <b><asp:Label ID="Label6" runat="server" Text="Label"></asp:Label></b></td>
        </tr>
    </table>

</asp:Content>
