Imports System.Data.SqlClient
Imports System.Net
Imports System.Net.Mail

Public Class Correoenvio
    Public iCodCorreoEnvio As String
    Public iCodCandidatoAdmision As String
    Public iCodCandidatoInforme As String
    Public cNickCreacion As String
    Public cPlantilla As String
    Public cTitulo As String
    Public cMensaje As String
    Public cNombreClienteRemitente As String
    Public cCorreoRemitente As String
    Public cKeyRemitente As String
    Public cCorreoDestino As String
    Public cCorreoCopia As String
    Public bEnviado As String
    Public dFechaEnvio As String
    Public iCodUsuarioEnvio As String
    Public bReenviado As String
    Public cNombres As String
    Public cUsuario As String
    Public cClave As String
    Public cFechaFinBloqueo As String
    Public cFechaFinObservado As String
    Public cNomContrata As String
    Public cUrlDrive As String
    Public iCodUsuarioCreacion As String
    Public dFechaCreacion As String
    Public iCodUsuarioModificacion As String
    Public dFechaModificacion As String
    Public qSelect As String
    Public cTipoOpe As Char
    Public bTransaccion As Boolean = False
    Public mc As New ConnectSQL
    Public Function ListaDatos() As DataTable
        Dim Query As String
        Dim readers As DataTable
        Query = "SELECT * FROM dbo.CorreoEnvio"
        readers = mc.ExecuteDataTable(Query)
        Return readers
    End Function
    Public Sub Insertar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "INSERT into dbo.CorreoEnvio (iCodCandidatoAdmision,iCodCandidatoInforme,cNickCreacion,cPlantilla,cTitulo,cMensaje,cNombreClienteRemitente,cCorreoRemitente,cKeyRemitente,cCorreoDestino,cCorreoCopia,bEnviado,dFechaEnvio,iCodUsuarioEnvio,bReenviado,cNombres,cUsuario,cClave,cFechaFinBloqueo,cFechaFinObservado,cNomContrata,cUrlDrive,iCodUsuarioCreacion,dFechaCreacion,iCodUsuarioModificacion,dFechaModificacion ) VALUES(@iCodCandidatoAdmision,@iCodCandidatoInforme,@cNickCreacion,@cPlantilla,@cTitulo,@cMensaje,@cNombreClienteRemitente,@cCorreoRemitente,@cKeyRemitente,@cCorreoDestino,@cCorreoCopia,@bEnviado,@dFechaEnvio,@iCodUsuarioEnvio,@bReenviado,@cNombres,@cUsuario,@cClave,@cFechaFinBloqueo,@cFechaFinObservado,@cNomContrata,@cUrlDrive,@iCodUsuarioCreacion,@dFechaCreacion,@iCodUsuarioModificacion,@dFechaModificacion); SELECT SCOPE_IDENTITY(); "
        cmdSQL.Parameters.Add("@iCodCandidatoAdmision", SqlDbType.Int).Value = Me.iCodCandidatoAdmision
        cmdSQL.Parameters.Add("@iCodCandidatoInforme", SqlDbType.Int).Value = Me.iCodCandidatoInforme
        cmdSQL.Parameters.Add("@cNickCreacion", SqlDbType.Nvarchar, 100).Value = Me.cNickCreacion
        cmdSQL.Parameters.Add("@cPlantilla", SqlDbType.Nvarchar, 200).Value = Me.cPlantilla
        cmdSQL.Parameters.Add("@cTitulo", SqlDbType.Nvarchar, 400).Value = Me.cTitulo
        cmdSQL.Parameters.Add("@cMensaje", SqlDbType.Nvarchar, -1).Value = Me.cMensaje
        cmdSQL.Parameters.Add("@cNombreClienteRemitente", SqlDbType.Varchar, 100).Value = Me.cNombreClienteRemitente
        cmdSQL.Parameters.Add("@cCorreoRemitente", SqlDbType.Nvarchar, 200).Value = Me.cCorreoRemitente
        cmdSQL.Parameters.Add("@cKeyRemitente", SqlDbType.VarChar, 300).Value = Me.cKeyRemitente
        cmdSQL.Parameters.Add("@cCorreoDestino", SqlDbType.Nvarchar, 200).Value = Me.cCorreoDestino
        cmdSQL.Parameters.Add("@cCorreoCopia", SqlDbType.Nvarchar, 200).Value = Me.cCorreoCopia
        cmdSQL.Parameters.Add("@bEnviado", SqlDbType.Bit).Value = Me.bEnviado
        cmdSQL.Parameters.Add("@dFechaEnvio", SqlDbType.Datetime).Value = Me.dFechaEnvio
        cmdSQL.Parameters.Add("@iCodUsuarioEnvio", SqlDbType.Int).Value = Me.iCodUsuarioEnvio
        cmdSQL.Parameters.Add("@bReenviado", SqlDbType.Bit).Value = Me.bReenviado
        cmdSQL.Parameters.Add("@cNombres", SqlDbType.Nvarchar, 400).Value = Me.cNombres
        cmdSQL.Parameters.Add("@cUsuario", SqlDbType.Nvarchar, 100).Value = Me.cUsuario
        cmdSQL.Parameters.Add("@cClave", SqlDbType.Nvarchar, 200).Value = Me.cClave
        cmdSQL.Parameters.Add("@cFechaFinBloqueo", SqlDbType.Varchar, 50).Value = Me.cFechaFinBloqueo
        cmdSQL.Parameters.Add("@cFechaFinObservado", SqlDbType.Varchar, 50).Value = Me.cFechaFinObservado
        cmdSQL.Parameters.Add("@cNomContrata", SqlDbType.Nvarchar, 400).Value = Me.cNomContrata
        cmdSQL.Parameters.Add("@cUrlDrive", SqlDbType.Nvarchar, 1000).Value = Me.cUrlDrive
        cmdSQL.Parameters.Add("@iCodUsuarioCreacion", SqlDbType.Int).Value = Me.iCodUsuarioCreacion
        cmdSQL.Parameters.Add("@dFechaCreacion", SqlDbType.Datetime).Value = Me.dFechaCreacion
        cmdSQL.Parameters.Add("@iCodUsuarioModificacion", SqlDbType.Int).Value = Me.iCodUsuarioModificacion
        cmdSQL.Parameters.Add("@dFechaModificacion", SqlDbType.Datetime).Value = Me.dFechaModificacion

        Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
        If pCodInsert > 0 Then
            Me.iCodCorreoEnvio = pCodInsert
        Else
            Me.iCodCorreoEnvio = 0
        End If
    End Sub
    Public Sub InsertarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "INSERT into dbo.CorreoEnvio (iCodCandidatoAdmision,iCodCandidatoInforme,cNickCreacion,cPlantilla,cTitulo,cMensaje,cNombreClienteRemitente,cCorreoRemitente,cKeyRemitente,cCorreoDestino,cCorreoCopia,bEnviado,dFechaEnvio,iCodUsuarioEnvio,bReenviado,cNombres,cUsuario,cClave,cFechaFinBloqueo,cFechaFinObservado,cNomContrata,cUrlDrive,iCodUsuarioCreacion,dFechaCreacion,iCodUsuarioModificacion,dFechaModificacion ) VALUES(@iCodCandidatoAdmision,@iCodCandidatoInforme,@cNickCreacion,@cPlantilla,@cTitulo,@cMensaje,@cNombreClienteRemitente,@cCorreoRemitente,@cKeyRemitente,@cCorreoDestino,@cCorreoCopia,@bEnviado,@dFechaEnvio,@iCodUsuarioEnvio,@bReenviado,@cNombres,@cUsuario,@cClave,@cFechaFinBloqueo,@cFechaFinObservado,@cNomContrata,@cUrlDrive,@iCodUsuarioCreacion,@dFechaCreacion,@iCodUsuarioModificacion,@dFechaModificacion); SELECT SCOPE_IDENTITY(); "
        cmdSQL.Parameters.Add("@iCodCandidatoAdmision", SqlDbType.Int).Value = Me.iCodCandidatoAdmision
        cmdSQL.Parameters.Add("@iCodCandidatoInforme", SqlDbType.Int).Value = Me.iCodCandidatoInforme
        cmdSQL.Parameters.Add("@cNickCreacion", SqlDbType.Nvarchar, 100).Value = Me.cNickCreacion
        cmdSQL.Parameters.Add("@cPlantilla", SqlDbType.Nvarchar, 200).Value = Me.cPlantilla
        cmdSQL.Parameters.Add("@cTitulo", SqlDbType.Nvarchar, 400).Value = Me.cTitulo
        cmdSQL.Parameters.Add("@cMensaje", SqlDbType.Nvarchar, -1).Value = Me.cMensaje
        cmdSQL.Parameters.Add("@cNombreClienteRemitente", SqlDbType.Varchar, 100).Value = Me.cNombreClienteRemitente
        cmdSQL.Parameters.Add("@cCorreoRemitente", SqlDbType.Nvarchar, 200).Value = Me.cCorreoRemitente
        cmdSQL.Parameters.Add("@cKeyRemitente", SqlDbType.VarChar, 300).Value = Me.cKeyRemitente
        cmdSQL.Parameters.Add("@cCorreoDestino", SqlDbType.Nvarchar, 200).Value = Me.cCorreoDestino
        cmdSQL.Parameters.Add("@cCorreoCopia", SqlDbType.Nvarchar, 200).Value = Me.cCorreoCopia
        cmdSQL.Parameters.Add("@bEnviado", SqlDbType.Bit).Value = Me.bEnviado
        cmdSQL.Parameters.Add("@dFechaEnvio", SqlDbType.Datetime).Value = Me.dFechaEnvio
        cmdSQL.Parameters.Add("@iCodUsuarioEnvio", SqlDbType.Int).Value = Me.iCodUsuarioEnvio
        cmdSQL.Parameters.Add("@bReenviado", SqlDbType.Bit).Value = Me.bReenviado
        cmdSQL.Parameters.Add("@cNombres", SqlDbType.Nvarchar, 400).Value = Me.cNombres
        cmdSQL.Parameters.Add("@cUsuario", SqlDbType.Nvarchar, 100).Value = Me.cUsuario
        cmdSQL.Parameters.Add("@cClave", SqlDbType.Nvarchar, 200).Value = Me.cClave
        cmdSQL.Parameters.Add("@cFechaFinBloqueo", SqlDbType.Varchar, 50).Value = Me.cFechaFinBloqueo
        cmdSQL.Parameters.Add("@cFechaFinObservado", SqlDbType.Varchar, 50).Value = Me.cFechaFinObservado
        cmdSQL.Parameters.Add("@cNomContrata", SqlDbType.Nvarchar, 400).Value = Me.cNomContrata
        cmdSQL.Parameters.Add("@cUrlDrive", SqlDbType.Nvarchar, 1000).Value = Me.cUrlDrive
        cmdSQL.Parameters.Add("@iCodUsuarioCreacion", SqlDbType.Int).Value = Me.iCodUsuarioCreacion
        cmdSQL.Parameters.Add("@dFechaCreacion", SqlDbType.Datetime).Value = Me.dFechaCreacion
        cmdSQL.Parameters.Add("@iCodUsuarioModificacion", SqlDbType.Int).Value = Me.iCodUsuarioModificacion
        cmdSQL.Parameters.Add("@dFechaModificacion", SqlDbType.Datetime).Value = Me.dFechaModificacion

        Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
        If pCodInsert > 0 Then
            Me.iCodCorreoEnvio = pCodInsert
        Else
            Me.iCodCorreoEnvio = 0
        End If
    End Sub
    Public Sub Modificar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "UPDATE  dbo.CorreoEnvio SET iCodCandidatoAdmision=@iCodCandidatoAdmision,iCodCandidatoInforme=@iCodCandidatoInforme,cNickCreacion=@cNickCreacion,cPlantilla=@cPlantilla,cTitulo=@cTitulo,cMensaje=@cMensaje,cNombreClienteRemitente=@cNombreClienteRemitente,cCorreoRemitente=@cCorreoRemitente,cKeyRemitente=@cKeyRemitente,cCorreoDestino=@cCorreoDestino,cCorreoCopia=@cCorreoCopia,bEnviado=@bEnviado,dFechaEnvio=@dFechaEnvio,iCodUsuarioEnvio=@iCodUsuarioEnvio,bReenviado=@bReenviado,cNombres=@cNombres,cUsuario=@cUsuario,cClave=@cClave,cFechaFinBloqueo=@cFechaFinBloqueo,cFechaFinObservado=@cFechaFinObservado,cNomContrata=@cNomContrata,cUrlDrive=@cUrlDrive,iCodUsuarioCreacion=@iCodUsuarioCreacion,dFechaCreacion=@dFechaCreacion,iCodUsuarioModificacion=@iCodUsuarioModificacion,dFechaModificacion=@dFechaModificacion WHERE iCodCorreoEnvio=@iCodCorreoEnvio"
        cmdSQL.Parameters.Add("@iCodCorreoEnvio", SqlDbType.Int).Value = Me.iCodCorreoEnvio
        cmdSQL.Parameters.Add("@iCodCandidatoAdmision", SqlDbType.Int).Value = Me.iCodCandidatoAdmision
        cmdSQL.Parameters.Add("@iCodCandidatoInforme", SqlDbType.Int).Value = Me.iCodCandidatoInforme
        cmdSQL.Parameters.Add("@cNickCreacion", SqlDbType.Nvarchar, 100).Value = Me.cNickCreacion
        cmdSQL.Parameters.Add("@cPlantilla", SqlDbType.Nvarchar, 200).Value = Me.cPlantilla
        cmdSQL.Parameters.Add("@cTitulo", SqlDbType.Nvarchar, 400).Value = Me.cTitulo
        cmdSQL.Parameters.Add("@cMensaje", SqlDbType.Nvarchar, -1).Value = Me.cMensaje
        cmdSQL.Parameters.Add("@cNombreClienteRemitente", SqlDbType.Varchar, 100).Value = Me.cNombreClienteRemitente
        cmdSQL.Parameters.Add("@cCorreoRemitente", SqlDbType.Nvarchar, 200).Value = Me.cCorreoRemitente
        cmdSQL.Parameters.Add("@cKeyRemitente", SqlDbType.VarChar, 300).Value = Me.cKeyRemitente
        cmdSQL.Parameters.Add("@cCorreoDestino", SqlDbType.Nvarchar, 200).Value = Me.cCorreoDestino
        cmdSQL.Parameters.Add("@cCorreoCopia", SqlDbType.Nvarchar, 200).Value = Me.cCorreoCopia
        cmdSQL.Parameters.Add("@bEnviado", SqlDbType.Bit).Value = Me.bEnviado
        cmdSQL.Parameters.Add("@dFechaEnvio", SqlDbType.Datetime).Value = Me.dFechaEnvio
        cmdSQL.Parameters.Add("@iCodUsuarioEnvio", SqlDbType.Int).Value = Me.iCodUsuarioEnvio
        cmdSQL.Parameters.Add("@bReenviado", SqlDbType.Bit).Value = Me.bReenviado
        cmdSQL.Parameters.Add("@cNombres", SqlDbType.Nvarchar, 400).Value = Me.cNombres
        cmdSQL.Parameters.Add("@cUsuario", SqlDbType.Nvarchar, 100).Value = Me.cUsuario
        cmdSQL.Parameters.Add("@cClave", SqlDbType.Nvarchar, 200).Value = Me.cClave
        cmdSQL.Parameters.Add("@cFechaFinBloqueo", SqlDbType.Varchar, 50).Value = Me.cFechaFinBloqueo
        cmdSQL.Parameters.Add("@cFechaFinObservado", SqlDbType.Varchar, 50).Value = Me.cFechaFinObservado
        cmdSQL.Parameters.Add("@cNomContrata", SqlDbType.Nvarchar, 400).Value = Me.cNomContrata
        cmdSQL.Parameters.Add("@cUrlDrive", SqlDbType.Nvarchar, 1000).Value = Me.cUrlDrive
        cmdSQL.Parameters.Add("@iCodUsuarioCreacion", SqlDbType.Int).Value = Me.iCodUsuarioCreacion
        cmdSQL.Parameters.Add("@dFechaCreacion", SqlDbType.Datetime).Value = Me.dFechaCreacion
        cmdSQL.Parameters.Add("@iCodUsuarioModificacion", SqlDbType.Int).Value = Me.iCodUsuarioModificacion
        cmdSQL.Parameters.Add("@dFechaModificacion", SqlDbType.Datetime).Value = Me.dFechaModificacion

        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub ModificarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "UPDATE  dbo.CorreoEnvio SET iCodCandidatoAdmision=@iCodCandidatoAdmision,iCodCandidatoInforme=@iCodCandidatoInforme,cNickCreacion=@cNickCreacion,cPlantilla=@cPlantilla,cTitulo=@cTitulo,cMensaje=@cMensaje,cNombreClienteRemitente=@cNombreClienteRemitente,cCorreoRemitente=@cCorreoRemitente,cKeyRemitente=@cKeyRemitente,cCorreoDestino=@cCorreoDestino,cCorreoCopia=@cCorreoCopia,bEnviado=@bEnviado,dFechaEnvio=@dFechaEnvio,iCodUsuarioEnvio=@iCodUsuarioEnvio,bReenviado=@bReenviado,cNombres=@cNombres,cUsuario=@cUsuario,cClave=@cClave,cFechaFinBloqueo=@cFechaFinBloqueo,cFechaFinObservado=@cFechaFinObservado,cNomContrata=@cNomContrata,cUrlDrive=@cUrlDrive,iCodUsuarioCreacion=@iCodUsuarioCreacion,dFechaCreacion=@dFechaCreacion,iCodUsuarioModificacion=@iCodUsuarioModificacion,dFechaModificacion=@dFechaModificacion WHERE iCodCorreoEnvio=@iCodCorreoEnvio"
        cmdSQL.Parameters.Add("@iCodCorreoEnvio", SqlDbType.Int).Value = Me.iCodCorreoEnvio
        cmdSQL.Parameters.Add("@iCodCandidatoAdmision", SqlDbType.Int).Value = Me.iCodCandidatoAdmision
        cmdSQL.Parameters.Add("@iCodCandidatoInforme", SqlDbType.Int).Value = Me.iCodCandidatoInforme
        cmdSQL.Parameters.Add("@cNickCreacion", SqlDbType.Nvarchar, 100).Value = Me.cNickCreacion
        cmdSQL.Parameters.Add("@cPlantilla", SqlDbType.Nvarchar, 200).Value = Me.cPlantilla
        cmdSQL.Parameters.Add("@cTitulo", SqlDbType.Nvarchar, 400).Value = Me.cTitulo
        cmdSQL.Parameters.Add("@cMensaje", SqlDbType.Nvarchar, -1).Value = Me.cMensaje
        cmdSQL.Parameters.Add("@cNombreClienteRemitente", SqlDbType.Varchar, 100).Value = Me.cNombreClienteRemitente
        cmdSQL.Parameters.Add("@cCorreoRemitente", SqlDbType.Nvarchar, 200).Value = Me.cCorreoRemitente
        cmdSQL.Parameters.Add("@cKeyRemitente", SqlDbType.VarChar, 300).Value = Me.cKeyRemitente
        cmdSQL.Parameters.Add("@cCorreoDestino", SqlDbType.Nvarchar, 200).Value = Me.cCorreoDestino
        cmdSQL.Parameters.Add("@cCorreoCopia", SqlDbType.Nvarchar, 200).Value = Me.cCorreoCopia
        cmdSQL.Parameters.Add("@bEnviado", SqlDbType.Bit).Value = Me.bEnviado
        cmdSQL.Parameters.Add("@dFechaEnvio", SqlDbType.Datetime).Value = Me.dFechaEnvio
        cmdSQL.Parameters.Add("@iCodUsuarioEnvio", SqlDbType.Int).Value = Me.iCodUsuarioEnvio
        cmdSQL.Parameters.Add("@bReenviado", SqlDbType.Bit).Value = Me.bReenviado
        cmdSQL.Parameters.Add("@cNombres", SqlDbType.Nvarchar, 400).Value = Me.cNombres
        cmdSQL.Parameters.Add("@cUsuario", SqlDbType.Nvarchar, 100).Value = Me.cUsuario
        cmdSQL.Parameters.Add("@cClave", SqlDbType.Nvarchar, 200).Value = Me.cClave
        cmdSQL.Parameters.Add("@cFechaFinBloqueo", SqlDbType.Varchar, 50).Value = Me.cFechaFinBloqueo
        cmdSQL.Parameters.Add("@cFechaFinObservado", SqlDbType.Varchar, 50).Value = Me.cFechaFinObservado
        cmdSQL.Parameters.Add("@cNomContrata", SqlDbType.Nvarchar, 400).Value = Me.cNomContrata
        cmdSQL.Parameters.Add("@cUrlDrive", SqlDbType.Nvarchar, 1000).Value = Me.cUrlDrive
        cmdSQL.Parameters.Add("@iCodUsuarioCreacion", SqlDbType.Int).Value = Me.iCodUsuarioCreacion
        cmdSQL.Parameters.Add("@dFechaCreacion", SqlDbType.Datetime).Value = Me.dFechaCreacion
        cmdSQL.Parameters.Add("@iCodUsuarioModificacion", SqlDbType.Int).Value = Me.iCodUsuarioModificacion
        cmdSQL.Parameters.Add("@dFechaModificacion", SqlDbType.Datetime).Value = Me.dFechaModificacion

        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub Eliminar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "DELETE from  dbo.CorreoEnvio  WHERE iCodCorreoEnvio=@iCodCorreoEnvio"
        'cmdSQL.CommandText = "UPDATE dbo.CorreoEnvio  SET bAnulado=1 WHERE  iCodCorreoEnvio=@iCodCorreoEnvio"
        cmdSQL.Parameters.Add("@iCodCorreoEnvio", SqlDbType.Int).Value = Me.iCodCorreoEnvio
        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub EliminarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "DELETE from  dbo.CorreoEnvio  WHERE iCodCorreoEnvio=@iCodCorreoEnvio"
        'cmdSQL.CommandText = "UPDATE dbo.CorreoEnvio  SET bAnulado=1 WHERE  iCodCorreoEnvio=@iCodCorreoEnvio"
        cmdSQL.Parameters.Add("@iCodCorreoEnvio", SqlDbType.Int).Value = Me.iCodCorreoEnvio
        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub getRecord()
        Dim readers As IDataReader
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL

        If bTransaccion = True Then cmdSQL.Transaction = Me.mc.miTransact Else 

        cmdSQL.CommandText = "SELECT * FROM dbo.CorreoEnvio WHERE iCodCorreoEnvio=@iCodCorreoEnvio"
        cmdSQL.Parameters.Add("@iCodCorreoEnvio", SqlDbType.Int).Value = Me.iCodCorreoEnvio
        readers = cmdSQL.ExecuteReader
        If readers.Read() Then
            Me.iCodCorreoEnvio = CStr(readers.GetValue(0))
            Me.iCodCandidatoAdmision = CStr(readers.GetValue(1))
            Me.iCodCandidatoInforme = CStr(readers.GetValue(2))
            Me.cNickCreacion = CStr(readers.GetValue(3))
            Me.cPlantilla = CStr(readers.GetValue(4))
            Me.cTitulo = CStr(readers.GetValue(5))
            Me.cMensaje = CStr(readers.GetValue(6))
            Me.cNombreClienteRemitente = CStr(readers.GetValue(7))
            Me.cCorreoRemitente = CStr(readers.GetValue(8))
            Me.cKeyRemitente = CStr(readers.GetValue(9))
            Me.cCorreoDestino = CStr(readers.GetValue(10))
            Me.cCorreoCopia = CStr(readers.GetValue(11))
            Me.bEnviado = CStr(readers.GetValue(12))
            Me.dFechaEnvio = CStr(readers.GetValue(13))
            Me.iCodUsuarioEnvio = CStr(readers.GetValue(14))
            Me.bReenviado = CStr(readers.GetValue(15))
            Me.cNombres = CStr(readers.GetValue(16))
            Me.cUsuario = CStr(readers.GetValue(17))
            Me.cClave = CStr(readers.GetValue(18))
            Me.cFechaFinBloqueo = CStr(readers.GetValue(19))
            Me.cFechaFinObservado = CStr(readers.GetValue(20))
            Me.cNomContrata = CStr(readers.GetValue(21))
            Me.cUrlDrive = CStr(readers.GetValue(22))
            Me.iCodUsuarioCreacion = CStr(readers.GetValue(23))
            Me.dFechaCreacion = CStr(readers.GetValue(24))
            Me.iCodUsuarioModificacion = CStr(readers.GetValue(25))
            Me.dFechaModificacion = CStr(readers.GetValue(26))
        End If
        readers.Close()
    End Sub
    Public Function ListaDatosCombo() As DataTable
        Dim miDataTable As New DataTable
        Dim readers As IDataReader
        miDataTable.Columns.Add("ValueMember")
        miDataTable.Columns.Add("DisplayMember")
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "SELECT * FROM dbo.CorreoEnvio"
        readers = cmdSQL.ExecuteReader
        While readers.Read()
            miDataTable.Rows.Add(CStr(readers.GetValue(0)), CStr(readers.GetValue(1)))
        End While
        readers.Close()
        Return miDataTable
    End Function
    Public Function LastID() As Integer
        Const query As String = "SELECT SCOPE_IDENTITY()"
        Return mc.ExecuteScalar(query)
    End Function
    Public Function LastIDT() As Integer
        Const query As String = "SELECT SCOPE_IDENTITY()"
        Return mc.ExecuteScalarTransact(query)
    End Function
    '********************************************************************************
    Public Function ListaCorreos() As DataTable
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = "SP_DT_CorreoEnvioLista"

 

        Dim readers As SqlDataReader
        readers = cmdSQL.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(readers)
        Return dt
    End Function
    Public Function ListaCorreosPendientes() As DataTable
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = "SP_DT_CorreoEnvioListaPendientes"



        Dim readers As SqlDataReader
        readers = cmdSQL.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(readers)
        Return dt
    End Function
    Public Function EnviarCorreoSeleccionado() As Boolean

        Dim correos As New MailMessage
        'correos.From = New MailAddress("oael@manpowerperu.pe", "OAEL - AAQ")
        correos.From = New MailAddress("karemperaltavenegas@gmail.com", "KPV")
        correos.To.Add(Trim("karem.peralta@manpowergroup.pe"))

        Select Case Me.cPlantilla
            Case "PLANTILLA_INGRESO_NUEVO"
                correos.Subject = ("INGRESO NUEVO - Plataforma OAEL - Oficina de Apoyo al Empleo Local - Quellaveco")
                correos.Body += "<style> .sourcesans-font{ font-family: sans-serif; } </style> <table style='width: 90%;color:#4e4e4e;' align='center'> <tr > <td> <table style='width: 100%;color:#eeeeee;background-color:#447296;border-radius:5px;padding: 18px 10px 18px 10px;height: auto; margin-top: 10px;'> <tr> <td width='50%'></td> <td width='50%' align='right' ><img style='display:inline-block;position: relative;right: 0;width: 180px;padding-right:4px;' src='https://mipostulacion.pe/images/logo-footer.png' width='180px'></td> </tr> </table> </td> </tr> <tr> <td> <p class='sourcesans-font' style='margin-top: 50px; margin-bottom: 8px;margin-left: 10px; margin-right: 10px;color:#4e4e4e;'>Estimado/a :</p> <p class='sourcesans-font' style='margin-top: 20px; margin-bottom: 4px;margin-left: 10px; margin-right: 10px;color:#4e4e4e;'> {cNomContrata}</p> <p class='sourcesans-font' style='margin-top: 0px; margin-left: 10px; margin-right: 10px;font-size: 1.6em;font-weight: bold; color: #525F77;'>{cNomCompleto}</p> </td> </tr> <tr> <td> <p class='sourcesans-font' style='margin-left: 10px; margin-right: 10px;padding-bottom: 8px; margin-top: 10px; font-size: 1.04em;color:#4e4e4e;'>Mediante la presente se confirma la cuenta de acceso a la plataforma web de la OAEL, puede ingresar mediante el siguiente enlace <a href='https://mipostulacion.pe/siel/webcandidato/LoginCandidato.aspx' style='font-weight: bold;color:#7a6f31;text-decoration:none;' target='_blank'><u>Acceder a la Plataforma del Candidato</u></a>. </p> <p class='sourcesans-font' style='margin-left: 10px; margin-right: 10px;padding-bottom: 8px; font-size: 1.04em;color:#4e4e4e;'> <b>Usuario :</b> {cUsuario} <br> <b>Clave :</b> {cClave} </p> </td> </tr> <tr><td>&nbsp;</td></tr> <tr> <td> <div style='border-radius: 8px; margin-top: 20px;margin-left: 10px; margin-right: 10px;background-color: #f5f4f0;padding: 12px 12px 20px 12px;font-size: 0.95em;'> <p class='sourcesans-font' style='padding:4px 20px 8px 20px;'> <strong>MATERIAL DE AYUDA : </strong> Adjuntamos enlaces web de material de soporte para la gestión de la plataforma, haga clic en los íconos para acceder al contenido. </p> <table> <tr> <td width='25%' align='center'> <a href='{cUrlOneDrive}' style='text-decoration:none;' target='_blank'> <img style='display:block; margin: 0 auto; width: 64px;padding-right:4px;' src='https://mipostulacion.pe/OAEL/_GTContent/images/skydrive.png' width='64px'> </a> </td> <td width='25%'> <a href='https://chat.whatsapp.com/LS1oJoYFUUhLiVqnMw7RJF' style='text-decoration:none;' target='_blank'> <img style='display:block; margin: 0 auto; width: 64px;padding-right:4px;' src='https://mipostulacion.pe/OAEL/_GTContent/images/whatsapp64.png' width='64px'> </a> </td> <td width='25%'> <a href='https://manpowergrouperu-my.sharepoint.com/:f:/g/personal/oael_manpowerperu_pe/EsLzNwvmDMdHo0D0kGW1MDMBqv6l3shXIkm3sWxOqIMvoA?e=sTIa1S' style='text-decoration:none;' target='_blank'> <img style='display:block; margin: 0 auto; width: 64px;padding-right:4px;' src='https://mipostulacion.pe/OAEL/_GTContent/images/files.png' width='64px'> </a> </td> <td width='25%'> <a href='https://mipostulacion.pe/OAEL/Login.aspx' style='text-decoration:none;' target='_blank'> <img style='display:block; margin: 0 auto; width: 64px;padding-right:4px;' src='https://mipostulacion.pe/OAEL/_GTContent/images/oaelapp.png' width='64px'> </a> </td> </tr> <tr> <td width='25%' align='center'> <p class='sourcesans-font' style='padding:0px 24px; font-size: 0.8em;color: #4e4e4e;'> <a href='{cUrlOneDrive}' target='_blank' style='color:#0b41a4;text-decoration:none;'> Repositorio OneDrive para carga de CV </a> </p> </td> <td width='25%' align='center'> <p class='sourcesans-font' style='padding:0px 24px; font-size: 0.8em;color: #4e4e4e;'> <a href='https://chat.whatsapp.com/LS1oJoYFUUhLiVqnMw7RJF' target='_blank' style='color:#168b08;text-decoration:none;'> Grupo de Soporte WhatsApp</a> </p> </td> <td width='25%' align='center'> <p class='sourcesans-font' style='padding:0px 24px; font-size: 0.8em;color: #4e4e4e;'> <a href='https://manpowergrouperu-my.sharepoint.com/:f:/g/personal/oael_manpowerperu_pe/EsLzNwvmDMdHo0D0kGW1MDMBqv6l3shXIkm3sWxOqIMvoA?e=sTIa1S' target='_blank' style='color:#0367a5;text-decoration:none;'> Manuales, video inductivo y otros de gestión</a> </p> </td> <td width='25%' align='center'> <p class='sourcesans-font' style='padding:0px 24px; font-size: 0.8em;color: #4e4e4e;'> <a href='https://mipostulacion.pe/OAEL/Login.aspx' target='_blank' style='color:#00657a;text-decoration:none;'> Acceso directo Sistema web OAEL</a> </p> </td> </tr> </table> </div> </td> </tr> <tr><td>&nbsp;</td></tr> <tr> <td> <table style='width: 90%;' align='center'> <tr> <td width='100px' align='right'> <div style='margin-left: 6px; margin-right: 12px; margin-top:12px;margin-bottom:8px;'> <img style='display:inline-block;position: relative;right: 0;width: 120px;padding-right:4px;' src='https://mipostulacion.pe/assets/img/logo-1.png' width='200px'> </div> </td> <td> <div style='margin-left: 0px; margin-right: 0px; margin-top:28px;margin-bottom:12px;padding: 10px 10px;border-left:2px solid #135b70 ; color:#525F77; '> <p class='sourcesans-font' style='font-size:1.1em;margin: 0;font-weight: bold; margin-left: 5px;'>Oficina de Apoyo al Empleo Local</p> <p class='sourcesans-font' style='margin: 0;margin-left: 5px;padding-top: 2px; font-size:0.9em;'>Soporte OAEL</p> <p class='sourcesans-font' style=' margin: 0;margin-left: 5px;padding-top: 2px;font-size:0.9em;'>(+51) 949345261</p> </div> </td> </tr> </table> </td> </tr> <tr><td>&nbsp;</td></tr> <tr><td><p class='sourcesans-font' style='padding:4px 20px 4px 20px; text-align: center; font-size:0.95em;color:#7a6f31;font-weight: bold;'>*** Este correo se ha enviado de forma automática por lo cual no debe responder al mismo. ***</td></tr> </table>"
                correos.Body = correos.Body.Replace("{cNomCompleto}", Me.cNombres)
                correos.Body = correos.Body.Replace("{cUsuario}", Me.cUsuario)
                correos.Body = correos.Body.Replace("{cClave}", Me.cClave)
                correos.Body = correos.Body.Replace("{cNomContrata}", Me.cNomContrata)
                correos.Body = correos.Body.Replace("{cUrlOneDrive}", Me.cUrlDrive)

            Case "PLANTILLA_ACTUALIZACION"
                correos.Subject = ("ACTUALIZACIÓN - Plataforma OAEL - Oficina de Apoyo al Empleo Local - Quellaveco")
                correos.Body += "<style> .sourcesans-font{ font-family: sans-serif; } </style> <table style='width: 90%;color:#4e4e4e;' align='center'> <tr > <td> <table style='width: 100%;color:#eeeeee;background-color:#447296;border-radius:5px;padding: 18px 10px 18px 10px;height: auto; margin-top: 10px;'> <tr> <td width='50%'></td> <td width='50%' align='right' ><img style='display:inline-block;position: relative;right: 0;width: 180px;padding-right:4px;' src='https://mipostulacion.pe/images/logo-footer.png' width='180px'></td> </tr> </table> </td> </tr> <tr> <td> <p class='sourcesans-font' style='margin-top: 50px; margin-bottom: 8px;margin-left: 10px; margin-right: 10px;color:#4e4e4e;'>Estimado/a :</p> <p class='sourcesans-font' style='margin-top: 20px; margin-bottom: 4px;margin-left: 10px; margin-right: 10px;color:#4e4e4e;'> {cNomContrata}</p> <p class='sourcesans-font' style='margin-top: 0px; margin-left: 10px; margin-right: 10px;font-size: 1.6em;font-weight: bold; color: #525F77;'>{cNomCompleto}</p> </td> </tr> <tr> <td> <p class='sourcesans-font' style='margin-left: 10px; margin-right: 10px;padding-bottom: 8px; margin-top: 10px; font-size: 1.04em;color:#4e4e4e;'>Mediante la presente se confirma la cuenta de acceso a la plataforma web de la OAEL, puede ingresar mediante el siguiente enlace <a href='https://mipostulacion.pe/siel/webcandidato/LoginCandidato.aspx' style='font-weight: bold;color:#7a6f31;text-decoration:none;' target='_blank'><u>Acceder a la Plataforma del Candidato</u></a>. </p> <p class='sourcesans-font' style='margin-left: 10px; margin-right: 10px;padding-bottom: 8px; font-size: 1.04em;color:#4e4e4e;'> <b>Usuario :</b> {cUsuario} <br> <b>Clave :</b> {cClave} </p> </td> </tr> <tr><td>&nbsp;</td></tr> <tr> <td> <div style='border-radius: 8px; margin-top: 20px;margin-left: 10px; margin-right: 10px;background-color: #f5f4f0;padding: 12px 12px 20px 12px;font-size: 0.95em;'> <p class='sourcesans-font' style='padding:4px 20px 8px 20px;'> <strong>MATERIAL DE AYUDA : </strong> Adjuntamos enlaces web de material de soporte para la gestión de la plataforma, haga clic en los íconos para acceder al contenido. </p> <table> <tr> <td width='25%' align='center'> <a href='{cUrlOneDrive}' style='text-decoration:none;' target='_blank'> <img style='display:block; margin: 0 auto; width: 64px;padding-right:4px;' src='https://mipostulacion.pe/OAEL/_GTContent/images/skydrive.png' width='64px'> </a> </td> <td width='25%'> <a href='https://chat.whatsapp.com/LS1oJoYFUUhLiVqnMw7RJF' style='text-decoration:none;' target='_blank'> <img style='display:block; margin: 0 auto; width: 64px;padding-right:4px;' src='https://mipostulacion.pe/OAEL/_GTContent/images/whatsapp64.png' width='64px'> </a> </td> <td width='25%'> <a href='https://manpowergrouperu-my.sharepoint.com/:f:/g/personal/oael_manpowerperu_pe/EsLzNwvmDMdHo0D0kGW1MDMBqv6l3shXIkm3sWxOqIMvoA?e=sTIa1S' style='text-decoration:none;' target='_blank'> <img style='display:block; margin: 0 auto; width: 64px;padding-right:4px;' src='https://mipostulacion.pe/OAEL/_GTContent/images/files.png' width='64px'> </a> </td> <td width='25%'> <a href='https://mipostulacion.pe/OAEL/Login.aspx' style='text-decoration:none;' target='_blank'> <img style='display:block; margin: 0 auto; width: 64px;padding-right:4px;' src='https://mipostulacion.pe/OAEL/_GTContent/images/oaelapp.png' width='64px'> </a> </td> </tr> <tr> <td width='25%' align='center'> <p class='sourcesans-font' style='padding:0px 24px; font-size: 0.8em;color: #4e4e4e;'> <a href='{cUrlOneDrive}' target='_blank' style='color:#0b41a4;text-decoration:none;'> Repositorio OneDrive para carga de CV </a> </p> </td> <td width='25%' align='center'> <p class='sourcesans-font' style='padding:0px 24px; font-size: 0.8em;color: #4e4e4e;'> <a href='https://chat.whatsapp.com/LS1oJoYFUUhLiVqnMw7RJF' target='_blank' style='color:#168b08;text-decoration:none;'> Grupo de Soporte WhatsApp</a> </p> </td> <td width='25%' align='center'> <p class='sourcesans-font' style='padding:0px 24px; font-size: 0.8em;color: #4e4e4e;'> <a href='https://manpowergrouperu-my.sharepoint.com/:f:/g/personal/oael_manpowerperu_pe/EsLzNwvmDMdHo0D0kGW1MDMBqv6l3shXIkm3sWxOqIMvoA?e=sTIa1S' target='_blank' style='color:#0367a5;text-decoration:none;'> Manuales, video inductivo y otros de gestión</a> </p> </td> <td width='25%' align='center'> <p class='sourcesans-font' style='padding:0px 24px; font-size: 0.8em;color: #4e4e4e;'> <a href='https://mipostulacion.pe/OAEL/Login.aspx' target='_blank' style='color:#00657a;text-decoration:none;'> Acceso directo Sistema web OAEL</a> </p> </td> </tr> </table> </div> </td> </tr> <tr><td>&nbsp;</td></tr> <tr> <td> <table style='width: 90%;' align='center'> <tr> <td width='100px' align='right'> <div style='margin-left: 6px; margin-right: 12px; margin-top:12px;margin-bottom:8px;'> <img style='display:inline-block;position: relative;right: 0;width: 120px;padding-right:4px;' src='https://mipostulacion.pe/assets/img/logo-1.png' width='200px'> </div> </td> <td> <div style='margin-left: 0px; margin-right: 0px; margin-top:28px;margin-bottom:12px;padding: 10px 10px;border-left:2px solid #135b70 ; color:#525F77; '> <p class='sourcesans-font' style='font-size:1.1em;margin: 0;font-weight: bold; margin-left: 5px;'>Oficina de Apoyo al Empleo Local</p> <p class='sourcesans-font' style='margin: 0;margin-left: 5px;padding-top: 2px; font-size:0.9em;'>Soporte OAEL</p> <p class='sourcesans-font' style=' margin: 0;margin-left: 5px;padding-top: 2px;font-size:0.9em;'>(+51) 949345261</p> </div> </td> </tr> </table> </td> </tr> <tr><td>&nbsp;</td></tr> <tr><td><p class='sourcesans-font' style='padding:4px 20px 4px 20px; text-align: center; font-size:0.95em;color:#7a6f31;font-weight: bold;'>*** Este correo se ha enviado de forma automática por lo cual no debe responder al mismo. ***</td></tr> </table>"
                correos.Body = correos.Body.Replace("{cNomCompleto}", Me.cNombres)
                correos.Body = correos.Body.Replace("{cUsuario}", Me.cUsuario)
                correos.Body = correos.Body.Replace("{cClave}", Me.cClave)
                correos.Body = correos.Body.Replace("{cNomContrata}", Me.cNomContrata)
                correos.Body = correos.Body.Replace("{cUrlOneDrive}", Me.cUrlDrive)
            Case Else
                correos.Subject = ("GENERAL - Plataforma OAEL - Oficina de Apoyo al Empleo Local - Quellaveco")
                correos.Body += "<style> .sourcesans-font{ font-family: sans-serif; } </style> <table style='width: 90%;color:#4e4e4e;' align='center'> <tr > <td> <table style='width: 100%;color:#eeeeee;background-color:#447296;border-radius:5px;padding: 18px 10px 18px 10px;height: auto; margin-top: 10px;'> <tr> <td width='50%'></td> <td width='50%' align='right' ><img style='display:inline-block;position: relative;right: 0;width: 180px;padding-right:4px;' src='https://mipostulacion.pe/images/logo-footer.png' width='180px'></td> </tr> </table> </td> </tr> <tr> <td> <p class='sourcesans-font' style='margin-top: 50px; margin-bottom: 8px;margin-left: 10px; margin-right: 10px;color:#4e4e4e;'>Estimado/a :</p> <p class='sourcesans-font' style='margin-top: 20px; margin-bottom: 4px;margin-left: 10px; margin-right: 10px;color:#4e4e4e;'> {cNomContrata}</p> <p class='sourcesans-font' style='margin-top: 0px; margin-left: 10px; margin-right: 10px;font-size: 1.6em;font-weight: bold; color: #525F77;'>{cNomCompleto}</p> </td> </tr> <tr> <td> <p class='sourcesans-font' style='margin-left: 10px; margin-right: 10px;padding-bottom: 8px; margin-top: 10px; font-size: 1.04em;color:#4e4e4e;'>Mediante la presente se confirma la cuenta de acceso a la plataforma web de la OAEL, puede ingresar mediante el siguiente enlace <a href='https://mipostulacion.pe/siel/webcandidato/LoginCandidato.aspx' style='font-weight: bold;color:#7a6f31;text-decoration:none;' target='_blank'><u>Acceder a la Plataforma del Candidato</u></a>. </p> <p class='sourcesans-font' style='margin-left: 10px; margin-right: 10px;padding-bottom: 8px; font-size: 1.04em;color:#4e4e4e;'> <b>Usuario :</b> {cUsuario} <br> <b>Clave :</b> {cClave} </p> </td> </tr> <tr><td>&nbsp;</td></tr> <tr> <td> <div style='border-radius: 8px; margin-top: 20px;margin-left: 10px; margin-right: 10px;background-color: #f5f4f0;padding: 12px 12px 20px 12px;font-size: 0.95em;'> <p class='sourcesans-font' style='padding:4px 20px 8px 20px;'> <strong>MATERIAL DE AYUDA : </strong> Adjuntamos enlaces web de material de soporte para la gestión de la plataforma, haga clic en los íconos para acceder al contenido. </p> <table> <tr> <td width='25%' align='center'> <a href='{cUrlOneDrive}' style='text-decoration:none;' target='_blank'> <img style='display:block; margin: 0 auto; width: 64px;padding-right:4px;' src='https://mipostulacion.pe/OAEL/_GTContent/images/skydrive.png' width='64px'> </a> </td> <td width='25%'> <a href='https://chat.whatsapp.com/LS1oJoYFUUhLiVqnMw7RJF' style='text-decoration:none;' target='_blank'> <img style='display:block; margin: 0 auto; width: 64px;padding-right:4px;' src='https://mipostulacion.pe/OAEL/_GTContent/images/whatsapp64.png' width='64px'> </a> </td> <td width='25%'> <a href='https://manpowergrouperu-my.sharepoint.com/:f:/g/personal/oael_manpowerperu_pe/EsLzNwvmDMdHo0D0kGW1MDMBqv6l3shXIkm3sWxOqIMvoA?e=sTIa1S' style='text-decoration:none;' target='_blank'> <img style='display:block; margin: 0 auto; width: 64px;padding-right:4px;' src='https://mipostulacion.pe/OAEL/_GTContent/images/files.png' width='64px'> </a> </td> <td width='25%'> <a href='https://mipostulacion.pe/OAEL/Login.aspx' style='text-decoration:none;' target='_blank'> <img style='display:block; margin: 0 auto; width: 64px;padding-right:4px;' src='https://mipostulacion.pe/OAEL/_GTContent/images/oaelapp.png' width='64px'> </a> </td> </tr> <tr> <td width='25%' align='center'> <p class='sourcesans-font' style='padding:0px 24px; font-size: 0.8em;color: #4e4e4e;'> <a href='{cUrlOneDrive}' target='_blank' style='color:#0b41a4;text-decoration:none;'> Repositorio OneDrive para carga de CV </a> </p> </td> <td width='25%' align='center'> <p class='sourcesans-font' style='padding:0px 24px; font-size: 0.8em;color: #4e4e4e;'> <a href='https://chat.whatsapp.com/LS1oJoYFUUhLiVqnMw7RJF' target='_blank' style='color:#168b08;text-decoration:none;'> Grupo de Soporte WhatsApp</a> </p> </td> <td width='25%' align='center'> <p class='sourcesans-font' style='padding:0px 24px; font-size: 0.8em;color: #4e4e4e;'> <a href='https://manpowergrouperu-my.sharepoint.com/:f:/g/personal/oael_manpowerperu_pe/EsLzNwvmDMdHo0D0kGW1MDMBqv6l3shXIkm3sWxOqIMvoA?e=sTIa1S' target='_blank' style='color:#0367a5;text-decoration:none;'> Manuales, video inductivo y otros de gestión</a> </p> </td> <td width='25%' align='center'> <p class='sourcesans-font' style='padding:0px 24px; font-size: 0.8em;color: #4e4e4e;'> <a href='https://mipostulacion.pe/OAEL/Login.aspx' target='_blank' style='color:#00657a;text-decoration:none;'> Acceso directo Sistema web OAEL</a> </p> </td> </tr> </table> </div> </td> </tr> <tr><td>&nbsp;</td></tr> <tr> <td> <table style='width: 90%;' align='center'> <tr> <td width='100px' align='right'> <div style='margin-left: 6px; margin-right: 12px; margin-top:12px;margin-bottom:8px;'> <img style='display:inline-block;position: relative;right: 0;width: 120px;padding-right:4px;' src='https://mipostulacion.pe/assets/img/logo-1.png' width='200px'> </div> </td> <td> <div style='margin-left: 0px; margin-right: 0px; margin-top:28px;margin-bottom:12px;padding: 10px 10px;border-left:2px solid #135b70 ; color:#525F77; '> <p class='sourcesans-font' style='font-size:1.1em;margin: 0;font-weight: bold; margin-left: 5px;'>Oficina de Apoyo al Empleo Local</p> <p class='sourcesans-font' style='margin: 0;margin-left: 5px;padding-top: 2px; font-size:0.9em;'>Soporte OAEL</p> <p class='sourcesans-font' style=' margin: 0;margin-left: 5px;padding-top: 2px;font-size:0.9em;'>(+51) 949345261</p> </div> </td> </tr> </table> </td> </tr> <tr><td>&nbsp;</td></tr> <tr><td><p class='sourcesans-font' style='padding:4px 20px 4px 20px; text-align: center; font-size:0.95em;color:#7a6f31;font-weight: bold;'>*** Este correo se ha enviado de forma automática por lo cual no debe responder al mismo. ***</td></tr> </table>"
                correos.Body = correos.Body.Replace("{cNomCompleto}", Me.cNombres)
                correos.Body = correos.Body.Replace("{cUsuario}", Me.cUsuario)
                correos.Body = correos.Body.Replace("{cClave}", Me.cClave)
                correos.Body = correos.Body.Replace("{cNomContrata}", Me.cNomContrata)
                correos.Body = correos.Body.Replace("{cUrlOneDrive}", Me.cUrlDrive)

        End Select
        correos.IsBodyHtml = True
        correos.Priority = MailPriority.Normal

        Dim envios As New SmtpClient
        Try
            envios.Host = "10.56.4.40"
            envios.Port = "25"
            envios.UseDefaultCredentials = True
            'envios.Credentials = New NetworkCredential(Me.cMail, Me.cMailKey)
            envios.EnableSsl = True
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

    Public Function EnviarMensaje() As Boolean

        Dim correos As New MailMessage
        correos.From = New MailAddress(Me.cCorreoRemitente, Me.cNombreClienteRemitente)
        correos.To.Add(Trim(Me.cCorreoDestino))


        correos.Subject = Me.cTitulo
        correos.Body = Me.cMensaje

        If Len(Trim(Me.cCorreoCopia)) > 0 Then
            correos.Bcc.Add(LCase(Trim(Me.cCorreoCopia)))
        End If


        correos.IsBodyHtml = True
        correos.Priority = MailPriority.Normal

        Dim envios As New SmtpClient
        Try

            envios.Host = "10.56.4.40"
            envios.Port = 25
            'envios.UseDefaultCredentials = True
            envios.Credentials = New NetworkCredential(Me.cCorreoRemitente, "")
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
    Public Sub ActualizarEstadoEnvioCorreo()

        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL

        cmdSQL.CommandText = "UPDATE dbo.CorreoEnvio SET bEnviado=1,dFechaEnvio=GETDATE(),iCodUsuarioEnvio=@iCodUsuarioEnvio WHERE iCodCorreoEnvio=@iCodCorreoEnvio"
        cmdSQL.Parameters.Add("@iCodCorreoEnvio", SqlDbType.Int).Value = Me.iCodCorreoEnvio
        cmdSQL.Parameters.Add("@iCodUsuarioEnvio", SqlDbType.TinyInt).Value = Me.iCodUsuarioEnvio
        cmdSQL.ExecuteNonQuery()
    End Sub
End Class
