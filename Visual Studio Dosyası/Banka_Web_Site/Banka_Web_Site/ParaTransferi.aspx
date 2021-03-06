﻿<%@ Page Title="PARA TRANSFERİ" Language="C#" MasterPageFile="~/MusteriMenusu.Master" AutoEventWireup="true" CodeBehind="ParaTransferi.aspx.cs" Inherits="Banka_Web_Site.ParaTransferi" %>
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
            margin:125px;
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
        .hesap .alt .doldurulacak-alan .textbox{
            margin-top:15px;
            text-align:center;
            color:indianred;
            border:1px solid indianred;
        }
        .hesap .alt .doldurulacak-alan .btnTransferEt{
            width:120px;
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
            <b>PARA TRANSFERİ</b>
        </div>
        <div class="alt">
            <div class="doldurulacak-alan">
                <asp:Label ID="lblMusteri" Text="Müşteri Numarası: " runat="server" CssClass="label"> </asp:Label> &nbsp
                <asp:Label ID="lblMusteriNo" Text="" runat="server" CssClass="label"> </asp:Label> 
                <br /><br />
                <asp:Label ID="lblHesap" Text="Hesap Numarası: " runat="server" CssClass="label"> </asp:Label> &nbsp
                <asp:DropDownList ID="ddlHesapNo" runat="server" AutoPostBack="true" CssClass="ddl" OnSelectedIndexChanged="ddlHesapNo_SelectedIndexChanged"></asp:DropDownList>
                <br /><br />
                <asp:Label ID="lblHesap2" Text="Hesap Numarası 2: " runat="server" CssClass="label"> </asp:Label> &nbsp
                <asp:DropDownList ID="ddlHesapNo2" runat="server" AutoPostBack="true" CssClass="ddl" OnSelectedIndexChanged="ddlHesapNo2_SelectedIndexChanged" ></asp:DropDownList>
                <br /><br />
                <asp:Label ID="lblTutar" Text="Transfer Edilecek Tutar: " runat="server" CssClass="label"> </asp:Label> &nbsp
                <asp:TextBox ID="txtTutar" runat="server" CssClass="textbox" TextMode="Number"></asp:TextBox>
                <br />
                <asp:Button ID="btnTransferEt" runat="server" Text="TRANSFER ET" CssClass="btnTransferEt" OnClick="btnTransferEt_Click"/>
                <br /><br />
                <asp:Label ID="lblMesaj" runat="server" Text="" CssClass="label"></asp:Label> 
            </div>
       </div>
    </div>
</asp:Content>
