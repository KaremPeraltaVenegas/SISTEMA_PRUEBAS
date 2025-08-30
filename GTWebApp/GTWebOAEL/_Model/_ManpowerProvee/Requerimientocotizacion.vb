Imports System.Data.SqlClient
Public Class Requerimientocotizacion
Public iCodRequerimientoCotizacion As String
Public iCodRequerimiento As String
Public iCodContrataLocal As String
Public cCondicion As String
Public cEstado As String
Public iTipoPostulacion As String
Public dFechaPostulacion As String
Public iCodUsuarioPostulacion As String
Public iRanking As String
Public iDiasValidezOferta As String
Public iTiempoEntrega As String
Public cCondicionesPropuesta As String
Public cAnotaciones As String
Public dFechaPresentaPropuesta As String
Public iCodUsuarioPresentaPropuesta As String
Public bIGV As String
Public nSubTotal As String
Public nIGV As String
Public nTotal As String
    Public bAdjudicado As String
    Public iCodUsuarioAdjudica As String
    Public dFechaAdjudica As String
    Public cNotasAdjudica As String
    Public iCodUsuarioObs As String
    Public dFechaObs As String
    Public cObs As String
    Public cUrlDocumentosPostor As String
    Public iCodUsuarioFeedbackContrata As String
    Public dFechaFeedbackContrata As String
    Public cFeedbackContrata As String
    Public cFeedbackContrataDetalle As String
    Public iCodUsuarioValidaFeedback As String
    Public dFechaValidaFeedback As String
    Public cFeedbackCorrecto As String
    Public cTipoValidaFeedback As String
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
        Query = "SELECT * FROM prov.RequerimientoCotizacion"
        readers = mc.ExecuteDataTable(Query)
        Return readers
    End Function
    Public Sub Insertar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "INSERT into prov.RequerimientoCotizacion (iCodRequerimiento,iCodContrataLocal,cCondicion,cEstado,iTipoPostulacion,dFechaPostulacion,iCodUsuarioPostulacion,iRanking,iDiasValidezOferta,iTiempoEntrega,cCondicionesPropuesta,cAnotaciones,dFechaPresentaPropuesta,iCodUsuarioPresentaPropuesta,bIGV,nSubTotal,nIGV,nTotal,bAdjudicado,iCodUsuarioAdjudica,dFechaAdjudica,cNotasAdjudica,iCodUsuarioObs,dFechaObs,cObs,cUrlDocumentosPostor,iCodUsuarioFeedbackContrata,dFechaFeedbackContrata,cFeedbackContrata,cFeedbackContrataDetalle,iCodUsuarioValidaFeedback,dFechaValidaFeedback,cFeedbackCorrecto,cTipoValidaFeedback,iCodUsuarioCreacion,dFechaCreacion,iCodUsuarioModificacion,dFechaModificacion ) VALUES(@iCodRequerimiento,@iCodContrataLocal,@cCondicion,@cEstado,@iTipoPostulacion,@dFechaPostulacion,@iCodUsuarioPostulacion,@iRanking,@iDiasValidezOferta,@iTiempoEntrega,@cCondicionesPropuesta,@cAnotaciones,@dFechaPresentaPropuesta,@iCodUsuarioPresentaPropuesta,@bIGV,@nSubTotal,@nIGV,@nTotal,@bAdjudicado,@iCodUsuarioAdjudica,@dFechaAdjudica,@cNotasAdjudica,@iCodUsuarioObs,@dFechaObs,@cObs,@cUrlDocumentosPostor,@iCodUsuarioFeedbackContrata,@dFechaFeedbackContrata,@cFeedbackContrata,@cFeedbackContrataDetalle,@iCodUsuarioValidaFeedback,@dFechaValidaFeedback,@cFeedbackCorrecto,@cTipoValidaFeedback,@iCodUsuarioCreacion,@dFechaCreacion,@iCodUsuarioModificacion,@dFechaModificacion); SELECT SCOPE_IDENTITY(); "
        cmdSQL.Parameters.Add("@iCodRequerimiento", SqlDbType.Int).Value = Me.iCodRequerimiento
        cmdSQL.Parameters.Add("@iCodContrataLocal", SqlDbType.Int).Value = Me.iCodContrataLocal
        cmdSQL.Parameters.Add("@cCondicion", SqlDbType.Varchar, 30).Value = Me.cCondicion
        cmdSQL.Parameters.Add("@cEstado", SqlDbType.Varchar, 20).Value = Me.cEstado
        cmdSQL.Parameters.Add("@iTipoPostulacion", SqlDbType.Tinyint).Value = Me.iTipoPostulacion
        cmdSQL.Parameters.Add("@dFechaPostulacion", SqlDbType.Datetime).Value = Me.dFechaPostulacion
        cmdSQL.Parameters.Add("@iCodUsuarioPostulacion", SqlDbType.Int).Value = Me.iCodUsuarioPostulacion
        cmdSQL.Parameters.Add("@iRanking", SqlDbType.Tinyint).Value = Me.iRanking
        cmdSQL.Parameters.Add("@iDiasValidezOferta", SqlDbType.Tinyint).Value = Me.iDiasValidezOferta
        cmdSQL.Parameters.Add("@iTiempoEntrega", SqlDbType.Tinyint).Value = Me.iTiempoEntrega
        cmdSQL.Parameters.Add("@cCondicionesPropuesta", SqlDbType.Varchar, -1).Value = Me.cCondicionesPropuesta
        cmdSQL.Parameters.Add("@cAnotaciones", SqlDbType.Varchar, -1).Value = Me.cAnotaciones
        cmdSQL.Parameters.Add("@dFechaPresentaPropuesta", SqlDbType.Datetime).Value = Me.dFechaPresentaPropuesta
        cmdSQL.Parameters.Add("@iCodUsuarioPresentaPropuesta", SqlDbType.Int).Value = Me.iCodUsuarioPresentaPropuesta
        cmdSQL.Parameters.Add("@bIGV", SqlDbType.Bit).Value = Me.bIGV
        cmdSQL.Parameters.Add("@nSubTotal", SqlDbType.Decimal).Value = Me.nSubTotal
        cmdSQL.Parameters.Add("@nIGV", SqlDbType.Decimal).Value = Me.nIGV
        cmdSQL.Parameters.Add("@nTotal", SqlDbType.Decimal).Value = Me.nTotal
        cmdSQL.Parameters.Add("@bAdjudicado", SqlDbType.Bit).Value = Me.bAdjudicado
        cmdSQL.Parameters.Add("@iCodUsuarioAdjudica", SqlDbType.Int).Value = Me.iCodUsuarioAdjudica
        cmdSQL.Parameters.Add("@dFechaAdjudica", SqlDbType.Datetime).Value = Me.dFechaAdjudica
        cmdSQL.Parameters.Add("@cNotasAdjudica", SqlDbType.Varchar, -1).Value = Me.cNotasAdjudica
        cmdSQL.Parameters.Add("@iCodUsuarioObs", SqlDbType.Int).Value = Me.iCodUsuarioObs
        cmdSQL.Parameters.Add("@dFechaObs", SqlDbType.Datetime).Value = Me.dFechaObs
        cmdSQL.Parameters.Add("@cObs", SqlDbType.Varchar, -1).Value = Me.cObs
        cmdSQL.Parameters.Add("@cUrlDocumentosPostor", SqlDbType.Varchar, -1).Value = Me.cUrlDocumentosPostor
        cmdSQL.Parameters.Add("@iCodUsuarioFeedbackContrata", SqlDbType.Int).Value = Me.iCodUsuarioFeedbackContrata
        cmdSQL.Parameters.Add("@dFechaFeedbackContrata", SqlDbType.Datetime).Value = Me.dFechaFeedbackContrata
        cmdSQL.Parameters.Add("@cFeedbackContrata", SqlDbType.Varchar, 100).Value = Me.cFeedbackContrata
        cmdSQL.Parameters.Add("@cFeedbackContrataDetalle", SqlDbType.Varchar, -1).Value = Me.cFeedbackContrataDetalle
        cmdSQL.Parameters.Add("@iCodUsuarioValidaFeedback", SqlDbType.Int).Value = Me.iCodUsuarioValidaFeedback
        cmdSQL.Parameters.Add("@dFechaValidaFeedback", SqlDbType.Datetime).Value = Me.dFechaValidaFeedback
        cmdSQL.Parameters.Add("@cFeedbackCorrecto", SqlDbType.Varchar, 3).Value = Me.cFeedbackCorrecto
        cmdSQL.Parameters.Add("@cTipoValidaFeedback", SqlDbType.Varchar, 2).Value = Me.cTipoValidaFeedback
        cmdSQL.Parameters.Add("@iCodUsuarioCreacion", SqlDbType.Int).Value = Me.iCodUsuarioCreacion
        cmdSQL.Parameters.Add("@dFechaCreacion", SqlDbType.Datetime).Value = Me.dFechaCreacion
        cmdSQL.Parameters.Add("@iCodUsuarioModificacion", SqlDbType.Int).Value = Me.iCodUsuarioModificacion
        cmdSQL.Parameters.Add("@dFechaModificacion", SqlDbType.Datetime).Value = Me.dFechaModificacion

        Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
        If pCodInsert > 0 Then
            Me.iCodRequerimientoCotizacion = pCodInsert
        Else
            Me.iCodRequerimientoCotizacion = 0
        End If
    End Sub
    Public Sub InsertarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "INSERT into prov.RequerimientoCotizacion (iCodRequerimiento,iCodContrataLocal,cCondicion,cEstado,iTipoPostulacion,dFechaPostulacion,iCodUsuarioPostulacion,iRanking,iDiasValidezOferta,iTiempoEntrega,cCondicionesPropuesta,cAnotaciones,dFechaPresentaPropuesta,iCodUsuarioPresentaPropuesta,bIGV,nSubTotal,nIGV,nTotal,bAdjudicado,iCodUsuarioAdjudica,dFechaAdjudica,cNotasAdjudica,iCodUsuarioObs,dFechaObs,cObs,cUrlDocumentosPostor,iCodUsuarioFeedbackContrata,dFechaFeedbackContrata,cFeedbackContrata,cFeedbackContrataDetalle,iCodUsuarioValidaFeedback,dFechaValidaFeedback,cFeedbackCorrecto,cTipoValidaFeedback,iCodUsuarioCreacion,dFechaCreacion,iCodUsuarioModificacion,dFechaModificacion ) VALUES(@iCodRequerimiento,@iCodContrataLocal,@cCondicion,@cEstado,@iTipoPostulacion,@dFechaPostulacion,@iCodUsuarioPostulacion,@iRanking,@iDiasValidezOferta,@iTiempoEntrega,@cCondicionesPropuesta,@cAnotaciones,@dFechaPresentaPropuesta,@iCodUsuarioPresentaPropuesta,@bIGV,@nSubTotal,@nIGV,@nTotal,@bAdjudicado,@iCodUsuarioAdjudica,@dFechaAdjudica,@cNotasAdjudica,@iCodUsuarioObs,@dFechaObs,@cObs,@cUrlDocumentosPostor,@iCodUsuarioFeedbackContrata,@dFechaFeedbackContrata,@cFeedbackContrata,@cFeedbackContrataDetalle,@iCodUsuarioValidaFeedback,@dFechaValidaFeedback,@cFeedbackCorrecto,@cTipoValidaFeedback,@iCodUsuarioCreacion,@dFechaCreacion,@iCodUsuarioModificacion,@dFechaModificacion); SELECT SCOPE_IDENTITY(); "
        cmdSQL.Parameters.Add("@iCodRequerimiento", SqlDbType.Int).Value = Me.iCodRequerimiento
        cmdSQL.Parameters.Add("@iCodContrataLocal", SqlDbType.Int).Value = Me.iCodContrataLocal
        cmdSQL.Parameters.Add("@cCondicion", SqlDbType.Varchar, 30).Value = Me.cCondicion
        cmdSQL.Parameters.Add("@cEstado", SqlDbType.Varchar, 20).Value = Me.cEstado
        cmdSQL.Parameters.Add("@iTipoPostulacion", SqlDbType.Tinyint).Value = Me.iTipoPostulacion
        cmdSQL.Parameters.Add("@dFechaPostulacion", SqlDbType.Datetime).Value = Me.dFechaPostulacion
        cmdSQL.Parameters.Add("@iCodUsuarioPostulacion", SqlDbType.Int).Value = Me.iCodUsuarioPostulacion
        cmdSQL.Parameters.Add("@iRanking", SqlDbType.Tinyint).Value = Me.iRanking
        cmdSQL.Parameters.Add("@iDiasValidezOferta", SqlDbType.Tinyint).Value = Me.iDiasValidezOferta
        cmdSQL.Parameters.Add("@iTiempoEntrega", SqlDbType.Tinyint).Value = Me.iTiempoEntrega
        cmdSQL.Parameters.Add("@cCondicionesPropuesta", SqlDbType.Varchar, -1).Value = Me.cCondicionesPropuesta
        cmdSQL.Parameters.Add("@cAnotaciones", SqlDbType.Varchar, -1).Value = Me.cAnotaciones
        cmdSQL.Parameters.Add("@dFechaPresentaPropuesta", SqlDbType.Datetime).Value = Me.dFechaPresentaPropuesta
        cmdSQL.Parameters.Add("@iCodUsuarioPresentaPropuesta", SqlDbType.Int).Value = Me.iCodUsuarioPresentaPropuesta
        cmdSQL.Parameters.Add("@bIGV", SqlDbType.Bit).Value = Me.bIGV
        cmdSQL.Parameters.Add("@nSubTotal", SqlDbType.Decimal).Value = Me.nSubTotal
        cmdSQL.Parameters.Add("@nIGV", SqlDbType.Decimal).Value = Me.nIGV
        cmdSQL.Parameters.Add("@nTotal", SqlDbType.Decimal).Value = Me.nTotal
        cmdSQL.Parameters.Add("@bAdjudicado", SqlDbType.Bit).Value = Me.bAdjudicado
        cmdSQL.Parameters.Add("@iCodUsuarioAdjudica", SqlDbType.Int).Value = Me.iCodUsuarioAdjudica
        cmdSQL.Parameters.Add("@dFechaAdjudica", SqlDbType.Datetime).Value = Me.dFechaAdjudica
        cmdSQL.Parameters.Add("@cNotasAdjudica", SqlDbType.Varchar, -1).Value = Me.cNotasAdjudica
        cmdSQL.Parameters.Add("@iCodUsuarioObs", SqlDbType.Int).Value = Me.iCodUsuarioObs
        cmdSQL.Parameters.Add("@dFechaObs", SqlDbType.Datetime).Value = Me.dFechaObs
        cmdSQL.Parameters.Add("@cObs", SqlDbType.Varchar, -1).Value = Me.cObs
        cmdSQL.Parameters.Add("@cUrlDocumentosPostor", SqlDbType.Varchar, -1).Value = Me.cUrlDocumentosPostor
        cmdSQL.Parameters.Add("@iCodUsuarioFeedbackContrata", SqlDbType.Int).Value = Me.iCodUsuarioFeedbackContrata
        cmdSQL.Parameters.Add("@dFechaFeedbackContrata", SqlDbType.Datetime).Value = Me.dFechaFeedbackContrata
        cmdSQL.Parameters.Add("@cFeedbackContrata", SqlDbType.Varchar, 100).Value = Me.cFeedbackContrata
        cmdSQL.Parameters.Add("@cFeedbackContrataDetalle", SqlDbType.Varchar, -1).Value = Me.cFeedbackContrataDetalle
        cmdSQL.Parameters.Add("@iCodUsuarioValidaFeedback", SqlDbType.Int).Value = Me.iCodUsuarioValidaFeedback
        cmdSQL.Parameters.Add("@dFechaValidaFeedback", SqlDbType.Datetime).Value = Me.dFechaValidaFeedback
        cmdSQL.Parameters.Add("@cFeedbackCorrecto", SqlDbType.Varchar, 3).Value = Me.cFeedbackCorrecto
        cmdSQL.Parameters.Add("@cTipoValidaFeedback", SqlDbType.Varchar, 2).Value = Me.cTipoValidaFeedback
        cmdSQL.Parameters.Add("@iCodUsuarioCreacion", SqlDbType.Int).Value = Me.iCodUsuarioCreacion
        cmdSQL.Parameters.Add("@dFechaCreacion", SqlDbType.Datetime).Value = Me.dFechaCreacion
        cmdSQL.Parameters.Add("@iCodUsuarioModificacion", SqlDbType.Int).Value = Me.iCodUsuarioModificacion
        cmdSQL.Parameters.Add("@dFechaModificacion", SqlDbType.Datetime).Value = Me.dFechaModificacion

        Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
        If pCodInsert > 0 Then
            Me.iCodRequerimientoCotizacion = pCodInsert
        Else
            Me.iCodRequerimientoCotizacion = 0
        End If
    End Sub
    Public Sub Modificar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "UPDATE  prov.RequerimientoCotizacion SET iCodRequerimiento=@iCodRequerimiento,iCodContrataLocal=@iCodContrataLocal,cCondicion=@cCondicion,cEstado=@cEstado,iTipoPostulacion=@iTipoPostulacion,dFechaPostulacion=@dFechaPostulacion,iCodUsuarioPostulacion=@iCodUsuarioPostulacion,iRanking=@iRanking,iDiasValidezOferta=@iDiasValidezOferta,iTiempoEntrega=@iTiempoEntrega,cCondicionesPropuesta=@cCondicionesPropuesta,cAnotaciones=@cAnotaciones,dFechaPresentaPropuesta=@dFechaPresentaPropuesta,iCodUsuarioPresentaPropuesta=@iCodUsuarioPresentaPropuesta,bIGV=@bIGV,nSubTotal=@nSubTotal,nIGV=@nIGV,nTotal=@nTotal,bAdjudicado=@bAdjudicado,iCodUsuarioAdjudica=@iCodUsuarioAdjudica,dFechaAdjudica=@dFechaAdjudica,cNotasAdjudica=@cNotasAdjudica,iCodUsuarioObs=@iCodUsuarioObs,dFechaObs=@dFechaObs,cObs=@cObs,cUrlDocumentosPostor=@cUrlDocumentosPostor,iCodUsuarioFeedbackContrata=@iCodUsuarioFeedbackContrata,dFechaFeedbackContrata=@dFechaFeedbackContrata,cFeedbackContrata=@cFeedbackContrata,cFeedbackContrataDetalle=@cFeedbackContrataDetalle,iCodUsuarioValidaFeedback=@iCodUsuarioValidaFeedback,dFechaValidaFeedback=@dFechaValidaFeedback,cFeedbackCorrecto=@cFeedbackCorrecto,cTipoValidaFeedback=@cTipoValidaFeedback,iCodUsuarioCreacion=@iCodUsuarioCreacion,dFechaCreacion=@dFechaCreacion,iCodUsuarioModificacion=@iCodUsuarioModificacion,dFechaModificacion=@dFechaModificacion WHERE iCodRequerimientoCotizacion=@iCodRequerimientoCotizacion"
        cmdSQL.Parameters.Add("@iCodRequerimientoCotizacion", SqlDbType.Int).Value = Me.iCodRequerimientoCotizacion
        cmdSQL.Parameters.Add("@iCodRequerimiento", SqlDbType.Int).Value = Me.iCodRequerimiento
        cmdSQL.Parameters.Add("@iCodContrataLocal", SqlDbType.Int).Value = Me.iCodContrataLocal
        cmdSQL.Parameters.Add("@cCondicion", SqlDbType.Varchar, 30).Value = Me.cCondicion
        cmdSQL.Parameters.Add("@cEstado", SqlDbType.Varchar, 20).Value = Me.cEstado
        cmdSQL.Parameters.Add("@iTipoPostulacion", SqlDbType.Tinyint).Value = Me.iTipoPostulacion
        cmdSQL.Parameters.Add("@dFechaPostulacion", SqlDbType.Datetime).Value = Me.dFechaPostulacion
        cmdSQL.Parameters.Add("@iCodUsuarioPostulacion", SqlDbType.Int).Value = Me.iCodUsuarioPostulacion
        cmdSQL.Parameters.Add("@iRanking", SqlDbType.Tinyint).Value = Me.iRanking
        cmdSQL.Parameters.Add("@iDiasValidezOferta", SqlDbType.Tinyint).Value = Me.iDiasValidezOferta
        cmdSQL.Parameters.Add("@iTiempoEntrega", SqlDbType.Tinyint).Value = Me.iTiempoEntrega
        cmdSQL.Parameters.Add("@cCondicionesPropuesta", SqlDbType.Varchar, -1).Value = Me.cCondicionesPropuesta
        cmdSQL.Parameters.Add("@cAnotaciones", SqlDbType.Varchar, -1).Value = Me.cAnotaciones
        cmdSQL.Parameters.Add("@dFechaPresentaPropuesta", SqlDbType.Datetime).Value = Me.dFechaPresentaPropuesta
        cmdSQL.Parameters.Add("@iCodUsuarioPresentaPropuesta", SqlDbType.Int).Value = Me.iCodUsuarioPresentaPropuesta
        cmdSQL.Parameters.Add("@bIGV", SqlDbType.Bit).Value = Me.bIGV
        cmdSQL.Parameters.Add("@nSubTotal", SqlDbType.Decimal).Value = Me.nSubTotal
        cmdSQL.Parameters.Add("@nIGV", SqlDbType.Decimal).Value = Me.nIGV
        cmdSQL.Parameters.Add("@nTotal", SqlDbType.Decimal).Value = Me.nTotal
        cmdSQL.Parameters.Add("@bAdjudicado", SqlDbType.Bit).Value = Me.bAdjudicado
        cmdSQL.Parameters.Add("@iCodUsuarioAdjudica", SqlDbType.Int).Value = Me.iCodUsuarioAdjudica
        cmdSQL.Parameters.Add("@dFechaAdjudica", SqlDbType.Datetime).Value = Me.dFechaAdjudica
        cmdSQL.Parameters.Add("@cNotasAdjudica", SqlDbType.Varchar, -1).Value = Me.cNotasAdjudica
        cmdSQL.Parameters.Add("@iCodUsuarioObs", SqlDbType.Int).Value = Me.iCodUsuarioObs
        cmdSQL.Parameters.Add("@dFechaObs", SqlDbType.Datetime).Value = Me.dFechaObs
        cmdSQL.Parameters.Add("@cObs", SqlDbType.Varchar, -1).Value = Me.cObs
        cmdSQL.Parameters.Add("@cUrlDocumentosPostor", SqlDbType.Varchar, -1).Value = Me.cUrlDocumentosPostor
        cmdSQL.Parameters.Add("@iCodUsuarioFeedbackContrata", SqlDbType.Int).Value = Me.iCodUsuarioFeedbackContrata
        cmdSQL.Parameters.Add("@dFechaFeedbackContrata", SqlDbType.Datetime).Value = Me.dFechaFeedbackContrata
        cmdSQL.Parameters.Add("@cFeedbackContrata", SqlDbType.Varchar, 100).Value = Me.cFeedbackContrata
        cmdSQL.Parameters.Add("@cFeedbackContrataDetalle", SqlDbType.Varchar, -1).Value = Me.cFeedbackContrataDetalle
        cmdSQL.Parameters.Add("@iCodUsuarioValidaFeedback", SqlDbType.Int).Value = Me.iCodUsuarioValidaFeedback
        cmdSQL.Parameters.Add("@dFechaValidaFeedback", SqlDbType.Datetime).Value = Me.dFechaValidaFeedback
        cmdSQL.Parameters.Add("@cFeedbackCorrecto", SqlDbType.Varchar, 3).Value = Me.cFeedbackCorrecto
        cmdSQL.Parameters.Add("@cTipoValidaFeedback", SqlDbType.Varchar, 2).Value = Me.cTipoValidaFeedback
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
        cmdSQL.CommandText = "UPDATE  prov.RequerimientoCotizacion SET iCodRequerimiento=@iCodRequerimiento,iCodContrataLocal=@iCodContrataLocal,cCondicion=@cCondicion,cEstado=@cEstado,iTipoPostulacion=@iTipoPostulacion,dFechaPostulacion=@dFechaPostulacion,iCodUsuarioPostulacion=@iCodUsuarioPostulacion,iRanking=@iRanking,iDiasValidezOferta=@iDiasValidezOferta,iTiempoEntrega=@iTiempoEntrega,cCondicionesPropuesta=@cCondicionesPropuesta,cAnotaciones=@cAnotaciones,dFechaPresentaPropuesta=@dFechaPresentaPropuesta,iCodUsuarioPresentaPropuesta=@iCodUsuarioPresentaPropuesta,bIGV=@bIGV,nSubTotal=@nSubTotal,nIGV=@nIGV,nTotal=@nTotal,bAdjudicado=@bAdjudicado,iCodUsuarioAdjudica=@iCodUsuarioAdjudica,dFechaAdjudica=@dFechaAdjudica,cNotasAdjudica=@cNotasAdjudica,iCodUsuarioObs=@iCodUsuarioObs,dFechaObs=@dFechaObs,cObs=@cObs,cUrlDocumentosPostor=@cUrlDocumentosPostor,iCodUsuarioFeedbackContrata=@iCodUsuarioFeedbackContrata,dFechaFeedbackContrata=@dFechaFeedbackContrata,cFeedbackContrata=@cFeedbackContrata,cFeedbackContrataDetalle=@cFeedbackContrataDetalle,iCodUsuarioValidaFeedback=@iCodUsuarioValidaFeedback,dFechaValidaFeedback=@dFechaValidaFeedback,cFeedbackCorrecto=@cFeedbackCorrecto,cTipoValidaFeedback=@cTipoValidaFeedback,iCodUsuarioCreacion=@iCodUsuarioCreacion,dFechaCreacion=@dFechaCreacion,iCodUsuarioModificacion=@iCodUsuarioModificacion,dFechaModificacion=@dFechaModificacion WHERE iCodRequerimientoCotizacion=@iCodRequerimientoCotizacion"
        cmdSQL.Parameters.Add("@iCodRequerimientoCotizacion", SqlDbType.Int).Value = Me.iCodRequerimientoCotizacion
        cmdSQL.Parameters.Add("@iCodRequerimiento", SqlDbType.Int).Value = Me.iCodRequerimiento
        cmdSQL.Parameters.Add("@iCodContrataLocal", SqlDbType.Int).Value = Me.iCodContrataLocal
        cmdSQL.Parameters.Add("@cCondicion", SqlDbType.Varchar, 30).Value = Me.cCondicion
        cmdSQL.Parameters.Add("@cEstado", SqlDbType.Varchar, 20).Value = Me.cEstado
        cmdSQL.Parameters.Add("@iTipoPostulacion", SqlDbType.Tinyint).Value = Me.iTipoPostulacion
        cmdSQL.Parameters.Add("@dFechaPostulacion", SqlDbType.Datetime).Value = Me.dFechaPostulacion
        cmdSQL.Parameters.Add("@iCodUsuarioPostulacion", SqlDbType.Int).Value = Me.iCodUsuarioPostulacion
        cmdSQL.Parameters.Add("@iRanking", SqlDbType.Tinyint).Value = Me.iRanking
        cmdSQL.Parameters.Add("@iDiasValidezOferta", SqlDbType.Tinyint).Value = Me.iDiasValidezOferta
        cmdSQL.Parameters.Add("@iTiempoEntrega", SqlDbType.Tinyint).Value = Me.iTiempoEntrega
        cmdSQL.Parameters.Add("@cCondicionesPropuesta", SqlDbType.Varchar, -1).Value = Me.cCondicionesPropuesta
        cmdSQL.Parameters.Add("@cAnotaciones", SqlDbType.Varchar, -1).Value = Me.cAnotaciones
        cmdSQL.Parameters.Add("@dFechaPresentaPropuesta", SqlDbType.Datetime).Value = Me.dFechaPresentaPropuesta
        cmdSQL.Parameters.Add("@iCodUsuarioPresentaPropuesta", SqlDbType.Int).Value = Me.iCodUsuarioPresentaPropuesta
        cmdSQL.Parameters.Add("@bIGV", SqlDbType.Bit).Value = Me.bIGV
        cmdSQL.Parameters.Add("@nSubTotal", SqlDbType.Decimal).Value = Me.nSubTotal
        cmdSQL.Parameters.Add("@nIGV", SqlDbType.Decimal).Value = Me.nIGV
        cmdSQL.Parameters.Add("@nTotal", SqlDbType.Decimal).Value = Me.nTotal
        cmdSQL.Parameters.Add("@bAdjudicado", SqlDbType.Bit).Value = Me.bAdjudicado
        cmdSQL.Parameters.Add("@iCodUsuarioAdjudica", SqlDbType.Int).Value = Me.iCodUsuarioAdjudica
        cmdSQL.Parameters.Add("@dFechaAdjudica", SqlDbType.Datetime).Value = Me.dFechaAdjudica
        cmdSQL.Parameters.Add("@cNotasAdjudica", SqlDbType.Varchar, -1).Value = Me.cNotasAdjudica
        cmdSQL.Parameters.Add("@iCodUsuarioObs", SqlDbType.Int).Value = Me.iCodUsuarioObs
        cmdSQL.Parameters.Add("@dFechaObs", SqlDbType.Datetime).Value = Me.dFechaObs
        cmdSQL.Parameters.Add("@cObs", SqlDbType.Varchar, -1).Value = Me.cObs
        cmdSQL.Parameters.Add("@cUrlDocumentosPostor", SqlDbType.Varchar, -1).Value = Me.cUrlDocumentosPostor
        cmdSQL.Parameters.Add("@iCodUsuarioFeedbackContrata", SqlDbType.Int).Value = Me.iCodUsuarioFeedbackContrata
        cmdSQL.Parameters.Add("@dFechaFeedbackContrata", SqlDbType.Datetime).Value = Me.dFechaFeedbackContrata
        cmdSQL.Parameters.Add("@cFeedbackContrata", SqlDbType.Varchar, 100).Value = Me.cFeedbackContrata
        cmdSQL.Parameters.Add("@cFeedbackContrataDetalle", SqlDbType.Varchar, -1).Value = Me.cFeedbackContrataDetalle
        cmdSQL.Parameters.Add("@iCodUsuarioValidaFeedback", SqlDbType.Int).Value = Me.iCodUsuarioValidaFeedback
        cmdSQL.Parameters.Add("@dFechaValidaFeedback", SqlDbType.Datetime).Value = Me.dFechaValidaFeedback
        cmdSQL.Parameters.Add("@cFeedbackCorrecto", SqlDbType.Varchar, 3).Value = Me.cFeedbackCorrecto
        cmdSQL.Parameters.Add("@cTipoValidaFeedback", SqlDbType.Varchar, 2).Value = Me.cTipoValidaFeedback
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
        cmdSQL.CommandText = "DELETE from  prov.RequerimientoCotizacion  WHERE iCodRequerimientoCotizacion=@iCodRequerimientoCotizacion"
        'cmdSQL.CommandText = "UPDATE prov.RequerimientoCotizacion  SET bAnulado=1 WHERE  iCodRequerimientoCotizacion=@iCodRequerimientoCotizacion"
        cmdSQL.Parameters.Add("@iCodRequerimientoCotizacion", SqlDbType.Int).Value = Me.iCodRequerimientoCotizacion
        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub EliminarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "DELETE from  prov.RequerimientoCotizacion  WHERE iCodRequerimientoCotizacion=@iCodRequerimientoCotizacion"
        'cmdSQL.CommandText = "UPDATE prov.RequerimientoCotizacion  SET bAnulado=1 WHERE  iCodRequerimientoCotizacion=@iCodRequerimientoCotizacion"
        cmdSQL.Parameters.Add("@iCodRequerimientoCotizacion", SqlDbType.Int).Value = Me.iCodRequerimientoCotizacion
        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub getRecord()
        Dim readers As IDataReader
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL

        If bTransaccion = True Then cmdSQL.Transaction = Me.mc.miTransact Else 

        cmdSQL.CommandText = "SELECT * FROM prov.RequerimientoCotizacion WHERE iCodRequerimientoCotizacion=@iCodRequerimientoCotizacion"
        cmdSQL.Parameters.Add("@iCodRequerimientoCotizacion", SqlDbType.Int).Value = Me.iCodRequerimientoCotizacion
        readers = cmdSQL.ExecuteReader
        If readers.Read() Then
            Me.iCodRequerimientoCotizacion = CStr(readers.GetValue(0))
            Me.iCodRequerimiento = CStr(readers.GetValue(1))
            Me.iCodContrataLocal = CStr(readers.GetValue(2))
            Me.cCondicion = CStr(readers.GetValue(3))
            Me.cEstado = CStr(readers.GetValue(4))
            Me.iTipoPostulacion = CStr(readers.GetValue(5))
            Me.dFechaPostulacion = CStr(readers.GetValue(6))
            Me.iCodUsuarioPostulacion = CStr(readers.GetValue(7))
            Me.iRanking = CStr(readers.GetValue(8))
            Me.iDiasValidezOferta = CStr(readers.GetValue(9))
            Me.iTiempoEntrega = CStr(readers.GetValue(10))
            Me.cCondicionesPropuesta = CStr(readers.GetValue(11))
            Me.cAnotaciones = CStr(readers.GetValue(12))
            Me.dFechaPresentaPropuesta = CStr(readers.GetValue(13))
            Me.iCodUsuarioPresentaPropuesta = CStr(readers.GetValue(14))
            Me.bIGV = CStr(readers.GetValue(15))
            Me.nSubTotal = CStr(readers.GetValue(16))
            Me.nIGV = CStr(readers.GetValue(17))
            Me.nTotal = CStr(readers.GetValue(18))
            Me.bAdjudicado = CStr(readers.GetValue(19))
            Me.iCodUsuarioAdjudica = CStr(readers.GetValue(20))
            Me.dFechaAdjudica = CStr(readers.GetValue(21))
            Me.cNotasAdjudica = CStr(readers.GetValue(22))
            Me.iCodUsuarioObs = CStr(readers.GetValue(23))
            Me.dFechaObs = CStr(readers.GetValue(24))
            Me.cObs = CStr(readers.GetValue(25))
            Me.cUrlDocumentosPostor = CStr(readers.GetValue(26))
            Me.iCodUsuarioFeedbackContrata = CStr(readers.GetValue(27))
            Me.dFechaFeedbackContrata = CStr(readers.GetValue(28))
            Me.cFeedbackContrata = CStr(readers.GetValue(29))
            Me.cFeedbackContrataDetalle = CStr(readers.GetValue(30))
            Me.iCodUsuarioValidaFeedback = CStr(readers.GetValue(31))
            Me.dFechaValidaFeedback = CStr(readers.GetValue(32))
            Me.cFeedbackCorrecto = CStr(readers.GetValue(33))
            Me.cTipoValidaFeedback = CStr(readers.GetValue(34))
            Me.iCodUsuarioCreacion = CStr(readers.GetValue(35))
            Me.dFechaCreacion = CStr(readers.GetValue(36))
            Me.iCodUsuarioModificacion = CStr(readers.GetValue(37))
            Me.dFechaModificacion = CStr(readers.GetValue(38))
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
	cmdSQL.CommandText = "SELECT * FROM prov.RequerimientoCotizacion"
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
    '1 'OAEL' 
    '2 'SISTEMA' 
    '3 'EXCEPTUADO' 
    '4 'PREFERENCIAL' 
    '5 'SOLICITADO POR EECC' 
    '6 'VIRTUAL APP' 
    '7 'STAKEHOLDER' 
    Public Function ListaTipoPostulacion() As DataTable
        Dim miDataTable As New DataTable
        miDataTable.Columns.Add("ValueMember")
        miDataTable.Columns.Add("DisplayMember")
        With miDataTable
            .Rows.Add("2", "SISTEMA - SUGERIDO POR CONSULTOR")
            '.Rows.Add("4", "PREFERENCIAL - REQ. POR EL POSTULANTE")
            .Rows.Add("5", "SOLICITADO POR EMPRESA CONTRATISTA")
            .Rows.Add("7", "SOLICITADO POR AAQ - STAKEHOLDER")
        End With
        Return miDataTable
    End Function
    Public Function ListaRespuestasFeedback() As DataTable

        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "SELECT cFeedback as ValueMember,cFeedback as DisplayMember FROM prov.TipoFeedback WHERE bAnulado=0"
         Dim readers As SqlDataReader
        readers = cmdSQL.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(readers)
        Return dt
    End Function
    'Public Function ListaRequerimientoCotizacionPostor() As DataTable

    '    Dim cmdSQL As New SqlCommand
    '    cmdSQL.Parameters.Clear()
    '    cmdSQL.Connection = ConnectSQL.linkSQL
    '    cmdSQL.CommandType = CommandType.StoredProcedure
    '    cmdSQL.CommandText = "prov.SP_DT_RequerimientoCotizacionPostor"
    '    cmdSQL.Parameters.Add("@iCodRequerimiento", SqlDbType.Int).Value = Me.iCodRequerimiento


    '    Dim readers As SqlDataReader
    '    readers = cmdSQL.ExecuteReader()
    '    Dim dt As New DataTable
    '    dt.Load(readers)
    '    Return dt
    'End Function
    Public Function ListaCotizacionPostorPorRequerimiento() As DataTable

        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = "prov.SP_DTW_RequerimientoCotizacionPostores"
        cmdSQL.Parameters.Add("@iCodRequerimiento", SqlDbType.Int).Value = Me.iCodRequerimiento


        Dim readers As SqlDataReader
        readers = cmdSQL.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(readers)
        Return dt
    End Function
    Public Function ListaRequerimientoCotizacionAdjudicacion() As DataTable

        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = "prov.SP_DT_RequerimientoCotizacionAdjudica"
        cmdSQL.Parameters.Add("@iCodRequerimiento", SqlDbType.Int).Value = Me.iCodRequerimiento


        Dim readers As SqlDataReader
        readers = cmdSQL.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(readers)
        Return dt
    End Function
    Public Sub PresentaCierraPropuesta()

        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "UPDATE  prov.RequerimientoCotizacion SET cEstado=@cEstado,dFechaPresentaPropuesta=@dFechaPresentaPropuesta,iCodUsuarioPresentaPropuesta=@iCodUsuarioPresentaPropuesta,nSubTotal=@nSubTotal,nIGV=@nIGV,nTotal=@nTotal,iCodUsuarioModificacion=@iCodUsuarioModificacion,dFechaModificacion=@dFechaModificacion WHERE iCodRequerimientoCotizacion=@iCodRequerimientoCotizacion"
        cmdSQL.Parameters.Add("@iCodRequerimientoCotizacion", SqlDbType.Int).Value = Me.iCodRequerimientoCotizacion
        cmdSQL.Parameters.Add("@cEstado", SqlDbType.VarChar, 20).Value = Me.cEstado
        cmdSQL.Parameters.Add("@dFechaPresentaPropuesta", SqlDbType.DateTime).Value = Me.dFechaPresentaPropuesta
        cmdSQL.Parameters.Add("@iCodUsuarioPresentaPropuesta", SqlDbType.Int).Value = Me.iCodUsuarioPresentaPropuesta
        cmdSQL.Parameters.Add("@nSubTotal", SqlDbType.Decimal).Value = Me.nSubTotal
        cmdSQL.Parameters.Add("@nIGV", SqlDbType.Decimal).Value = Me.nIGV
        cmdSQL.Parameters.Add("@nTotal", SqlDbType.Decimal).Value = Me.nTotal
        cmdSQL.Parameters.Add("@iCodUsuarioModificacion", SqlDbType.Int).Value = Me.iCodUsuarioModificacion
        cmdSQL.Parameters.Add("@dFechaModificacion", SqlDbType.DateTime).Value = Me.dFechaModificacion

        cmdSQL.ExecuteNonQuery()
    End Sub

    Public Sub UpdatePropuestaPostor()

        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "UPDATE  prov.RequerimientoCotizacion SET iDiasValidezOferta=@iDiasValidezOferta,iTiempoEntrega=@iTiempoEntrega,cCondicionesPropuesta=@cCondicionesPropuesta,iCodUsuarioModificacion=@iCodUsuarioModificacion,dFechaModificacion=@dFechaModificacion WHERE iCodRequerimientoCotizacion=@iCodRequerimientoCotizacion"
        cmdSQL.Parameters.Add("@iCodRequerimientoCotizacion", SqlDbType.Int).Value = Me.iCodRequerimientoCotizacion
        cmdSQL.Parameters.Add("@iDiasValidezOferta", SqlDbType.TinyInt).Value = Me.iDiasValidezOferta
        cmdSQL.Parameters.Add("@iTiempoEntrega", SqlDbType.TinyInt).Value = Me.iTiempoEntrega
        cmdSQL.Parameters.Add("@cCondicionesPropuesta", SqlDbType.VarChar, -1).Value = Me.cCondicionesPropuesta
        cmdSQL.Parameters.Add("@iCodUsuarioModificacion", SqlDbType.Int).Value = Me.iCodUsuarioModificacion
        cmdSQL.Parameters.Add("@dFechaModificacion", SqlDbType.DateTime).Value = Me.dFechaModificacion

        cmdSQL.ExecuteNonQuery()
    End Sub

    Public Sub UpdateCotizacionAdjudicacion()

        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "UPDATE  prov.RequerimientoCotizacion SET bAdjudicado=@bAdjudicado,iCodUsuarioAdjudica=@iCodUsuarioAdjudica,dFechaAdjudica=@dFechaAdjudica,cNotasAdjudica=@cNotasAdjudica,cEstado=@cEstado,cFeedbackContrata=@cFeedbackContrata WHERE iCodRequerimientoCotizacion=@iCodRequerimientoCotizacion"
        cmdSQL.Parameters.Add("@iCodRequerimientoCotizacion", SqlDbType.Int).Value = Me.iCodRequerimientoCotizacion
        cmdSQL.Parameters.Add("@bAdjudicado", SqlDbType.Bit).Value = Me.bAdjudicado
        cmdSQL.Parameters.Add("@iCodUsuarioAdjudica", SqlDbType.Int).Value = Me.iCodUsuarioAdjudica
        cmdSQL.Parameters.Add("@dFechaAdjudica", SqlDbType.DateTime).Value = Me.dFechaAdjudica
        cmdSQL.Parameters.Add("@cNotasAdjudica", SqlDbType.VarChar, -1).Value = Me.cNotasAdjudica

        cmdSQL.Parameters.Add("@cEstado", SqlDbType.VarChar, 20).Value = Me.cEstado
        cmdSQL.Parameters.Add("@cFeedbackContrata", SqlDbType.VarChar, 100).Value = Me.cFeedbackContrata

        'cmdSQL.Parameters.Add("@iCodUsuarioFeedbackContrata", SqlDbType.Int).Value = Me.iCodUsuarioFeedbackContrata
        'cmdSQL.Parameters.Add("@dFechaFeedbackContrata", SqlDbType.DateTime).Value = Me.dFechaFeedbackContrata
        'cmdSQL.Parameters.Add("@cFeedbackContrataDetalle", SqlDbType.VarChar, -1).Value = Me.cFeedbackContrataDetalle

        cmdSQL.ExecuteNonQuery()
    End Sub

    Public Function UpdateAdjudicarRequerimientoAPostor() As Integer

        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = "prov.SP_UPD_AdjudicarRequerimientoAPostor"
        cmdSQL.Parameters.Add("@iCodRequerimientoCotizacion", SqlDbType.Int).Value = Me.iCodRequerimientoCotizacion
        cmdSQL.Parameters.Add("@iCodRequerimiento", SqlDbType.Int).Value = Me.iCodRequerimiento
        cmdSQL.Parameters.Add("@dFechaAdjudica", SqlDbType.DateTime).Value = Me.dFechaAdjudica
        cmdSQL.Parameters.Add("@iCodUsuarioAdjudica", SqlDbType.Int).Value = Me.iCodUsuarioAdjudica
        cmdSQL.Parameters.Add("@cNotasAdjudica", SqlDbType.VarChar, -1).Value = Me.cNotasAdjudica

        Return CInt(cmdSQL.ExecuteScalar())
    End Function

    Public Sub UpdateCotizacionFeedbackContrata()

        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "UPDATE  prov.RequerimientoCotizacion SET iCodUsuarioFeedbackContrata=@iCodUsuarioFeedbackContrata,dFechaFeedbackContrata=@dFechaFeedbackContrata,cFeedbackContrataDetalle=@cFeedbackContrataDetalle WHERE iCodRequerimientoCotizacion=@iCodRequerimientoCotizacion"
        cmdSQL.Parameters.Add("@iCodRequerimientoCotizacion", SqlDbType.Int).Value = Me.iCodRequerimientoCotizacion
 
        cmdSQL.Parameters.Add("@iCodUsuarioFeedbackContrata", SqlDbType.Int).Value = Me.iCodUsuarioFeedbackContrata
        cmdSQL.Parameters.Add("@dFechaFeedbackContrata", SqlDbType.DateTime).Value = Me.dFechaFeedbackContrata
        cmdSQL.Parameters.Add("@cFeedbackContrataDetalle", SqlDbType.VarChar, -1).Value = Me.cFeedbackContrataDetalle

        cmdSQL.ExecuteNonQuery()
    End Sub
End Class
