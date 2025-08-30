Imports System.Data.SqlClient
Public Class Seguridadclavehistorial
Public iCodSeguridadClaveHistorial As String
Public iCodUsuario As String
Public cClave As String
Public iNroCorrelativo As String
Public dFechaCreacion As String
Public qSelect As String
Public cTipoOpe as Char
Public bTransaccion as Boolean=False
Public mc as New ConnectSQL
 Public Function ListaDatos() As DataTable
	Dim Query As String
	Dim readers As DataTable
        Query = "SELECT * FROM dbo.SeguridadClaveHistorial"
        readers = mc.ExecuteDataTable(Query)
        Return readers
    End Function
    Public Sub Insertar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "INSERT into dbo.SeguridadClaveHistorial (iCodUsuario,cClave,iNroCorrelativo,dFechaCreacion ) VALUES(@iCodUsuario,@cClave,@iNroCorrelativo,@dFechaCreacion); SELECT SCOPE_IDENTITY(); "
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@cClave", SqlDbType.Varchar, 250).Value = Me.cClave
        cmdSQL.Parameters.Add("@iNroCorrelativo", SqlDbType.Int).Value = Me.iNroCorrelativo
        cmdSQL.Parameters.Add("@dFechaCreacion", SqlDbType.Datetime).Value = Me.dFechaCreacion

        Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
        If pCodInsert > 0 Then
            Me.iCodSeguridadClaveHistorial = pCodInsert
        Else
            Me.iCodSeguridadClaveHistorial = 0
        End If
    End Sub
    Public Sub InsertarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "INSERT into dbo.SeguridadClaveHistorial (iCodUsuario,cClave,iNroCorrelativo,dFechaCreacion ) VALUES(@iCodUsuario,@cClave,@iNroCorrelativo,@dFechaCreacion); SELECT SCOPE_IDENTITY(); "
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@cClave", SqlDbType.Varchar, 250).Value = Me.cClave
        cmdSQL.Parameters.Add("@iNroCorrelativo", SqlDbType.Int).Value = Me.iNroCorrelativo
        cmdSQL.Parameters.Add("@dFechaCreacion", SqlDbType.Datetime).Value = Me.dFechaCreacion

        Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
        If pCodInsert > 0 Then
            Me.iCodSeguridadClaveHistorial = pCodInsert
        Else
            Me.iCodSeguridadClaveHistorial = 0
        End If
    End Sub
    Public Sub Modificar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "UPDATE  dbo.SeguridadClaveHistorial SET iCodUsuario=@iCodUsuario,cClave=@cClave,iNroCorrelativo=@iNroCorrelativo,dFechaCreacion=@dFechaCreacion WHERE iCodSeguridadClaveHistorial=@iCodSeguridadClaveHistorial"
        cmdSQL.Parameters.Add("@iCodSeguridadClaveHistorial", SqlDbType.Int).Value = Me.iCodSeguridadClaveHistorial
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@cClave", SqlDbType.Varchar, 250).Value = Me.cClave
        cmdSQL.Parameters.Add("@iNroCorrelativo", SqlDbType.Int).Value = Me.iNroCorrelativo
        cmdSQL.Parameters.Add("@dFechaCreacion", SqlDbType.Datetime).Value = Me.dFechaCreacion

        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub ModificarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "UPDATE  dbo.SeguridadClaveHistorial SET iCodUsuario=@iCodUsuario,cClave=@cClave,iNroCorrelativo=@iNroCorrelativo,dFechaCreacion=@dFechaCreacion WHERE iCodSeguridadClaveHistorial=@iCodSeguridadClaveHistorial"
        cmdSQL.Parameters.Add("@iCodSeguridadClaveHistorial", SqlDbType.Int).Value = Me.iCodSeguridadClaveHistorial
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@cClave", SqlDbType.Varchar, 250).Value = Me.cClave
        cmdSQL.Parameters.Add("@iNroCorrelativo", SqlDbType.Int).Value = Me.iNroCorrelativo
        cmdSQL.Parameters.Add("@dFechaCreacion", SqlDbType.Datetime).Value = Me.dFechaCreacion

        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub Eliminar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "DELETE from  dbo.SeguridadClaveHistorial  WHERE iCodSeguridadClaveHistorial=@iCodSeguridadClaveHistorial"
        'cmdSQL.CommandText = "UPDATE dbo.SeguridadClaveHistorial  SET bAnulado=1 WHERE  iCodSeguridadClaveHistorial=@iCodSeguridadClaveHistorial"
        cmdSQL.Parameters.Add("@iCodSeguridadClaveHistorial", SqlDbType.Int).Value = Me.iCodSeguridadClaveHistorial
        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub EliminarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "DELETE from  dbo.SeguridadClaveHistorial  WHERE iCodSeguridadClaveHistorial=@iCodSeguridadClaveHistorial"
        'cmdSQL.CommandText = "UPDATE dbo.SeguridadClaveHistorial  SET bAnulado=1 WHERE  iCodSeguridadClaveHistorial=@iCodSeguridadClaveHistorial"
        cmdSQL.Parameters.Add("@iCodSeguridadClaveHistorial", SqlDbType.Int).Value = Me.iCodSeguridadClaveHistorial
        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub getRecord()
        Dim readers As IDataReader
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL

        If bTransaccion = True Then cmdSQL.Transaction = Me.mc.miTransact Else 

        cmdSQL.CommandText = "SELECT * FROM dbo.SeguridadClaveHistorial WHERE iCodSeguridadClaveHistorial=@iCodSeguridadClaveHistorial"
        cmdSQL.Parameters.Add("@iCodSeguridadClaveHistorial", SqlDbType.Int).Value = Me.iCodSeguridadClaveHistorial
        readers = cmdSQL.ExecuteReader
        If readers.Read() Then
            Me.iCodSeguridadClaveHistorial = CStr(readers.GetValue(0))
            Me.iCodUsuario = CStr(readers.GetValue(1))
            Me.cClave = CStr(readers.GetValue(2))
            Me.iNroCorrelativo = CStr(readers.GetValue(3))
            Me.dFechaCreacion = CStr(readers.GetValue(4))
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
        cmdSQL.CommandText = "SELECT * FROM dbo.SeguridadClaveHistorial"
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

    Public Function AgregarAlCaducarContrasenia() As Integer
        Dim Query As String = ""
        Dim readers As IDataReader
        Dim respuesta As Integer

        Query = " exec dbo.SP_INSER_SeguridadClaveHistorial " &
                       "@iCodUsuario=" & Trim(Me.iCodUsuario) &
                       ",@cClave='" & Trim(Me.cClave) & "'"

        readers = mc.ExecuteReader(Query)
        While readers.Read()
            respuesta = CInt(readers.GetValue(0))
        End While
        Return respuesta
    End Function
End Class
