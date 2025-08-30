Imports System.Data.SqlClient
Public Class Fuerzalaboral
    Public iCodFuerzaLaboral As String
    Public iCodContrata As String
    Public iCodSubContratista As String
    Public iCodContratistaContrato As String
    Public iPeriodo As String
    Public iMes As String
    Public bActivo As String
    Public iCodEstado As String
    Public iCodUsuario As String
    Public dFechaSis As String
    Public qSelect As String
    Public cTipoOpe As Char
    Public bTransaccion As Boolean = False
    Public mc As New ConnectSQL
    Public Function ListaDatos() As DataTable
        Dim Query As String
        Dim readers As DataTable
        Query = "SELECT * FROM dbo.FuerzaLaboral"
        readers = mc.ExecuteDataTable(Query)
        Return readers
    End Function
    Public Sub Insertar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "INSERT into dbo.FuerzaLaboral (iCodContrata,iCodSubContratista,iCodContratistaContrato,iPeriodo,iMes,bActivo,iCodEstado,iCodUsuario,dFechaSis ) VALUES(@iCodContrata,@iCodSubContratista,@iCodContratistaContrato,@iPeriodo,@iMes,@bActivo,@iCodEstado,@iCodUsuario,@dFechaSis); SELECT SCOPE_IDENTITY(); "
        cmdSQL.Parameters.Add("@iCodContrata", SqlDbType.Int).Value = Me.iCodContrata
        cmdSQL.Parameters.Add("@iCodSubContratista", SqlDbType.Int).Value = Me.iCodSubContratista
        cmdSQL.Parameters.Add("@iCodContratistaContrato", SqlDbType.Int).Value = Me.iCodContratistaContrato
        cmdSQL.Parameters.Add("@iPeriodo", SqlDbType.Smallint).Value = Me.iPeriodo
        cmdSQL.Parameters.Add("@iMes", SqlDbType.Tinyint).Value = Me.iMes
        cmdSQL.Parameters.Add("@bActivo", SqlDbType.Bit).Value = Me.bActivo
        cmdSQL.Parameters.Add("@iCodEstado", SqlDbType.Tinyint).Value = Me.iCodEstado
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.Datetime).Value = Me.dFechaSis

        Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
        If pCodInsert > 0 Then
            Me.iCodFuerzaLaboral = pCodInsert
        Else
            Me.iCodFuerzaLaboral = 0
        End If
    End Sub
    Public Sub InsertarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "INSERT into dbo.FuerzaLaboral (iCodContrata,iCodSubContratista,iCodContratistaContrato,iPeriodo,iMes,bActivo,iCodEstado,iCodUsuario,dFechaSis ) VALUES(@iCodContrata,@iCodSubContratista,@iCodContratistaContrato,@iPeriodo,@iMes,@bActivo,@iCodEstado,@iCodUsuario,@dFechaSis); SELECT SCOPE_IDENTITY(); "
        cmdSQL.Parameters.Add("@iCodContrata", SqlDbType.Int).Value = Me.iCodContrata
        cmdSQL.Parameters.Add("@iCodSubContratista", SqlDbType.Int).Value = Me.iCodSubContratista
        cmdSQL.Parameters.Add("@iCodContratistaContrato", SqlDbType.Int).Value = Me.iCodContratistaContrato
        cmdSQL.Parameters.Add("@iPeriodo", SqlDbType.Smallint).Value = Me.iPeriodo
        cmdSQL.Parameters.Add("@iMes", SqlDbType.Tinyint).Value = Me.iMes
        cmdSQL.Parameters.Add("@bActivo", SqlDbType.Bit).Value = Me.bActivo
        cmdSQL.Parameters.Add("@iCodEstado", SqlDbType.Tinyint).Value = Me.iCodEstado
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.Datetime).Value = Me.dFechaSis

        Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
        If pCodInsert > 0 Then
            Me.iCodFuerzaLaboral = pCodInsert
        Else
            Me.iCodFuerzaLaboral = 0
        End If
    End Sub
    Public Sub Modificar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "UPDATE  dbo.FuerzaLaboral SET iCodContrata=@iCodContrata,iCodSubContratista=@iCodSubContratista,iCodContratistaContrato=@iCodContratistaContrato,iPeriodo=@iPeriodo,iMes=@iMes,bActivo=@bActivo,iCodEstado=@iCodEstado,iCodUsuario=@iCodUsuario,dFechaSis=@dFechaSis WHERE iCodFuerzaLaboral=@iCodFuerzaLaboral"
        cmdSQL.Parameters.Add("@iCodFuerzaLaboral", SqlDbType.Int).Value = Me.iCodFuerzaLaboral
        cmdSQL.Parameters.Add("@iCodContrata", SqlDbType.Int).Value = Me.iCodContrata
        cmdSQL.Parameters.Add("@iCodSubContratista", SqlDbType.Int).Value = Me.iCodSubContratista
        cmdSQL.Parameters.Add("@iCodContratistaContrato", SqlDbType.Int).Value = Me.iCodContratistaContrato
        cmdSQL.Parameters.Add("@iPeriodo", SqlDbType.Smallint).Value = Me.iPeriodo
        cmdSQL.Parameters.Add("@iMes", SqlDbType.Tinyint).Value = Me.iMes
        cmdSQL.Parameters.Add("@bActivo", SqlDbType.Bit).Value = Me.bActivo
        cmdSQL.Parameters.Add("@iCodEstado", SqlDbType.Tinyint).Value = Me.iCodEstado
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.Datetime).Value = Me.dFechaSis

        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub ModificarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "UPDATE  dbo.FuerzaLaboral SET iCodContrata=@iCodContrata,iCodSubContratista=@iCodSubContratista,iCodContratistaContrato=@iCodContratistaContrato,iPeriodo=@iPeriodo,iMes=@iMes,bActivo=@bActivo,iCodEstado=@iCodEstado,iCodUsuario=@iCodUsuario,dFechaSis=@dFechaSis WHERE iCodFuerzaLaboral=@iCodFuerzaLaboral"
        cmdSQL.Parameters.Add("@iCodFuerzaLaboral", SqlDbType.Int).Value = Me.iCodFuerzaLaboral
        cmdSQL.Parameters.Add("@iCodContrata", SqlDbType.Int).Value = Me.iCodContrata
        cmdSQL.Parameters.Add("@iCodSubContratista", SqlDbType.Int).Value = Me.iCodSubContratista
        cmdSQL.Parameters.Add("@iCodContratistaContrato", SqlDbType.Int).Value = Me.iCodContratistaContrato
        cmdSQL.Parameters.Add("@iPeriodo", SqlDbType.Smallint).Value = Me.iPeriodo
        cmdSQL.Parameters.Add("@iMes", SqlDbType.Tinyint).Value = Me.iMes
        cmdSQL.Parameters.Add("@bActivo", SqlDbType.Bit).Value = Me.bActivo
        cmdSQL.Parameters.Add("@iCodEstado", SqlDbType.Tinyint).Value = Me.iCodEstado
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.Datetime).Value = Me.dFechaSis

        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub Eliminar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "DELETE from  dbo.FuerzaLaboral  WHERE iCodFuerzaLaboral=@iCodFuerzaLaboral"
        'cmdSQL.CommandText = "UPDATE dbo.FuerzaLaboral  SET bAnulado=1 WHERE  iCodFuerzaLaboral=@iCodFuerzaLaboral"
        cmdSQL.Parameters.Add("@iCodFuerzaLaboral", SqlDbType.Int).Value = Me.iCodFuerzaLaboral
        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub EliminarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "DELETE from  dbo.FuerzaLaboral  WHERE iCodFuerzaLaboral=@iCodFuerzaLaboral"
        'cmdSQL.CommandText = "UPDATE dbo.FuerzaLaboral  SET bAnulado=1 WHERE  iCodFuerzaLaboral=@iCodFuerzaLaboral"
        cmdSQL.Parameters.Add("@iCodFuerzaLaboral", SqlDbType.Int).Value = Me.iCodFuerzaLaboral
        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub getRecord()
        Dim readers As IDataReader
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL

        If bTransaccion = True Then cmdSQL.Transaction = Me.mc.miTransact Else 

        cmdSQL.CommandText = "SELECT * FROM dbo.FuerzaLaboral WHERE iCodFuerzaLaboral=@iCodFuerzaLaboral"
        cmdSQL.Parameters.Add("@iCodFuerzaLaboral", SqlDbType.Int).Value = Me.iCodFuerzaLaboral
        readers = cmdSQL.ExecuteReader
        If readers.Read() Then
            Me.iCodFuerzaLaboral = CStr(readers.GetValue(0))
            Me.iCodContrata = CStr(readers.GetValue(1))
            Me.iCodSubContratista = CStr(readers.GetValue(2))
            Me.iCodContratistaContrato = CStr(readers.GetValue(3))
            Me.iPeriodo = CStr(readers.GetValue(4))
            Me.iMes = CStr(readers.GetValue(5))
            Me.bActivo = CStr(readers.GetValue(6))
            Me.iCodEstado = CStr(readers.GetValue(7))
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
        cmdSQL.CommandText = "SELECT * FROM dbo.FuerzaLaboral"
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
    '****************************************************************
    Public Function ListaPeriodosReportados() As DataTable
        Dim Query As String
        Dim readers As DataTable
        Query = " exec dbo.SP_FL_GetPeriodosByContrata " & _
                       " @iCodContrata='" & Trim(Me.iCodContrata) & "'"
        'InputBox("", "", Query)
        readers = mc.ExecuteDataTable(Query)
        Return readers
    End Function

    Public Function ListaContratistasFFLL() As DataTable

        Dim Query As String
        Dim readers As DataTable
        Query = String.Format("SELECT iCodContrata as ValueMember,cNomContrata as DisplayMember FROM fl_ReporteContratistas order by cNomContrata asc")
        readers = mc.ExecuteDataTable(Query)
        Return readers

    End Function


    Public Function CerrarPeriodoFFLL(ByVal pCodFuerzaLaboral As String, ByVal pCodUsuarioCierra As String) As DataTable

        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = "dbo.SP_FL_CierraPeriodoFFLL"
        cmdSQL.Parameters.Add("@iCodFuerzaLaboral", SqlDbType.Int).Value = pCodFuerzaLaboral
        cmdSQL.Parameters.Add("@iCodUsuarioCierre", SqlDbType.Int).Value = pCodUsuarioCierra

        Dim readers As SqlDataReader
        readers = cmdSQL.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(readers)
        Return dt
    End Function

    Public Function ListasPeriodosFLPorContrata() As DataTable

        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = "dbo.SP_FL_PeriodosPorContrata"
        cmdSQL.Parameters.Add("@iCodContrata", SqlDbType.Int).Value = Me.iCodContrata
 
        Dim readers As SqlDataReader
        readers = cmdSQL.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(readers)
        Return dt
    End Function
End Class
