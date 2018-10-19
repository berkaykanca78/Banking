<%@ Page Title="BAKİYE SORGULA" Language="C#" MasterPageFile="~/MusteriMenusu.Master" AutoEventWireup="true" CodeBehind="BakiyeSorgula.aspx.cs" Inherits="Banka_Web_Site.BakiyeSorgula" %>
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
            color:indianred;
        }
        .hesap .alt .doldurulacak-alan .ddl{
            color:indianred;
            background-color:lightgray;
        }
        .hesap .alt .doldurulacak-alan .btnSorgula{
            width:100px;
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
    <div class="hesap">
        <div class="üst">
            <b>BAKİYE SORGULA</b>
        </div>
        <div class="alt">
            <div class="doldurulacak-alan">
                <asp:Label ID="lblMus" Text="Müşteri Kullanıcı Adı:" runat="server" CssClass="label"> </asp:Label> &nbsp
                <asp:Label ID="lblMusKulAdi" Text="" runat="server" CssClass="label"> </asp:Label>
                <br /><br />
                <asp:Label ID="lblMusHesapNo" Text="Müşteri Hesap Numarası:" runat="server" CssClass="label"> </asp:Label> &nbsp
                <asp:DropDownList ID="ddlHesapNo" runat="server" AutoPostBack="true" CssClass="ddl" OnSelectedIndexChanged="ddlHesapNo_SelectedIndexChanged" ></asp:DropDownList>
                <br /><br />
                <asp:Label ID="lblHesap" Text="Müşteri Hesap Türü:" runat="server" CssClass="label"> </asp:Label> &nbsp
                <asp:Label ID="lblHesapTuru" Text="" runat="server" CssClass="label"> </asp:Label> 
                <br /><br />
                <asp:Button ID="btnSorgula" runat="server" Text="SORGULA" CssClass="btnSorgula" OnClick="btnSorgula_Click"/>
                <br /><br /><br />
                <asp:Label ID="lblBakiye" Text="Bakiyeniz:" runat="server" CssClass="label"> </asp:Label> &nbsp
                <asp:Label ID="lblBakiyeTutari" Text="" runat="server" CssClass="label"> </asp:Label>              
            </div>
       </div>
    </div>
</asp:Content>
