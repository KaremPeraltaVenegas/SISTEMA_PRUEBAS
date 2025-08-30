Imports System.Data.SqlClient
Public Class Catalogobienesservicios
    Public iCodCatalogoBienesServicios As String
    Public iCodRubroBienesServicios As String
    Public iCodCategoriaBienesServicios As String
    Public iCodTipoMedida As String
    Public cTipo As String
    Public cDetalleBienesServicios As String
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
        Query = "SELECT * FROM prov.CatalogoBienesServicios"
        readers = mc.ExecuteDataTable(Query)
        Return readers
    End Function
    Public Sub Insertar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "INSERT into prov.CatalogoBienesServicios (iCodRubroBienesServicios,iCodCategoriaBienesServicios,iCodTipoMedida,cTipo,cDetalleBienesServicios,iCodUsuarioCreacion,dFechaCreacion,iCodUsuarioModificacion,dFechaModificacion ) VALUES(@iCodRubroBienesServicios,@iCodCategoriaBienesServicios,@iCodTipoMedida,@cTipo,@cDetalleBienesServicios,@iCodUsuarioCreacion,@dFechaCreacion,@iCodUsuarioModificacion,@dFechaModificacion); SELECT SCOPE_IDENTITY(); "
        cmdSQL.Parameters.Add("@iCodRubroBienesServicios", SqlDbType.Int).Value = Me.iCodRubroBienesServicios
        cmdSQL.Parameters.Add("@iCodCategoriaBienesServicios", SqlDbType.Int).Value = Me.iCodCategoriaBienesServicios
        cmdSQL.Parameters.Add("@iCodTipoMedida", SqlDbType.Int).Value = Me.iCodTipoMedida
        cmdSQL.Parameters.Add("@cTipo", SqlDbType.Char, 1).Value = Me.cTipo
        cmdSQL.Parameters.Add("@cDetalleBienesServicios", SqlDbType.Varchar, -1).Value = Me.cDetalleBienesServicios
        cmdSQL.Parameters.Add("@iCodUsuarioCreacion", SqlDbType.Int).Value = Me.iCodUsuarioCreacion
        cmdSQL.Parameters.Add("@dFechaCreacion", SqlDbType.Datetime).Value = Me.dFechaCreacion
        cmdSQL.Parameters.Add("@iCodUsuarioModificacion", SqlDbType.Int).Value = Me.iCodUsuarioModificacion
        cmdSQL.Parameters.Add("@dFechaModificacion", SqlDbType.Datetime).Value = Me.dFechaModificacion

        Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
        If pCodInsert > 0 Then
            Me.iCodCatalogoBienesServicios = pCodInsert
        Else
            Me.iCodCatalogoBienesServicios = 0
        End If
    End Sub
    Public Sub InsertarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "INSERT into prov.CatalogoBienesServicios (iCodRubroBienesServicios,iCodCategoriaBienesServicios,iCodTipoMedida,cTipo,cDetalleBienesServicios,iCodUsuarioCreacion,dFechaCreacion,iCodUsuarioModificacion,dFechaModificacion ) VALUES(@iCodRubroBienesServicios,@iCodCategoriaBienesServicios,@iCodTipoMedida,@cTipo,@cDetalleBienesServicios,@iCodUsuarioCreacion,@dFechaCreacion,@iCodUsuarioModificacion,@dFechaModificacion); SELECT SCOPE_IDENTITY(); "
        cmdSQL.Parameters.Add("@iCodRubroBienesServicios", SqlDbType.Int).Value = Me.iCodRubroBienesServicios
        cmdSQL.Parameters.Add("@iCodCategoriaBienesServicios", SqlDbType.Int).Value = Me.iCodCategoriaBienesServicios
        cmdSQL.Parameters.Add("@iCodTipoMedida", SqlDbType.Int).Value = Me.iCodTipoMedida
        cmdSQL.Parameters.Add("@cTipo", SqlDbType.Char, 1).Value = Me.cTipo
        cmdSQL.Parameters.Add("@cDetalleBienesServicios", SqlDbType.Varchar, -1).Value = Me.cDetalleBienesServicios
        cmdSQL.Parameters.Add("@iCodUsuarioCreacion", SqlDbType.Int).Value = Me.iCodUsuarioCreacion
        cmdSQL.Parameters.Add("@dFechaCreacion", SqlDbType.Datetime).Value = Me.dFechaCreacion
        cmdSQL.Parameters.Add("@iCodUsuarioModificacion", SqlDbType.Int).Value = Me.iCodUsuarioModificacion
        cmdSQL.Parameters.Add("@dFechaModificacion", SqlDbType.Datetime).Value = Me.dFechaModificacion

        Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
        If pCodInsert > 0 Then
            Me.iCodCatalogoBienesServicios = pCodInsert
        Else
            Me.iCodCatalogoBienesServicios = 0
        End If
    End Sub
    Public Sub Modificar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "UPDATE  prov.CatalogoBienesServicios SET iCodRubroBienesServicios=@iCodRubroBienesServicios,iCodCategoriaBienesServicios=@iCodCategoriaBienesServicios,iCodTipoMedida=@iCodTipoMedida,cTipo=@cTipo,cDetalleBienesServicios=@cDetalleBienesServicios,iCodUsuarioCreacion=@iCodUsuarioCreacion,dFechaCreacion=@dFechaCreacion,iCodUsuarioModificacion=@iCodUsuarioModificacion,dFechaModificacion=@dFechaModificacion WHERE iCodCatalogoBienesServicios=@iCodCatalogoBienesServicios"
        cmdSQL.Parameters.Add("@iCodCatalogoBienesServicios", SqlDbType.Int).Value = Me.iCodCatalogoBienesServicios
        cmdSQL.Parameters.Add("@iCodRubroBienesServicios", SqlDbType.Int).Value = Me.iCodRubroBienesServicios
        cmdSQL.Parameters.Add("@iCodCategoriaBienesServicios", SqlDbType.Int).Value = Me.iCodCategoriaBienesServicios
        cmdSQL.Parameters.Add("@iCodTipoMedida", SqlDbType.Int).Value = Me.iCodTipoMedida
        cmdSQL.Parameters.Add("@cTipo", SqlDbType.Char, 1).Value = Me.cTipo
        cmdSQL.Parameters.Add("@cDetalleBienesServicios", SqlDbType.Varchar, -1).Value = Me.cDetalleBienesServicios
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
        cmdSQL.CommandText = "UPDATE  prov.CatalogoBienesServicios SET iCodRubroBienesServicios=@iCodRubroBienesServicios,iCodCategoriaBienesServicios=@iCodCategoriaBienesServicios,iCodTipoMedida=@iCodTipoMedida,cTipo=@cTipo,cDetalleBienesServicios=@cDetalleBienesServicios,iCodUsuarioCreacion=@iCodUsuarioCreacion,dFechaCreacion=@dFechaCreacion,iCodUsuarioModificacion=@iCodUsuarioModificacion,dFechaModificacion=@dFechaModificacion WHERE iCodCatalogoBienesServicios=@iCodCatalogoBienesServicios"
        cmdSQL.Parameters.Add("@iCodCatalogoBienesServicios", SqlDbType.Int).Value = Me.iCodCatalogoBienesServicios
        cmdSQL.Parameters.Add("@iCodRubroBienesServicios", SqlDbType.Int).Value = Me.iCodRubroBienesServicios
        cmdSQL.Parameters.Add("@iCodCategoriaBienesServicios", SqlDbType.Int).Value = Me.iCodCategoriaBienesServicios
        cmdSQL.Parameters.Add("@iCodTipoMedida", SqlDbType.Int).Value = Me.iCodTipoMedida
        cmdSQL.Parameters.Add("@cTipo", SqlDbType.Char, 1).Value = Me.cTipo
        cmdSQL.Parameters.Add("@cDetalleBienesServicios", SqlDbType.Varchar, -1).Value = Me.cDetalleBienesServicios
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
        cmdSQL.CommandText = "DELETE from  prov.CatalogoBienesServicios  WHERE iCodCatalogoBienesServicios=@iCodCatalogoBienesServicios"
        'cmdSQL.CommandText = "UPDATE prov.CatalogoBienesServicios  SET bAnulado=1 WHERE  iCodCatalogoBienesServicios=@iCodCatalogoBienesServicios"
        cmdSQL.Parameters.Add("@iCodCatalogoBienesServicios", SqlDbType.Int).Value = Me.iCodCatalogoBienesServicios
        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub EliminarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "DELETE from  prov.CatalogoBienesServicios  WHERE iCodCatalogoBienesServicios=@iCodCatalogoBienesServicios"
        'cmdSQL.CommandText = "UPDATE prov.CatalogoBienesServicios  SET bAnulado=1 WHERE  iCodCatalogoBienesServicios=@iCodCatalogoBienesServicios"
        cmdSQL.Parameters.Add("@iCodCatalogoBienesServicios", SqlDbType.Int).Value = Me.iCodCatalogoBienesServicios
        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub getRecord()
        Dim readers As IDataReader
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL

        If bTransaccion = True Then cmdSQL.Transaction = Me.mc.miTransact Else 

        cmdSQL.CommandText = "SELECT * FROM prov.CatalogoBienesServicios WHERE iCodCatalogoBienesServicios=@iCodCatalogoBienesServicios"
        cmdSQL.Parameters.Add("@iCodCatalogoBienesServicios", SqlDbType.Int).Value = Me.iCodCatalogoBienesServicios
        readers = cmdSQL.ExecuteReader
        If readers.Read() Then
            Me.iCodCatalogoBienesServicios = CStr(readers.GetValue(0))
            Me.iCodRubroBienesServicios = CStr(readers.GetValue(1))
            Me.iCodCategoriaBienesServicios = CStr(readers.GetValue(2))
            Me.iCodTipoMedida = CStr(readers.GetValue(3))
            Me.cTipo = CStr(readers.GetValue(4))
            Me.cDetalleBienesServicios = CStr(readers.GetValue(5))
            Me.iCodUsuarioCreacion = CStr(readers.GetValue(6))
            Me.dFechaCreacion = CStr(readers.GetValue(7))
            Me.iCodUsuarioModificacion = CStr(readers.GetValue(8))
            Me.dFechaModificacion = CStr(readers.GetValue(9))
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
	cmdSQL.CommandText = "SELECT * FROM prov.CatalogoBienesServicios"
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
    '***********************************************
    Public Function ListaTipo() As DataTable
        Dim miDataTable As New DataTable
        miDataTable.Columns.Add("ValueMember")
        miDataTable.Columns.Add("DisplayMember")
        With miDataTable
            .Rows.Add("B", "BIENES")
            .Rows.Add("S", "SERVICIOS")
             
        End With
        Return miDataTable
    End Function
    'Public Function ListaCatalogoBS() As DataTable
    '    Dim miDataTable As New DataTable
    '    Dim readers As IDataReader
    '    miDataTable.Columns.Add("ValueMember")
    '    miDataTable.Columns.Add("DisplayMember")
    '    Dim cmdSQL As New SqlCommand
    '    cmdSQL.Parameters.Clear()
    '    cmdSQL.Connection = ConnectSQL.linkSQL
    '    cmdSQL.CommandText = "SELECT * FROM prov.CatalogoBienesServicios"
    '    readers = cmdSQL.ExecuteReader
    '    While readers.Read()
    '        miDataTable.Rows.Add(CStr(readers.GetValue(0)), CStr(readers.GetValue(4)))
    '    End While
    '    readers.Close()
    '    Return miDataTable
    'End Function
    Public Function ListaCatalogoBS() As DataTable

        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = "prov.SP_DT_CatalogoBienesServicios"

        Dim readers As SqlDataReader
        readers = cmdSQL.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(readers)
        Return dt
    End Function
End Class
