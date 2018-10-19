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
    public partial class ParaYatirma : System.Web.UI.Page
    {
        //SQL İle Bağlantı Kurmamızı Sağlayan Komutlar Static Olup İhtiyaç Olduğunda Çağırılarak Kullanılır.
            static string baglantiString = "Data Source=BERKAY-TOSH\\SQLEXPRESS;Initial Catalog=BANKA;Integrated Security=True"; //Bağlantı Stringi
            static SqlConnection baglanti = null; //SQL Bağlantısını Oluşturma.
            static string sorgu = "";
            static SqlCommand komut = null;
            static SqlDataReader oku = null;
        private void musterinoGoster()
        {
            baglanti = new SqlConnection(baglantiString); //SQL Bağlantısını Oluşturma.
            sorgu = "SELECT * FROM Musteri WHERE Kullanici_Adi='" + (string)Session["musteri_kullanıcı_adı"] + "'";
            komut = new SqlCommand(sorgu, baglanti);
            baglanti.Open();
            oku = komut.ExecuteReader();
            while (oku.Read())
            {
                lblMusteriNo.Text = oku["Musteri_No"].ToString();
            }
            oku.Close();
            baglanti.Close();
        }
        private void hesapnoBak()
        {
            baglanti = new SqlConnection(baglantiString); //SQL Bağlantısını Oluşturma.
            sorgu = "SELECT * FROM Hesap WHERE Musteri_No='" + lblMusteriNo.Text + "'";
            komut = new SqlCommand(sorgu, baglanti);
            baglanti.Open();
            oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ddlHesapNo.SelectedValue = oku["Hesap_No"].ToString();
            }
            oku.Close();
            baglanti.Close();
        }
        public void DropDownListiDoldur()
        {
            baglanti = new SqlConnection(baglantiString);//SQL Bağlantısını Oluşturma.
            sorgu = "SELECT Hesap.*,Musteri.* FROM Hesap INNER JOIN Musteri ON Hesap.Musteri_No=Musteri.Musteri_No WHERE Musteri.Musteri_No='" + lblMusteriNo.Text + "' ORDER BY Hesap.Hesap_No";
            komut = new SqlCommand(sorgu, baglanti); //SQL Sorgusu Oluşturma 
            baglanti.Open();
            oku = komut.ExecuteReader();
            ddlHesapNo.DataSource = oku;
            ddlHesapNo.DataTextField = "Hesap_No";
            ddlHesapNo.DataValueField = "Hesap_No";
            ddlHesapNo.DataBind();
            oku.Close();
            baglanti.Close();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            baglanti = new SqlConnection(baglantiString); //SQL Bağlantısını Oluşturma.
            sorgu = "SELECT * FROM Hesap WHERE Hesap_No IN (SELECT MAX(Hesap_No) FROM Hesap)";
            komut = new SqlCommand(sorgu, baglanti);
            baglanti.Open();
            komut.CommandType = CommandType.Text;
            komut.ExecuteNonQuery(); ;
            oku = komut.ExecuteReader();
            while (oku.Read())
            {
                lblHesapTuruBilgisi.Text = oku["Hesap_Turu"].ToString();
            }
            oku.Close();
            baglanti.Close();
            if (!Page.IsPostBack) //Sayfa Yenilenmediyse Yani İlk Defa Çalışıyorsa.
            {
                musterinoGoster();
                hesapnoBak();
                DropDownListiDoldur();
            }
        }
        protected void ddlHesapNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti = new SqlConnection(baglantiString); //SQL Bağlantısını Oluşturma.
            sorgu = "SELECT * FROM Hesap WHERE Hesap_No=@Hesap_No";
            komut = new SqlCommand(sorgu, baglanti);
            baglanti.Open();
            komut.CommandType = CommandType.Text;
            komut.Parameters.AddWithValue("@Hesap_No", ddlHesapNo.SelectedValue);
            komut.ExecuteNonQuery();
            oku = komut.ExecuteReader();
            while (oku.Read())
            {
                lblHesapTuruBilgisi.Text = oku["Hesap_Turu"].ToString();
            }
            oku.Close();
            baglanti.Close();
        }
        protected void btnParaYatir_Click(object sender, EventArgs e)
        {
            baglanti = new SqlConnection(baglantiString);
            sorgu = "UPDATE Hesap set Bakiye=Bakiye+@Bakiye WHERE Hesap_No=@Hesap_No";
            komut = new SqlCommand(sorgu, baglanti);
            baglanti.Open();
            komut.Parameters.AddWithValue("@Bakiye", txtTutar.Text);
            komut.Parameters.AddWithValue("@Hesap_No", ddlHesapNo.SelectedValue);
            komut.ExecuteNonQuery();
            SqlCommand komut2 = new SqlCommand
            ("INSERT INTO Hesap_Hareketleri(Hesap_No,Tutar,Tarih,Islem_Turu) VALUES(@Hesap_No,@Tutar,@Tarih,@Islem_Turu)", baglanti);
            komut2.Parameters.AddWithValue("@Hesap_No", ddlHesapNo.SelectedValue);
            komut2.Parameters.AddWithValue("@Tutar", txtTutar.Text);
            komut2.Parameters.Add("@Tarih", System.Data.SqlDbType.SmallDateTime);
            komut2.Parameters["@Tarih"].Value = DateTime.Now.ToString();
            komut2.Parameters.AddWithValue("@Islem_Turu", "Para Yatırma");
            komut2.ExecuteNonQuery();
            baglanti.Close();
            lblMesaj.Text="Bakiyeniz Güncellendi.";
        }
    }
}