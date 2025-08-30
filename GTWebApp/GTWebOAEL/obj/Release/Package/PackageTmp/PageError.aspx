<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PageError.aspx.vb" Inherits="GTWebOAEL.PageError" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 

     <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, user-scalable=no, maximum-scale=1.0, minimum-scale=1.0" />
    <title>Manpower Group</title>
    <link rel="stylesheet" type="text/css" href="Content/Site.css" />
    <link rel="shortcut icon" type="image/x-icon" href="favicon.ico" />
    <style>
 
        .BoxLogin {
            box-shadow: 0 10px 25px 0 rgba(50,50,93,.1), 0 5px 15px 0 rgba(0,0,0,.1);
            /*padding:60px 12px!important;*/
            margin-top:60px!important;
            background:#f4f6f7;
        }
        .divCenter {
        margin:65px auto!important;
        display :block;

        }
        .blockCenter {
        margin:0 auto!important;
        }
        .gtTitle {
        color:#4d87b9;
        font-size:1.4em;
        font-weight:500;
        padding-bottom:12px!important;
        }
        .gtContainerLogin {
        width:60%!important;
        margin:auto;
      padding:40px 10px!important;
        }
      

        body {
        font: 14px 'Segoe UI', Helvetica, 'Droid Sans', Tahoma, Geneva, sans-serif;
        font-weight: inherit;
    color: #666;
        }
        h1, h2, h3, h4, h5 {
        font-weight :normal ;
           font-size:1em;
        }
        @media (max-width: 480px) {
  .gtContainerLogin {
    width: 40%;
  }
}
        .toUpper {}
    </style>
</head>
<body class="Login">
    <form id="form1" runat="server">
 
     <div class="BoxLogin gtContainerLogin">
          <div class="" style="text-align:center">
              <h3 class="gtTitle">Error de Proceso</h3>
               <h4>Ha ocurrido un error. Por favor envía un correo <br /> al administrador de la plataforma, 
                  indicando el problema presentado  <br /> y/o contacte con nuestro personal mediante el grupo de Telegram.</h4>
              <h5>Puedes volver a la página de <a href="Default.aspx" style="color:#F87C1D;text-decoration :none ;font-weight:bold;"> >> Inicio << </a></h5>
          </div>
             
      </div>
        


    </form>
</body>
</html>
