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
    public partial class HesapHareketleri : System.Web.UI.Page
    {
            //SQL İle Bağlantı Kurmamızı Sağlayan Komutlar Static Olup İhtiyaç Olduğunda Çağırılarak Kullanılır.
            static string baglantiString = "Data Source=BERKAY-TOSH\\SQLEXPRESS;Initial Catalog=BANKA;Integrated Security=True"; //Bağlantı Stringi
            static SqlConnection baglanti = null;
            static string sorgu = "";
            static SqlCommand komut = null;
            static SqlDataAdapter adaptor = null;

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

            //Sayfamız Yüklendiğinde Çalışır.
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!Page.IsPostBack) //Sayfa Yenilenmediyse Yani İlk Defa Çalışıyorsa.
                {
                    if (Session["yönetici_kullanıcı_adı"] != null)
                    {
                        sorgu = "SELECT * FROM Hesap_Hareketleri";
                        ReportViewer1.ProcessingMode = ProcessingMode.Local;
                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Rapor1.rdlc");
                        DataSet1 dsHesap = VeriGetir(sorgu);
                        ReportDataSource datasource = new ReportDataSource("DataSet1", dsHesap.Tables[0]);
                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(datasource);
                    }
                }
            }
    }
}