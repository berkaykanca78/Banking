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
    public partial class ParaTransferi : System.Web.UI.Page
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
        private void hesapno2Bak()
        {
            baglanti = new SqlConnection(baglantiString); //SQL Bağlantısını Oluşturma.
            sorgu = "SELECT * FROM Hesap WHERE Musteri_No!='" + lblMusteriNo.Text + "'";
            komut = new SqlCommand(sorgu, baglanti);
            baglanti.Open();
            oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ddlHesapNo2.SelectedValue = oku["Hesap_No"].ToString();
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
        public void DropDownListiDoldur2()
        {
            baglanti = new SqlConnection(baglantiString);//SQL Bağlantısını Oluşturma.
            sorgu = "SELECT Hesap.*,Musteri.* FROM Hesap INNER JOIN Musteri ON Hesap.Musteri_No=Musteri.Musteri_No WHERE Musteri.Musteri_No!='" + lblMusteriNo.Text + "' ORDER BY Hesap.Hesap_No";
            komut = new SqlCommand(sorgu, baglanti); //SQL Sorgusu Oluşturma 
            baglanti.Open();
            oku = komut.ExecuteReader();
            ddlHesapNo2.DataSource = oku;
            ddlHesapNo2.DataTextField = "Hesap_No";
            ddlHesapNo2.DataValueField = "Hesap_No";
            ddlHesapNo2.DataBind();
            oku.Close();
            baglanti.Close();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) //Sayfa Yenilenmediyse Yani İlk Defa Çalışıyorsa.
            {
                musterinoGoster();
                hesapnoBak();
                hesapno2Bak();
                DropDownListiDoldur();
                DropDownListiDoldur2();
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
            baglanti.Close();
        }
        protected void ddlHesapNo2_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti = new SqlConnection(baglantiString); //SQL Bağlantısını Oluşturma.
            sorgu = "SELECT * FROM Hesap WHERE Hesap_No=@Hesap_No";
            komut = new SqlCommand(sorgu, baglanti);
            baglanti.Open();
            komut.CommandType = CommandType.Text;
            komut.Parameters.AddWithValue("@Hesap_No", ddlHesapNo.SelectedValue);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        protected void btnTransferEt_Click(object sender, EventArgs e)
        {
            baglanti = new SqlConnection(baglantiString);
            sorgu = "SELECT * FROM Hesap WHERE Bakiye<@Bakiye AND Hesap_No=@Hesap_No ";
            komut = new SqlCommand(sorgu, baglanti);
            baglanti.Open();
            komut.Parameters.AddWithValue("@Bakiye", txtTutar.Text);
            komut.Parameters.AddWithValue("@Hesap_No", ddlHesapNo.SelectedValue);
            komut.ExecuteNonQuery();
            oku = komut.ExecuteReader();
            if(oku.Read())
            {
                lblMesaj.Text = "Girmiş Olduğunuz Tutar Bakiyenizden Fazladır.";
                baglanti.Close();
            }
            else
            {
                baglanti = new SqlConnection(baglantiString);
                sorgu = "UPDATE Hesap set Bakiye=Bakiye-@Bakiye WHERE Hesap_No=@Hesap_No1 AND Bakiye>=@Bakiye";
                komut = new SqlCommand(sorgu, baglanti);
                baglanti.Open();
                komut.Parameters.AddWithValue("@Bakiye", txtTutar.Text);
                komut.Parameters.AddWithValue("@Hesap_No1", ddlHesapNo.SelectedValue);
                komut.ExecuteNonQuery();
                string sorgu2 = "UPDATE Hesap set Bakiye = Bakiye + '" + txtTutar.Text + "' WHERE Hesap_No = '" + ddlHesapNo2.SelectedValue + "'";
                SqlCommand komut2 = new SqlCommand(sorgu2, baglanti);
                SqlDataReader oku = komut2.ExecuteReader();
                while (oku.Read())
                {
                    txtTutar.Text = oku["Bakiye"].ToString();
                }
                oku.Close();
                SqlCommand komut3 = new SqlCommand("INSERT INTO Hesap_Hareketleri(Hesap_No,Tutar,Tarih,Islem_Turu,Hesap_No2) VALUES(@Hesap_No,@Tutar,@Tarih,@Islem_Turu,@Hesap_No2)", baglanti);
                komut3.Parameters.AddWithValue("@Hesap_No", ddlHesapNo.SelectedValue);
                komut3.Parameters.AddWithValue("@Tutar", txtTutar.Text);
                komut3.Parameters.Add("@Tarih", System.Data.SqlDbType.SmallDateTime);
                komut3.Parameters["@Tarih"].Value = DateTime.Now.ToString();
                komut3.Parameters.AddWithValue("@Islem_Turu", "Para Transferi");
                komut3.Parameters.AddWithValue("@Hesap_No2", ddlHesapNo2.SelectedValue);
                komut3.ExecuteNonQuery();
                baglanti.Close();
                lblMesaj.Text = "Paranız Başarı İle Transfer Edildi.";
            }
        }
    }
}