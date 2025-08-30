Imports System.Data.SqlClient
Public Class Anexoadmisiontipo
    Public iCodAnexoAdmisionTipo As String
    Public cDetalle As String
    Public cResumen As String
    Public iGrupo As String
    Public qSelect As String
    Public cTipoOpe As Char
    Public bTransaccion As Boolean = False
    Public mc As New ConnectSQL
    Public Function ListaDatos() As DataTable
        Dim Query As String
        Dim readers As DataTable
        Query = "SELECT * FROM dbo.AnexoAdmisionTipo"
        readers = mc.ExecuteDataTable(Query)
        Return readers
    End Function
    Public Sub Insertar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "INSERT into dbo.AnexoAdmisionTipo (cDetalle,cResumen,iGrupo ) VALUES(@cDetalle,@cResumen,@iGrupo); SELECT SCOPE_IDENTITY(); "
        cmdSQL.Parameters.Add("@cDetalle", SqlDbType.Varchar, 50).Value = Me.cDetalle
        cmdSQL.Parameters.Add("@cResumen", SqlDbType.Varchar, 50).Value = Me.cResumen
        cmdSQL.Parameters.Add("@iGrupo", SqlDbType.Tinyint).Value = Me.iGrupo

        Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
        If pCodInsert > 0 Then
            Me.iCodAnexoAdmisionTipo = pCodInsert
        Else
            Me.iCodAnexoAdmisionTipo = 0
        End If
    End Sub
    Public Sub InsertarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "INSERT into dbo.AnexoAdmisionTipo (cDetalle,cResumen,iGrupo ) VALUES(@cDetalle,@cResumen,@iGrupo); SELECT SCOPE_IDENTITY(); "
        cmdSQL.Parameters.Add("@cDetalle", SqlDbType.Varchar, 50).Value = Me.cDetalle
        cmdSQL.Parameters.Add("@cResumen", SqlDbType.Varchar, 50).Value = Me.cResumen
        cmdSQL.Parameters.Add("@iGrupo", SqlDbType.Tinyint).Value = Me.iGrupo

        Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
        If pCodInsert > 0 Then
            Me.iCodAnexoAdmisionTipo = pCodInsert
        Else
            Me.iCodAnexoAdmisionTipo = 0
        End If
    End Sub
    Public Sub Modificar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "UPDATE  dbo.AnexoAdmisionTipo SET cDetalle=@cDetalle,cResumen=@cResumen,iGrupo=@iGrupo WHERE iCodAnexoAdmisionTipo=@iCodAnexoAdmisionTipo"
        cmdSQL.Parameters.Add("@iCodAnexoAdmisionTipo", SqlDbType.Tinyint).Value = Me.iCodAnexoAdmisionTipo
        cmdSQL.Parameters.Add("@cDetalle", SqlDbType.Varchar, 50).Value = Me.cDetalle
        cmdSQL.Parameters.Add("@cResumen", SqlDbType.Varchar, 50).Value = Me.cResumen
        cmdSQL.Parameters.Add("@iGrupo", SqlDbType.Tinyint).Value = Me.iGrupo

        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub ModificarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "UPDATE  dbo.AnexoAdmisionTipo SET cDetalle=@cDetalle,cResumen=@cResumen,iGrupo=@iGrupo WHERE iCodAnexoAdmisionTipo=@iCodAnexoAdmisionTipo"
        cmdSQL.Parameters.Add("@iCodAnexoAdmisionTipo", SqlDbType.Tinyint).Value = Me.iCodAnexoAdmisionTipo
        cmdSQL.Parameters.Add("@cDetalle", SqlDbType.Varchar, 50).Value = Me.cDetalle
        cmdSQL.Parameters.Add("@cResumen", SqlDbType.Varchar, 50).Value = Me.cResumen
        cmdSQL.Parameters.Add("@iGrupo", SqlDbType.Tinyint).Value = Me.iGrupo

        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub Eliminar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "DELETE from  dbo.AnexoAdmisionTipo  WHERE iCodAnexoAdmisionTipo=@iCodAnexoAdmisionTipo"
        'cmdSQL.CommandText = "UPDATE dbo.AnexoAdmisionTipo  SET bAnulado=1 WHERE  iCodAnexoAdmisionTipo=@iCodAnexoAdmisionTipo"
        cmdSQL.Parameters.Add("@iCodAnexoAdmisionTipo", SqlDbType.Tinyint).Value = Me.iCodAnexoAdmisionTipo
        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub EliminarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "DELETE from  dbo.AnexoAdmisionTipo  WHERE iCodAnexoAdmisionTipo=@iCodAnexoAdmisionTipo"
        'cmdSQL.CommandText = "UPDATE dbo.AnexoAdmisionTipo  SET bAnulado=1 WHERE  iCodAnexoAdmisionTipo=@iCodAnexoAdmisionTipo"
        cmdSQL.Parameters.Add("@iCodAnexoAdmisionTipo", SqlDbType.Tinyint).Value = Me.iCodAnexoAdmisionTipo
        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub getRecord()
        Dim readers As IDataReader
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL

        If bTransaccion = True Then cmdSQL.Transaction = Me.mc.miTransact Else 

        cmdSQL.CommandText = "SELECT * FROM dbo.AnexoAdmisionTipo WHERE iCodAnexoAdmisionTipo=@iCodAnexoAdmisionTipo"
        cmdSQL.Parameters.Add("@iCodAnexoAdmisionTipo", SqlDbType.Tinyint).Value = Me.iCodAnexoAdmisionTipo
        readers = cmdSQL.ExecuteReader
        If readers.Read() Then
            Me.iCodAnexoAdmisionTipo = CStr(readers.GetValue(0))
            Me.cDetalle = CStr(readers.GetValue(1))
            Me.cResumen = CStr(readers.GetValue(2))
            Me.iGrupo = CStr(readers.GetValue(3))
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
        cmdSQL.CommandText = "SELECT * FROM dbo.AnexoAdmisionTipo"
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
    '********************************************
    Public Function ListaItems() As DataTable
        Dim Query As String
        Query = String.Format("SELECT iCodAnexoAdmisionTipo as ValueMember,cDetalle as DisplayMember FROM Anexoadmisiontipo")
        Return mc.ExecuteDataTable(Query)
    End Function
End Class
