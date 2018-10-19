using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Banka_Web_Site
{
    public partial class MusteriKaydi : System.Web.UI.Page
    {
        //SQL İle Bağlantı Kurmamızı Sağlayan Komutlar Static Olup İhtiyaç Olduğunda Çağırılarak Kullanılır.
            static string baglantiString = "Data Source=BERKAY-TOSH\\SQLEXPRESS;Initial Catalog=BANKA;Integrated Security=True"; //Bağlantı Stringi
            static SqlConnection baglanti = null; //SQL Bağlantısını Oluşturma.
            static string sorgu = "";
            static SqlCommand komut = null;
            static SqlDataReader oku = null;

        private void kayitOl() //Kayıt Olmayı Sağlayan Metod.
        {
            if (txtAd.Text != "" || txtAdres.Text != "" || txtDogum.Text != "" || txtKulAdı.Text != "" || txtMail.Text != "" || txtSifre.Text != "" || txtSifre2.Text != "" || txtSoyad.Text != "" || txtTC.Text != "" || txtTelefon.Text != "")
            {
                    baglanti = new SqlConnection(baglantiString); //SQL Bağlantısını Oluşturma.
                    sorgu = "INSERT INTO Musteri(Kullanici_Adi,Sifre,Musteri_TC,Musteri_Ad,Musteri_Soyad,Musteri_Adres,Musteri_Mail,Musteri_Telefon,Musteri_Dogum_Tarihi) VALUES (@Kullanici_Adi,@Sifre,@Musteri_TC,@Musteri_Ad,@Musteri_Soyad,@Musteri_Adres,@Musteri_Mail,@Musteri_Telefon,@Musteri_Dogum_Tarihi)"; //Sorgu Stringi
                    komut = new SqlCommand(sorgu, baglanti); //SQL Sorgusu Oluşturma 
                    baglanti.Open(); //SQL Bağlantısını Açma.
                    try //Hata Aranacak Yer.
                    {
                        komut.Parameters.AddWithValue("@Kullanici_Adi", txtKulAdı.Text);//Parametre Değeri Ekleme
                        komut.Parameters.AddWithValue("@Sifre", txtSifre.Text); //Parametre Değeri Ekleme
                        komut.Parameters.AddWithValue("@Musteri_TC", txtTC.Text); //Parametre Değeri Ekleme
                        komut.Parameters.AddWithValue("@Musteri_Ad", txtAd.Text); //Parametre Değeri Ekleme
                        komut.Parameters.AddWithValue("@Musteri_Soyad", txtSoyad.Text); //Parametre Değeri Ekleme
                        komut.Parameters.AddWithValue("@Musteri_Adres", txtAdres.Text); //Parametre Değeri Ekleme
                        komut.Parameters.AddWithValue("@Musteri_Mail", txtMail.Text); //Parametre Değeri Ekleme
                        komut.Parameters.AddWithValue("@Musteri_Telefon", txtTelefon.Text); //Parametre Değeri Ekleme
                        komut.Parameters.AddWithValue("@Musteri_Dogum_Tarihi", txtDogum.Text); //Parametre Değeri Ekleme
                        komut.ExecuteNonQuery();//Sorgumuzda UPDATE,DELETE gibi işlemler yapıyorsak bu metodu kullanmalıyız.Etkilediği kayıt sayısını döndürür.
                        baglanti.Close();
                        lblMesaj.Text = "Müşteri Eklendi."; //Yeni Yönetici Eklendi.
                    }
                    catch (Exception) //Hata Bulunursa.
                    {
                        lblMesaj.Text = "Kaydolma İşleminiz Yapılırken Hata Oluştu,Lütfen Daha Sonra Tekrar Deneyiniz."; //Hata Bulunursa.
                    }
            }
            else
            {
                lblMesaj.Text = "Lütfen Müşteri Kaydı İçin Boş Alanları Doldurunuz."; //Boş Alanlar Varsa
            }
        }
        private void temizle(Control kontrol) //TextBox,DropDownList,CheckBox ve RadioButton Temizleme Fonksiyonu.
        {
            var textbox = kontrol as TextBox; //TextBoxları Kontrol Etmek.
            if (textbox != null)
                textbox.Text = string.Empty;
            var dropDownList = kontrol as DropDownList; //DropDownListleri Kontrol Etmek.
            if (dropDownList != null)
                dropDownList.SelectedIndex = 0;
            var checkBox = kontrol as CheckBox; //CheckBoxları Kontrol Etmek. 
            if (checkBox != null)
                checkBox.Checked = false;
            var radioButton = kontrol as RadioButton; //RadioButtonları Kontrol Etmek.
            if (radioButton != null)
                radioButton.Checked = false;
            foreach (Control kntrl in kontrol.Controls)
            {
                temizle(kntrl); //Kontrol Edilenleri Sıfırlama
            }
        }
        private void gecmisiSil() //Daha Önce Girilen Veriler Silinir.
        {
            txtAd.Attributes.Add("autocomplete", "off"); //Daha Önce Girilen Veriler Silinir.
            txtAdres.Attributes.Add("autocomplete", "off"); //Daha Önce Girilen Veriler Silinir.
            txtDogum.Attributes.Add("autocomplete", "off"); //Daha Önce Girilen Veriler Silinir.
            txtKulAdı.Attributes.Add("autocomplete", "off"); //Daha Önce Girilen Veriler Silinir.
            txtMail.Attributes.Add("autocomplete", "off"); //Daha Önce Girilen Veriler Silinir.
            txtSifre.Attributes.Add("autocomplete", "off"); //Daha Önce Girilen Veriler Silinir.
            txtSifre2.Attributes.Add("autocomplete", "off"); //Daha Önce Girilen Veriler Silinir.
            txtSoyad.Attributes.Add("autocomplete", "off"); //Daha Önce Girilen Veriler Silinir.
            txtTC.Attributes.Add("autocomplete", "off"); //Daha Önce Girilen Veriler Silinir.
            txtTelefon.Attributes.Add("autocomplete", "off"); //Daha Önce Girilen Veriler Silinir.
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                gecmisiSil(); //Daha Önce Girilen Veriler Silen Fonksiyonu Çağırma.
            }
        }
        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti = new SqlConnection(baglantiString); //SQL Bağlantısını Oluşturma.
            sorgu = "SELECT * FROM Musteri WHERE Kullanici_Adi='" + txtKulAdı.Text + "'";
            komut = new SqlCommand(sorgu, baglanti);
            baglanti.Open();
            oku = komut.ExecuteReader();
            if (oku.Read())
            {
                if (txtAd.Text != "" || txtAdres.Text != "" || txtDogum.Text != "" || txtKulAdı.Text != "" || txtMail.Text != "" || txtSifre.Text != "" || txtSifre2.Text != "" || txtSoyad.Text != "" || txtTC.Text != "" || txtTelefon.Text != "")
                {
                    txtKulAdı.Text = oku["Kullanici_Adi"].ToString();
                    lblMesaj.Text = "Sistemize Kayıtlı Aynı Kullanıcı Adı İçeren Kullanıcımız Var Lütfen Başka Bir Kullanıcı Adı Seçiniz."; //Aynı Kullanıcı Adı Varsa.
                    txtMail.Text = oku["Musteri_Mail"].ToString();
                    lblMesaj.Text = "Sistemize Kayıtlı Aynı E-Mail Adresi İçeren Kullanıcımız Var Lütfen Başka Bir E-Mail Adresi Seçiniz."; //Aynı Kullanıcı Adı Varsa.
                    oku.Close();
                    baglanti.Close();
                }
                else
                {
                    lblMesaj.Text = "Lütfen Müşteri Kaydı İçin Boş Alanları Doldurunuz."; //Boş Alanlar Varsa
                }
            }
            else
            {
                kayitOl();
            }
        }
        protected void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle(this); //Temizleme Fonksiyonunu Çağırma.
            lblMesaj.Text = "";
        }
    }
}