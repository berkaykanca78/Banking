using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data; 
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;

namespace Banka_Web_Site
{
    public partial class YoneticiKaydiOlustur : System.Web.UI.Page
    {
        //SQL İle Bağlantı Kurmamızı Sağlayan Komutlar Static Olup İhtiyaç Olduğunda Çağırılarak Kullanılır.
            static string baglantiString = "Data Source=BERKAY-TOSH\\SQLEXPRESS;Initial Catalog=BANKA;Integrated Security=True"; //Bağlantı Stringi
            static SqlConnection baglanti = null; //SQL Bağlantısını Oluşturma.
            static string sorgu = "";
            static SqlCommand komut = null;
        private void kayitOl() //Kayıt Olmayı Sağlayan Metod.
        {
            if(txtAd.Text!="" || txtAdres.Text!="" || txtDogum.Text!="" || txtKulAdı.Text!="" || txtMail.Text!="" || txtSifre.Text!="" || txtSifre2.Text!="" || txtSorgu.Text!="" || txtSoyad.Text!="" || txtTC.Text!="" || txtTelefon.Text!="")
            {
                if (txtSorgu.Text == "kar78" || txtSorgu.Text == "KAR78") //Eğer Kaydolma Kodu Doğru Girilmişse
                {
                        baglanti = new SqlConnection(baglantiString); //SQL Bağlantısını Oluşturma.
                        sorgu = "INSERT INTO Yonetici(Kullanici_Adi,Sifre,Yonetici_TC,Yonetici_Ad,Yonetici_Soyad,Yonetici_Adres,Yonetici_Mail,Yonetici_Telefon,Yonetici_Dogum_Tarihi) VALUES(@Kullanici_Adi,@Sifre,@Yonetici_TC,@Yonetici_Ad,@Yonetici_Soyad,@Yonetici_Adres,@Yonetici_Mail,@Yonetici_Telefon,@Yonetici_Dogum_Tarihi)"; //Sorgu Stringi
                        komut = new SqlCommand(sorgu, baglanti); //SQL Sorgusu Oluşturma 
                        baglanti.Open(); //SQL Bağlantısını Açma.
                        try //Hata Aranacak Yer.
                        {
                            komut.Parameters.AddWithValue("@Kullanici_Adi", txtKulAdı.Text);//Parametre Değeri Ekleme
                            komut.Parameters.AddWithValue("@Sifre", txtSifre.Text); //Parametre Değeri Ekleme
                            komut.Parameters.AddWithValue("@Yonetici_TC", txtTC.Text); //Parametre Değeri Ekleme
                            komut.Parameters.AddWithValue("@Yonetici_Ad", txtAd.Text); //Parametre Değeri Ekleme
                            komut.Parameters.AddWithValue("@Yonetici_Soyad", txtSoyad.Text); //Parametre Değeri Ekleme
                            komut.Parameters.AddWithValue("@Yonetici_Adres", txtAdres.Text); //Parametre Değeri Ekleme
                            komut.Parameters.AddWithValue("@Yonetici_Mail", txtMail.Text); //Parametre Değeri Ekleme
                            komut.Parameters.AddWithValue("@Yonetici_Telefon", txtTelefon.Text); //Parametre Değeri Ekleme
                            komut.Parameters.AddWithValue("@Yonetici_Dogum_Tarihi", txtDogum.Text); //Parametre Değeri Ekleme
                            komut.ExecuteNonQuery();//Sorgumuzda UPDATE,DELETE gibi işlemler yapıyorsak bu metodu kullanmalıyız.Etkilediği kayıt sayısını döndürür.
                            baglanti.Close();
                            lblUyari.Text = "Yönetici Eklendi."; //Yeni Yönetici Eklendi.
                        }
                        catch (Exception) //Hata Bulunursa.
                        {
                            lblUyari.Text = "Kaydolma İşleminiz Yapılırken Hata Oluştu,Lütfen Daha Sonra Tekrar Deneyiniz."; //Hata Bulunursa.
                        }
                    }
                else
                {
                    lblUyari.Text="Lütfen Yönetici Olduğunuzu Kanıtlamak İçin Kaydolma Kodunu Doğru Giriniz."; //Kaydolma Kodu Yanlış Girilirse
                }
            }
            else
            {
                lblUyari.Text = "Lütfen Yönetici Kaydı İçin Boş Alanları Doldurunuz."; //Boş Alanlar Varsa
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
            txtSorgu.Attributes.Add("autocomplete", "off"); //Daha Önce Girilen Veriler Silinir.
            txtSoyad.Attributes.Add("autocomplete", "off"); //Daha Önce Girilen Veriler Silinir.
            txtTC.Attributes.Add("autocomplete", "off"); //Daha Önce Girilen Veriler Silinir.
            txtTelefon.Attributes.Add("autocomplete", "off"); //Daha Önce Girilen Veriler Silinir.
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            gecmisiSil(); //Daha Önce Girilen Veriler Silen Fonksiyonu Çağırma.
        }
        protected void btnKayitOl_Click(object sender, EventArgs e)
        {
            kayitOl(); //Kayıt Olma Fonksiyonunu Çağırma.
        }
        protected void btnTemizle_Click(object sender, EventArgs e) //TextBox,DropDownList,CheckBox ve RadioButton Temizleme Butonu.
        {
            temizle(this); //Temizleme Fonksiyonunu Çağırma.
            lblUyari.Text = "";
        }
    }
}