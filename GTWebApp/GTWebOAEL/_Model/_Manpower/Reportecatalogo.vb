Imports System.Data.SqlClient
Public Class Reportecatalogo
Public iCodReporteCatalogo As String
Public cNombreReporte As String
Public cQueryReporte As String
Public bFiltroFecha As String
Public bInactivo As String
Public cTipo As String
Public qSelect As String
Public cTipoOpe as Char
Public bTransaccion as Boolean=False
Public mc as New ConnectSQL
 Public Function ListaDatos() As DataTable
	Dim Query As String
	Dim readers As DataTable
	Query = "SELECT * FROM rpt.ReporteCatalogo"
	readers = mc.ExecuteDataTable(Query)
	Return readers
End Function
 Public Sub Insertar()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.CommandText ="INSERT into rpt.ReporteCatalogo (cNombreReporte,cQueryReporte,bFiltroFecha,bInactivo,cTipo ) VALUES(@cNombreReporte,@cQueryReporte,@bFiltroFecha,@bInactivo,@cTipo); SELECT SCOPE_IDENTITY(); "
	cmdSQL.Parameters.Add("@cNombreReporte", SqlDbType.Varchar,400).Value = Me.cNombreReporte
	cmdSQL.Parameters.Add("@cQueryReporte", SqlDbType.Varchar,-1).Value = Me.cQueryReporte
	cmdSQL.Parameters.Add("@bFiltroFecha", SqlDbType.Bit).Value = Me.bFiltroFecha
	cmdSQL.Parameters.Add("@bInactivo", SqlDbType.Bit).Value = Me.bInactivo
	cmdSQL.Parameters.Add("@cTipo", SqlDbType.Varchar,40).Value = Me.cTipo

	Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
	If pCodInsert > 0 Then
		Me.iCodReporteCatalogo=pCodInsert
	Else
		Me.iCodReporteCatalogo=0
	End If
End Sub
 Public Sub InsertarTransact()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.Transaction = Me.mc.miTransact 
	cmdSQL.CommandText ="INSERT into rpt.ReporteCatalogo (cNombreReporte,cQueryReporte,bFiltroFecha,bInactivo,cTipo ) VALUES(@cNombreReporte,@cQueryReporte,@bFiltroFecha,@bInactivo,@cTipo); SELECT SCOPE_IDENTITY(); "
	cmdSQL.Parameters.Add("@cNombreReporte", SqlDbType.Varchar,400).Value = Me.cNombreReporte
	cmdSQL.Parameters.Add("@cQueryReporte", SqlDbType.Varchar,-1).Value = Me.cQueryReporte
	cmdSQL.Parameters.Add("@bFiltroFecha", SqlDbType.Bit).Value = Me.bFiltroFecha
	cmdSQL.Parameters.Add("@bInactivo", SqlDbType.Bit).Value = Me.bInactivo
	cmdSQL.Parameters.Add("@cTipo", SqlDbType.Varchar,40).Value = Me.cTipo

	Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
	If pCodInsert > 0 Then
		Me.iCodReporteCatalogo=pCodInsert
	Else
		Me.iCodReporteCatalogo=0
	End If
End Sub
 Public Sub Modificar()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.CommandText = "UPDATE  rpt.ReporteCatalogo SET cNombreReporte=@cNombreReporte,cQueryReporte=@cQueryReporte,bFiltroFecha=@bFiltroFecha,bInactivo=@bInactivo,cTipo=@cTipo WHERE iCodReporteCatalogo=@iCodReporteCatalogo"
	cmdSQL.Parameters.Add("@iCodReporteCatalogo", SqlDbType.Int).Value = Me.iCodReporteCatalogo
	cmdSQL.Parameters.Add("@cNombreReporte", SqlDbType.Varchar,400).Value = Me.cNombreReporte
	cmdSQL.Parameters.Add("@cQueryReporte", SqlDbType.Varchar,-1).Value = Me.cQueryReporte
	cmdSQL.Parameters.Add("@bFiltroFecha", SqlDbType.Bit).Value = Me.bFiltroFecha
	cmdSQL.Parameters.Add("@bInactivo", SqlDbType.Bit).Value = Me.bInactivo
	cmdSQL.Parameters.Add("@cTipo", SqlDbType.Varchar,40).Value = Me.cTipo

	cmdSQL.ExecuteNonQuery()
End Sub
 Public Sub ModificarTransact()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.Transaction = Me.mc.miTransact 
	cmdSQL.CommandText = "UPDATE  rpt.ReporteCatalogo SET cNombreReporte=@cNombreReporte,cQueryReporte=@cQueryReporte,bFiltroFecha=@bFiltroFecha,bInactivo=@bInactivo,cTipo=@cTipo WHERE iCodReporteCatalogo=@iCodReporteCatalogo"
	cmdSQL.Parameters.Add("@iCodReporteCatalogo", SqlDbType.Int).Value = Me.iCodReporteCatalogo
	cmdSQL.Parameters.Add("@cNombreReporte", SqlDbType.Varchar,400).Value = Me.cNombreReporte
	cmdSQL.Parameters.Add("@cQueryReporte", SqlDbType.Varchar,-1).Value = Me.cQueryReporte
	cmdSQL.Parameters.Add("@bFiltroFecha", SqlDbType.Bit).Value = Me.bFiltroFecha
	cmdSQL.Parameters.Add("@bInactivo", SqlDbType.Bit).Value = Me.bInactivo
	cmdSQL.Parameters.Add("@cTipo", SqlDbType.Varchar,40).Value = Me.cTipo

	cmdSQL.ExecuteNonQuery()
End Sub
 Public Sub Eliminar()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.CommandText = "DELETE from  rpt.ReporteCatalogo  WHERE iCodReporteCatalogo=@iCodReporteCatalogo"
'cmdSQL.CommandText = "UPDATE rpt.ReporteCatalogo  SET bAnulado=1 WHERE  iCodReporteCatalogo=@iCodReporteCatalogo"
cmdSQL.Parameters.Add("@iCodReporteCatalogo", SqlDbType.Int).Value = Me.iCodReporteCatalogo
	cmdSQL.ExecuteNonQuery()
End Sub
 Public Sub EliminarTransact()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.Transaction = Me.mc.miTransact 
	cmdSQL.CommandText = "DELETE from  rpt.ReporteCatalogo  WHERE iCodReporteCatalogo=@iCodReporteCatalogo"
'cmdSQL.CommandText = "UPDATE rpt.ReporteCatalogo  SET bAnulado=1 WHERE  iCodReporteCatalogo=@iCodReporteCatalogo"
cmdSQL.Parameters.Add("@iCodReporteCatalogo", SqlDbType.Int).Value = Me.iCodReporteCatalogo
	cmdSQL.ExecuteNonQuery()
End Sub
Public Sub getRecord()
	Dim readers As IDataReader
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	
	If bTransaccion=True Then cmdSQL.Transaction = Me.mc.miTransact Else 

	cmdSQL.CommandText = "SELECT * FROM rpt.ReporteCatalogo WHERE iCodReporteCatalogo=@iCodReporteCatalogo"
	cmdSQL.Parameters.Add("@iCodReporteCatalogo", SqlDbType.Int).Value = Me.iCodReporteCatalogo
	readers = cmdSQL.ExecuteReader
	If readers.Read() Then
		Me.iCodReporteCatalogo = CStr(readers.GetValue(0))
		Me.cNombreReporte = CStr(readers.GetValue(1))
		Me.cQueryReporte = CStr(readers.GetValue(2))
		Me.bFiltroFecha = CStr(readers.GetValue(3))
		Me.bInactivo = CStr(readers.GetValue(4))
		Me.cTipo = CStr(readers.GetValue(5))
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
	cmdSQL.CommandText = "SELECT * FROM rpt.ReporteCatalogo"
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

    '********************************************************************************

    Public dFechaIni As String
    Public dFechaFin As String


    Public Function ListaReportes() As DataTable


        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "SELECT * FROM rpt.ReporteCatalogo where bInactivo=0 and (cTipo=@cTipo or cTipo='G')"
        cmdSQL.Parameters.Add("@cTipo", SqlDbType.VarChar, 40).Value = Me.cTipo


        Dim readers As SqlDataReader
        readers = cmdSQL.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(readers)
        Return dt
    End Function

    Public Function EjecutaReporte() As DataTable


        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = Me.cQueryReporte
        cmdSQL.Parameters.Add("@dFechaIni", SqlDbType.Date).Value = Me.dFechaIni
        cmdSQL.Parameters.Add("@dFechaFin", SqlDbType.Date).Value = Me.dFechaFin


        Dim readers As SqlDataReader
        readers = cmdSQL.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(readers)
        Return dt
    End Function

End Class
