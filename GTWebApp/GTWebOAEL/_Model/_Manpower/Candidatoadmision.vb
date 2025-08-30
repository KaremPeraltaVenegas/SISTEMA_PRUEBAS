Imports System.Data.SqlClient

Public Class Candidatoadmision
    Public iCodCandidatoAdmision As String
    Public iCodCandidatoAdmisionTipo As String
    Public iCodCandidatoInforme As String
    Public iCodConvocatoria As String
    Public iCodCandidatoAdmisionOrigen As String
    Public bNuevo As String
    Public bRequierePostulacion As String
    Public dFechaSolicitud As String
    Public dFechaRegistro As String
    Public iCodUsuarioRegistro As String
    Public bDocumentoTramite As String
    Public dFechaEvaluacion As String
    Public bEvaluacion As String
    Public iCodUsuarioEvaluacion As String
    Public dFechaConsentimiento As String
    Public bConsentimiento As String
    Public iCodUsuarioConsentimiento As String
    Public dFechaAptitud As String
    Public bAptitud As String
    Public iCodUsuarioAptitud As String
    Public dFechaCheckList As String
    Public bCheckList As String
    Public iCodUsuarioCheckList As String
    Public dFechaExpediente As String
    Public bExpediente As String
    Public iCodUsuarioExpediente As String
    Public cObs As String
    Public bImprocedente As String
    Public cEstado As String
    Public iResultadoTramite As String
    Public iCodUsuarioResultado As String
    Public cGuid As String
    Public bRespuesta As String
    Public iCodUsuarioRespuesta As String
    Public dFechaRespuesta As String
    Public iNivelRiesgo As String
    Public iCodUsuario As String
    Public dFechaSis As String
    Public qSelect As String
    Public cTipoOpe As Char
    Public bTransaccion As Boolean = False
    Public mc As New ConnectSQL
    Public Function ListaDatos() As DataTable
        Dim Query As String
        Dim readers As DataTable
        Query = "SELECT * FROM dbo.CandidatoAdmision"
        readers = mc.ExecuteDataTable(Query)
        Return readers
    End Function
    Public Sub Insertar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "INSERT into dbo.CandidatoAdmision (iCodCandidatoAdmisionTipo,iCodCandidatoInforme,iCodConvocatoria,iCodCandidatoAdmisionOrigen,bNuevo,bRequierePostulacion,dFechaSolicitud,dFechaRegistro,iCodUsuarioRegistro,bDocumentoTramite,dFechaEvaluacion,bEvaluacion,iCodUsuarioEvaluacion,dFechaConsentimiento,bConsentimiento,iCodUsuarioConsentimiento,dFechaAptitud,bAptitud,iCodUsuarioAptitud,dFechaCheckList,bCheckList,iCodUsuarioCheckList,dFechaExpediente,bExpediente,iCodUsuarioExpediente,cObs,bImprocedente,cEstado,iResultadoTramite,iCodUsuarioResultado,cGuid,bRespuesta,iCodUsuarioRespuesta,dFechaRespuesta,iNivelRiesgo,iCodUsuario,dFechaSis ) VALUES(@iCodCandidatoAdmisionTipo,@iCodCandidatoInforme,@iCodConvocatoria,@iCodCandidatoAdmisionOrigen,@bNuevo,@bRequierePostulacion,@dFechaSolicitud,@dFechaRegistro,@iCodUsuarioRegistro,@bDocumentoTramite,@dFechaEvaluacion,@bEvaluacion,@iCodUsuarioEvaluacion,@dFechaConsentimiento,@bConsentimiento,@iCodUsuarioConsentimiento,@dFechaAptitud,@bAptitud,@iCodUsuarioAptitud,@dFechaCheckList,@bCheckList,@iCodUsuarioCheckList,@dFechaExpediente,@bExpediente,@iCodUsuarioExpediente,@cObs,@bImprocedente,@cEstado,@iResultadoTramite,@iCodUsuarioResultado,@cGuid,@bRespuesta,@iCodUsuarioRespuesta,@dFechaRespuesta,@iNivelRiesgo,@iCodUsuario,@dFechaSis); SELECT SCOPE_IDENTITY(); "
        cmdSQL.Parameters.Add("@iCodCandidatoAdmisionTipo", SqlDbType.Tinyint).Value = Me.iCodCandidatoAdmisionTipo
        cmdSQL.Parameters.Add("@iCodCandidatoInforme", SqlDbType.Int).Value = Me.iCodCandidatoInforme
        cmdSQL.Parameters.Add("@iCodConvocatoria", SqlDbType.Int).Value = Me.iCodConvocatoria
        cmdSQL.Parameters.Add("@iCodCandidatoAdmisionOrigen", SqlDbType.Int).Value = Me.iCodCandidatoAdmisionOrigen
        cmdSQL.Parameters.Add("@bNuevo", SqlDbType.Bit).Value = Me.bNuevo
        cmdSQL.Parameters.Add("@bRequierePostulacion", SqlDbType.Bit).Value = Me.bRequierePostulacion
        cmdSQL.Parameters.Add("@dFechaSolicitud", SqlDbType.Date).Value = Me.dFechaSolicitud
        cmdSQL.Parameters.Add("@dFechaRegistro", SqlDbType.Date).Value = Me.dFechaRegistro
        cmdSQL.Parameters.Add("@iCodUsuarioRegistro", SqlDbType.Int).Value = Me.iCodUsuarioRegistro
        cmdSQL.Parameters.Add("@bDocumentoTramite", SqlDbType.Bit).Value = Me.bDocumentoTramite
        cmdSQL.Parameters.Add("@dFechaEvaluacion", SqlDbType.Date).Value = Me.dFechaEvaluacion
        cmdSQL.Parameters.Add("@bEvaluacion", SqlDbType.Bit).Value = Me.bEvaluacion
        cmdSQL.Parameters.Add("@iCodUsuarioEvaluacion", SqlDbType.Int).Value = Me.iCodUsuarioEvaluacion
        cmdSQL.Parameters.Add("@dFechaConsentimiento", SqlDbType.Date).Value = Me.dFechaConsentimiento
        cmdSQL.Parameters.Add("@bConsentimiento", SqlDbType.Bit).Value = Me.bConsentimiento
        cmdSQL.Parameters.Add("@iCodUsuarioConsentimiento", SqlDbType.Int).Value = Me.iCodUsuarioConsentimiento
        cmdSQL.Parameters.Add("@dFechaAptitud", SqlDbType.Date).Value = Me.dFechaAptitud
        cmdSQL.Parameters.Add("@bAptitud", SqlDbType.Bit).Value = Me.bAptitud
        cmdSQL.Parameters.Add("@iCodUsuarioAptitud", SqlDbType.Int).Value = Me.iCodUsuarioAptitud
        cmdSQL.Parameters.Add("@dFechaCheckList", SqlDbType.Date).Value = Me.dFechaCheckList
        cmdSQL.Parameters.Add("@bCheckList", SqlDbType.Bit).Value = Me.bCheckList
        cmdSQL.Parameters.Add("@iCodUsuarioCheckList", SqlDbType.Int).Value = Me.iCodUsuarioCheckList
        cmdSQL.Parameters.Add("@dFechaExpediente", SqlDbType.Date).Value = Me.dFechaExpediente
        cmdSQL.Parameters.Add("@bExpediente", SqlDbType.Bit).Value = Me.bExpediente
        cmdSQL.Parameters.Add("@iCodUsuarioExpediente", SqlDbType.Int).Value = Me.iCodUsuarioExpediente
        cmdSQL.Parameters.Add("@cObs", SqlDbType.Varchar, -1).Value = Me.cObs
        cmdSQL.Parameters.Add("@bImprocedente", SqlDbType.Bit).Value = Me.bImprocedente
        cmdSQL.Parameters.Add("@cEstado", SqlDbType.Varchar, 2).Value = Me.cEstado
        cmdSQL.Parameters.Add("@iResultadoTramite", SqlDbType.Tinyint).Value = Me.iResultadoTramite
        cmdSQL.Parameters.Add("@iCodUsuarioResultado", SqlDbType.Int).Value = Me.iCodUsuarioResultado
        cmdSQL.Parameters.Add("@cGuid", SqlDbType.Varchar, 50).Value = Me.cGuid
        cmdSQL.Parameters.Add("@bRespuesta", SqlDbType.Bit).Value = Me.bRespuesta
        cmdSQL.Parameters.Add("@iCodUsuarioRespuesta", SqlDbType.Int).Value = Me.iCodUsuarioRespuesta
        cmdSQL.Parameters.Add("@dFechaRespuesta", SqlDbType.Datetime).Value = Me.dFechaRespuesta
        cmdSQL.Parameters.Add("@iNivelRiesgo", SqlDbType.Tinyint).Value = Me.iNivelRiesgo
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.Datetime).Value = Me.dFechaSis

        Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
        If pCodInsert > 0 Then
            Me.iCodCandidatoAdmision = pCodInsert
        Else
            Me.iCodCandidatoAdmision = 0
        End If
    End Sub
    Public Sub InsertarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "INSERT into dbo.CandidatoAdmision (iCodCandidatoAdmisionTipo,iCodCandidatoInforme,iCodConvocatoria,iCodCandidatoAdmisionOrigen,bNuevo,bRequierePostulacion,dFechaSolicitud,dFechaRegistro,iCodUsuarioRegistro,bDocumentoTramite,dFechaEvaluacion,bEvaluacion,iCodUsuarioEvaluacion,dFechaConsentimiento,bConsentimiento,iCodUsuarioConsentimiento,dFechaAptitud,bAptitud,iCodUsuarioAptitud,dFechaCheckList,bCheckList,iCodUsuarioCheckList,dFechaExpediente,bExpediente,iCodUsuarioExpediente,cObs,bImprocedente,cEstado,iResultadoTramite,iCodUsuarioResultado,cGuid,bRespuesta,iCodUsuarioRespuesta,dFechaRespuesta,iNivelRiesgo,iCodUsuario,dFechaSis ) VALUES(@iCodCandidatoAdmisionTipo,@iCodCandidatoInforme,@iCodConvocatoria,@iCodCandidatoAdmisionOrigen,@bNuevo,@bRequierePostulacion,@dFechaSolicitud,@dFechaRegistro,@iCodUsuarioRegistro,@bDocumentoTramite,@dFechaEvaluacion,@bEvaluacion,@iCodUsuarioEvaluacion,@dFechaConsentimiento,@bConsentimiento,@iCodUsuarioConsentimiento,@dFechaAptitud,@bAptitud,@iCodUsuarioAptitud,@dFechaCheckList,@bCheckList,@iCodUsuarioCheckList,@dFechaExpediente,@bExpediente,@iCodUsuarioExpediente,@cObs,@bImprocedente,@cEstado,@iResultadoTramite,@iCodUsuarioResultado,@cGuid,@bRespuesta,@iCodUsuarioRespuesta,@dFechaRespuesta,@iNivelRiesgo,@iCodUsuario,@dFechaSis); SELECT SCOPE_IDENTITY(); "
        cmdSQL.Parameters.Add("@iCodCandidatoAdmisionTipo", SqlDbType.Tinyint).Value = Me.iCodCandidatoAdmisionTipo
        cmdSQL.Parameters.Add("@iCodCandidatoInforme", SqlDbType.Int).Value = Me.iCodCandidatoInforme
        cmdSQL.Parameters.Add("@iCodConvocatoria", SqlDbType.Int).Value = Me.iCodConvocatoria
        cmdSQL.Parameters.Add("@iCodCandidatoAdmisionOrigen", SqlDbType.Int).Value = Me.iCodCandidatoAdmisionOrigen
        cmdSQL.Parameters.Add("@bNuevo", SqlDbType.Bit).Value = Me.bNuevo
        cmdSQL.Parameters.Add("@bRequierePostulacion", SqlDbType.Bit).Value = Me.bRequierePostulacion
        cmdSQL.Parameters.Add("@dFechaSolicitud", SqlDbType.Date).Value = Me.dFechaSolicitud
        cmdSQL.Parameters.Add("@dFechaRegistro", SqlDbType.Date).Value = Me.dFechaRegistro
        cmdSQL.Parameters.Add("@iCodUsuarioRegistro", SqlDbType.Int).Value = Me.iCodUsuarioRegistro
        cmdSQL.Parameters.Add("@bDocumentoTramite", SqlDbType.Bit).Value = Me.bDocumentoTramite
        cmdSQL.Parameters.Add("@dFechaEvaluacion", SqlDbType.Date).Value = Me.dFechaEvaluacion
        cmdSQL.Parameters.Add("@bEvaluacion", SqlDbType.Bit).Value = Me.bEvaluacion
        cmdSQL.Parameters.Add("@iCodUsuarioEvaluacion", SqlDbType.Int).Value = Me.iCodUsuarioEvaluacion
        cmdSQL.Parameters.Add("@dFechaConsentimiento", SqlDbType.Date).Value = Me.dFechaConsentimiento
        cmdSQL.Parameters.Add("@bConsentimiento", SqlDbType.Bit).Value = Me.bConsentimiento
        cmdSQL.Parameters.Add("@iCodUsuarioConsentimiento", SqlDbType.Int).Value = Me.iCodUsuarioConsentimiento
        cmdSQL.Parameters.Add("@dFechaAptitud", SqlDbType.Date).Value = Me.dFechaAptitud
        cmdSQL.Parameters.Add("@bAptitud", SqlDbType.Bit).Value = Me.bAptitud
        cmdSQL.Parameters.Add("@iCodUsuarioAptitud", SqlDbType.Int).Value = Me.iCodUsuarioAptitud
        cmdSQL.Parameters.Add("@dFechaCheckList", SqlDbType.Date).Value = Me.dFechaCheckList
        cmdSQL.Parameters.Add("@bCheckList", SqlDbType.Bit).Value = Me.bCheckList
        cmdSQL.Parameters.Add("@iCodUsuarioCheckList", SqlDbType.Int).Value = Me.iCodUsuarioCheckList
        cmdSQL.Parameters.Add("@dFechaExpediente", SqlDbType.Date).Value = Me.dFechaExpediente
        cmdSQL.Parameters.Add("@bExpediente", SqlDbType.Bit).Value = Me.bExpediente
        cmdSQL.Parameters.Add("@iCodUsuarioExpediente", SqlDbType.Int).Value = Me.iCodUsuarioExpediente
        cmdSQL.Parameters.Add("@cObs", SqlDbType.Varchar, -1).Value = Me.cObs
        cmdSQL.Parameters.Add("@bImprocedente", SqlDbType.Bit).Value = Me.bImprocedente
        cmdSQL.Parameters.Add("@cEstado", SqlDbType.Varchar, 2).Value = Me.cEstado
        cmdSQL.Parameters.Add("@iResultadoTramite", SqlDbType.Tinyint).Value = Me.iResultadoTramite
        cmdSQL.Parameters.Add("@iCodUsuarioResultado", SqlDbType.Int).Value = Me.iCodUsuarioResultado
        cmdSQL.Parameters.Add("@cGuid", SqlDbType.Varchar, 50).Value = Me.cGuid
        cmdSQL.Parameters.Add("@bRespuesta", SqlDbType.Bit).Value = Me.bRespuesta
        cmdSQL.Parameters.Add("@iCodUsuarioRespuesta", SqlDbType.Int).Value = Me.iCodUsuarioRespuesta
        cmdSQL.Parameters.Add("@dFechaRespuesta", SqlDbType.Datetime).Value = Me.dFechaRespuesta
        cmdSQL.Parameters.Add("@iNivelRiesgo", SqlDbType.Tinyint).Value = Me.iNivelRiesgo
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.Datetime).Value = Me.dFechaSis

        Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
        If pCodInsert > 0 Then
            Me.iCodCandidatoAdmision = pCodInsert
        Else
            Me.iCodCandidatoAdmision = 0
        End If
    End Sub
    Public Sub Modificar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "UPDATE  dbo.CandidatoAdmision SET iCodCandidatoAdmisionTipo=@iCodCandidatoAdmisionTipo,iCodCandidatoInforme=@iCodCandidatoInforme,iCodConvocatoria=@iCodConvocatoria,iCodCandidatoAdmisionOrigen=@iCodCandidatoAdmisionOrigen,bNuevo=@bNuevo,bRequierePostulacion=@bRequierePostulacion,dFechaSolicitud=@dFechaSolicitud,dFechaRegistro=@dFechaRegistro,iCodUsuarioRegistro=@iCodUsuarioRegistro,bDocumentoTramite=@bDocumentoTramite,dFechaEvaluacion=@dFechaEvaluacion,bEvaluacion=@bEvaluacion,iCodUsuarioEvaluacion=@iCodUsuarioEvaluacion,dFechaConsentimiento=@dFechaConsentimiento,bConsentimiento=@bConsentimiento,iCodUsuarioConsentimiento=@iCodUsuarioConsentimiento,dFechaAptitud=@dFechaAptitud,bAptitud=@bAptitud,iCodUsuarioAptitud=@iCodUsuarioAptitud,dFechaCheckList=@dFechaCheckList,bCheckList=@bCheckList,iCodUsuarioCheckList=@iCodUsuarioCheckList,dFechaExpediente=@dFechaExpediente,bExpediente=@bExpediente,iCodUsuarioExpediente=@iCodUsuarioExpediente,cObs=@cObs,bImprocedente=@bImprocedente,cEstado=@cEstado,iResultadoTramite=@iResultadoTramite,iCodUsuarioResultado=@iCodUsuarioResultado,cGuid=@cGuid,bRespuesta=@bRespuesta,iCodUsuarioRespuesta=@iCodUsuarioRespuesta,dFechaRespuesta=@dFechaRespuesta,iNivelRiesgo=@iNivelRiesgo,iCodUsuario=@iCodUsuario,dFechaSis=@dFechaSis WHERE iCodCandidatoAdmision=@iCodCandidatoAdmision"
        cmdSQL.Parameters.Add("@iCodCandidatoAdmision", SqlDbType.Int).Value = Me.iCodCandidatoAdmision
        cmdSQL.Parameters.Add("@iCodCandidatoAdmisionTipo", SqlDbType.Tinyint).Value = Me.iCodCandidatoAdmisionTipo
        cmdSQL.Parameters.Add("@iCodCandidatoInforme", SqlDbType.Int).Value = Me.iCodCandidatoInforme
        cmdSQL.Parameters.Add("@iCodConvocatoria", SqlDbType.Int).Value = Me.iCodConvocatoria
        cmdSQL.Parameters.Add("@iCodCandidatoAdmisionOrigen", SqlDbType.Int).Value = Me.iCodCandidatoAdmisionOrigen
        cmdSQL.Parameters.Add("@bNuevo", SqlDbType.Bit).Value = Me.bNuevo
        cmdSQL.Parameters.Add("@bRequierePostulacion", SqlDbType.Bit).Value = Me.bRequierePostulacion
        cmdSQL.Parameters.Add("@dFechaSolicitud", SqlDbType.Date).Value = Me.dFechaSolicitud
        cmdSQL.Parameters.Add("@dFechaRegistro", SqlDbType.Date).Value = Me.dFechaRegistro
        cmdSQL.Parameters.Add("@iCodUsuarioRegistro", SqlDbType.Int).Value = Me.iCodUsuarioRegistro
        cmdSQL.Parameters.Add("@bDocumentoTramite", SqlDbType.Bit).Value = Me.bDocumentoTramite
        cmdSQL.Parameters.Add("@dFechaEvaluacion", SqlDbType.Date).Value = Me.dFechaEvaluacion
        cmdSQL.Parameters.Add("@bEvaluacion", SqlDbType.Bit).Value = Me.bEvaluacion
        cmdSQL.Parameters.Add("@iCodUsuarioEvaluacion", SqlDbType.Int).Value = Me.iCodUsuarioEvaluacion
        cmdSQL.Parameters.Add("@dFechaConsentimiento", SqlDbType.Date).Value = Me.dFechaConsentimiento
        cmdSQL.Parameters.Add("@bConsentimiento", SqlDbType.Bit).Value = Me.bConsentimiento
        cmdSQL.Parameters.Add("@iCodUsuarioConsentimiento", SqlDbType.Int).Value = Me.iCodUsuarioConsentimiento
        cmdSQL.Parameters.Add("@dFechaAptitud", SqlDbType.Date).Value = Me.dFechaAptitud
        cmdSQL.Parameters.Add("@bAptitud", SqlDbType.Bit).Value = Me.bAptitud
        cmdSQL.Parameters.Add("@iCodUsuarioAptitud", SqlDbType.Int).Value = Me.iCodUsuarioAptitud
        cmdSQL.Parameters.Add("@dFechaCheckList", SqlDbType.Date).Value = Me.dFechaCheckList
        cmdSQL.Parameters.Add("@bCheckList", SqlDbType.Bit).Value = Me.bCheckList
        cmdSQL.Parameters.Add("@iCodUsuarioCheckList", SqlDbType.Int).Value = Me.iCodUsuarioCheckList
        cmdSQL.Parameters.Add("@dFechaExpediente", SqlDbType.Date).Value = Me.dFechaExpediente
        cmdSQL.Parameters.Add("@bExpediente", SqlDbType.Bit).Value = Me.bExpediente
        cmdSQL.Parameters.Add("@iCodUsuarioExpediente", SqlDbType.Int).Value = Me.iCodUsuarioExpediente
        cmdSQL.Parameters.Add("@cObs", SqlDbType.Varchar, -1).Value = Me.cObs
        cmdSQL.Parameters.Add("@bImprocedente", SqlDbType.Bit).Value = Me.bImprocedente
        cmdSQL.Parameters.Add("@cEstado", SqlDbType.Varchar, 2).Value = Me.cEstado
        cmdSQL.Parameters.Add("@iResultadoTramite", SqlDbType.Tinyint).Value = Me.iResultadoTramite
        cmdSQL.Parameters.Add("@iCodUsuarioResultado", SqlDbType.Int).Value = Me.iCodUsuarioResultado
        cmdSQL.Parameters.Add("@cGuid", SqlDbType.Varchar, 50).Value = Me.cGuid
        cmdSQL.Parameters.Add("@bRespuesta", SqlDbType.Bit).Value = Me.bRespuesta
        cmdSQL.Parameters.Add("@iCodUsuarioRespuesta", SqlDbType.Int).Value = Me.iCodUsuarioRespuesta
        cmdSQL.Parameters.Add("@dFechaRespuesta", SqlDbType.Datetime).Value = Me.dFechaRespuesta
        cmdSQL.Parameters.Add("@iNivelRiesgo", SqlDbType.Tinyint).Value = Me.iNivelRiesgo
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.Datetime).Value = Me.dFechaSis

        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub ModificarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "UPDATE  dbo.CandidatoAdmision SET iCodCandidatoAdmisionTipo=@iCodCandidatoAdmisionTipo,iCodCandidatoInforme=@iCodCandidatoInforme,iCodConvocatoria=@iCodConvocatoria,iCodCandidatoAdmisionOrigen=@iCodCandidatoAdmisionOrigen,bNuevo=@bNuevo,bRequierePostulacion=@bRequierePostulacion,dFechaSolicitud=@dFechaSolicitud,dFechaRegistro=@dFechaRegistro,iCodUsuarioRegistro=@iCodUsuarioRegistro,bDocumentoTramite=@bDocumentoTramite,dFechaEvaluacion=@dFechaEvaluacion,bEvaluacion=@bEvaluacion,iCodUsuarioEvaluacion=@iCodUsuarioEvaluacion,dFechaConsentimiento=@dFechaConsentimiento,bConsentimiento=@bConsentimiento,iCodUsuarioConsentimiento=@iCodUsuarioConsentimiento,dFechaAptitud=@dFechaAptitud,bAptitud=@bAptitud,iCodUsuarioAptitud=@iCodUsuarioAptitud,dFechaCheckList=@dFechaCheckList,bCheckList=@bCheckList,iCodUsuarioCheckList=@iCodUsuarioCheckList,dFechaExpediente=@dFechaExpediente,bExpediente=@bExpediente,iCodUsuarioExpediente=@iCodUsuarioExpediente,cObs=@cObs,bImprocedente=@bImprocedente,cEstado=@cEstado,iResultadoTramite=@iResultadoTramite,iCodUsuarioResultado=@iCodUsuarioResultado,cGuid=@cGuid,bRespuesta=@bRespuesta,iCodUsuarioRespuesta=@iCodUsuarioRespuesta,dFechaRespuesta=@dFechaRespuesta,iNivelRiesgo=@iNivelRiesgo,iCodUsuario=@iCodUsuario,dFechaSis=@dFechaSis WHERE iCodCandidatoAdmision=@iCodCandidatoAdmision"
        cmdSQL.Parameters.Add("@iCodCandidatoAdmision", SqlDbType.Int).Value = Me.iCodCandidatoAdmision
        cmdSQL.Parameters.Add("@iCodCandidatoAdmisionTipo", SqlDbType.Tinyint).Value = Me.iCodCandidatoAdmisionTipo
        cmdSQL.Parameters.Add("@iCodCandidatoInforme", SqlDbType.Int).Value = Me.iCodCandidatoInforme
        cmdSQL.Parameters.Add("@iCodConvocatoria", SqlDbType.Int).Value = Me.iCodConvocatoria
        cmdSQL.Parameters.Add("@iCodCandidatoAdmisionOrigen", SqlDbType.Int).Value = Me.iCodCandidatoAdmisionOrigen
        cmdSQL.Parameters.Add("@bNuevo", SqlDbType.Bit).Value = Me.bNuevo
        cmdSQL.Parameters.Add("@bRequierePostulacion", SqlDbType.Bit).Value = Me.bRequierePostulacion
        cmdSQL.Parameters.Add("@dFechaSolicitud", SqlDbType.Date).Value = Me.dFechaSolicitud
        cmdSQL.Parameters.Add("@dFechaRegistro", SqlDbType.Date).Value = Me.dFechaRegistro
        cmdSQL.Parameters.Add("@iCodUsuarioRegistro", SqlDbType.Int).Value = Me.iCodUsuarioRegistro
        cmdSQL.Parameters.Add("@bDocumentoTramite", SqlDbType.Bit).Value = Me.bDocumentoTramite
        cmdSQL.Parameters.Add("@dFechaEvaluacion", SqlDbType.Date).Value = Me.dFechaEvaluacion
        cmdSQL.Parameters.Add("@bEvaluacion", SqlDbType.Bit).Value = Me.bEvaluacion
        cmdSQL.Parameters.Add("@iCodUsuarioEvaluacion", SqlDbType.Int).Value = Me.iCodUsuarioEvaluacion
        cmdSQL.Parameters.Add("@dFechaConsentimiento", SqlDbType.Date).Value = Me.dFechaConsentimiento
        cmdSQL.Parameters.Add("@bConsentimiento", SqlDbType.Bit).Value = Me.bConsentimiento
        cmdSQL.Parameters.Add("@iCodUsuarioConsentimiento", SqlDbType.Int).Value = Me.iCodUsuarioConsentimiento
        cmdSQL.Parameters.Add("@dFechaAptitud", SqlDbType.Date).Value = Me.dFechaAptitud
        cmdSQL.Parameters.Add("@bAptitud", SqlDbType.Bit).Value = Me.bAptitud
        cmdSQL.Parameters.Add("@iCodUsuarioAptitud", SqlDbType.Int).Value = Me.iCodUsuarioAptitud
        cmdSQL.Parameters.Add("@dFechaCheckList", SqlDbType.Date).Value = Me.dFechaCheckList
        cmdSQL.Parameters.Add("@bCheckList", SqlDbType.Bit).Value = Me.bCheckList
        cmdSQL.Parameters.Add("@iCodUsuarioCheckList", SqlDbType.Int).Value = Me.iCodUsuarioCheckList
        cmdSQL.Parameters.Add("@dFechaExpediente", SqlDbType.Date).Value = Me.dFechaExpediente
        cmdSQL.Parameters.Add("@bExpediente", SqlDbType.Bit).Value = Me.bExpediente
        cmdSQL.Parameters.Add("@iCodUsuarioExpediente", SqlDbType.Int).Value = Me.iCodUsuarioExpediente
        cmdSQL.Parameters.Add("@cObs", SqlDbType.Varchar, -1).Value = Me.cObs
        cmdSQL.Parameters.Add("@bImprocedente", SqlDbType.Bit).Value = Me.bImprocedente
        cmdSQL.Parameters.Add("@cEstado", SqlDbType.Varchar, 2).Value = Me.cEstado
        cmdSQL.Parameters.Add("@iResultadoTramite", SqlDbType.Tinyint).Value = Me.iResultadoTramite
        cmdSQL.Parameters.Add("@iCodUsuarioResultado", SqlDbType.Int).Value = Me.iCodUsuarioResultado
        cmdSQL.Parameters.Add("@cGuid", SqlDbType.Varchar, 50).Value = Me.cGuid
        cmdSQL.Parameters.Add("@bRespuesta", SqlDbType.Bit).Value = Me.bRespuesta
        cmdSQL.Parameters.Add("@iCodUsuarioRespuesta", SqlDbType.Int).Value = Me.iCodUsuarioRespuesta
        cmdSQL.Parameters.Add("@dFechaRespuesta", SqlDbType.Datetime).Value = Me.dFechaRespuesta
        cmdSQL.Parameters.Add("@iNivelRiesgo", SqlDbType.Tinyint).Value = Me.iNivelRiesgo
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.Datetime).Value = Me.dFechaSis

        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub Eliminar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "DELETE from  dbo.CandidatoAdmision  WHERE iCodCandidatoAdmision=@iCodCandidatoAdmision"
        'cmdSQL.CommandText = "UPDATE dbo.CandidatoAdmision  SET bAnulado=1 WHERE  iCodCandidatoAdmision=@iCodCandidatoAdmision"
        cmdSQL.Parameters.Add("@iCodCandidatoAdmision", SqlDbType.Int).Value = Me.iCodCandidatoAdmision
        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub EliminarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "DELETE from  dbo.CandidatoAdmision  WHERE iCodCandidatoAdmision=@iCodCandidatoAdmision"
        'cmdSQL.CommandText = "UPDATE dbo.CandidatoAdmision  SET bAnulado=1 WHERE  iCodCandidatoAdmision=@iCodCandidatoAdmision"
        cmdSQL.Parameters.Add("@iCodCandidatoAdmision", SqlDbType.Int).Value = Me.iCodCandidatoAdmision
        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub getRecord()
        Dim readers As IDataReader
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL

        If bTransaccion = True Then cmdSQL.Transaction = Me.mc.miTransact Else 

        cmdSQL.CommandText = "SELECT * FROM dbo.CandidatoAdmision WHERE iCodCandidatoAdmision=@iCodCandidatoAdmision"
        cmdSQL.Parameters.Add("@iCodCandidatoAdmision", SqlDbType.Int).Value = Me.iCodCandidatoAdmision
        readers = cmdSQL.ExecuteReader
        If readers.Read() Then
            Me.iCodCandidatoAdmision = CStr(readers.GetValue(0))
            Me.iCodCandidatoAdmisionTipo = CStr(readers.GetValue(1))
            Me.iCodCandidatoInforme = CStr(readers.GetValue(2))
            Me.iCodConvocatoria = CStr(readers.GetValue(3))
            Me.iCodCandidatoAdmisionOrigen = CStr(readers.GetValue(4))
            Me.bNuevo = CStr(readers.GetValue(5))
            Me.bRequierePostulacion = CStr(readers.GetValue(6))
            Me.dFechaSolicitud = CStr(readers.GetValue(7))
            Me.dFechaRegistro = CStr(readers.GetValue(8))
            Me.iCodUsuarioRegistro = CStr(readers.GetValue(9))
            Me.bDocumentoTramite = CStr(readers.GetValue(10))
            Me.dFechaEvaluacion = CStr(readers.GetValue(11))
            Me.bEvaluacion = CStr(readers.GetValue(12))
            Me.iCodUsuarioEvaluacion = CStr(readers.GetValue(13))
            Me.dFechaConsentimiento = CStr(readers.GetValue(14))
            Me.bConsentimiento = CStr(readers.GetValue(15))
            Me.iCodUsuarioConsentimiento = CStr(readers.GetValue(16))
            Me.dFechaAptitud = CStr(readers.GetValue(17))
            Me.bAptitud = CStr(readers.GetValue(18))
            Me.iCodUsuarioAptitud = CStr(readers.GetValue(19))
            Me.dFechaCheckList = CStr(readers.GetValue(20))
            Me.bCheckList = CStr(readers.GetValue(21))
            Me.iCodUsuarioCheckList = CStr(readers.GetValue(22))
            Me.dFechaExpediente = CStr(readers.GetValue(23))
            Me.bExpediente = CStr(readers.GetValue(24))
            Me.iCodUsuarioExpediente = CStr(readers.GetValue(25))
            Me.cObs = CStr(readers.GetValue(26))
            Me.bImprocedente = CStr(readers.GetValue(27))
            Me.cEstado = CStr(readers.GetValue(28))
            Me.iResultadoTramite = CStr(readers.GetValue(29))
            Me.iCodUsuarioResultado = CStr(readers.GetValue(30))
            Me.cGuid = CStr(readers.GetValue(31))
            Me.bRespuesta = CStr(readers.GetValue(32))
            Me.iCodUsuarioRespuesta = CStr(readers.GetValue(33))
            Me.dFechaRespuesta = CStr(readers.GetValue(34))
            Me.iNivelRiesgo = CStr(readers.GetValue(35))
            Me.iCodUsuario = CStr(readers.GetValue(36))
            Me.dFechaSis = CStr(readers.GetValue(37))
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
        cmdSQL.CommandText = "SELECT * FROM dbo.CandidatoAdmision"
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
    '**********************************************************
    Public Function ListaNivelRiesgo() As DataTable
        Dim miDataTable As New DataTable
        miDataTable.Columns.Add("ValueMember")
        miDataTable.Columns.Add("DisplayMember")
        With miDataTable
            .Rows.Add("0", "SIN RIESGO")
            .Rows.Add("1", "RIESGO BAJO")
            .Rows.Add("2", "RIESGO MEDIO")
            .Rows.Add("3", "RIESGO SIGNIFICATIVO")
            .Rows.Add("3", "RIESGO ALTO")
        End With
        Return miDataTable
    End Function
    'En uso: WEB
    Public Function ListaSolicitudes(ByVal pFechaInicio As String, ByVal pFechaFin As String) As DataTable

        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = "main.SP_DT_GetCandidatoAdmisionPorFechaRegistro"
        cmdSQL.Parameters.Add("@dFechaRegistroInicio", SqlDbType.Date).Value = pFechaInicio
        cmdSQL.Parameters.Add("@dFechaRegistroFin", SqlDbType.Date).Value = pFechaFin

        Dim readers As SqlDataReader
        readers = cmdSQL.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(readers)
        Return dt
    End Function

    Public Function ExisteRegistroNuevo(ByVal pNroDNI As String, ByVal pTipoDoc As String) As Boolean
        Dim Query As String

        Dim count As Integer
        Query = "select count(ca.iCodCandidatoInforme) from " & _
        " candidatoadmision ca  inner join candidatoinforme ci on ca.iCodCandidatoInforme=ci.iCodCandidatoInforme " & _
        " where ci.cDNI='" & pNroDNI & "' and ci.cTipoDoc='" & pTipoDoc & "' and ca.iCodCandidatoAdmisionTipo=1 "
        count = mc.ExecuteScalar(Query)
        If (count > 0) Then 'SI EXISTE EXTRAEMOS DATOS
            ExisteRegistroNuevo = True
        Else
            ExisteRegistroNuevo = False
        End If
        Return ExisteRegistroNuevo
    End Function

    Public Sub UpdateLineaObs()
        Dim Query As String
        Query = String.Format("UPDATE Candidatoadmision SET cObs='{1}' WHERE iCodCandidatoAdmision={0}", Me.iCodCandidatoAdmision, Me.cObs)
        mc.ExecuteQuery(Query)
    End Sub

    Public Sub ModificarRegistro()
        Dim Query As String
        Query = String.Format("UPDATE  Candidatoadmision SET iCodCandidatoAdmisionTipo='{1}',iCodCandidatoInforme='{2}',iCodConvocatoria='{3}',iCodCandidatoAdmisionOrigen='{4}',bNuevo='{5}',bRequierePostulacion='{6}',dFechaSolicitud='{7}',dFechaRegistro='{8}',iCodUsuarioRegistro='{9}',bDocumentoTramite='{10}',dFechaEvaluacion='{11}',bEvaluacion='{12}',iCodUsuarioEvaluacion='{13}',dFechaConsentimiento='{14}',bConsentimiento='{15}',iCodUsuarioConsentimiento='{16}',dFechaAptitud='{17}',bAptitud='{18}',iCodUsuarioAptitud='{19}',dFechaCheckList='{20}',bCheckList='{21}',iCodUsuarioCheckList='{22}',dFechaExpediente='{23}',bExpediente='{24}',iCodUsuarioExpediente='{25}',cObs=cObs+'{26}',bImprocedente='{27}',cEstado='{28}',iResultadoTramite='{29}',iCodUsuarioResultado='{30}',cGuid='{31}',bRespuesta='{32}',iCodUsuarioRespuesta='{33}',dFechaRespuesta='{34}',iCodUsuario='{35}',dFechaSis='{36}' WHERE iCodCandidatoAdmision={0}", Me.iCodCandidatoAdmision, Me.iCodCandidatoAdmisionTipo, Me.iCodCandidatoInforme, Me.iCodConvocatoria, Me.iCodCandidatoAdmisionOrigen, Me.bNuevo, Me.bRequierePostulacion, Me.dFechaSolicitud, Me.dFechaRegistro, Me.iCodUsuarioRegistro, Me.bDocumentoTramite, Me.dFechaEvaluacion, Me.bEvaluacion, Me.iCodUsuarioEvaluacion, Me.dFechaConsentimiento, Me.bConsentimiento, Me.iCodUsuarioConsentimiento, Me.dFechaAptitud, Me.bAptitud, Me.iCodUsuarioAptitud, Me.dFechaCheckList, Me.bCheckList, Me.iCodUsuarioCheckList, Me.dFechaExpediente, Me.bExpediente, Me.iCodUsuarioExpediente, Me.cObs, Me.bImprocedente, Me.cEstado, Me.iResultadoTramite, Me.iCodUsuarioResultado, Me.cGuid, Me.bRespuesta, Me.iCodUsuarioRespuesta, Me.dFechaRespuesta, Me.iCodUsuario, Me.dFechaSis)

        'InputBox("", "", Query)
        mc.ExecuteQuery(Query)
    End Sub


    Public Sub UpdateLineaObsAgregar()
        Dim Query As String

        Query = String.Format("UPDATE Candidatoadmision SET cObs=cObs + '{1}' WHERE iCodCandidatoAdmision={0}", Me.iCodCandidatoAdmision, Me.cObs)
        mc.ExecuteQuery(Query)
    End Sub
    Public Sub UpdateLineaObsAgregarConRpta()
        Dim Query As String

        Query = String.Format("UPDATE Candidatoadmision SET cObs=cObs + '{1}',iCodUsuarioRespuesta='{2}',bRespuesta=1,dFechaRespuesta=GETDATE() WHERE iCodCandidatoAdmision={0}", Me.iCodCandidatoAdmision, Me.cObs, Me.iCodUsuarioRespuesta)
        mc.ExecuteQuery(Query)
    End Sub
    Public Sub AnularTramite()
        Dim Query As String

        Query = String.Format("UPDATE Candidatoadmision SET bImprocedente=1,cEstado='R',iCodUsuario='{1}',cObs=cObs+'{2}',dFechaSis=GETDATE() WHERE iCodCandidatoAdmision={0}", Me.iCodCandidatoAdmision, Me.iCodUsuario, Me.cObs)
        mc.ExecuteQuery(Query)
    End Sub

    Public Sub UpdateEnvioEvaluacion()
        Dim Query As String
        Query = String.Format("UPDATE  Candidatoadmision SET dFechaEvaluacion='{1}',bEvaluacion='{2}',iCodUsuarioEvaluacion='{3}',cObs=cObs+'{4}' WHERE iCodCandidatoAdmision={0}", _
                              Me.iCodCandidatoAdmision, Me.dFechaEvaluacion, Me.bEvaluacion, Me.iCodUsuarioEvaluacion, Me.cObs)

        mc.ExecuteQuery(Query)
    End Sub



    Public Sub UpdateDatoEvaluacion()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "UPDATE  dbo.CandidatoAdmision SET dFechaAptitud=@dFechaAptitud,bAptitud=@bAptitud,iCodUsuarioAptitud=@iCodUsuarioAptitud,cObs=(cObs + @cObs)  WHERE iCodCandidatoAdmision=@iCodCandidatoAdmision"
        cmdSQL.Parameters.Add("@iCodCandidatoAdmision", SqlDbType.Int).Value = Me.iCodCandidatoAdmision
        'cmdSQL.Parameters.Add("@iCodCandidatoInforme", SqlDbType.Int).Value = Me.iCodCandidatoInforme
        cmdSQL.Parameters.Add("@dFechaAptitud", SqlDbType.Date).Value = Me.dFechaAptitud
        cmdSQL.Parameters.Add("@bAptitud", SqlDbType.Bit).Value = Me.bAptitud
        cmdSQL.Parameters.Add("@iCodUsuarioAptitud", SqlDbType.Int).Value = Me.iCodUsuarioAptitud
        cmdSQL.Parameters.Add("@cObs", SqlDbType.VarChar, -1).Value = Me.cObs
        cmdSQL.ExecuteNonQuery()
    End Sub

    Public Sub UpdateDatoTramiteCheckList()

        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "UPDATE  dbo.CandidatoAdmision SET dFechaCheckList=@dFechaCheckList,bCheckList=@bCheckList,iCodUsuarioCheckList=@iCodUsuarioCheckList,bImprocedente=@bImprocedente,cEstado=@cEstado,iResultadoTramite=@iResultadoTramite,cObs=(cObs + @cObs)  WHERE iCodCandidatoAdmision=@iCodCandidatoAdmision"
        cmdSQL.Parameters.Add("@iCodCandidatoAdmision", SqlDbType.Int).Value = Me.iCodCandidatoAdmision
        cmdSQL.Parameters.Add("@dFechaCheckList", SqlDbType.Date).Value = Me.dFechaCheckList
        cmdSQL.Parameters.Add("@bCheckList", SqlDbType.Bit).Value = Me.bCheckList
        cmdSQL.Parameters.Add("@iCodUsuarioCheckList", SqlDbType.Int).Value = Me.iCodUsuarioCheckList
        cmdSQL.Parameters.Add("@bImprocedente", SqlDbType.Bit).Value = Me.bImprocedente
        cmdSQL.Parameters.Add("@cEstado", SqlDbType.VarChar, 2).Value = Me.cEstado
        cmdSQL.Parameters.Add("@iResultadoTramite", SqlDbType.TinyInt).Value = Me.iResultadoTramite
        cmdSQL.Parameters.Add("@cObs", SqlDbType.VarChar, -1).Value = Me.cObs

        cmdSQL.ExecuteNonQuery()
    End Sub


    Public Sub UpdateEnvioRespuestaCorreo()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "UPDATE  dbo.CandidatoAdmision SET bRespuesta=@bRespuesta,iCodUsuarioRespuesta=@iCodUsuarioRespuesta,dFechaRespuesta=@dFechaRespuesta WHERE iCodCandidatoAdmision=@iCodCandidatoAdmision"
        cmdSQL.Parameters.Add("@iCodCandidatoAdmision", SqlDbType.Int).Value = Me.iCodCandidatoAdmision
        

        cmdSQL.Parameters.Add("@bRespuesta", SqlDbType.Bit).Value = Me.bRespuesta
        cmdSQL.Parameters.Add("@iCodUsuarioRespuesta", SqlDbType.Int).Value = Me.iCodUsuarioRespuesta
        cmdSQL.Parameters.Add("@dFechaRespuesta", SqlDbType.DateTime).Value = Me.dFechaRespuesta

        cmdSQL.ExecuteNonQuery()
    End Sub


    Public Sub UpdateObservarRetornarARevision()


        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "UPDATE  dbo.CandidatoAdmision SET bCheckList=@bCheckList,bImprocedente=@bImprocedente,cEstado=@cEstado,iResultadoTramite=@iResultadoTramite,cObs=(cObs + @cObs)  WHERE iCodCandidatoAdmision=@iCodCandidatoAdmision"
        cmdSQL.Parameters.Add("@iCodCandidatoAdmision", SqlDbType.Int).Value = Me.iCodCandidatoAdmision
        'cmdSQL.Parameters.Add("@dFechaCheckList", SqlDbType.Date).Value = Me.dFechaCheckList
        cmdSQL.Parameters.Add("@bCheckList", SqlDbType.Bit).Value = Me.bCheckList
        'cmdSQL.Parameters.Add("@iCodUsuarioCheckList", SqlDbType.Int).Value = Me.iCodUsuarioCheckList
        cmdSQL.Parameters.Add("@bImprocedente", SqlDbType.Bit).Value = Me.bImprocedente
        cmdSQL.Parameters.Add("@cEstado", SqlDbType.VarChar, 2).Value = Me.cEstado
        cmdSQL.Parameters.Add("@iResultadoTramite", SqlDbType.TinyInt).Value = Me.iResultadoTramite
        cmdSQL.Parameters.Add("@cObs", SqlDbType.VarChar, -1).Value = Me.cObs

        cmdSQL.ExecuteNonQuery()
    End Sub

    Public cBloqueaRegistroActualizacion As String
    Public cFechaFinBloqueo As String
    Public cFechaFinObservado As String
    Public bBloqueoObservado As Boolean

    Public Function HabilitadoRegistroActualizacion(ByVal pCodCandidatoInforme As String) As DataTable


        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = "main.SP_ROW_UltimaActualizacionDiasBloqueado"
        cmdSQL.Parameters.Add("@iCodCandidatoInforme", SqlDbType.Int).Value = pCodCandidatoInforme

        Dim readers As SqlDataReader
        readers = cmdSQL.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(readers)
        Return dt

    End Function


    Public Sub UpdateBloqueaActividadSIEL()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "UPDATE  dbo.CandidatoAdmision SET bRespuesta=@bRespuesta,iCodUsuarioRespuesta=@iCodUsuarioRespuesta,dFechaRespuesta=@dFechaRespuesta WHERE iCodCandidatoAdmision=@iCodCandidatoAdmision"
        cmdSQL.Parameters.Add("@iCodCandidatoAdmision", SqlDbType.Int).Value = Me.iCodCandidatoAdmision


        cmdSQL.Parameters.Add("@bRespuesta", SqlDbType.Bit).Value = Me.bRespuesta
        cmdSQL.Parameters.Add("@iCodUsuarioRespuesta", SqlDbType.Int).Value = Me.iCodUsuarioRespuesta
        cmdSQL.Parameters.Add("@dFechaRespuesta", SqlDbType.DateTime).Value = Me.dFechaRespuesta

        cmdSQL.ExecuteNonQuery()
    End Sub

    Public Function GetCandidatoAdmisionPorCodigo(ByVal pCodCandidatoAdmision As String) As DataTable
        Dim Query As String = ""
        Dim readers As DataTable

        Query = " exec main.SP_ROW_CandidatoAdmisionPorCodigo " &
                     " @iCodCandidatoAdmision=" & Trim(pCodCandidatoAdmision) & " "
        readers = mc.ExecuteDataTable(Query)

        Return readers

    End Function
End Class
