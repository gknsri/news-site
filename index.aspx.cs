using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int k = 1;
        OleDbConnection baglanti = new OleDbConnection();
        OleDbCommand sorgu = new OleDbCommand();
        OleDbDataReader getir;
        baglanti.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" + HttpContext.Current.Request.PhysicalApplicationPath + "vt.mdb";
        baglanti.Open();
        sorgu.Connection = baglanti;
        sorgu.CommandText = "select id,surmansetfoto,haberbaslik from haberler where surmansetsecim='e'";
        getir = sorgu.ExecuteReader();
        while (getir.Read())
        {
            if (k == 1)
            { surmansetsliderust.Attributes.CssStyle.Value = "background:url(haberfoto/" + Convert.ToString(getir[1]) + ")";
            surmansetslideralticbaslik.InnerHtml = Convert.ToString(getir[2]);
            }
            ListBox6.Items.Add(Convert.ToString(getir[0]));
            ListBox1.Items.Add(Convert.ToString(getir[1]));
            ListBox2.Items.Add(Convert.ToString(getir[2]));
            k++;
        }


        k = 1;
        OleDbConnection baglanti1 = new OleDbConnection();
        OleDbCommand sorgu1 = new OleDbCommand();
        OleDbDataReader getir1;
        baglanti1.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" + HttpContext.Current.Request.PhysicalApplicationPath + "vt.mdb";
        baglanti1.Open();
        sorgu1.Connection = baglanti1;
        sorgu1.CommandText = "select id,mansetfoto,detayfoto,haberbaslik from haberler where mansetsecim='e'";
        getir1 = sorgu1.ExecuteReader();
        while (getir1.Read())
        {
            if (k == 1)
            { mansetsliderust.Attributes.CssStyle.Value = "background:url(haberfoto/" + Convert.ToString(getir1[1]) + ")";
            mansetslideralticbaslik.InnerHtml = Convert.ToString(getir1[3]);
            }
            ListBox7.Items.Add(Convert.ToString(getir1[0]));
            ListBox3.Items.Add(Convert.ToString(getir1[1]));
            ListBox4.Items.Add(Convert.ToString(getir1[2]));
            ListBox5.Items.Add(Convert.ToString(getir1[3]));
            k++;
        }

        string gecici = "";
        OleDbConnection baglanti2 = new OleDbConnection();
        OleDbCommand sorgu2 = new OleDbCommand();
        OleDbDataReader getir2;
        baglanti2.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" + HttpContext.Current.Request.PhysicalApplicationPath + "vt.mdb";
        baglanti2.Open();
        sorgu2.Connection = baglanti2;
        sorgu2.CommandText = "select id,detayfoto,haberbaslik from haberler where mansetsecim='h' or surmansetsecim='h'";
        getir2=sorgu2.ExecuteReader();

        for(int i=1; i<9; i++)
        {
            getir2.Read();
            gecici = gecici + "<div class='kucukhaber'><div class='kucukhaberfoto'><a href='detay.aspx?id=" + Convert.ToString(getir2[0]) + "'><img src='haberfoto/" + Convert.ToString(getir2[1]) + "' width='149' height='117' /></div></a><div class='kucukhaberbaslik'><a href='detay.aspx?id=" + Convert.ToString(getir2[0]) + "'>" + Convert.ToString(getir2[2]) + "</a></div></div>";
       
        }
        baglanti2.Close();
        ortasol.InnerHtml = gecici;


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
        sorgu4.CommandText = "select * from reklamlar where id="+sayilar[0];
        getir4 = sorgu4.ExecuteReader();
        getir4.Read();
        reklam1.InnerHtml = "<img src='reklamlar/"+Convert.ToString(getir4[1])+"'>";
        baglanti4.Close();

        OleDbConnection baglanti5 = new OleDbConnection();
        OleDbCommand sorgu5 = new OleDbCommand();
        OleDbDataReader getir5;
        baglanti5.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" + HttpContext.Current.Request.PhysicalApplicationPath + "vt.mdb";
        baglanti5.Open();
        sorgu5.Connection = baglanti5;
        sorgu5.CommandText = "select * from reklamlar where id="+sayilar[1];
        getir5 = sorgu5.ExecuteReader();
        getir5.Read();
        reklam2.InnerHtml = "<img src='reklamlar/" + Convert.ToString(getir5[1]) + "'>";
        baglanti5.Close();

        gecici = "";
        OleDbConnection baglanti6 = new OleDbConnection();
        OleDbCommand sorgu6 = new OleDbCommand();
        OleDbDataReader getir6;
        baglanti6.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" + HttpContext.Current.Request.PhysicalApplicationPath + "vt.mdb";
        baglanti6.Open();
        sorgu6.Connection = baglanti6;
        sorgu6.CommandText = "select id,detayfoto,haberbaslik from haberler where (mansetsecim='h' or surmansetsecim='h') and kategori='Türkiye' ";
        getir6 = sorgu6.ExecuteReader();

        for (int i = 1; i < 4; i++)
        {
            getir6.Read();
            if (i != 3)
            {
                gecici = gecici + "<div class='kucukhaber1'><div class='kucukhaberfoto'><a href='detay.aspx?id=" + Convert.ToString(getir6[0]) + "'><img src='haberfoto/" + Convert.ToString(getir6[1]) + "' width='149' height='117' /></div></a><div class='kucukhaberbaslik'><a href='detay.aspx?id=" + Convert.ToString(getir6[0]) + "'>" + Convert.ToString(getir6[2]) + "</a></div></div>";
            }
            else
            {
                gecici = gecici + "<div class='kucukhaber2'><div class='kucukhaberfoto'><a href='detay.aspx?id=" + Convert.ToString(getir6[0]) + "'><img src='haberfoto/" + Convert.ToString(getir6[1]) + "' width='149' height='117' /></div></a><div class='kucukhaberbaslik'><a href='detay.aspx?id=" + Convert.ToString(getir6[0]) + "'>" + Convert.ToString(getir6[2]) + "</a></div></div>";
            }
        }

        kategorihaberleri.InnerHtml = gecici;

        gecici = "";
        OleDbConnection baglanti7 = new OleDbConnection();
        OleDbCommand sorgu7 = new OleDbCommand();
        OleDbDataReader getir7;
        baglanti7.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" + HttpContext.Current.Request.PhysicalApplicationPath + "vt.mdb";
        baglanti7.Open();
        sorgu7.Connection = baglanti7;
        sorgu7.CommandText = "select id,detayfoto,haberbaslik from haberler where (mansetsecim='h' or surmansetsecim='h') and kategori='Dünya' ";
        getir7 = sorgu7.ExecuteReader();

        for (int i = 1; i < 4; i++)
        {
            getir7.Read();
            if (i != 3)
            {
                gecici = gecici + "<div class='kucukhaber1'><div class='kucukhaberfoto'><a href='detay.aspx?id=" + Convert.ToString(getir7[0]) + "'><img src='haberfoto/" + Convert.ToString(getir7[1]) + "' width='149' height='117' /></div></a><div class='kucukhaberbaslik'><a href='detay.aspx?id=" + Convert.ToString(getir7[0]) + "'>" + Convert.ToString(getir7[2]) + "</a></div></div>";
            }
            else
            {
                gecici = gecici + "<div class='kucukhaber2'><div class='kucukhaberfoto'><a href='detay.aspx?id=" + Convert.ToString(getir7[0]) + "'><img src='haberfoto/" + Convert.ToString(getir7[1]) + "' width='149' height='117' /></div></a><div class='kucukhaberbaslik'><a href='detay.aspx?id=" + Convert.ToString(getir7[0]) + "'>" + Convert.ToString(getir7[2]) + "</a></div></div>";
            }
        }

        kategorihaberleri1.InnerHtml = gecici;



        gecici = "";
        OleDbConnection baglanti9 = new OleDbConnection();
        OleDbCommand sorgu9 = new OleDbCommand();
        OleDbDataReader getir9;
        baglanti9.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" + HttpContext.Current.Request.PhysicalApplicationPath + "vt.mdb";
        baglanti9.Open();
        sorgu9.Connection = baglanti9;
        sorgu9.CommandText = "select id,detayfoto,haberbaslik from haberler where (mansetsecim='h' or surmansetsecim='h') and kategori='Spor' ";
        getir9 = sorgu9.ExecuteReader();

        for (int i = 1; i < 4; i++)
        {
            getir9.Read();
            if (i != 3)
            {
                gecici = gecici + "<div class='kucukhaber1'><div class='kucukhaberfoto'><a href='detay.aspx?id=" + Convert.ToString(getir9[0]) + "'><img src='haberfoto/" + Convert.ToString(getir9[1]) + "' width='149' height='119' /></div></a><div class='kucukhaberbaslik'><a href='detay.aspx?id=" + Convert.ToString(getir9[0]) + "'>" + Convert.ToString(getir9[2]) + "</a></div></div>";
            }
            else
            {
                gecici = gecici + "<div class='kucukhaber2'><div class='kucukhaberfoto'><a href='detay.aspx?id=" + Convert.ToString(getir9[0]) + "'><img src='haberfoto/" + Convert.ToString(getir9[1]) + "' width='149' height='119' /></div></a><div class='kucukhaberbaslik'><a href='detay.aspx?id=" + Convert.ToString(getir9[0]) + "'>" + Convert.ToString(getir9[2]) + "</a></div></div>";
            }
        }

        kategorihaberleri3.InnerHtml = gecici;

        gecici = "";
        OleDbConnection baglanti10 = new OleDbConnection();
        OleDbCommand sorgu10 = new OleDbCommand();
        OleDbDataReader getir10;
        baglanti10.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" + HttpContext.Current.Request.PhysicalApplicationPath + "vt.mdb";
        baglanti10.Open();
        sorgu10.Connection = baglanti10;
        sorgu10.CommandText = "select id,detayfoto,haberbaslik from haberler where (mansetsecim='h' or surmansetsecim='h') and kategori='Sağlık' ";
        getir10 = sorgu10.ExecuteReader();

        for (int i = 1; i < 4; i++)
        {
            getir10.Read();
            if (i != 3)
            {
                gecici = gecici + "<div class='kucukhaber1'><div class='kucukhaberfoto'><a href='detay.aspx?id=" + Convert.ToString(getir10[0]) + "'><img src='haberfoto/" + Convert.ToString(getir10[1]) + "' width='149' height='119' /></div></a><div class='kucukhaberbaslik'><a href='detay.aspx?id=" + Convert.ToString(getir10[0]) + "'>" + Convert.ToString(getir10[2]) + "</a></div></div>";
            }
            else
            {
                gecici = gecici + "<div class='kucukhaber2'><div class='kucukhaberfoto'><a href='detay.aspx?id=" + Convert.ToString(getir10[0]) + "'><img src='haberfoto/" + Convert.ToString(getir10[1]) + "' width='149' height='119' /></div></a><div class='kucukhaberbaslik'><a href='detay.aspx?id=" + Convert.ToString(getir10[0]) + "'>" + Convert.ToString(getir10[2]) + "</a></div></div>";
            }
        }

        kategorihaberleri4.InnerHtml = gecici;

        gecici = "";
        OleDbConnection baglanti11 = new OleDbConnection();
        OleDbCommand sorgu11 = new OleDbCommand();
        OleDbDataReader getir11;
        baglanti11.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" + HttpContext.Current.Request.PhysicalApplicationPath + "vt.mdb";
        baglanti11.Open();
        sorgu11.Connection = baglanti11;
        sorgu11.CommandText = "select id,detayfoto,haberbaslik from haberler where (mansetsecim='h' or surmansetsecim='h') and kategori='Teknoloji' ";
        getir11 = sorgu11.ExecuteReader();

        for (int i = 1; i < 4; i++)
        {
            getir11.Read();
            if (i != 3)
            {
                gecici = gecici + "<div class='kucukhaber1'><div class='kucukhaberfoto'><a href='detay.aspx?id=" + Convert.ToString(getir11[0]) + "'><img src='haberfoto/" + Convert.ToString(getir11[1]) + "' width='149' height='119' /></div></a><div class='kucukhaberbaslik'><a href='detay.aspx?id=" + Convert.ToString(getir11[0]) + "'>" + Convert.ToString(getir11[2]) + "</a></div></div>";
            }
            else
            {
                gecici = gecici + "<div class='kucukhaber2'><div class='kucukhaberfoto'><a href='detay.aspx?id=" + Convert.ToString(getir11[0]) + "'><img src='haberfoto/" + Convert.ToString(getir11[1]) + "' width='149' height='119' /></div></a><div class='kucukhaberbaslik'><a href='detay.aspx?id=" + Convert.ToString(getir11[0]) + "'>" + Convert.ToString(getir11[2]) + "</a></div></div>";
            }
        }

        kategorihaberleri5.InnerHtml = gecici;

        gecici = "";
        OleDbConnection baglanti12 = new OleDbConnection();
        OleDbCommand sorgu12 = new OleDbCommand();
        OleDbDataReader getir12;
        baglanti12.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" + HttpContext.Current.Request.PhysicalApplicationPath + "vt.mdb";
        baglanti12.Open();
        sorgu12.Connection = baglanti12;
        sorgu12.CommandText = "select id,detayfoto,haberbaslik from haberler where (mansetsecim='h' or surmansetsecim='h') and kategori='Otomobil' ";
        getir12 = sorgu12.ExecuteReader();

        for (int i = 1; i < 4; i++)
        {
            getir12.Read();
            if (i != 3)
            {
                gecici = gecici + "<div class='kucukhaber1'><div class='kucukhaberfoto'><a href='detay.aspx?id=" + Convert.ToString(getir12[0]) + "'><img src='haberfoto/" + Convert.ToString(getir12[1]) + "' width='149' height='119' /></div></a><div class='kucukhaberbaslik'><a href='detay.aspx?id=" + Convert.ToString(getir12[0]) + "'>" + Convert.ToString(getir12[2]) + "</a></div></div>";
            }
            else
            {
                gecici = gecici + "<div class='kucukhaber2'><div class='kucukhaberfoto'><a href='detay.aspx?id=" + Convert.ToString(getir12[0]) + "'><img src='haberfoto/" + Convert.ToString(getir12[1]) + "' width='149' height='119' /></div></a><div class='kucukhaberbaslik'><a href='detay.aspx?id=" + Convert.ToString(getir12[0]) + "'>" + Convert.ToString(getir12[2]) + "</a></div></div>";
            }
        }

        kategorihaberleri6.InnerHtml = gecici;

        gecici = "";
        OleDbConnection baglanti13 = new OleDbConnection();
        OleDbCommand sorgu13 = new OleDbCommand();
        OleDbDataReader getir13;
        baglanti13.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" + HttpContext.Current.Request.PhysicalApplicationPath + "vt.mdb";
        baglanti13.Open();
        sorgu13.Connection = baglanti13;
        sorgu13.CommandText = "select id,detayfoto,haberbaslik from haberler where (mansetsecim='h' or surmansetsecim='h') and kategori='Sanat' ";
        getir13 = sorgu13.ExecuteReader();

        for (int i = 1; i < 4; i++)
        {
            getir13.Read();
            if (i != 3)
            {
                gecici = gecici + "<div class='kucukhaber1'><div class='kucukhaberfoto'><a href='detay.aspx?id=" + Convert.ToString(getir13[0]) + "'><img src='haberfoto/" + Convert.ToString(getir13[1]) + "' width='149' height='119' /></div></a><div class='kucukhaberbaslik'><a href='detay.aspx?id=" + Convert.ToString(getir13[0]) + "'>" + Convert.ToString(getir13[2]) + "</a></div></div>";
            }
            else
            {
                gecici = gecici + "<div class='kucukhaber2'><div class='kucukhaberfoto'><a href='detay.aspx?id=" + Convert.ToString(getir13[0]) + "'><img src='haberfoto/" + Convert.ToString(getir13[1]) + "' width='149' height='119' /></div></a><div class='kucukhaberbaslik'><a href='detay.aspx?id=" + Convert.ToString(getir13[0]) + "'>" + Convert.ToString(getir13[2]) + "</a></div></div>";
            }
        }

        kategorihaberleri7.InnerHtml = gecici;

        gecici = "";
        OleDbConnection baglanti14 = new OleDbConnection();
        OleDbCommand sorgu14 = new OleDbCommand();
        OleDbDataReader getir14;
        baglanti14.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" + HttpContext.Current.Request.PhysicalApplicationPath + "vt.mdb";
        baglanti14.Open();
        sorgu14.Connection = baglanti14;
        sorgu14.CommandText = "select id,detayfoto,haberbaslik from haberler where (mansetsecim='h' or surmansetsecim='h') and kategori='Yaşam' ";
        getir14 = sorgu14.ExecuteReader();

        for (int i = 1; i < 4; i++)
        {
            getir14.Read();
            if (i != 3)
            {
                gecici = gecici + "<div class='kucukhaber1'><div class='kucukhaberfoto'><a href='detay.aspx?id=" + Convert.ToString(getir14[0]) + "'><img src='haberfoto/" + Convert.ToString(getir14[1]) + "' width='149' height='119' /></div></a><div class='kucukhaberbaslik'><a href='detay.aspx?id=" + Convert.ToString(getir14[0]) + "'>" + Convert.ToString(getir14[2]) + "</a></div></div>";
            }
            else
            {
                gecici = gecici + "<div class='kucukhaber2'><div class='kucukhaberfoto'><a href='detay.aspx?id=" + Convert.ToString(getir14[0]) + "'><img src='haberfoto/" + Convert.ToString(getir14[1]) + "' width='149' height='119' /></div></a><div class='kucukhaberbaslik'><a href='detay.aspx?id=" + Convert.ToString(getir14[0]) + "'>" + Convert.ToString(getir14[2]) + "</a></div></div>";
            }
        }

        kategorihaberleri8.InnerHtml = gecici;

        gecici = "";
        OleDbConnection baglanti15 = new OleDbConnection();
        OleDbCommand sorgu15 = new OleDbCommand();
        OleDbDataReader getir15;
        baglanti15.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" + HttpContext.Current.Request.PhysicalApplicationPath + "vt.mdb";
        baglanti15.Open();
        sorgu15.Connection = baglanti15;
        sorgu15.CommandText = "select id,detayfoto,haberbaslik from haberler where (mansetsecim='h' or surmansetsecim='h') and kategori='Eğitim' ";
        getir15 = sorgu15.ExecuteReader();

        for (int i = 1; i < 4; i++)
        {
            getir15.Read();
            if (i != 3)
            {
                gecici = gecici + "<div class='kucukhaber1'><div class='kucukhaberfoto'><a href='detay.aspx?id=" + Convert.ToString(getir15[0]) + "'><img src='haberfoto/" + Convert.ToString(getir15[1]) + "' width='149' height='119' /></div></a><div class='kucukhaberbaslik'><a href='detay.aspx?id=" + Convert.ToString(getir15[0]) + "'>" + Convert.ToString(getir15[2]) + "</a></div></div>";
            }
            else
            {
                gecici = gecici + "<div class='kucukhaber2'><div class='kucukhaberfoto'><a href='detay.aspx?id=" + Convert.ToString(getir15[0]) + "'><img src='haberfoto/" + Convert.ToString(getir15[1]) + "' width='149' height='119' /></div></a><div class='kucukhaberbaslik'><a href='detay.aspx?id=" + Convert.ToString(getir15[0]) + "'>" + Convert.ToString(getir15[2]) + "</a></div></div>";
            }
        }

        kategorihaberleri9.InnerHtml = gecici;
    }
}