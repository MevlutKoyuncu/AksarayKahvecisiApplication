<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLoginPanel/YoneticiMaster.Master" AutoEventWireup="true" CodeBehind="UrunEkle.aspx.cs" Inherits="AksarayKahvecisiApplication.AdminLoginPanel.UrunEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/FormStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formPanel">
        <div class="panelBaslik">
            <h2>Ürün Ekle</h2>
        </div>
        <div class="panelIci">
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="panel basarili" Visible="false">
                <span>Ürün Ekleme İşlemi Başarılı</span>
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
                <asp:DropDownList ID="ddl_ureticiulke" runat="server" CssClass="metinkutu" DataTextField="Isim" DataValueField="ID" AppendDataBoundItems="true"></asp:DropDownList>
            </div>
            <div class="satir">
                <label>Fiyat</label><br />
                <asp:TextBox ID="tb_fiyat" runat="server" CssClass="metinkutu" placeholder="Fiyat Giriniz"></asp:TextBox>
            </div>
            <div class="satir">
                <label>Stok</label><br />
                <asp:TextBox ID="tb_stok" runat="server" CssClass="metinkutu" placeholder="Stok Miktarı Giriniz"></asp:TextBox>
            </div>
            <div class="satir">
                <asp:CheckBox ID="cb_durum" runat="server" CssClass="check" Text="Ürün Satışta" />
            </div>
            <div class="satir" style="padding-top: 20px;">
                <asp:LinkButton ID="lbtn_ekle" runat="server" CssClass="formbuton" OnClick="lbtn_ekle_Click">Ürünü Ekle</asp:LinkButton>
                <div style="clear: both"></div>
            </div>
        </div>
    </div>
</asp:Content>
