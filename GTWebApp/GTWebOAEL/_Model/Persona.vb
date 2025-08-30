Imports System.Data.SqlClient
Public Class Persona
    Public iCodPersona As String
    Public cTipoPer As String
    Public iCodTipoDocumentoIdentidad As String
    Public cNroDoc As String
    Public cDireccion As String
    Public bAnulado As String
    Public iCodUsuario As String
    Public dFechaSis As String
    Public qSelect As String
    Public cTipoOpe As Char
    Public bTransaccion As Boolean = False
    Public mc As New ConnectSQL
    Public Function ListaDatos() As DataTable
        Dim Query As String
        Dim readers As DataTable
        Query = "SELECT * FROM dbo.Persona"
        readers = mc.ExecuteDataTable(Query)
        Return readers
    End Function
    Public Sub Insertar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "INSERT into dbo.Persona (cTipoPer,iCodTipoDocumentoIdentidad,cNroDoc,cDireccion,bAnulado,iCodUsuario,dFechaSis ) VALUES(@cTipoPer,@iCodTipoDocumentoIdentidad,@cNroDoc,@cDireccion,@bAnulado,@iCodUsuario,@dFechaSis); SELECT SCOPE_IDENTITY(); "
        cmdSQL.Parameters.Add("@cTipoPer", SqlDbType.Char, 2).Value = Me.cTipoPer
        cmdSQL.Parameters.Add("@iCodTipoDocumentoIdentidad", SqlDbType.Int).Value = Me.iCodTipoDocumentoIdentidad
        cmdSQL.Parameters.Add("@cNroDoc", SqlDbType.VarChar, 50).Value = Me.cNroDoc
        cmdSQL.Parameters.Add("@cDireccion", SqlDbType.VarChar, 150).Value = Me.cDireccion
        cmdSQL.Parameters.Add("@bAnulado", SqlDbType.Bit).Value = Me.bAnulado
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.DateTime).Value = Me.dFechaSis

        Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
        If pCodInsert > 0 Then
            Me.iCodPersona = pCodInsert
        Else
            Me.iCodPersona = 0
        End If
    End Sub
    Public Sub InsertarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "INSERT into dbo.Persona (cTipoPer,iCodTipoDocumentoIdentidad,cNroDoc,cDireccion,bAnulado,iCodUsuario,dFechaSis ) VALUES(@cTipoPer,@iCodTipoDocumentoIdentidad,@cNroDoc,@cDireccion,@bAnulado,@iCodUsuario,@dFechaSis); SELECT SCOPE_IDENTITY(); "
        cmdSQL.Parameters.Add("@cTipoPer", SqlDbType.Char, 2).Value = Me.cTipoPer
        cmdSQL.Parameters.Add("@iCodTipoDocumentoIdentidad", SqlDbType.Int).Value = Me.iCodTipoDocumentoIdentidad
        cmdSQL.Parameters.Add("@cNroDoc", SqlDbType.VarChar, 50).Value = Me.cNroDoc
        cmdSQL.Parameters.Add("@cDireccion", SqlDbType.VarChar, 150).Value = Me.cDireccion
        cmdSQL.Parameters.Add("@bAnulado", SqlDbType.Bit).Value = Me.bAnulado
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.DateTime).Value = Me.dFechaSis

        Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
        If pCodInsert > 0 Then
            Me.iCodPersona = pCodInsert
        Else
            Me.iCodPersona = 0
        End If
    End Sub
    Public Sub Modificar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "UPDATE  dbo.Persona SET cTipoPer=@cTipoPer,iCodTipoDocumentoIdentidad=@iCodTipoDocumentoIdentidad,cNroDoc=@cNroDoc,cDireccion=@cDireccion,bAnulado=@bAnulado,iCodUsuario=@iCodUsuario,dFechaSis=@dFechaSis WHERE iCodPersona=@iCodPersona"
        cmdSQL.Parameters.Add("@iCodPersona", SqlDbType.Int).Value = Me.iCodPersona
        cmdSQL.Parameters.Add("@cTipoPer", SqlDbType.Char, 2).Value = Me.cTipoPer
        cmdSQL.Parameters.Add("@iCodTipoDocumentoIdentidad", SqlDbType.Int).Value = Me.iCodTipoDocumentoIdentidad
        cmdSQL.Parameters.Add("@cNroDoc", SqlDbType.VarChar, 50).Value = Me.cNroDoc
        cmdSQL.Parameters.Add("@cDireccion", SqlDbType.VarChar, 150).Value = Me.cDireccion
        cmdSQL.Parameters.Add("@bAnulado", SqlDbType.Bit).Value = Me.bAnulado
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.DateTime).Value = Me.dFechaSis

        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub ModificarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "UPDATE  dbo.Persona SET cTipoPer=@cTipoPer,iCodTipoDocumentoIdentidad=@iCodTipoDocumentoIdentidad,cNroDoc=@cNroDoc,cDireccion=@cDireccion,bAnulado=@bAnulado,iCodUsuario=@iCodUsuario,dFechaSis=@dFechaSis WHERE iCodPersona=@iCodPersona"
        cmdSQL.Parameters.Add("@iCodPersona", SqlDbType.Int).Value = Me.iCodPersona
        cmdSQL.Parameters.Add("@cTipoPer", SqlDbType.Char, 2).Value = Me.cTipoPer
        cmdSQL.Parameters.Add("@iCodTipoDocumentoIdentidad", SqlDbType.Int).Value = Me.iCodTipoDocumentoIdentidad
        cmdSQL.Parameters.Add("@cNroDoc", SqlDbType.VarChar, 50).Value = Me.cNroDoc
        cmdSQL.Parameters.Add("@cDireccion", SqlDbType.VarChar, 150).Value = Me.cDireccion
        cmdSQL.Parameters.Add("@bAnulado", SqlDbType.Bit).Value = Me.bAnulado
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.DateTime).Value = Me.dFechaSis

        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub Eliminar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "DELETE from  dbo.Persona  WHERE iCodPersona=@iCodPersona"
        'cmdSQL.CommandText = "UPDATE dbo.Persona  SET bAnulado=1 WHERE  iCodPersona=@iCodPersona"
        cmdSQL.Parameters.Add("@iCodPersona", SqlDbType.Int).Value = Me.iCodPersona
        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub EliminarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "DELETE from  dbo.Persona  WHERE iCodPersona=@iCodPersona"
        'cmdSQL.CommandText = "UPDATE dbo.Persona  SET bAnulado=1 WHERE  iCodPersona=@iCodPersona"
        cmdSQL.Parameters.Add("@iCodPersona", SqlDbType.Int).Value = Me.iCodPersona
        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub getRecord()
        Dim readers As IDataReader
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL

        If bTransaccion = True Then cmdSQL.Transaction = Me.mc.miTransact Else 

        cmdSQL.CommandText = "SELECT * FROM dbo.Persona WHERE iCodPersona=@iCodPersona"
        cmdSQL.Parameters.Add("@iCodPersona", SqlDbType.Int).Value = Me.iCodPersona
        readers = cmdSQL.ExecuteReader
        If readers.Read() Then
            Me.iCodPersona = CStr(readers.GetValue(0))
            Me.cTipoPer = CStr(readers.GetValue(1))
            Me.iCodTipoDocumentoIdentidad = CStr(readers.GetValue(2))
            Me.cNroDoc = CStr(readers.GetValue(3))
            Me.cDireccion = CStr(readers.GetValue(4))
            Me.bAnulado = CStr(readers.GetValue(5))
            Me.iCodUsuario = CStr(readers.GetValue(6))
            Me.dFechaSis = CStr(readers.GetValue(7))
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
        cmdSQL.CommandText = "SELECT * FROM dbo.Persona"
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
End Class
