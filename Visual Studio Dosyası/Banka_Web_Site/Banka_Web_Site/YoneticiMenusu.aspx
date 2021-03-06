﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YoneticiMenusu.aspx.cs" Inherits="Banka_Web_Site.YoneticiMenusu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>YÖNETİCİ MENÜSÜ</title>
    <script src="http://code.jquery.com/jquery-2.0.3.min.js"></script>
    <script type="text/javascript">
        $("document").ready(function () {
            $("header nav ul li.profil-kismi").mouseover(function () {
                $("header nav ul li.profil-kismi .profiller").css("display","block")
            })
            $("header nav ul li.profil-kismi").mouseleave(function () {
                $("header nav ul li.profil-kismi .profiller").css("display", "none")
            })
            $("header nav ul li.kayit-kismi").mouseover(function () {
                $("header nav ul li.kayit-kismi .kayitlar").css("display", "block")
            })
            $("header nav ul li.kayit-kismi").mouseleave(function () {
                $("header nav ul li.kayit-kismi .kayitlar").css("display", "none")
            })
        })
    </script>
    <script type="text/javascript">
        var delayb4scroll = 2000
        var marqueespeed = 2
        var pauseit = 1
        var copyspeed = marqueespeed
        var pausespeed = (pauseit == 0) ? copyspeed : 0
        var actualheight = ''
        function scrollmarquee() {
            if (parseInt(cross_marquee.style.top) > (actualheight * (-1) + 8))
                cross_marquee.style.top = parseInt(cross_marquee.style.top) - copyspeed + "px"
            else
                cross_marquee.style.top = parseInt(marqueeheight) + 8 + "px"
        }
        function initializemarquee() {
            cross_marquee = document.getElementById("vmarquee")
            cross_marquee.style.top = 0
            marqueeheight = document.getElementById("marqueecontainer").offsetHeight
            actualheight = cross_marquee.offsetHeight
            if (window.opera || navigator.userAgent.indexOf("Netscape/7") != -1) {
                cross_marquee.style.height = marqueeheight + "px"
                cross_marquee.style.overflow = "scroll"
                return
            }
            setTimeout('lefttime=setInterval("scrollmarquee()",30)', delayb4scroll)
        }
        if (window.addEventListener)
            window.addEventListener("load", initializemarquee, false)
        else if (window.attachEvent)
            window.attachEvent("onload", initializemarquee)
        else if (document.getElementById)
            window.onload = initializemarquee
    </script>
    <style type="text/css"> 
body{
            background-color:lightgray;
            font-family:'Trebuchet MS',Arial,'Comic Sans MS','Caneletter Script Personal Use';
        }
        *{
            margin:0;
            padding:0;
            border:0;
        }
        a{
            text-decoration:none;
            color:indianred;
        }
        a:hover{
            text-decoration:none;
            color:red;
        }
        #ickisim{
            width:960px;
            height:auto;
            margin:0 auto;
        }
        header{
            float:left;
            width:100%;
            height:60px;
            background-color:white;
        }
        header .logo
        {
            float:left;
            width:88px;
            height:58px;
            border:1px solid indianred;
            text-align:center;
            line-height:58px;
            color:white;
            background-image:url("images/Logo.png");
        }
        header nav{
            float:left;
            width:778px;
            height:58px;
            border:1px solid indianred;
            line-height:58px;
        }
        header nav ul{
            list-style:none;
        }
        header nav ul li{
            float:left;
            margin:0 10px;
            color:indianred;
        }
        header nav ul li.profil-kismi{
            position:relative;
        }
        header nav ul li.profil-kismi .profiller{
            display:none;
            margin-top:1px;
            position:absolute;
            width:200px;
            height:auto;
            background-color:white;
        }
        header nav ul li.profil-kismi .profiller ul li{
            float:left;
            text-align:center;
        }
        header nav ul li.kayit-kismi{
            position:relative;
        }
        header nav ul li.kayit-kismi .kayitlar{
            display:none;
            margin-top:1px;
            position:absolute;
            width:200px;
            height:auto;
            background-color:white;
        }
        header nav ul li.kayit-kismi .kayitlar ul li{
            float:left;
            text-align:center;
        }
        #lblYoneticiKulAdi{
            float:right;
            color:indianred;
            margin-right:5px;
        }
        #lblYoneticiKulAdi:hover{
            color:red;
        }
        header .oturumKapat{
            float:right;
            width:90px;
            height:60px;
        }
        header .oturumKapat .btnOturumKapat{
           float:right;
           width:90px;
           height:60px;
           background-color:indianred;
           color:white;
           border:1px solid indianred;
        }
        header .oturumKapat .btnOturumKapat:hover{
           color:lightgray;
        }
        .banner{
            float:left;
            margin-top:45px;
            width:960px;
            height:360px;
            background-image:url("images/YoneticiBanner.png");
        }
        .soltaraf{
            float:left;
            width:285px;
            height:499px;
            margin-top:45px;
            background-color:white;
            border-bottom:1px solid indianred;
        }        
        .soltaraf .duyuru{
            float:left;
            width:285px;
            height:auto;
        }
        .soltaraf .duyuru .üst{
            float:left;
            width:270px;
            height:44px;
            background-color:white;
            border-bottom:1px solid indianred;
            line-height:44px;
            padding-left:15px;
            color:indianred;
        }
        .soltaraf .duyuru .alt{
            float:left;
            width:285px;
            height:450px;
            background-color:white;
        }
        .soltaraf .duyuru .alt .duyuru-kismi{
            float:left;
            width:250px;
            height:100px;
            color:indianred;
            margin-left:10px;
        }
        #marqueecontainer{
            position: relative;
            overflow: hidden;
        }
        .sagtaraf{
            float:right;
            width:625px;
            height:499px;
            margin-top:45px;
            background-color:white;
            border-bottom:1px solid indianred;
        }
        .sagtaraf .üst{
            width:625px;
            height:44px;
            background-color:white;
            border-bottom:1px solid indianred;
            line-height:44px;
            text-align:center;
            color:indianred;
        }
        .sagtaraf .alt{
            float:left;
            width:590px;
            padding-left:17.5px;
            padding-right:17.5px;
            height:454px;
            background-color:white;
            border-bottom:1px solid indianred;
        }
        .sagtaraf .alt .doldurulacak-alan{
            text-align:center;
            line-height:50px;
            height:50px;
        }
        .sagtaraf .alt .doldurulacak-alan .ddl{
            margin-top:15px;
            text-align:center;
            color:indianred;
            background-color:lightgray;
        }
        .sagtaraf .alt .doldurulacak-alan .label{
            color:indianred;
        }
        .sagtaraf .alt .doldurulacak-alan .textbox{
            color:indianred;
            border:1px solid indianred;
        }
        .sagtaraf .alt .doldurulacak-alan .button{
            width:100px;
            height:40px;
            line-height:40px;
            text-align:center;
            background-color:indianred;
            color:white;
            margin:5px;
        }
        .sagtaraf .alt .doldurulacak-alan .labelMesaj{
            color:indianred;
        }
        .sagtaraf .alt .doldurulacak-alan .button:hover{
            color:lightgray;
        }
        footer{
            float:left;
            width:100%;
            height:60px;
            margin-top:45px;
            background-color:white;
            line-height:60px;
            text-align:center;
            color:indianred;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="ickisim">
            <header> 
                <div class="logo"></div>
                <nav>
                    <ul>
                        <li>
                            <a href="YoneticiMenusu.aspx">Yönetici Ana Sayfası</a>
                        </li>
                        <li class="profil-kismi">
                            <a href="#">Profil</a>
                            <div class="profiller">
                                <ul>
                                    <li><a href="YoneticiProfil.aspx">Profilim</a></li>
                                    <br />
                                    <li><a href="MusteriProfil.aspx">Müşteri Profili</a></li>
                                </ul>
                            </div>
                        </li>
                        <li class="kayit-kismi">
                            <a href="#">Kayıt Oluştur</a>
                            <div class="kayitlar">
                                <ul>
                                    <li><a href="MusteriKaydi.aspx">Müşteri Kaydı</a></li>
                                    <br />
                                    <li><a href="HesapKaydi.aspx">Hesap Kaydı</a></li>
                                </ul>
                            </div>
                        </li>
                        <li>
                            <a href="HesapHareketleri.aspx">Hesap Hareketleri</a>
                        </li>
                        <asp:Label ID="lblYoneticiKulAdi" runat="server" Text="Kullanıcı Adı"></asp:Label>
                    </ul>
                </nav>
                <div class="oturumKapat">
                    <asp:Button ID="btnOturumKapat" CssClass="btnOturumKapat" runat="server" Text="Oturum Kapat" OnClick="btnOturumKapat_Click"/>
                </div>
            </header>
            <div class="banner"></div>
            <div class="soltaraf">
                <div class="duyuru">
                    <div class="üst"><b>Duyurular</b></div>
                    <div id="marqueecontainer" onMouseover="copyspeed=pausespeed" onMouseout="copyspeed=marqueespeed" class="alt">
                        <div id="vmarquee" style="position: absolute; width: 98%;">
                            <asp:ListView ID="listDuyuru" runat="server">
                                <ItemTemplate> 
                                        <div class="duyuru-kismi">
                                            <asp:Label runat="server" Text='<%#Eval("Baslik")%>'></asp:Label><br />
                                            <asp:Label runat="server" Text='<%#Eval("Duyuru")%>'></asp:Label><br />
                                            <asp:Label runat="server" Text='<%#Eval("Tarih")%>'></asp:Label>
                                        </div>
                                </ItemTemplate>
                            </asp:ListView>
                        </div> 
                    </div>
                 </div>
            </div>
            <div class="sagtaraf">
                <div class="üst">
                    <b>DUYURU DÜZENLEME</b>
                </div>
                <div class="alt">
                    <div class="doldurulacak-alan">
                        <asp:Label ID="lblDuyuruNo" runat="server" Text="Duyuru Numarası: " CssClass="label"></asp:Label>
                        <asp:DropDownList ID="ddlDuyuru" runat="server" CssClass="ddl" AutoPostBack="True" OnSelectedIndexChanged="ddlDuyuru_SelectedIndexChanged"></asp:DropDownList>
                        <br />
                        <asp:Label ID="lblYonetici" runat="server" Text="Yönetici Kullanıcı Adı: " CssClass="label"></asp:Label>
                        <asp:Label ID="lblYonKulAdi" runat="server" Text="" CssClass="label"></asp:Label>
                        <br />
                        <asp:Label ID="lblYoneticiNo" runat="server" Text="Yönetici Numarası: " CssClass="label"></asp:Label>
                        <asp:Label ID="lblYonNo" runat="server" Text="" CssClass="label"></asp:Label>
                        <br />
                        <asp:Label ID="lblBaslik" runat="server" Text="Başlık: " CssClass="label"></asp:Label>
                        <asp:TextBox ID="txtBaslik" runat="server" CssClass="textbox"></asp:TextBox>
                        <br />
                        <asp:Label ID="lblDuyuru" runat="server" Text="Duyuru: " CssClass="label"></asp:Label>
                        <asp:TextBox ID="txtDuyuru" runat="server" CssClass="textbox"></asp:TextBox>
                        <br />
                        <asp:Label ID="lblTarih" runat="server" Text="Tarih: " CssClass="label"></asp:Label>
                        <asp:Label ID="lblTarihGoster" runat="server" Text="" CssClass="label"></asp:Label>
                        <br />
                        <asp:Button ID="btnGuncelle" runat="server" Text="GÜNCELLE" CssClass="button" OnClick="btnGuncelle_Click" /> 
                        <asp:Button ID="btnSilme" runat="server" Text="SİL" CssClass="button" OnClick="btnSilme_Click" />                    
                        <asp:Button ID="btnEkle" runat="server" Text="EKLE" CssClass="button" OnClick="btnEkle_Click" /><br />
                        <asp:Label ID="lblMesaj" runat="server" Text="" CssClass="label"></asp:Label>
                    </div>
                </div>
            </div>
            <footer><b>KARDEMİR A.Ş. Staj Projesi</b></footer>
        </div>
    </form>
</body>
</html>
