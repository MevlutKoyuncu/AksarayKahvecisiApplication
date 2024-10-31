<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLoginPanel/YoneticiMaster.Master" AutoEventWireup="true" CodeBehind="UrunListesi.aspx.cs" Inherits="AksarayKahvecisiApplication.AdminLoginPanel.UrunListesi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/FormStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formpanel">
        <div class="panelbaslik">
            <h2>Ürün Listelesi</h2>
            <a href="UrunEkle.aspx" class="saglink formbuton">Ürün Ekle</a>
            <asp:LinkButton ID="lbtn_azalanurunler" runat="server" OnClick="lbtn_azalanurunler_Click" CssClass="formbuton saglink2">Azalan Ürünleri Göster</asp:LinkButton>
        </div>
        <div class="panelici">
            <asp:ListView ID="lv_urunler" runat="server" OnItemCommand="lv_urunler_ItemCommand">
                <LayoutTemplate>
                    <table class="tablo" cellpadding="0" cellspacing="0">
                        <tr>
                            <th width="1%">Ürün No</th>
                            <th width="7%">Ürün Adı</th>
                            <th width="1%">Satıcı</th>
                            <th width="1%">Üretici Ülke</th>
                            <th width="1%">Fiyat</th>
                            <th width="2%">Stok(KG)(Adet)</th>
                            <th width="1%">Satışta mı</th>
                            <th width="1%">Seçenekler</th>
                        </tr>
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("ID") %></td>
                        <td><%# Eval("Isim") %></td>
                        <td><%# Eval("Satici") %></td>
                        <td><%# Eval("UreticiUlke") %></td>
                        <td><%# Eval("Fiyat") %>₺</td>
                        <td><%# Eval("Stok")%></td>
                        <td><%# Eval("SatistamiStr") %></td>
                        <td>
                            <asp:LinkButton ID="lbtn_durumdegistir" runat="server" CssClass="tablobuton satistami" CommandArgument='<%# Eval("ID") %>' CommandName="satistami"></asp:LinkButton>
                            <asp:LinkButton ID="lbtn_sil" runat="server" CssClass="tablobuton sil" CommandArgument='<%# Eval("ID") %>' CommandName="sil"></asp:LinkButton>
                            <a href='UrunDuzenle.aspx?uid=<%# Eval("ID") %>' class="tablobuton duzenle"></a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
            <div style="clear: both"></div>
        </div>
    </div>
</asp:Content>
