Imports System.Data.SqlClient
Public Class Requerimientocotizaciondetalle
Public iCodRequerimientoCotizacionDetalle As String
Public iCodRequerimientoCotizacion As String
Public iCodRequerimientoDetalle As String
Public iRanking As String
Public nPrecioUnit As String
Public nCantidad As String
Public nSubTotal As String
Public nIGV As String
Public nTotal As String
Public cCondicionesPropuesta As String
Public cMarca As String
Public cModelo As String
Public bAdjudicado As String
Public iCodUsuarioCreacion As String
Public dFechaCreacion As String
Public iCodUsuarioModificacion As String
Public dFechaModificacion As String
Public qSelect As String
Public cTipoOpe as Char
Public bTransaccion as Boolean=False
Public mc as New ConnectSQL
 Public Function ListaDatos() As DataTable
	Dim Query As String
	Dim readers As DataTable
	Query = "SELECT * FROM prov.RequerimientoCotizacionDetalle"
	readers = mc.ExecuteDataTable(Query)
	Return readers
End Function
 Public Sub Insertar()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.CommandText ="INSERT into prov.RequerimientoCotizacionDetalle (iCodRequerimientoCotizacion,iCodRequerimientoDetalle,iRanking,nPrecioUnit,nCantidad,nSubTotal,nIGV,nTotal,cCondicionesPropuesta,cMarca,cModelo,bAdjudicado,iCodUsuarioCreacion,dFechaCreacion,iCodUsuarioModificacion,dFechaModificacion ) VALUES(@iCodRequerimientoCotizacion,@iCodRequerimientoDetalle,@iRanking,@nPrecioUnit,@nCantidad,@nSubTotal,@nIGV,@nTotal,@cCondicionesPropuesta,@cMarca,@cModelo,@bAdjudicado,@iCodUsuarioCreacion,@dFechaCreacion,@iCodUsuarioModificacion,@dFechaModificacion); SELECT SCOPE_IDENTITY(); "
	cmdSQL.Parameters.Add("@iCodRequerimientoCotizacion", SqlDbType.Int).Value = Me.iCodRequerimientoCotizacion
	cmdSQL.Parameters.Add("@iCodRequerimientoDetalle", SqlDbType.Int).Value = Me.iCodRequerimientoDetalle
	cmdSQL.Parameters.Add("@iRanking", SqlDbType.Tinyint).Value = Me.iRanking
	cmdSQL.Parameters.Add("@nPrecioUnit", SqlDbType.Decimal).Value = Me.nPrecioUnit
	cmdSQL.Parameters.Add("@nCantidad", SqlDbType.Decimal).Value = Me.nCantidad
	cmdSQL.Parameters.Add("@nSubTotal", SqlDbType.Decimal).Value = Me.nSubTotal
	cmdSQL.Parameters.Add("@nIGV", SqlDbType.Decimal).Value = Me.nIGV
	cmdSQL.Parameters.Add("@nTotal", SqlDbType.Decimal).Value = Me.nTotal
	cmdSQL.Parameters.Add("@cCondicionesPropuesta", SqlDbType.Varchar,-1).Value = Me.cCondicionesPropuesta
	cmdSQL.Parameters.Add("@cMarca", SqlDbType.Varchar,50).Value = Me.cMarca
	cmdSQL.Parameters.Add("@cModelo", SqlDbType.Varchar,50).Value = Me.cModelo
	cmdSQL.Parameters.Add("@bAdjudicado", SqlDbType.Bit).Value = Me.bAdjudicado
	cmdSQL.Parameters.Add("@iCodUsuarioCreacion", SqlDbType.Int).Value = Me.iCodUsuarioCreacion
	cmdSQL.Parameters.Add("@dFechaCreacion", SqlDbType.Datetime).Value = Me.dFechaCreacion
	cmdSQL.Parameters.Add("@iCodUsuarioModificacion", SqlDbType.Int).Value = Me.iCodUsuarioModificacion
	cmdSQL.Parameters.Add("@dFechaModificacion", SqlDbType.Datetime).Value = Me.dFechaModificacion

	Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
	If pCodInsert > 0 Then
		Me.iCodRequerimientoCotizacionDetalle=pCodInsert
	Else
		Me.iCodRequerimientoCotizacionDetalle=0
	End If
End Sub
 Public Sub InsertarTransact()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.Transaction = Me.mc.miTransact 
	cmdSQL.CommandText ="INSERT into prov.RequerimientoCotizacionDetalle (iCodRequerimientoCotizacion,iCodRequerimientoDetalle,iRanking,nPrecioUnit,nCantidad,nSubTotal,nIGV,nTotal,cCondicionesPropuesta,cMarca,cModelo,bAdjudicado,iCodUsuarioCreacion,dFechaCreacion,iCodUsuarioModificacion,dFechaModificacion ) VALUES(@iCodRequerimientoCotizacion,@iCodRequerimientoDetalle,@iRanking,@nPrecioUnit,@nCantidad,@nSubTotal,@nIGV,@nTotal,@cCondicionesPropuesta,@cMarca,@cModelo,@bAdjudicado,@iCodUsuarioCreacion,@dFechaCreacion,@iCodUsuarioModificacion,@dFechaModificacion); SELECT SCOPE_IDENTITY(); "
	cmdSQL.Parameters.Add("@iCodRequerimientoCotizacion", SqlDbType.Int).Value = Me.iCodRequerimientoCotizacion
	cmdSQL.Parameters.Add("@iCodRequerimientoDetalle", SqlDbType.Int).Value = Me.iCodRequerimientoDetalle
	cmdSQL.Parameters.Add("@iRanking", SqlDbType.Tinyint).Value = Me.iRanking
	cmdSQL.Parameters.Add("@nPrecioUnit", SqlDbType.Decimal).Value = Me.nPrecioUnit
	cmdSQL.Parameters.Add("@nCantidad", SqlDbType.Decimal).Value = Me.nCantidad
	cmdSQL.Parameters.Add("@nSubTotal", SqlDbType.Decimal).Value = Me.nSubTotal
	cmdSQL.Parameters.Add("@nIGV", SqlDbType.Decimal).Value = Me.nIGV
	cmdSQL.Parameters.Add("@nTotal", SqlDbType.Decimal).Value = Me.nTotal
	cmdSQL.Parameters.Add("@cCondicionesPropuesta", SqlDbType.Varchar,-1).Value = Me.cCondicionesPropuesta
	cmdSQL.Parameters.Add("@cMarca", SqlDbType.Varchar,50).Value = Me.cMarca
	cmdSQL.Parameters.Add("@cModelo", SqlDbType.Varchar,50).Value = Me.cModelo
	cmdSQL.Parameters.Add("@bAdjudicado", SqlDbType.Bit).Value = Me.bAdjudicado
	cmdSQL.Parameters.Add("@iCodUsuarioCreacion", SqlDbType.Int).Value = Me.iCodUsuarioCreacion
	cmdSQL.Parameters.Add("@dFechaCreacion", SqlDbType.Datetime).Value = Me.dFechaCreacion
	cmdSQL.Parameters.Add("@iCodUsuarioModificacion", SqlDbType.Int).Value = Me.iCodUsuarioModificacion
	cmdSQL.Parameters.Add("@dFechaModificacion", SqlDbType.Datetime).Value = Me.dFechaModificacion

	Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
	If pCodInsert > 0 Then
		Me.iCodRequerimientoCotizacionDetalle=pCodInsert
	Else
		Me.iCodRequerimientoCotizacionDetalle=0
	End If
End Sub
 Public Sub Modificar()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.CommandText = "UPDATE  prov.RequerimientoCotizacionDetalle SET iCodRequerimientoCotizacion=@iCodRequerimientoCotizacion,iCodRequerimientoDetalle=@iCodRequerimientoDetalle,iRanking=@iRanking,nPrecioUnit=@nPrecioUnit,nCantidad=@nCantidad,nSubTotal=@nSubTotal,nIGV=@nIGV,nTotal=@nTotal,cCondicionesPropuesta=@cCondicionesPropuesta,cMarca=@cMarca,cModelo=@cModelo,bAdjudicado=@bAdjudicado,iCodUsuarioCreacion=@iCodUsuarioCreacion,dFechaCreacion=@dFechaCreacion,iCodUsuarioModificacion=@iCodUsuarioModificacion,dFechaModificacion=@dFechaModificacion WHERE iCodRequerimientoCotizacionDetalle=@iCodRequerimientoCotizacionDetalle"
	cmdSQL.Parameters.Add("@iCodRequerimientoCotizacionDetalle", SqlDbType.Int).Value = Me.iCodRequerimientoCotizacionDetalle
	cmdSQL.Parameters.Add("@iCodRequerimientoCotizacion", SqlDbType.Int).Value = Me.iCodRequerimientoCotizacion
	cmdSQL.Parameters.Add("@iCodRequerimientoDetalle", SqlDbType.Int).Value = Me.iCodRequerimientoDetalle
	cmdSQL.Parameters.Add("@iRanking", SqlDbType.Tinyint).Value = Me.iRanking
	cmdSQL.Parameters.Add("@nPrecioUnit", SqlDbType.Decimal).Value = Me.nPrecioUnit
	cmdSQL.Parameters.Add("@nCantidad", SqlDbType.Decimal).Value = Me.nCantidad
	cmdSQL.Parameters.Add("@nSubTotal", SqlDbType.Decimal).Value = Me.nSubTotal
	cmdSQL.Parameters.Add("@nIGV", SqlDbType.Decimal).Value = Me.nIGV
	cmdSQL.Parameters.Add("@nTotal", SqlDbType.Decimal).Value = Me.nTotal
	cmdSQL.Parameters.Add("@cCondicionesPropuesta", SqlDbType.Varchar,-1).Value = Me.cCondicionesPropuesta
	cmdSQL.Parameters.Add("@cMarca", SqlDbType.Varchar,50).Value = Me.cMarca
	cmdSQL.Parameters.Add("@cModelo", SqlDbType.Varchar,50).Value = Me.cModelo
	cmdSQL.Parameters.Add("@bAdjudicado", SqlDbType.Bit).Value = Me.bAdjudicado
	cmdSQL.Parameters.Add("@iCodUsuarioCreacion", SqlDbType.Int).Value = Me.iCodUsuarioCreacion
	cmdSQL.Parameters.Add("@dFechaCreacion", SqlDbType.Datetime).Value = Me.dFechaCreacion
	cmdSQL.Parameters.Add("@iCodUsuarioModificacion", SqlDbType.Int).Value = Me.iCodUsuarioModificacion
	cmdSQL.Parameters.Add("@dFechaModificacion", SqlDbType.Datetime).Value = Me.dFechaModificacion

	cmdSQL.ExecuteNonQuery()
End Sub
 Public Sub ModificarTransact()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.Transaction = Me.mc.miTransact 
	cmdSQL.CommandText = "UPDATE  prov.RequerimientoCotizacionDetalle SET iCodRequerimientoCotizacion=@iCodRequerimientoCotizacion,iCodRequerimientoDetalle=@iCodRequerimientoDetalle,iRanking=@iRanking,nPrecioUnit=@nPrecioUnit,nCantidad=@nCantidad,nSubTotal=@nSubTotal,nIGV=@nIGV,nTotal=@nTotal,cCondicionesPropuesta=@cCondicionesPropuesta,cMarca=@cMarca,cModelo=@cModelo,bAdjudicado=@bAdjudicado,iCodUsuarioCreacion=@iCodUsuarioCreacion,dFechaCreacion=@dFechaCreacion,iCodUsuarioModificacion=@iCodUsuarioModificacion,dFechaModificacion=@dFechaModificacion WHERE iCodRequerimientoCotizacionDetalle=@iCodRequerimientoCotizacionDetalle"
	cmdSQL.Parameters.Add("@iCodRequerimientoCotizacionDetalle", SqlDbType.Int).Value = Me.iCodRequerimientoCotizacionDetalle
	cmdSQL.Parameters.Add("@iCodRequerimientoCotizacion", SqlDbType.Int).Value = Me.iCodRequerimientoCotizacion
	cmdSQL.Parameters.Add("@iCodRequerimientoDetalle", SqlDbType.Int).Value = Me.iCodRequerimientoDetalle
	cmdSQL.Parameters.Add("@iRanking", SqlDbType.Tinyint).Value = Me.iRanking
	cmdSQL.Parameters.Add("@nPrecioUnit", SqlDbType.Decimal).Value = Me.nPrecioUnit
	cmdSQL.Parameters.Add("@nCantidad", SqlDbType.Decimal).Value = Me.nCantidad
	cmdSQL.Parameters.Add("@nSubTotal", SqlDbType.Decimal).Value = Me.nSubTotal
	cmdSQL.Parameters.Add("@nIGV", SqlDbType.Decimal).Value = Me.nIGV
	cmdSQL.Parameters.Add("@nTotal", SqlDbType.Decimal).Value = Me.nTotal
	cmdSQL.Parameters.Add("@cCondicionesPropuesta", SqlDbType.Varchar,-1).Value = Me.cCondicionesPropuesta
	cmdSQL.Parameters.Add("@cMarca", SqlDbType.Varchar,50).Value = Me.cMarca
	cmdSQL.Parameters.Add("@cModelo", SqlDbType.Varchar,50).Value = Me.cModelo
	cmdSQL.Parameters.Add("@bAdjudicado", SqlDbType.Bit).Value = Me.bAdjudicado
	cmdSQL.Parameters.Add("@iCodUsuarioCreacion", SqlDbType.Int).Value = Me.iCodUsuarioCreacion
	cmdSQL.Parameters.Add("@dFechaCreacion", SqlDbType.Datetime).Value = Me.dFechaCreacion
	cmdSQL.Parameters.Add("@iCodUsuarioModificacion", SqlDbType.Int).Value = Me.iCodUsuarioModificacion
	cmdSQL.Parameters.Add("@dFechaModificacion", SqlDbType.Datetime).Value = Me.dFechaModificacion

	cmdSQL.ExecuteNonQuery()
End Sub
 Public Sub Eliminar()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.CommandText = "DELETE from  prov.RequerimientoCotizacionDetalle  WHERE iCodRequerimientoCotizacionDetalle=@iCodRequerimientoCotizacionDetalle"
'cmdSQL.CommandText = "UPDATE prov.RequerimientoCotizacionDetalle  SET bAnulado=1 WHERE  iCodRequerimientoCotizacionDetalle=@iCodRequerimientoCotizacionDetalle"
cmdSQL.Parameters.Add("@iCodRequerimientoCotizacionDetalle", SqlDbType.Int).Value = Me.iCodRequerimientoCotizacionDetalle
	cmdSQL.ExecuteNonQuery()
End Sub
 Public Sub EliminarTransact()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.Transaction = Me.mc.miTransact 
	cmdSQL.CommandText = "DELETE from  prov.RequerimientoCotizacionDetalle  WHERE iCodRequerimientoCotizacionDetalle=@iCodRequerimientoCotizacionDetalle"
'cmdSQL.CommandText = "UPDATE prov.RequerimientoCotizacionDetalle  SET bAnulado=1 WHERE  iCodRequerimientoCotizacionDetalle=@iCodRequerimientoCotizacionDetalle"
cmdSQL.Parameters.Add("@iCodRequerimientoCotizacionDetalle", SqlDbType.Int).Value = Me.iCodRequerimientoCotizacionDetalle
	cmdSQL.ExecuteNonQuery()
End Sub
Public Sub getRecord()
	Dim readers As IDataReader
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	
	If bTransaccion=True Then cmdSQL.Transaction = Me.mc.miTransact Else 

	cmdSQL.CommandText = "SELECT * FROM prov.RequerimientoCotizacionDetalle WHERE iCodRequerimientoCotizacionDetalle=@iCodRequerimientoCotizacionDetalle"
	cmdSQL.Parameters.Add("@iCodRequerimientoCotizacionDetalle", SqlDbType.Int).Value = Me.iCodRequerimientoCotizacionDetalle
	readers = cmdSQL.ExecuteReader
	If readers.Read() Then
		Me.iCodRequerimientoCotizacionDetalle = CStr(readers.GetValue(0))
		Me.iCodRequerimientoCotizacion = CStr(readers.GetValue(1))
		Me.iCodRequerimientoDetalle = CStr(readers.GetValue(2))
		Me.iRanking = CStr(readers.GetValue(3))
		Me.nPrecioUnit = CStr(readers.GetValue(4))
		Me.nCantidad = CStr(readers.GetValue(5))
		Me.nSubTotal = CStr(readers.GetValue(6))
		Me.nIGV = CStr(readers.GetValue(7))
		Me.nTotal = CStr(readers.GetValue(8))
		Me.cCondicionesPropuesta = CStr(readers.GetValue(9))
		Me.cMarca = CStr(readers.GetValue(10))
		Me.cModelo = CStr(readers.GetValue(11))
		Me.bAdjudicado = CStr(readers.GetValue(12))
		Me.iCodUsuarioCreacion = CStr(readers.GetValue(13))
		Me.dFechaCreacion = CStr(readers.GetValue(14))
		Me.iCodUsuarioModificacion = CStr(readers.GetValue(15))
		Me.dFechaModificacion = CStr(readers.GetValue(16))
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
	cmdSQL.CommandText = "SELECT * FROM prov.RequerimientoCotizacionDetalle"
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

    Public Sub UpdateCotizacionPostor()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "UPDATE  prov.RequerimientoCotizacionDetalle SET nPrecioUnit=@nPrecioUnit,nSubTotal=@nSubTotal,nIGV=@nIGV,nTotal=@nTotal,cCondicionesPropuesta=@cCondicionesPropuesta,iCodUsuarioModificacion=@iCodUsuarioModificacion,dFechaModificacion=@dFechaModificacion WHERE iCodRequerimientoCotizacionDetalle=@iCodRequerimientoCotizacionDetalle"
        cmdSQL.Parameters.Add("@iCodRequerimientoCotizacionDetalle", SqlDbType.Int).Value = Me.iCodRequerimientoCotizacionDetalle
        cmdSQL.Parameters.Add("@nPrecioUnit", SqlDbType.Decimal).Value = Me.nPrecioUnit
        cmdSQL.Parameters.Add("@nSubTotal", SqlDbType.Decimal).Value = Me.nSubTotal
        cmdSQL.Parameters.Add("@nIGV", SqlDbType.Decimal).Value = Me.nIGV
        cmdSQL.Parameters.Add("@nTotal", SqlDbType.Decimal).Value = Me.nTotal
        cmdSQL.Parameters.Add("@cCondicionesPropuesta", SqlDbType.VarChar, -1).Value = Me.cCondicionesPropuesta
        cmdSQL.Parameters.Add("@iCodUsuarioModificacion", SqlDbType.Int).Value = Me.iCodUsuarioModificacion
        cmdSQL.Parameters.Add("@dFechaModificacion", SqlDbType.DateTime).Value = Me.dFechaModificacion

        cmdSQL.ExecuteNonQuery()
    End Sub

    'Public Function ListaRequerimientoCotizacionDetallePorPostor() As DataTable

    '    Dim cmdSQL As New SqlCommand
    '    cmdSQL.Parameters.Clear()
    '    cmdSQL.Connection = ConnectSQL.linkSQL
    '    cmdSQL.CommandType = CommandType.StoredProcedure
    '    cmdSQL.CommandText = "prov.SP_DT_RequerimientoCotizacionDetallePostor"
    '    cmdSQL.Parameters.Add("@iCodRequerimientoCotizacion", SqlDbType.Int).Value = Me.iCodRequerimientoCotizacion

    '    Dim readers As SqlDataReader
    '    readers = cmdSQL.ExecuteReader()
    '    Dim dt As New DataTable
    '    dt.Load(readers)
    '    Return dt
    'End Function
    Public Function ListaRequerimientoCotizacionDetallePorPostor() As DataTable

        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = "prov.SP_DTW_RequerimientoCotizacionDetallePorPostor"
        cmdSQL.Parameters.Add("@iCodRequerimientoCotizacion", SqlDbType.Int).Value = Me.iCodRequerimientoCotizacion

        Dim readers As SqlDataReader
        readers = cmdSQL.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(readers)
        Return dt
    End Function
End Class
