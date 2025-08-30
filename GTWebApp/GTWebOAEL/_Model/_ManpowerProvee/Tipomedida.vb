Imports System.Data.SqlClient
Public Class Tipomedida
Public iCodTipoMedida As String
Public cNomMedida As String
Public cNomCorto As String
Public cCodigoSunat As String
Public bSunat As String
Public qSelect As String
Public cTipoOpe as Char
Public bTransaccion as Boolean=False
Public mc as New ConnectSQL
 Public Function ListaDatos() As DataTable
	Dim Query As String
	Dim readers As DataTable
	Query = "SELECT * FROM prov.TipoMedida"
	readers = mc.ExecuteDataTable(Query)
	Return readers
End Function
 Public Sub Insertar()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.CommandText ="INSERT into prov.TipoMedida (cNomMedida,cNomCorto,cCodigoSunat,bSunat ) VALUES(@cNomMedida,@cNomCorto,@cCodigoSunat,@bSunat); SELECT SCOPE_IDENTITY(); "
	cmdSQL.Parameters.Add("@cNomMedida", SqlDbType.Varchar,85).Value = Me.cNomMedida
	cmdSQL.Parameters.Add("@cNomCorto", SqlDbType.Varchar,50).Value = Me.cNomCorto
	cmdSQL.Parameters.Add("@cCodigoSunat", SqlDbType.Varchar,8).Value = Me.cCodigoSunat
	cmdSQL.Parameters.Add("@bSunat", SqlDbType.Bit).Value = Me.bSunat

	Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
	If pCodInsert > 0 Then
		Me.iCodTipoMedida=pCodInsert
	Else
		Me.iCodTipoMedida=0
	End If
End Sub
 Public Sub InsertarTransact()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.Transaction = Me.mc.miTransact 
	cmdSQL.CommandText ="INSERT into prov.TipoMedida (cNomMedida,cNomCorto,cCodigoSunat,bSunat ) VALUES(@cNomMedida,@cNomCorto,@cCodigoSunat,@bSunat); SELECT SCOPE_IDENTITY(); "
	cmdSQL.Parameters.Add("@cNomMedida", SqlDbType.Varchar,85).Value = Me.cNomMedida
	cmdSQL.Parameters.Add("@cNomCorto", SqlDbType.Varchar,50).Value = Me.cNomCorto
	cmdSQL.Parameters.Add("@cCodigoSunat", SqlDbType.Varchar,8).Value = Me.cCodigoSunat
	cmdSQL.Parameters.Add("@bSunat", SqlDbType.Bit).Value = Me.bSunat

	Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
	If pCodInsert > 0 Then
		Me.iCodTipoMedida=pCodInsert
	Else
		Me.iCodTipoMedida=0
	End If
End Sub
 Public Sub Modificar()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.CommandText = "UPDATE  prov.TipoMedida SET cNomMedida=@cNomMedida,cNomCorto=@cNomCorto,cCodigoSunat=@cCodigoSunat,bSunat=@bSunat WHERE iCodTipoMedida=@iCodTipoMedida"
	cmdSQL.Parameters.Add("@iCodTipoMedida", SqlDbType.Int).Value = Me.iCodTipoMedida
	cmdSQL.Parameters.Add("@cNomMedida", SqlDbType.Varchar,85).Value = Me.cNomMedida
	cmdSQL.Parameters.Add("@cNomCorto", SqlDbType.Varchar,50).Value = Me.cNomCorto
	cmdSQL.Parameters.Add("@cCodigoSunat", SqlDbType.Varchar,8).Value = Me.cCodigoSunat
	cmdSQL.Parameters.Add("@bSunat", SqlDbType.Bit).Value = Me.bSunat

	cmdSQL.ExecuteNonQuery()
End Sub
 Public Sub ModificarTransact()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.Transaction = Me.mc.miTransact 
	cmdSQL.CommandText = "UPDATE  prov.TipoMedida SET cNomMedida=@cNomMedida,cNomCorto=@cNomCorto,cCodigoSunat=@cCodigoSunat,bSunat=@bSunat WHERE iCodTipoMedida=@iCodTipoMedida"
	cmdSQL.Parameters.Add("@iCodTipoMedida", SqlDbType.Int).Value = Me.iCodTipoMedida
	cmdSQL.Parameters.Add("@cNomMedida", SqlDbType.Varchar,85).Value = Me.cNomMedida
	cmdSQL.Parameters.Add("@cNomCorto", SqlDbType.Varchar,50).Value = Me.cNomCorto
	cmdSQL.Parameters.Add("@cCodigoSunat", SqlDbType.Varchar,8).Value = Me.cCodigoSunat
	cmdSQL.Parameters.Add("@bSunat", SqlDbType.Bit).Value = Me.bSunat

	cmdSQL.ExecuteNonQuery()
End Sub
 Public Sub Eliminar()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.CommandText = "DELETE from  prov.TipoMedida  WHERE iCodTipoMedida=@iCodTipoMedida"
'cmdSQL.CommandText = "UPDATE prov.TipoMedida  SET bAnulado=1 WHERE  iCodTipoMedida=@iCodTipoMedida"
cmdSQL.Parameters.Add("@iCodTipoMedida", SqlDbType.Int).Value = Me.iCodTipoMedida
	cmdSQL.ExecuteNonQuery()
End Sub
 Public Sub EliminarTransact()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.Transaction = Me.mc.miTransact 
	cmdSQL.CommandText = "DELETE from  prov.TipoMedida  WHERE iCodTipoMedida=@iCodTipoMedida"
'cmdSQL.CommandText = "UPDATE prov.TipoMedida  SET bAnulado=1 WHERE  iCodTipoMedida=@iCodTipoMedida"
cmdSQL.Parameters.Add("@iCodTipoMedida", SqlDbType.Int).Value = Me.iCodTipoMedida
	cmdSQL.ExecuteNonQuery()
End Sub
Public Sub getRecord()
	Dim readers As IDataReader
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	
	If bTransaccion=True Then cmdSQL.Transaction = Me.mc.miTransact Else 

	cmdSQL.CommandText = "SELECT * FROM prov.TipoMedida WHERE iCodTipoMedida=@iCodTipoMedida"
	cmdSQL.Parameters.Add("@iCodTipoMedida", SqlDbType.Int).Value = Me.iCodTipoMedida
	readers = cmdSQL.ExecuteReader
	If readers.Read() Then
		Me.iCodTipoMedida = CStr(readers.GetValue(0))
		Me.cNomMedida = CStr(readers.GetValue(1))
		Me.cNomCorto = CStr(readers.GetValue(2))
		Me.cCodigoSunat = CStr(readers.GetValue(3))
		Me.bSunat = CStr(readers.GetValue(4))
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
	cmdSQL.CommandText = "SELECT * FROM prov.TipoMedida"
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
