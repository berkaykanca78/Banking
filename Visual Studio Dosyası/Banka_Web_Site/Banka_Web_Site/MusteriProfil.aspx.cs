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
    public partial class MusteriProfil : System.Web.UI.Page
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
        protected void Page_Load(object sender, EventArgs e)
        {
            baglanti = new SqlConnection(baglantiString); //SQL Bağlantısını Oluşturma.
            sorgu = "SELECT * FROM Musteri WHERE Musteri_No IN (SELECT MIN(Musteri_No) FROM Musteri)";
            komut = new SqlCommand(sorgu, baglanti);
            baglanti.Open();
            komut.CommandType = CommandType.Text;
            komut.ExecuteNonQuery();;
            oku = komut.ExecuteReader();
            while (oku.Read())
            {
                lblID.Text = oku["Musteri_No"].ToString();
                lblKulAdiBilgisi.Text = oku["Kullanici_Adi"].ToString();
                lblTCBilgisi.Text = oku["Musteri_TC"].ToString();
                lblAdBilgisi.Text = oku["Musteri_Ad"].ToString();
                lblSoyadBilgisi.Text = oku["Musteri_Soyad"].ToString();
                lblAdresBilgisi.Text = oku["Musteri_Adres"].ToString();
                lblMailBilgisi.Text = oku["Musteri_Mail"].ToString();
                lblTelefonBilgisi.Text = oku["Musteri_Telefon"].ToString();
                lblDogumBilgisi.Text = oku["Musteri_Dogum_Tarihi"].ToString();
            }
            DateTime Tarih = DateTime.Parse(lblDogumBilgisi.Text);
            lblDogumBilgisi.Text = Tarih.ToShortDateString();
            oku.Close();
            baglanti.Close();
            if (!Page.IsPostBack)
            {
                DropDownListiDoldur();
            }
        }
        protected void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle(this);
        }
        protected void ddlMusteri_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti = new SqlConnection(baglantiString); //SQL Bağlantısını Oluşturma.
            sorgu = "SELECT * FROM Musteri WHERE Musteri_No=@Musteri_No";
            komut = new SqlCommand(sorgu, baglanti);
            baglanti.Open();
            komut.CommandType = CommandType.Text;
            komut.Parameters.AddWithValue("@Musteri_No", ddlMusteri.SelectedValue);
            komut.ExecuteNonQuery();
            oku = komut.ExecuteReader();
            while (oku.Read())
            {
                lblID.Text = oku["Musteri_No"].ToString();
                lblKulAdiBilgisi.Text = oku["Kullanici_Adi"].ToString();
                lblTCBilgisi.Text = oku["Musteri_TC"].ToString();
                lblAdBilgisi.Text = oku["Musteri_Ad"].ToString();
                lblSoyadBilgisi.Text = oku["Musteri_Soyad"].ToString();
                lblAdresBilgisi.Text = oku["Musteri_Adres"].ToString();
                lblMailBilgisi.Text = oku["Musteri_Mail"].ToString();
                lblTelefonBilgisi.Text = oku["Musteri_Telefon"].ToString();
                lblDogumBilgisi.Text = oku["Musteri_Dogum_Tarihi"].ToString();
            }
            DateTime Tarih = DateTime.Parse(lblDogumBilgisi.Text);
            lblDogumBilgisi.Text = Tarih.ToShortDateString();
            oku.Close();
            baglanti.Close();
        }
    }
}