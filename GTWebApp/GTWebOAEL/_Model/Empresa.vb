Public Class Empresa
Public iCodEmpresa As String
Public cRUC As String
Public cRazonSocial As String
Public cNomComercial As String
Public cTipo As String
Public cFonoCorporativo As String
Public cNomContacto As String
Public cFonoContacto As String
Public cCorreoContacto As String
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
	Query = "SELECT * FROM Empresa"
	readers = mc.ExecuteDataTable(Query)
	Return readers
End Function
 Public Sub Insertar()
	Dim Query As String
	Query = String.Format("INSERT into Empresa VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')",Me.cRUC,Me.cRazonSocial,Me.cNomComercial,Me.cTipo,Me.cFonoCorporativo,Me.cNomContacto,Me.cFonoContacto,Me.cCorreoContacto,Me.dFechaCreacion,Me.iCodUsuario,Me.dFechaSistema)
	If mc.ExecuteQuery(Query) Then
	Me.iCodEmpresa = Me.LastID()
	End If
End Sub
 Public Sub InsertarTransact()
	Dim Query As String
	Query = String.Format("INSERT into Empresa VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')",Me.cRUC,Me.cRazonSocial,Me.cNomComercial,Me.cTipo,Me.cFonoCorporativo,Me.cNomContacto,Me.cFonoContacto,Me.cCorreoContacto,Me.dFechaCreacion,Me.iCodUsuario,Me.dFechaSistema)
	If mc.ExecuteQueryTransact(Query) Then
		Me.iCodEmpresa = Me.LastIDT()
	End If
End Sub
 Public Sub Modificar()
	Dim Query As String
	Query = String.Format("UPDATE  Empresa SET cRUC='{1}',cRazonSocial='{2}',cNomComercial='{3}',cTipo='{4}',cFonoCorporativo='{5}',cNomContacto='{6}',cFonoContacto='{7}',cCorreoContacto='{8}',dFechaCreacion='{9}',iCodUsuario='{10}',dFechaSistema='{11}' WHERE iCodEmpresa={0}", Me.iCodEmpresa,Me.cRUC,Me.cRazonSocial,Me.cNomComercial,Me.cTipo,Me.cFonoCorporativo,Me.cNomContacto,Me.cFonoContacto,Me.cCorreoContacto,Me.dFechaCreacion,Me.iCodUsuario,Me.dFechaSistema)
	mc.ExecuteQuery(Query)
End Sub
 Public Sub ModificarTransact()
	Dim Query As String
	Query = String.Format("UPDATE  Empresa SET cRUC='{1}',cRazonSocial='{2}',cNomComercial='{3}',cTipo='{4}',cFonoCorporativo='{5}',cNomContacto='{6}',cFonoContacto='{7}',cCorreoContacto='{8}',dFechaCreacion='{9}',iCodUsuario='{10}',dFechaSistema='{11}' WHERE iCodEmpresa={0}", Me.iCodEmpresa,Me.cRUC,Me.cRazonSocial,Me.cNomComercial,Me.cTipo,Me.cFonoCorporativo,Me.cNomContacto,Me.cFonoContacto,Me.cCorreoContacto,Me.dFechaCreacion,Me.iCodUsuario,Me.dFechaSistema)
	mc.ExecuteQueryTransact(Query)
End Sub
 Public Sub Eliminar()
	Dim Query As String
	Query = String.Format("DELETE from Empresa WHERE iCodEmpresa={0}", Me.iCodEmpresa)
	'Query = String.Format("UPDATE Empresa SET bAnulado=1 WHERE iCodEmpresa={0}", Me.iCodEmpresa)
	mc.ExecuteQuery(Query)
End Sub
 Public Sub EliminarTransact()
	Dim Query As String
	Query = String.Format("DELETE from Empresa WHERE iCodEmpresa={0}", Me.iCodEmpresa)
	'Query = String.Format("UPDATE Empresa SET bAnulado=1 WHERE iCodEmpresa={0}", Me.iCodEmpresa)
	mc.ExecuteQueryTransact(Query)
End Sub
Public Sub getRecord()
	Dim Query As String
	Dim readers As IDataReader
	Query = String.Format("SELECT * FROM Empresa WHERE iCodEmpresa={0}", Me.iCodEmpresa)
	readers = mc.ExecuteGetRecord(Query)
	readers.Read()
		Me.iCodEmpresa = CStr(readers.GetValue(0))
		Me.cRUC = CStr(readers.GetValue(1))
		Me.cRazonSocial = CStr(readers.GetValue(2))
		Me.cNomComercial = CStr(readers.GetValue(3))
		Me.cTipo = CStr(readers.GetValue(4))
		Me.cFonoCorporativo = CStr(readers.GetValue(5))
		Me.cNomContacto = CStr(readers.GetValue(6))
		Me.cFonoContacto = CStr(readers.GetValue(7))
		Me.cCorreoContacto = CStr(readers.GetValue(8))
		Me.dFechaCreacion = CStr(readers.GetValue(9))
		Me.iCodUsuario = CStr(readers.GetValue(10))
		Me.dFechaSistema = CStr(readers.GetValue(11))
		readers.Close()
End Sub
Public Function ListaDatosCombo() As DataTable
	Dim miDataTable As New DataTable
	Dim Query As String
	Dim readers As IDataReader
	miDataTable.Columns.Add("ValueMember")
	miDataTable.Columns.Add("DisplayMember")
	Query = String.Format("SELECT * FROM Empresa")
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

 
    Public Function ListaEmpresas() As DataTable
        Dim Query As String
        Dim readers As DataTable
        Query = "Select iCodEmpresa,cRazonSocial from Empresa"
        readers = mc.ExecuteDataTable(Query)
        Return readers
    End Function

End Class
