<%@ Page Title="HESAP HAREKETLERİ" Language="C#" MasterPageFile="~/YoneticiMenusu.Master" AutoEventWireup="true" CodeBehind="HesapHareketleri.aspx.cs" Inherits="Banka_Web_Site.HesapHareketleri" %>

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
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="hesap">
        <div class="üst">
            <b>HESAP HAREKETLERİ</b>
        </div>
        <div class="alt">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%"></rsweb:ReportViewer>
       </div>
    </div>
</asp:Content>
