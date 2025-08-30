Imports System.Data.SqlClient
Public Class Seguridadusuariohistorial
Public iCodSeguridadUsuarioHistorial As String
Public cNick As String
Public iCodUsuario As String
Public cTipoLogOnOff As String
Public iNroIntentosLogOn As String
Public bIngresoAplicacion As String
Public dFechaLogOnOff As String
Public cHostName As String
Public cIP As String
Public bBloqueado As String
Public dFechaBloqueo As String
Public qSelect As String
Public cTipoOpe as Char
Public bTransaccion as Boolean=False
	Public mc As New ConnectSQL
	Public bEsBloqueado As Boolean
 Public Function ListaDatos() As DataTable
	Dim Query As String
	Dim readers As DataTable
        Query = "SELECT * FROM dbo.SeguridadUsuarioHistorial"
        readers = mc.ExecuteDataTable(Query)
        Return readers
    End Function
    Public Sub Insertar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "INSERT into dbo.SeguridadUsuarioHistorial (cNick,iCodUsuario,cTipoLogOnOff,iNroIntentosLogOn,bIngresoAplicacion,dFechaLogOnOff,cHostName,cIP,bBloqueado,dFechaBloqueo ) VALUES(@cNick,@iCodUsuario,@cTipoLogOnOff,@iNroIntentosLogOn,@bIngresoAplicacion,@dFechaLogOnOff,@cHostName,@cIP,@bBloqueado,@dFechaBloqueo); SELECT SCOPE_IDENTITY(); "
        cmdSQL.Parameters.Add("@cNick", SqlDbType.Varchar, 50).Value = Me.cNick
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@cTipoLogOnOff", SqlDbType.Varchar, 250).Value = Me.cTipoLogOnOff
        cmdSQL.Parameters.Add("@iNroIntentosLogOn", SqlDbType.Int).Value = Me.iNroIntentosLogOn
        cmdSQL.Parameters.Add("@bIngresoAplicacion", SqlDbType.Bit).Value = Me.bIngresoAplicacion
        cmdSQL.Parameters.Add("@dFechaLogOnOff", SqlDbType.Datetime).Value = Me.dFechaLogOnOff
        cmdSQL.Parameters.Add("@cHostName", SqlDbType.Varchar, 250).Value = Me.cHostName
        cmdSQL.Parameters.Add("@cIP", SqlDbType.Varchar, 250).Value = Me.cIP
        cmdSQL.Parameters.Add("@bBloqueado", SqlDbType.Bit).Value = Me.bBloqueado
        cmdSQL.Parameters.Add("@dFechaBloqueo", SqlDbType.Datetime).Value = Me.dFechaBloqueo

        Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
        If pCodInsert > 0 Then
            Me.iCodSeguridadUsuarioHistorial = pCodInsert
        Else
            Me.iCodSeguridadUsuarioHistorial = 0
        End If
    End Sub
    Public Sub InsertarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "INSERT into dbo.SeguridadUsuarioHistorial (cNick,iCodUsuario,cTipoLogOnOff,iNroIntentosLogOn,bIngresoAplicacion,dFechaLogOnOff,cHostName,cIP,bBloqueado,dFechaBloqueo ) VALUES(@cNick,@iCodUsuario,@cTipoLogOnOff,@iNroIntentosLogOn,@bIngresoAplicacion,@dFechaLogOnOff,@cHostName,@cIP,@bBloqueado,@dFechaBloqueo); SELECT SCOPE_IDENTITY(); "
        cmdSQL.Parameters.Add("@cNick", SqlDbType.Varchar, 50).Value = Me.cNick
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@cTipoLogOnOff", SqlDbType.Varchar, 250).Value = Me.cTipoLogOnOff
        cmdSQL.Parameters.Add("@iNroIntentosLogOn", SqlDbType.Int).Value = Me.iNroIntentosLogOn
        cmdSQL.Parameters.Add("@bIngresoAplicacion", SqlDbType.Bit).Value = Me.bIngresoAplicacion
        cmdSQL.Parameters.Add("@dFechaLogOnOff", SqlDbType.Datetime).Value = Me.dFechaLogOnOff
        cmdSQL.Parameters.Add("@cHostName", SqlDbType.Varchar, 250).Value = Me.cHostName
        cmdSQL.Parameters.Add("@cIP", SqlDbType.Varchar, 250).Value = Me.cIP
        cmdSQL.Parameters.Add("@bBloqueado", SqlDbType.Bit).Value = Me.bBloqueado
        cmdSQL.Parameters.Add("@dFechaBloqueo", SqlDbType.Datetime).Value = Me.dFechaBloqueo

        Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
        If pCodInsert > 0 Then
            Me.iCodSeguridadUsuarioHistorial = pCodInsert
        Else
            Me.iCodSeguridadUsuarioHistorial = 0
        End If
    End Sub
    Public Sub Modificar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "UPDATE  dbo.SeguridadUsuarioHistorial SET cNick=@cNick,iCodUsuario=@iCodUsuario,cTipoLogOnOff=@cTipoLogOnOff,iNroIntentosLogOn=@iNroIntentosLogOn,bIngresoAplicacion=@bIngresoAplicacion,dFechaLogOnOff=@dFechaLogOnOff,cHostName=@cHostName,cIP=@cIP,bBloqueado=@bBloqueado,dFechaBloqueo=@dFechaBloqueo WHERE iCodSeguridadUsuarioHistorial=@iCodSeguridadUsuarioHistorial"
        cmdSQL.Parameters.Add("@iCodSeguridadUsuarioHistorial", SqlDbType.Int).Value = Me.iCodSeguridadUsuarioHistorial
        cmdSQL.Parameters.Add("@cNick", SqlDbType.Varchar, 50).Value = Me.cNick
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@cTipoLogOnOff", SqlDbType.Varchar, 250).Value = Me.cTipoLogOnOff
        cmdSQL.Parameters.Add("@iNroIntentosLogOn", SqlDbType.Int).Value = Me.iNroIntentosLogOn
        cmdSQL.Parameters.Add("@bIngresoAplicacion", SqlDbType.Bit).Value = Me.bIngresoAplicacion
        cmdSQL.Parameters.Add("@dFechaLogOnOff", SqlDbType.Datetime).Value = Me.dFechaLogOnOff
        cmdSQL.Parameters.Add("@cHostName", SqlDbType.Varchar, 250).Value = Me.cHostName
        cmdSQL.Parameters.Add("@cIP", SqlDbType.Varchar, 250).Value = Me.cIP
        cmdSQL.Parameters.Add("@bBloqueado", SqlDbType.Bit).Value = Me.bBloqueado
        cmdSQL.Parameters.Add("@dFechaBloqueo", SqlDbType.Datetime).Value = Me.dFechaBloqueo

        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub ModificarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "UPDATE  dbo.SeguridadUsuarioHistorial SET cNick=@cNick,iCodUsuario=@iCodUsuario,cTipoLogOnOff=@cTipoLogOnOff,iNroIntentosLogOn=@iNroIntentosLogOn,bIngresoAplicacion=@bIngresoAplicacion,dFechaLogOnOff=@dFechaLogOnOff,cHostName=@cHostName,cIP=@cIP,bBloqueado=@bBloqueado,dFechaBloqueo=@dFechaBloqueo WHERE iCodSeguridadUsuarioHistorial=@iCodSeguridadUsuarioHistorial"
        cmdSQL.Parameters.Add("@iCodSeguridadUsuarioHistorial", SqlDbType.Int).Value = Me.iCodSeguridadUsuarioHistorial
        cmdSQL.Parameters.Add("@cNick", SqlDbType.Varchar, 50).Value = Me.cNick
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@cTipoLogOnOff", SqlDbType.Varchar, 250).Value = Me.cTipoLogOnOff
        cmdSQL.Parameters.Add("@iNroIntentosLogOn", SqlDbType.Int).Value = Me.iNroIntentosLogOn
        cmdSQL.Parameters.Add("@bIngresoAplicacion", SqlDbType.Bit).Value = Me.bIngresoAplicacion
        cmdSQL.Parameters.Add("@dFechaLogOnOff", SqlDbType.Datetime).Value = Me.dFechaLogOnOff
        cmdSQL.Parameters.Add("@cHostName", SqlDbType.Varchar, 250).Value = Me.cHostName
        cmdSQL.Parameters.Add("@cIP", SqlDbType.Varchar, 250).Value = Me.cIP
        cmdSQL.Parameters.Add("@bBloqueado", SqlDbType.Bit).Value = Me.bBloqueado
        cmdSQL.Parameters.Add("@dFechaBloqueo", SqlDbType.Datetime).Value = Me.dFechaBloqueo

        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub Eliminar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "DELETE from  dbo.SeguridadUsuarioHistorial  WHERE iCodSeguridadUsuarioHistorial=@iCodSeguridadUsuarioHistorial"
        'cmdSQL.CommandText = "UPDATE dbo.SeguridadUsuarioHistorial  SET bAnulado=1 WHERE  iCodSeguridadUsuarioHistorial=@iCodSeguridadUsuarioHistorial"
        cmdSQL.Parameters.Add("@iCodSeguridadUsuarioHistorial", SqlDbType.Int).Value = Me.iCodSeguridadUsuarioHistorial
        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub EliminarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "DELETE from  dbo.SeguridadUsuarioHistorial  WHERE iCodSeguridadUsuarioHistorial=@iCodSeguridadUsuarioHistorial"
        'cmdSQL.CommandText = "UPDATE dbo.SeguridadUsuarioHistorial  SET bAnulado=1 WHERE  iCodSeguridadUsuarioHistorial=@iCodSeguridadUsuarioHistorial"
        cmdSQL.Parameters.Add("@iCodSeguridadUsuarioHistorial", SqlDbType.Int).Value = Me.iCodSeguridadUsuarioHistorial
        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub getRecord()
        Dim readers As IDataReader
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL

        If bTransaccion = True Then cmdSQL.Transaction = Me.mc.miTransact Else 

        cmdSQL.CommandText = "SELECT * FROM dbo.SeguridadUsuarioHistorial WHERE iCodSeguridadUsuarioHistorial=@iCodSeguridadUsuarioHistorial"
        cmdSQL.Parameters.Add("@iCodSeguridadUsuarioHistorial", SqlDbType.Int).Value = Me.iCodSeguridadUsuarioHistorial
        readers = cmdSQL.ExecuteReader
        If readers.Read() Then
            Me.iCodSeguridadUsuarioHistorial = CStr(readers.GetValue(0))
            Me.cNick = CStr(readers.GetValue(1))
            Me.iCodUsuario = CStr(readers.GetValue(2))
            Me.cTipoLogOnOff = CStr(readers.GetValue(3))
            Me.iNroIntentosLogOn = CStr(readers.GetValue(4))
            Me.bIngresoAplicacion = CStr(readers.GetValue(5))
            Me.dFechaLogOnOff = CStr(readers.GetValue(6))
            Me.cHostName = CStr(readers.GetValue(7))
            Me.cIP = CStr(readers.GetValue(8))
            Me.bBloqueado = CStr(readers.GetValue(9))
            Me.dFechaBloqueo = CStr(readers.GetValue(10))
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
        cmdSQL.CommandText = "SELECT * FROM dbo.SeguridadUsuarioHistorial"
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
    Public Function AgregarSeguridadUsuarioHistorial() As Integer
        Dim Query As String = ""
        Dim readers As IDataReader
        Dim respuesta As Integer

        Query = " exec dbo.SP_INSER_SeguridadUsuarioHistorial " &
                       "@cNick='" & Trim(Me.cNick) &
                       "',@iCodUsuario=" & Trim(Me.iCodUsuario) &
                       ",@cTipoLogOnOff='" & Trim(Me.cTipoLogOnOff) &
                       "',@iNroIntentosLogOn=" & Trim(Me.iNroIntentosLogOn) &
                       ",@bIngresoAplicacion=" & Trim(Me.bIngresoAplicacion) &
                       ",@dFechaLogOnOff='" & Trim(Me.dFechaLogOnOff) &
                       "',@cHostName='" & Trim(Me.cHostName) &
                       "',@cIP='" & Trim(Me.cIP) & "'" &
                       ",@bBloqueado=" & Me.bBloqueado &
                       ",@dFechaBloqueo=" & IIf(Me.dFechaBloqueo = "NULL", Me.dFechaBloqueo, "'" + Me.dFechaBloqueo + "'")

        readers = mc.ExecuteReader(Query)
        While readers.Read()
            respuesta = CInt(readers.GetValue(0))
        End While
        Return respuesta
    End Function
End Class
