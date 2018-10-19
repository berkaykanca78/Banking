using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Banka_Web_Site
{
    public partial class ParaCekme : System.Web.UI.Page
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
        protected void btnParaCek_Click(object sender, EventArgs e)
        {
            baglanti = new SqlConnection(baglantiString);
            sorgu = "SELECT * FROM Hesap WHERE Bakiye<@Bakiye AND Hesap_No=@Hesap_No ";
            komut = new SqlCommand(sorgu, baglanti);
            baglanti.Open();
            komut.Parameters.AddWithValue("@Bakiye", txtTutar.Text);
            komut.Parameters.AddWithValue("@Hesap_No", ddlHesapNo.SelectedValue);
            komut.ExecuteNonQuery();
            oku = komut.ExecuteReader();
            if (oku.Read())
            {
                lblBakiye.Text = "Girmiş Olduğunuz Tutar Bakiyenizden Fazladır.";
                baglanti.Close();
            }
            else
            {
                if (Convert.ToInt32(txtTutar.Text) > 1000)
                {
                    baglanti = new SqlConnection(baglantiString);
                    sorgu = "UPDATE Hesap set Bakiye = Bakiye - @Bakiye WHERE Hesap_No = @Hesap_No AND Bakiye>= @Bakiye";
                    komut = new SqlCommand(sorgu, baglanti);
                    baglanti.Open();
                    komut.Parameters.AddWithValue("@Bakiye", txtTutar.Text);
                    komut.Parameters.AddWithValue("@Hesap_No", ddlHesapNo.SelectedValue);
                    komut.ExecuteNonQuery();
                    SqlCommand komut2 = new SqlCommand
                    ("SELECT Musteri.Musteri_Mail,Musteri.Musteri_Ad,Musteri.Musteri_Soyad,Musteri.Kullanici_Adi,Hesap.Hesap_No FROM Musteri INNER JOIN Hesap ON Musteri.Musteri_No=Hesap.Musteri_No WHERE Hesap.Hesap_No=@Hesap_No2", baglanti);
                    komut2.Parameters.AddWithValue("@Hesap_No2", ddlHesapNo.SelectedValue);
                    komut2.ExecuteNonQuery();
                    SqlDataReader oku = komut2.ExecuteReader();
                    while (oku.Read())
                    {
                        MailMessage mesaj = new MailMessage();
                        mesaj.To.Add(new MailAddress(oku["Musteri_Mail"].ToString()));
                        mesaj.From = new MailAddress("bankastajprojesi@gmail.com", "Banka Otomasyonu Bilgilendirme Sistemi", System.Text.Encoding.UTF8);
                        mesaj.Subject = "Hesabınızdan 1000 TL'Den Fazla Para Çekimi Olmuştur.";
                        mesaj.Body = "Merhaba " + oku["Musteri_Ad"].ToString() + " " + oku["Musteri_Soyad"].ToString() + "\n" + "\n" + "E-Mail: " + oku["Musteri_Mail"].ToString() + "\n" + "Kullanıcı Adı: " + oku["Kullanici_Adi"].ToString() + "\n";
                        SmtpClient client = new SmtpClient();
                        client.Host = "smtp.gmail.com";
                        client.Port = 587;
                        client.Credentials = new NetworkCredential("bankastajprojesi@gmail.com", "banka_78");
                        client.EnableSsl = true;
                        try
                        {
                            client.Send(mesaj);
                            lblMesaj.Text = "Mail adresinize mesaj gönderilmiştir.";
                        }
                        catch
                        {
                            lblMesaj.Text = "Mesaj gönderilirken bir hata oluştu.";
                        }
                    }
                    oku.Close();
                    SqlCommand komut3 = new SqlCommand
                    ("INSERT INTO Hesap_Hareketleri(Hesap_No,Tutar,Tarih,Islem_Turu) VALUES(@Hesap_No,@Tutar,@Tarih,@Islem_Turu)", baglanti);
                    komut3.Parameters.AddWithValue("@Hesap_No", ddlHesapNo.SelectedValue);
                    komut3.Parameters.AddWithValue("@Tutar", txtTutar.Text);
                    komut3.Parameters.Add("@Tarih", System.Data.SqlDbType.SmallDateTime);
                    komut3.Parameters["@Tarih"].Value = DateTime.Now.ToString();
                    komut3.Parameters.AddWithValue("@Islem_Turu", "Para Çekme");
                    komut3.ExecuteNonQuery();
                    baglanti.Close();
                    lblBakiye.Text = "Bakiyeniz Güncellendi.";
                    System.Threading.Thread.Sleep(2000);
                }
                else
                {
                    baglanti = new SqlConnection(baglantiString);
                    sorgu = "UPDATE Hesap set Bakiye = Bakiye - @Bakiye WHERE Hesap_No = @Hesap_No AND Bakiye>= @Bakiye";
                    komut = new SqlCommand(sorgu, baglanti);
                    baglanti.Open();
                    komut.Parameters.AddWithValue("@Bakiye", txtTutar.Text);
                    komut.Parameters.AddWithValue("@Hesap_No", ddlHesapNo.SelectedValue);
                    komut.ExecuteNonQuery();
                    SqlCommand komut3 = new SqlCommand
                    ("INSERT INTO Hesap_Hareketleri(Hesap_No,Tutar,Tarih,Islem_Turu) VALUES(@Hesap_No,@Tutar,@Tarih,@Islem_Turu)", baglanti);
                    komut3.Parameters.AddWithValue("@Hesap_No", ddlHesapNo.SelectedValue);
                    komut3.Parameters.AddWithValue("@Tutar", txtTutar.Text);
                    komut3.Parameters.Add("@Tarih", System.Data.SqlDbType.DateTime);
                    komut3.Parameters["@Tarih"].Value = DateTime.Now.ToString();
                    komut3.Parameters.AddWithValue("@Islem_Turu", "Para Çekme");
                    komut3.ExecuteNonQuery();
                    baglanti.Close();
                    lblBakiye.Text = "Bakiyeniz Güncellendi.";
                    System.Threading.Thread.Sleep(2000);
                }
            }
            
        }
    }
}