<%@ Page Title="HESAP KAYDI" Language="C#" MasterPageFile="~/YoneticiMenusu.Master" AutoEventWireup="true" CodeBehind="HesapKaydi.aspx.cs" Inherits="Banka_Web_Site.HesapKaydi" %>
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
        .hesap .alt .doldurulacak-alan .textbox{
            margin-top:15px;
            text-align:center;
            color:indianred;
            border:1px solid indianred;
        }
        .hesap .alt .doldurulacak-alan .btnTemizle{
            float:left;
            width:120px;
            height:40px;
            line-height:40px;
            text-align:center;
            margin-top:20px;
            background-color:indianred;
            color:white;
        }
        .hesap .alt .doldurulacak-alan .btnKayit{
            float:right;
            width:120px;
            height:40px;
            line-height:40px;
            text-align:center;
            margin-top:20px;
            background-color:indianred;
            color:white;
        }
        .hesap .alt .doldurulacak-alan .button:hover{
            color:lightgray;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="hesap">
        <div class="üst">
            <b>HESAP KAYDI</b>
        </div>
        <div class="alt">
            <div class="doldurulacak-alan">
                <asp:Label ID="lblYon" Text="Yönetici Kullanıcı Adı:" runat="server" CssClass="label"> </asp:Label> &nbsp
                <asp:Label ID="lblYonKulAdi" Text="" runat="server" CssClass="label"> </asp:Label>
                <br />
                <asp:Label ID="lblMus" Text="Müşteri Kullanıcı Adı:" runat="server" CssClass="label"> </asp:Label> &nbsp
                <asp:DropDownList ID="ddlMusteri" runat="server" AutoPostBack="true" CssClass="ddl"></asp:DropDownList>
                <br />
                <asp:Label ID="lblBakiye" Text="Bakiye:" runat="server" CssClass="label"> </asp:Label> &nbsp
                <asp:TextBox ID="txtBakiye" runat="server" CssClass="textbox"></asp:TextBox> 
                <br />
                <asp:Label ID="lblHesapTuru" Text="Hesap Türü:" runat="server" CssClass="label"> </asp:Label> &nbsp
                <asp:DropDownList ID="ddlHesapTuru" runat="server" AutoPostBack="true" CssClass="ddl">
                    <asp:ListItem Text="Vadeli"></asp:ListItem>
                    <asp:ListItem Text="Vadesiz"></asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:Button ID="btnTemizle" runat="server" Text="TEMİZLE" CssClass="btnTemizle" OnClick="btnTemizle_Click"/>
                <asp:Button ID="btnKayit" runat="server" Text="HESAP OLUŞTUR" CssClass="btnKayit" OnClick="btnKayit_Click"/>
                <br />
                <asp:Label ID="lblMesaj" runat="server" Text="" CssClass="label"></asp:Label>
            </div>
       </div>
    </div>
</asp:Content>
