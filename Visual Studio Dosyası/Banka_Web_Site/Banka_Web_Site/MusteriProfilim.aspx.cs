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
    public partial class MusteriProfilim : System.Web.UI.Page
    {
        //SQL İle Bağlantı Kurmamızı Sağlayan Komutlar Static Olup İhtiyaç Olduğunda Çağırılarak Kullanılır.
            static string baglantiString = "Data Source=BERKAY-TOSH\\SQLEXPRESS;Initial Catalog=BANKA;Integrated Security=True"; //Bağlantı Stringi
            static SqlConnection baglanti = null; //SQL Bağlantısını Oluşturma.
            static string sorgu = "";
            static SqlCommand komut = null;
            static SqlDataReader oku = null;

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
        protected void bilgiGetir()
        {
            DataSet liste = new DataSet();
            baglanti = new SqlConnection(baglantiString);
            sorgu = "SELECT * FROM Musteri WHERE Kullanici_Adi=@Kullanici_Adi";
            komut = new SqlCommand(sorgu, baglanti);
            baglanti.Open();
            komut.Parameters.Add("@Kullanici_Adi", SqlDbType.VarChar).Value = Session["musteri_kullanıcı_adı"];
            komut.ExecuteNonQuery();
            oku = komut.ExecuteReader();
            while (oku.Read())
            {
                lblIDBilgisi.Text = oku["Musteri_No"].ToString();
                txtKulAdı.Text = oku["Kullanici_Adi"].ToString();
                txtSifre.Text = oku["Sifre"].ToString();
                txtTC.Text = oku["Musteri_TC"].ToString();
                txtAd.Text = oku["Musteri_Ad"].ToString();
                txtSoyad.Text = oku["Musteri_Soyad"].ToString();
                txtAdres.Text = oku["Musteri_Adres"].ToString();
                txtMail.Text = oku["Musteri_Mail"].ToString();
                txtTelefon.Text = oku["Musteri_Telefon"].ToString();
                lblDogumTarihi.Text = oku["Musteri_Dogum_Tarihi"].ToString();
            }
            DateTime Tarih = DateTime.Parse(lblDogumTarihi.Text);
            lblDogumTarihi.Text = Tarih.ToShortDateString();
            baglanti.Close();
            baglanti = null;
        }
        private void gecmisiSil() //Daha Önce Girilen Veriler Silinir.
        {
            txtAd.Attributes.Add("autocomplete", "off"); //Daha Önce Girilen Veriler Silinir.
            txtAdres.Attributes.Add("autocomplete", "off"); //Daha Önce Girilen Veriler Silinir.
            txtKulAdı.Attributes.Add("autocomplete", "off"); //Daha Önce Girilen Veriler Silinir.
            txtMail.Attributes.Add("autocomplete", "off"); //Daha Önce Girilen Veriler Silinir.
            txtSifre.Attributes.Add("autocomplete", "off"); //Daha Önce Girilen Veriler Silinir.
            txtSoyad.Attributes.Add("autocomplete", "off"); //Daha Önce Girilen Veriler Silinir.
            txtTC.Attributes.Add("autocomplete", "off"); //Daha Önce Girilen Veriler Silinir.
            txtTelefon.Attributes.Add("autocomplete", "off"); //Daha Önce Girilen Veriler Silinir.
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["musteri_kullanıcı_adı"] != null)
            {
                if (!Page.IsPostBack)
                {
                    gecmisiSil();
                    bilgiGetir();
                }
                else if (Page.IsPostBack)
                {
                    Session["musteri_kullanıcı_adı"] = txtKulAdı.Text;
                    gecmisiSil();
                    baglanti = new SqlConnection(baglantiString);
                    sorgu = "SELECT * FROM Musteri WHERE Musteri_No='" + lblIDBilgisi.Text + "'";
                    komut = new SqlCommand(sorgu, baglanti);
                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                }
            }
        }
        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti = new SqlConnection(baglantiString);
            sorgu = "UPDATE Musteri SET Kullanici_Adi = '" + txtKulAdı.Text + "', Sifre = '" + txtSifre.Text + "', Musteri_TC = '" + txtTC.Text + "',Musteri_Ad='"+txtAd.Text+"',Musteri_Soyad='"+txtSoyad.Text+"',Musteri_Adres='"+txtAdres.Text+"',Musteri_Mail='"+txtMail.Text+"',Musteri_Telefon='"+txtTelefon.Text+"' WHERE Musteri_No='"+lblIDBilgisi.Text+"'";
            komut = new SqlCommand(sorgu, baglanti);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            lblMesaj.Text = "Profiliniz Güncellenmiştir.";
        }
        protected void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle(this);
            lblMesaj.Text = "";
        }
    }
}