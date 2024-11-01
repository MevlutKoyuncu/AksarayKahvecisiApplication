<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLoginPanel/YoneticiMaster.Master" AutoEventWireup="true" CodeBehind="Duyurular.aspx.cs" Inherits="AksarayKahvecisiApplication.AdminLoginPanel.Duyurular" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/FormStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formpanel">
        <div class="panelbaslik">
            <h2>Ürün Listelesi</h2>
            <a href="DuyuruEkle.aspx" class="saglink formbuton">Ürün Ekle</a>
            <asp:LinkButton ID="lbtn_azalanurunler" runat="server" OnClick="lbtn_azalanurunler_Click" CssClass="formbuton saglink2">Azalan Ürünleri Göster</asp:LinkButton>
        </div>
        <div class="panelici">
            <asp:ListView ID="lv_urunler" runat="server" OnItemCommand="lv_urunler_ItemCommand">
                <LayoutTemplate>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Baslik") %></td>
                        <td><%# Eval("Icerik") %></td>
                        <td><%# Eval("Tarih") %></td>
                        <td>
                            <asp:LinkButton ID="lbtn_durumsil" runat="server" CssClass="tablobuton sil" CommandArgument='<%# Eval("ID") %>' CommandName="sil"></asp:LinkButton>
                            <a href='DuyuruDuzenle.aspx?uid=<%# Eval("ID") %>' class="tablobuton duzenle"></a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
            <div style="clear: both"></div>
        </div>
    </div>
</asp:Content>
