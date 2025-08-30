Imports System.Data.SqlClient
Public Class Categoriabienesservicios
Public iCodCategoriaBienesServicios As String
Public iCodRubroBienesServicios As String
Public cCategoriaBienesServicios As String
Public iCodUsuarioCreacion As String
Public dFechaCreacion As String
Public iCodUsuarioModificacion As String
Public dFechaModificacion As String
Public qSelect As String
Public cTipoOpe as Char
Public bTransaccion as Boolean=False
Public mc as New ConnectSQL
 Public Function ListaDatos() As DataTable
	Dim Query As String
	Dim readers As DataTable
	Query = "SELECT * FROM prov.CategoriaBienesServicios"
	readers = mc.ExecuteDataTable(Query)
	Return readers
End Function
 Public Sub Insertar()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.CommandText ="INSERT into prov.CategoriaBienesServicios (iCodRubroBienesServicios,cCategoriaBienesServicios,iCodUsuarioCreacion,dFechaCreacion,iCodUsuarioModificacion,dFechaModificacion ) VALUES(@iCodRubroBienesServicios,@cCategoriaBienesServicios,@iCodUsuarioCreacion,@dFechaCreacion,@iCodUsuarioModificacion,@dFechaModificacion); SELECT SCOPE_IDENTITY(); "
	cmdSQL.Parameters.Add("@iCodRubroBienesServicios", SqlDbType.Int).Value = Me.iCodRubroBienesServicios
	cmdSQL.Parameters.Add("@cCategoriaBienesServicios", SqlDbType.Varchar,250).Value = Me.cCategoriaBienesServicios
	cmdSQL.Parameters.Add("@iCodUsuarioCreacion", SqlDbType.Int).Value = Me.iCodUsuarioCreacion
	cmdSQL.Parameters.Add("@dFechaCreacion", SqlDbType.Datetime).Value = Me.dFechaCreacion
	cmdSQL.Parameters.Add("@iCodUsuarioModificacion", SqlDbType.Int).Value = Me.iCodUsuarioModificacion
	cmdSQL.Parameters.Add("@dFechaModificacion", SqlDbType.Datetime).Value = Me.dFechaModificacion

	Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
	If pCodInsert > 0 Then
		Me.iCodCategoriaBienesServicios=pCodInsert
	Else
		Me.iCodCategoriaBienesServicios=0
	End If
End Sub
 Public Sub InsertarTransact()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.Transaction = Me.mc.miTransact 
	cmdSQL.CommandText ="INSERT into prov.CategoriaBienesServicios (iCodRubroBienesServicios,cCategoriaBienesServicios,iCodUsuarioCreacion,dFechaCreacion,iCodUsuarioModificacion,dFechaModificacion ) VALUES(@iCodRubroBienesServicios,@cCategoriaBienesServicios,@iCodUsuarioCreacion,@dFechaCreacion,@iCodUsuarioModificacion,@dFechaModificacion); SELECT SCOPE_IDENTITY(); "
	cmdSQL.Parameters.Add("@iCodRubroBienesServicios", SqlDbType.Int).Value = Me.iCodRubroBienesServicios
	cmdSQL.Parameters.Add("@cCategoriaBienesServicios", SqlDbType.Varchar,250).Value = Me.cCategoriaBienesServicios
	cmdSQL.Parameters.Add("@iCodUsuarioCreacion", SqlDbType.Int).Value = Me.iCodUsuarioCreacion
	cmdSQL.Parameters.Add("@dFechaCreacion", SqlDbType.Datetime).Value = Me.dFechaCreacion
	cmdSQL.Parameters.Add("@iCodUsuarioModificacion", SqlDbType.Int).Value = Me.iCodUsuarioModificacion
	cmdSQL.Parameters.Add("@dFechaModificacion", SqlDbType.Datetime).Value = Me.dFechaModificacion

	Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
	If pCodInsert > 0 Then
		Me.iCodCategoriaBienesServicios=pCodInsert
	Else
		Me.iCodCategoriaBienesServicios=0
	End If
End Sub
 Public Sub Modificar()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.CommandText = "UPDATE  prov.CategoriaBienesServicios SET iCodRubroBienesServicios=@iCodRubroBienesServicios,cCategoriaBienesServicios=@cCategoriaBienesServicios,iCodUsuarioCreacion=@iCodUsuarioCreacion,dFechaCreacion=@dFechaCreacion,iCodUsuarioModificacion=@iCodUsuarioModificacion,dFechaModificacion=@dFechaModificacion WHERE iCodCategoriaBienesServicios=@iCodCategoriaBienesServicios"
	cmdSQL.Parameters.Add("@iCodCategoriaBienesServicios", SqlDbType.Int).Value = Me.iCodCategoriaBienesServicios
	cmdSQL.Parameters.Add("@iCodRubroBienesServicios", SqlDbType.Int).Value = Me.iCodRubroBienesServicios
	cmdSQL.Parameters.Add("@cCategoriaBienesServicios", SqlDbType.Varchar,250).Value = Me.cCategoriaBienesServicios
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
	cmdSQL.CommandText = "UPDATE  prov.CategoriaBienesServicios SET iCodRubroBienesServicios=@iCodRubroBienesServicios,cCategoriaBienesServicios=@cCategoriaBienesServicios,iCodUsuarioCreacion=@iCodUsuarioCreacion,dFechaCreacion=@dFechaCreacion,iCodUsuarioModificacion=@iCodUsuarioModificacion,dFechaModificacion=@dFechaModificacion WHERE iCodCategoriaBienesServicios=@iCodCategoriaBienesServicios"
	cmdSQL.Parameters.Add("@iCodCategoriaBienesServicios", SqlDbType.Int).Value = Me.iCodCategoriaBienesServicios
	cmdSQL.Parameters.Add("@iCodRubroBienesServicios", SqlDbType.Int).Value = Me.iCodRubroBienesServicios
	cmdSQL.Parameters.Add("@cCategoriaBienesServicios", SqlDbType.Varchar,250).Value = Me.cCategoriaBienesServicios
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
	cmdSQL.CommandText = "DELETE from  prov.CategoriaBienesServicios  WHERE iCodCategoriaBienesServicios=@iCodCategoriaBienesServicios"
'cmdSQL.CommandText = "UPDATE prov.CategoriaBienesServicios  SET bAnulado=1 WHERE  iCodCategoriaBienesServicios=@iCodCategoriaBienesServicios"
cmdSQL.Parameters.Add("@iCodCategoriaBienesServicios", SqlDbType.Int).Value = Me.iCodCategoriaBienesServicios
	cmdSQL.ExecuteNonQuery()
End Sub
 Public Sub EliminarTransact()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.Transaction = Me.mc.miTransact 
	cmdSQL.CommandText = "DELETE from  prov.CategoriaBienesServicios  WHERE iCodCategoriaBienesServicios=@iCodCategoriaBienesServicios"
'cmdSQL.CommandText = "UPDATE prov.CategoriaBienesServicios  SET bAnulado=1 WHERE  iCodCategoriaBienesServicios=@iCodCategoriaBienesServicios"
cmdSQL.Parameters.Add("@iCodCategoriaBienesServicios", SqlDbType.Int).Value = Me.iCodCategoriaBienesServicios
	cmdSQL.ExecuteNonQuery()
End Sub
Public Sub getRecord()
	Dim readers As IDataReader
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	
	If bTransaccion=True Then cmdSQL.Transaction = Me.mc.miTransact Else 

	cmdSQL.CommandText = "SELECT * FROM prov.CategoriaBienesServicios WHERE iCodCategoriaBienesServicios=@iCodCategoriaBienesServicios"
	cmdSQL.Parameters.Add("@iCodCategoriaBienesServicios", SqlDbType.Int).Value = Me.iCodCategoriaBienesServicios
	readers = cmdSQL.ExecuteReader
	If readers.Read() Then
		Me.iCodCategoriaBienesServicios = CStr(readers.GetValue(0))
		Me.iCodRubroBienesServicios = CStr(readers.GetValue(1))
		Me.cCategoriaBienesServicios = CStr(readers.GetValue(2))
		Me.iCodUsuarioCreacion = CStr(readers.GetValue(3))
		Me.dFechaCreacion = CStr(readers.GetValue(4))
		Me.iCodUsuarioModificacion = CStr(readers.GetValue(5))
		Me.dFechaModificacion = CStr(readers.GetValue(6))
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
	cmdSQL.CommandText = "SELECT * FROM prov.CategoriaBienesServicios"
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
    '***************************************************
    Public Function ListaCategoriaBS() As DataTable
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = "prov.SP_DT_CategoriasBienesServicios"

        Dim readers As SqlDataReader
        readers = cmdSQL.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(readers)
        Return dt
    End Function
End Class
