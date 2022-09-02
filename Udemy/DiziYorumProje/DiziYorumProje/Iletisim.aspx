<%@ Page Title="" Language="C#" MasterPageFile="~/Kullanici.Master" AutoEventWireup="true" CodeBehind="Iletisim.aspx.cs" Inherits="DiziYorumProje.Iletisim" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="contact-content">
	 <div class="container">
		     <div class="contact-info">
			 <h2>İletişim</h2>
			 <p>Blog sayfamızda bulunan film ve dizilere eklemek istedikleriniz için veya yorumlarda yaşayacağınız herhangi bir problemde bizimle aşağıda bulunan form yardımıyla iletişime geçebilirsiniz.
				 Mesaj gönderme sırasında lütfen mail adresinizi kontrol ederek, doğruluğundan emin olarak iletilerinizi gönderiniz.Sorunlarınızın çözümü için sizinle mail adresinizden iletişime geçilecektir.
			 </p>
			 </div>
			 <div class="contact-details">				 
			 <form runat="server">
                 <asp:TextBox ID="TxtAdSoyad" runat="server" placeholder="Ad Soyad" required=""></asp:TextBox>
				 <br />
				 <asp:TextBox ID="TxtMail" runat="server" placeholder="Email" required=""></asp:TextBox>
				 <asp:TextBox ID="TxtTelefon" runat="server" placeholder="Telefon" required=""></asp:TextBox>
				 <asp:TextBox ID="TxtKonu" runat="server" placeholder="Konu" required=""></asp:TextBox>
				 <asp:TextBox ID="TxtMesaj" runat="server" placeholder="Mesajınız..." required="" TextMode="MultiLine"></asp:TextBox>
                 <asp:Button ID="BtnGonder" runat="server" Text="Gönder" OnClick="BtnGonder_Click" />
			 </form>
		  </div>
		  <div class="contact-details">
			  <div class="col-md-6 contact-map">
				 <h4>Biz Buradayız</h4>
			<div class="mapouter"><div class="gmap_canvas"><iframe width="600" height="500" id="gmap_canvas" 
				src="https://maps.google.com/maps?q=Ankara%20bilkent&t=&z=13&ie=UTF8&iwloc=&output=embed" 
				frameborder="0" scrolling="no" marginheight="0" marginwidth="0"></iframe>
				<a href="https://www.whatismyip-address.com"></a></div>
				<style>.mapouter{position:relative;text-align:right;height:500px;width:600px;}.gmap_canvas
			    {overflow:hidden;background:none!important;height:500px;width:600px;}</style></div>	
			  </div>
			  <div class="col-md-6 company_address">		 
					<h4>Adresimiz</h4>
					<p>Bilkent CyberPark</p>
					<p>C Blok 6.Kat No:65</p>
					<p>Bilkent / Ankara</p>
					<p>Telefon : (90) 222 666 444</p>
					<p>Fax : (000) 123 456 78 0</p>
					<p>Email : <a href="mailto:info@example.com">info@mycompany.com</a></p>
					<p>Takip Et : <a href="#">Facebook</a>, <a href="#">Twitter</a></p>
			 </div>
			  <div class="clearfix"></div>
	     </div>		 
</div>
	 </div>

</asp:Content>
