Module ParametrosGlobales

    '=========================================================
    'PARAMETROS DEL APP MAIN
    'Public Sis_iCodUsuario As Integer
    'Public Sis_iCodPersonaLogin As Integer
    'Public sis_iCodPersonaEmpresa As Integer = 6
    'Public Sis_cNickUsuario As String
    'Public Sis_iTipoUsuario As Integer
    'Public Sis_iPeriodo As Integer
    'Public Sis_iMes As Integer
    'Public Sis_iCodAlmacen As Integer = 1
    'Public Sis_iCodLugar As Integer = 1
    Public Sis_bBBDDCustom As Boolean = True 'true=configurar   false=localhost
    'Public Sis_dFecha As Date = Date.Now
    'PARAMETROS DEL NEGOCIO
    'Public Sis_iCodUbigeoEmpresa = 1476
    'Public Sis_iCodPersonaCliente = 0
    'Public Sis_iCodContrata As Integer
    'PARAMETROS CONFIG CONNECT
    Public Con_cServer As String
    Public Con_cDatabase As String
    Public Con_cUser As String
    Public Con_cClave As String
    Public Function EstablecerParametrosGlobales() As Boolean
        If Sis_bBBDDCustom Then 'parametro personalizado

            Dim Setting As New _AppConfig
            'Dim Encripta As New _Encripta
            Con_cServer = Setting.ReadSetting("Server")
            Con_cDatabase = Setting.ReadSetting("Database")
            Con_cUser = (Setting.ReadSetting("User"))
            Con_cClave = Setting.ReadSetting("Clave")

        Else 'parametro del usuario

            'Con_cServer = "200.60.145.130"
            'Con_cDatabase = "GTManpowerLocal"
            'Con_cUser = "APPQUELLAVECO"
            'Con_cClave = "Gelbert2019."

     
            'MsgBox(Con_cServer)76517042
        End If

        Dim cc As New ConnectSQL
        'cc = New ConnectSQL(Con_cServer, Con_cUser, Con_cClave, Con_cDatabase)
        If cc.isConnect Then 'ok
            'Sis_iPeriodo = Year(Now)
            'Sis_iMes = Month(Now)
            'Sis_iCodUsuario = 1
            'Sis_iCodPersonaLogin = 1
            Return True
        Else 'fallo           
            Return False
        End If
        cc = Nothing
    End Function
End Module
