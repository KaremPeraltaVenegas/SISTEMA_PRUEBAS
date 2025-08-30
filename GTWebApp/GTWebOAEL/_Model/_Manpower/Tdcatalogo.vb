Imports System.Data.SqlClient
Public Class Tdcatalogo
Public iCodTDCatalogo As String
Public cTabla As String
Public cNombreGrupo As String
Public iOrden As String
Public cValueMember As String
Public cDisplayMember As String
Public cValor As String
Public qSelect As String
Public cTipoOpe as Char
Public bTransaccion as Boolean=False
Public mc as New ConnectSQL
 Public Function ListaDatos() As DataTable
	Dim Query As String
	Dim readers As DataTable
	Query = "SELECT * FROM dbo.TDCatalogo"
	readers = mc.ExecuteDataTable(Query)
	Return readers
End Function
 Public Sub Insertar()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.CommandText ="INSERT into dbo.TDCatalogo (cTabla,cNombreGrupo,iOrden,cValueMember,cDisplayMember,cValor ) VALUES(@cTabla,@cNombreGrupo,@iOrden,@cValueMember,@cDisplayMember,@cValor); SELECT SCOPE_IDENTITY(); "
	cmdSQL.Parameters.Add("@cTabla", SqlDbType.Varchar,30).Value = Me.cTabla
	cmdSQL.Parameters.Add("@cNombreGrupo", SqlDbType.Varchar,50).Value = Me.cNombreGrupo
	cmdSQL.Parameters.Add("@iOrden", SqlDbType.Tinyint).Value = Me.iOrden
	cmdSQL.Parameters.Add("@cValueMember", SqlDbType.Varchar,200).Value = Me.cValueMember
	cmdSQL.Parameters.Add("@cDisplayMember", SqlDbType.Varchar,200).Value = Me.cDisplayMember
	cmdSQL.Parameters.Add("@cValor", SqlDbType.Varchar,50).Value = Me.cValor

	Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
	If pCodInsert > 0 Then
		Me.iCodTDCatalogo=pCodInsert
	Else
		Me.iCodTDCatalogo=0
	End If
End Sub
 Public Sub InsertarTransact()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.Transaction = Me.mc.miTransact 
	cmdSQL.CommandText ="INSERT into dbo.TDCatalogo (cTabla,cNombreGrupo,iOrden,cValueMember,cDisplayMember,cValor ) VALUES(@cTabla,@cNombreGrupo,@iOrden,@cValueMember,@cDisplayMember,@cValor); SELECT SCOPE_IDENTITY(); "
	cmdSQL.Parameters.Add("@cTabla", SqlDbType.Varchar,30).Value = Me.cTabla
	cmdSQL.Parameters.Add("@cNombreGrupo", SqlDbType.Varchar,50).Value = Me.cNombreGrupo
	cmdSQL.Parameters.Add("@iOrden", SqlDbType.Tinyint).Value = Me.iOrden
	cmdSQL.Parameters.Add("@cValueMember", SqlDbType.Varchar,200).Value = Me.cValueMember
	cmdSQL.Parameters.Add("@cDisplayMember", SqlDbType.Varchar,200).Value = Me.cDisplayMember
	cmdSQL.Parameters.Add("@cValor", SqlDbType.Varchar,50).Value = Me.cValor

	Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
	If pCodInsert > 0 Then
		Me.iCodTDCatalogo=pCodInsert
	Else
		Me.iCodTDCatalogo=0
	End If
End Sub
 Public Sub Modificar()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.CommandText = "UPDATE  dbo.TDCatalogo SET cTabla=@cTabla,cNombreGrupo=@cNombreGrupo,iOrden=@iOrden,cValueMember=@cValueMember,cDisplayMember=@cDisplayMember,cValor=@cValor WHERE iCodTDCatalogo=@iCodTDCatalogo"
	cmdSQL.Parameters.Add("@iCodTDCatalogo", SqlDbType.Int).Value = Me.iCodTDCatalogo
	cmdSQL.Parameters.Add("@cTabla", SqlDbType.Varchar,30).Value = Me.cTabla
	cmdSQL.Parameters.Add("@cNombreGrupo", SqlDbType.Varchar,50).Value = Me.cNombreGrupo
	cmdSQL.Parameters.Add("@iOrden", SqlDbType.Tinyint).Value = Me.iOrden
	cmdSQL.Parameters.Add("@cValueMember", SqlDbType.Varchar,200).Value = Me.cValueMember
	cmdSQL.Parameters.Add("@cDisplayMember", SqlDbType.Varchar,200).Value = Me.cDisplayMember
	cmdSQL.Parameters.Add("@cValor", SqlDbType.Varchar,50).Value = Me.cValor

	cmdSQL.ExecuteNonQuery()
End Sub
 Public Sub ModificarTransact()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.Transaction = Me.mc.miTransact 
	cmdSQL.CommandText = "UPDATE  dbo.TDCatalogo SET cTabla=@cTabla,cNombreGrupo=@cNombreGrupo,iOrden=@iOrden,cValueMember=@cValueMember,cDisplayMember=@cDisplayMember,cValor=@cValor WHERE iCodTDCatalogo=@iCodTDCatalogo"
	cmdSQL.Parameters.Add("@iCodTDCatalogo", SqlDbType.Int).Value = Me.iCodTDCatalogo
	cmdSQL.Parameters.Add("@cTabla", SqlDbType.Varchar,30).Value = Me.cTabla
	cmdSQL.Parameters.Add("@cNombreGrupo", SqlDbType.Varchar,50).Value = Me.cNombreGrupo
	cmdSQL.Parameters.Add("@iOrden", SqlDbType.Tinyint).Value = Me.iOrden
	cmdSQL.Parameters.Add("@cValueMember", SqlDbType.Varchar,200).Value = Me.cValueMember
	cmdSQL.Parameters.Add("@cDisplayMember", SqlDbType.Varchar,200).Value = Me.cDisplayMember
	cmdSQL.Parameters.Add("@cValor", SqlDbType.Varchar,50).Value = Me.cValor

	cmdSQL.ExecuteNonQuery()
End Sub
 Public Sub Eliminar()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.CommandText = "DELETE from  dbo.TDCatalogo  WHERE iCodTDCatalogo=@iCodTDCatalogo"
'cmdSQL.CommandText = "UPDATE dbo.TDCatalogo  SET bAnulado=1 WHERE  iCodTDCatalogo=@iCodTDCatalogo"
cmdSQL.Parameters.Add("@iCodTDCatalogo", SqlDbType.Int).Value = Me.iCodTDCatalogo
	cmdSQL.ExecuteNonQuery()
End Sub
 Public Sub EliminarTransact()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.Transaction = Me.mc.miTransact 
	cmdSQL.CommandText = "DELETE from  dbo.TDCatalogo  WHERE iCodTDCatalogo=@iCodTDCatalogo"
'cmdSQL.CommandText = "UPDATE dbo.TDCatalogo  SET bAnulado=1 WHERE  iCodTDCatalogo=@iCodTDCatalogo"
cmdSQL.Parameters.Add("@iCodTDCatalogo", SqlDbType.Int).Value = Me.iCodTDCatalogo
	cmdSQL.ExecuteNonQuery()
End Sub
Public Sub getRecord()
	Dim readers As IDataReader
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	
	If bTransaccion=True Then cmdSQL.Transaction = Me.mc.miTransact Else 

	cmdSQL.CommandText = "SELECT * FROM dbo.TDCatalogo WHERE iCodTDCatalogo=@iCodTDCatalogo"
	cmdSQL.Parameters.Add("@iCodTDCatalogo", SqlDbType.Int).Value = Me.iCodTDCatalogo
	readers = cmdSQL.ExecuteReader
	If readers.Read() Then
		Me.iCodTDCatalogo = CStr(readers.GetValue(0))
		Me.cTabla = CStr(readers.GetValue(1))
		Me.cNombreGrupo = CStr(readers.GetValue(2))
		Me.iOrden = CStr(readers.GetValue(3))
		Me.cValueMember = CStr(readers.GetValue(4))
		Me.cDisplayMember = CStr(readers.GetValue(5))
		Me.cValor = CStr(readers.GetValue(6))
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
	cmdSQL.CommandText = "SELECT * FROM dbo.TDCatalogo"
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
    '*****************************************************************************
	Public Function ListaDatosComboSimplePorTabla() As DataTable
		Dim miDataTable As New DataTable
		miDataTable.Columns.Add(CStr(Me.cNombreGrupo))
		miDataTable.Columns.Add("cDisplayMember")
		Dim readers As IDataReader
		Dim cmdSQL As New SqlCommand
		cmdSQL.Parameters.Clear()
		cmdSQL.Connection = ConnectSQL.linkSQL

		If bTransaccion = True Then cmdSQL.Transaction = Me.mc.miTransact Else

		cmdSQL.CommandText = "SELECT cValueMember,cDisplayMember FROM dbo.TDCatalogo WHERE cTabla=@cTabla AND cNombreGrupo=@cNombreGrupo"
		cmdSQL.Parameters.Add("@cTabla", SqlDbType.NVarChar).Value = Me.cTabla
		cmdSQL.Parameters.Add("@cNombreGrupo", SqlDbType.NVarChar).Value = Me.cNombreGrupo
		readers = cmdSQL.ExecuteReader
		While readers.Read()
			miDataTable.Rows.Add(CStr(readers.GetValue(0)), CStr(readers.GetValue(1)))
		End While
		readers.Close()
		Return miDataTable

    End Function



End Class
