<%@ Page Title="MÜŞTERİ PROFİLİ" Language="C#" MasterPageFile="~/YoneticiMenusu.Master" AutoEventWireup="true" CodeBehind="MusteriProfil.aspx.cs" Inherits="Banka_Web_Site.MusteriProfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        *{
            margin:0;
            padding:0;
            border:0;
        }
        .musteri{
            float:left;
            width:625px;
            height:auto;
        }
        .musteri .üst{
            width:625px;
            height:44px;
            background-color:white;
            border-bottom:1px solid indianred;
            line-height:44px;
            text-align:center;
            color:indianred;
        }
        .musteri .alt{
            float:left;
            width:590px;
            padding-left:17.5px;
            padding-right:17.5px;
            height:454px;
            background-color:white;
            border-bottom:1px solid indianred;
        }
        .musteri .alt .doldurulacak-alan{
            text-align:center;
            margin-top:75px;
        }
        .musteri .alt .doldurulacak-alan .ddl{
            text-align:center;
            color:indianred;
            background-color:lightgray;
        }
        .musteri .alt .doldurulacak-alan .labelID{
            color:indianred;
        }
        .musteri .alt .doldurulacak-alan .label{
            color:indianred;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="musteri">
        <div class="üst">
            <b>MÜŞTERİ PROFİLİ</b>
        </div>
        <div class="alt">
            <div class="doldurulacak-alan">
                <asp:Label ID="lblMusterKulAdi" Text="Müşteri Kullanıcı Adı: " runat="server" CssClass="label"/> 
                <asp:DropDownList ID="ddlMusteri" runat="server" AutoPostBack="True" CssClass="ddl" OnSelectedIndexChanged="ddlMusteri_SelectedIndexChanged"> </asp:DropDownList> <br /><br />
                <asp:Label ID="lblMusteriNo" Text="Müşteri No: " runat="server" CssClass="labelID"/> 
                <asp:Label ID="lblID" Text="" runat="server" CssClass="labelID"/>
                <br />
                <asp:Label ID="lblKulAdi" runat="server" Text="Kullanıcı Adı: " CssClass="label"></asp:Label>
                <asp:Label ID="lblKulAdiBilgisi" runat="server" Text="" CssClass="label"></asp:Label>
                <br />
                <asp:Label ID="lblTC" runat="server" Text="T.C Kimlik Numarası: " CssClass="label"></asp:Label> 
                <asp:Label ID="lblTCBilgisi" runat="server" Text="" CssClass="label"></asp:Label> 
                <br />
                <asp:Label ID="lblAd" runat="server" Text="Ad: " CssClass="label"></asp:Label> 
                <asp:Label ID="lblAdBilgisi" runat="server" Text="" CssClass="label"></asp:Label>
                <br />
                <asp:Label ID="lblSoyad" runat="server" Text="Soyad: " CssClass="label"></asp:Label> 
                <asp:Label ID="lblSoyadBilgisi" runat="server" Text="" CssClass="label"></asp:Label> 
                <br />
                <asp:Label ID="lblAdres" runat="server" Text="Adres: " CssClass="label"></asp:Label> 
                <asp:Label ID="lblAdresBilgisi" runat="server" Text="" CssClass="label"></asp:Label> 
                <br />
                <asp:Label ID="lblMail" runat="server" Text="E-Mail: " CssClass="label"></asp:Label> 
                <asp:Label ID="lblMailBilgisi" runat="server" Text="" CssClass="label"></asp:Label>
                <br />
                <asp:Label ID="lblTelefon" runat="server" Text="Telefon:(+90): " CssClass="label"></asp:Label> 
                <asp:Label ID="lblTelefonBilgisi" runat="server" Text="" CssClass="label"></asp:Label> 
                <br />
                <asp:Label ID="lblDogum" runat="server" Text="Doğum Tarihi: " CssClass="label"></asp:Label> 
                <asp:Label ID="lblDogumBilgisi" runat="server" Text="" CssClass="label"></asp:Label> 
            </div>
       </div>
    </div>
</asp:Content>
