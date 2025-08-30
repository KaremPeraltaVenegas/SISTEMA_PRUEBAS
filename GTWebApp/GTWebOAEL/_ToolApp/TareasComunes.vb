Imports DevExpress.XtraGrid
Imports DevExpress.XtraEditors
Imports System.Net
Imports System.Text

Module TareasComunes
   
    Public Function ToNumStr(ByVal myNumeral As String) As String
        Return Replace(myNumeral, ",", "")
    End Function
    Public Function F_ColocarFecha(ByVal myDate As String) As Date
        Return CDate(Format(CDate(myDate), "dd/MM/yyyy"))
    End Function
    Public Function F_ObtenerFecha(ByVal myDate As Date) As String
        Return Format(myDate, "yyyy-MM-dd")
    End Function
    Public Function GlobalDateNow() As String
        Return Format(Date.Now, "yyyy-MM-dd HH:mm:ss")
    End Function
    Public Function GlobalDateOnly() As String
        Return Format(Date.Now, "yyyy-MM-dd")
    End Function
    Public Function getParametrosReporte() As DevExpress.DataAccess.ConnectionParameters.MsSqlConnectionParameters
        Con_cServer = "10.56.67.4"
        Con_cDatabase = "GTManpowerLocal"
        Con_cUser = "APPQUELLAVECO"
        Con_cClave = "Gelbert2019."

        'Con_cServer = "."
        'Con_cDatabase = "GTManpowerLocal"
        'Con_cUser = "aaq"
        'Con_cClave = "abc123*"

        getParametrosReporte = New DevExpress.DataAccess.ConnectionParameters.MsSqlConnectionParameters()
        getParametrosReporte.AuthorizationType = DevExpress.DataAccess.ConnectionParameters.MsSqlAuthorizationType.SqlServer
        getParametrosReporte.DatabaseName = Con_cDatabase
        getParametrosReporte.Password = Con_cClave
        getParametrosReporte.ServerName = Con_cServer
        getParametrosReporte.UserName = Con_cUser
        Return getParametrosReporte
    End Function
    Function EscapeComilla(ByVal msData As Object) As String
        Return (Replace(msData, "'", "''"))
    End Function
    Public Function CheckInternet() As Boolean
        Try
            Using client = New WebClient()
                Using stream = client.OpenRead("http://www.google.com")
                    Return True
                End Using
            End Using
        Catch
            Return False
        End Try
    End Function
    Public Sub CopiarArchivo(ByVal fileOrigen As String, ByVal pathDestino As String)
        System.IO.File.Copy(fileOrigen, System.IO.Path.Combine(pathDestino, System.IO.Path.GetFileName(fileOrigen)), True)
        System.IO.File.SetLastWriteTime(System.IO.Path.Combine(pathDestino, System.IO.Path.GetFileName(fileOrigen)), Date.Now())
        'System.IO.File.Copy(
    End Sub
    Public Sub CopiarArchivo(ByVal fileOrigen As String, ByVal pathDestino As String, ByVal fileNameNew As String)
        System.IO.File.Copy(fileOrigen, System.IO.Path.Combine(pathDestino, System.IO.Path.GetFileName(fileNameNew)), True)
        System.IO.File.SetLastWriteTime(System.IO.Path.Combine(pathDestino, System.IO.Path.GetFileName(fileNameNew)), Date.Now())
        'System.IO.File.Copy(
    End Sub
    Public Function GetArchivoFullName(ByVal fileOrigen As String, ByVal pathDestino As String) As String
        Return System.IO.Path.Combine(pathDestino, System.IO.Path.GetFileName(fileOrigen))
    End Function
    Public Sub DeleteFile(ByVal mFile As String)
        If Len(Trim(mFile)) <= 0 Then
            Exit Sub
        End If
        If System.IO.File.Exists(mFile) Then
            System.IO.File.Delete(mFile)
        End If
    End Sub
    Public Sub VerCVGlobal(ByVal mDNI As String)
        Dim cPathFiles As String
        Dim Setting As New _AppConfig
        cPathFiles = Trim(Setting.ReadSetting("PathFiles"))
        Dim bEncontrado As Boolean = False
        Dim FileLocation As System.IO.DirectoryInfo = New System.IO.DirectoryInfo(cPathFiles & "\")

        Dim fi As List(Of System.IO.FileInfo) = New List(Of System.IO.FileInfo)

        For Each File In FileLocation.GetFiles("*.*", IO.SearchOption.AllDirectories)
            'MsgBox(File.FullName)
            'Exit For
            If (File IsNot Nothing) Then
                If (System.IO.Path.GetExtension(File.ToString.ToLower) = ".pdf") Then
                    'MsgBox(File.FullName)
                    If (File.ToString.ToLower.Contains(mDNI)) Then
                        'File.LastWriteTime = (Date.Now)
                        'pArchivoPDF = File.FullName
                        Process.Start(File.FullName)
                        bEncontrado = True
                        Exit For
                    End If
                End If
            End If
        Next
        If Not bEncontrado Then
            'DevExpress.XtraEditors.XtraMessageBox.Show("No existe archivo con DNI del Postulante.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If

    End Sub
    Public Sub VerCVExpediente(ByVal mDNI As String)
        Dim cPathFiles As String
        Dim Setting As New _AppConfig
        cPathFiles = "X:\"
        Dim bEncontrado As Boolean = False
        Dim FileLocation As System.IO.DirectoryInfo = New System.IO.DirectoryInfo(cPathFiles & "\")

        Dim fi As List(Of System.IO.FileInfo) = New List(Of System.IO.FileInfo)

        For Each File In FileLocation.GetFiles("*.*", IO.SearchOption.AllDirectories)
            'MsgBox(File.FullName)
            'Exit For
            If (File IsNot Nothing) Then
                If (System.IO.Path.GetExtension(File.ToString.ToLower) = ".pdf") Then
                    'MsgBox(File.FullName)
                    If (File.ToString.ToLower.Contains(mDNI)) Then
                        'File.LastWriteTime = (Date.Now)
                        'pArchivoPDF = File.FullName
                        Process.Start(File.FullName)
                        bEncontrado = True
                        Exit For
                    End If
                End If
            End If
        Next
        If Not bEncontrado Then
            'DevExpress.XtraEditors.XtraMessageBox.Show("No existe archivo con DNI del Postulante.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If

    End Sub
    Function F_CortarCadena(ByVal miStr As String, ByVal cSepara As String, ByVal iPos As Integer) As String
        F_CortarCadena = ""
        Dim miStrTemp() As String
        miStrTemp = miStr.Split(cSepara)
        F_CortarCadena = Trim(miStrTemp(iPos))
        Return F_CortarCadena
    End Function
    Public Function WebDNICloud(ByVal pDNI As String, ByVal pCUI As String) As String

        Dim cResultCon As String = ""
        Dim miConexion As New ConnectSQL
        Dim cResultOpe As String = "FAIL"
        Dim bWeb As New System.Net.WebClient
        Dim sourceString As String
        Dim cServerDNI As String
        Dim bEnableDNI As Boolean = True

        Dim cDNIResponse, cCUIResponse, cApelResponse, cApelPResponse, cApelMResponse, cNomResponse, JSONStringPersona As String
        Dim cSexo, cUbigeoNaci, cUbigeoResidencia, cFechaNacimiento, cEstCivil, cDireccion As String

        Try
            cCUIResponse = ""
            cDNIResponse = ""
            cApelResponse = ""
            cApelPResponse = ""
            cApelMResponse = ""
            cNomResponse = ""
            cSexo = ""
            cUbigeoNaci = ""
            cUbigeoResidencia = ""
            cFechaNacimiento = ""
            cEstCivil = ""
            cDireccion = ""

            bWeb.Encoding = System.Text.Encoding.UTF8

            cResultCon = miConexion.OpenConnection

            If cResultCon = "OK" Then 'ok   

                'CERRADO TEMPORALMENTE
                'Dim CRecordCONF As New Uconfig2
                'CRecordCONF.iCodUConfig2 = 1
                'CRecordCONF.getRecord()
                'cServerDNI = CRecordCONF.cValue1
                'bEnableDNI = CBool(CRecordCONF.cValue3)
                'CRecordCONF = Nothing
                cServerDNI = "apidniruc"

                If cServerDNI = "apidniruc" Then
                    System.Net.ServicePointManager.SecurityProtocol = 3072
                    sourceString = bWeb.DownloadString("https://api.dniruc.com/api/search/dni/" & Trim(pDNI.Replace("'", "''")) & "/5948982a-bace-4d82-a537-f9a986624a98")
                    Dim responseJSON As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(sourceString)
                    cCUIResponse = GetCUI(pDNI)
                    cApelResponse = Trim(CStr(responseJSON("data")("ap_paterno"))) & " " & Trim(CStr(responseJSON("data")("ap_materno")))
                    cApelPResponse = Trim(CStr(responseJSON("data")("ap_paterno")))
                    cApelMResponse = Trim(CStr(responseJSON("data")("ap_materno")))
                    cNomResponse = CStr(responseJSON("data")("nombres"))
                    cSexo = CStr(responseJSON("data")("sexo")).ToUpper()
                    cUbigeoNaci = CStr(responseJSON("data")("ubigeo_naci"))
                    cUbigeoResidencia = CStr(responseJSON("data")("ubigeo"))
                    cFechaNacimiento = CStr(responseJSON("data")("fecha_nacimiento"))
                    cEstCivil = CStr(responseJSON("data")("estadoCivil"))
                    cDireccion = CStr(responseJSON("data")("direccion"))

                    cSexo = cSexo.Chars(0) 'Devuelve primer caracter
                    cDireccion = cDireccion.Replace("'", "")
                    If String.IsNullOrWhiteSpace(cUbigeoResidencia) Then
                        cUbigeoResidencia = "000000"
                    End If

                End If

                JSONStringPersona = "{""success"":true,""dni"":""" & pDNI & """,""cui"":""" & cCUIResponse &
                                    """,""apellidos"":""" & cApelResponse & """,""cApelP"":""" & cApelPResponse & """,""cApelM"":""" & cApelMResponse & """,""nombres"":""" & cNomResponse &
                                    """,""sexo"":""" & cSexo & """,""ubigeoNaci"":""" & cUbigeoNaci & """,""ubigeoResidencia"":""" & cUbigeoResidencia &
                                    """,""fechaNacimiento"":""" & cFechaNacimiento & """,""estadoCivil"":""" & cEstCivil &
                                    """,""direccion"":""" & cDireccion & """}"

                cResultOpe = JSONStringPersona
                miConexion.CloseConnection()
                Return cResultOpe
            Else
                Throw New ApplicationException("FAIL : Error en la conexión con a BBDD.")
            End If
        Catch ex As Exception
            JSONStringPersona = "{""success"":false,""dni"":"""",""cui"":"""",""apellidos"":"""",""nombres"":""""}"

            cResultOpe = JSONStringPersona
            Return cResultOpe
        Finally
            miConexion = Nothing
            ConnectSQL.linkSQL.Dispose()
            cResultCon = Nothing
            cResultOpe = Nothing
            bWeb = Nothing
            JSONStringPersona = Nothing
            cCUIResponse = Nothing
            cDNIResponse = Nothing
            cApelResponse = Nothing
            cNomResponse = Nothing
            sourceString = Nothing
            cServerDNI = Nothing
            bEnableDNI = Nothing
        End Try

    End Function

    Public Function WebRUC(ByVal pRUC As String) As String
        Dim cResultOpe As String = "FAIL"
        Dim bWeb As New System.Net.WebClient
        Dim sourceString As String

        Dim cRUCResponse, cRazonSocialResponse, JSONStringEmpresa As String
        Try
            cRUCResponse = ""
            cRazonSocialResponse = ""
            bWeb.Encoding = System.Text.Encoding.UTF8

            System.Net.ServicePointManager.SecurityProtocol = 3072
            sourceString = bWeb.DownloadString("https://dniruc.apisperu.com/api/v1/ruc/" & Trim(pRUC.Replace("'", "''")) & "?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6ImdlbGJlcnQuZWRzb25AZ21haWwuY29tIn0.Uvh20PFU18U76AERcDUQUxqbqeD6hNFB6RGp1h0HHOU")
            Dim responseJSON As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(sourceString)
            cRazonSocialResponse = CStr(responseJSON("razonSocial"))

            If Len(cRazonSocialResponse.Trim) > 0 Then
                JSONStringEmpresa = "{""success"":true,""ruc"":""" & Trim(pRUC.Replace("'", "''")) & """,""razonsocial"":""" & cRazonSocialResponse & """}"
            Else
                JSONStringEmpresa = "{""success"":false,""ruc"":"""",""razonsocial"":""""}"
            End If

            cResultOpe = JSONStringEmpresa

            Return cResultOpe

        Catch ex As Exception
            JSONStringEmpresa = "{""success"":false,""ruc"":"""",""razonsocial"":""""}"

            cResultOpe = JSONStringEmpresa
            Return cResultOpe
        Finally

            cResultOpe = Nothing
            bWeb = Nothing
            JSONStringEmpresa = Nothing
            cRazonSocialResponse = Nothing
            cRUCResponse = Nothing
            sourceString = Nothing

        End Try
    End Function
    Public Function IsValidEmail(ByVal email As String) As Boolean
        email = Trim(email)
        If email = String.Empty Then Return False
        ' Compruebo si el formato de la dirección es correcto.
        Dim re As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("^[\w._%-]+@[\w.-]+\.[a-zA-Z]{2,4}$")
        Dim m As System.Text.RegularExpressions.Match = re.Match(email)
        Return (m.Captures.Count <> 0)
    End Function
  
    Public Function GetCUI(ByVal DNI As String)
        If Len(Trim(DNI)) <> 8 Then
            Return ""
        End If

        If Not IsNumeric(Trim(DNI)) Then
            Return ""
        End If

        Try
            Dim arreglo_dni() As Char = DNI.ToCharArray 'convirtiendo la cadena en vector
            'suma de los 8 primeros digitos del dni
            Dim _1 As Integer = Val(arreglo_dni(0)) * 3
            Dim _2 As Integer = Val(arreglo_dni(1)) * 2
            Dim _3 As Integer = Val(arreglo_dni(2)) * 7
            Dim _4 As Integer = Val(arreglo_dni(3)) * 6
            Dim _5 As Integer = Val(arreglo_dni(4)) * 5
            Dim _6 As Integer = Val(arreglo_dni(5)) * 4
            Dim _7 As Integer = Val(arreglo_dni(6)) * 3
            Dim _8 As Integer = Val(arreglo_dni(7)) * 2

            Dim _suma_dni As Integer = _1 + _2 + _3 + _4 + _5 + _6 + _7 + _8

            Dim _residuo As Integer = _suma_dni Mod 11 'residuo

            Dim _posicion As Integer = 11 - _residuo
            If _posicion = 11 Then
                _posicion = 0
            End If

            Dim _hash As String = "67890112345" 'hash reniec
            Dim _verificador() As Char = _hash.ToArray()


            _1 = Nothing
            _2 = Nothing
            _3 = Nothing
            _4 = Nothing
            _5 = Nothing
            _6 = Nothing
            _7 = Nothing
            _8 = Nothing
            _suma_dni = Nothing
            _hash = Nothing
            _residuo = Nothing
            arreglo_dni = Nothing

            Return _verificador(_posicion).ToString()

        Catch ex As Exception

            Return ""
        Finally
        End Try
    End Function
    Public Function GeneratePassword(longitud As Integer) As String
        Dim caracteres As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"
        Dim res As New StringBuilder()
        Dim rnd As New Random()
        While 0 < System.Math.Max(System.Threading.Interlocked.Decrement(longitud), longitud + 1)
            res.Append(caracteres(rnd.[Next](caracteres.Length)))
        End While
        Return res.ToString()
    End Function


    Public Function GeneradorPasswordDos(ByVal passedLength As Integer, ByVal bSimbolos As Boolean) As String

        'Dim myLowercase As String = "abcdefghijklmnopqrstuvwxyz"
        Dim myLowercase As String = "abcdefghijkmnopqrstuvwxyz"

        'Dim myUppercase As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        Dim myUppercase As String = "ABCDEFGHJKLMNPQRSTUVWXYZ"

        'Dim myNumbers As String = "0123456789"
        Dim myNumbers As String = "123456789"


        Dim mySymbols As String = ""

        If bSimbolos Then
            'mySymbols = "~!@#$^*()_-+={}[]:;<>,.?/"
            mySymbols = "~!@#$^*()_-+={}[]:;<>,./"
        End If


        Dim myAllChars As String = myLowercase & myUppercase & myNumbers & mySymbols

        Dim myRandom As New System.Random

        Dim myPassword As String = ""

        myPassword = myPassword & myLowercase(myRandom.Next(0, myLowercase.Length)) & myLowercase(myRandom.Next(0, myLowercase.Length))

        myPassword = myPassword & myUppercase(myRandom.Next(0, myUppercase.Length)) & myUppercase(myRandom.Next(0, myUppercase.Length))

        myPassword = myPassword & myNumbers(myRandom.Next(0, myNumbers.Length)) & myNumbers(myRandom.Next(0, myNumbers.Length))

        myPassword = myPassword & mySymbols(myRandom.Next(0, mySymbols.Length)) & mySymbols(myRandom.Next(0, mySymbols.Length))

        For i As Integer = 0 To (passedLength - 9)

            myPassword = myPassword & myAllChars(myRandom.Next(0, myAllChars.Length))

        Next

        Dim strInput As String = myPassword

        Dim strOutput As String = ""

        Dim rand As New System.Random

        Dim intPlace As Integer

        While strInput.Length > 0

            intPlace = rand.Next(0, strInput.Length)

            strOutput += strInput.Substring(intPlace, 1)

            strInput = strInput.Remove(intPlace, 1)

        End While

        myPassword = strOutput

        Return myPassword

    End Function
    Public Function EsValidaContrasenia(pContrasenia As String) As Boolean

        ' Si es Nothing no es válida.
        If (pContrasenia Is Nothing) Then Return False

        pContrasenia = pContrasenia.Replace(" ", "")
        ' Si su longitud es menor de 8 caracteres, no es válida.
        If (pContrasenia.Length < 8) Then Return False

        Dim existeNumero As Boolean
        Dim existeLetraMayuscula As Boolean

        ' Ya solo queda verificar si al menos hay
        ' un número y una letra en mayúscula.
        '
        For Each c As Char In pContrasenia

            If (Char.IsDigit(c)) Then
                existeNumero = True
                Continue For
            End If

            If (c = c.ToString().ToUpper()) Then
                existeLetraMayuscula = True
            End If
        Next

        Return ((existeNumero) And (existeLetraMayuscula))

    End Function
    Public Function GenerateCorreoAcortado(ByVal correo As String) As String
        Dim nuevo_correo As String = ""
        Dim delimitadores() As String = {"@"}
        Dim vector_correo_completo() As String
        vector_correo_completo = correo.Split(delimitadores, StringSplitOptions.None)
        'mostrar resultado

        Dim long_ini As Integer = vector_correo_completo(0).Length
        Dim long_fin As Integer = vector_correo_completo(0).Length

        If (long_ini > 5) Then ' estableciendo longitud
            long_ini = 2 'si el correo tiene mas de 5 caracteres
            long_fin -= 1
        Else
            long_ini = 1 'si el correo tiene menos de 5 caracteres
        End If

        For i As Integer = 1 To long_ini Step 1 'extraer la longitud de caracteres de inicio >>>
            nuevo_correo += Mid(vector_correo_completo(0), i, 1)
        Next
        nuevo_correo += "...."
        For i As Integer = 1 To long_ini Step 1 'extraer las 2 longitud de caracteres de fin <<<<
            nuevo_correo += Mid(vector_correo_completo(0), long_fin, 1)
            long_fin += 1
        Next
        nuevo_correo = nuevo_correo + "@" + vector_correo_completo(1) 'nuevo correo concatenado ge....23@gmail.com
        Return nuevo_correo
    End Function
    Public Function CambiarUrlToHref(ByVal text As String) As String
        Dim pattern As String
        pattern = "(https:\/\/([\w.]+\/?)\S*)"
        Dim re As Regex = New Regex(pattern, RegexOptions.IgnoreCase Or RegexOptions.Compiled)
        text = re.Replace(text, "<a href=""$1"" target=""_blank"">$1</a>")
        Return text
    End Function

    Public Function TokenGenerator() As String
        Dim random() As Byte = New Byte(100) {}
        'RNGCryptoServiceProvider is an implementation of an RNG
        Dim rng As New System.Security.Cryptography.RNGCryptoServiceProvider()
        rng.GetBytes(random) ' bytes in random are now random

        TokenGenerator = Convert.ToBase64String(random.ToArray())
        TokenGenerator = TokenGenerator.Replace("/", "").Replace("+", "").Replace("=", "")
        Return TokenGenerator
    End Function
    Public Function Encriptar(ByVal Input As String) As String

        Dim IV() As Byte = ASCIIEncoding.ASCII.GetBytes("#GTt84~^") 'La clave debe ser de 8 caracteres
        Dim EncryptionKey() As Byte = Convert.FromBase64String("rGtSPvIvVLlrc5tzPU9/c67GkjyyL1SQ") 'No se puede alterar la cantidad de caracteres pero si la clave
        Dim buffer() As Byte = Encoding.UTF8.GetBytes(Input)
        Dim des As System.Security.Cryptography.TripleDESCryptoServiceProvider = New System.Security.Cryptography.TripleDESCryptoServiceProvider
        des.Key = EncryptionKey
        des.IV = IV

        Return Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length()))

    End Function

    'FUNCION QUE RECIBE UNA CADENA ENCRIPTADA Y LA DESENCRIPTA
    Public Function Desencriptar(ByVal Input As String) As String

        Dim IV() As Byte = ASCIIEncoding.ASCII.GetBytes("#GTt84~^") 'La clave debe ser de 8 caracteres
        Dim EncryptionKey() As Byte = Convert.FromBase64String("rGtSPvIvVLlrc5tzPU9/c67GkjyyL1SQ") 'No se puede alterar la cantidad de caracteres pero si la clave
        Dim buffer() As Byte = Convert.FromBase64String(Input)
        Dim des As System.Security.Cryptography.TripleDESCryptoServiceProvider = New System.Security.Cryptography.TripleDESCryptoServiceProvider
        des.Key = EncryptionKey
        des.IV = IV
        Return Encoding.UTF8.GetString(des.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length()))

    End Function

#Region "SEGUNDO METODO DE CIFRADO"
    Public Function Encrypt(clearText As String) As String
        If clearText = "" Then
            Return ""
        End If

        Dim EncryptionKey As String = "GETT2SPBNI99212"
        Dim clearBytes As Byte() = Encoding.Unicode.GetBytes(clearText)
        Using encryptor As System.Security.Cryptography.Aes = System.Security.Cryptography.Aes.Create()
            Dim pdb As New System.Security.Cryptography.Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D, _
             &H65, &H64, &H76, &H65, &H64, &H65, _
             &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)
            Using ms As New System.IO.MemoryStream()
                Using cs As New System.Security.Cryptography.CryptoStream(ms, encryptor.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Write)
                    cs.Write(clearBytes, 0, clearBytes.Length)
                    cs.Close()
                End Using
                clearText = Convert.ToBase64String(ms.ToArray())
            End Using
        End Using
        Return clearText
    End Function
 

    Public Function Decrypt(cipherText As String) As String
        If cipherText = "" Then
            Return ""
        End If
        Dim EncryptionKey As String = "GETT2SPBNI99212"
        cipherText = cipherText.Replace(" ", "+")
        Dim cipherBytes As Byte() = Convert.FromBase64String(cipherText)
        Using encryptor As System.Security.Cryptography.Aes = System.Security.Cryptography.Aes.Create()
            Dim pdb As New System.Security.Cryptography.Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D, _
             &H65, &H64, &H76, &H65, &H64, &H65, _
             &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)
            Using ms As New System.IO.MemoryStream()
                Using cs As New System.Security.Cryptography.CryptoStream(ms, encryptor.CreateDecryptor(), System.Security.Cryptography.CryptoStreamMode.Write)
                    cs.Write(cipherBytes, 0, cipherBytes.Length)
                    cs.Close()
                End Using
                cipherText = Encoding.Unicode.GetString(ms.ToArray())
            End Using
        End Using
        Return cipherText
    End Function
#End Region

#Region "CIFRADO UNICODE"
    Public Function Cifrar(clearText As String) As String
        '*******************************************************************************
        'MODO DE USO EN CLIENTE
        ' HttpUtility.UrlEncode(Cifrar(Variable))
        '*******************************************************************************
        Dim EncryptionKey As String = "GETT2SPBNI81674"
        Dim clearBytes As Byte() = Encoding.Unicode.GetBytes(clearText)
        Using encryptor As System.Security.Cryptography.Aes = System.Security.Cryptography.Aes.Create()
            Dim pdb As New System.Security.Cryptography.Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D,
             &H65, &H64, &H76, &H65, &H64, &H65,
             &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)
            Using ms As New System.IO.MemoryStream()
                Using cs As New System.Security.Cryptography.CryptoStream(ms, encryptor.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Write)
                    cs.Write(clearBytes, 0, clearBytes.Length)
                    cs.Close()
                End Using
                clearText = Convert.ToBase64String(ms.ToArray())
            End Using
        End Using
        Return clearText
    End Function
    Public Function Descifrar(cipherText As String) As String
        '*******************************************************************************
        'MODO DE USO EN CLIENTE
        'Descifrar(HttpUtility.UrlDecode(Request.QueryString("nombre_parametro")))
        '*******************************************************************************
        Dim EncryptionKey As String = "GETT2SPBNI81674"
        cipherText = cipherText.Replace(" ", "+")
        Dim cipherBytes As Byte() = Convert.FromBase64String(cipherText)
        Using encryptor As System.Security.Cryptography.Aes = System.Security.Cryptography.Aes.Create()
            Dim pdb As New System.Security.Cryptography.Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D,
             &H65, &H64, &H76, &H65, &H64, &H65,
             &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)
            Using ms As New System.IO.MemoryStream()
                Using cs As New System.Security.Cryptography.CryptoStream(ms, encryptor.CreateDecryptor(), System.Security.Cryptography.CryptoStreamMode.Write)
                    cs.Write(cipherBytes, 0, cipherBytes.Length)
                    cs.Close()
                End Using
                cipherText = Encoding.Unicode.GetString(ms.ToArray())
            End Using
        End Using
        Return cipherText
    End Function
#End Region
End Module
