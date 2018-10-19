using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace Banka_Web_Site
{
    public partial class SifremiUnuttum : System.Web.UI.Page
    {
        //SQL İle Bağlantı Kurmamızı Sağlayan Komutlar Static Olup İhtiyaç Olduğunda Çağırılarak Kullanılır.
        static string baglantiString = "Data Source=BERKAY-TOSH\\SQLEXPRESS;Initial Catalog=BANKA;Integrated Security=True"; //Bağlantı Stringi
        static SqlConnection baglanti = null;
        static string sorgu = "";
        static string yenisifre = "";
        static SqlCommand komut = null;
        static SqlDataReader oku = null;

        private string SifreOlustur() //Yeni Şifre Oluşturma Metodu
        {
            char[] karakter = "0123456789abcdefghijklmnoprstuvyz".ToCharArray();
            string sonuc = "";
            Random rnd = new Random();
            for (int i = 0; i < 6; i++) //Şifremiz şuan 6 karakter içericek.
            {
                sonuc += karakter[rnd.Next(0, karakter.Length - 1)].ToString();
            }
            return sonuc;
        }
        private void sifreUnuttum() //Şifremizi Unutursak
        {
            if (txtMail.Text != "")
            {
                baglanti = new SqlConnection(baglantiString); //SQL Bağlantısını Oluşturma.
                sorgu = "SELECT * FROM Yonetici WHERE Yonetici_Mail='" + txtMail.Text + "'"; //Sorgu Stringi
                komut = new SqlCommand(sorgu, baglanti); //SQL Sorgusu Oluşturma 
                baglanti.Open(); //SQL Bağlantısını Açma.
                oku = komut.ExecuteReader(); //SQL İle Bİlgileri Okuma
                yenisifre = SifreOlustur(); //Yeni Şifre Oluşturma 
                if (oku.Read()) //Eğer Okursa
                {
                    MailMessage mesaj = new MailMessage();
                    mesaj.To.Add(new MailAddress(txtMail.Text));
                    mesaj.From = new MailAddress("bankastajprojesi@gmail.com", "Banka Web Sitesi Üyelik Sistemi", System.Text.Encoding.UTF8);
                    mesaj.Subject = "Yeni Şifreniz";
                    mesaj.Body = "Merhaba " + oku["Yonetici_Ad"].ToString() + " " + oku["Yonetici_Soyad"].ToString() + "\n" + "\n" + "E-Mail: " + oku["Yonetici_Mail"].ToString() + "\n" + "Kullanıcı Adı: " + oku["Kullanici_Adi"].ToString() + "\n" + "Yeni Şifreniz: " + yenisifre + "\n";
                    SmtpClient client = new SmtpClient();
                    client.Host = "smtp.gmail.com";
                    client.Port = 587;
                    client.Credentials = new NetworkCredential("bankastajprojesi@gmail.com", "banka_78");
                    client.EnableSsl = true;
                    try
                    {
                        client.Send(mesaj);
                        lblUyariMesaji.Text = "Yeni şifreniz e-mail adresinize gönderilmiştir.";
                    }
                    catch (Exception)
                    {
                        lblUyariMesaji.Text = "Mesaj gönderilirken bir hata oluştu.";
                    }
                }
                else
                {
                    lblUyariMesaji.Text = "Yazdığınız E-Mail Adresi Sistemimizde Kayıtlı Değildir.";
                }
                oku.Close();
                sorgu = "UPDATE Yonetici SET Sifre='" + yenisifre + "' WHERE Yonetici_Mail='" + txtMail.Text + "'"; //Sorgu Stringi
                SqlCommand SifreGuncelleYonetici = new SqlCommand(sorgu, baglanti); //Şifreniz Güncellenmiştir.
                SifreGuncelleYonetici.ExecuteNonQuery();

                sorgu = "SELECT * FROM Musteri WHERE Musteri_Mail='" + txtMail.Text + "'"; //Sorgu Stringi
                komut = new SqlCommand(sorgu, baglanti);
                oku = komut.ExecuteReader();
                yenisifre = SifreOlustur();
                if (oku.Read()) //Eğer Okursa
                {
                    MailMessage mesaj = new MailMessage();
                    mesaj.To.Add(new MailAddress(txtMail.Text));
                    mesaj.From = new MailAddress("bankastajprojesi@gmail.com", "Banka Web Sitesi Üyelik Sistemi", System.Text.Encoding.UTF8);
                    mesaj.Subject = "Yeni Şifreniz";
                    mesaj.Body = "Merhaba " + oku["Musteri_Ad"].ToString() + " " + oku["Musteri_Soyad"].ToString() + "\n" + "\n" + "E-Mail: " + oku["Musteri_Mail"].ToString() + "\n" + "Kullanıcı Adı: " + oku["Kullanici_Adi"].ToString() + "\n" + "Yeni Şifreniz: " + yenisifre + "\n";
                    SmtpClient client = new SmtpClient();
                    client.Host = "smtp.gmail.com";
                    client.Port = 587;
                    client.Credentials = new NetworkCredential("bankastajprojesi@gmail.com", "banka_78");
                    client.EnableSsl = true;
                    try
                    {
                        client.Send(mesaj);
                        lblUyariMesaji.Text = "Yeni şifreniz e-mail adresinize gönderilmiştir.";
                    }
                    catch (Exception)
                    {
                        lblUyariMesaji.Text = "Mesaj gönderilirken bir hata oluştu.";
                    }
                }
                else
                {
                    if (lblUyariMesaji.Text != "Yeni şifreniz e-mail adresinize gönderilmiştir.")
                    {
                        lblUyariMesaji.Text = "Yazdığınız E-Mail Adresi Sistemimizde Kayıtlı Değildir.";
                    }
                }
                oku.Close();
                sorgu = "UPDATE Musteri SET Sifre='" + yenisifre + "' WHERE Musteri_Mail='" + txtMail.Text + "'"; //Sorgu Stringi
                SqlCommand SifreGuncelleMusteri = new SqlCommand(sorgu, baglanti);
                SifreGuncelleMusteri.ExecuteNonQuery();
                baglanti.Close();
                txtMail.Text = "";
                System.Threading.Thread.Sleep(2000);
            }
            else if(txtMail.Text == "")
            {
                lblUyariMesaji.Text = "Lütfen E-Mail Adresinizi Yazınız.";
            }
        }
        private void gecmisiSil() //Daha Önce Girilen Veriler Silinir.
        {
            txtMail.Attributes.Add("autocomplete", "off"); //Daha Önce Girilen Veriler Silinir.
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            gecmisiSil();
        }
        protected void btnYeniSifre_Click(object sender, EventArgs e)
        {
            sifreUnuttum();
        }
    }
}