<%@ Page Title="ŞİFREMİ UNUTTUM" Language="C#" MasterPageFile="~/AnaSayfa.Master" AutoEventWireup="true" CodeBehind="SifremiUnuttum.aspx.cs" Inherits="Banka_Web_Site.SifremiUnuttum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        *{
            margin:0;
            padding:0;
            border:0;
        }
        .sifre{
            float:left;
            width:625px;
            height:auto;
        }
        .sifre .üst{
            width:625px;
            height:43px;
            background-color:white;
            border-bottom:1px solid indianred;
            border-top:1px solid indianred;
            line-height:44px;
            text-align:center;
            color:indianred;
        }
        .sifre .alt{
            float:left;
            width:590px;
            padding-left:17.5px;
            padding-right:17.5px;
            height:424px;
            background-color:white;
            border-bottom:1px solid indianred;
        }
        .sifre .alt .doldurulacak-alan{
            margin-top:25px;
            text-align:center;
            line-height:100px;
            height:100px;
        }
        .sifre .alt .doldurulacak-alan .label{
            color:indianred;
            margin-top:12px;
        }
        .sifre .alt .doldurulacak-alan .textbox{
            color:indianred;
            margin-top:12px;
            border:1px solid indianred;
            margin-left:3px;
        }
        .sifre .alt .doldurulacak-alan .btnYeniSifre{
            width:150px;
            height:40px;
            line-height:40px;
            text-align:center;
            margin-top:20px;
            background-color:indianred;
            color:white;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="sifre">
        <div class="üst">
            <b>ŞİFREMİ UNUTTUM</b>
        </div>
        <div class="alt">
            <div class="doldurulacak-alan">
                <asp:Label ID="lblMail" runat="server" Text="E-Mail Adresiniz:" CssClass="label"></asp:Label> 
                <asp:TextBox ID="txtMail" CssClass="textbox" runat="server" AutoCompleteType="Email" TextMode="Email"/> <br />
                <asp:Button ID="btnYeniSifre" CssClass="btnYeniSifre" runat="server" Text="YENİ ŞİFRE GÖNDER" OnClick="btnYeniSifre_Click"/> <br />
                <asp:Label ID="lblUyariMesaji" runat="server" Text="" CssClass="label"></asp:Label>
            </div>
       </div>
    </div>
</asp:Content>
