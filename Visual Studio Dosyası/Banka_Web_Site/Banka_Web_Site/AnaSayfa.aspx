<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnaSayfa.aspx.cs" Inherits="Banka_Web_Site.AnaSayfa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ANA SAYFA</title>
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
            width:608px;
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
        header .slogan{
            float:right;
            width:258px;
            height:58px;
            border:1px solid indianred;
            line-height:58px;
        }
        #lblSlogan{
            float:right;
            color:indianred;
            margin-right:20px;
        }
        #lblSlogan:hover{
            color:red;
        }
        .banner{
            float:left;
            margin-top:45px;
            width:960px;
            height:360px;
            background-image:url("images/Banner.png");
        }
        .soltaraf{
            float:left;
            width:285px;
            height:500px;
            margin-top:45px;
        }
        .soltaraf .giris{
            float:left;
            width:285px;
            height:auto;
        }
        .soltaraf .giris .üst{
            float:left;
            width:270px;
            height:44px;
            background-color:white;
            border-bottom:1px solid indianred;
            line-height:44px;
            padding-left:15px;
            color:indianred;
        }
        .soltaraf .giris .alt{
            float:left;
            width:250px;
            padding:17.5px;
            height:225px;
            background-color:white;
            border-bottom:1px solid indianred;
        }
        .soltaraf .giris .alt .label{
            text-align:center;
            color:indianred;
            margin-top:7.5px;
        }
        .soltaraf .giris .alt .textbox{
            float:left;
            width:228px;
            padding:10px;
            height:18px;
            line-height:38px;
            text-align:center;
            border:1px solid indianred;
            color:indianred;
        }
        .soltaraf .giris .alt .cboxBeniHatırla{
            float:left;
            text-align:center;
            color:indianred;
            margin-top:7.5px;
        }
        .soltaraf .giris .alt .cboxBeniHatırla:hover
        {
            text-decoration:none;
            color:red;
        } 
        .soltaraf .giris .alt .linkbtnSifre{
            float:right;
            text-align:center;
            color:indianred;
            margin-top:7.5px;
        }
        .soltaraf .giris .alt .linkbtnSifre:hover
        {
            text-decoration:none;
            color:red;
        } 
        .soltaraf .giris .alt .btnGiris{
            float:right;
            width:100px;
            height:40px;
            line-height:40px;
            text-align:center;
            color:white;
            background-color:indianred;
            margin-top:7.5px;
        }
        .soltaraf .giris .alt .btnGiris:hover
        {
            text-decoration:none;
            color:lightgray;
        } 
        .soltaraf .giris .alt .btnTemizle{
            float:left;
            width:100px;
            height:40px;
            line-height:40px;
            text-align:center;
            color:white;
            background-color:indianred;
            margin-top:7.5px;
        }
        .soltaraf .giris .alt .btnTemizle:hover
        {
            text-decoration:none;
            color:lightgray;
        } 
        .soltaraf .giris .alt .lblYetki{
            float:left;
            text-align:center;
            color:indianred;
            margin-top:7.5px;
            margin-left:55px;
        }
        .soltaraf .giris .alt .ddlYetki{
            float:left;
            text-align:center;
            color:indianred;
            background-color:lightgray;
            margin-top:7.5px;
        }
        .soltaraf .duyurular{
            float:left;
            width:285px;
            height:189px;
            margin-top:5px;
            background-color:white;
        }
        .soltaraf .duyurular .üst{
            float:left;
            width:270px;
            height:44px;
            background-color:white;
            border-bottom:1px solid indianred;
            line-height:44px;
            padding-left:15px;
            color:indianred;
        }
        .soltaraf .duyurular .alt{
            float:left;
            width:250px;
            padding:17.5px;
            height:108px;
            background-color:white;
            border-bottom:1px solid indianred;
        }
        .soltaraf .duyurular .alt .duyuru-kismi{
            float:left;
            width:250px;
            height:100px;
            color:indianred;
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
        .sagtaraf .lblUyari{
            width:625px;
            color:indianred;
            height:30px;
            font-size:90%;
        }
        .sagtaraf .icerik{
            width:625px;
            height:465px;
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
            margin-top:20px;
            float:left;
            width:590px;
            padding-left:17.5px;
            padding-right:17.5px;
            height:404px;
            background-color:white;
            border-bottom:1px solid indianred;
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
</head>
<body>
    <form id="form1" runat="server">
        <div id="ickisim">
            <header>
                <div class="logo"></div>
                <nav>
                    <ul>
                        <li>
                            <a href="/">Ana Sayfa</a>
                        </li>
                        <li>
                            <a href="YoneticiKaydiOlustur.aspx">Yönetici Kaydı Oluştur</a>
                        </li>
                        <li>
                            <a href="Hakkimizda.aspx">Hakkımızda</a>
                        </li>
                    </ul>
                </nav>
                <div class="slogan">
                    <asp:Label ID="lblSlogan" runat="server" Text="KARBANK - Geleceğin Bankası" Font-Bold="true"></asp:Label>
                </div>
            </header>
            <div class="banner"></div>
            <div class="soltaraf">
                <div class="giris">
                    <div class="üst"><b>Oturum Aç</b></div>
                    <div class="alt">
                        <div>
                            <asp:Label ID="lblKulAdı" runat="server" Text="Kullanıcı Adı:" CssClass="label"></asp:Label>
                            <asp:TextBox ID="txtKulAdı" CssClass="textbox" runat="server"/>
                        </div>
                        <div>
                            <asp:Label ID="lblSifre" runat="server" Text="Şifre:" CssClass="label"></asp:Label>
                            <asp:TextBox ID="txtSifre" CssClass="textbox" runat="server" TextMode="Password"/>
                        </div>
                        <div>
                            <asp:CheckBox ID="cboxBeniHatırla" runat="server" Text="Beni Hatırla" CssClass="cboxBeniHatırla"/>
                            <asp:LinkButton ID="linkbtnSifre" runat="server" CssClass="linkbtnSifre" OnClick="linkbtnSifre_Click">Şifremi Unuttum</asp:LinkButton>
                        </div>
                        <div>
                           <asp:Button ID="btnGiris" CssClass="btnGiris" runat="server" Text="OTURUM AÇ" OnClick="btnGiris_Click"/>
                           <asp:Button ID="btnTemizle" CssClass="btnTemizle" runat="server" Text="TEMİZLE" OnClick="btnTemizle_Click"/>  
                        </div>
                        <div>
                            <asp:Label ID="lblYetki" runat="server" Text="Yetkiniz:" CssClass="lblYetki"></asp:Label>
                            <asp:DropDownList ID="ddlYetki" CssClass="ddlYetki" runat="server">
                                <asp:ListItem>Müşteri</asp:ListItem>
                                <asp:ListItem>Yönetici</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="duyurular">
                    <div class="üst">
                       <b>Duyurular</b>
                    </div>
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
                  <div class="lblUyari">
                      <asp:Label ID="lblUyari" runat="server" Text=""></asp:Label>
                  </div>
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
