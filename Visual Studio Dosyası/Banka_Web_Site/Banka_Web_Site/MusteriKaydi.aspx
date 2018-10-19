<%@ Page Title="MÜŞTERİ KAYDI" Language="C#" MasterPageFile="~/YoneticiMenusu.Master" AutoEventWireup="true" CodeBehind="MusteriKaydi.aspx.cs" Inherits="Banka_Web_Site.MusteriKaydi" %>
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
            margin-top:25px;
            text-align:center;
            line-height:15px;
            height:15px;
        }
        .musteri .alt .doldurulacak-alan .label{
            color:indianred;
            margin-top:11px;
        }
        .musteri .alt .doldurulacak-alan .textbox{
            color:indianred;
            margin-top:11px;
            border:1px solid indianred;
        }
        .musteri .alt .doldurulacak-alan .btnTemizle{
            float:left;
            width:100px;
            height:40px;
            line-height:40px;
            text-align:center;
            margin-top:20px;
            background-color:indianred;
            color:white;
        }
        .musteri .alt .doldurulacak-alan .cvSifre2{
            line-height:60px;
            text-align:center;
            margin-top:20px;
            height:60px;
        }
        .musteri .alt .doldurulacak-alan .btnKaydet{
            float:right;
            width:100px;
            height:40px;
            line-height:40px;
            text-align:center;
            margin-top:20px;
            background-color:indianred;
            color:white;
        }
        .musteri .alt .doldurulacak-alan .button:hover{
            color:lightgray;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="musteri">
        <div class="üst">
            <b>MÜŞTERİ KAYDI</b>
        </div>
        <div class="alt">
            <div class="doldurulacak-alan">
                <asp:Label ID="lblKulAdı" runat="server" Text="Kullanıcı Adı:" CssClass="label"></asp:Label>
                <asp:TextBox ID="txtKulAdı" CssClass="textbox" runat="server" AutoCompleteType="DisplayName"/>
                <br />
                <asp:Label ID="lblSifre" runat="server" Text="Şifre:" CssClass="label"></asp:Label>
                <asp:TextBox ID="txtSifre" CssClass="textbox" runat="server"/>
                <br />
                <asp:Label ID="lblSifre2" runat="server" Text="Şifre Tekrarı:" CssClass="label"></asp:Label>
                <asp:TextBox ID="txtSifre2" CssClass="textbox" runat="server"/>
                <br />
                <asp:Label ID="lblTC" runat="server" Text="T.C Kimlik Numarası:" CssClass="label"></asp:Label> 
                <asp:TextBox ID="txtTC" CssClass="textbox" runat="server" TextMode="Number"/>
                <br />
                <asp:Label ID="lblAd" runat="server" Text="Ad:" CssClass="label"></asp:Label> 
                <asp:TextBox ID="txtAd" CssClass="textbox" runat="server" AutoCompleteType="FirstName"/>
                <br />
                <asp:Label ID="lblSoyad" runat="server" Text="Soyad:" CssClass="label"></asp:Label> 
                <asp:TextBox ID="txtSoyad" CssClass="textbox" runat="server" AutoCompleteType="LastName"/>
                <br />
                <asp:Label ID="lblAdres" runat="server" Text="Adres:" CssClass="label"></asp:Label> 
                <asp:TextBox ID="txtAdres" CssClass="textbox" runat="server" AutoCompleteType="BusinessStreetAddress" TextMode="MultiLine"/>
                <br />
                <asp:Label ID="lblMail" runat="server" Text="E-Mail:" CssClass="label"></asp:Label> 
                <asp:TextBox ID="txtMail" CssClass="textbox" runat="server" AutoCompleteType="Email" TextMode="Email"/>
                <br />
                <asp:Label ID="lblTelefon" runat="server" Text="Telefon:(+90)" CssClass="label"></asp:Label> 
                <asp:TextBox ID="txtTelefon" CssClass="textbox" runat="server" AutoCompleteType="BusinessPhone" TextMode="Phone" MaxLength="10"/>
                <br />
                <asp:Label ID="lblDogum" runat="server" Text="Doğum Tarihi:" CssClass="label"></asp:Label> 
                <asp:TextBox ID="txtDogum" CssClass="textbox" runat="server" TextMode="Date"/>
                <br />
                <asp:Button ID="btnTemizle" CssClass="btnTemizle" runat="server" Text="TEMİZLE" OnClick="btnTemizle_Click"/>
                <asp:Button ID="btnKaydet" CssClass="btnKaydet" runat="server" Text="KAYDET" OnClick="btnKaydet_Click"/>
                <asp:CompareValidator ID="cvSifre2" CssClass="cvSifre2" runat="server" ErrorMessage="Lütfen şifrenizi kontrol ediniz!" ControlToCompare="txtSifre" ControlToValidate="txtSifre2" Font-Bold="True" ForeColor="Indianred"></asp:CompareValidator>
                <br>
                <asp:Label ID="lblMesaj" runat="server" Text="" CssClass="label"></asp:Label> 
            </div>
       </div>
    </div>
</asp:Content>
