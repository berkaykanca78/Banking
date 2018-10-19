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
    public partial class AnaSayfa : System.Web.UI.Page
    {
        //SQL İle Bağlantı Kurmamızı Sağlayan Komutlar Static Olup İhtiyaç Olduğunda Çağırılarak Kullanılır.
            static string baglantiString = "Data Source=BERKAY-TOSH\\SQLEXPRESS;Initial Catalog=BANKA;Integrated Security=True"; //Bağlantı Stringi
            static SqlConnection baglanti = null; 
            static string sorgu = "";
            static SqlCommand komut = null;
            static SqlDataReader oku = null;
            static string[,] etkinlik;

        //Metodlar
        private void oturumAc() //Oturum Açmayı Sağlayan Metod.
            {
                if (txtKulAdı.Text != "" && txtSifre.Text != "") //Eğer Textboxlara Değer Girilimişse
                {
                    if (ddlYetki.SelectedItem.Text == "Müşteri") //Eğer DropDownList'ten Müşteri Seçilirse
                    {
                        baglanti = new SqlConnection(baglantiString); //SQL Bağlantısını Oluşturma.
                        sorgu = "SELECT * FROM Musteri WHERE Kullanici_Adi=@Kullanici_Adi AND Sifre=@Sifre"; //Sorgu Stringi
                        komut = new SqlCommand(sorgu, baglanti); //SQL Sorgusu Oluşturma 
                        baglanti.Open(); //SQL Bağlantısını Açma.
                        try //Hata Aranacak Yer.
                        {
                            komut.Parameters.AddWithValue("@Kullanici_Adi", txtKulAdı.Text); //Parametre Değeri Ekleme
                            komut.Parameters.AddWithValue("@Sifre", txtSifre.Text); //Parametre Değeri Ekleme
                            komut.ExecuteNonQuery();//Sorgumuzda UPDATE,DELETE gibi işlemler yapıyorsak bu metodu kullanmalıyız.Etkilediği kayıt sayısını döndürür.
                            oku = komut.ExecuteReader(); //Eğer sorgumuzda bir tablo için SELECT işlemi yaptıysak SELECT attığımız kayıtları okumak için bu metodu kullanmalıyız.
                            if (oku.Read()) //Eğer tabloyu okursa
                            {
                                Session["musteri_kullanıcı_adı"] = txtKulAdı.Text; //Kullanıcı Adını içeren Session oluştur.
                                Response.Redirect("MusteriMenusu.aspx"); //Yönetici Menüsüne Yönlendir.
                            }
                            else //Okumazsa
                            {
                                lblUyari.Text = "Oturum Açma İşlemi İçin Lütfen Kullanıcı Adınızı Ve Şifrenizi Doğru Girdiğinize,Yetkinizi Doğru Seçtiğinize Emin Olunuz."; //Kullanıcı Adınızı,Şifrenizi ve Yetkinizi Kontrol Ediniz.
                            }
                            baglanti.Close(); //SQL Bağlantısını Kapatma.
                        }
                        catch (Exception) //Hata Bulunursa.
                        {
                            lblUyari.Text = "Oturum Açma İşleminiz Yapılırken Hata Oluştu,Lütfen Daha Sonra Tekrar Deneyiniz."; //Hata Bulunursa.
                        }
                    }
                    else if (ddlYetki.SelectedItem.Text == "Yönetici") //Eğer DropDownList'ten Yönetici Seçilirse
                    {
                        baglanti = new SqlConnection(baglantiString); //SQL Bağlantısını Oluşturma.
                        sorgu = "SELECT * FROM Yonetici WHERE Kullanici_Adi=@Kullanici_Adi AND Sifre=@Sifre"; //Sorgu Stringi
                        komut = new SqlCommand(sorgu, baglanti); //SQL Sorgusu Oluşturma 
                        baglanti.Open(); //SQL Bağlantısını Açma.
                        try //Hata Aranacak Yer.
                        {
                            komut.Parameters.AddWithValue("@Kullanici_Adi", txtKulAdı.Text); //Parametre Değeri Ekleme
                            komut.Parameters.AddWithValue("@Sifre", txtSifre.Text); //Parametre Değeri Ekleme
                            komut.ExecuteNonQuery();//Sorgumuzda UPDATE,DELETE gibi işlemler yapıyorsak bu metodu kullanmalıyız.Etkilediği kayıt sayısını döndürür.
                            oku = komut.ExecuteReader(); //Eğer sorgumuzda bir tablo için SELECT işlemi yaptıysak SELECT attığımız kayıtları okumak için bu metodu kullanmalıyız.
                            if (oku.Read()) //Eğer tabloyu okursa
                            {
                                Session["yönetici_kullanıcı_adı"] = txtKulAdı.Text; //Kullanıcı Adını içeren Session oluştur.
                                Response.Redirect("YoneticiMenusu.aspx"); //Yönetici Menüsüne Yönlendir.
                            }
                            else //Okumazsa
                            {
                                lblUyari.Text = "Oturum Açma İşlemi İçin Lütfen Kullanıcı Adınızı Ve Şifrenizi Doğru Girdiğinize,Yetkinizi Doğru Seçtiğinize Emin Olunuz."; //Kullanıcı Adınızı,Şifrenizi ve Yetkinizi Kontrol Ediniz.
                            }
                            baglanti.Close(); //SQL Bağlantısını Kapatma.
                        }
                        catch (Exception) //Hata Bulunursa.
                        {
                            lblUyari.Text = "Oturum Açma İşleminiz Yapılırken Hata Oluştu,Lütfen Daha Sonra Tekrar Deneyiniz."; //Hata Bulunursa.
                        }
                    }
                }
                else //Eğer Textboxlara Değer Girilimemişse
                {
                    lblUyari.Text = "Oturum Açma İşlemi İçin Boş Alanları Doldurmanız Gerekir."; //Değer Girilmemişse
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
            private void temizle(Control kontrol) //TextBox,DropDownList,CheckBox ve RadioButton Temizlemeyi Sağlayan Metod.
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
            private void beniHatirla() //Oluşturulan Çerezleri Tutmayı Sağlayan Metod.
            {
                if (cboxBeniHatırla.Checked) //Eğer BeniHatırla Checkboxu Seçili İse
                {
                    Response.Cookies["KullanıcıAdı"].Expires = DateTime.Now.AddDays(30); //Çerezleri 30 Gün Tut.
                    Response.Cookies["Şifre"].Expires = DateTime.Now.AddDays(30); //Çerezleri 30 Gün Tut.
                }
                else //Seçili Değilse
                {
                    Response.Cookies["KullanıcıAdı"].Expires = DateTime.Now.AddDays(-1); //Çerezleri Sil
                    Response.Cookies["Şifre"].Expires = DateTime.Now.AddDays(-1); //Çerezleri Sil
                }
                Response.Cookies["KullanıcıAdı"].Value = txtKulAdı.Text.Trim(); //Kullanıcı Adınızı Textboxa Girdiğinizde Çerez Olarak Ekler.
                Response.Cookies["Şifre"].Value = txtSifre.Text.Trim(); //Şifrenizi Textboxa Girdiğinizde Çerez Olarak Ekler.
            }
            private void gecmisiSil() //Daha Önce Girilen Verileri Silen Metod.
            {
                txtKulAdı.Attributes.Add("autocomplete", "off"); //Daha Önce Girilen Veriler Silinir.
                txtSifre.Attributes.Add("autocomplete", "off"); //Daha Önce Girilen Veriler Silinir.
            }
            private void cerezOlusturma() //Çerez Oluşturmayı Sağlayan Metod.
            {
                if (Request.Cookies["KullanıcıAdı"] != null && Request.Cookies["Şifre"] != null)
                {
                    txtKulAdı.Text = Request.Cookies["KullanıcıAdı"].Value;
                    txtSifre.Attributes["value"] = Request.Cookies["Şifre"].Value;
                    baglanti = new SqlConnection(baglantiString); //SQL Bağlantısını Oluşturma.
                    sorgu = "SELECT * FROM Musteri WHERE Kullanici_Adi=@Kullanici_Adi AND Sifre=@Sifre"; //Sorgu Stringi
                    komut = new SqlCommand(sorgu, baglanti); //SQL Sorgusu Oluşturma 
                    baglanti.Open(); //SQL Bağlantısını Açma.
                    try //Hata Aranacak Yer.
                    {
                        komut.Parameters.AddWithValue("@Kullanici_Adi", txtKulAdı.Text); //Parametre Değeri Ekleme
                        komut.Parameters.AddWithValue("@Sifre", txtSifre.Attributes["value"]); //Parametre Değeri Ekleme
                        komut.ExecuteNonQuery();//Sorgumuzda UPDATE,DELETE gibi işlemler yapıyorsak bu metodu kullanmalıyız.Etkilediği kayıt sayısını döndürür.
                        oku = komut.ExecuteReader(); //Eğer sorgumuzda bir tablo için SELECT işlemi yaptıysak SELECT attığımız kayıtları okumak için bu metodu kullanmalıyız.
                        if (oku.Read()) //Eğer tabloyu okursa
                        {
                            Session["musteri_kullanıcı_adı"] = txtKulAdı.Text; //Kullanıcı Adını içeren Session oluştur.
                            Response.Redirect("MusteriMenusu.aspx"); //Yönetici Menüsüne Yönlendir.
                        }
                        else //Okumazsa
                        {
                            lblUyari.Text = "Oturum Açma İşlemi İçin Lütfen Kullanıcı Adınızı Ve Şifrenizi Doğru Girdiğinize,Yetkinizi Doğru Seçtiğinize Emin Olunuz."; //Kullanıcı Adınızı,Şifrenizi ve Yetkinizi Kontrol Ediniz.
                        }
                        baglanti.Close();
                        sorgu = "";
                        komut = null;
                        oku.Close();
                    }
                    catch (Exception) //Hata Bulunursa.
                    {
                        lblUyari.Text = "Oturum Açma İşleminiz Yapılırken Hata Oluştu,Lütfen Daha Sonra Tekrar Deneyiniz."; //Hata Bulunursa.
                    }

                    baglanti = new SqlConnection(baglantiString); //SQL Bağlantısını Oluşturma.
                    sorgu = "SELECT * FROM Yonetici WHERE Kullanici_Adi=@Kullanici_Adi AND Sifre=@Sifre"; //Sorgu Stringi
                    komut = new SqlCommand(sorgu, baglanti); //SQL Sorgusu Oluşturma 
                    baglanti.Open(); //SQL Bağlantısını Açma.
                    try //Hata Aranacak Yer.
                    {
                        komut.Parameters.AddWithValue("@Kullanici_Adi", txtKulAdı.Text); //Parametre Değeri Ekleme
                        komut.Parameters.AddWithValue("@Sifre", txtSifre.Attributes["value"]); //Parametre Değeri Ekleme
                        komut.ExecuteNonQuery();//Sorgumuzda UPDATE,DELETE gibi işlemler yapıyorsak bu metodu kullanmalıyız.Etkilediği kayıt sayısını döndürür.
                        oku = komut.ExecuteReader(); //Eğer sorgumuzda bir tablo için SELECT işlemi yaptıysak SELECT attığımız kayıtları okumak için bu metodu kullanmalıyız.
                        if (oku.Read()) //Eğer tabloyu okursa
                        {
                            Session["yönetici_kullanıcı_adı"] = txtKulAdı.Text; //Kullanıcı Adını içeren Session oluştur.
                            Response.Redirect("YoneticiMenusu.aspx"); //Yönetici Menüsüne Yönlendir.
                        }
                        else //Okumazsa
                        {
                            lblUyari.Text = "Oturum Açma İşlemi İçin Lütfen Kullanıcı Adınızı Ve Şifrenizi Doğru Girdiğinize,Yetkinizi Doğru Seçtiğinize Emin Olunuz."; //Kullanıcı Adınızı,Şifrenizi ve Yetkinizi Kontrol Ediniz.
                        }
                        baglanti.Close();
                        sorgu = "";
                        komut = null;
                        oku.Close();
                    }
                    catch (Exception) //Hata Bulunursa.
                    {
                        lblUyari.Text = "Oturum Açma İşleminiz Yapılırken Hata Oluştu,Lütfen Daha Sonra Tekrar Deneyiniz."; //Hata Bulunursa.
                    }
                }
            }

        //Sayfamız Yüklendiğinde Çalışır.
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!Page.IsPostBack) //Sayfa Yenilenmediyse Yani İlk Defa Çalışıyorsa.
                {
                    duyurulariGoster(); //Duyuruları Gösteren Metodu Çağırır.
                    gecmisiSil(); //Daha Önce Girilen Verileri Silen Metodu Çağırır.
                    cerezOlusturma(); //Çerez Oluşturmayı Sağlayan Metodu Çağırır.
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

        //Butonlar
            protected void btnGiris_Click(object sender, EventArgs e) //Oturum Açmamızı Sağlayan Buton.
            {
                beniHatirla(); //Oluşturulan Çerezleri Tutmayı Sağlayan Metodu Çağırır.
                oturumAc(); //Oturum Açmayı Sağlayan Metodu Çağırır.
            }
            protected void btnTemizle_Click(object sender, EventArgs e) //TextBox,DropDownList,CheckBox ve RadioButton Temizleme Butonu.
            {
                Response.Cookies["KullanıcıAdı"].Expires = DateTime.Now.AddDays(-1); //Çerezleri Silme
                Response.Cookies["Şifre"].Expires = DateTime.Now.AddDays(-1); //Çerezleri Silme
                temizle(this); //Temizleme Fonksiyonunu Çağırma.
                lblUyari.Text = "";
            }
            protected void linkbtnSifre_Click(object sender, EventArgs e) //Şifrenizi Unuttuysanız Mail İle Yeni Şifre Gönderen LinkButonu.
            {
                Response.Redirect("SifremiUnuttum.aspx"); //Şifremi Unuttum Sayfasına Yönlendirmek İçin Kullanılır.
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