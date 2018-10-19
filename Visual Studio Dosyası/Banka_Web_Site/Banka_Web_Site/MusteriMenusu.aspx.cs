using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Banka_Web_Site
{
    public partial class MusteriMenusu : System.Web.UI.Page
    {
        //SQL İle Bağlantı Kurmamızı Sağlayan Komutlar Static Olup İhtiyaç Olduğunda Çağırılarak Kullanılır.
            static string baglantiString = "Data Source=BERKAY-TOSH\\SQLEXPRESS;Initial Catalog=BANKA;Integrated Security=True"; //Bağlantı Stringi
            static SqlConnection baglanti = null; //SQL Bağlantısını Oluşturma.
            static string sorgu = "";
            static SqlCommand komut = null;
            static SqlDataReader oku = null;
            static string[,] etkinlik;

        private void oturumKapat() //Oturumu Kapatmayı Sağlar.
        {
            Response.Cookies["KullanıcıAdı"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["Şifre"].Expires = DateTime.Now.AddDays(-1);
            Session.RemoveAll();
            Response.Redirect("/");
        }
        private void musteriKulAdiGoster() //Headerda Yönetici Kullanıcı Adını Gösterme
        {
            if (Session["musteri_kullanıcı_adı"] != null)
            {
                lblMusteriKulAdi.Text = "[" + (string)Session["musteri_kullanıcı_adı"] + "]";
            }
            else
            {
                Response.Redirect("/");
            }
        }
        private void duyurulariGoster() //Duyuruları Gösteren Metod.
        {
            baglanti = new SqlConnection(baglantiString); //SQL Bağlantısını Oluşturma.
            sorgu = "SELECT * FROM Duyurular ORDER BY Tarih DESC"; //Sorgu Stringi
            komut = new SqlCommand(sorgu, baglanti); //SQL Sorgusu Oluşturma 
            baglanti.Open(); //SQL Bağlantısını Açma.
            oku = komut.ExecuteReader(); //Eğer sorgumuzda bir tablo için SELECT işlemi yaptıysak SELECT attığımız kayıtları okumak için bu metodu kullanmalıyız.
            listDuyuru.DataSource = oku;
            listDuyuru.DataBind();
            baglanti.Close(); //SQL Bağlantısını Kapatma.
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            musteriKulAdiGoster();
            duyurulariGoster();
            if (!Page.IsPostBack)
            {
                etkinlik = new string[13, 32];
                etkinlik[03, 12] = "İstiklâl Marşı’nın Kabulü";
                etkinlik[03, 18] = "Çanakkale Deniz Zaferini Anma Günü";
                etkinlik[04, 07] = "Regaib Kandili";
                etkinlik[04, 23] = "Ulusal Egemenlik ve Çocuk Bayramı";
                etkinlik[05, 03] = "Mirac Kandili";
                etkinlik[05, 13] = "Türk Dil Bayramı";
                etkinlik[05, 19] = "Atatürk’ü Anma ve Gençlik ve Spor Bayramı";
                etkinlik[05, 21] = "Berat Kandili";
                etkinlik[05, 29] = "İstanbul’un Fethi Şenlikleri";
                etkinlik[06, 06] = "Ramazan'ın Başlangıcı";
                etkinlik[07, 01] = "Kadir Gecesi";
                etkinlik[07, 04] = "Ramazan Bayramı Arefesi";
                etkinlik[07, 05] = "Ramazan Bayramı 1.Günü";
                etkinlik[07, 06] = "Ramazan Bayramı 2.Günü";
                etkinlik[07, 07] = "Ramazan Bayramı 3.Günü";
                etkinlik[08, 30] = "Zafer Bayramı";
                etkinlik[09, 11] = "Kurban Bayramı Arefesi";
                etkinlik[09, 12] = "Kurban Bayramı 1.Günü";
                etkinlik[09, 13] = "Kurban Bayramı 2.Günü";
                etkinlik[09, 14] = "Kurban Bayramı 3.Günü";
                etkinlik[09, 15] = "Kurban Bayramı 4.Günü";
                etkinlik[10, 29] = "Cumhuriyet Bayramı";
                etkinlik[11, 10] = "Atatürk’ü Anma Günü";
                etkinlik[11, 24] = "Öğretmenler Günü";
                etkinlik[12, 11] = "Mevlid Kandili";
            }
  
        }
        protected void btnOturumKapat_Click(object sender, EventArgs e)
        {
            oturumKapat();
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.IsOtherMonth)
            {
                e.Cell.Controls.Clear();
            }
            else
            {
                Label lbl = new Label();
                lbl.CssClass = "css_appointment";
                string etkin = etkinlik[e.Day.Date.Month, e.Day.Date.Day];
                if (etkin != "")
                {
                    lbl.Text = "<br />";
                    lbl.Text += etkin;
                    e.Cell.Controls.Add(lbl);
                }
            }
        }
    }
}