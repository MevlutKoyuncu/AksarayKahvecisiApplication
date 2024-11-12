<%@ Page Title="" Language="C#" MasterPageFile="~/UyePanel/UyeMaster.Master" AutoEventWireup="true" CodeBehind="Siparislerim.aspx.cs" Inherits="AksarayKahvecisiApplication.UyePanel.Siparislerim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="CSS/FormStyle.css" rel="stylesheet" />
    <div class="formpanel">
        <div class="panelbaslik">
            <h2>Siparişlerim</h2>
            <div class="panelici">
                <asp:ListView ID="lv_siparisler" runat="server" OnItemCommand="lv_siparisler_ItemCommand">
                    <LayoutTemplate>
                        <table class="tablo" cellpadding="0" cellspacing="0">
                            <tr>
                                <th width="1%">Siparis No</th>
                                <th width="7%">Ürün Adı</th>
                                <th width="1%">Türü</th>
                                <th width="1%">Miktar</th>
                                <th width="1%">Sipariş Tarihi</th>
                                <th width="1%">Toplam Fiyat</th>
                                <th width="2%">Durumu</th>
                            </tr>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("ID") %></td>
                            <td><%# Eval("UrunIsim") %></td>
                            <td><%# Eval("TurIsim") %></td>
                            <td><%# Eval("Miktar") %></td>
                            <td><%# Eval("Tarih") %></td>
                            <td><%# Eval("ToplamFiyat") %> ₺</td>
                            <td><%# Eval("DurumIsim") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
                <div style="clear: both"></div>
            </div>
        </div>
    </div>
</asp:Content>
