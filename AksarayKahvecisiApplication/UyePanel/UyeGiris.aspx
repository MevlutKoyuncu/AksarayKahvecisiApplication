<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UyeGiris.aspx.cs" Inherits="AksarayKahvecisiApplication.UyePanel.UyeGiris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Üye Giriş Paneli</title>
    <link href="CSS/LoginStyle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="karsilama">
                <div class="satir">
                    <h1>Üye Giriş Paneli</h1>
                </div>
                <asp:Panel ID="pnl_hata" runat="server" CssClass="hatakutu" Visible="false">
                    <asp:Label ID="lbl_hatametin" runat="server"></asp:Label>
                </asp:Panel>
                <div class="satir">
                    <label>Kullanıcı Adı Giriş</label>
                    <asp:TextBox ID="tb_uyekadi" runat="server" placeholder="Kullanıcı adınızı giriniz" CssClass="metinkutu" Text="EskiCoffeeShop"></asp:TextBox>
                </div>
                <div class="satir">
                    <label>Şifre</label>
                    <asp:TextBox ID="tb_uyesifre" runat="server" placeholder="Şifrenizi giriniz" TextMode="Password" CssClass="metinkutu"></asp:TextBox>
                </div>
                <div class="satir">
                    <asp:LinkButton ID="lbtn_uyegiris" runat="server" OnClick="lbtn_uyegiris_Click" CssClass="buton">Giriş</asp:LinkButton>
                </div>
            </div>
            <div style="clear: both"></div>
        </div>

    </form>
</body>
</html>
