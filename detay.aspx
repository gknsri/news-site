<%@ Page Language="C#" AutoEventWireup="true" CodeFile="detay.aspx.cs" Inherits="detay" %>

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
        .hepsi { width:980px; height:auto; margin:10px auto;}
        .banner { width:980px; height:150px; margin:10px auto 0 auto;}
        #menudis { width:100%; height:45px; background:url(images/menu.png);}
        .menu { width:980px; height:45px; margin:0 auto;}
        .menu ul li { float:left; }
        .menu ul li a{display:block; padding:13px 10px; font:13px tahoma; color:#4d4d4d; text-decoration:none }
        .menu ul li a:hover{ background:#ccc}
        .logo { width:300px; height:115px; background:url(images/logo.png) no-repeat; margin:15px 0 0 0 ; float:left      }
        #l1{ width:76px; height:76px; background:url(images/l1.png) no-repeat; margin:35px 0 0 270px; float:left; position:relative; z-index:2;        }
        #l2{ width:76px; height:76px; background:url(images/l2.png) no-repeat ; margin:35px 0 0 -10px; float:left ; position:relative;   z-index:1;    }
        #l3{ width:76px; height:76px; background:url(images/l3.png) no-repeat ; margin:35px 0 0 150px; float:left        }
        #ortasol { width:670px; height:510px; float:left;margin:10px 0 0 0; }
        #ortasag { width:300px; height:510px; float:left; margin:15px 0 0 10px;}
        #reklam1 { width:300px; height:250px;}
        #reklam2 { width:300px; height:250px; margin:10px 0 0 0;}
        #detayfoto { width:250px; height:200px; float:left; margin:10px 0 0 0 }
        #detaybaslik { width:610px; height:50px; float:left; margin:5px 10px 0 0; font:bold 18px tahoma; color:#222 }
        #detaytarih { width:50px; height:15px; float:left; margin:10px 0 0 0; font:italic 12px tahoma; color:#aaa;    }
        #detayaltbaslik { width:406px; height:135px; float:left; margin:10px 0 0 14px;font:16px tahoma; color:#222;  }
        #detayozet { width:670px; height:auto; float:left; margin:10px 0 0 0;font:14px tahoma; color:#222;   }
        #kategorihaberleri{ width:980px; height:270px; margin:5px 0 0 0 ; float:left;}
        .kucukhaber1{ width:302px; height:117px; float:left;  padding:3px; background:#fff; border:1px solid #ccc; margin:5px 25px 0 0; }
        .kucukhaber2{ width:302px; height:117px; float:left;  padding:3px; background:#fff; border:1px solid #ccc; margin:5px 0 0 0; }
        .kucukhaberfoto{ width:149px; height:119px; float:left;  }
        .kucukhaberbaslik{ width:143px; height:119px; float:left; margin:0 0 0 10px; }
        .kucukhaberbaslik a {font:12px tahoma; color:#444; text-decoration:none        }
        .kucukhaberbaslik a:hover {color:#222; text-decoration:underline        }
    </style>
   
    <script type="text/javascript">
        function ust1() {
            document.getElementById("l1").style.zIndex = 2;
            document.getElementById("l2").style.zIndex = 1;

        }

        function ust2() {
            document.getElementById("l1").style.zIndex = 1;
            document.getElementById("l2").style.zIndex = 2;

        }
    </script>
</head>
<body>
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
<div id="ortasol">
<div id="detaybaslik" runat="server"></div>
<div id="detaytarih" runat="server"></div>
<div id="detayfoto" runat="server"></div>
<div id="detayaltbaslik" runat="server"></div>
<div id="detayozet" runat="server"></div>
</div>
<div  id="ortasag">
<div id="reklam1" runat="server"></div>
<div id="reklam2" runat="server"></div>
</div>
<div id="kategorihaberleri" runat="server"></div>
</div>
    </form>
</body>
</html>