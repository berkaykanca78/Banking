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
    public partial class HesapKaydi : System.Web.UI.Page
    {
        //SQL İle Bağlantı Kurmamızı Sağlayan Komutlar Static Olup İhtiyaç Olduğunda Çağırılarak Kullanılır.
            static string baglantiString = "Data Source=BERKAY-TOSH\\SQLEXPRESS;Initial Catalog=BANKA;Integrated Security=True"; //Bağlantı Stringi
            static SqlConnection baglanti = null;
            static string sorgu = "";
            static SqlCommand komut = null;
            static SqlDataReader oku = null;

        //Metodlar
            private void hesapKaydiOlustur() //Kayıt Olmayı Sağlayan Metod.
            {
                if (txtBakiye.Text != "")
                {
                    baglanti = new SqlConnection(baglantiString); //SQL Bağlantısını Oluşturma.
                    sorgu = "SELECT * FROM Yonetici WHERE Kullanici_Adi='" + lblYonKulAdi.Text + "'";
                    komut = new SqlCommand(sorgu, baglanti);
                    baglanti.Open();
                    oku = komut.ExecuteReader();
                    while (oku.Read())
                    {
                        lblYonKulAdi.Text = oku["Yonetici_No"].ToString();
                    }
                    oku.Close();

                    sorgu = "INSERT INTO Hesap(Yonetici_No,Musteri_No,Bakiye,Hesap_Turu) VALUES (@Yonetici_No,@Musteri_No,@Bakiye,@Hesap_Turu)";
                    komut = new SqlCommand(sorgu, baglanti);
                    try //Hata Aranacak Yer.
                    {
                        komut.Parameters.AddWithValue("@Yonetici_No", lblYonKulAdi.Text);//Parametre Değeri Ekleme
                        komut.Parameters.AddWithValue("@Musteri_No", ddlMusteri.SelectedValue); //Parametre Değeri Ekleme
                        komut.Parameters.AddWithValue("@Bakiye", txtBakiye.Text); //Parametre Değeri Ekleme
                        komut.Parameters.AddWithValue("@Hesap_Turu", ddlHesapTuru.SelectedItem.Text); //Parametre Değeri Ekleme
                        komut.ExecuteNonQuery();//Sorgumuzda UPDATE,DELETE gibi işlemler yapıyorsak bu metodu kullanmalıyız.Etkilediği kayıt sayısını döndürür.
                        baglanti.Close();
                        komut.Dispose();
                        lblMesaj.Text = "Hesap Oluşturuldu."; //Yeni Yönetici Eklendi.
                    }
                    catch (Exception) //Hata Bulunursa.
                    {
                        lblMesaj.Text = "Hesap Oluşturma İşleminiz Yapılırken Hata Oluştu,Lütfen Daha Sonra Tekrar Deneyiniz."; //Hata Bulunursa.
                    }
                    baglanti.Close();
                    lblYonKulAdi.Text = Session["yönetici_kullanıcı_adı"].ToString();
                }
                else
                {
                    txtBakiye.Text = "0";
                    baglanti = new SqlConnection(baglantiString); //SQL Bağlantısını Oluşturma.
                    sorgu = "SELECT * FROM Yonetici WHERE Kullanici_Adi='" + lblYonKulAdi.Text + "'";
                    komut = new SqlCommand(sorgu, baglanti);
                    baglanti.Open();
                    oku = komut.ExecuteReader();
                    while (oku.Read())
                    {
                        lblYonKulAdi.Text = oku["Yonetici_No"].ToString();
                    }
                    oku.Close();

                    sorgu = "INSERT INTO Hesap(Yonetici_No,Musteri_No,Bakiye,Hesap_Turu) VALUES (@Yonetici_No,@Musteri_No,@Bakiye,@Hesap_Turu)";
                    komut = new SqlCommand(sorgu, baglanti);
                    try //Hata Aranacak Yer.
                    {
                        komut.Parameters.AddWithValue("@Yonetici_No", lblYonKulAdi.Text);//Parametre Değeri Ekleme
                        komut.Parameters.AddWithValue("@Musteri_No", ddlMusteri.SelectedValue); //Parametre Değeri Ekleme
                        komut.Parameters.AddWithValue("@Bakiye", txtBakiye.Text); //Parametre Değeri Ekleme
                        komut.Parameters.AddWithValue("@Hesap_Turu", ddlHesapTuru.SelectedItem.Text); //Parametre Değeri Ekleme
                        komut.ExecuteNonQuery();//Sorgumuzda UPDATE,DELETE gibi işlemler yapıyorsak bu metodu kullanmalıyız.Etkilediği kayıt sayısını döndürür.
                        baglanti.Close();
                        komut.Dispose();
                        lblMesaj.Text = "Hesap Oluşturuldu."; //Yeni Yönetici Eklendi.
                    }
                    catch (Exception) //Hata Bulunursa.
                    {
                        lblMesaj.Text = "Hesap Oluşturma İşleminiz Yapılırken Hata Oluştu,Lütfen Daha Sonra Tekrar Deneyiniz."; //Hata Bulunursa.
                    }
                    baglanti.Close();
                    lblYonKulAdi.Text = Session["yönetici_kullanıcı_adı"].ToString();
                }
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
            public void DropDownListiDoldur()
            {
                baglanti = new SqlConnection(baglantiString); //SQL Bağlantısını Oluşturma.
                sorgu = "SELECT * FROM Musteri";
                komut = new SqlCommand(sorgu, baglanti);
                baglanti.Open();
                oku = komut.ExecuteReader();
                ddlMusteri.DataSource = oku;
                ddlMusteri.DataTextField = "Kullanici_Adi";
                ddlMusteri.DataValueField = "Musteri_No";
                ddlMusteri.DataBind();
                oku.Close();
                baglanti.Close();
            }

        //Sayfamız Yüklendiğinde Çalışır.
            protected void Page_Load(object sender, EventArgs e)
            {
                if (Session["yönetici_kullanıcı_adı"] != null)
                {
                    lblYonKulAdi.Text = (string)Session["yönetici_kullanıcı_adı"];
                }
                if (!Page.IsPostBack)
                {
                    DropDownListiDoldur();
                    txtBakiye.Attributes.Add("autocomplete", "off"); //Daha Önce Girilen Veriler Silinir.
                }
            }

        //Butonlar
            protected void btnTemizle_Click(object sender, EventArgs e)
            {
                temizle(this);
                lblMesaj.Text = "";
            }
            protected void btnKayit_Click(object sender, EventArgs e) //Hesap Kaydı Oluşturmayı Sağlayan Buton.
            {
                hesapKaydiOlustur();
            }
    }
}