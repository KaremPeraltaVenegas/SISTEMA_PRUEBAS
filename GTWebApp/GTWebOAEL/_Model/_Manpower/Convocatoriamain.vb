Imports System.Data.SqlClient
Public Class Convocatoriamain
    Public iCodConvocatoriaMain As String
    Public COD_CLIENTE As String
    Public COD_CONVOCATORIA As String
    Public IDREQ As String
    Public iCodCliente As String
    Public iCodClienteCuenta As String
    Public iCodContrata As String
    Public iCodContratistaContrato As String
    Public iCodSubContrata As String
    Public cRUCContrata As String
    Public cSubContrata As String
    Public cNroConvocatoria As String
    Public cSolicitante As String
    Public dFechaSolicitud As String
    Public dFechaAprobacion As String
    Public iCodUsuarioAprueba As String
    Public dFechaIni As String
    Public dFechaFin As String
    Public dFechaLimite As String
    Public iTipo As String
    Public cObs As String
    Public cRutaLista As String
    Public cRutaComprobante As String
    Public cRutaDifusion As String
    Public iEstado As String
    Public cEstado As String
    Public dEstadoFecha As String
    Public iCodUsuarioEstado As String
    Public iCodUsuario As String
    Public dFechaSis As String
    Public iCorrelativo As String
    Public iPeriodo As String
    Public bAprobadoCED As String
    Public bAprobadoCliente As String
    Public dFechaEnvio As String
    Public iCodUsuarioEnvio As String
    Public dFechaDesaAprobacionCliente As String
    Public iCodUsuarioDesaAprobacionCliente As String
    Public qSelect As String
    Public cTipoOpe As Char
    Public bTransaccion As Boolean = False
    Public mc As New ConnectSQL
    Public Function ListaDatos() As DataTable
        Dim Query As String
        Dim readers As DataTable
        Query = "SELECT * FROM dbo.ConvocatoriaMain"
        readers = mc.ExecuteDataTable(Query)
        Return readers
    End Function

    Public Sub Insertar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "INSERT into dbo.ConvocatoriaMain (COD_CLIENTE,COD_CONVOCATORIA,IDREQ,iCodCliente,iCodClienteCuenta,iCodContrata,iCodContratistaContrato,iCodSubContrata,cRUCContrata,cSubContrata,cNroConvocatoria,cSolicitante,dFechaSolicitud,dFechaAprobacion,iCodUsuarioAprueba,dFechaIni,dFechaFin,dFechaLimite,iTipo,cObs,cRutaLista,cRutaComprobante,cRutaDifusion,iEstado,cEstado,dEstadoFecha,iCodUsuarioEstado,iCodUsuario,dFechaSis,iCorrelativo,iPeriodo,bAprobadoCED,bAprobadoCliente,dFechaEnvio,iCodUsuarioEnvio,dFechaDesaAprobacionCliente,iCodUsuarioDesaAprobacionCliente ) VALUES(@COD_CLIENTE,@COD_CONVOCATORIA,@IDREQ,@iCodCliente,@iCodClienteCuenta,@iCodContrata,@iCodContratistaContrato,@iCodSubContrata,@cRUCContrata,@cSubContrata,@cNroConvocatoria,@cSolicitante,@dFechaSolicitud,@dFechaAprobacion,@iCodUsuarioAprueba,@dFechaIni,@dFechaFin,@dFechaLimite,@iTipo,@cObs,@cRutaLista,@cRutaComprobante,@cRutaDifusion,@iEstado,@cEstado,@dEstadoFecha,@iCodUsuarioEstado,@iCodUsuario,@dFechaSis,@iCorrelativo,@iPeriodo,@bAprobadoCED,@bAprobadoCliente,@dFechaEnvio,@iCodUsuarioEnvio,@dFechaDesaAprobacionCliente,@iCodUsuarioDesaAprobacionCliente); SELECT SCOPE_IDENTITY(); "
        cmdSQL.Parameters.Add("@COD_CLIENTE", SqlDbType.Float).Value = Me.COD_CLIENTE
        cmdSQL.Parameters.Add("@COD_CONVOCATORIA", SqlDbType.VarChar, 20).Value = Me.COD_CONVOCATORIA
        cmdSQL.Parameters.Add("@IDREQ", SqlDbType.Float).Value = Me.IDREQ
        cmdSQL.Parameters.Add("@iCodCliente", SqlDbType.Int).Value = Me.iCodCliente
        cmdSQL.Parameters.Add("@iCodClienteCuenta", SqlDbType.Int).Value = Me.iCodClienteCuenta
        cmdSQL.Parameters.Add("@iCodContrata", SqlDbType.Int).Value = Me.iCodContrata
        cmdSQL.Parameters.Add("@iCodContratistaContrato", SqlDbType.Int).Value = Me.iCodContratistaContrato
        cmdSQL.Parameters.Add("@iCodSubContrata", SqlDbType.Int).Value = Me.iCodSubContrata
        cmdSQL.Parameters.Add("@cRUCContrata", SqlDbType.VarChar, 12).Value = Me.cRUCContrata
        cmdSQL.Parameters.Add("@cSubContrata", SqlDbType.VarChar, 80).Value = Me.cSubContrata
        cmdSQL.Parameters.Add("@cNroConvocatoria", SqlDbType.VarChar, 15).Value = Me.cNroConvocatoria
        cmdSQL.Parameters.Add("@cSolicitante", SqlDbType.VarChar, 200).Value = Me.cSolicitante
        cmdSQL.Parameters.Add("@dFechaSolicitud", SqlDbType.Date).Value = Me.dFechaSolicitud
        cmdSQL.Parameters.Add("@dFechaAprobacion", SqlDbType.Date).Value = Me.dFechaAprobacion
        cmdSQL.Parameters.Add("@iCodUsuarioAprueba", SqlDbType.Int).Value = Me.iCodUsuarioAprueba
        cmdSQL.Parameters.Add("@dFechaIni", SqlDbType.Date).Value = Me.dFechaIni
        cmdSQL.Parameters.Add("@dFechaFin", SqlDbType.Date).Value = Me.dFechaFin
        cmdSQL.Parameters.Add("@dFechaLimite", SqlDbType.Date).Value = Me.dFechaLimite
        cmdSQL.Parameters.Add("@iTipo", SqlDbType.TinyInt).Value = Me.iTipo
        cmdSQL.Parameters.Add("@cObs", SqlDbType.VarChar, 250).Value = Me.cObs
        cmdSQL.Parameters.Add("@cRutaLista", SqlDbType.VarChar, 200).Value = Me.cRutaLista
        cmdSQL.Parameters.Add("@cRutaComprobante", SqlDbType.VarChar, 200).Value = Me.cRutaComprobante
        cmdSQL.Parameters.Add("@cRutaDifusion", SqlDbType.VarChar, 200).Value = Me.cRutaDifusion
        cmdSQL.Parameters.Add("@iEstado", SqlDbType.TinyInt).Value = Me.iEstado
        cmdSQL.Parameters.Add("@cEstado", SqlDbType.Char, 2).Value = Me.cEstado
        cmdSQL.Parameters.Add("@dEstadoFecha", SqlDbType.DateTime).Value = Me.dEstadoFecha
        cmdSQL.Parameters.Add("@iCodUsuarioEstado", SqlDbType.Int).Value = Me.iCodUsuarioEstado
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.DateTime).Value = Me.dFechaSis

        If Me.iCorrelativo = "NULL" Then
            cmdSQL.Parameters.Add("@iCorrelativo", SqlDbType.Int).Value = DBNull.Value
        Else

            cmdSQL.Parameters.Add("@iCorrelativo", SqlDbType.Int).Value = CInt(Me.iCorrelativo)
        End If

        cmdSQL.Parameters.Add("@iPeriodo", SqlDbType.SmallInt).Value = Me.iPeriodo

        If Me.bAprobadoCED = "NULL" Then
            cmdSQL.Parameters.Add("@bAprobadoCED", SqlDbType.Bit).Value = DBNull.Value
        Else
            cmdSQL.Parameters.Add("@bAprobadoCED", SqlDbType.Bit).Value = Me.bAprobadoCED
        End If

        If Me.bAprobadoCliente = "NULL" Then
            cmdSQL.Parameters.Add("@bAprobadoCliente", SqlDbType.Bit).Value = DBNull.Value
        Else
            cmdSQL.Parameters.Add("@bAprobadoCliente", SqlDbType.Bit).Value = Me.bAprobadoCliente
        End If

        If Me.dFechaEnvio = "NULL" Then
            cmdSQL.Parameters.Add("@dFechaEnvio", SqlDbType.DateTime).Value = DBNull.Value
        Else
            cmdSQL.Parameters.Add("@dFechaEnvio", SqlDbType.DateTime).Value = Me.dFechaEnvio
        End If

        If Me.iCodUsuarioEnvio = "NULL" Then
            cmdSQL.Parameters.Add("@iCodUsuarioEnvio", SqlDbType.Int).Value = DBNull.Value

        Else
            cmdSQL.Parameters.Add("@iCodUsuarioEnvio", SqlDbType.Int).Value = Me.iCodUsuarioEnvio
        End If

        If Me.dFechaDesaAprobacionCliente = "NULL" Then
            cmdSQL.Parameters.Add("@dFechaDesaAprobacionCliente", SqlDbType.DateTime).Value = DBNull.Value
        Else
            cmdSQL.Parameters.Add("@dFechaDesaAprobacionCliente", SqlDbType.DateTime).Value = Me.dFechaDesaAprobacionCliente
        End If

        If Me.iCodUsuarioDesaAprobacionCliente = "NULL" Then
            cmdSQL.Parameters.Add("@iCodUsuarioDesaAprobacionCliente", SqlDbType.Int).Value = DBNull.Value

        Else
            cmdSQL.Parameters.Add("@iCodUsuarioDesaAprobacionCliente", SqlDbType.Int).Value = Me.iCodUsuarioDesaAprobacionCliente
        End If

        Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
        If pCodInsert > 0 Then
            Me.iCodConvocatoriaMain = pCodInsert
        Else
            Me.iCodConvocatoriaMain = 0
        End If
    End Sub
    Public Sub InsertarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "INSERT into dbo.ConvocatoriaMain (COD_CLIENTE,COD_CONVOCATORIA,IDREQ,iCodCliente,iCodClienteCuenta,iCodContrata,iCodContratistaContrato,iCodSubContrata,cRUCContrata,cSubContrata,cNroConvocatoria,cSolicitante,dFechaSolicitud,dFechaAprobacion,iCodUsuarioAprueba,dFechaIni,dFechaFin,dFechaLimite,iTipo,cObs,cRutaLista,cRutaComprobante,cRutaDifusion,iEstado,cEstado,dEstadoFecha,iCodUsuarioEstado,iCodUsuario,dFechaSis,iCorrelativo,iPeriodo,bAprobadoCED,bAprobadoCliente,dFechaEnvio,iCodUsuarioEnvio ) VALUES(@COD_CLIENTE,@COD_CONVOCATORIA,@IDREQ,@iCodCliente,@iCodClienteCuenta,@iCodContrata,@iCodContratistaContrato,@iCodSubContrata,@cRUCContrata,@cSubContrata,@cNroConvocatoria,@cSolicitante,@dFechaSolicitud,@dFechaAprobacion,@iCodUsuarioAprueba,@dFechaIni,@dFechaFin,@dFechaLimite,@iTipo,@cObs,@cRutaLista,@cRutaComprobante,@cRutaDifusion,@iEstado,@cEstado,@dEstadoFecha,@iCodUsuarioEstado,@iCodUsuario,@dFechaSis,@iCorrelativo,@iPeriodo,@bAprobadoCED,@bAprobadoCliente,@dFechaEnvio,@iCodUsuarioEnvio); SELECT SCOPE_IDENTITY(); "
        cmdSQL.Parameters.Add("@COD_CLIENTE", SqlDbType.Float).Value = Me.COD_CLIENTE
        cmdSQL.Parameters.Add("@COD_CONVOCATORIA", SqlDbType.VarChar, 20).Value = Me.COD_CONVOCATORIA
        cmdSQL.Parameters.Add("@IDREQ", SqlDbType.Float).Value = Me.IDREQ
        cmdSQL.Parameters.Add("@iCodCliente", SqlDbType.Int).Value = Me.iCodCliente
        cmdSQL.Parameters.Add("@iCodClienteCuenta", SqlDbType.Int).Value = Me.iCodClienteCuenta
        cmdSQL.Parameters.Add("@iCodContrata", SqlDbType.Int).Value = Me.iCodContrata
        cmdSQL.Parameters.Add("@iCodContratistaContrato", SqlDbType.Int).Value = Me.iCodContratistaContrato
        cmdSQL.Parameters.Add("@iCodSubContrata", SqlDbType.Int).Value = Me.iCodSubContrata
        cmdSQL.Parameters.Add("@cRUCContrata", SqlDbType.VarChar, 12).Value = Me.cRUCContrata
        cmdSQL.Parameters.Add("@cSubContrata", SqlDbType.VarChar, 80).Value = Me.cSubContrata
        cmdSQL.Parameters.Add("@cNroConvocatoria", SqlDbType.VarChar, 15).Value = Me.cNroConvocatoria
        cmdSQL.Parameters.Add("@cSolicitante", SqlDbType.VarChar, 200).Value = Me.cSolicitante
        cmdSQL.Parameters.Add("@dFechaSolicitud", SqlDbType.Date).Value = Me.dFechaSolicitud
        cmdSQL.Parameters.Add("@dFechaAprobacion", SqlDbType.Date).Value = Me.dFechaAprobacion
        cmdSQL.Parameters.Add("@iCodUsuarioAprueba", SqlDbType.Int).Value = Me.iCodUsuarioAprueba
        cmdSQL.Parameters.Add("@dFechaIni", SqlDbType.Date).Value = Me.dFechaIni
        cmdSQL.Parameters.Add("@dFechaFin", SqlDbType.Date).Value = Me.dFechaFin
        cmdSQL.Parameters.Add("@dFechaLimite", SqlDbType.Date).Value = Me.dFechaLimite
        cmdSQL.Parameters.Add("@iTipo", SqlDbType.TinyInt).Value = Me.iTipo
        cmdSQL.Parameters.Add("@cObs", SqlDbType.VarChar, 250).Value = Me.cObs
        cmdSQL.Parameters.Add("@cRutaLista", SqlDbType.VarChar, 200).Value = Me.cRutaLista
        cmdSQL.Parameters.Add("@cRutaComprobante", SqlDbType.VarChar, 200).Value = Me.cRutaComprobante
        cmdSQL.Parameters.Add("@cRutaDifusion", SqlDbType.VarChar, 200).Value = Me.cRutaDifusion
        cmdSQL.Parameters.Add("@iEstado", SqlDbType.TinyInt).Value = Me.iEstado
        cmdSQL.Parameters.Add("@cEstado", SqlDbType.Char, 2).Value = Me.cEstado
        cmdSQL.Parameters.Add("@dEstadoFecha", SqlDbType.DateTime).Value = Me.dEstadoFecha
        cmdSQL.Parameters.Add("@iCodUsuarioEstado", SqlDbType.Int).Value = Me.iCodUsuarioEstado
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.DateTime).Value = Me.dFechaSis
        cmdSQL.Parameters.Add("@iCorrelativo", SqlDbType.SmallInt).Value = Me.iCorrelativo
        cmdSQL.Parameters.Add("@iPeriodo", SqlDbType.SmallInt).Value = Me.iPeriodo
        cmdSQL.Parameters.Add("@bAprobadoCED", SqlDbType.Bit).Value = Me.bAprobadoCED
        cmdSQL.Parameters.Add("@bAprobadoCliente", SqlDbType.Bit).Value = Me.bAprobadoCliente
        cmdSQL.Parameters.Add("@dFechaEnvio", SqlDbType.DateTime).Value = Me.dFechaEnvio
        cmdSQL.Parameters.Add("@iCodUsuarioEnvio", SqlDbType.Int).Value = Me.iCodUsuarioEnvio

        Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
        If pCodInsert > 0 Then
            Me.iCodConvocatoriaMain = pCodInsert
        Else
            Me.iCodConvocatoriaMain = 0
        End If
    End Sub
    Public Sub Modificar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "UPDATE  dbo.ConvocatoriaMain SET COD_CLIENTE=@COD_CLIENTE,COD_CONVOCATORIA=@COD_CONVOCATORIA,IDREQ=@IDREQ,iCodCliente=@iCodCliente,iCodClienteCuenta=@iCodClienteCuenta,iCodContrata=@iCodContrata,iCodContratistaContrato=@iCodContratistaContrato,iCodSubContrata=@iCodSubContrata,cRUCContrata=@cRUCContrata,cSubContrata=@cSubContrata,cNroConvocatoria=@cNroConvocatoria,cSolicitante=@cSolicitante,dFechaSolicitud=@dFechaSolicitud,dFechaAprobacion=@dFechaAprobacion,iCodUsuarioAprueba=@iCodUsuarioAprueba,dFechaIni=@dFechaIni,dFechaFin=@dFechaFin,dFechaLimite=@dFechaLimite,iTipo=@iTipo,cObs=@cObs,cRutaLista=@cRutaLista,cRutaComprobante=@cRutaComprobante,cRutaDifusion=@cRutaDifusion,iEstado=@iEstado,cEstado=@cEstado,dEstadoFecha=@dEstadoFecha,iCodUsuarioEstado=@iCodUsuarioEstado,iCodUsuario=@iCodUsuario,dFechaSis=@dFechaSis,iCorrelativo=@iCorrelativo,iPeriodo=@iPeriodo,bAprobadoCED=@bAprobadoCED,bAprobadoCliente=@bAprobadoCliente,dFechaEnvio=@dFechaEnvio,iCodUsuarioEnvio=@iCodUsuarioEnvio WHERE iCodConvocatoriaMain=@iCodConvocatoriaMain"
        cmdSQL.Parameters.Add("@iCodConvocatoriaMain", SqlDbType.Int).Value = Me.iCodConvocatoriaMain
        cmdSQL.Parameters.Add("@COD_CLIENTE", SqlDbType.Float).Value = Me.COD_CLIENTE
        cmdSQL.Parameters.Add("@COD_CONVOCATORIA", SqlDbType.VarChar, 20).Value = Me.COD_CONVOCATORIA
        cmdSQL.Parameters.Add("@IDREQ", SqlDbType.Float).Value = Me.IDREQ
        cmdSQL.Parameters.Add("@iCodCliente", SqlDbType.Int).Value = Me.iCodCliente
        cmdSQL.Parameters.Add("@iCodClienteCuenta", SqlDbType.Int).Value = Me.iCodClienteCuenta
        cmdSQL.Parameters.Add("@iCodContrata", SqlDbType.Int).Value = Me.iCodContrata
        cmdSQL.Parameters.Add("@iCodContratistaContrato", SqlDbType.Int).Value = Me.iCodContratistaContrato
        cmdSQL.Parameters.Add("@iCodSubContrata", SqlDbType.Int).Value = Me.iCodSubContrata
        cmdSQL.Parameters.Add("@cRUCContrata", SqlDbType.VarChar, 12).Value = Me.cRUCContrata
        cmdSQL.Parameters.Add("@cSubContrata", SqlDbType.VarChar, 80).Value = Me.cSubContrata
        cmdSQL.Parameters.Add("@cNroConvocatoria", SqlDbType.VarChar, 15).Value = Me.cNroConvocatoria
        cmdSQL.Parameters.Add("@cSolicitante", SqlDbType.VarChar, 200).Value = Me.cSolicitante
        cmdSQL.Parameters.Add("@dFechaSolicitud", SqlDbType.Date).Value = Me.dFechaSolicitud
        cmdSQL.Parameters.Add("@dFechaAprobacion", SqlDbType.Date).Value = Me.dFechaAprobacion
        cmdSQL.Parameters.Add("@iCodUsuarioAprueba", SqlDbType.Int).Value = Me.iCodUsuarioAprueba
        cmdSQL.Parameters.Add("@dFechaIni", SqlDbType.Date).Value = Me.dFechaIni
        cmdSQL.Parameters.Add("@dFechaFin", SqlDbType.Date).Value = Me.dFechaFin
        cmdSQL.Parameters.Add("@dFechaLimite", SqlDbType.Date).Value = Me.dFechaLimite
        cmdSQL.Parameters.Add("@iTipo", SqlDbType.TinyInt).Value = Me.iTipo
        cmdSQL.Parameters.Add("@cObs", SqlDbType.VarChar, 250).Value = Me.cObs
        cmdSQL.Parameters.Add("@cRutaLista", SqlDbType.VarChar, 200).Value = Me.cRutaLista
        cmdSQL.Parameters.Add("@cRutaComprobante", SqlDbType.VarChar, 200).Value = Me.cRutaComprobante
        cmdSQL.Parameters.Add("@cRutaDifusion", SqlDbType.VarChar, 200).Value = Me.cRutaDifusion
        cmdSQL.Parameters.Add("@iEstado", SqlDbType.TinyInt).Value = Me.iEstado
        cmdSQL.Parameters.Add("@cEstado", SqlDbType.Char, 2).Value = Me.cEstado
        cmdSQL.Parameters.Add("@dEstadoFecha", SqlDbType.DateTime).Value = Me.dEstadoFecha
        cmdSQL.Parameters.Add("@iCodUsuarioEstado", SqlDbType.Int).Value = Me.iCodUsuarioEstado
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.DateTime).Value = Me.dFechaSis
        cmdSQL.Parameters.Add("@iCorrelativo", SqlDbType.SmallInt).Value = Me.iCorrelativo
        cmdSQL.Parameters.Add("@iPeriodo", SqlDbType.SmallInt).Value = Me.iPeriodo
        cmdSQL.Parameters.Add("@bAprobadoCED", SqlDbType.Bit).Value = Me.bAprobadoCED
        cmdSQL.Parameters.Add("@bAprobadoCliente", SqlDbType.Bit).Value = Me.bAprobadoCliente
        cmdSQL.Parameters.Add("@dFechaEnvio", SqlDbType.DateTime).Value = Me.dFechaEnvio
        cmdSQL.Parameters.Add("@iCodUsuarioEnvio", SqlDbType.Int).Value = Me.iCodUsuarioEnvio

        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub ModificarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "UPDATE  dbo.ConvocatoriaMain SET COD_CLIENTE=@COD_CLIENTE,COD_CONVOCATORIA=@COD_CONVOCATORIA,IDREQ=@IDREQ,iCodCliente=@iCodCliente,iCodClienteCuenta=@iCodClienteCuenta,iCodContrata=@iCodContrata,iCodContratistaContrato=@iCodContratistaContrato,iCodSubContrata=@iCodSubContrata,cRUCContrata=@cRUCContrata,cSubContrata=@cSubContrata,cNroConvocatoria=@cNroConvocatoria,cSolicitante=@cSolicitante,dFechaSolicitud=@dFechaSolicitud,dFechaAprobacion=@dFechaAprobacion,iCodUsuarioAprueba=@iCodUsuarioAprueba,dFechaIni=@dFechaIni,dFechaFin=@dFechaFin,dFechaLimite=@dFechaLimite,iTipo=@iTipo,cObs=@cObs,cRutaLista=@cRutaLista,cRutaComprobante=@cRutaComprobante,cRutaDifusion=@cRutaDifusion,iEstado=@iEstado,cEstado=@cEstado,dEstadoFecha=@dEstadoFecha,iCodUsuarioEstado=@iCodUsuarioEstado,iCodUsuario=@iCodUsuario,dFechaSis=@dFechaSis,iCorrelativo=@iCorrelativo,iPeriodo=@iPeriodo,bAprobadoCED=@bAprobadoCED,bAprobadoCliente=@bAprobadoCliente,dFechaEnvio=@dFechaEnvio,iCodUsuarioEnvio=@iCodUsuarioEnvio WHERE iCodConvocatoriaMain=@iCodConvocatoriaMain"
        cmdSQL.Parameters.Add("@iCodConvocatoriaMain", SqlDbType.Int).Value = Me.iCodConvocatoriaMain
        cmdSQL.Parameters.Add("@COD_CLIENTE", SqlDbType.Float).Value = Me.COD_CLIENTE
        cmdSQL.Parameters.Add("@COD_CONVOCATORIA", SqlDbType.VarChar, 20).Value = Me.COD_CONVOCATORIA
        cmdSQL.Parameters.Add("@IDREQ", SqlDbType.Float).Value = Me.IDREQ
        cmdSQL.Parameters.Add("@iCodCliente", SqlDbType.Int).Value = Me.iCodCliente
        cmdSQL.Parameters.Add("@iCodClienteCuenta", SqlDbType.Int).Value = Me.iCodClienteCuenta
        cmdSQL.Parameters.Add("@iCodContrata", SqlDbType.Int).Value = Me.iCodContrata
        cmdSQL.Parameters.Add("@iCodContratistaContrato", SqlDbType.Int).Value = Me.iCodContratistaContrato
        cmdSQL.Parameters.Add("@iCodSubContrata", SqlDbType.Int).Value = Me.iCodSubContrata
        cmdSQL.Parameters.Add("@cRUCContrata", SqlDbType.VarChar, 12).Value = Me.cRUCContrata
        cmdSQL.Parameters.Add("@cSubContrata", SqlDbType.VarChar, 80).Value = Me.cSubContrata
        cmdSQL.Parameters.Add("@cNroConvocatoria", SqlDbType.VarChar, 15).Value = Me.cNroConvocatoria
        cmdSQL.Parameters.Add("@cSolicitante", SqlDbType.VarChar, 200).Value = Me.cSolicitante
        cmdSQL.Parameters.Add("@dFechaSolicitud", SqlDbType.Date).Value = Me.dFechaSolicitud
        cmdSQL.Parameters.Add("@dFechaAprobacion", SqlDbType.Date).Value = Me.dFechaAprobacion
        cmdSQL.Parameters.Add("@iCodUsuarioAprueba", SqlDbType.Int).Value = Me.iCodUsuarioAprueba
        cmdSQL.Parameters.Add("@dFechaIni", SqlDbType.Date).Value = Me.dFechaIni
        cmdSQL.Parameters.Add("@dFechaFin", SqlDbType.Date).Value = Me.dFechaFin
        cmdSQL.Parameters.Add("@dFechaLimite", SqlDbType.Date).Value = Me.dFechaLimite
        cmdSQL.Parameters.Add("@iTipo", SqlDbType.TinyInt).Value = Me.iTipo
        cmdSQL.Parameters.Add("@cObs", SqlDbType.VarChar, 250).Value = Me.cObs
        cmdSQL.Parameters.Add("@cRutaLista", SqlDbType.VarChar, 200).Value = Me.cRutaLista
        cmdSQL.Parameters.Add("@cRutaComprobante", SqlDbType.VarChar, 200).Value = Me.cRutaComprobante
        cmdSQL.Parameters.Add("@cRutaDifusion", SqlDbType.VarChar, 200).Value = Me.cRutaDifusion
        cmdSQL.Parameters.Add("@iEstado", SqlDbType.TinyInt).Value = Me.iEstado
        cmdSQL.Parameters.Add("@cEstado", SqlDbType.Char, 2).Value = Me.cEstado
        cmdSQL.Parameters.Add("@dEstadoFecha", SqlDbType.DateTime).Value = Me.dEstadoFecha
        cmdSQL.Parameters.Add("@iCodUsuarioEstado", SqlDbType.Int).Value = Me.iCodUsuarioEstado
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.DateTime).Value = Me.dFechaSis
        cmdSQL.Parameters.Add("@iCorrelativo", SqlDbType.SmallInt).Value = Me.iCorrelativo
        cmdSQL.Parameters.Add("@iPeriodo", SqlDbType.SmallInt).Value = Me.iPeriodo
        cmdSQL.Parameters.Add("@bAprobadoCED", SqlDbType.Bit).Value = Me.bAprobadoCED
        cmdSQL.Parameters.Add("@bAprobadoCliente", SqlDbType.Bit).Value = Me.bAprobadoCliente
        cmdSQL.Parameters.Add("@dFechaEnvio", SqlDbType.DateTime).Value = Me.dFechaEnvio
        cmdSQL.Parameters.Add("@iCodUsuarioEnvio", SqlDbType.Int).Value = Me.iCodUsuarioEnvio

        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub Eliminar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "DELETE from  dbo.ConvocatoriaMain  WHERE iCodConvocatoriaMain=@iCodConvocatoriaMain"
        'cmdSQL.CommandText = "UPDATE dbo.ConvocatoriaMain  SET bAnulado=1 WHERE  iCodConvocatoriaMain=@iCodConvocatoriaMain"
        cmdSQL.Parameters.Add("@iCodConvocatoriaMain", SqlDbType.Int).Value = Me.iCodConvocatoriaMain
        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub EliminarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "DELETE from  dbo.ConvocatoriaMain  WHERE iCodConvocatoriaMain=@iCodConvocatoriaMain"
        'cmdSQL.CommandText = "UPDATE dbo.ConvocatoriaMain  SET bAnulado=1 WHERE  iCodConvocatoriaMain=@iCodConvocatoriaMain"
        cmdSQL.Parameters.Add("@iCodConvocatoriaMain", SqlDbType.Int).Value = Me.iCodConvocatoriaMain
        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub getRecord()
        Dim readers As IDataReader
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL

        If bTransaccion = True Then cmdSQL.Transaction = Me.mc.miTransact Else 

        cmdSQL.CommandText = "SELECT * FROM dbo.ConvocatoriaMain WHERE iCodConvocatoriaMain=@iCodConvocatoriaMain"
        cmdSQL.Parameters.Add("@iCodConvocatoriaMain", SqlDbType.Int).Value = Me.iCodConvocatoriaMain
        readers = cmdSQL.ExecuteReader
        If readers.Read() Then
            Me.iCodConvocatoriaMain = CStr(readers.GetValue(0))
            Me.COD_CLIENTE = CStr(readers.GetValue(1))
            Me.COD_CONVOCATORIA = CStr(readers.GetValue(2))
            Me.IDREQ = CStr(readers.GetValue(3))
            Me.iCodCliente = CStr(readers.GetValue(4))
            Me.iCodClienteCuenta = CStr(readers.GetValue(5))
            Me.iCodContrata = CStr(readers.GetValue(6))
            Me.iCodContratistaContrato = CStr(readers.GetValue(7))
            Me.iCodSubContrata = CStr(readers.GetValue(8))
            Me.cRUCContrata = CStr(readers.GetValue(9))
            Me.cSubContrata = CStr(readers.GetValue(10))
            Me.cNroConvocatoria = CStr(readers.GetValue(11))
            Me.cSolicitante = CStr(readers.GetValue(12))
            Me.dFechaSolicitud = CStr(readers.GetValue(13))
            Me.dFechaAprobacion = CStr(IIf(readers.GetValue(14) Is DBNull.Value, "NULL", readers.GetValue(14)))
            Me.iCodUsuarioAprueba = CStr(readers.GetValue(15))
            Me.dFechaIni = CStr(readers.GetValue(16))
            Me.dFechaFin = CStr(readers.GetValue(17))
            Me.dFechaLimite = CStr(readers.GetValue(18))
            Me.iTipo = CStr(readers.GetValue(19))
            Me.cObs = CStr(readers.GetValue(20))
            Me.cRutaLista = CStr(readers.GetValue(21))
            Me.cRutaComprobante = CStr(readers.GetValue(22))
            Me.cRutaDifusion = CStr(readers.GetValue(23))
            Me.iEstado = CStr(readers.GetValue(24))
            Me.cEstado = CStr(readers.GetValue(25))
            Me.dEstadoFecha = CStr(readers.GetValue(26))
            Me.iCodUsuarioEstado = CStr(readers.GetValue(27))
            Me.iCodUsuario = CStr(readers.GetValue(28))
            Me.dFechaSis = CStr(readers.GetValue(29))
            Me.iCorrelativo = CStr(readers.GetValue(30))
            Me.iPeriodo = CStr(readers.GetValue(31))
            Me.bAprobadoCED = CStr(IIf(readers.GetValue(32) Is DBNull.Value, "NULL", readers.GetValue(32)))
            Me.bAprobadoCliente = CStr(IIf(readers.GetValue(33) Is DBNull.Value, "NULL", readers.GetValue(33)))
            Me.dFechaEnvio = CStr(IIf(readers.GetValue(34) Is DBNull.Value, "NULL", readers.GetValue(34)))
            Me.iCodUsuarioEnvio = CStr(IIf(readers.GetValue(35) Is DBNull.Value, "NULL", readers.GetValue(35)))
            Me.dFechaDesaAprobacionCliente = CStr(IIf(readers.GetValue(36) Is DBNull.Value, "NULL", readers.GetValue(36)))
            Me.iCodUsuarioDesaAprobacionCliente = CStr(IIf(readers.GetValue(37) Is DBNull.Value, "NULL", readers.GetValue(37)))
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
        cmdSQL.CommandText = "SELECT * FROM dbo.ConvocatoriaMain"
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


    '*******************************************************************************************************************
    '*******************************************************************************************************************
    Public Function ListaTipoConvocatoria() As DataTable
        Dim miDataTable As New DataTable
        miDataTable.Columns.Add("ValueMember")
        miDataTable.Columns.Add("DisplayMember")
        With miDataTable
            .Rows.Add("1", "REGULAR")
            '.Rows.Add("2", "REQ. EXCEPTUADO")
            .Rows.Add("6", "PGI")
            .Rows.Add("3", "REQ. ADICIONAL")
            .Rows.Add("4", "REQ. DISPENSADO")
            .Rows.Add("5", "MARATON")
            .Rows.Add("9", "OTROS")
        End With
        Return miDataTable
    End Function

    Public Function ListaConvocatorias() As DataTable
        Dim Query As String
        Dim readers As DataTable
        Query = String.Format("Select iCodConvocatoriaMain as ValueMember,cNroConvocatoria as DisplayMember from ConvocatoriaMain where iCodContratistaContrato={0} ", Me.iCodContratistaContrato)
        readers = mc.ExecuteDataTable(Query)
        Return readers
    End Function
    Public Function ListaConvocatoriasByEmpresa() As DataTable
        Dim Query As String
        Dim readers As DataTable
        Query = String.Format("Select iCodConvocatoriaMain as ValueMember,cNroConvocatoria as DisplayMember from ConvocatoriaMain where iCodContratistaContrato={0} ", Me.iCodContratistaContrato)
        readers = mc.ExecuteDataTable(Query)
        Return readers
    End Function

    '****************************************************************
    Public Function ListaConvocatoriasByContrata() As DataTable
        Dim Query As String
        Dim readers As DataTable
        Query = " exec dbo.SP_DT_ConvocatoriasByContrata " & _
                       " @iCodContrata='" & Trim(Me.iCodContrata) & "'"
        'InputBox("", "", Query)
        readers = mc.ExecuteDataTable(Query)
        Return readers
    End Function

    Public Function ListaPostulantesByConvocatoria() As DataTable
        Dim Query As String
        Dim readers As DataTable
        Query = " exec dbo.SP_DTW_PostulantesByConvocatoria " & _
                       " @iCodConvocatoriaMain='" & Trim(Me.iCodConvocatoriaMain) & "'"
        'InputBox("", "", Query)
        readers = mc.ExecuteDataTable(Query)
        Return readers
    End Function
    Public Function ListaPostulantesRankingByConvocatoria() As DataTable

        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = "SP_DTW_PostulantesByConvocatoriaRanking"
        cmdSQL.Parameters.Add("@iCodConvocatoriaMain", SqlDbType.Int).Value = Me.iCodConvocatoriaMain
 
        Dim readers As SqlDataReader
        readers = cmdSQL.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(readers)
        Return dt
    End Function
    Public Function ListaPostulantesRankingByConvocatoriaSistema() As DataTable

        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = "SP_DTW_PostulantesByConvocatoriaRankingSistema"
        cmdSQL.Parameters.Add("@iCodConvocatoriaMain", SqlDbType.Int).Value = Me.iCodConvocatoriaMain

        Dim readers As SqlDataReader
        readers = cmdSQL.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(readers)
        Return dt
    End Function
    '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    Public Function ListaConvocatoriasPorContrata() As DataTable
        Dim Query As String
        Dim readers As DataTable
        Query = " exec dbo.SP_DT_ConvocatoriasPorContrata " &
                       " @iCodContrata='" & Trim(Me.iCodContrata) & "'"
        'InputBox("", "", Query)
        readers = mc.ExecuteDataTable(Query)
        Return readers
    End Function

    Public Function GetConvocatoriaMainPorCodigo(ByVal _iCodConvocatoriaMain As Integer) As DataTable
        Dim Query As String = ""
        Dim readers As DataTable

        Query = " exec dbo.SP_ROW_GetConvocatoriaMain" &
                       " @iCodConvocatoriaMain=" & Trim(_iCodConvocatoriaMain)

        readers = mc.ExecuteDataTable(Query)
        Return readers
    End Function
    Public Function SP_ELIM_ConvocatoriaMainAntesCrearDetalles(ByVal _pCodConvocatoriaMain As Integer) As Integer
        Dim Query As String = ""
        Dim readers As IDataReader
        Dim respuesta As Integer

        Query = " exec dbo.SP_ELIM_ConvocatoriaMainAntesCrearDetalles " &
                       " @iCodConvocatoriaMain=" & Trim(_pCodConvocatoriaMain)

        readers = mc.ExecuteReader(Query)
        While readers.Read()
            respuesta = CInt(readers.GetValue(0))
        End While
        Return respuesta
    End Function

    Public Function EnviarConvocatoriaCED(ByVal p_iCodConvocatoriaMain As String, ByVal p_dFechaEnvio As String, ByVal p_iCodUsuarioEnvio As String) As Integer
        Dim Query As String = ""
        Dim readers As IDataReader
        Dim respuesta As Integer

        Query = " exec dbo.SP_ACTU_EnviarConvocatoriaCED " &
                       " @iCodConvocatoriaMain=" & Trim(p_iCodConvocatoriaMain) & "," &
                       " @dFechaEnvio='" & Trim(p_dFechaEnvio) & "'," &
                       " @iCodUsuarioEnvio=" & Trim(p_iCodUsuarioEnvio)

        readers = mc.ExecuteReader(Query)
        While readers.Read()
            respuesta = CInt(readers.GetValue(0))
        End While
        Return respuesta
    End Function
    Public Function AprobarFinalizarClienteConvocatoria(ByVal p_iCodConvocatoriaMain As String, ByVal p_iCodUsuarioAprueba As String) As Integer
        Dim Query As String = ""
        Dim readers As IDataReader
        Dim respuesta As Integer

        Query = " exec dbo.SP_ACTU_AprobarActualizarClienteConvocatoria " &
                       "@iCodConvocatoriaMain=" & Trim(p_iCodConvocatoriaMain) & "," &
                       " @iCodUsuarioAprueba=" & Trim(p_iCodUsuarioAprueba)

        readers = mc.ExecuteReader(Query)
        While readers.Read()
            respuesta = CInt(readers.GetValue(0))
        End While
        Return respuesta
    End Function

    Public Function DesaprobarFinalizarClienteConvocatoria(ByVal p_iCodConvocatoriaMain As String, ByVal p_iCodUsuarioAprueba As String) As Integer
        Dim Query As String = ""
        Dim readers As IDataReader
        Dim respuesta As Integer

        Query = " exec dbo.SP_ACTU_DesaprobarActualizarClienteConvocatoria " &
                       "@iCodConvocatoriaMain=" & Trim(p_iCodConvocatoriaMain) & "," &
                       " @iCodUsuarioAprueba=" & Trim(p_iCodUsuarioAprueba)

        readers = mc.ExecuteReader(Query)
        While readers.Read()
            respuesta = CInt(readers.GetValue(0))
        End While
        Return respuesta
    End Function

    Public Function ListaConvocatoriasPendientesDeClientePorContrata() As DataTable
        Dim Query As String
        Dim readers As DataTable
        Query = " exec dbo.SP_DT_ConvocatoriasPendientesClientePorContrata " &
                       " @iCodContrata='" & Trim(Me.iCodContrata) & "'"
        readers = mc.ExecuteDataTable(Query)
        Return readers
    End Function
    Public Function ListaConvocatoriasAprobadasCEDPorContrata() As DataTable
        Dim Query As String
        Dim readers As DataTable
        Query = " exec dbo.SP_DT_ConvocatoriasAprobadasCEDPorContrata " &
                       " @iCodContrata='" & Trim(Me.iCodContrata) & "'"
        readers = mc.ExecuteDataTable(Query)
        Return readers
    End Function
    Public Function AnulacionConvocatoriaMain(ByVal _pCodConvocatoriaMain As Integer) As Integer
        Dim Query As String = ""
        Dim readers As IDataReader
        Dim respuesta As Integer

        Query = " exec dbo.SP_ACTU_ConvocatoriaMainAnulacion " &
                       " @iCodConvocatoriaMain=" & Trim(_pCodConvocatoriaMain)

        readers = mc.ExecuteReader(Query)
        While readers.Read()
            respuesta = CInt(readers.GetValue(0))
        End While
        Return respuesta
    End Function


    Public Function ListaConvocatoriasPorContrataFeedback() As DataTable
        'Dim Query As String
        'Dim readers As DataTable
        'Query = " exec dbo.SP_DT_ConvocatoriasByContrata " & _
        '               " @iCodContrata='" & Trim(Me.iCodContrata) & "'"
        ''InputBox("", "", Query)
        'readers = mc.ExecuteDataTable(Query)
        'Return readers


        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = "dbo.SP_DTW_ConvocatoriasPorContrataFeedback"
        cmdSQL.Parameters.Add("@iCodContrata", SqlDbType.Int).Value = Me.iCodContrata

        Dim readers As SqlDataReader
        readers = cmdSQL.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(readers)
        Return dt

    End Function
End Class
