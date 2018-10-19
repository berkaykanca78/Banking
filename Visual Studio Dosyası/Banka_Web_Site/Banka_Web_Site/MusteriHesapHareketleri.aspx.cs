using Microsoft.Reporting.WebForms;
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
    public partial class MusteriHesapHareketleri : System.Web.UI.Page
    {
        //SQL İle Bağlantı Kurmamızı Sağlayan Komutlar Static Olup İhtiyaç Olduğunda Çağırılarak Kullanılır.
            static string baglantiString = "Data Source=BERKAY-TOSH\\SQLEXPRESS;Initial Catalog=BANKA;Integrated Security=True"; //Bağlantı Stringi
            static SqlConnection baglanti = null;
            static string sorgu = "";
            static SqlCommand komut = null;
            static SqlDataReader oku = null;
            static SqlDataAdapter adaptor = null;

        //Metodlar
            private DataSet1 VeriGetir(string query)
            {
                baglanti = new SqlConnection(baglantiString); //SQL Bağlantısını Oluşturma.
                komut = new SqlCommand(query);
                adaptor = new SqlDataAdapter();
                komut.Connection = baglanti;
                adaptor.SelectCommand = komut;
                DataSet1 dsHesap = new DataSet1();
                adaptor.Fill(dsHesap, "DataTable1");
                return dsHesap;
            }
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
                sorgu = "SELECT Hesap.*,Musteri.* FROM Hesap INNER JOIN Musteri ON Hesap.Musteri_No=Musteri.Musteri_No WHERE Musteri.Musteri_No='" + lblMusteriNo.Text + "' ORDER BY Hesap.Hesap_No DESC";
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
                if (!Page.IsPostBack) //Sayfa Yenilenmediyse Yani İlk Defa Çalışıyorsa.
                {
                    if (Session["musteri_kullanıcı_adı"] != null)
                    {
                        musterinoGoster();
                        hesapnoBak();
                        DropDownListiDoldur();
                        sorgu = "SELECT * FROM Hesap_Hareketleri WHERE Hesap_No='" + ddlHesapNo.SelectedValue + "' OR Hesap_No2='"+ ddlHesapNo.SelectedValue + "'";
                        ReportViewer1.ProcessingMode = ProcessingMode.Local;
                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Rapor1.rdlc");
                        DataSet1 dsHesap = VeriGetir(sorgu);
                        ReportDataSource datasource = new ReportDataSource("DataSet1", dsHesap.Tables[0]);
                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(datasource);
                    }
                }
            }

            protected void ddlHesapNo_SelectedIndexChanged(object sender, EventArgs e)
            {
                baglanti = new SqlConnection(baglantiString);//SQL Bağlantısını Oluşturma.
                sorgu = "SELECT Hesap.*,Musteri.* FROM Hesap INNER JOIN Musteri ON Hesap.Musteri_No=Musteri.Musteri_No WHERE Hesap.Hesap_No=@Hesap_No";
                komut = new SqlCommand(sorgu, baglanti); //SQL Sorgusu Oluşturma 
                baglanti.Open();
                komut.CommandType = CommandType.Text;
                komut.Parameters.AddWithValue("@Hesap_No", ddlHesapNo.SelectedValue);
                komut.ExecuteNonQuery();
                oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    sorgu = "SELECT * FROM Hesap_Hareketleri WHERE Hesap_No='" + ddlHesapNo.SelectedValue + "' OR Hesap_No2='" + ddlHesapNo.SelectedValue + "'";
                    ReportViewer1.ProcessingMode = ProcessingMode.Local;
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Rapor1.rdlc");
                    DataSet1 dsHesap = VeriGetir(sorgu);
                    ReportDataSource datasource = new ReportDataSource("DataSet1", dsHesap.Tables[0]);
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(datasource);
                }
                oku.Close();
                baglanti.Close();
            }
    }
}