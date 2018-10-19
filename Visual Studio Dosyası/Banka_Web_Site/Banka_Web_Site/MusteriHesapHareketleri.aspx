<%@ Page Title="HESAP HAREKETLERİM" Language="C#" MasterPageFile="~/MusteriMenusu.Master" AutoEventWireup="true" CodeBehind="MusteriHesapHareketleri.aspx.cs" Inherits="Banka_Web_Site.MusteriHesapHareketleri" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
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
            width:625px;
            height:454px;
            background-color:white;
            border-bottom:1px solid indianred;
        }
        .hesap .alt .label{
            float:left;
            color:indianred;
            margin-left:2px;
        }
        .hesap .alt .ddl{
            float:right;
            margin-top:2px;
            text-align:center;
            color:indianred;
            background-color:lightgray;
            margin-right:5px;
        }
        .hesap .alt .lblhesapno{
            float:right;
            color:indianred;
            margin-right:5px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="hesap">
        <div class="üst">
            <b>HESAP HAREKETLERİM</b>
        </div>
        <div class="alt">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:Label ID="lblMusteri" runat="server" Text="Müşteri Numaranız: " CssClass="label"></asp:Label>
            <asp:Label ID="lblMusteriNo" runat="server" Text="" CssClass="label"></asp:Label>
            <asp:DropDownList ID="ddlHesapNo" runat="server" CssClass="ddl" AutoPostBack="True" OnSelectedIndexChanged="ddlHesapNo_SelectedIndexChanged"></asp:DropDownList>
            <asp:Label ID="lblhesapno" runat="server" Text="Hesap Numaranız: " CssClass="lblhesapno"></asp:Label>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%"></rsweb:ReportViewer>
        </div>
    </div>
</asp:Content>
