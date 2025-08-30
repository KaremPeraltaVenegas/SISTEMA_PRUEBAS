Imports System.Data.SqlClient
Public Class Tdcondicionsustento
Public iCodTDCondicionSustento As String
Public iCodCliente As String
Public cCondicion As String
Public cCondicionSustento As String
Public cSustento As String
Public cRequisitos As String
Public bAnulado As String
Public iCodUsuario As String
Public dFechaSis As String
Public qSelect As String
Public cTipoOpe as Char
Public bTransaccion as Boolean=False
Public mc as New ConnectSQL
 Public Function ListaDatos() As DataTable
	Dim Query As String
	Dim readers As DataTable
	Query = "SELECT * FROM dbo.TDCondicionSustento"
	readers = mc.ExecuteDataTable(Query)
	Return readers
End Function
 Public Sub Insertar()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.CommandText ="INSERT into dbo.TDCondicionSustento (iCodCliente,cCondicion,cCondicionSustento,cSustento,cRequisitos,bAnulado,iCodUsuario,dFechaSis ) VALUES(@iCodCliente,@cCondicion,@cCondicionSustento,@cSustento,@cRequisitos,@bAnulado,@iCodUsuario,@dFechaSis); SELECT SCOPE_IDENTITY(); "
	cmdSQL.Parameters.Add("@iCodCliente", SqlDbType.Int).Value = Me.iCodCliente
	cmdSQL.Parameters.Add("@cCondicion", SqlDbType.Varchar,10).Value = Me.cCondicion
	cmdSQL.Parameters.Add("@cCondicionSustento", SqlDbType.Varchar,50).Value = Me.cCondicionSustento
	cmdSQL.Parameters.Add("@cSustento", SqlDbType.Varchar,50).Value = Me.cSustento
	cmdSQL.Parameters.Add("@cRequisitos", SqlDbType.Varchar,-1).Value = Me.cRequisitos
	cmdSQL.Parameters.Add("@bAnulado", SqlDbType.Bit).Value = Me.bAnulado
	cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
	cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.Datetime).Value = Me.dFechaSis

	Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
	If pCodInsert > 0 Then
		Me.iCodTDCondicionSustento=pCodInsert
	Else
		Me.iCodTDCondicionSustento=0
	End If
End Sub
 Public Sub InsertarTransact()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.Transaction = Me.mc.miTransact 
	cmdSQL.CommandText ="INSERT into dbo.TDCondicionSustento (iCodCliente,cCondicion,cCondicionSustento,cSustento,cRequisitos,bAnulado,iCodUsuario,dFechaSis ) VALUES(@iCodCliente,@cCondicion,@cCondicionSustento,@cSustento,@cRequisitos,@bAnulado,@iCodUsuario,@dFechaSis); SELECT SCOPE_IDENTITY(); "
	cmdSQL.Parameters.Add("@iCodCliente", SqlDbType.Int).Value = Me.iCodCliente
	cmdSQL.Parameters.Add("@cCondicion", SqlDbType.Varchar,10).Value = Me.cCondicion
	cmdSQL.Parameters.Add("@cCondicionSustento", SqlDbType.Varchar,50).Value = Me.cCondicionSustento
	cmdSQL.Parameters.Add("@cSustento", SqlDbType.Varchar,50).Value = Me.cSustento
	cmdSQL.Parameters.Add("@cRequisitos", SqlDbType.Varchar,-1).Value = Me.cRequisitos
	cmdSQL.Parameters.Add("@bAnulado", SqlDbType.Bit).Value = Me.bAnulado
	cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
	cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.Datetime).Value = Me.dFechaSis

	Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
	If pCodInsert > 0 Then
		Me.iCodTDCondicionSustento=pCodInsert
	Else
		Me.iCodTDCondicionSustento=0
	End If
End Sub
 Public Sub Modificar()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.CommandText = "UPDATE  dbo.TDCondicionSustento SET iCodCliente=@iCodCliente,cCondicion=@cCondicion,cCondicionSustento=@cCondicionSustento,cSustento=@cSustento,cRequisitos=@cRequisitos,bAnulado=@bAnulado,iCodUsuario=@iCodUsuario,dFechaSis=@dFechaSis WHERE iCodTDCondicionSustento=@iCodTDCondicionSustento"
	cmdSQL.Parameters.Add("@iCodTDCondicionSustento", SqlDbType.Int).Value = Me.iCodTDCondicionSustento
	cmdSQL.Parameters.Add("@iCodCliente", SqlDbType.Int).Value = Me.iCodCliente
	cmdSQL.Parameters.Add("@cCondicion", SqlDbType.Varchar,10).Value = Me.cCondicion
	cmdSQL.Parameters.Add("@cCondicionSustento", SqlDbType.Varchar,50).Value = Me.cCondicionSustento
	cmdSQL.Parameters.Add("@cSustento", SqlDbType.Varchar,50).Value = Me.cSustento
	cmdSQL.Parameters.Add("@cRequisitos", SqlDbType.Varchar,-1).Value = Me.cRequisitos
	cmdSQL.Parameters.Add("@bAnulado", SqlDbType.Bit).Value = Me.bAnulado
	cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
	cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.Datetime).Value = Me.dFechaSis

	cmdSQL.ExecuteNonQuery()
End Sub
 Public Sub ModificarTransact()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.Transaction = Me.mc.miTransact 
	cmdSQL.CommandText = "UPDATE  dbo.TDCondicionSustento SET iCodCliente=@iCodCliente,cCondicion=@cCondicion,cCondicionSustento=@cCondicionSustento,cSustento=@cSustento,cRequisitos=@cRequisitos,bAnulado=@bAnulado,iCodUsuario=@iCodUsuario,dFechaSis=@dFechaSis WHERE iCodTDCondicionSustento=@iCodTDCondicionSustento"
	cmdSQL.Parameters.Add("@iCodTDCondicionSustento", SqlDbType.Int).Value = Me.iCodTDCondicionSustento
	cmdSQL.Parameters.Add("@iCodCliente", SqlDbType.Int).Value = Me.iCodCliente
	cmdSQL.Parameters.Add("@cCondicion", SqlDbType.Varchar,10).Value = Me.cCondicion
	cmdSQL.Parameters.Add("@cCondicionSustento", SqlDbType.Varchar,50).Value = Me.cCondicionSustento
	cmdSQL.Parameters.Add("@cSustento", SqlDbType.Varchar,50).Value = Me.cSustento
	cmdSQL.Parameters.Add("@cRequisitos", SqlDbType.Varchar,-1).Value = Me.cRequisitos
	cmdSQL.Parameters.Add("@bAnulado", SqlDbType.Bit).Value = Me.bAnulado
	cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
	cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.Datetime).Value = Me.dFechaSis

	cmdSQL.ExecuteNonQuery()
End Sub
 Public Sub Eliminar()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.CommandText = "DELETE from  dbo.TDCondicionSustento  WHERE iCodTDCondicionSustento=@iCodTDCondicionSustento"
'cmdSQL.CommandText = "UPDATE dbo.TDCondicionSustento  SET bAnulado=1 WHERE  iCodTDCondicionSustento=@iCodTDCondicionSustento"
cmdSQL.Parameters.Add("@iCodTDCondicionSustento", SqlDbType.Int).Value = Me.iCodTDCondicionSustento
	cmdSQL.ExecuteNonQuery()
End Sub
 Public Sub EliminarTransact()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.Transaction = Me.mc.miTransact 
	cmdSQL.CommandText = "DELETE from  dbo.TDCondicionSustento  WHERE iCodTDCondicionSustento=@iCodTDCondicionSustento"
'cmdSQL.CommandText = "UPDATE dbo.TDCondicionSustento  SET bAnulado=1 WHERE  iCodTDCondicionSustento=@iCodTDCondicionSustento"
cmdSQL.Parameters.Add("@iCodTDCondicionSustento", SqlDbType.Int).Value = Me.iCodTDCondicionSustento
	cmdSQL.ExecuteNonQuery()
End Sub
Public Sub getRecord()
	Dim readers As IDataReader
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	
	If bTransaccion=True Then cmdSQL.Transaction = Me.mc.miTransact Else 

	cmdSQL.CommandText = "SELECT * FROM dbo.TDCondicionSustento WHERE iCodTDCondicionSustento=@iCodTDCondicionSustento"
	cmdSQL.Parameters.Add("@iCodTDCondicionSustento", SqlDbType.Int).Value = Me.iCodTDCondicionSustento
	readers = cmdSQL.ExecuteReader
	If readers.Read() Then
		Me.iCodTDCondicionSustento = CStr(readers.GetValue(0))
		Me.iCodCliente = CStr(readers.GetValue(1))
		Me.cCondicion = CStr(readers.GetValue(2))
		Me.cCondicionSustento = CStr(readers.GetValue(3))
		Me.cSustento = CStr(readers.GetValue(4))
		Me.cRequisitos = CStr(readers.GetValue(5))
		Me.bAnulado = CStr(readers.GetValue(6))
		Me.iCodUsuario = CStr(readers.GetValue(7))
		Me.dFechaSis = CStr(readers.GetValue(8))
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
	cmdSQL.CommandText = "SELECT * FROM dbo.TDCondicionSustento"
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

	Public Function ListaCondicionSustento() As DataTable

		Dim Query As String = ""
		Dim readers As SqlDataReader
		Dim cmdSQL As New SqlCommand
		cmdSQL.Parameters.Clear()
		cmdSQL.Connection = ConnectSQL.linkSQL
		cmdSQL.CommandText = "SELECT iCodTDCondicionSustento,cCondicionSustento,cSustento FROM dbo.TDCondicionSustento WHERE iCodCliente=@iCodCliente"
		cmdSQL.Parameters.Add("@iCodCliente", SqlDbType.Int).Value = Me.iCodCliente

		readers = cmdSQL.ExecuteReader()
		Dim dt As New DataTable
		dt.Load(readers)
		readers.Close()
		Return dt

	End Function
End Class
