<%@ Page Title="" Language="C#" MasterPageFile="~/Kullanici.Master" AutoEventWireup="true" CodeBehind="Hakkimda.aspx.cs" Inherits="DiziYorumProje.Hakkimda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<div class="about-content">
		<div class="container">
			<div class="about-section">
				<div class="contact-info">
					<h2>Hakkımızda</h2>
						<asp:Repeater ID="Repeater1" runat="server">
							<ItemTemplate>
								<p><%# Eval("ACIKLAMA") %></p>
							</ItemTemplate>
                        </asp:Repeater>
                </div>
			</div>		 
		</div>
	</div>

</asp:Content>
