﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MusteriMenusu.aspx.cs" Inherits="Banka_Web_Site.MusteriMenusu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MÜŞTERİ MENÜSÜ</title>
    <script src="http://code.jquery.com/jquery-2.0.3.min.js"></script>
    <script type="text/javascript">
        $("document").ready(function () {
            $("header nav ul li.islem-kismi").mouseover(function () {
                $("header nav ul li.islem-kismi .islemler").css("display", "block")
            })
            $("header nav ul li.islem-kismi").mouseleave(function () {
                $("header nav ul li.islem-kismi .islemler").css("display", "none")
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
            margin-left:15px;
            color:indianred;
        }
        header nav ul li.islem-kismi{
            position:relative;
        }
        header nav ul li.islem-kismi .islemler{
            display:none;
            margin-top:1px;
            position:absolute;
            width:200px;
            height:auto;
            background-color:white;
        }
        header nav ul li.islem-kismi .islemler ul li{
            float:left;
            text-align:center;
        }
        #lblMusteriKulAdi{
            float:right;
            color:indianred;
            margin-right:5px;
        }
        #lblMusteriKulAdi:hover{
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
            background-image:url("images/MusteriBanner.png");
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
            margin:15px;
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
        .sagtaraf .icerik{
            width:625px;
            height:495px;
        }
        .sagtaraf .icerik .üst{
            width:625px;
            height:43px;
            background-color:white;
            border-bottom:1px solid indianred;
            border-top:1px solid indianred;
            line-height:44px;
            text-align:center;
            color:indianred;
        }
        .sagtaraf .icerik .alt{
            margin-top:40px;
            float:left;
            width:590px;
            padding-left:17.5px;
            padding-right:17.5px;
            height:404px;
            background-color:white;
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
                            <a href="MusteriMenusu.aspx">Müşteri Ana Sayfası</a>
                        </li>
                        <li>
                            <a href="MusteriProfilim.aspx">Profilim</a>
                        </li>
                        <li>
                            <a href="MusteriHesaplarim.aspx">Hesaplarım</a>
                        </li>
                        <li class="islem-kismi">
                            <a href="#">İşlemler</a>
                            <div class="islemler">
                                <ul>
                                    <li><a href="ParaCekme.aspx">Para Çekme</a></li>
                                    <br />
                                    <li><a href="ParaYatirma.aspx">Para Yatırma</a></li>
                                    <br />
                                    <li><a href="ParaTransferi.aspx">Para Transferi</a></li>
                                    <br />
                                    <li><a href="MusteriHesapHareketleri.aspx">Hesap Hareketlerim</a></li>
                                    <br />
                                    <li><a href="BakiyeSorgula.aspx">Bakiye Sorgula</a></li>
                                </ul>
                            </div>
                        </li>
                            <asp:Label ID="lblMusteriKulAdi" runat="server" Text="Kullanıcı Adı"></asp:Label>
                    </ul>
                </nav>
                <div class="oturumKapat">
                    <asp:Button ID="btnOturumKapat" CssClass="btnOturumKapat" runat="server" Text="Oturum Kapat" OnClick="btnOturumKapat_Click" />
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
                <div class="icerik">
                    <div class="üst">
                       <b>TAKVİM</b>
                    </div>
                    <div class="alt">
                        <asp:Calendar ID="Calendar1" runat="server"   Font-Names="Verdana" 
                        BackColor="White"   BorderColor="Black"   BorderStyle="Solid"   CellSpacing="1"   Font-Size="9pt"  
                        ForeColor="Black"   Height="250px"   NextPrevFormat="ShortMonth" OnDayRender="Calendar1_DayRender">  
                            <SelectedDayStyle BackColor="#333399" ForeColor="White" />  
                            <TodayDayStyle BackColor="#999999" ForeColor="White" />  
                            <OtherMonthDayStyle ForeColor="#999999" />  
                            <DayStyle BackColor="#CCCCCC" Height="50px" Width="100px" />  
                            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />  
                            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />  
                            <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" Font-Size="12pt" ForeColor="White" Height="12pt" />  
                        </asp:Calendar> 
                    </div>
                </div>
            </div>
            <footer><b>KARDEMİR A.Ş. Staj Projesi</b></footer>
        </div>
    </form>
</body>
</html>
