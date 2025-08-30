Imports System.Data.SqlClient
Public Class Rubrobienesservicios
Public iCodRubroBienesServicios As String
Public cRubroBienesServicios As String
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
	Query = "SELECT * FROM prov.RubroBienesServicios"
	readers = mc.ExecuteDataTable(Query)
	Return readers
End Function
 Public Sub Insertar()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.CommandText ="INSERT into prov.RubroBienesServicios (cRubroBienesServicios,iCodUsuarioCreacion,dFechaCreacion,iCodUsuarioModificacion,dFechaModificacion ) VALUES(@cRubroBienesServicios,@iCodUsuarioCreacion,@dFechaCreacion,@iCodUsuarioModificacion,@dFechaModificacion); SELECT SCOPE_IDENTITY(); "
	cmdSQL.Parameters.Add("@cRubroBienesServicios", SqlDbType.Varchar,200).Value = Me.cRubroBienesServicios
	cmdSQL.Parameters.Add("@iCodUsuarioCreacion", SqlDbType.Int).Value = Me.iCodUsuarioCreacion
	cmdSQL.Parameters.Add("@dFechaCreacion", SqlDbType.Datetime).Value = Me.dFechaCreacion
	cmdSQL.Parameters.Add("@iCodUsuarioModificacion", SqlDbType.Int).Value = Me.iCodUsuarioModificacion
	cmdSQL.Parameters.Add("@dFechaModificacion", SqlDbType.Datetime).Value = Me.dFechaModificacion

	Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
	If pCodInsert > 0 Then
		Me.iCodRubroBienesServicios=pCodInsert
	Else
		Me.iCodRubroBienesServicios=0
	End If
End Sub
 Public Sub InsertarTransact()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.Transaction = Me.mc.miTransact 
	cmdSQL.CommandText ="INSERT into prov.RubroBienesServicios (cRubroBienesServicios,iCodUsuarioCreacion,dFechaCreacion,iCodUsuarioModificacion,dFechaModificacion ) VALUES(@cRubroBienesServicios,@iCodUsuarioCreacion,@dFechaCreacion,@iCodUsuarioModificacion,@dFechaModificacion); SELECT SCOPE_IDENTITY(); "
	cmdSQL.Parameters.Add("@cRubroBienesServicios", SqlDbType.Varchar,200).Value = Me.cRubroBienesServicios
	cmdSQL.Parameters.Add("@iCodUsuarioCreacion", SqlDbType.Int).Value = Me.iCodUsuarioCreacion
	cmdSQL.Parameters.Add("@dFechaCreacion", SqlDbType.Datetime).Value = Me.dFechaCreacion
	cmdSQL.Parameters.Add("@iCodUsuarioModificacion", SqlDbType.Int).Value = Me.iCodUsuarioModificacion
	cmdSQL.Parameters.Add("@dFechaModificacion", SqlDbType.Datetime).Value = Me.dFechaModificacion

	Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
	If pCodInsert > 0 Then
		Me.iCodRubroBienesServicios=pCodInsert
	Else
		Me.iCodRubroBienesServicios=0
	End If
End Sub
 Public Sub Modificar()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.CommandText = "UPDATE  prov.RubroBienesServicios SET cRubroBienesServicios=@cRubroBienesServicios,iCodUsuarioCreacion=@iCodUsuarioCreacion,dFechaCreacion=@dFechaCreacion,iCodUsuarioModificacion=@iCodUsuarioModificacion,dFechaModificacion=@dFechaModificacion WHERE iCodRubroBienesServicios=@iCodRubroBienesServicios"
	cmdSQL.Parameters.Add("@iCodRubroBienesServicios", SqlDbType.Int).Value = Me.iCodRubroBienesServicios
	cmdSQL.Parameters.Add("@cRubroBienesServicios", SqlDbType.Varchar,200).Value = Me.cRubroBienesServicios
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
	cmdSQL.CommandText = "UPDATE  prov.RubroBienesServicios SET cRubroBienesServicios=@cRubroBienesServicios,iCodUsuarioCreacion=@iCodUsuarioCreacion,dFechaCreacion=@dFechaCreacion,iCodUsuarioModificacion=@iCodUsuarioModificacion,dFechaModificacion=@dFechaModificacion WHERE iCodRubroBienesServicios=@iCodRubroBienesServicios"
	cmdSQL.Parameters.Add("@iCodRubroBienesServicios", SqlDbType.Int).Value = Me.iCodRubroBienesServicios
	cmdSQL.Parameters.Add("@cRubroBienesServicios", SqlDbType.Varchar,200).Value = Me.cRubroBienesServicios
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
	cmdSQL.CommandText = "DELETE from  prov.RubroBienesServicios  WHERE iCodRubroBienesServicios=@iCodRubroBienesServicios"
'cmdSQL.CommandText = "UPDATE prov.RubroBienesServicios  SET bAnulado=1 WHERE  iCodRubroBienesServicios=@iCodRubroBienesServicios"
cmdSQL.Parameters.Add("@iCodRubroBienesServicios", SqlDbType.Int).Value = Me.iCodRubroBienesServicios
	cmdSQL.ExecuteNonQuery()
End Sub
 Public Sub EliminarTransact()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.Transaction = Me.mc.miTransact 
	cmdSQL.CommandText = "DELETE from  prov.RubroBienesServicios  WHERE iCodRubroBienesServicios=@iCodRubroBienesServicios"
'cmdSQL.CommandText = "UPDATE prov.RubroBienesServicios  SET bAnulado=1 WHERE  iCodRubroBienesServicios=@iCodRubroBienesServicios"
cmdSQL.Parameters.Add("@iCodRubroBienesServicios", SqlDbType.Int).Value = Me.iCodRubroBienesServicios
	cmdSQL.ExecuteNonQuery()
End Sub
Public Sub getRecord()
	Dim readers As IDataReader
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	
	If bTransaccion=True Then cmdSQL.Transaction = Me.mc.miTransact Else 

	cmdSQL.CommandText = "SELECT * FROM prov.RubroBienesServicios WHERE iCodRubroBienesServicios=@iCodRubroBienesServicios"
	cmdSQL.Parameters.Add("@iCodRubroBienesServicios", SqlDbType.Int).Value = Me.iCodRubroBienesServicios
	readers = cmdSQL.ExecuteReader
	If readers.Read() Then
		Me.iCodRubroBienesServicios = CStr(readers.GetValue(0))
		Me.cRubroBienesServicios = CStr(readers.GetValue(1))
		Me.iCodUsuarioCreacion = CStr(readers.GetValue(2))
		Me.dFechaCreacion = CStr(readers.GetValue(3))
		Me.iCodUsuarioModificacion = CStr(readers.GetValue(4))
		Me.dFechaModificacion = CStr(readers.GetValue(5))
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
	cmdSQL.CommandText = "SELECT * FROM prov.RubroBienesServicios"
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
