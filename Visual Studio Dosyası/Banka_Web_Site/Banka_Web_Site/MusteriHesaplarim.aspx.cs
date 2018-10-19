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
    public partial class MusteriHesaplarim : System.Web.UI.Page
    {
        //SQL İle Bağlantı Kurmamızı Sağlayan Komutlar Static Olup İhtiyaç Olduğunda Çağırılarak Kullanılır.
            static string baglantiString = "Data Source=BERKAY-TOSH\\SQLEXPRESS;Initial Catalog=BANKA;Integrated Security=True"; //Bağlantı Stringi
            static SqlConnection baglanti = null; //SQL Bağlantısını Oluşturma.
            static string sorgu = "";
            static SqlCommand komut = null;
            static SqlDataReader oku = null;

        public void DropDownListiDoldur()
        {
            if (Session["musteri_kullanıcı_adı"] != null)
            {
                baglanti = new SqlConnection(baglantiString); //SQL Bağlantısını Oluşturma.
                sorgu = "SELECT Hesap.*,Musteri.* FROM Hesap INNER JOIN Musteri ON Hesap.Musteri_No=Musteri.Musteri_No WHERE Musteri.Kullanici_Adi='" + (string)Session["musteri_kullanıcı_adı"] + "'";
                komut = new SqlCommand(sorgu, baglanti);
                baglanti.Open();
                oku = komut.ExecuteReader();
                ddlHesapNo.DataSource = oku;
                ddlHesapNo.DataTextField = "Hesap_No";
                ddlHesapNo.DataValueField = "Hesap_No";
                ddlHesapNo.DataBind();
                oku.Close();
                baglanti.Close();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            baglanti = new SqlConnection(baglantiString); //SQL Bağlantısını Oluşturma.
            sorgu = "SELECT * FROM Hesap INNER JOIN Yonetici ON Hesap.Yonetici_No=Yonetici.Yonetici_No WHERE Hesap.Hesap_No IN (SELECT MIN(Hesap_No) FROM Hesap)";
            komut = new SqlCommand(sorgu, baglanti);
            baglanti.Open();
            komut.CommandType = CommandType.Text;
            komut.ExecuteNonQuery();
            oku = komut.ExecuteReader();
            while (oku.Read())
            {
                lblBakiyeBilgisi.Text = oku["Bakiye"]+" TL".ToString();
                lblHesapTuruBilgisi.Text = oku["Hesap_Turu"].ToString();
                lblYonKulAdi.Text = oku["Kullanici_Adi"].ToString();
            }
            oku.Close();
            baglanti.Close();
            if (!Page.IsPostBack) //Sayfa Yenilenmediyse Yani İlk Defa Çalışıyorsa.
            {
                if (Session["musteri_kullanıcı_adı"] != null)
                {
                    lblMusKulAdi.Text = Session["musteri_kullanıcı_adı"].ToString();
                    DropDownListiDoldur();
                }
            }
        }
        protected void ddlHesapNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMusKulAdi.Text = Session["musteri_kullanıcı_adı"].ToString();
            baglanti = new SqlConnection(baglantiString); //SQL Bağlantısını Oluşturma.
            sorgu = "SELECT * FROM Hesap INNER JOIN Yonetici ON Hesap.Yonetici_No=Yonetici.Yonetici_No WHERE Hesap.Hesap_No=@Hesap_No";
            baglanti.Open();
            komut = new SqlCommand(sorgu, baglanti);
            komut.CommandType = CommandType.Text;
            komut.Parameters.AddWithValue("@Hesap_No", ddlHesapNo.SelectedValue);
            komut.ExecuteNonQuery();
            oku = komut.ExecuteReader();
            while (oku.Read())
            {
                lblBakiyeBilgisi.Text = oku["Bakiye"]+" TL".ToString();
                lblHesapTuruBilgisi.Text = oku["Hesap_Turu"].ToString();
                lblYonKulAdi.Text = oku["Kullanici_Adi"].ToString();
            }
            oku.Close();
            baglanti.Close();
        }
    }
}