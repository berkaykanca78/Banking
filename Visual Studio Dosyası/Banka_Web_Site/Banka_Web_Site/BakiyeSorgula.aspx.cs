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
    public partial class BakiyeSorgula : System.Web.UI.Page
    {
        //SQL İle Bağlantı Kurmamızı Sağlayan Komutlar Static Olup İhtiyaç Olduğunda Çağırılarak Kullanılır.
            static string baglantiString = "Data Source=BERKAY-TOSH\\SQLEXPRESS;Initial Catalog=BANKA;Integrated Security=True"; //Bağlantı Stringi
            static SqlConnection baglanti = null; 
            static string sorgu = "";
            static SqlCommand komut = null;
            static SqlDataReader oku = null; 

        //Metodlar
            private void bakiyeSorgula() //Oturum Açmayı Sağlayan Metod.
            {
                lblBakiyeTutari.Visible = true;
                baglanti = new SqlConnection(baglantiString);//SQL Bağlantısını Oluşturma.
                sorgu = "SELECT Hesap_No,Bakiye FROM Hesap WHERE Hesap_No=@Hesap_No";
                komut = new SqlCommand(sorgu, baglanti); //SQL Sorgusu Oluşturma 
                baglanti.Open();
                komut.Parameters.AddWithValue("@Hesap_No", ddlHesapNo.SelectedValue);
                komut.ExecuteNonQuery();
                oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    lblBakiyeTutari.Text = oku["Bakiye"].ToString() + " TL";
                }
                baglanti.Close();
            }
            public void DropDownListiDoldur()
            {
                baglanti = new SqlConnection(baglantiString);//SQL Bağlantısını Oluşturma.
                sorgu = "SELECT Hesap.*,Musteri.* FROM Hesap INNER JOIN Musteri ON Hesap.Musteri_No=Musteri.Musteri_No WHERE Musteri.Kullanici_Adi='"+lblMusKulAdi.Text+"'";
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

        //Sayfamız Yüklendiğinde Çalışır.
             protected void Page_Load(object sender, EventArgs e)
             {
                if (Session["musteri_kullanıcı_Adı"] != null)
                {
                    lblMusKulAdi.Text = Session["musteri_kullanıcı_Adı"].ToString();
                    if (!Page.IsPostBack) //Sayfa Yenilenmediyse Yani İlk Defa Çalışıyorsa.
                    {
                        DropDownListiDoldur();
                        lblBakiye.Visible = false;
                        baglanti = new SqlConnection(baglantiString);//SQL Bağlantısını Oluşturma.
                        sorgu = "SELECT Hesap.*,Musteri.* FROM Hesap INNER JOIN Musteri ON Hesap.Musteri_No=Musteri.Musteri_No WHERE Musteri.Kullanici_Adi='" + lblMusKulAdi.Text + "' AND Hesap.Hesap_No IN (SELECT MIN(Hesap.Hesap_No) FROM Hesap)";
                        komut = new SqlCommand(sorgu, baglanti); //SQL Sorgusu Oluşturma 
                        baglanti.Open();
                        komut.CommandType = CommandType.Text;
                        komut.ExecuteNonQuery();
                        oku = komut.ExecuteReader();
                        while (oku.Read())
                        {
                            lblHesapTuru.Text = oku["Hesap_Turu"].ToString();
                        }
                        oku.Close();
                    }
                }
             }

        //Butonlar

            protected void btnSorgula_Click(object sender, EventArgs e)
            {
                bakiyeSorgula();
                lblBakiye.Visible = true;
            }
            protected void ddlHesapNo_SelectedIndexChanged(object sender, EventArgs e)
            {
                baglanti = new SqlConnection(baglantiString);//SQL Bağlantısını Oluşturma.
                sorgu = "SELECT Hesap.*,Musteri.* FROM Hesap INNER JOIN Musteri ON Hesap.Musteri_No=Musteri.Musteri_No WHERE Musteri.Kullanici_Adi='" + lblMusKulAdi.Text + "' AND Hesap.Hesap_No=@Hesap_No";
                komut = new SqlCommand(sorgu, baglanti); //SQL Sorgusu Oluşturma 
                baglanti.Open();
                komut.CommandType = CommandType.Text;
                komut.Parameters.AddWithValue("@Hesap_No", ddlHesapNo.SelectedValue);
                komut.ExecuteNonQuery();
                oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    lblHesapTuru.Text = oku["Hesap_Turu"].ToString();
                }
                oku.Close();
                baglanti.Close();
                lblBakiye.Visible = false;
                lblBakiyeTutari.Text = "";
            }
    }
}