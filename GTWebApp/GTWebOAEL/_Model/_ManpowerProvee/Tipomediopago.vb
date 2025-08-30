Imports System.Data.SqlClient
Public Class Tipomediopago
Public iCodTipoMedioPago As String
Public cCorrelativoSunat As String
Public cDetalle As String
Public qSelect As String
Public cTipoOpe as Char
Public bTransaccion as Boolean=False
Public mc as New ConnectSQL
 Public Function ListaDatos() As DataTable
	Dim Query As String
	Dim readers As DataTable
	Query = "SELECT * FROM prov.TipoMedioPago"
	readers = mc.ExecuteDataTable(Query)
	Return readers
End Function
 Public Sub Insertar()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.CommandText ="INSERT into prov.TipoMedioPago (cCorrelativoSunat,cDetalle ) VALUES(@cCorrelativoSunat,@cDetalle); SELECT SCOPE_IDENTITY(); "
	cmdSQL.Parameters.Add("@cCorrelativoSunat", SqlDbType.Varchar,50).Value = Me.cCorrelativoSunat
	cmdSQL.Parameters.Add("@cDetalle", SqlDbType.Varchar,250).Value = Me.cDetalle

	Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
	If pCodInsert > 0 Then
		Me.iCodTipoMedioPago=pCodInsert
	Else
		Me.iCodTipoMedioPago=0
	End If
End Sub
 Public Sub InsertarTransact()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.Transaction = Me.mc.miTransact 
	cmdSQL.CommandText ="INSERT into prov.TipoMedioPago (cCorrelativoSunat,cDetalle ) VALUES(@cCorrelativoSunat,@cDetalle); SELECT SCOPE_IDENTITY(); "
	cmdSQL.Parameters.Add("@cCorrelativoSunat", SqlDbType.Varchar,50).Value = Me.cCorrelativoSunat
	cmdSQL.Parameters.Add("@cDetalle", SqlDbType.Varchar,250).Value = Me.cDetalle

	Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
	If pCodInsert > 0 Then
		Me.iCodTipoMedioPago=pCodInsert
	Else
		Me.iCodTipoMedioPago=0
	End If
End Sub
 Public Sub Modificar()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.CommandText = "UPDATE  prov.TipoMedioPago SET cCorrelativoSunat=@cCorrelativoSunat,cDetalle=@cDetalle WHERE iCodTipoMedioPago=@iCodTipoMedioPago"
	cmdSQL.Parameters.Add("@iCodTipoMedioPago", SqlDbType.Tinyint).Value = Me.iCodTipoMedioPago
	cmdSQL.Parameters.Add("@cCorrelativoSunat", SqlDbType.Varchar,50).Value = Me.cCorrelativoSunat
	cmdSQL.Parameters.Add("@cDetalle", SqlDbType.Varchar,250).Value = Me.cDetalle

	cmdSQL.ExecuteNonQuery()
End Sub
 Public Sub ModificarTransact()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.Transaction = Me.mc.miTransact 
	cmdSQL.CommandText = "UPDATE  prov.TipoMedioPago SET cCorrelativoSunat=@cCorrelativoSunat,cDetalle=@cDetalle WHERE iCodTipoMedioPago=@iCodTipoMedioPago"
	cmdSQL.Parameters.Add("@iCodTipoMedioPago", SqlDbType.Tinyint).Value = Me.iCodTipoMedioPago
	cmdSQL.Parameters.Add("@cCorrelativoSunat", SqlDbType.Varchar,50).Value = Me.cCorrelativoSunat
	cmdSQL.Parameters.Add("@cDetalle", SqlDbType.Varchar,250).Value = Me.cDetalle

	cmdSQL.ExecuteNonQuery()
End Sub
 Public Sub Eliminar()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.CommandText = "DELETE from  prov.TipoMedioPago  WHERE iCodTipoMedioPago=@iCodTipoMedioPago"
'cmdSQL.CommandText = "UPDATE prov.TipoMedioPago  SET bAnulado=1 WHERE  iCodTipoMedioPago=@iCodTipoMedioPago"
cmdSQL.Parameters.Add("@iCodTipoMedioPago", SqlDbType.Tinyint).Value = Me.iCodTipoMedioPago
	cmdSQL.ExecuteNonQuery()
End Sub
 Public Sub EliminarTransact()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.Transaction = Me.mc.miTransact 
	cmdSQL.CommandText = "DELETE from  prov.TipoMedioPago  WHERE iCodTipoMedioPago=@iCodTipoMedioPago"
'cmdSQL.CommandText = "UPDATE prov.TipoMedioPago  SET bAnulado=1 WHERE  iCodTipoMedioPago=@iCodTipoMedioPago"
cmdSQL.Parameters.Add("@iCodTipoMedioPago", SqlDbType.Tinyint).Value = Me.iCodTipoMedioPago
	cmdSQL.ExecuteNonQuery()
End Sub
Public Sub getRecord()
	Dim readers As IDataReader
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	
	If bTransaccion=True Then cmdSQL.Transaction = Me.mc.miTransact Else 

	cmdSQL.CommandText = "SELECT * FROM prov.TipoMedioPago WHERE iCodTipoMedioPago=@iCodTipoMedioPago"
	cmdSQL.Parameters.Add("@iCodTipoMedioPago", SqlDbType.Tinyint).Value = Me.iCodTipoMedioPago
	readers = cmdSQL.ExecuteReader
	If readers.Read() Then
		Me.iCodTipoMedioPago = CStr(readers.GetValue(0))
		Me.cCorrelativoSunat = CStr(readers.GetValue(1))
		Me.cDetalle = CStr(readers.GetValue(2))
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
	cmdSQL.CommandText = "SELECT * FROM prov.TipoMedioPago"
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
