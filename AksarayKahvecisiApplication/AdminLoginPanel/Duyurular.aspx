<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLoginPanel/YoneticiMaster.Master" AutoEventWireup="true" CodeBehind="Duyurular.aspx.cs" Inherits="AksarayKahvecisiApplication.AdminLoginPanel.Duyurular" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/FormStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formpanel">
        <div class="panelbaslik">
            <h2>Duyuru Listesi</h2>
            <a href="DuyuruEkle.aspx" class="saglink formbuton">Duyuru Ekle</a>
        </div>
        <div class="panelici">
            <asp:ListView ID="lv_duyuru" runat="server" OnItemCommand="lv_duyuru_ItemCommand">
                <LayoutTemplate>
                    <table class="tablo" cellpadding="0" cellspacing="0">
                        <tr>
                            <th>Duyuru Başlığı</th>
                            <th>Duyuru İçeriği</th>
                            <th>Tarih ve Saat</th>
                            <th>Seçenekler</th>
                        </tr>
                        <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                        </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Baslik") %></td>
                        <td><%# Eval("Icerik") %></td>
                        <td><%# Eval("Tarih") %></td>
                        <td>
                            <asp:LinkButton ID="lbtn_duyurusil" runat="server" CssClass="tablobuton sil" CommandArgument='<%# Eval("ID") %>' CommandName="sil"></asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
            <div style="clear: both"></div>
        </div>
    </div>
</asp:Content>
