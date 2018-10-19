<%@ Page Title="HAKKIMIZDA" Language="C#" MasterPageFile="~/AnaSayfa.Master" AutoEventWireup="true" CodeBehind="Hakkimizda.aspx.cs" Inherits="Banka_Web_Site.Hakkimizda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        *{
            margin:0;
            padding:0;
            border:0;
        }
        .hakkimizda{
            float:left;
            width:625px;
            height:auto;
        }
        .hakkimizda .üst{
            width:625px;
            height:43px;
            background-color:white;
            border-bottom:1px solid indianred;
            border-top:1px solid indianred;
            line-height:44px;
            text-align:center;
            color:indianred;
        }
        .hakkimizda .alt{
            float:left;
            width:590px;
            padding:17.5px;
            height:389px;
            background-color:white;
            border-bottom:1px solid indianred;
        }
        .hakkimizda .alt .label{
            color:indianred;
            text-align:center;
            height:115px;
            line-height:115px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="hakkimizda">
        <div class="üst">
            <b>HAKKIMIZDA</b>
        </div>
        <div class="alt">
            <div class="label">
                <asp:Label CssClass="label" runat="server" text="Berkay KANCA-İstanbul Aydın Üniversitesi-Bilgisayar Mühendisliği"/> <br/>
                <asp:Label CssClass="label" runat="server" text="Cihan KARABACAK-Mersin Üniversitesi-Bilgisayar Teknolojisi ve Bilişim Sistemleri"/><br />
                <asp:Label CssClass="label" runat="server" text="Görkem GÜNLÜ-İstanbul Aydın Üniversitesi-Bilgisayar Mühendisliği"/> <br />
            </div>
       </div>
    </div>
</asp:Content>
