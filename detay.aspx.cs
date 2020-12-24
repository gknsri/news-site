using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class detay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int gelensayi = Convert.ToInt32(Request.QueryString["id"]);
        if (gelensayi == 0)
        { gelensayi = 1; }

        int ebid;
        OleDbConnection baglanti3 = new OleDbConnection();
        OleDbCommand sorgu3 = new OleDbCommand();
        OleDbDataReader getir3;
        baglanti3.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" + HttpContext.Current.Request.PhysicalApplicationPath + "vt.mdb";
        baglanti3.Open();
        sorgu3.Connection = baglanti3;
        sorgu3.CommandText = "select max(id) from reklamlar";
        getir3 = sorgu3.ExecuteReader();
        getir3.Read();
        ebid = Convert.ToInt32(getir3[0]);
        baglanti3.Close();

        Random a = new Random();
        int[] sayilar = new int[2];
        int uretilensayi, j = 0;
        while (j < 2)
        {
            uretilensayi = a.Next(1, ebid + 1);
            if (sayilar.Contains(uretilensayi) == false)
            {
                sayilar[j] = uretilensayi;
                j++;
            }
        }


        OleDbConnection baglanti4 = new OleDbConnection();
        OleDbCommand sorgu4 = new OleDbCommand();
        OleDbDataReader getir4;
        baglanti4.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" + HttpContext.Current.Request.PhysicalApplicationPath + "vt.mdb";
        baglanti4.Open();
        sorgu4.Connection = baglanti4;
        sorgu4.CommandText = "select * from reklamlar where id=" + sayilar[0];
        getir4 = sorgu4.ExecuteReader();
        getir4.Read();
        reklam1.InnerHtml = "<img src='reklamlar/" + Convert.ToString(getir4[1]) + "'>";
        baglanti4.Close();

        OleDbConnection baglanti5 = new OleDbConnection();
        OleDbCommand sorgu5 = new OleDbCommand();
        OleDbDataReader getir5;
        baglanti5.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" + HttpContext.Current.Request.PhysicalApplicationPath + "vt.mdb";
        baglanti5.Open();
        sorgu5.Connection = baglanti5;
        sorgu5.CommandText = "select * from reklamlar where id=" + sayilar[1];
        getir5 = sorgu5.ExecuteReader();
        getir5.Read();
        reklam2.InnerHtml = "<img src='reklamlar/" + Convert.ToString(getir5[1]) + "'>";
        baglanti5.Close();


        OleDbConnection baglanti6 = new OleDbConnection();
        OleDbCommand sorgu6= new OleDbCommand();
        OleDbDataReader getir6;
        baglanti6.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" + HttpContext.Current.Request.PhysicalApplicationPath + "vt.mdb";
        baglanti6.Open();
        sorgu6.Connection = baglanti6;
        sorgu6.CommandText = "select * from haberler where id=" + gelensayi;
        getir6 = sorgu6.ExecuteReader();
        getir6.Read();

        detaybaslik.InnerHtml=Convert.ToString(getir6["haberbaslik"]);
        detaytarih.InnerHtml = Convert.ToString(getir6["habertarih"]);
        detayfoto.InnerHtml = "<img src='haberfoto/" + Convert.ToString(getir6["detayfoto"]) + "' width='250' height='200'>";
        detayaltbaslik.InnerHtml = Convert.ToString(getir6["haberaltbaslik"]);
        detayozet.InnerHtml = Convert.ToString(getir6["haberozet"]);
        baglanti5.Close();

        OleDbConnection baglanti8 = new OleDbConnection();
        OleDbCommand sorgu8 = new OleDbCommand();
        OleDbDataReader getir8;
        baglanti8.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" + HttpContext.Current.Request.PhysicalApplicationPath + "vt.mdb";
        baglanti8.Open();
        sorgu8.Connection = baglanti8;
        sorgu8.CommandText = "select max(id) from haberler";
        getir8 = sorgu8.ExecuteReader();
        getir8.Read();
        ebid = Convert.ToInt32(getir8[0]);
        baglanti8.Close();
       
        int[] sayilar1 = new int[6];
        j = 0;
        while (j < 6)
        {
            uretilensayi = a.Next(1, ebid + 1);
            if (sayilar1.Contains(uretilensayi) == false)
            {
                sayilar1[j] = uretilensayi;
                j++;
            }
        }



        string gecici = "";
       
        

        for (int i = 0; i < 6; i++)
        {
            OleDbConnection baglanti7 = new OleDbConnection();
            OleDbCommand sorgu7 = new OleDbCommand();
            OleDbDataReader getir7;
            baglanti7.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" + HttpContext.Current.Request.PhysicalApplicationPath + "vt.mdb";
            baglanti7.Open();
            sorgu7.Connection = baglanti7;
            sorgu7.CommandText = "select id,detayfoto,haberbaslik from haberler where id="+sayilar1[i];
            getir7 = sorgu7.ExecuteReader();
            getir7.Read();
            if (i != 2 && i!=5)
            {
                gecici = gecici + "<div class='kucukhaber1'><div class='kucukhaberfoto'><a href='detay.aspx?id=" + Convert.ToString(getir7[0]) + "'><img src='haberfoto/" + Convert.ToString(getir7[1]) + "' width='149' height='117' /></div></a><div class='kucukhaberbaslik'><a href='detay.aspx?id=" + Convert.ToString(getir7[0]) + "'>" + Convert.ToString(getir7[2]) + "</a></div></div>";
            }
            else
            {
                gecici = gecici + "<div class='kucukhaber2'><div class='kucukhaberfoto'><a href='detay.aspx?id=" + Convert.ToString(getir7[0]) + "'><img src='haberfoto/" + Convert.ToString(getir7[1]) + "' width='149' height='117' /></div></a><div class='kucukhaberbaslik'><a href='detay.aspx?id=" + Convert.ToString(getir7[0]) + "'>" + Convert.ToString(getir7[2]) + "</a></div></div>";
            }
            baglanti7.Close();
        }

        kategorihaberleri.InnerHtml = gecici;


    }
}