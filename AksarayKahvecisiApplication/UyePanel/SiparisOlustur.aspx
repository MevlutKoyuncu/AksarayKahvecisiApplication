<%@ Page Title="" Language="C#" MasterPageFile="~/UyePanel/UyeMaster.Master" AutoEventWireup="true" CodeBehind="SiparisOlustur.aspx.cs" Inherits="AksarayKahvecisiApplication.UyePanel.SiparisOlustur" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/FormStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formPanel">
        <div class="panelBaslik">
            <h2>Sipariş Oluştur</h2>
        </div>
        <div class="panelIci">
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="panel basarili" Visible="false">
                <span>Sipariş Oluşturuldu</span>
            </asp:Panel>
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="panel basarisiz" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
            <div class="satir">
                <asp:DropDownList ID="ddl_urunler" runat="server" CssClass="metinkutu" DataTextField="Isim" DataValueField="ID" AppendDataBoundItems="true">
                    <asp:ListItem Value="-1" Text="Ürün seçiniz"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="satir">
                <asp:DropDownList ID="ddl_ureticiulke" runat="server" CssClass="metinkutu" DataTextField="Isim" DataValueField="ID" AppendDataBoundItems="true">
                    <asp:ListItem Value="-1" Text="Ürün türünü seçiniz"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="satir">
                <label>İstenilen Miktar(KG)(Adet)</label><br />
                <asp:TextBox ID="tb_miktar" runat="server" CssClass="metinkutu" placeholder="İstediğiniz miktarı giriniz"></asp:TextBox>
            </div>
            <div class="satir" style="padding-top: 20px;">
                <asp:LinkButton ID="lbtn_siparisolustur" runat="server" CssClass="formbuton" OnClick="lbtn_siparisolustur_Click">Sipariş oluştur</asp:LinkButton>
                <div style="clear: both"></div>
            </div>
        </div>
    </div>
</asp:Content>
