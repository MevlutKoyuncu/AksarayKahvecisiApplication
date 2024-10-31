<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YoneticiGiris.aspx.cs" Inherits="AksarayKahvecisiApplication.AdminLoginPanel.YoneticiGiris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Yönetici Giriş Paneli</title>
    <link href="CSS/LoginStyle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
    <div class="karsilama">
        <div class="satir">
          <h1>Yönetici Paneli</h1>
        </div>
        <asp:Panel ID="pnl_hata" runat="server" CssClass="hatakutu" Visible="false">
            <asp:Label ID="lbl_hatametin" runat="server"></asp:Label>
        </asp:Panel>
        <div class="satir">
            <label>Maille Giriş</label>
            <asp:TextBox ID="tb_mail" runat="server" placeholder="Mailinizi giriniz" CssClass="metinkutu" Text="akcs@akcs.com"></asp:TextBox>
        </div>
        <div class="satir">
            <label>Şifre</label>
            <asp:TextBox ID="tb_sifre" runat="server" placeholder="Şifrenizi giriniz" TextMode="Password" CssClass="metinkutu"></asp:TextBox>
        </div>
        <div class="satir">
            <asp:LinkButton ID="lbtn_giris" runat="server" OnClick="lbtn_giris_Click" CssClass="buton">Giriş</asp:LinkButton>
        </div>
    </div>
    <div style="clear: both"></div>
</div>

    </form>
</body>
</html>
