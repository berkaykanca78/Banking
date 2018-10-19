<%@ Page Title="HESAPLARIM" Language="C#" MasterPageFile="~/MusteriMenusu.Master" AutoEventWireup="true" CodeBehind="MusteriHesaplarim.aspx.cs" Inherits="Banka_Web_Site.MusteriHesaplarim" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style>
        *{
            margin:0;
            padding:0;
            border:0;
        }
        .hesap{
            float:left;
            width:625px;
            height:auto;
        }
        .hesap .üst{
            width:625px;
            height:44px;
            background-color:white;
            border-bottom:1px solid indianred;
            line-height:44px;
            text-align:center;
            color:indianred;
        }
        .hesap .alt{
            float:left;
            width:590px;
            padding-left:17.5px;
            padding-right:17.5px;
            height:454px;
            background-color:white;
            border-bottom:1px solid indianred;
        }
        .hesap .alt .doldurulacak-alan{
            margin:100px;
            text-align:center;
        }
        .hesap .alt .doldurulacak-alan .label{
            margin-top:15px;
            color:indianred;
        }
        .hesap .alt .doldurulacak-alan .ddl{
            margin-top:15px;
            text-align:center;
            color:indianred;
            background-color:lightgray;
        }
        .hesap .alt .doldurulacak-alan .button:hover{
            color:lightgray;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="hesap">
        <div class="üst">
            <b>HESAPLARIM</b>
        </div>
        <div class="alt">
            <div class="doldurulacak-alan">
                <asp:Label ID="lblHesapNo" Text="Hesap Numarası:" runat="server" CssClass="label"> </asp:Label> &nbsp
                <asp:DropDownList ID="ddlHesapNo" runat="server" CssClass="ddl" AutoPostBack="True" OnSelectedIndexChanged="ddlHesapNo_SelectedIndexChanged" style="height: 16px"></asp:DropDownList>
                <br />
                <asp:Label ID="lblYon" Text="Yönetici Kullanıcı Adı:" runat="server" CssClass="label"> </asp:Label> &nbsp
                <asp:Label ID="lblYonKulAdi" Text="" runat="server" CssClass="label"> </asp:Label>
                <br />
                <asp:Label ID="lblMus" Text="Müşteri Kullanıcı Adı:" runat="server" CssClass="label"> </asp:Label> &nbsp
                <asp:Label ID="lblMusKulAdi" Text="" runat="server" CssClass="label"> </asp:Label> 
                <br />
                <asp:Label ID="lblBakiye" Text="Bakiye:" runat="server" CssClass="label"> </asp:Label> &nbsp
                <asp:Label ID="lblBakiyeBilgisi" Text="" runat="server" CssClass="label"> </asp:Label> 
                <br />
                <asp:Label ID="lblHesapTuru" Text="Hesap Türü:" runat="server" CssClass="label"> </asp:Label> &nbsp
                <asp:Label ID="lblHesapTuruBilgisi" Text="" runat="server" CssClass="label"> </asp:Label>
            </div>
            </div>
       </div>
</asp:Content>
