<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLoginPanel/YoneticiMaster.Master" AutoEventWireup="true" CodeBehind="DuyuruEkle.aspx.cs" Inherits="AksarayKahvecisiApplication.AdminLoginPanel.DuyuruEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/FormStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formPanel">
        <div class="panelBaslik">
            <h2>Duyuru Ekle</h2>
        </div>
        <div class="panelIci">
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="panel basarili" Visible="false">
                <span>Duyuru Ekleme İşlemi Başarılı</span>
            </asp:Panel>
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="panel basarisiz" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
            <div class="satir">
                <label>Başlık</label><br />
                <asp:TextBox ID="tb_baslik" runat="server" CssClass="metinkutu" placeholder="Konu Başlığı Giriniz"></asp:TextBox>
            </div>
            <div class="satir">
                <label>İçerik</label><br />
                <asp:TextBox ID="tb_icerik" runat="server" CssClass="metinkutu" placeholder="İçeriği Giriniz"></asp:TextBox>
            </div>
            <div class="satir" style="padding-top: 20px;">
                <asp:LinkButton ID="lbtn_duyuruekle" runat="server" CssClass="formbuton" OnClick="lbtn_duyuruekle_Click">Duyuru Ekle</asp:LinkButton>
                <div style="clear: both"></div>
            </div>
        </div>
    </div>
</asp:Content>
