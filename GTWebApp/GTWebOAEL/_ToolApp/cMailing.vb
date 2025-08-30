Imports System.Net.Mail
Imports System.Net

Public Class cMailing
    Public cNombres As String
    Public cClave As String
    Public cCorreoDestino As String
    Public cLinkAcceso01 As String
    Public cLinkAcceso02 As String
    Public cMail As String
    Public cMailKey As String
    Public cMailSMTP As String
    Public cMailPort As String
    Public cMailDomain As String
    Public cMailHostIP As String
    Public cNomContrata As String
    Public cUrlDrive As String
    Public cUsuario As String
    Public Function GestionarEnvio(ByVal pPlantilla As String, ByVal pDestinoCorreo As String, ByVal pDestinoNombre As String) As Boolean
        GestionarEnvio = False

        If pPlantilla = "RecuperarClave" Then
            'Me.cMail = "evaluacion.aaq@viampg.com"
            'Me.cMailKey = "uiwjezvfcagxdaop"
            'Me.cMailSMTP = "smtp.mail.yahoo.com"
            'Me.cMailPort = "587"
            'Me.cMailDomain = ""
            GestionarEnvio = EnviarCorreoRecuperarClave()
        End If


        Return GestionarEnvio
    End Function
    Public Function EnviarCorreoRecuperarClave() As Boolean 'agregar

        Dim correos As New MailMessage
        'Try


        correos.From = New MailAddress("oael@manpowergroup.pe", "OAEL - AAQ")
        correos.To.Add(Trim(Me.cCorreoDestino))
        'correos.To.Add(Trim("karemperaltavenegas@gmail.com"))

        correos.Subject = ("Datos de Usuario - Plataforma OAEL - Oficina de Apoyo al Empleo Local - Quellaveco")
        correos.IsBodyHtml = True
        correos.Priority = MailPriority.Normal
        correos.Body += "<style> .sourcesans-font{ font-family: sans-serif; } </style> <table style='width: 90%;color:#4e4e4e;' align='center'> <tr > <td> <table style='width: 100%;color:#eeeeee;background-color:#447296;border-radius:5px;padding: 18px 10px 18px 10px;height: auto; margin-top: 10px;'> <tr> <td width='50%'></td> <td width='50%' align='right' ><img style='display:inline-block;position: relative;right: 0;width: 180px;padding-right:4px;' src='https://mipostulacion.pe/images/logo-footer.png' width='180px'></td> </tr> </table> </td> </tr> <tr> <td> <p class='sourcesans-font' style='margin-top: 50px; margin-bottom: 8px;margin-left: 10px; margin-right: 10px;color:#4e4e4e;'>Estimado/a :</p> <p class='sourcesans-font' style='margin-top: 20px; margin-bottom: 4px;margin-left: 10px; margin-right: 10px;color:#4e4e4e;'> {cNomContrata}</p> <p class='sourcesans-font' style='margin-top: 0px; margin-left: 10px; margin-right: 10px;font-size: 1.6em;font-weight: bold; color: #525F77;'>{cNomCompleto}</p> </td> </tr> <tr> <td> <p class='sourcesans-font' style='margin-left: 10px; margin-right: 10px;padding-bottom: 8px; margin-top: 10px; font-size: 1.04em;color:#4e4e4e;'>Mediante la presente se confirma la cuenta de acceso a la plataforma web de la OAEL, puede ingresar mediante el siguiente enlace <a href='https://mipostulacion.pe/siel/webcandidato/LoginCandidato.aspx' style='font-weight: bold;color:#7a6f31;text-decoration:none;' target='_blank'><u>Acceder a la Plataforma del Candidato</u></a>. </p> <p class='sourcesans-font' style='margin-left: 10px; margin-right: 10px;padding-bottom: 8px; font-size: 1.04em;color:#4e4e4e;'> <b>Usuario :</b> {cUsuario} <br> <b>Clave :</b> {cClave} </p> </td> </tr> <tr><td>&nbsp;</td></tr> <tr> <td> <div style='border-radius: 8px; margin-top: 20px;margin-left: 10px; margin-right: 10px;background-color: #f5f4f0;padding: 12px 12px 20px 12px;font-size: 0.95em;'> <p class='sourcesans-font' style='padding:4px 20px 8px 20px;'> <strong>MATERIAL DE AYUDA : </strong> Adjuntamos enlaces web de material de soporte para la gestión de la plataforma, haga clic en los íconos para acceder al contenido. </p> <table> <tr> <td width='25%' align='center'> <a href='{cUrlOneDrive}' style='text-decoration:none;' target='_blank'> <img style='display:block; margin: 0 auto; width: 64px;padding-right:4px;' src='https://mipostulacion.pe/OAEL/_GTContent/images/skydrive.png' width='64px'> </a> </td> <td width='25%'> <a href='https://chat.whatsapp.com/LS1oJoYFUUhLiVqnMw7RJF' style='text-decoration:none;' target='_blank'> <img style='display:block; margin: 0 auto; width: 64px;padding-right:4px;' src='https://mipostulacion.pe/OAEL/_GTContent/images/whatsapp64.png' width='64px'> </a> </td> <td width='25%'> <a href='https://manpowergrouperu-my.sharepoint.com/:f:/g/personal/oael_manpowerperu_pe/EsLzNwvmDMdHo0D0kGW1MDMBqv6l3shXIkm3sWxOqIMvoA?e=sTIa1S' style='text-decoration:none;' target='_blank'> <img style='display:block; margin: 0 auto; width: 64px;padding-right:4px;' src='https://mipostulacion.pe/OAEL/_GTContent/images/files.png' width='64px'> </a> </td> <td width='25%'> <a href='https://mipostulacion.pe/OAEL/Login.aspx' style='text-decoration:none;' target='_blank'> <img style='display:block; margin: 0 auto; width: 64px;padding-right:4px;' src='https://mipostulacion.pe/OAEL/_GTContent/images/oaelapp.png' width='64px'> </a> </td> </tr> <tr> <td width='25%' align='center'> <p class='sourcesans-font' style='padding:0px 24px; font-size: 0.8em;color: #4e4e4e;'> <a href='{cUrlOneDrive}' target='_blank' style='color:#0b41a4;text-decoration:none;'> Repositorio OneDrive para carga de CV </a> </p> </td> <td width='25%' align='center'> <p class='sourcesans-font' style='padding:0px 24px; font-size: 0.8em;color: #4e4e4e;'> <a href='https://chat.whatsapp.com/LS1oJoYFUUhLiVqnMw7RJF' target='_blank' style='color:#168b08;text-decoration:none;'> Grupo de Soporte WhatsApp</a> </p> </td> <td width='25%' align='center'> <p class='sourcesans-font' style='padding:0px 24px; font-size: 0.8em;color: #4e4e4e;'> <a href='https://manpowergrouperu-my.sharepoint.com/:f:/g/personal/oael_manpowerperu_pe/EsLzNwvmDMdHo0D0kGW1MDMBqv6l3shXIkm3sWxOqIMvoA?e=sTIa1S' target='_blank' style='color:#0367a5;text-decoration:none;'> Manuales, video inductivo y otros de gestión</a> </p> </td> <td width='25%' align='center'> <p class='sourcesans-font' style='padding:0px 24px; font-size: 0.8em;color: #4e4e4e;'> <a href='https://mipostulacion.pe/OAEL/Login.aspx' target='_blank' style='color:#00657a;text-decoration:none;'> Acceso directo Sistema web OAEL</a> </p> </td> </tr> </table> </div> </td> </tr> <tr><td>&nbsp;</td></tr> <tr> <td> <table style='width: 90%;' align='center'> <tr> <td width='100px' align='right'> <div style='margin-left: 6px; margin-right: 12px; margin-top:12px;margin-bottom:8px;'> <img style='display:inline-block;position: relative;right: 0;width: 120px;padding-right:4px;' src='https://mipostulacion.pe/assets/img/logo-1.png' width='200px'> </div> </td> <td> <div style='margin-left: 0px; margin-right: 0px; margin-top:28px;margin-bottom:12px;padding: 10px 10px;border-left:2px solid #135b70 ; color:#525F77; '> <p class='sourcesans-font' style='font-size:1.1em;margin: 0;font-weight: bold; margin-left: 5px;'>Oficina de Apoyo al Empleo Local</p> <p class='sourcesans-font' style='margin: 0;margin-left: 5px;padding-top: 2px; font-size:0.9em;'>Soporte OAEL</p> <p class='sourcesans-font' style=' margin: 0;margin-left: 5px;padding-top: 2px;font-size:0.9em;'>(+51) 949345261</p> </div> </td> </tr> </table> </td> </tr> <tr><td>&nbsp;</td></tr> <tr><td><p class='sourcesans-font' style='padding:4px 20px 4px 20px; text-align: center; font-size:0.95em;color:#7a6f31;font-weight: bold;'>*** Este correo se ha enviado de forma automática por lo cual no debe responder al mismo. ***</td></tr> </table>"

        'correos.Body += "<table style='width: 90%;color:#4e4e4e;' align='center'><tr ><td><table style='width: 100%;color:#eeeeee;background-color:#1F4E79;padding: 18px 10px 18px 10px;height: auto;'><tr><td width='50%'></td><td width='50%' align='right' ><img style='display:inline-block;position: relative;right: 0;width: 200px;padding-right:4px; ' src='http://mipostulacion.pe/images/logo-footer.png'></td></tr></table></td></tr><tr><td><p style='padding-top:12px;'>Estimado/a :</p><p style='font-size: 1.2em;font-weight: bold; '>{cNomCompleto}</p></td></tr><tr><td><p style='padding-bottom: 6px;margin:0px!important;'>Hemos recibido una solicitud de cambio de contraseña, su nueva contraseña es :</p></td></tr><tr><td><p style='padding-bottom: 12px;'><span style='font-weight: bold;font-size:1.2em; '>{cClaveUsuario}</span></p></td></tr><tr><td><div style='background-color: #F2F2F2;padding: 8px 8px;font-size: 0.9em;'><p>Recomendamos cambiar su clave una vez que ingrese al sistema. Puede acceder al sistema desde el siguiente enlace <a href='{cUrlPlataforma}' style='font-weight: bold;color: #ED7D31;text-decoration:none;' target='_blank'>PLATAFORMA OAEL</a></p></div></td></tr><tr><td><div style='margin-top:16px;margin-bottom:12px;background-color: #F2F2F2;padding: 12px 12px;border-left:2px solid #ED7D31 ; '><p style='font-size:1.2em;margin: 0;font-weight: bold; '>Gracias por confiar en nosotros.</p><p style='margin: 0;'>Atte. Oficina de Apoyo al Empleo Local</p><p style='font-size:0.9em;margin: 0;'>Anglo American Quellaveco</p></div></td></tr></table>"

        'correos.Body = correos.Body.Replace("{cNomCompleto}", Me.cNombres)
        'correos.Body = correos.Body.Replace("{cUrlPlataforma}", Me.cLinkAcceso01)
        'correos.Body = correos.Body.Replace("{cClaveUsuario}", Me.cClave)

        correos.Body = correos.Body.Replace("{cNomCompleto}", Me.cNombres)
        correos.Body = correos.Body.Replace("{cUsuario}", Me.cUsuario)
        correos.Body = correos.Body.Replace("{cClave}", Me.cClave)
        correos.Body = correos.Body.Replace("{cNomContrata}", Me.cNomContrata)
        correos.Body = correos.Body.Replace("{cUrlOneDrive}", Me.cUrlDrive)

        Dim envios As New SmtpClient
        'envios.EnableSsl = True
        'envios.Host = Me.cMailSMTP  'gmail.com "smtp.gmail.com" 
        'envios.Port = Me.cMailPort '578 465 
        'envios.Credentials = New NetworkCredential(Me.cMail, Me.cMailKey)
        'envios.DeliveryMethod = SmtpDeliveryMethod.Network

        'MsgBox("mail: " & Me.cMail & vbCrLf & "clave: " & Me.cMailKey & vbCrLf & "port: " & Me.cMailHostIP & vbCrLf & "puesto: " & Me.cMailPort)


        Try
            envios.UseDefaultCredentials = True
            'envios.Credentials = New NetworkCredential(Me.cMail, Me.cMailKey)
            envios.Host = "10.56.4.40"
            envios.Port = 25
            envios.EnableSsl = False
            envios.DeliveryMethod = SmtpDeliveryMethod.Network

            envios.Send(correos)

            Return True
        Catch ex As SmtpFailedRecipientsException


            Return False
        Catch ex As Exception
            Return False
        Finally
            correos = Nothing
            envios = Nothing
        End Try


    End Function
End Class
