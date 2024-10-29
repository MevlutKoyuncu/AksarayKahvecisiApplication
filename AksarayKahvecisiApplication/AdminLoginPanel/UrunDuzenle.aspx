<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLoginPanel/YoneticiMaster.Master" AutoEventWireup="true" CodeBehind="UrunDuzenle.aspx.cs" Inherits="AksarayKahvecisiApplication.AdminLoginPanel.UrunDuzenle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/FormStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formPanel">
        <div class="panelBaslik">
            <h3>Ürün Düzenle</h3>
        </div>
        <div class="panelIci">
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="panel basarili" Visible="false">
                <span>Ürün Düzenleme İşlemi Başarılı</span>
            </asp:Panel>
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="panel basarisiz" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
            <div class="satir">
                <label>Ürün Adı</label><br />
                <asp:TextBox ID="tb_isim" runat="server" CssClass="metinkutu" placeholder="Ürün Adı Giriniz"></asp:TextBox>
            </div>
            <div class="satir">
                <label>Satıcı Adı</label><br />
                <asp:TextBox ID="tb_satici" runat="server" CssClass="metinkutu" placeholder="Satıcı Adı Giriniz"></asp:TextBox>
            </div>
            <div class="satir">
                <label>Üretici Ülke</label><br />
                <asp:TextBox ID="tb_ureticiulke" runat="server" CssClass="metinkutu" placeholder="Üretici Ülke Giriniz"></asp:TextBox>
            </div>
            <div class="satir">
                <label>Fiyat</label><br />
                <asp:TextBox ID="tb_fiyat" runat="server" CssClass="metinkutu" placeholder="Yeni Fiyat Giriniz"></asp:TextBox>
            </div>
            <div class="satir">
                <label>Stok</label><br />
                <asp:TextBox ID="tb_stok" runat="server" CssClass="metinkutu" placeholder="Stok Miktarı Giriniz"></asp:TextBox>
            </div>
            <div class="satir">
                <asp:CheckBox ID="cb_durum" runat="server" CssClass="check" Text="Ürün Satışta" />
            </div>
            <div class="satir" style="padding-top: 20px;">
                <asp:LinkButton ID="lbtn_duzenle" runat="server" CssClass="formbuton" OnClick="lbtn_duzenle_Click">Ürün Düzenle</asp:LinkButton>
                <div style="clear: both"></div>
            </div>
        </div>
    </div>
</asp:Content>
