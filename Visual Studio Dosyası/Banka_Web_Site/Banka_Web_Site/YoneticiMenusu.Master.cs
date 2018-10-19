using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Banka_Web_Site
{
    public partial class YoneticiMenusu1 : System.Web.UI.MasterPage
    {
        //SQL İle Bağlantı Kurmamızı Sağlayan Komutlar Static Olup İhtiyaç Olduğunda Çağırılarak Kullanılır.
        static string baglantiString = "Data Source=BERKAY-TOSH\\SQLEXPRESS;Initial Catalog=BANKA;Integrated Security=True"; //Bağlantı Stringi
        static SqlConnection baglanti = null; //SQL Bağlantısını Oluşturma.
        static string sorgu = "";
        static SqlCommand komut = null;
        static SqlDataReader oku = null;
        private void oturumKapat() //Oturumu Kapatmayı Sağlar.
        {
            Response.Cookies["KullanıcıAdı"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["Şifre"].Expires = DateTime.Now.AddDays(-1);
            Session.RemoveAll();
            Response.Redirect("/");
        }
        private void yoneticiKulAdiGoster() //Headerda Yönetici Kullanıcı Adını Gösterme
        {
            if (Session["yönetici_kullanıcı_adı"] != null)
            {
                lblYoneticiKulAdi.Text = "[" + (string)Session["yönetici_kullanıcı_adı"] + "]";
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
            yoneticiKulAdiGoster();
            duyurulariGoster();
        }
        protected void btnOturumKapat_Click(object sender, EventArgs e)
        {
            oturumKapat();
        }
    }
}