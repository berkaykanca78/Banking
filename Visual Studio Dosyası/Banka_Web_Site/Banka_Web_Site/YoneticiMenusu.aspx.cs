using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Banka_Web_Site
{
    public partial class YoneticiMenusu : System.Web.UI.Page
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
        public void DropDownListiDoldur()
        {
            baglanti = new SqlConnection(baglantiString); //SQL Bağlantısını Oluşturma.
            sorgu = "SELECT * FROM Duyurular";
            komut = new SqlCommand(sorgu, baglanti);
            baglanti.Open();
            oku = komut.ExecuteReader();
            ddlDuyuru.DataSource = oku;
            ddlDuyuru.DataTextField = "Duyuru_No";
            ddlDuyuru.DataValueField = "Duyuru_No";
            ddlDuyuru.DataBind();
            oku.Close();
            baglanti.Close();
        }
        private void gecmisiSil() //Daha Önce Girilen Veriler Silinir.
        {
            txtBaslik.Attributes.Add("autocomplete", "off"); //Daha Önce Girilen Veriler Silinir.
            txtDuyuru.Attributes.Add("autocomplete", "off"); //Daha Önce Girilen Veriler Silinir.
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["yönetici_kullanıcı_adı"] != null)
            {
                lblYonKulAdi.Text = (string)Session["yönetici_kullanıcı_adı"];
            }
            if (!Page.IsPostBack)
            {
                gecmisiSil();
                yoneticiKulAdiGoster();
                duyurulariGoster();
                DropDownListiDoldur();
                if (Session["yönetici_kullanıcı_adı"] != null)
                {
                    lblYonKulAdi.Text = (string)Session["yönetici_kullanıcı_adı"];
                }
                baglanti = new SqlConnection(baglantiString); //SQL Bağlantısını Oluşturma.
                sorgu = "SELECT * FROM Duyurular WHERE Duyuru_No IN (SELECT MIN(Duyuru_No) FROM Duyurular)";
                komut = new SqlCommand(sorgu, baglanti);
                baglanti.Open();
                komut.CommandType = CommandType.Text;
                komut.ExecuteNonQuery(); ;
                oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    lblYonNo.Text = oku["Yonetici_No"].ToString();
                    txtBaslik.Text = oku["Baslik"].ToString();
                    txtDuyuru.Text = oku["Duyuru"].ToString();
                    lblTarihGoster.Text = oku["Tarih"].ToString();
                }
                DateTime Tarih = DateTime.Parse(lblTarihGoster.Text);
                lblTarihGoster.Text = Tarih.ToShortDateString();
                oku.Close();
                baglanti.Close();
            }
            else if (Page.IsPostBack)
            {
                gecmisiSil();
                Session["yönetici_kullanıcı_adı"] = lblYonKulAdi.Text;
                baglanti = new SqlConnection(baglantiString);
                sorgu = "SELECT * FROM Duyurular WHERE Duyuru_No='" + ddlDuyuru.SelectedValue + "'";
                komut = new SqlCommand(sorgu, baglanti);
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
                duyurulariGoster();
            }
        }
        protected void btnOturumKapat_Click(object sender, EventArgs e)
        {
            oturumKapat();
        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti = new SqlConnection(baglantiString);
            sorgu = "UPDATE Duyurular SET Baslik=@Baslik,Duyuru=@Duyuru WHERE Duyuru_No='" + ddlDuyuru.SelectedValue + "'";
            komut = new SqlCommand(sorgu, baglanti);
            baglanti.Open();
            komut.Parameters.AddWithValue("@Baslik", txtBaslik.Text); //Parametre Değeri Ekleme
            komut.Parameters.AddWithValue("@Duyuru", txtDuyuru.Text); //Parametre Değeri Ekleme
            komut.ExecuteNonQuery();
            baglanti.Close();
            lblMesaj.Text = "Duyurunuz Güncellenmiştir.";
            duyurulariGoster();
            DropDownListiDoldur();
        }

        protected void btnSilme_Click(object sender, EventArgs e)
        {
            baglanti = new SqlConnection(baglantiString);
            sorgu = "DELETE FROM Duyurular WHERE Duyuru_No=@Duyuru_No";
            komut = new SqlCommand(sorgu, baglanti);
            baglanti.Open();
            komut.Parameters.AddWithValue("@Duyuru_No", ddlDuyuru.SelectedValue); //Parametre Değeri Ekleme
            komut.ExecuteNonQuery();
            baglanti.Close();
            lblMesaj.Text = "Duyurunuz Silinmiştir.";
            duyurulariGoster();
            DropDownListiDoldur();
        }

        protected void btnEkle_Click(object sender, EventArgs e)
        {
            baglanti = new SqlConnection(baglantiString);
            sorgu = "INSERT INTO Duyurular (Yonetici_No,Baslik,Duyuru,Tarih) VALUES (@Yonetici_No,@Baslik,@Duyuru,@Tarih)";
            komut = new SqlCommand(sorgu, baglanti);
            baglanti.Open();
            komut.Parameters.Add("@Yonetici_No", System.Data.SqlDbType.BigInt);
            komut.Parameters["@Yonetici_No"].Value = lblYonNo.Text;
            komut.Parameters.Add("@Baslik", System.Data.SqlDbType.NVarChar, 50);
            komut.Parameters["@Baslik"].Value = txtBaslik.Text;
            komut.Parameters.Add("@Duyuru", System.Data.SqlDbType.NVarChar, 50);
            komut.Parameters["@Duyuru"].Value = txtDuyuru.Text;
            komut.Parameters.Add("@Tarih", System.Data.SqlDbType.DateTime2);
            komut.Parameters["@Tarih"].Value = DateTime.Now.ToString();
            komut.ExecuteNonQuery();
            baglanti.Close();
            lblMesaj.Text = "Duyurunuz Eklenmiştir.";
            duyurulariGoster();
            DropDownListiDoldur();
        }
        protected void ddlDuyuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblYonKulAdi.Text = (string)Session["yönetici_kullanıcı_adı"];
            baglanti = new SqlConnection(baglantiString); //SQL Bağlantısını Oluşturma.
            sorgu = "SELECT * FROM Duyurular WHERE Duyuru_No=@Duyuru_No";
            komut = new SqlCommand(sorgu, baglanti);
            baglanti.Open();
            komut.CommandType = CommandType.Text;
            komut.Parameters.AddWithValue("@Duyuru_No", ddlDuyuru.SelectedValue);
            komut.ExecuteNonQuery();
            oku = komut.ExecuteReader();
            while (oku.Read())
            {
                lblYonNo.Text = oku["Yonetici_No"].ToString();
                txtBaslik.Text = oku["Baslik"].ToString();
                txtDuyuru.Text = oku["Duyuru"].ToString();
                lblTarihGoster.Text = oku["Tarih"].ToString();
            }
            DateTime Tarih = DateTime.Parse(lblTarihGoster.Text);
            lblTarihGoster.Text = Tarih.ToShortDateString();
            oku.Close();
            baglanti.Close();
        }
    }
}