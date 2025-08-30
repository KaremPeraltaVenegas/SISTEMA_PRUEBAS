Imports System.Data.SqlClient
Public Class Tdocupacion
    Public iCodOcupacion As String
    Public cNomOcupacion As String
    Public cOcupacionAbrev As String
    Public cTipo As String
    Public cCategoriaRCC As String
    Public cOcupacionRCC As String
    Public cEspecialidadRCC As String
    Public qSelect As String
    Public cTipoOpe As Char
    Public bTransaccion As Boolean = False
    Public mc As New ConnectSQL
    Public Function ListaDatos() As DataTable
        Dim Query As String
        Dim readers As DataTable
        Query = "SELECT * FROM dbo.TDOcupacion"
        readers = mc.ExecuteDataTable(Query)
        Return readers
    End Function
    Public Sub Insertar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "INSERT into dbo.TDOcupacion (cNomOcupacion,cOcupacionAbrev,cTipo,cCategoriaRCC,cOcupacionRCC,cEspecialidadRCC ) VALUES(@cNomOcupacion,@cOcupacionAbrev,@cTipo,@cCategoriaRCC,@cOcupacionRCC,@cEspecialidadRCC); SELECT SCOPE_IDENTITY(); "
        cmdSQL.Parameters.Add("@cNomOcupacion", SqlDbType.Varchar, 150).Value = Me.cNomOcupacion
        cmdSQL.Parameters.Add("@cOcupacionAbrev", SqlDbType.Varchar, 50).Value = Me.cOcupacionAbrev
        cmdSQL.Parameters.Add("@cTipo", SqlDbType.Varchar, 6).Value = Me.cTipo
        cmdSQL.Parameters.Add("@cCategoriaRCC", SqlDbType.Varchar, 50).Value = Me.cCategoriaRCC
        cmdSQL.Parameters.Add("@cOcupacionRCC", SqlDbType.Varchar, 50).Value = Me.cOcupacionRCC
        cmdSQL.Parameters.Add("@cEspecialidadRCC", SqlDbType.Varchar, 50).Value = Me.cEspecialidadRCC

        Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
        If pCodInsert > 0 Then
            Me.iCodOcupacion = pCodInsert
        Else
            Me.iCodOcupacion = 0
        End If
    End Sub
    Public Sub InsertarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "INSERT into dbo.TDOcupacion (cNomOcupacion,cOcupacionAbrev,cTipo,cCategoriaRCC,cOcupacionRCC,cEspecialidadRCC ) VALUES(@cNomOcupacion,@cOcupacionAbrev,@cTipo,@cCategoriaRCC,@cOcupacionRCC,@cEspecialidadRCC); SELECT SCOPE_IDENTITY(); "
        cmdSQL.Parameters.Add("@cNomOcupacion", SqlDbType.Varchar, 150).Value = Me.cNomOcupacion
        cmdSQL.Parameters.Add("@cOcupacionAbrev", SqlDbType.Varchar, 50).Value = Me.cOcupacionAbrev
        cmdSQL.Parameters.Add("@cTipo", SqlDbType.Varchar, 6).Value = Me.cTipo
        cmdSQL.Parameters.Add("@cCategoriaRCC", SqlDbType.Varchar, 50).Value = Me.cCategoriaRCC
        cmdSQL.Parameters.Add("@cOcupacionRCC", SqlDbType.Varchar, 50).Value = Me.cOcupacionRCC
        cmdSQL.Parameters.Add("@cEspecialidadRCC", SqlDbType.Varchar, 50).Value = Me.cEspecialidadRCC

        Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
        If pCodInsert > 0 Then
            Me.iCodOcupacion = pCodInsert
        Else
            Me.iCodOcupacion = 0
        End If
    End Sub
    Public Sub Modificar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "UPDATE  dbo.TDOcupacion SET cNomOcupacion=@cNomOcupacion,cOcupacionAbrev=@cOcupacionAbrev,cTipo=@cTipo,cCategoriaRCC=@cCategoriaRCC,cOcupacionRCC=@cOcupacionRCC,cEspecialidadRCC=@cEspecialidadRCC WHERE iCodOcupacion=@iCodOcupacion"
        cmdSQL.Parameters.Add("@iCodOcupacion", SqlDbType.Int).Value = Me.iCodOcupacion
        cmdSQL.Parameters.Add("@cNomOcupacion", SqlDbType.Varchar, 150).Value = Me.cNomOcupacion
        cmdSQL.Parameters.Add("@cOcupacionAbrev", SqlDbType.Varchar, 50).Value = Me.cOcupacionAbrev
        cmdSQL.Parameters.Add("@cTipo", SqlDbType.Varchar, 6).Value = Me.cTipo
        cmdSQL.Parameters.Add("@cCategoriaRCC", SqlDbType.Varchar, 50).Value = Me.cCategoriaRCC
        cmdSQL.Parameters.Add("@cOcupacionRCC", SqlDbType.Varchar, 50).Value = Me.cOcupacionRCC
        cmdSQL.Parameters.Add("@cEspecialidadRCC", SqlDbType.Varchar, 50).Value = Me.cEspecialidadRCC

        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub ModificarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "UPDATE  dbo.TDOcupacion SET cNomOcupacion=@cNomOcupacion,cOcupacionAbrev=@cOcupacionAbrev,cTipo=@cTipo,cCategoriaRCC=@cCategoriaRCC,cOcupacionRCC=@cOcupacionRCC,cEspecialidadRCC=@cEspecialidadRCC WHERE iCodOcupacion=@iCodOcupacion"
        cmdSQL.Parameters.Add("@iCodOcupacion", SqlDbType.Int).Value = Me.iCodOcupacion
        cmdSQL.Parameters.Add("@cNomOcupacion", SqlDbType.Varchar, 150).Value = Me.cNomOcupacion
        cmdSQL.Parameters.Add("@cOcupacionAbrev", SqlDbType.Varchar, 50).Value = Me.cOcupacionAbrev
        cmdSQL.Parameters.Add("@cTipo", SqlDbType.Varchar, 6).Value = Me.cTipo
        cmdSQL.Parameters.Add("@cCategoriaRCC", SqlDbType.Varchar, 50).Value = Me.cCategoriaRCC
        cmdSQL.Parameters.Add("@cOcupacionRCC", SqlDbType.Varchar, 50).Value = Me.cOcupacionRCC
        cmdSQL.Parameters.Add("@cEspecialidadRCC", SqlDbType.Varchar, 50).Value = Me.cEspecialidadRCC

        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub Eliminar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "DELETE from  dbo.TDOcupacion  WHERE iCodOcupacion=@iCodOcupacion"
        'cmdSQL.CommandText = "UPDATE dbo.TDOcupacion  SET bAnulado=1 WHERE  iCodOcupacion=@iCodOcupacion"
        cmdSQL.Parameters.Add("@iCodOcupacion", SqlDbType.Int).Value = Me.iCodOcupacion
        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub EliminarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "DELETE from  dbo.TDOcupacion  WHERE iCodOcupacion=@iCodOcupacion"
        'cmdSQL.CommandText = "UPDATE dbo.TDOcupacion  SET bAnulado=1 WHERE  iCodOcupacion=@iCodOcupacion"
        cmdSQL.Parameters.Add("@iCodOcupacion", SqlDbType.Int).Value = Me.iCodOcupacion
        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub getRecord()
        Dim readers As IDataReader
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL

        If bTransaccion = True Then cmdSQL.Transaction = Me.mc.miTransact Else 

        cmdSQL.CommandText = "SELECT * FROM dbo.TDOcupacion WHERE iCodOcupacion=@iCodOcupacion"
        cmdSQL.Parameters.Add("@iCodOcupacion", SqlDbType.Int).Value = Me.iCodOcupacion
        readers = cmdSQL.ExecuteReader
        If readers.Read() Then
            Me.iCodOcupacion = CStr(readers.GetValue(0))
            Me.cNomOcupacion = CStr(readers.GetValue(1))
            Me.cOcupacionAbrev = CStr(readers.GetValue(2))
            Me.cTipo = CStr(readers.GetValue(3))
            Me.cCategoriaRCC = CStr(readers.GetValue(4))
            Me.cOcupacionRCC = CStr(readers.GetValue(5))
            Me.cEspecialidadRCC = CStr(readers.GetValue(6))
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
        cmdSQL.CommandText = "SELECT * FROM dbo.TDOcupacion"
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
    '*********************************************************************************************
    Public Function ListaOcupaciones() As DataTable
        Dim miDataTable As New DataTable
        Dim Query As String
        Dim readers As IDataReader
        miDataTable.Columns.Add("ValueMember")
        miDataTable.Columns.Add("DisplayMember")
        Query = String.Format("SELECT * FROM Tdocupacion")
        readers = mc.ExecuteReader(Query)
        While readers.Read()
            miDataTable.Rows.Add(CStr(readers.GetValue(0)), CStr(readers.GetValue(1)))
        End While
        readers.Close()
        Return miDataTable
    End Function
    Public Function ListaOcupacionesAllField() As DataTable
        Dim Query As String
        Query = String.Format("SELECT * FROM v_TDOcupacion")
        ListaOcupacionesAllField = mc.ExecuteDataTable(Query)
        Return ListaOcupacionesAllField
    End Function

    Public Function ListaOcupacionesConTipoMOC() As DataTable
        Dim miDataTable As New DataTable
        Dim Query As String
        Dim readers As IDataReader
        miDataTable.Columns.Add("ValueMember")
        miDataTable.Columns.Add("DisplayMember")
        Query = String.Format("SELECT iCodOcupacion, cTipo + ' - ' + cNomOcupacion as 'nombreOcupacion' FROM dbo.Tdocupacion")
        readers = mc.ExecuteReader(Query)
        While readers.Read()
            miDataTable.Rows.Add(CStr(readers.GetValue(0)), CStr(readers.GetValue(1)))
        End While
        readers.Close()
        Return miDataTable
    End Function

    Public Function obtenerDetallePerfilPorCodOcupacion() As DataTable

        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = "dbo.SP_ROW_TDOcupacion"
        cmdSQL.Parameters.Add("@iCodOcupacion", SqlDbType.Int).Value = Me.iCodOcupacion

        Dim readers As SqlDataReader
        readers = cmdSQL.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(readers)
        Return dt

    End Function
End Class
