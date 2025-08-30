Imports System.Data.SqlClient
Public Class Candidatoadmisioncatalogo
Public iCodCandidatoAdmisionCatalogo As String
Public cDesTipoAdmision As String
Public cGrupo As String
Public bPostular As String
Public cTipo As String
Public bHabilitado As String
Public qSelect As String
Public cTipoOpe as Char
Public bTransaccion as Boolean=False
Public mc as New ConnectSQL
 Public Function ListaDatos() As DataTable
	Dim Query As String
	Dim readers As DataTable
	Query = "SELECT * FROM dbo.CandidatoAdmisionCatalogo"
	readers = mc.ExecuteDataTable(Query)
	Return readers
End Function
 Public Sub Insertar()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.CommandText ="INSERT into dbo.CandidatoAdmisionCatalogo (cDesTipoAdmision,cGrupo,bPostular,cTipo,bHabilitado ) VALUES(@cDesTipoAdmision,@cGrupo,@bPostular,@cTipo,@bHabilitado); SELECT SCOPE_IDENTITY(); "
	cmdSQL.Parameters.Add("@cDesTipoAdmision", SqlDbType.Varchar,50).Value = Me.cDesTipoAdmision
	cmdSQL.Parameters.Add("@cGrupo", SqlDbType.Varchar,50).Value = Me.cGrupo
	cmdSQL.Parameters.Add("@bPostular", SqlDbType.Bit).Value = Me.bPostular
	cmdSQL.Parameters.Add("@cTipo", SqlDbType.Varchar,4).Value = Me.cTipo
	cmdSQL.Parameters.Add("@bHabilitado", SqlDbType.Bit).Value = Me.bHabilitado

	Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
	If pCodInsert > 0 Then
		Me.iCodCandidatoAdmisionCatalogo=pCodInsert
	Else
		Me.iCodCandidatoAdmisionCatalogo=0
	End If
End Sub
 Public Sub InsertarTransact()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.Transaction = Me.mc.miTransact 
	cmdSQL.CommandText ="INSERT into dbo.CandidatoAdmisionCatalogo (cDesTipoAdmision,cGrupo,bPostular,cTipo,bHabilitado ) VALUES(@cDesTipoAdmision,@cGrupo,@bPostular,@cTipo,@bHabilitado); SELECT SCOPE_IDENTITY(); "
	cmdSQL.Parameters.Add("@cDesTipoAdmision", SqlDbType.Varchar,50).Value = Me.cDesTipoAdmision
	cmdSQL.Parameters.Add("@cGrupo", SqlDbType.Varchar,50).Value = Me.cGrupo
	cmdSQL.Parameters.Add("@bPostular", SqlDbType.Bit).Value = Me.bPostular
	cmdSQL.Parameters.Add("@cTipo", SqlDbType.Varchar,4).Value = Me.cTipo
	cmdSQL.Parameters.Add("@bHabilitado", SqlDbType.Bit).Value = Me.bHabilitado

	Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
	If pCodInsert > 0 Then
		Me.iCodCandidatoAdmisionCatalogo=pCodInsert
	Else
		Me.iCodCandidatoAdmisionCatalogo=0
	End If
End Sub
 Public Sub Modificar()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.CommandText = "UPDATE  dbo.CandidatoAdmisionCatalogo SET cDesTipoAdmision=@cDesTipoAdmision,cGrupo=@cGrupo,bPostular=@bPostular,cTipo=@cTipo,bHabilitado=@bHabilitado WHERE iCodCandidatoAdmisionCatalogo=@iCodCandidatoAdmisionCatalogo"
	cmdSQL.Parameters.Add("@iCodCandidatoAdmisionCatalogo", SqlDbType.Int).Value = Me.iCodCandidatoAdmisionCatalogo
	cmdSQL.Parameters.Add("@cDesTipoAdmision", SqlDbType.Varchar,50).Value = Me.cDesTipoAdmision
	cmdSQL.Parameters.Add("@cGrupo", SqlDbType.Varchar,50).Value = Me.cGrupo
	cmdSQL.Parameters.Add("@bPostular", SqlDbType.Bit).Value = Me.bPostular
	cmdSQL.Parameters.Add("@cTipo", SqlDbType.Varchar,4).Value = Me.cTipo
	cmdSQL.Parameters.Add("@bHabilitado", SqlDbType.Bit).Value = Me.bHabilitado

	cmdSQL.ExecuteNonQuery()
End Sub
 Public Sub ModificarTransact()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.Transaction = Me.mc.miTransact 
	cmdSQL.CommandText = "UPDATE  dbo.CandidatoAdmisionCatalogo SET cDesTipoAdmision=@cDesTipoAdmision,cGrupo=@cGrupo,bPostular=@bPostular,cTipo=@cTipo,bHabilitado=@bHabilitado WHERE iCodCandidatoAdmisionCatalogo=@iCodCandidatoAdmisionCatalogo"
	cmdSQL.Parameters.Add("@iCodCandidatoAdmisionCatalogo", SqlDbType.Int).Value = Me.iCodCandidatoAdmisionCatalogo
	cmdSQL.Parameters.Add("@cDesTipoAdmision", SqlDbType.Varchar,50).Value = Me.cDesTipoAdmision
	cmdSQL.Parameters.Add("@cGrupo", SqlDbType.Varchar,50).Value = Me.cGrupo
	cmdSQL.Parameters.Add("@bPostular", SqlDbType.Bit).Value = Me.bPostular
	cmdSQL.Parameters.Add("@cTipo", SqlDbType.Varchar,4).Value = Me.cTipo
	cmdSQL.Parameters.Add("@bHabilitado", SqlDbType.Bit).Value = Me.bHabilitado

	cmdSQL.ExecuteNonQuery()
End Sub
 Public Sub Eliminar()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.CommandText = "DELETE from  dbo.CandidatoAdmisionCatalogo  WHERE iCodCandidatoAdmisionCatalogo=@iCodCandidatoAdmisionCatalogo"
'cmdSQL.CommandText = "UPDATE dbo.CandidatoAdmisionCatalogo  SET bAnulado=1 WHERE  iCodCandidatoAdmisionCatalogo=@iCodCandidatoAdmisionCatalogo"
cmdSQL.Parameters.Add("@iCodCandidatoAdmisionCatalogo", SqlDbType.Int).Value = Me.iCodCandidatoAdmisionCatalogo
	cmdSQL.ExecuteNonQuery()
End Sub
 Public Sub EliminarTransact()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.Transaction = Me.mc.miTransact 
	cmdSQL.CommandText = "DELETE from  dbo.CandidatoAdmisionCatalogo  WHERE iCodCandidatoAdmisionCatalogo=@iCodCandidatoAdmisionCatalogo"
'cmdSQL.CommandText = "UPDATE dbo.CandidatoAdmisionCatalogo  SET bAnulado=1 WHERE  iCodCandidatoAdmisionCatalogo=@iCodCandidatoAdmisionCatalogo"
cmdSQL.Parameters.Add("@iCodCandidatoAdmisionCatalogo", SqlDbType.Int).Value = Me.iCodCandidatoAdmisionCatalogo
	cmdSQL.ExecuteNonQuery()
End Sub
Public Sub getRecord()
	Dim readers As IDataReader
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	
	If bTransaccion=True Then cmdSQL.Transaction = Me.mc.miTransact Else 

	cmdSQL.CommandText = "SELECT * FROM dbo.CandidatoAdmisionCatalogo WHERE iCodCandidatoAdmisionCatalogo=@iCodCandidatoAdmisionCatalogo"
	cmdSQL.Parameters.Add("@iCodCandidatoAdmisionCatalogo", SqlDbType.Int).Value = Me.iCodCandidatoAdmisionCatalogo
	readers = cmdSQL.ExecuteReader
	If readers.Read() Then
		Me.iCodCandidatoAdmisionCatalogo = CStr(readers.GetValue(0))
		Me.cDesTipoAdmision = CStr(readers.GetValue(1))
		Me.cGrupo = CStr(readers.GetValue(2))
		Me.bPostular = CStr(readers.GetValue(3))
		Me.cTipo = CStr(readers.GetValue(4))
		Me.bHabilitado = CStr(readers.GetValue(5))
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
	cmdSQL.CommandText = "SELECT * FROM dbo.CandidatoAdmisionCatalogo"
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

	Public Function ListaCatalogoTipoAdmisionPorTipo() As DataTable
		Dim Query As String
		Dim readers As DataTable
		Query = String.Format("SELECT iCodCandidatoAdmisionCatalogo as ValueMember,cDesTipoAdmision as DisplayMember FROM Candidatoadmisioncatalogo where cTipo='" & Me.cTipo & "'" & " and bHabilitado=1")
		readers = mc.ExecuteDataTable(Query)
		Return readers
	End Function
End Class
