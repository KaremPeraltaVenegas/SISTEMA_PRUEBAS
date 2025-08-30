Imports System.Data.SqlClient
Public Class Requerimiento
    Public iCodRequerimiento As String
    Public iCodCliente As String
    Public iCodclienteCuenta As String
    Public iCodContrata As String
    Public iCodContratistaContrato As String
    Public iCodSubContrata As String
    Public iCodTipoMoneda As String
    Public iCodTipoRequerimiento As String
    Public iCodTipoEstadoRequerimiento As String
    Public cEstado As String
    Public iPeriodo As String
    Public iCorrelativo As String
    Public cNroRequerimiento As String
    Public cSolicitante As String
    Public dFechaSolicitud As String
    Public iCodUsuarioSolicitud As String
    Public dFechaEnvio As String
    Public iCodUsuarioEnvio As String
    Public dFechaAprobacion As String
    Public iCodUsuarioAprueba As String
    Public bAprobado As String
    Public dFechaDesaAprobacionCliente As String
    Public iCodUsuarioDesaAprobacionCliente As String
    Public bAprobadoCliente As String
    Public cObs As String
    Public iCodUsuarioEstado As String
    Public dFechaEstado As String
    Public dFechaConvocatoriaIni As String
    Public dFechaConvocatoriaFin As String
    Public dFechaRegistroIni As String
    Public dFechaRegistroFin As String
    Public bFechaConsultas As String
    Public dFechaConsultasIni As String
    Public dFechaConsultasFin As String
    Public bFechaRespuestas As String
    Public dFechaRespuestasIni As String
    Public dFechaRespuestasFin As String
    Public bFechaIntegracion As String
    Public dFechaIntegracionIni As String
    Public dFechaIntegracionFin As String
    Public bFechaPresentaOferta As String
    Public dFechaPresentaOfertaIni As String
    Public dFechaPresentaOfertaFin As String
    Public bFechaEvaluacion As String
    Public dFechaEvaluacionIni As String
    Public dFechaEvaluacionFin As String
    Public dFechaAdjudicado As String
    Public cAlcanceRequerimiento As String
    Public cTerminosPago As String
    Public bFechaTiempoServicio As String
    Public dFechaTiempoServicioIni As String
    Public dFechaTiempoServicioFin As String
    Public cLogRequerimiento As String
    Public cUrlDocumentos As String
    Public cUrlCarpeta As String
    Public bLiberado As String
    Public iCodUsuarioLiberado As String
    Public dFechaLiberado As String
    Public cMotivoLiberado As String
    Public cNotasLiberado As String
    Public iCodUsuarioCreacion As String
    Public dFechaCreacion As String
    Public iCodUsuarioModificacion As String
    Public dFechaModificacion As String
    Public qSelect As String
    Public cTipoOpe As Char
    Public bTransaccion As Boolean = False
    Public mc As New ConnectSQL
    Public Function ListaDatos() As DataTable
        Dim Query As String
        Dim readers As DataTable
        Query = "SELECT * FROM prov.Requerimiento"
        readers = mc.ExecuteDataTable(Query)
        Return readers
    End Function
    Public Sub Insertar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "INSERT into prov.Requerimiento (iCodCliente,iCodclienteCuenta,iCodContrata,iCodContratistaContrato,iCodSubContrata,iCodTipoMoneda,iCodTipoRequerimiento,iCodTipoEstadoRequerimiento,cEstado,iPeriodo,iCorrelativo,cNroRequerimiento,cSolicitante,dFechaSolicitud,iCodUsuarioSolicitud,dFechaEnvio,iCodUsuarioEnvio,dFechaAprobacion,iCodUsuarioAprueba,bAprobado,dFechaDesaAprobacionCliente,iCodUsuarioDesaAprobacionCliente,bAprobadoCliente,cObs,iCodUsuarioEstado,dFechaEstado,dFechaConvocatoriaIni,dFechaConvocatoriaFin,dFechaRegistroIni,dFechaRegistroFin,bFechaConsultas,dFechaConsultasIni,dFechaConsultasFin,bFechaRespuestas,dFechaRespuestasIni,dFechaRespuestasFin,bFechaIntegracion,dFechaIntegracionIni,dFechaIntegracionFin,bFechaPresentaOferta,dFechaPresentaOfertaIni,dFechaPresentaOfertaFin,bFechaEvaluacion,dFechaEvaluacionIni,dFechaEvaluacionFin,dFechaAdjudicado,cAlcanceRequerimiento,cTerminosPago,bFechaTiempoServicio,dFechaTiempoServicioIni,dFechaTiempoServicioFin,cLogRequerimiento,cUrlDocumentos,cUrlCarpeta,bLiberado,iCodUsuarioLiberado,dFechaLiberado,cMotivoLiberado,cNotasLiberado,iCodUsuarioCreacion,dFechaCreacion,iCodUsuarioModificacion,dFechaModificacion ) VALUES(@iCodCliente,@iCodclienteCuenta,@iCodContrata,@iCodContratistaContrato,@iCodSubContrata,@iCodTipoMoneda,@iCodTipoRequerimiento,@iCodTipoEstadoRequerimiento,@cEstado,@iPeriodo,@iCorrelativo,@cNroRequerimiento,@cSolicitante,@dFechaSolicitud,@iCodUsuarioSolicitud,@dFechaEnvio,@iCodUsuarioEnvio,@dFechaAprobacion,@iCodUsuarioAprueba,@bAprobado,@dFechaDesaAprobacionCliente,@iCodUsuarioDesaAprobacionCliente,@bAprobadoCliente,@cObs,@iCodUsuarioEstado,@dFechaEstado,@dFechaConvocatoriaIni,@dFechaConvocatoriaFin,@dFechaRegistroIni,@dFechaRegistroFin,@bFechaConsultas,@dFechaConsultasIni,@dFechaConsultasFin,@bFechaRespuestas,@dFechaRespuestasIni,@dFechaRespuestasFin,@bFechaIntegracion,@dFechaIntegracionIni,@dFechaIntegracionFin,@bFechaPresentaOferta,@dFechaPresentaOfertaIni,@dFechaPresentaOfertaFin,@bFechaEvaluacion,@dFechaEvaluacionIni,@dFechaEvaluacionFin,@dFechaAdjudicado,@cAlcanceRequerimiento,@cTerminosPago,@bFechaTiempoServicio,@dFechaTiempoServicioIni,@dFechaTiempoServicioFin,@cLogRequerimiento,@cUrlDocumentos,@cUrlCarpeta,@bLiberado,@iCodUsuarioLiberado,@dFechaLiberado,@cMotivoLiberado,@cNotasLiberado,@iCodUsuarioCreacion,@dFechaCreacion,@iCodUsuarioModificacion,@dFechaModificacion); SELECT SCOPE_IDENTITY(); "
        cmdSQL.Parameters.Add("@iCodCliente", SqlDbType.Int).Value = Me.iCodCliente
        cmdSQL.Parameters.Add("@iCodclienteCuenta", SqlDbType.Int).Value = Me.iCodclienteCuenta
        cmdSQL.Parameters.Add("@iCodContrata", SqlDbType.Int).Value = Me.iCodContrata
        cmdSQL.Parameters.Add("@iCodContratistaContrato", SqlDbType.Int).Value = Me.iCodContratistaContrato
        cmdSQL.Parameters.Add("@iCodSubContrata", SqlDbType.Int).Value = Me.iCodSubContrata
        cmdSQL.Parameters.Add("@iCodTipoMoneda", SqlDbType.Int).Value = Me.iCodTipoMoneda
        cmdSQL.Parameters.Add("@iCodTipoRequerimiento", SqlDbType.Smallint).Value = Me.iCodTipoRequerimiento
        cmdSQL.Parameters.Add("@iCodTipoEstadoRequerimiento", SqlDbType.Smallint).Value = Me.iCodTipoEstadoRequerimiento
        cmdSQL.Parameters.Add("@cEstado", SqlDbType.Varchar, 30).Value = Me.cEstado
        cmdSQL.Parameters.Add("@iPeriodo", SqlDbType.Smallint).Value = Me.iPeriodo
        cmdSQL.Parameters.Add("@iCorrelativo", SqlDbType.Smallint).Value = Me.iCorrelativo
        cmdSQL.Parameters.Add("@cNroRequerimiento", SqlDbType.Varchar, 15).Value = Me.cNroRequerimiento
        cmdSQL.Parameters.Add("@cSolicitante", SqlDbType.Varchar, 200).Value = Me.cSolicitante
        cmdSQL.Parameters.Add("@dFechaSolicitud", SqlDbType.Datetime).Value = Me.dFechaSolicitud
        cmdSQL.Parameters.Add("@iCodUsuarioSolicitud", SqlDbType.Int).Value = Me.iCodUsuarioSolicitud
        cmdSQL.Parameters.Add("@dFechaEnvio", SqlDbType.Datetime).Value = Me.dFechaEnvio
        cmdSQL.Parameters.Add("@iCodUsuarioEnvio", SqlDbType.Int).Value = Me.iCodUsuarioEnvio
        cmdSQL.Parameters.Add("@dFechaAprobacion", SqlDbType.Datetime).Value = Me.dFechaAprobacion
        cmdSQL.Parameters.Add("@iCodUsuarioAprueba", SqlDbType.Int).Value = Me.iCodUsuarioAprueba
        cmdSQL.Parameters.Add("@bAprobado", SqlDbType.Bit).Value = Me.bAprobado
        cmdSQL.Parameters.Add("@dFechaDesaAprobacionCliente", SqlDbType.Datetime).Value = Me.dFechaDesaAprobacionCliente
        cmdSQL.Parameters.Add("@iCodUsuarioDesaAprobacionCliente", SqlDbType.Int).Value = Me.iCodUsuarioDesaAprobacionCliente
        cmdSQL.Parameters.Add("@bAprobadoCliente", SqlDbType.Bit).Value = Me.bAprobadoCliente
        cmdSQL.Parameters.Add("@cObs", SqlDbType.Varchar, -1).Value = Me.cObs
        cmdSQL.Parameters.Add("@iCodUsuarioEstado", SqlDbType.Int).Value = Me.iCodUsuarioEstado
        cmdSQL.Parameters.Add("@dFechaEstado", SqlDbType.Datetime).Value = Me.dFechaEstado
        cmdSQL.Parameters.Add("@dFechaConvocatoriaIni", SqlDbType.Date).Value = Me.dFechaConvocatoriaIni
        cmdSQL.Parameters.Add("@dFechaConvocatoriaFin", SqlDbType.Date).Value = Me.dFechaConvocatoriaFin
        cmdSQL.Parameters.Add("@dFechaRegistroIni", SqlDbType.Datetime).Value = Me.dFechaRegistroIni
        cmdSQL.Parameters.Add("@dFechaRegistroFin", SqlDbType.Datetime).Value = Me.dFechaRegistroFin
        cmdSQL.Parameters.Add("@bFechaConsultas", SqlDbType.Bit).Value = Me.bFechaConsultas
        cmdSQL.Parameters.Add("@dFechaConsultasIni", SqlDbType.Date).Value = Me.dFechaConsultasIni
        cmdSQL.Parameters.Add("@dFechaConsultasFin", SqlDbType.Date).Value = Me.dFechaConsultasFin
        cmdSQL.Parameters.Add("@bFechaRespuestas", SqlDbType.Bit).Value = Me.bFechaRespuestas
        cmdSQL.Parameters.Add("@dFechaRespuestasIni", SqlDbType.Date).Value = Me.dFechaRespuestasIni
        cmdSQL.Parameters.Add("@dFechaRespuestasFin", SqlDbType.Date).Value = Me.dFechaRespuestasFin
        cmdSQL.Parameters.Add("@bFechaIntegracion", SqlDbType.Bit).Value = Me.bFechaIntegracion
        cmdSQL.Parameters.Add("@dFechaIntegracionIni", SqlDbType.Date).Value = Me.dFechaIntegracionIni
        cmdSQL.Parameters.Add("@dFechaIntegracionFin", SqlDbType.Date).Value = Me.dFechaIntegracionFin
        cmdSQL.Parameters.Add("@bFechaPresentaOferta", SqlDbType.Bit).Value = Me.bFechaPresentaOferta
        cmdSQL.Parameters.Add("@dFechaPresentaOfertaIni", SqlDbType.Datetime).Value = Me.dFechaPresentaOfertaIni
        cmdSQL.Parameters.Add("@dFechaPresentaOfertaFin", SqlDbType.Datetime).Value = Me.dFechaPresentaOfertaFin
        cmdSQL.Parameters.Add("@bFechaEvaluacion", SqlDbType.Bit).Value = Me.bFechaEvaluacion
        cmdSQL.Parameters.Add("@dFechaEvaluacionIni", SqlDbType.Datetime).Value = Me.dFechaEvaluacionIni
        cmdSQL.Parameters.Add("@dFechaEvaluacionFin", SqlDbType.Datetime).Value = Me.dFechaEvaluacionFin
        cmdSQL.Parameters.Add("@dFechaAdjudicado", SqlDbType.Datetime).Value = Me.dFechaAdjudicado
        cmdSQL.Parameters.Add("@cAlcanceRequerimiento", SqlDbType.Varchar, -1).Value = Me.cAlcanceRequerimiento
        cmdSQL.Parameters.Add("@cTerminosPago", SqlDbType.Varchar, 250).Value = Me.cTerminosPago
        cmdSQL.Parameters.Add("@bFechaTiempoServicio", SqlDbType.Bit).Value = Me.bFechaTiempoServicio
        cmdSQL.Parameters.Add("@dFechaTiempoServicioIni", SqlDbType.Date).Value = Me.dFechaTiempoServicioIni
        cmdSQL.Parameters.Add("@dFechaTiempoServicioFin", SqlDbType.Date).Value = Me.dFechaTiempoServicioFin
        cmdSQL.Parameters.Add("@cLogRequerimiento", SqlDbType.Varchar, -1).Value = Me.cLogRequerimiento
        cmdSQL.Parameters.Add("@cUrlDocumentos", SqlDbType.Varchar, -1).Value = Me.cUrlDocumentos
        cmdSQL.Parameters.Add("@cUrlCarpeta", SqlDbType.Varchar, -1).Value = Me.cUrlCarpeta
        cmdSQL.Parameters.Add("@bLiberado", SqlDbType.Bit).Value = Me.bLiberado
        cmdSQL.Parameters.Add("@iCodUsuarioLiberado", SqlDbType.Int).Value = Me.iCodUsuarioLiberado
        cmdSQL.Parameters.Add("@dFechaLiberado", SqlDbType.Datetime).Value = Me.dFechaLiberado
        cmdSQL.Parameters.Add("@cMotivoLiberado", SqlDbType.Varchar, 50).Value = Me.cMotivoLiberado
        cmdSQL.Parameters.Add("@cNotasLiberado", SqlDbType.Varchar, -1).Value = Me.cNotasLiberado
        cmdSQL.Parameters.Add("@iCodUsuarioCreacion", SqlDbType.Int).Value = Me.iCodUsuarioCreacion
        cmdSQL.Parameters.Add("@dFechaCreacion", SqlDbType.Datetime).Value = Me.dFechaCreacion
        cmdSQL.Parameters.Add("@iCodUsuarioModificacion", SqlDbType.Int).Value = Me.iCodUsuarioModificacion
        cmdSQL.Parameters.Add("@dFechaModificacion", SqlDbType.Datetime).Value = Me.dFechaModificacion

        Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
        If pCodInsert > 0 Then
            Me.iCodRequerimiento = pCodInsert
        Else
            Me.iCodRequerimiento = 0
        End If
    End Sub
    Public Sub InsertarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "INSERT into prov.Requerimiento (iCodCliente,iCodclienteCuenta,iCodContrata,iCodContratistaContrato,iCodSubContrata,iCodTipoMoneda,iCodTipoRequerimiento,iCodTipoEstadoRequerimiento,cEstado,iPeriodo,iCorrelativo,cNroRequerimiento,cSolicitante,dFechaSolicitud,iCodUsuarioSolicitud,dFechaEnvio,iCodUsuarioEnvio,dFechaAprobacion,iCodUsuarioAprueba,bAprobado,dFechaDesaAprobacionCliente,iCodUsuarioDesaAprobacionCliente,bAprobadoCliente,cObs,iCodUsuarioEstado,dFechaEstado,dFechaConvocatoriaIni,dFechaConvocatoriaFin,dFechaRegistroIni,dFechaRegistroFin,bFechaConsultas,dFechaConsultasIni,dFechaConsultasFin,bFechaRespuestas,dFechaRespuestasIni,dFechaRespuestasFin,bFechaIntegracion,dFechaIntegracionIni,dFechaIntegracionFin,bFechaPresentaOferta,dFechaPresentaOfertaIni,dFechaPresentaOfertaFin,bFechaEvaluacion,dFechaEvaluacionIni,dFechaEvaluacionFin,dFechaAdjudicado,cAlcanceRequerimiento,cTerminosPago,bFechaTiempoServicio,dFechaTiempoServicioIni,dFechaTiempoServicioFin,cLogRequerimiento,cUrlDocumentos,cUrlCarpeta,bLiberado,iCodUsuarioLiberado,dFechaLiberado,cMotivoLiberado,cNotasLiberado,iCodUsuarioCreacion,dFechaCreacion,iCodUsuarioModificacion,dFechaModificacion ) VALUES(@iCodCliente,@iCodclienteCuenta,@iCodContrata,@iCodContratistaContrato,@iCodSubContrata,@iCodTipoMoneda,@iCodTipoRequerimiento,@iCodTipoEstadoRequerimiento,@cEstado,@iPeriodo,@iCorrelativo,@cNroRequerimiento,@cSolicitante,@dFechaSolicitud,@iCodUsuarioSolicitud,@dFechaEnvio,@iCodUsuarioEnvio,@dFechaAprobacion,@iCodUsuarioAprueba,@bAprobado,@dFechaDesaAprobacionCliente,@iCodUsuarioDesaAprobacionCliente,@bAprobadoCliente,@cObs,@iCodUsuarioEstado,@dFechaEstado,@dFechaConvocatoriaIni,@dFechaConvocatoriaFin,@dFechaRegistroIni,@dFechaRegistroFin,@bFechaConsultas,@dFechaConsultasIni,@dFechaConsultasFin,@bFechaRespuestas,@dFechaRespuestasIni,@dFechaRespuestasFin,@bFechaIntegracion,@dFechaIntegracionIni,@dFechaIntegracionFin,@bFechaPresentaOferta,@dFechaPresentaOfertaIni,@dFechaPresentaOfertaFin,@bFechaEvaluacion,@dFechaEvaluacionIni,@dFechaEvaluacionFin,@dFechaAdjudicado,@cAlcanceRequerimiento,@cTerminosPago,@bFechaTiempoServicio,@dFechaTiempoServicioIni,@dFechaTiempoServicioFin,@cLogRequerimiento,@cUrlDocumentos,@cUrlCarpeta,@bLiberado,@iCodUsuarioLiberado,@dFechaLiberado,@cMotivoLiberado,@cNotasLiberado,@iCodUsuarioCreacion,@dFechaCreacion,@iCodUsuarioModificacion,@dFechaModificacion); SELECT SCOPE_IDENTITY(); "
        cmdSQL.Parameters.Add("@iCodCliente", SqlDbType.Int).Value = Me.iCodCliente
        cmdSQL.Parameters.Add("@iCodclienteCuenta", SqlDbType.Int).Value = Me.iCodclienteCuenta
        cmdSQL.Parameters.Add("@iCodContrata", SqlDbType.Int).Value = Me.iCodContrata
        cmdSQL.Parameters.Add("@iCodContratistaContrato", SqlDbType.Int).Value = Me.iCodContratistaContrato
        cmdSQL.Parameters.Add("@iCodSubContrata", SqlDbType.Int).Value = Me.iCodSubContrata
        cmdSQL.Parameters.Add("@iCodTipoMoneda", SqlDbType.Int).Value = Me.iCodTipoMoneda
        cmdSQL.Parameters.Add("@iCodTipoRequerimiento", SqlDbType.Smallint).Value = Me.iCodTipoRequerimiento
        cmdSQL.Parameters.Add("@iCodTipoEstadoRequerimiento", SqlDbType.Smallint).Value = Me.iCodTipoEstadoRequerimiento
        cmdSQL.Parameters.Add("@cEstado", SqlDbType.Varchar, 30).Value = Me.cEstado
        cmdSQL.Parameters.Add("@iPeriodo", SqlDbType.Smallint).Value = Me.iPeriodo
        cmdSQL.Parameters.Add("@iCorrelativo", SqlDbType.Smallint).Value = Me.iCorrelativo
        cmdSQL.Parameters.Add("@cNroRequerimiento", SqlDbType.Varchar, 15).Value = Me.cNroRequerimiento
        cmdSQL.Parameters.Add("@cSolicitante", SqlDbType.Varchar, 200).Value = Me.cSolicitante
        cmdSQL.Parameters.Add("@dFechaSolicitud", SqlDbType.Datetime).Value = Me.dFechaSolicitud
        cmdSQL.Parameters.Add("@iCodUsuarioSolicitud", SqlDbType.Int).Value = Me.iCodUsuarioSolicitud
        cmdSQL.Parameters.Add("@dFechaEnvio", SqlDbType.Datetime).Value = Me.dFechaEnvio
        cmdSQL.Parameters.Add("@iCodUsuarioEnvio", SqlDbType.Int).Value = Me.iCodUsuarioEnvio
        cmdSQL.Parameters.Add("@dFechaAprobacion", SqlDbType.Datetime).Value = Me.dFechaAprobacion
        cmdSQL.Parameters.Add("@iCodUsuarioAprueba", SqlDbType.Int).Value = Me.iCodUsuarioAprueba
        cmdSQL.Parameters.Add("@bAprobado", SqlDbType.Bit).Value = Me.bAprobado
        cmdSQL.Parameters.Add("@dFechaDesaAprobacionCliente", SqlDbType.Datetime).Value = Me.dFechaDesaAprobacionCliente
        cmdSQL.Parameters.Add("@iCodUsuarioDesaAprobacionCliente", SqlDbType.Int).Value = Me.iCodUsuarioDesaAprobacionCliente
        cmdSQL.Parameters.Add("@bAprobadoCliente", SqlDbType.Bit).Value = Me.bAprobadoCliente
        cmdSQL.Parameters.Add("@cObs", SqlDbType.Varchar, -1).Value = Me.cObs
        cmdSQL.Parameters.Add("@iCodUsuarioEstado", SqlDbType.Int).Value = Me.iCodUsuarioEstado
        cmdSQL.Parameters.Add("@dFechaEstado", SqlDbType.Datetime).Value = Me.dFechaEstado
        cmdSQL.Parameters.Add("@dFechaConvocatoriaIni", SqlDbType.Date).Value = Me.dFechaConvocatoriaIni
        cmdSQL.Parameters.Add("@dFechaConvocatoriaFin", SqlDbType.Date).Value = Me.dFechaConvocatoriaFin
        cmdSQL.Parameters.Add("@dFechaRegistroIni", SqlDbType.Datetime).Value = Me.dFechaRegistroIni
        cmdSQL.Parameters.Add("@dFechaRegistroFin", SqlDbType.Datetime).Value = Me.dFechaRegistroFin
        cmdSQL.Parameters.Add("@bFechaConsultas", SqlDbType.Bit).Value = Me.bFechaConsultas
        cmdSQL.Parameters.Add("@dFechaConsultasIni", SqlDbType.Date).Value = Me.dFechaConsultasIni
        cmdSQL.Parameters.Add("@dFechaConsultasFin", SqlDbType.Date).Value = Me.dFechaConsultasFin
        cmdSQL.Parameters.Add("@bFechaRespuestas", SqlDbType.Bit).Value = Me.bFechaRespuestas
        cmdSQL.Parameters.Add("@dFechaRespuestasIni", SqlDbType.Date).Value = Me.dFechaRespuestasIni
        cmdSQL.Parameters.Add("@dFechaRespuestasFin", SqlDbType.Date).Value = Me.dFechaRespuestasFin
        cmdSQL.Parameters.Add("@bFechaIntegracion", SqlDbType.Bit).Value = Me.bFechaIntegracion
        cmdSQL.Parameters.Add("@dFechaIntegracionIni", SqlDbType.Date).Value = Me.dFechaIntegracionIni
        cmdSQL.Parameters.Add("@dFechaIntegracionFin", SqlDbType.Date).Value = Me.dFechaIntegracionFin
        cmdSQL.Parameters.Add("@bFechaPresentaOferta", SqlDbType.Bit).Value = Me.bFechaPresentaOferta
        cmdSQL.Parameters.Add("@dFechaPresentaOfertaIni", SqlDbType.Datetime).Value = Me.dFechaPresentaOfertaIni
        cmdSQL.Parameters.Add("@dFechaPresentaOfertaFin", SqlDbType.Datetime).Value = Me.dFechaPresentaOfertaFin
        cmdSQL.Parameters.Add("@bFechaEvaluacion", SqlDbType.Bit).Value = Me.bFechaEvaluacion
        cmdSQL.Parameters.Add("@dFechaEvaluacionIni", SqlDbType.Datetime).Value = Me.dFechaEvaluacionIni
        cmdSQL.Parameters.Add("@dFechaEvaluacionFin", SqlDbType.Datetime).Value = Me.dFechaEvaluacionFin
        cmdSQL.Parameters.Add("@dFechaAdjudicado", SqlDbType.Datetime).Value = Me.dFechaAdjudicado
        cmdSQL.Parameters.Add("@cAlcanceRequerimiento", SqlDbType.Varchar, -1).Value = Me.cAlcanceRequerimiento
        cmdSQL.Parameters.Add("@cTerminosPago", SqlDbType.Varchar, 250).Value = Me.cTerminosPago
        cmdSQL.Parameters.Add("@bFechaTiempoServicio", SqlDbType.Bit).Value = Me.bFechaTiempoServicio
        cmdSQL.Parameters.Add("@dFechaTiempoServicioIni", SqlDbType.Date).Value = Me.dFechaTiempoServicioIni
        cmdSQL.Parameters.Add("@dFechaTiempoServicioFin", SqlDbType.Date).Value = Me.dFechaTiempoServicioFin
        cmdSQL.Parameters.Add("@cLogRequerimiento", SqlDbType.Varchar, -1).Value = Me.cLogRequerimiento
        cmdSQL.Parameters.Add("@cUrlDocumentos", SqlDbType.Varchar, -1).Value = Me.cUrlDocumentos
        cmdSQL.Parameters.Add("@cUrlCarpeta", SqlDbType.Varchar, -1).Value = Me.cUrlCarpeta
        cmdSQL.Parameters.Add("@bLiberado", SqlDbType.Bit).Value = Me.bLiberado
        cmdSQL.Parameters.Add("@iCodUsuarioLiberado", SqlDbType.Int).Value = Me.iCodUsuarioLiberado
        cmdSQL.Parameters.Add("@dFechaLiberado", SqlDbType.Datetime).Value = Me.dFechaLiberado
        cmdSQL.Parameters.Add("@cMotivoLiberado", SqlDbType.Varchar, 50).Value = Me.cMotivoLiberado
        cmdSQL.Parameters.Add("@cNotasLiberado", SqlDbType.Varchar, -1).Value = Me.cNotasLiberado
        cmdSQL.Parameters.Add("@iCodUsuarioCreacion", SqlDbType.Int).Value = Me.iCodUsuarioCreacion
        cmdSQL.Parameters.Add("@dFechaCreacion", SqlDbType.Datetime).Value = Me.dFechaCreacion
        cmdSQL.Parameters.Add("@iCodUsuarioModificacion", SqlDbType.Int).Value = Me.iCodUsuarioModificacion
        cmdSQL.Parameters.Add("@dFechaModificacion", SqlDbType.Datetime).Value = Me.dFechaModificacion

        Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
        If pCodInsert > 0 Then
            Me.iCodRequerimiento = pCodInsert
        Else
            Me.iCodRequerimiento = 0
        End If
    End Sub
    Public Sub Modificar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "UPDATE  prov.Requerimiento SET iCodCliente=@iCodCliente,iCodclienteCuenta=@iCodclienteCuenta,iCodContrata=@iCodContrata,iCodContratistaContrato=@iCodContratistaContrato,iCodSubContrata=@iCodSubContrata,iCodTipoMoneda=@iCodTipoMoneda,iCodTipoRequerimiento=@iCodTipoRequerimiento,iCodTipoEstadoRequerimiento=@iCodTipoEstadoRequerimiento,cEstado=@cEstado,iPeriodo=@iPeriodo,iCorrelativo=@iCorrelativo,cNroRequerimiento=@cNroRequerimiento,cSolicitante=@cSolicitante,dFechaSolicitud=@dFechaSolicitud,iCodUsuarioSolicitud=@iCodUsuarioSolicitud,dFechaEnvio=@dFechaEnvio,iCodUsuarioEnvio=@iCodUsuarioEnvio,dFechaAprobacion=@dFechaAprobacion,iCodUsuarioAprueba=@iCodUsuarioAprueba,bAprobado=@bAprobado,dFechaDesaAprobacionCliente=@dFechaDesaAprobacionCliente,iCodUsuarioDesaAprobacionCliente=@iCodUsuarioDesaAprobacionCliente,bAprobadoCliente=@bAprobadoCliente,cObs=@cObs,iCodUsuarioEstado=@iCodUsuarioEstado,dFechaEstado=@dFechaEstado,dFechaConvocatoriaIni=@dFechaConvocatoriaIni,dFechaConvocatoriaFin=@dFechaConvocatoriaFin,dFechaRegistroIni=@dFechaRegistroIni,dFechaRegistroFin=@dFechaRegistroFin,bFechaConsultas=@bFechaConsultas,dFechaConsultasIni=@dFechaConsultasIni,dFechaConsultasFin=@dFechaConsultasFin,bFechaRespuestas=@bFechaRespuestas,dFechaRespuestasIni=@dFechaRespuestasIni,dFechaRespuestasFin=@dFechaRespuestasFin,bFechaIntegracion=@bFechaIntegracion,dFechaIntegracionIni=@dFechaIntegracionIni,dFechaIntegracionFin=@dFechaIntegracionFin,bFechaPresentaOferta=@bFechaPresentaOferta,dFechaPresentaOfertaIni=@dFechaPresentaOfertaIni,dFechaPresentaOfertaFin=@dFechaPresentaOfertaFin,bFechaEvaluacion=@bFechaEvaluacion,dFechaEvaluacionIni=@dFechaEvaluacionIni,dFechaEvaluacionFin=@dFechaEvaluacionFin,dFechaAdjudicado=@dFechaAdjudicado,cAlcanceRequerimiento=@cAlcanceRequerimiento,cTerminosPago=@cTerminosPago,bFechaTiempoServicio=@bFechaTiempoServicio,dFechaTiempoServicioIni=@dFechaTiempoServicioIni,dFechaTiempoServicioFin=@dFechaTiempoServicioFin,cLogRequerimiento=@cLogRequerimiento,cUrlDocumentos=@cUrlDocumentos,cUrlCarpeta=@cUrlCarpeta,bLiberado=@bLiberado,iCodUsuarioLiberado=@iCodUsuarioLiberado,dFechaLiberado=@dFechaLiberado,cMotivoLiberado=@cMotivoLiberado,cNotasLiberado=@cNotasLiberado,iCodUsuarioCreacion=@iCodUsuarioCreacion,dFechaCreacion=@dFechaCreacion,iCodUsuarioModificacion=@iCodUsuarioModificacion,dFechaModificacion=@dFechaModificacion WHERE iCodRequerimiento=@iCodRequerimiento"
        cmdSQL.Parameters.Add("@iCodRequerimiento", SqlDbType.Int).Value = Me.iCodRequerimiento
        cmdSQL.Parameters.Add("@iCodCliente", SqlDbType.Int).Value = Me.iCodCliente
        cmdSQL.Parameters.Add("@iCodclienteCuenta", SqlDbType.Int).Value = Me.iCodclienteCuenta
        cmdSQL.Parameters.Add("@iCodContrata", SqlDbType.Int).Value = Me.iCodContrata
        cmdSQL.Parameters.Add("@iCodContratistaContrato", SqlDbType.Int).Value = Me.iCodContratistaContrato
        cmdSQL.Parameters.Add("@iCodSubContrata", SqlDbType.Int).Value = Me.iCodSubContrata
        cmdSQL.Parameters.Add("@iCodTipoMoneda", SqlDbType.Int).Value = Me.iCodTipoMoneda
        cmdSQL.Parameters.Add("@iCodTipoRequerimiento", SqlDbType.Smallint).Value = Me.iCodTipoRequerimiento
        cmdSQL.Parameters.Add("@iCodTipoEstadoRequerimiento", SqlDbType.Smallint).Value = Me.iCodTipoEstadoRequerimiento
        cmdSQL.Parameters.Add("@cEstado", SqlDbType.Varchar, 30).Value = Me.cEstado
        cmdSQL.Parameters.Add("@iPeriodo", SqlDbType.Smallint).Value = Me.iPeriodo
        cmdSQL.Parameters.Add("@iCorrelativo", SqlDbType.Smallint).Value = Me.iCorrelativo
        cmdSQL.Parameters.Add("@cNroRequerimiento", SqlDbType.Varchar, 15).Value = Me.cNroRequerimiento
        cmdSQL.Parameters.Add("@cSolicitante", SqlDbType.Varchar, 200).Value = Me.cSolicitante
        cmdSQL.Parameters.Add("@dFechaSolicitud", SqlDbType.Datetime).Value = Me.dFechaSolicitud
        cmdSQL.Parameters.Add("@iCodUsuarioSolicitud", SqlDbType.Int).Value = Me.iCodUsuarioSolicitud
        cmdSQL.Parameters.Add("@dFechaEnvio", SqlDbType.Datetime).Value = Me.dFechaEnvio
        cmdSQL.Parameters.Add("@iCodUsuarioEnvio", SqlDbType.Int).Value = Me.iCodUsuarioEnvio
        cmdSQL.Parameters.Add("@dFechaAprobacion", SqlDbType.Datetime).Value = Me.dFechaAprobacion
        cmdSQL.Parameters.Add("@iCodUsuarioAprueba", SqlDbType.Int).Value = Me.iCodUsuarioAprueba
        cmdSQL.Parameters.Add("@bAprobado", SqlDbType.Bit).Value = Me.bAprobado
        cmdSQL.Parameters.Add("@dFechaDesaAprobacionCliente", SqlDbType.Datetime).Value = Me.dFechaDesaAprobacionCliente
        cmdSQL.Parameters.Add("@iCodUsuarioDesaAprobacionCliente", SqlDbType.Int).Value = Me.iCodUsuarioDesaAprobacionCliente
        cmdSQL.Parameters.Add("@bAprobadoCliente", SqlDbType.Bit).Value = Me.bAprobadoCliente
        cmdSQL.Parameters.Add("@cObs", SqlDbType.Varchar, -1).Value = Me.cObs
        cmdSQL.Parameters.Add("@iCodUsuarioEstado", SqlDbType.Int).Value = Me.iCodUsuarioEstado
        cmdSQL.Parameters.Add("@dFechaEstado", SqlDbType.Datetime).Value = Me.dFechaEstado
        cmdSQL.Parameters.Add("@dFechaConvocatoriaIni", SqlDbType.Date).Value = Me.dFechaConvocatoriaIni
        cmdSQL.Parameters.Add("@dFechaConvocatoriaFin", SqlDbType.Date).Value = Me.dFechaConvocatoriaFin
        cmdSQL.Parameters.Add("@dFechaRegistroIni", SqlDbType.Datetime).Value = Me.dFechaRegistroIni
        cmdSQL.Parameters.Add("@dFechaRegistroFin", SqlDbType.Datetime).Value = Me.dFechaRegistroFin
        cmdSQL.Parameters.Add("@bFechaConsultas", SqlDbType.Bit).Value = Me.bFechaConsultas
        cmdSQL.Parameters.Add("@dFechaConsultasIni", SqlDbType.Date).Value = Me.dFechaConsultasIni
        cmdSQL.Parameters.Add("@dFechaConsultasFin", SqlDbType.Date).Value = Me.dFechaConsultasFin
        cmdSQL.Parameters.Add("@bFechaRespuestas", SqlDbType.Bit).Value = Me.bFechaRespuestas
        cmdSQL.Parameters.Add("@dFechaRespuestasIni", SqlDbType.Date).Value = Me.dFechaRespuestasIni
        cmdSQL.Parameters.Add("@dFechaRespuestasFin", SqlDbType.Date).Value = Me.dFechaRespuestasFin
        cmdSQL.Parameters.Add("@bFechaIntegracion", SqlDbType.Bit).Value = Me.bFechaIntegracion
        cmdSQL.Parameters.Add("@dFechaIntegracionIni", SqlDbType.Date).Value = Me.dFechaIntegracionIni
        cmdSQL.Parameters.Add("@dFechaIntegracionFin", SqlDbType.Date).Value = Me.dFechaIntegracionFin
        cmdSQL.Parameters.Add("@bFechaPresentaOferta", SqlDbType.Bit).Value = Me.bFechaPresentaOferta
        cmdSQL.Parameters.Add("@dFechaPresentaOfertaIni", SqlDbType.Datetime).Value = Me.dFechaPresentaOfertaIni
        cmdSQL.Parameters.Add("@dFechaPresentaOfertaFin", SqlDbType.Datetime).Value = Me.dFechaPresentaOfertaFin
        cmdSQL.Parameters.Add("@bFechaEvaluacion", SqlDbType.Bit).Value = Me.bFechaEvaluacion
        cmdSQL.Parameters.Add("@dFechaEvaluacionIni", SqlDbType.Datetime).Value = Me.dFechaEvaluacionIni
        cmdSQL.Parameters.Add("@dFechaEvaluacionFin", SqlDbType.Datetime).Value = Me.dFechaEvaluacionFin
        cmdSQL.Parameters.Add("@dFechaAdjudicado", SqlDbType.Datetime).Value = Me.dFechaAdjudicado
        cmdSQL.Parameters.Add("@cAlcanceRequerimiento", SqlDbType.Varchar, -1).Value = Me.cAlcanceRequerimiento
        cmdSQL.Parameters.Add("@cTerminosPago", SqlDbType.Varchar, 250).Value = Me.cTerminosPago
        cmdSQL.Parameters.Add("@bFechaTiempoServicio", SqlDbType.Bit).Value = Me.bFechaTiempoServicio
        cmdSQL.Parameters.Add("@dFechaTiempoServicioIni", SqlDbType.Date).Value = Me.dFechaTiempoServicioIni
        cmdSQL.Parameters.Add("@dFechaTiempoServicioFin", SqlDbType.Date).Value = Me.dFechaTiempoServicioFin
        cmdSQL.Parameters.Add("@cLogRequerimiento", SqlDbType.Varchar, -1).Value = Me.cLogRequerimiento
        cmdSQL.Parameters.Add("@cUrlDocumentos", SqlDbType.Varchar, -1).Value = Me.cUrlDocumentos
        cmdSQL.Parameters.Add("@cUrlCarpeta", SqlDbType.Varchar, -1).Value = Me.cUrlCarpeta
        cmdSQL.Parameters.Add("@bLiberado", SqlDbType.Bit).Value = Me.bLiberado
        cmdSQL.Parameters.Add("@iCodUsuarioLiberado", SqlDbType.Int).Value = Me.iCodUsuarioLiberado
        cmdSQL.Parameters.Add("@dFechaLiberado", SqlDbType.Datetime).Value = Me.dFechaLiberado
        cmdSQL.Parameters.Add("@cMotivoLiberado", SqlDbType.Varchar, 50).Value = Me.cMotivoLiberado
        cmdSQL.Parameters.Add("@cNotasLiberado", SqlDbType.Varchar, -1).Value = Me.cNotasLiberado
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
        cmdSQL.CommandText = "UPDATE  prov.Requerimiento SET iCodCliente=@iCodCliente,iCodclienteCuenta=@iCodclienteCuenta,iCodContrata=@iCodContrata,iCodContratistaContrato=@iCodContratistaContrato,iCodSubContrata=@iCodSubContrata,iCodTipoMoneda=@iCodTipoMoneda,iCodTipoRequerimiento=@iCodTipoRequerimiento,iCodTipoEstadoRequerimiento=@iCodTipoEstadoRequerimiento,cEstado=@cEstado,iPeriodo=@iPeriodo,iCorrelativo=@iCorrelativo,cNroRequerimiento=@cNroRequerimiento,cSolicitante=@cSolicitante,dFechaSolicitud=@dFechaSolicitud,iCodUsuarioSolicitud=@iCodUsuarioSolicitud,dFechaEnvio=@dFechaEnvio,iCodUsuarioEnvio=@iCodUsuarioEnvio,dFechaAprobacion=@dFechaAprobacion,iCodUsuarioAprueba=@iCodUsuarioAprueba,bAprobado=@bAprobado,dFechaDesaAprobacionCliente=@dFechaDesaAprobacionCliente,iCodUsuarioDesaAprobacionCliente=@iCodUsuarioDesaAprobacionCliente,bAprobadoCliente=@bAprobadoCliente,cObs=@cObs,iCodUsuarioEstado=@iCodUsuarioEstado,dFechaEstado=@dFechaEstado,dFechaConvocatoriaIni=@dFechaConvocatoriaIni,dFechaConvocatoriaFin=@dFechaConvocatoriaFin,dFechaRegistroIni=@dFechaRegistroIni,dFechaRegistroFin=@dFechaRegistroFin,bFechaConsultas=@bFechaConsultas,dFechaConsultasIni=@dFechaConsultasIni,dFechaConsultasFin=@dFechaConsultasFin,bFechaRespuestas=@bFechaRespuestas,dFechaRespuestasIni=@dFechaRespuestasIni,dFechaRespuestasFin=@dFechaRespuestasFin,bFechaIntegracion=@bFechaIntegracion,dFechaIntegracionIni=@dFechaIntegracionIni,dFechaIntegracionFin=@dFechaIntegracionFin,bFechaPresentaOferta=@bFechaPresentaOferta,dFechaPresentaOfertaIni=@dFechaPresentaOfertaIni,dFechaPresentaOfertaFin=@dFechaPresentaOfertaFin,bFechaEvaluacion=@bFechaEvaluacion,dFechaEvaluacionIni=@dFechaEvaluacionIni,dFechaEvaluacionFin=@dFechaEvaluacionFin,dFechaAdjudicado=@dFechaAdjudicado,cAlcanceRequerimiento=@cAlcanceRequerimiento,cTerminosPago=@cTerminosPago,bFechaTiempoServicio=@bFechaTiempoServicio,dFechaTiempoServicioIni=@dFechaTiempoServicioIni,dFechaTiempoServicioFin=@dFechaTiempoServicioFin,cLogRequerimiento=@cLogRequerimiento,cUrlDocumentos=@cUrlDocumentos,cUrlCarpeta=@cUrlCarpeta,bLiberado=@bLiberado,iCodUsuarioLiberado=@iCodUsuarioLiberado,dFechaLiberado=@dFechaLiberado,cMotivoLiberado=@cMotivoLiberado,cNotasLiberado=@cNotasLiberado,iCodUsuarioCreacion=@iCodUsuarioCreacion,dFechaCreacion=@dFechaCreacion,iCodUsuarioModificacion=@iCodUsuarioModificacion,dFechaModificacion=@dFechaModificacion WHERE iCodRequerimiento=@iCodRequerimiento"
        cmdSQL.Parameters.Add("@iCodRequerimiento", SqlDbType.Int).Value = Me.iCodRequerimiento
        cmdSQL.Parameters.Add("@iCodCliente", SqlDbType.Int).Value = Me.iCodCliente
        cmdSQL.Parameters.Add("@iCodclienteCuenta", SqlDbType.Int).Value = Me.iCodclienteCuenta
        cmdSQL.Parameters.Add("@iCodContrata", SqlDbType.Int).Value = Me.iCodContrata
        cmdSQL.Parameters.Add("@iCodContratistaContrato", SqlDbType.Int).Value = Me.iCodContratistaContrato
        cmdSQL.Parameters.Add("@iCodSubContrata", SqlDbType.Int).Value = Me.iCodSubContrata
        cmdSQL.Parameters.Add("@iCodTipoMoneda", SqlDbType.Int).Value = Me.iCodTipoMoneda
        cmdSQL.Parameters.Add("@iCodTipoRequerimiento", SqlDbType.Smallint).Value = Me.iCodTipoRequerimiento
        cmdSQL.Parameters.Add("@iCodTipoEstadoRequerimiento", SqlDbType.Smallint).Value = Me.iCodTipoEstadoRequerimiento
        cmdSQL.Parameters.Add("@cEstado", SqlDbType.Varchar, 30).Value = Me.cEstado
        cmdSQL.Parameters.Add("@iPeriodo", SqlDbType.Smallint).Value = Me.iPeriodo
        cmdSQL.Parameters.Add("@iCorrelativo", SqlDbType.Smallint).Value = Me.iCorrelativo
        cmdSQL.Parameters.Add("@cNroRequerimiento", SqlDbType.Varchar, 15).Value = Me.cNroRequerimiento
        cmdSQL.Parameters.Add("@cSolicitante", SqlDbType.Varchar, 200).Value = Me.cSolicitante
        cmdSQL.Parameters.Add("@dFechaSolicitud", SqlDbType.Datetime).Value = Me.dFechaSolicitud
        cmdSQL.Parameters.Add("@iCodUsuarioSolicitud", SqlDbType.Int).Value = Me.iCodUsuarioSolicitud
        cmdSQL.Parameters.Add("@dFechaEnvio", SqlDbType.Datetime).Value = Me.dFechaEnvio
        cmdSQL.Parameters.Add("@iCodUsuarioEnvio", SqlDbType.Int).Value = Me.iCodUsuarioEnvio
        cmdSQL.Parameters.Add("@dFechaAprobacion", SqlDbType.Datetime).Value = Me.dFechaAprobacion
        cmdSQL.Parameters.Add("@iCodUsuarioAprueba", SqlDbType.Int).Value = Me.iCodUsuarioAprueba
        cmdSQL.Parameters.Add("@bAprobado", SqlDbType.Bit).Value = Me.bAprobado
        cmdSQL.Parameters.Add("@dFechaDesaAprobacionCliente", SqlDbType.Datetime).Value = Me.dFechaDesaAprobacionCliente
        cmdSQL.Parameters.Add("@iCodUsuarioDesaAprobacionCliente", SqlDbType.Int).Value = Me.iCodUsuarioDesaAprobacionCliente
        cmdSQL.Parameters.Add("@bAprobadoCliente", SqlDbType.Bit).Value = Me.bAprobadoCliente
        cmdSQL.Parameters.Add("@cObs", SqlDbType.Varchar, -1).Value = Me.cObs
        cmdSQL.Parameters.Add("@iCodUsuarioEstado", SqlDbType.Int).Value = Me.iCodUsuarioEstado
        cmdSQL.Parameters.Add("@dFechaEstado", SqlDbType.Datetime).Value = Me.dFechaEstado
        cmdSQL.Parameters.Add("@dFechaConvocatoriaIni", SqlDbType.Date).Value = Me.dFechaConvocatoriaIni
        cmdSQL.Parameters.Add("@dFechaConvocatoriaFin", SqlDbType.Date).Value = Me.dFechaConvocatoriaFin
        cmdSQL.Parameters.Add("@dFechaRegistroIni", SqlDbType.Datetime).Value = Me.dFechaRegistroIni
        cmdSQL.Parameters.Add("@dFechaRegistroFin", SqlDbType.Datetime).Value = Me.dFechaRegistroFin
        cmdSQL.Parameters.Add("@bFechaConsultas", SqlDbType.Bit).Value = Me.bFechaConsultas
        cmdSQL.Parameters.Add("@dFechaConsultasIni", SqlDbType.Date).Value = Me.dFechaConsultasIni
        cmdSQL.Parameters.Add("@dFechaConsultasFin", SqlDbType.Date).Value = Me.dFechaConsultasFin
        cmdSQL.Parameters.Add("@bFechaRespuestas", SqlDbType.Bit).Value = Me.bFechaRespuestas
        cmdSQL.Parameters.Add("@dFechaRespuestasIni", SqlDbType.Date).Value = Me.dFechaRespuestasIni
        cmdSQL.Parameters.Add("@dFechaRespuestasFin", SqlDbType.Date).Value = Me.dFechaRespuestasFin
        cmdSQL.Parameters.Add("@bFechaIntegracion", SqlDbType.Bit).Value = Me.bFechaIntegracion
        cmdSQL.Parameters.Add("@dFechaIntegracionIni", SqlDbType.Date).Value = Me.dFechaIntegracionIni
        cmdSQL.Parameters.Add("@dFechaIntegracionFin", SqlDbType.Date).Value = Me.dFechaIntegracionFin
        cmdSQL.Parameters.Add("@bFechaPresentaOferta", SqlDbType.Bit).Value = Me.bFechaPresentaOferta
        cmdSQL.Parameters.Add("@dFechaPresentaOfertaIni", SqlDbType.Datetime).Value = Me.dFechaPresentaOfertaIni
        cmdSQL.Parameters.Add("@dFechaPresentaOfertaFin", SqlDbType.Datetime).Value = Me.dFechaPresentaOfertaFin
        cmdSQL.Parameters.Add("@bFechaEvaluacion", SqlDbType.Bit).Value = Me.bFechaEvaluacion
        cmdSQL.Parameters.Add("@dFechaEvaluacionIni", SqlDbType.Datetime).Value = Me.dFechaEvaluacionIni
        cmdSQL.Parameters.Add("@dFechaEvaluacionFin", SqlDbType.Datetime).Value = Me.dFechaEvaluacionFin
        cmdSQL.Parameters.Add("@dFechaAdjudicado", SqlDbType.Datetime).Value = Me.dFechaAdjudicado
        cmdSQL.Parameters.Add("@cAlcanceRequerimiento", SqlDbType.Varchar, -1).Value = Me.cAlcanceRequerimiento
        cmdSQL.Parameters.Add("@cTerminosPago", SqlDbType.Varchar, 250).Value = Me.cTerminosPago
        cmdSQL.Parameters.Add("@bFechaTiempoServicio", SqlDbType.Bit).Value = Me.bFechaTiempoServicio
        cmdSQL.Parameters.Add("@dFechaTiempoServicioIni", SqlDbType.Date).Value = Me.dFechaTiempoServicioIni
        cmdSQL.Parameters.Add("@dFechaTiempoServicioFin", SqlDbType.Date).Value = Me.dFechaTiempoServicioFin
        cmdSQL.Parameters.Add("@cLogRequerimiento", SqlDbType.Varchar, -1).Value = Me.cLogRequerimiento
        cmdSQL.Parameters.Add("@cUrlDocumentos", SqlDbType.Varchar, -1).Value = Me.cUrlDocumentos
        cmdSQL.Parameters.Add("@cUrlCarpeta", SqlDbType.Varchar, -1).Value = Me.cUrlCarpeta
        cmdSQL.Parameters.Add("@bLiberado", SqlDbType.Bit).Value = Me.bLiberado
        cmdSQL.Parameters.Add("@iCodUsuarioLiberado", SqlDbType.Int).Value = Me.iCodUsuarioLiberado
        cmdSQL.Parameters.Add("@dFechaLiberado", SqlDbType.Datetime).Value = Me.dFechaLiberado
        cmdSQL.Parameters.Add("@cMotivoLiberado", SqlDbType.Varchar, 50).Value = Me.cMotivoLiberado
        cmdSQL.Parameters.Add("@cNotasLiberado", SqlDbType.Varchar, -1).Value = Me.cNotasLiberado
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
        cmdSQL.CommandText = "DELETE from  prov.Requerimiento  WHERE iCodRequerimiento=@iCodRequerimiento"
        'cmdSQL.CommandText = "UPDATE prov.Requerimiento  SET bAnulado=1 WHERE  iCodRequerimiento=@iCodRequerimiento"
        cmdSQL.Parameters.Add("@iCodRequerimiento", SqlDbType.Int).Value = Me.iCodRequerimiento
        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub EliminarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "DELETE from  prov.Requerimiento  WHERE iCodRequerimiento=@iCodRequerimiento"
        'cmdSQL.CommandText = "UPDATE prov.Requerimiento  SET bAnulado=1 WHERE  iCodRequerimiento=@iCodRequerimiento"
        cmdSQL.Parameters.Add("@iCodRequerimiento", SqlDbType.Int).Value = Me.iCodRequerimiento
        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub getRecord()
        Dim readers As IDataReader
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL

        If bTransaccion = True Then cmdSQL.Transaction = Me.mc.miTransact Else 

        cmdSQL.CommandText = "SELECT * FROM prov.Requerimiento WHERE iCodRequerimiento=@iCodRequerimiento"
        cmdSQL.Parameters.Add("@iCodRequerimiento", SqlDbType.Int).Value = Me.iCodRequerimiento
        readers = cmdSQL.ExecuteReader
        If readers.Read() Then
            Me.iCodRequerimiento = CStr(readers.GetValue(0))
            Me.iCodCliente = CStr(readers.GetValue(1))
            Me.iCodclienteCuenta = CStr(readers.GetValue(2))
            Me.iCodContrata = CStr(readers.GetValue(3))
            Me.iCodContratistaContrato = CStr(readers.GetValue(4))
            Me.iCodSubContrata = CStr(readers.GetValue(5))
            Me.iCodTipoMoneda = CStr(readers.GetValue(6))
            Me.iCodTipoRequerimiento = CStr(readers.GetValue(7))
            Me.iCodTipoEstadoRequerimiento = CStr(readers.GetValue(8))
            Me.cEstado = CStr(readers.GetValue(9))
            Me.iPeriodo = CStr(readers.GetValue(10))
            Me.iCorrelativo = CStr(readers.GetValue(11))
            Me.cNroRequerimiento = CStr(readers.GetValue(12))
            Me.cSolicitante = CStr(readers.GetValue(13))
            Me.dFechaSolicitud = CStr(readers.GetValue(14))
            Me.iCodUsuarioSolicitud = CStr(readers.GetValue(15))
            Me.dFechaEnvio = CStr(readers.GetValue(16))
            Me.iCodUsuarioEnvio = CStr(readers.GetValue(17))
            Me.dFechaAprobacion = CStr(readers.GetValue(18))
            Me.iCodUsuarioAprueba = CStr(readers.GetValue(19))
            Me.bAprobado = CStr(readers.GetValue(20))
            Me.dFechaDesaAprobacionCliente = CStr(readers.GetValue(21))
            Me.iCodUsuarioDesaAprobacionCliente = CStr(readers.GetValue(22))
            Me.bAprobadoCliente = CStr(readers.GetValue(23))
            Me.cObs = CStr(readers.GetValue(24))
            Me.iCodUsuarioEstado = CStr(readers.GetValue(25))
            Me.dFechaEstado = CStr(readers.GetValue(26))
            Me.dFechaConvocatoriaIni = CStr(readers.GetValue(27))
            Me.dFechaConvocatoriaFin = CStr(readers.GetValue(28))
            Me.dFechaRegistroIni = CStr(readers.GetValue(29))
            Me.dFechaRegistroFin = CStr(readers.GetValue(30))
            Me.bFechaConsultas = CStr(readers.GetValue(31))
            Me.dFechaConsultasIni = CStr(readers.GetValue(32))
            Me.dFechaConsultasFin = CStr(readers.GetValue(33))
            Me.bFechaRespuestas = CStr(readers.GetValue(34))
            Me.dFechaRespuestasIni = CStr(readers.GetValue(35))
            Me.dFechaRespuestasFin = CStr(readers.GetValue(36))
            Me.bFechaIntegracion = CStr(readers.GetValue(37))
            Me.dFechaIntegracionIni = CStr(readers.GetValue(38))
            Me.dFechaIntegracionFin = CStr(readers.GetValue(39))
            Me.bFechaPresentaOferta = CStr(readers.GetValue(40))
            Me.dFechaPresentaOfertaIni = CStr(readers.GetValue(41))
            Me.dFechaPresentaOfertaFin = CStr(readers.GetValue(42))
            Me.bFechaEvaluacion = CStr(readers.GetValue(43))
            Me.dFechaEvaluacionIni = CStr(readers.GetValue(44))
            Me.dFechaEvaluacionFin = CStr(readers.GetValue(45))
            Me.dFechaAdjudicado = CStr(readers.GetValue(46))
            Me.cAlcanceRequerimiento = CStr(readers.GetValue(47))
            Me.cTerminosPago = CStr(readers.GetValue(48))
            Me.bFechaTiempoServicio = CStr(readers.GetValue(49))
            Me.dFechaTiempoServicioIni = CStr(readers.GetValue(50))
            Me.dFechaTiempoServicioFin = CStr(readers.GetValue(51))
            Me.cLogRequerimiento = CStr(readers.GetValue(52))
            Me.cUrlDocumentos = CStr(readers.GetValue(53))
            Me.cUrlCarpeta = CStr(readers.GetValue(54))
            Me.bLiberado = CStr(readers.GetValue(55))
            Me.iCodUsuarioLiberado = CStr(readers.GetValue(56))
            Me.dFechaLiberado = CStr(readers.GetValue(57))
            Me.cMotivoLiberado = CStr(readers.GetValue(58))
            Me.cNotasLiberado = CStr(readers.GetValue(59))
            Me.iCodUsuarioCreacion = CStr(readers.GetValue(60))
            Me.dFechaCreacion = CStr(readers.GetValue(61))
            Me.iCodUsuarioModificacion = CStr(readers.GetValue(62))
            Me.dFechaModificacion = CStr(readers.GetValue(63))
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
        cmdSQL.CommandText = "SELECT * FROM prov.Requerimiento"
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
    '**********************************************************************

    Public Sub ActualizarUrl()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL

        cmdSQL.CommandText = "UPDATE prov.Requerimiento SET cUrlDocumentos=@cUrlDocumentos WHERE iCodRequerimiento=@iCodRequerimiento"
        cmdSQL.Parameters.Add("@iCodRequerimiento", SqlDbType.Int).Value = Me.iCodRequerimiento
        cmdSQL.Parameters.Add("@cUrlDocumentos", SqlDbType.VarChar, -1).Value = Me.cUrlDocumentos

        cmdSQL.ExecuteNonQuery()
    End Sub


    Public Sub ActualizarEstado()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL

        cmdSQL.CommandText = "UPDATE  prov.Requerimiento SET iCodTipoEstadoRequerimiento=@iCodTipoEstadoRequerimiento,cEstado=@cEstado,dFechaEstado=@dFechaEstado,iCodUsuarioEstado=@iCodUsuarioEstado WHERE iCodRequerimiento=@iCodRequerimiento"
        cmdSQL.Parameters.Add("@iCodRequerimiento", SqlDbType.Int).Value = Me.iCodRequerimiento
        cmdSQL.Parameters.Add("@iCodTipoEstadoRequerimiento", SqlDbType.SmallInt).Value = Me.iCodTipoEstadoRequerimiento
        cmdSQL.Parameters.Add("@dFechaEstado", SqlDbType.DateTime).Value = Me.dFechaEstado
        cmdSQL.Parameters.Add("@cEstado", SqlDbType.VarChar, 30).Value = Me.cEstado
        cmdSQL.Parameters.Add("@iCodUsuarioEstado", SqlDbType.Int).Value = Me.iCodUsuarioEstado

        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub AprobarRequerimiento()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL

        cmdSQL.CommandText = "UPDATE  prov.Requerimiento SET iCodTipoEstadoRequerimiento=@iCodTipoEstadoRequerimiento,cEstado=@cEstado,dFechaEstado=@dFechaEstado,iCodUsuarioEstado=@iCodUsuarioEstado,dFechaAprobacion=@dFechaAprobacion,iCodUsuarioAprueba=@iCodUsuarioAprueba,bAprobado=@bAprobado,dFechaDesaAprobacionCliente=@dFechaDesaAprobacionCliente,iCodUsuarioDesaAprobacionCliente=@iCodUsuarioDesaAprobacionCliente,bAprobadoCliente=@bAprobadoCliente WHERE iCodRequerimiento=@iCodRequerimiento"
        cmdSQL.Parameters.Add("@iCodRequerimiento", SqlDbType.Int).Value = Me.iCodRequerimiento
        cmdSQL.Parameters.Add("@iCodTipoEstadoRequerimiento", SqlDbType.SmallInt).Value = Me.iCodTipoEstadoRequerimiento
        cmdSQL.Parameters.Add("@dFechaEstado", SqlDbType.DateTime).Value = Me.dFechaEstado
        cmdSQL.Parameters.Add("@cEstado", SqlDbType.VarChar, 30).Value = Me.cEstado
        cmdSQL.Parameters.Add("@iCodUsuarioEstado", SqlDbType.Int).Value = Me.iCodUsuarioEstado

        cmdSQL.Parameters.Add("@dFechaAprobacion", SqlDbType.DateTime).Value = Me.dFechaAprobacion
        cmdSQL.Parameters.Add("@iCodUsuarioAprueba", SqlDbType.Int).Value = Me.iCodUsuarioAprueba
        cmdSQL.Parameters.Add("@bAprobado", SqlDbType.Bit).Value = Me.bAprobado

        cmdSQL.Parameters.Add("@dFechaDesaAprobacionCliente", SqlDbType.DateTime).Value = Me.dFechaDesaAprobacionCliente
        cmdSQL.Parameters.Add("@iCodUsuarioDesaAprobacionCliente", SqlDbType.Int).Value = Me.iCodUsuarioDesaAprobacionCliente
        cmdSQL.Parameters.Add("@bAprobadoCliente", SqlDbType.Bit).Value = Me.bAprobadoCliente


        cmdSQL.ExecuteNonQuery()

       


    End Sub
    Public Sub DeleteAnularRequerimiento()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "prov.SP_UPD_AnularRequerimiento"
        cmdSQL.Parameters.Add("@iCodRequerimiento", SqlDbType.Int).Value = Me.iCodRequerimiento
        cmdSQL.Parameters.Add("@dFechaEstado", SqlDbType.DateTime).Value = Me.dFechaEstado
        cmdSQL.Parameters.Add("@iCodUsuarioEstado", SqlDbType.Int).Value = Me.iCodUsuarioEstado

        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Function AnularRequerimiento() As Integer
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = "prov.SP_UPD_RequerimientoAnulacion"
        cmdSQL.Parameters.Add("@iCodRequerimiento", SqlDbType.Int).Value = Me.iCodRequerimiento
        cmdSQL.Parameters.Add("@dFechaEstado", SqlDbType.DateTime).Value = Me.dFechaEstado
        cmdSQL.Parameters.Add("@iCodUsuarioEstado", SqlDbType.Int).Value = Me.iCodUsuarioEstado

        Return CInt(cmdSQL.ExecuteScalar())
    End Function
    Public Function EnviarARevision() As Integer
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = "prov.SP_UPD_EnviarRequerimientoARevisar"
        cmdSQL.Parameters.Add("@iCodRequerimiento", SqlDbType.Int).Value = Me.iCodRequerimiento
        cmdSQL.Parameters.Add("@iCodUsuarioEstado", SqlDbType.Int).Value = Me.iCodUsuarioEstado

        Return CInt(cmdSQL.ExecuteScalar())
    End Function
    Public Sub UpdateLiberarRequerimiento()

        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL

        cmdSQL.CommandText = "UPDATE  prov.Requerimiento SET bLiberado=@bLiberado,iCodUsuarioLiberado=@iCodUsuarioLiberado,dFechaLiberado=@dFechaLiberado,cMotivoLiberado=@cMotivoLiberado,cNotasLiberado=@cNotasLiberado WHERE iCodRequerimiento=@iCodRequerimiento"
        cmdSQL.Parameters.Add("@iCodRequerimiento", SqlDbType.Int).Value = Me.iCodRequerimiento
        cmdSQL.Parameters.Add("@bLiberado", SqlDbType.Bit).Value = Me.bLiberado
        cmdSQL.Parameters.Add("@iCodUsuarioLiberado", SqlDbType.Int).Value = Me.iCodUsuarioLiberado
        cmdSQL.Parameters.Add("@dFechaLiberado", SqlDbType.DateTime).Value = Me.dFechaLiberado
        cmdSQL.Parameters.Add("@cMotivoLiberado", SqlDbType.VarChar, 50).Value = Me.cMotivoLiberado
        cmdSQL.Parameters.Add("@cNotasLiberado", SqlDbType.VarChar, -1).Value = Me.cNotasLiberado

        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub UpdateCarpeta()
       
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL

        cmdSQL.CommandText = "UPDATE  prov.Requerimiento SET cUrlCarpeta=@cUrlCarpeta WHERE iCodRequerimiento=@iCodRequerimiento"
        cmdSQL.Parameters.Add("@iCodRequerimiento", SqlDbType.Int).Value = Me.iCodRequerimiento
       cmdSQL.Parameters.Add("@cUrlCarpeta", SqlDbType.VarChar, -1).Value = Me.cUrlCarpeta

        cmdSQL.ExecuteNonQuery()
    End Sub


    Public Function ListaRequerimientos(ByVal pFechaIni As String, ByVal pFechaFin As String) As DataTable

        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = "prov.SP_DT_RequerimientosLista"
        cmdSQL.Parameters.Add("@dFechaIni", SqlDbType.Date).Value = pFechaIni
        cmdSQL.Parameters.Add("@dFechaFin", SqlDbType.Date).Value = pFechaFin

        Dim readers As SqlDataReader
        readers = cmdSQL.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(readers)
        Return dt
    End Function

    Public Function ListaRequerimientosPorContrata() As DataTable

        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = "prov.SP_DTW_RequerimientosPorContrata"
        cmdSQL.Parameters.Add("@iCodContrata", SqlDbType.Int).Value = Me.iCodContrata

        Dim readers As SqlDataReader
        readers = cmdSQL.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(readers)
        Return dt
    End Function

    Public Function GetRequerimientoPorCodigo(ByVal pCodRequerimiento As String) As DataTable
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = "prov.SP_ROW_GetRequerimiento"
        cmdSQL.Parameters.Add("@iCodRequerimiento", SqlDbType.Int).Value = pCodRequerimiento

        Dim readers As SqlDataReader
        readers = cmdSQL.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(readers)
        Return dt
    End Function
End Class
