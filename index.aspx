<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style>
        /***** RESET *****/
html, body, div, span, applet, object, iframe, h1, h2, h3, h4, h5, h6, p, blockquote, pre, a, abbr, acronym, address, big, cite, code,del, dfn, em, font, img, ins, kbd, q, s, samp,
small, strike, sub, sup, tt, var, b, u, i, center,dl, dt, dd, ol, ul, li,fieldset, form, label, legend,table, caption, tbody, tfoot, thead, tr {
	margin: 0;
	padding: 0;
	border: 0;
	outline: 0;
	/*font-size: 100%;
	vertical-align: baseline;*/
	
}
html, body {height:100%;}
body {line-height: 1;}
ol, ul {list-style: none;}
blockquote, q {quotes: none;}
blockquote:before, blockquote:after, q:before, q:after {content: '';content: none;}
table {border-collapse: collapse;border-spacing: 0;} 
textarea {overflow:auto;}

/***** RESET *****/
        body { background:#eaeaea;
        }
        .hepsi { width:980px; height:2750px; margin:10px auto;}
        .banner { width:980px; height:150px; margin:10px auto 0 auto;}
        #menudis { width:100%; height:45px; background:url(images/menu.png);}
        .menu { width:980px; height:45px; margin:0 auto;}
        
        .menu ul li { float:left; }
        .menu ul li a{display:block; padding:13px 10px; font:13px tahoma; color:#4d4d4d; text-decoration:none }
        .menu ul li a:hover{ background:#ccc}
        #surmanset { width:980px; height:200px; }
        #slider {width:980px; height:425px; margin:10px 0 0 0;}
        #ortasol { width:670px; height:510px; float:left;margin:10px 0 0 0; }
        #ortasag { width:300px; height:510px; float:left; margin:15px 0 0 10px;}
        #reklam1 { width:300px; height:250px;}
        #reklam2 { width:300px; height:250px; margin:10px 0 0 0;}
        .kategoribaslik { width:975px; height:25px; float:left; margin:10px 0 0 0; background:#15384c; font:bold 14px tahoma; padding:5px 0 0 5px ; color:#fff; }
        #kategorihaberleri, #kategorihaberleri1, #kategorihaberleri2, #kategorihaberleri3, #kategorihaberleri4, #kategorihaberleri5, #kategorihaberleri6, #kategorihaberleri7, #kategorihaberleri8, #kategorihaberleri9{ width:980px; height:130px; margin:5px 0 0 0 ; float:left;}
        #surmansetsliderust{width:970px;height:55px;padding:145px 0 0 10px}
        #surmansetslideralt{width:970px;height:49px; }
        #surmansetslideraltic{width:220px;height:49px; float:left} 
        #surmansetslideralticbaslik{width:500px;height:34px;margin:0 0 0 180px;float:left; background:#b00;opacity:0.8; font:16px tahoma; color:#fff; padding:15px 0 0 0; text-align:center } 
        .sayi{width:40px;height:35px;background:black;float:left;font:bold 18px arial;text-align:center;color:white;padding:14px 0 0 0;cursor:pointer; opacity:0.5}
        .sayi1{width:94.4px;height:75px;float:left;cursor:pointer; opacity:0.5; margin:0 4px 0 0}
        #mansetsliderust{width:970px;height:55px;padding:295px 0 0 10px}
        #mansetslideralt{width:980px;height:49px; }
        #mansetslideraltic{width:980px;height:49px; float:left; } 
        #mansetslideralticbaslik{width:500px;height:34px;margin:0 0 0 30px;float:left; background:#00b;opacity:0.8; font:16px tahoma; color:#fff; padding:15px 0 0 0; text-align:center }
        .kucukhaber{ width:302px; height:117px; float:left;  padding:3px; background:#fff; border:1px solid #ccc; margin:5px 25px 0 0; }
        .kucukhaber1{ width:302px; height:117px; float:left;  padding:3px; background:#fff; border:1px solid #ccc; margin:5px 25px 0 0; }
        .kucukhaber2{ width:302px; height:117px; float:left;  padding:3px; background:#fff; border:1px solid #ccc; margin:5px 0 0 0; }
        .kucukhaberfoto{ width:149px; height:119px; float:left;  }
        .kucukhaberbaslik{ width:143px; height:119px; float:left; margin:0 0 0 10px; }
        .logo { width:300px; height:115px; background:url(images/logo.png) no-repeat; margin:15px 0 0 0 ; float:left      }
        #l1{ width:76px; height:76px; background:url(images/l1.png) no-repeat; margin:35px 0 0 270px; float:left; position:relative; z-index:2;        }
        #l2{ width:76px; height:76px; background:url(images/l2.png) no-repeat ; margin:35px 0 0 -10px; float:left ; position:relative;   z-index:1;    }
        #l3{ width:76px; height:76px; background:url(images/l3.png) no-repeat ; margin:35px 0 0 150px; float:left        }
        #Panel1{display:none}
        .kucukhaberbaslik a {font:12px tahoma; color:#444; text-decoration:none        }
        .kucukhaberbaslik a:hover {color:#222; text-decoration:underline        }
    </style>
    <script type="text/javascript">
        var degistir;
        function degis(x) {
            window.clearInterval(degistir);

            var resimler = new Array();
            var j = 1;


            var mansetfotolist = document.getElementById('<%=ListBox1.ClientID%>')
        var mansetfotolistuzunluk = mansetfotolist.options.length;

        for (var i = 0; i < mansetfotolistuzunluk; i++) {
            resimler[j] = mansetfotolist.options[i].value;
            j++;
        }

        var basliklar = new Array();
        j = 1;

        var basliklist = document.getElementById('<%=ListBox2.ClientID%>')
        var basliklistuzunluk = basliklist.options.length;

        for (var i = 0; i < basliklistuzunluk; i++) {
            basliklar[j] = basliklist.options[i].value;
            j++;
        }


        var idler = new Array();
        j = 1;

        var idlist = document.getElementById('<%=ListBox6.ClientID%>')
        var idlistuzunluk = idlist.options.length;

        for (var i = 0; i < idlistuzunluk; i++) {
            idler[j] = idlist.options[i].value;
            j++;
        }


        for (var i = 1; i <= 5; i++) {
            if (x == i) {
                document.getElementById("surmansetsliderust").style.background = "url(haberfoto/" + resimler[i] + ")";
                document.getElementById("surmansetslideralticbaslik").innerHTML = basliklar[i];
                document.getElementById("sayi" + i).style.background = "red";
                document.getElementById("surmansetlink").href="detay.aspx?id="+idler[i];
            }
            else { document.getElementById("sayi" + i).style.background = "black"; }
        }
    }
    function basla(z) {

        var j = 1;
        var s = z;
        var resimler = new Array();



        var mansetfotolist = document.getElementById('<%=ListBox1.ClientID%>')
        var mansetfotolistuzunluk = mansetfotolist.options.length;

        for (var i = 0; i < mansetfotolistuzunluk; i++) {
            resimler[j] = mansetfotolist.options[i].value;
            j++;
        }

        var basliklar = new Array();
        j = 1;

        var basliklist = document.getElementById('<%=ListBox2.ClientID%>')
        var basliklistuzunluk = basliklist.options.length;

        for (var i = 0; i < basliklistuzunluk; i++) {
            basliklar[j] = basliklist.options[i].value;
            j++;
        }

        var idler = new Array();
        j = 1;

        var idlist = document.getElementById('<%=ListBox6.ClientID%>')
        var idlistuzunluk = idlist.options.length;

        for (var i = 0; i < idlistuzunluk; i++) {
            idler[j] = idlist.options[i].value;
            j++;
        }

        degistir = window.setInterval(function () {
            document.getElementById("surmansetsliderust").style.background = "url(haberfoto/" + resimler[s] + ")";
            document.getElementById("surmansetslideralticbaslik").innerHTML= basliklar[s] ;
            document.getElementById("surmansetlink").href = "detay.aspx?id=" + idler[s];
            for (var i = 1; i <= 5; i++) {
                if (s == i) {

                    document.getElementById("sayi" + i).style.background = "red";
                }
                else { document.getElementById("sayi" + i).style.background = "black"; }
            }

            s++;
            if (s == 6) {
                s = 1;
            }

        }, 4000);

    }

</script>
<script type="text/javascript">
    var degistir1;
    function degis1(x) {
        window.clearInterval(degistir1);

        var resimler = new Array();
        var j = 1;


        var mansetfotolist = document.getElementById('<%=ListBox3.ClientID%>')
            var mansetfotolistuzunluk = mansetfotolist.options.length;

            for (var i = 0; i < mansetfotolistuzunluk; i++) {
                resimler[j] = mansetfotolist.options[i].value;
                j++;
            }


            var detayresimler = new Array();
            j = 1;


            var detayfotolist = document.getElementById('<%=ListBox4.ClientID%>')
        var detayfotolistuzunluk = detayfotolist.options.length;

        for (var i = 0; i < detayfotolistuzunluk; i++) {
            detayresimler[j] = detayfotolist.options[i].value;
            j++;
        }


        var idler = new Array();
        j = 1;

        var idlist = document.getElementById('<%=ListBox7.ClientID%>')
        var idlistuzunluk = idlist.options.length;

        for (var i = 0; i < idlistuzunluk; i++) {
            idler[j] = idlist.options[i].value;
            j++;
        }


            var basliklar1 = new Array();
            j = 1;

            var basliklist = document.getElementById('<%=ListBox5.ClientID%>')
        var basliklistuzunluk = basliklist.options.length;

        for (var i = 0; i < basliklistuzunluk; i++) {
            basliklar1[j] = basliklist.options[i].value;
            j++;
        }


        for (var i = 1; i <= 10; i++) {
            if (x == i) {
                document.getElementById("mansetsliderust").style.background = "url(haberfoto/" + resimler[i] + ")";
                document.getElementById("mansetlink").href = "detay.aspx?id=" + idler[i];
                document.getElementById("mansetslideralticbaslik").innerHTML = basliklar1[i];
                document.getElementById("s" + x).style.opacity = "1";
            }
            else { document.getElementById("s" + i).style.opacity = "0.5"; }
        }
    }
    function basla1(z) {

        var j = 1;
        var s = z;
        var resimler = new Array();



        var mansetfotolist = document.getElementById('<%=ListBox3.ClientID%>')
        var mansetfotolistuzunluk = mansetfotolist.options.length;

        for (var i = 0; i < mansetfotolistuzunluk; i++) {
            resimler[j] = mansetfotolist.options[i].value;
            j++;
        }


        var detayresimler = new Array();
        j = 1;


        var detayfotolist = document.getElementById('<%=ListBox4.ClientID%>')
        var detayfotolistuzunluk = detayfotolist.options.length;

        for (var i = 0; i < detayfotolistuzunluk; i++) {
            detayresimler[j] = detayfotolist.options[i].value;
            j++;
        }

        
        var idler = new Array();
        j = 1;

        var idlist = document.getElementById('<%=ListBox7.ClientID%>')
        var idlistuzunluk = idlist.options.length;

        for (var i = 0; i < idlistuzunluk; i++) {
            idler[j] = idlist.options[i].value;
            j++;
        }


        var basliklar1 = new Array();
        j = 1;

        var basliklist = document.getElementById('<%=ListBox5.ClientID%>')
        var basliklistuzunluk = basliklist.options.length;

        for (var i = 0; i < basliklistuzunluk; i++) {
            basliklar1[j] = basliklist.options[i].value;
            j++;
        }



        degistir1 = window.setInterval(function () {
            document.getElementById("mansetsliderust").style.background = "url(haberfoto/" + resimler[s] + ")";
            document.getElementById("mansetslideralticbaslik").innerHTML = basliklar1[s];
            document.getElementById("mansetlink").href = "detay.aspx?id=" + idler[s];
            for (var i = 1; i <= 10; i++) {
                if (s == i) {

                    document.getElementById("s" + i).style.opacity = "1";
                }
                else { document.getElementById("s" + i).style.opacity = "0.5"; }
            }

            s++;
            if (s == 11) {
                s = 1;
            }

        }, 3000);

    }

</script>
    <script type="text/javascript">
        function ust1()
        {
            document.getElementById("l1").style.zIndex = 2;
            document.getElementById("l2").style.zIndex = 1;
            
        }

        function ust2() {
            document.getElementById("l1").style.zIndex = 1;
            document.getElementById("l2").style.zIndex = 2;

        }
    </script>
</head>
<body onload="basla(1);basla1(1)" >
    <form id="form1" runat="server">
    <div class="banner">
        <div class="logo"></div>
        <div id="l1" onmouseover="ust1()"></div>
        <div id="l2" onmouseover="ust2()"></div>
        <div id="l3"></div>
    </div>
        <div id="menudis">
    <div class="menu">
        <ul>
            <li><a href="">TÜRKİYE</a></li>
            <li><a href="">DÜNYA</a></li>
            <li><a href="">EKONOMİ</a></li>
            <li><a href="">SPOR</a></li>
            <li><a href="">SAĞLIK</a></li>
            <li><a href="">TEKNOLOJİ</a></li>
            <li><a href="">OTOMOBİL</a></li>
            <li><a href="">SANAT</a></li>
            <li><a href="">YAŞAM</a></li>
            <li><a href="">EĞİTİM</a></li>

        </ul>

    </div>
            </div>
        <div class="hepsi">
<a id="surmansetlink">
<div id="surmanset">
<div id="surmansetsliderust" runat="server">
<div id="surmansetslideralt">
<div id="surmansetslideraltic">
<ul>
<li class="sayi" id="sayi1" onmouseover="degis(1)" onmouseout="basla(1)">1</li>
<li class="sayi" id="sayi2" onmouseover="degis(2)" onmouseout="basla(2)">2</li>
<li class="sayi" id="sayi3" onmouseover="degis(3)" onmouseout="basla(3)">3</li>
<li class="sayi" id="sayi4" onmouseover="degis(4)" onmouseout="basla(4)">4</li>
<li class="sayi" id="sayi5" onmouseover="degis(5)" onmouseout="basla(5)">5</li>

</ul>
</div>
<div id="surmansetslideralticbaslik" runat="server"></div>
</div>
</div>
</div>
</a>
    <div id="slider">
<a id="mansetlink"><div id="mansetsliderust" runat="server"><div id="mansetslideralticbaslik" runat="server"></div></div></a>
<div id="mansetslideralt">
<div id="mansetslideraltic">
<ul>
<li class="sayi1" id="s1" onmouseover="degis1(1)" onmouseout="basla1(1)"><img src="haberfoto/<% Response.Write(ListBox4.Items[0].Text);  %>" width="94" /></li>
<li class="sayi1" id="s2" onmouseover="degis1(2)" onmouseout="basla1(2)"><img src="haberfoto/<% Response.Write(ListBox4.Items[1].Text);  %>" width="94" /></li>
<li class="sayi1" id="s3" onmouseover="degis1(3)" onmouseout="basla1(3)"><img src="haberfoto/<% Response.Write(ListBox4.Items[2].Text);  %>" width="94" /></li>
<li class="sayi1" id="s4" onmouseover="degis1(4)" onmouseout="basla1(4)"><img src="haberfoto/<% Response.Write(ListBox4.Items[3].Text);  %>" width="94" /></li>
<li class="sayi1" id="s5" onmouseover="degis1(5)" onmouseout="basla1(5)"><img src="haberfoto/<% Response.Write(ListBox4.Items[4].Text);  %>" width="94" /></li>
<li class="sayi1" id="s6" onmouseover="degis1(6)" onmouseout="basla1(6)"><img src="haberfoto/<% Response.Write(ListBox4.Items[5].Text);  %>" width="94" /></li>
<li class="sayi1" id="s7" onmouseover="degis1(7)" onmouseout="basla1(7)"><img src="haberfoto/<% Response.Write(ListBox4.Items[6].Text);  %>" width="94" /></li>
<li class="sayi1" id="s8" onmouseover="degis1(8)" onmouseout="basla1(8)"><img src="haberfoto/<% Response.Write(ListBox4.Items[7].Text);  %>" width="94" /></li>
<li class="sayi1" id="s9" onmouseover="degis1(9)" onmouseout="basla1(9)"><img src="haberfoto/<% Response.Write(ListBox4.Items[8].Text);  %>" width="94" /></li>
<li class="sayi1" id="s10" onmouseover="degis1(10)" onmouseout="basla1(10)" style="margin:0"><img src="haberfoto/<% Response.Write(ListBox4.Items[9].Text);  %>" width="95" /></li>
</ul>
</div></div>





    </div>
    <div id="ortasol" runat="server"></div>
    <div id="ortasag">
        <div id="reklam1" runat="server"></div>
        <div id="reklam2"  runat="server"></div>

    </div>
    <div class="kategoribaslik">TÜRKİYE</div>
    <div id="kategorihaberleri" runat="server"></div>
        <div class="kategoribaslik">DÜNYA</div>
    <div id="kategorihaberleri1"  runat="server"></div>    
        <div class="kategoribaslik">SPOR</div>
    <div id="kategorihaberleri3" runat="server"></div>
        <div class="kategoribaslik">SAĞLIK</div>
    <div id="kategorihaberleri4" runat="server"></div>
        <div class="kategoribaslik">TEKNOLOJİ</div>
    <div id="kategorihaberleri5" runat="server"></div>
        <div class="kategoribaslik">OTOMOBİL</div>
    <div id="kategorihaberleri6" runat="server"></div>
        <div class="kategoribaslik">SANAT</div>
    <div id="kategorihaberleri7" runat="server"></div>
        <div class="kategoribaslik">YAŞAM</div>
    <div id="kategorihaberleri8" runat="server"></div>
        <div class="kategoribaslik">EĞİTİM</div>
    <div id="kategorihaberleri9" runat="server"></div>

    </div>
<asp:Panel ID="Panel1" runat="server">
        <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
        <asp:ListBox ID="ListBox2" runat="server"></asp:ListBox>
        <asp:ListBox ID="ListBox3" runat="server"></asp:ListBox>
        <asp:ListBox ID="ListBox4" runat="server"></asp:ListBox>
        <asp:ListBox ID="ListBox5" runat="server"></asp:ListBox>
        <asp:ListBox ID="ListBox6" runat="server"></asp:ListBox>
        <asp:ListBox ID="ListBox7" runat="server"></asp:ListBox>
</asp:Panel>
    </form>
</body>
</html>
