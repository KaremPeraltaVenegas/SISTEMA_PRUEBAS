Imports System.Data.SqlClient
Public Class Usuariopermiso
Public iCodUsuarioPermiso As String
Public iCodUFormulario As String
Public iCodUsuarioSistema As String
Public bVisualizar As String
Public bAgregar As String
Public bGuardar As String
Public bEditar As String
Public bEliminar As String
Public iCodUsuario As String
	Public dFechaSis As String
	Public cTipoUsuario As String
	Public qSelect As String
Public cTipoOpe as Char
Public bTransaccion as Boolean=False
Public mc as New ConnectSQL
 Public Function ListaDatos() As DataTable
	Dim Query As String
	Dim readers As DataTable
	Query = "SELECT * FROM dbo.UsuarioPermiso"
	readers = mc.ExecuteDataTable(Query)
	Return readers
End Function
 Public Sub Insertar()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.CommandText ="INSERT into dbo.UsuarioPermiso (iCodUFormulario,iCodUsuarioSistema,bVisualizar,bAgregar,bGuardar,bEditar,bEliminar,iCodUsuario,dFechaSis ) VALUES(@iCodUFormulario,@iCodUsuarioSistema,@bVisualizar,@bAgregar,@bGuardar,@bEditar,@bEliminar,@iCodUsuario,@dFechaSis); SELECT SCOPE_IDENTITY(); "
	cmdSQL.Parameters.Add("@iCodUFormulario", SqlDbType.Int).Value = Me.iCodUFormulario
	cmdSQL.Parameters.Add("@iCodUsuarioSistema", SqlDbType.Int).Value = Me.iCodUsuarioSistema
	cmdSQL.Parameters.Add("@bVisualizar", SqlDbType.Bit).Value = Me.bVisualizar
	cmdSQL.Parameters.Add("@bAgregar", SqlDbType.Bit).Value = Me.bAgregar
	cmdSQL.Parameters.Add("@bGuardar", SqlDbType.Bit).Value = Me.bGuardar
	cmdSQL.Parameters.Add("@bEditar", SqlDbType.Bit).Value = Me.bEditar
	cmdSQL.Parameters.Add("@bEliminar", SqlDbType.Bit).Value = Me.bEliminar
	cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
	cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.Datetime).Value = Me.dFechaSis

	Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
	If pCodInsert > 0 Then
		Me.iCodUsuarioPermiso=pCodInsert
	Else
		Me.iCodUsuarioPermiso=0
	End If
End Sub
 Public Sub InsertarTransact()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.Transaction = Me.mc.miTransact 
	cmdSQL.CommandText ="INSERT into dbo.UsuarioPermiso (iCodUFormulario,iCodUsuarioSistema,bVisualizar,bAgregar,bGuardar,bEditar,bEliminar,iCodUsuario,dFechaSis ) VALUES(@iCodUFormulario,@iCodUsuarioSistema,@bVisualizar,@bAgregar,@bGuardar,@bEditar,@bEliminar,@iCodUsuario,@dFechaSis); SELECT SCOPE_IDENTITY(); "
	cmdSQL.Parameters.Add("@iCodUFormulario", SqlDbType.Int).Value = Me.iCodUFormulario
	cmdSQL.Parameters.Add("@iCodUsuarioSistema", SqlDbType.Int).Value = Me.iCodUsuarioSistema
	cmdSQL.Parameters.Add("@bVisualizar", SqlDbType.Bit).Value = Me.bVisualizar
	cmdSQL.Parameters.Add("@bAgregar", SqlDbType.Bit).Value = Me.bAgregar
	cmdSQL.Parameters.Add("@bGuardar", SqlDbType.Bit).Value = Me.bGuardar
	cmdSQL.Parameters.Add("@bEditar", SqlDbType.Bit).Value = Me.bEditar
	cmdSQL.Parameters.Add("@bEliminar", SqlDbType.Bit).Value = Me.bEliminar
	cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
	cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.Datetime).Value = Me.dFechaSis

	Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
	If pCodInsert > 0 Then
		Me.iCodUsuarioPermiso=pCodInsert
	Else
		Me.iCodUsuarioPermiso=0
	End If
End Sub
 Public Sub Modificar()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.CommandText = "UPDATE  dbo.UsuarioPermiso SET iCodUFormulario=@iCodUFormulario,iCodUsuarioSistema=@iCodUsuarioSistema,bVisualizar=@bVisualizar,bAgregar=@bAgregar,bGuardar=@bGuardar,bEditar=@bEditar,bEliminar=@bEliminar,iCodUsuario=@iCodUsuario,dFechaSis=@dFechaSis WHERE iCodUsuarioPermiso=@iCodUsuarioPermiso"
	cmdSQL.Parameters.Add("@iCodUsuarioPermiso", SqlDbType.Int).Value = Me.iCodUsuarioPermiso
	cmdSQL.Parameters.Add("@iCodUFormulario", SqlDbType.Int).Value = Me.iCodUFormulario
	cmdSQL.Parameters.Add("@iCodUsuarioSistema", SqlDbType.Int).Value = Me.iCodUsuarioSistema
	cmdSQL.Parameters.Add("@bVisualizar", SqlDbType.Bit).Value = Me.bVisualizar
	cmdSQL.Parameters.Add("@bAgregar", SqlDbType.Bit).Value = Me.bAgregar
	cmdSQL.Parameters.Add("@bGuardar", SqlDbType.Bit).Value = Me.bGuardar
	cmdSQL.Parameters.Add("@bEditar", SqlDbType.Bit).Value = Me.bEditar
	cmdSQL.Parameters.Add("@bEliminar", SqlDbType.Bit).Value = Me.bEliminar
	cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
	cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.Datetime).Value = Me.dFechaSis

	cmdSQL.ExecuteNonQuery()
End Sub
 Public Sub ModificarTransact()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.Transaction = Me.mc.miTransact 
	cmdSQL.CommandText = "UPDATE  dbo.UsuarioPermiso SET iCodUFormulario=@iCodUFormulario,iCodUsuarioSistema=@iCodUsuarioSistema,bVisualizar=@bVisualizar,bAgregar=@bAgregar,bGuardar=@bGuardar,bEditar=@bEditar,bEliminar=@bEliminar,iCodUsuario=@iCodUsuario,dFechaSis=@dFechaSis WHERE iCodUsuarioPermiso=@iCodUsuarioPermiso"
	cmdSQL.Parameters.Add("@iCodUsuarioPermiso", SqlDbType.Int).Value = Me.iCodUsuarioPermiso
	cmdSQL.Parameters.Add("@iCodUFormulario", SqlDbType.Int).Value = Me.iCodUFormulario
	cmdSQL.Parameters.Add("@iCodUsuarioSistema", SqlDbType.Int).Value = Me.iCodUsuarioSistema
	cmdSQL.Parameters.Add("@bVisualizar", SqlDbType.Bit).Value = Me.bVisualizar
	cmdSQL.Parameters.Add("@bAgregar", SqlDbType.Bit).Value = Me.bAgregar
	cmdSQL.Parameters.Add("@bGuardar", SqlDbType.Bit).Value = Me.bGuardar
	cmdSQL.Parameters.Add("@bEditar", SqlDbType.Bit).Value = Me.bEditar
	cmdSQL.Parameters.Add("@bEliminar", SqlDbType.Bit).Value = Me.bEliminar
	cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
	cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.Datetime).Value = Me.dFechaSis

	cmdSQL.ExecuteNonQuery()
End Sub
 Public Sub Eliminar()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.CommandText = "DELETE from  dbo.UsuarioPermiso  WHERE iCodUsuarioPermiso=@iCodUsuarioPermiso"
'cmdSQL.CommandText = "UPDATE dbo.UsuarioPermiso  SET bAnulado=1 WHERE  iCodUsuarioPermiso=@iCodUsuarioPermiso"
cmdSQL.Parameters.Add("@iCodUsuarioPermiso", SqlDbType.Int).Value = Me.iCodUsuarioPermiso
	cmdSQL.ExecuteNonQuery()
End Sub
 Public Sub EliminarTransact()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.Transaction = Me.mc.miTransact 
	cmdSQL.CommandText = "DELETE from  dbo.UsuarioPermiso  WHERE iCodUsuarioPermiso=@iCodUsuarioPermiso"
'cmdSQL.CommandText = "UPDATE dbo.UsuarioPermiso  SET bAnulado=1 WHERE  iCodUsuarioPermiso=@iCodUsuarioPermiso"
cmdSQL.Parameters.Add("@iCodUsuarioPermiso", SqlDbType.Int).Value = Me.iCodUsuarioPermiso
	cmdSQL.ExecuteNonQuery()
End Sub
Public Sub getRecord()
	Dim readers As IDataReader
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	
	If bTransaccion=True Then cmdSQL.Transaction = Me.mc.miTransact Else 

	cmdSQL.CommandText = "SELECT * FROM dbo.UsuarioPermiso WHERE iCodUsuarioPermiso=@iCodUsuarioPermiso"
	cmdSQL.Parameters.Add("@iCodUsuarioPermiso", SqlDbType.Int).Value = Me.iCodUsuarioPermiso
	readers = cmdSQL.ExecuteReader
	If readers.Read() Then
		Me.iCodUsuarioPermiso = CStr(readers.GetValue(0))
		Me.iCodUFormulario = CStr(readers.GetValue(1))
		Me.iCodUsuarioSistema = CStr(readers.GetValue(2))
		Me.bVisualizar = CStr(readers.GetValue(3))
		Me.bAgregar = CStr(readers.GetValue(4))
		Me.bGuardar = CStr(readers.GetValue(5))
		Me.bEditar = CStr(readers.GetValue(6))
		Me.bEliminar = CStr(readers.GetValue(7))
		Me.iCodUsuario = CStr(readers.GetValue(8))
		Me.dFechaSis = CStr(readers.GetValue(9))
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
	cmdSQL.CommandText = "SELECT * FROM dbo.UsuarioPermiso"
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

	Public Sub GenerarPermisosTransact()
		Dim cmdSQL As New SqlCommand("main.SP_INSER_GenerarPermisosPorUsuario", ConnectSQL.linkSQL)
		cmdSQL.CommandType = CommandType.StoredProcedure
		cmdSQL.Transaction = Me.mc.miTransact

		' Agregar parámetros
		cmdSQL.Parameters.Add("@iCodUsuarioSistema", SqlDbType.Int).Value = Me.iCodUsuarioSistema
		cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
		cmdSQL.Parameters.Add("@cTipoUsuario", SqlDbType.Char).Value = Me.cTipoUsuario

		cmdSQL.ExecuteNonQuery()
	End Sub

	Public Function VerificarTienePermisoPorNombrePagina(ByVal p_NombrePagina As String, p_CodUsuario As String) As Boolean

		Dim respuesta As Boolean
		Dim readers As SqlDataReader

		Dim cmdSQL As New SqlCommand
		cmdSQL.Parameters.Clear()
		cmdSQL.Connection = ConnectSQL.linkSQL
		cmdSQL.CommandType = CommandType.StoredProcedure
		cmdSQL.CommandText = "main.SP_COND_VerificarTienePermisoPorNombrePagina"
		cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = p_CodUsuario
		cmdSQL.Parameters.Add("@cNombrePagina", SqlDbType.VarChar).Value = p_NombrePagina

		readers = cmdSQL.ExecuteReader
		If readers.Read() Then
			respuesta = CBool(readers.GetValue(0))
		End If
		readers.Close()
		Return respuesta

	End Function
End Class
