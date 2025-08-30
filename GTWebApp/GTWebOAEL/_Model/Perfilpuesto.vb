Public Class Perfilpuesto
Public iCodPerfilPuesto As String
Public cNomPerfilPuesto As String
Public cNomCortoPerfilPuesto As String
Public cDesPerfilPuesto As String
Public cMOCMONC As String
Public dFechaCreacion As String
Public iCodUsuario As String
Public dFechaSistema As String
Public qSelect As String
Public cTipoOpe as Char
Public mc as New ConnectSQL
Public Function ListaDatos() As IDataReader
	Dim Query As String
	Dim readers As IDataReader
		Query = Me.qSelect 
	readers = mc.ExecuteReader(Query)
	Return readers
End Function
Public Function ListaDatosTable() As DataTable
	Dim Query As String
	Dim readers As DataTable
		Query = Me.qSelect 
	readers = mc.ExecuteDataTable(Query)
	Return readers
End Function
 Public Function ListaDatosShort() As DataTable
	Dim Query As String
	Dim readers As DataTable
	Query = "SELECT * FROM Perfilpuesto"
	readers = mc.ExecuteDataTable(Query)
	Return readers
End Function
 Public Sub Insertar()
	Dim Query As String
	Query = String.Format("INSERT into Perfilpuesto VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",Me.cNomPerfilPuesto,Me.cNomCortoPerfilPuesto,Me.cDesPerfilPuesto,Me.cMOCMONC,Me.dFechaCreacion,Me.iCodUsuario,Me.dFechaSistema)
	If mc.ExecuteQuery(Query) Then
	Me.iCodPerfilPuesto = Me.LastID()
	End If
End Sub
 Public Sub InsertarTransact()
	Dim Query As String
	Query = String.Format("INSERT into Perfilpuesto VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",Me.cNomPerfilPuesto,Me.cNomCortoPerfilPuesto,Me.cDesPerfilPuesto,Me.cMOCMONC,Me.dFechaCreacion,Me.iCodUsuario,Me.dFechaSistema)
	If mc.ExecuteQueryTransact(Query) Then
		Me.iCodPerfilPuesto = Me.LastIDT()
	End If
End Sub
 Public Sub Modificar()
	Dim Query As String
	Query = String.Format("UPDATE  Perfilpuesto SET cNomPerfilPuesto='{1}',cNomCortoPerfilPuesto='{2}',cDesPerfilPuesto='{3}',cMOCMONC='{4}',dFechaCreacion='{5}',iCodUsuario='{6}',dFechaSistema='{7}' WHERE iCodPerfilPuesto={0}", Me.iCodPerfilPuesto,Me.cNomPerfilPuesto,Me.cNomCortoPerfilPuesto,Me.cDesPerfilPuesto,Me.cMOCMONC,Me.dFechaCreacion,Me.iCodUsuario,Me.dFechaSistema)
	mc.ExecuteQuery(Query)
End Sub
 Public Sub ModificarTransact()
	Dim Query As String
	Query = String.Format("UPDATE  Perfilpuesto SET cNomPerfilPuesto='{1}',cNomCortoPerfilPuesto='{2}',cDesPerfilPuesto='{3}',cMOCMONC='{4}',dFechaCreacion='{5}',iCodUsuario='{6}',dFechaSistema='{7}' WHERE iCodPerfilPuesto={0}", Me.iCodPerfilPuesto,Me.cNomPerfilPuesto,Me.cNomCortoPerfilPuesto,Me.cDesPerfilPuesto,Me.cMOCMONC,Me.dFechaCreacion,Me.iCodUsuario,Me.dFechaSistema)
	mc.ExecuteQueryTransact(Query)
End Sub
 Public Sub Eliminar()
	Dim Query As String
	Query = String.Format("DELETE from Perfilpuesto WHERE iCodPerfilPuesto={0}", Me.iCodPerfilPuesto)
	'Query = String.Format("UPDATE Perfilpuesto SET bAnulado=1 WHERE iCodPerfilPuesto={0}", Me.iCodPerfilPuesto)
	mc.ExecuteQuery(Query)
End Sub
 Public Sub EliminarTransact()
	Dim Query As String
	Query = String.Format("DELETE from Perfilpuesto WHERE iCodPerfilPuesto={0}", Me.iCodPerfilPuesto)
	'Query = String.Format("UPDATE Perfilpuesto SET bAnulado=1 WHERE iCodPerfilPuesto={0}", Me.iCodPerfilPuesto)
	mc.ExecuteQueryTransact(Query)
End Sub
Public Sub getRecord()
	Dim Query As String
	Dim readers As IDataReader
	Query = String.Format("SELECT * FROM Perfilpuesto WHERE iCodPerfilPuesto={0}", Me.iCodPerfilPuesto)
	readers = mc.ExecuteGetRecord(Query)
	readers.Read()
		Me.iCodPerfilPuesto = CStr(readers.GetValue(0))
		Me.cNomPerfilPuesto = CStr(readers.GetValue(1))
		Me.cNomCortoPerfilPuesto = CStr(readers.GetValue(2))
		Me.cDesPerfilPuesto = CStr(readers.GetValue(3))
		Me.cMOCMONC = CStr(readers.GetValue(4))
		Me.dFechaCreacion = CStr(readers.GetValue(5))
		Me.iCodUsuario = CStr(readers.GetValue(6))
		Me.dFechaSistema = CStr(readers.GetValue(7))
		readers.Close()
End Sub
Public Function ListaDatosCombo() As DataTable
	Dim miDataTable As New DataTable
	Dim Query As String
	Dim readers As IDataReader
	miDataTable.Columns.Add("ValueMember")
	miDataTable.Columns.Add("DisplayMember")
	Query = String.Format("SELECT * FROM Perfilpuesto")
	readers = mc.ExecuteReader(Query)
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
