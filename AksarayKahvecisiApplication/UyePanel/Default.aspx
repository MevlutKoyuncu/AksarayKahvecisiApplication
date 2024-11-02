<%@ Page Title="" Language="C#" MasterPageFile="~/UyePanel/UyeMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AksarayKahvecisiApplication.UyePanel.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/FormStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formpanel">
        <div class="panelbaslik">
            <h2>
                <marquee behavior="scroll" direction="right" scrollamount="10">DUYURULAR</marquee>
            </h2>
        </div>
        <div class="panelici">
            <asp:ListView ID="lv_duyuru1" runat="server" OnItemCommand="lv_duyuru1_ItemCommand">
                <LayoutTemplate>
                    
                    <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                </LayoutTemplate>
                <ItemTemplate>
                    <div class="satir">
                        <h4><td class="duyurubaslik"><%# Eval("Baslik") %></td><br></h4>
                        <td><%# Eval("Icerik") %></td>
                        <td>Duyuru Tarihi: <%# Eval("Tarih") %></td>
                    </div>
                    </tr>
                </ItemTemplate> 
            </asp:ListView>
            <div style="clear: both"></div>
        </div>
    </div>
</asp:Content>
