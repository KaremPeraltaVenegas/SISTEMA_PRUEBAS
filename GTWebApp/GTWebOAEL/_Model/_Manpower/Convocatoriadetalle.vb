Imports System.Data.SqlClient
Public Class Convocatoriadetalle
    Public iCodConvocatoriaDetalle As String
    Public iCodConvocatoria As String
    Public iCodCandidatoInforme As String
    Public iTipoPostulacion As String
    Public dFechaMintra As String
    Public dFechaLiberadoExceptuado As String
    Public iRanking As String
    Public dFechaPropuesta As String
    Public cObsConsultor As String
    Public dFechaCargaCV As String
    Public dFechaContactoContrata1 As String
    Public dFechaRptaConformidad As String
    Public cSeleccionado As String
    Public cRptaContrata As String
    Public cRptaConformidad As String
    Public dFechaVerificaFeedback As String
    Public cFeedbackCorrecto As String
    Public cEstado As String
    Public cObs As String
    Public bCumplePerfil As String
    Public iCodUsuarioFeedback As String
    Public cTipoValidaFeedback As String
    Public iCodUsuarioRptaContrata As String
    Public dFechaRptaContrata As String
    Public iCodUsuario As String
    Public dFechaSis As String
    Public qSelect As String
    Public cTipoOpe As Char
    Public bTransaccion As Boolean = False
    Public mc As New ConnectSQL
    Public Function ListaDatos() As DataTable
        Dim Query As String
        Dim readers As DataTable
        Query = "SELECT * FROM dbo.ConvocatoriaDetalle"
        readers = mc.ExecuteDataTable(Query)
        Return readers
    End Function
    Public Sub Insertar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "INSERT into dbo.ConvocatoriaDetalle (iCodConvocatoria,iCodCandidatoInforme,iTipoPostulacion,dFechaMintra,dFechaLiberadoExceptuado,iRanking,dFechaPropuesta,cObsConsultor,dFechaCargaCV,dFechaContactoContrata1,dFechaRptaConformidad,cSeleccionado,cRptaContrata,cRptaConformidad,dFechaVerificaFeedback,cFeedbackCorrecto,cEstado,cObs,bCumplePerfil,iCodUsuarioFeedback,cTipoValidaFeedback,iCodUsuarioRptaContrata,dFechaRptaContrata,iCodUsuario,dFechaSis ) VALUES(@iCodConvocatoria,@iCodCandidatoInforme,@iTipoPostulacion,@dFechaMintra,@dFechaLiberadoExceptuado,@iRanking,@dFechaPropuesta,@cObsConsultor,@dFechaCargaCV,@dFechaContactoContrata1,@dFechaRptaConformidad,@cSeleccionado,@cRptaContrata,@cRptaConformidad,@dFechaVerificaFeedback,@cFeedbackCorrecto,@cEstado,@cObs,@bCumplePerfil,@iCodUsuarioFeedback,@cTipoValidaFeedback,@iCodUsuarioRptaContrata,@dFechaRptaContrata,@iCodUsuario,@dFechaSis); SELECT SCOPE_IDENTITY(); "
        cmdSQL.Parameters.Add("@iCodConvocatoria", SqlDbType.Int).Value = Me.iCodConvocatoria
        cmdSQL.Parameters.Add("@iCodCandidatoInforme", SqlDbType.Int).Value = Me.iCodCandidatoInforme
        cmdSQL.Parameters.Add("@iTipoPostulacion", SqlDbType.Tinyint).Value = Me.iTipoPostulacion
        cmdSQL.Parameters.Add("@dFechaMintra", SqlDbType.Datetime).Value = Me.dFechaMintra
        cmdSQL.Parameters.Add("@dFechaLiberadoExceptuado", SqlDbType.Date).Value = Me.dFechaLiberadoExceptuado
        cmdSQL.Parameters.Add("@iRanking", SqlDbType.Tinyint).Value = Me.iRanking
        cmdSQL.Parameters.Add("@dFechaPropuesta", SqlDbType.Datetime).Value = Me.dFechaPropuesta
        cmdSQL.Parameters.Add("@cObsConsultor", SqlDbType.Varchar, 500).Value = Me.cObsConsultor
        cmdSQL.Parameters.Add("@dFechaCargaCV", SqlDbType.Date).Value = Me.dFechaCargaCV
        cmdSQL.Parameters.Add("@dFechaContactoContrata1", SqlDbType.Date).Value = Me.dFechaContactoContrata1
        cmdSQL.Parameters.Add("@dFechaRptaConformidad", SqlDbType.Datetime).Value = Me.dFechaRptaConformidad
        cmdSQL.Parameters.Add("@cSeleccionado", SqlDbType.Varchar, 3).Value = Me.cSeleccionado
        cmdSQL.Parameters.Add("@cRptaContrata", SqlDbType.Varchar, 100).Value = Me.cRptaContrata
        cmdSQL.Parameters.Add("@cRptaConformidad", SqlDbType.Varchar, 50).Value = Me.cRptaConformidad
        cmdSQL.Parameters.Add("@dFechaVerificaFeedback", SqlDbType.Datetime).Value = Me.dFechaVerificaFeedback
        cmdSQL.Parameters.Add("@cFeedbackCorrecto", SqlDbType.Varchar, 3).Value = Me.cFeedbackCorrecto
        cmdSQL.Parameters.Add("@cEstado", SqlDbType.Varchar, 15).Value = Me.cEstado
        cmdSQL.Parameters.Add("@cObs", SqlDbType.Varchar, 1250).Value = Me.cObs
        cmdSQL.Parameters.Add("@bCumplePerfil", SqlDbType.Bit).Value = Me.bCumplePerfil
        cmdSQL.Parameters.Add("@iCodUsuarioFeedback", SqlDbType.Int).Value = Me.iCodUsuarioFeedback
        cmdSQL.Parameters.Add("@cTipoValidaFeedback", SqlDbType.Varchar, 2).Value = Me.cTipoValidaFeedback
        cmdSQL.Parameters.Add("@iCodUsuarioRptaContrata", SqlDbType.Int).Value = Me.iCodUsuarioRptaContrata
        cmdSQL.Parameters.Add("@dFechaRptaContrata", SqlDbType.Datetime).Value = Me.dFechaRptaContrata
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.Datetime).Value = Me.dFechaSis

        Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
        If pCodInsert > 0 Then
            Me.iCodConvocatoriaDetalle = pCodInsert
        Else
            Me.iCodConvocatoriaDetalle = 0
        End If
    End Sub
    Public Sub InsertarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "INSERT into dbo.ConvocatoriaDetalle (iCodConvocatoria,iCodCandidatoInforme,iTipoPostulacion,dFechaMintra,dFechaLiberadoExceptuado,iRanking,dFechaPropuesta,cObsConsultor,dFechaCargaCV,dFechaContactoContrata1,dFechaRptaConformidad,cSeleccionado,cRptaContrata,cRptaConformidad,dFechaVerificaFeedback,cFeedbackCorrecto,cEstado,cObs,bCumplePerfil,iCodUsuarioFeedback,cTipoValidaFeedback,iCodUsuarioRptaContrata,dFechaRptaContrata,iCodUsuario,dFechaSis ) VALUES(@iCodConvocatoria,@iCodCandidatoInforme,@iTipoPostulacion,@dFechaMintra,@dFechaLiberadoExceptuado,@iRanking,@dFechaPropuesta,@cObsConsultor,@dFechaCargaCV,@dFechaContactoContrata1,@dFechaRptaConformidad,@cSeleccionado,@cRptaContrata,@cRptaConformidad,@dFechaVerificaFeedback,@cFeedbackCorrecto,@cEstado,@cObs,@bCumplePerfil,@iCodUsuarioFeedback,@cTipoValidaFeedback,@iCodUsuarioRptaContrata,@dFechaRptaContrata,@iCodUsuario,@dFechaSis); SELECT SCOPE_IDENTITY(); "
        cmdSQL.Parameters.Add("@iCodConvocatoria", SqlDbType.Int).Value = Me.iCodConvocatoria
        cmdSQL.Parameters.Add("@iCodCandidatoInforme", SqlDbType.Int).Value = Me.iCodCandidatoInforme
        cmdSQL.Parameters.Add("@iTipoPostulacion", SqlDbType.Tinyint).Value = Me.iTipoPostulacion
        cmdSQL.Parameters.Add("@dFechaMintra", SqlDbType.Datetime).Value = Me.dFechaMintra
        cmdSQL.Parameters.Add("@dFechaLiberadoExceptuado", SqlDbType.Date).Value = Me.dFechaLiberadoExceptuado
        cmdSQL.Parameters.Add("@iRanking", SqlDbType.Tinyint).Value = Me.iRanking
        cmdSQL.Parameters.Add("@dFechaPropuesta", SqlDbType.Datetime).Value = Me.dFechaPropuesta
        cmdSQL.Parameters.Add("@cObsConsultor", SqlDbType.Varchar, 500).Value = Me.cObsConsultor
        cmdSQL.Parameters.Add("@dFechaCargaCV", SqlDbType.Date).Value = Me.dFechaCargaCV
        cmdSQL.Parameters.Add("@dFechaContactoContrata1", SqlDbType.Date).Value = Me.dFechaContactoContrata1
        cmdSQL.Parameters.Add("@dFechaRptaConformidad", SqlDbType.Datetime).Value = Me.dFechaRptaConformidad
        cmdSQL.Parameters.Add("@cSeleccionado", SqlDbType.Varchar, 3).Value = Me.cSeleccionado
        cmdSQL.Parameters.Add("@cRptaContrata", SqlDbType.Varchar, 100).Value = Me.cRptaContrata
        cmdSQL.Parameters.Add("@cRptaConformidad", SqlDbType.Varchar, 50).Value = Me.cRptaConformidad
        cmdSQL.Parameters.Add("@dFechaVerificaFeedback", SqlDbType.Datetime).Value = Me.dFechaVerificaFeedback
        cmdSQL.Parameters.Add("@cFeedbackCorrecto", SqlDbType.Varchar, 3).Value = Me.cFeedbackCorrecto
        cmdSQL.Parameters.Add("@cEstado", SqlDbType.Varchar, 15).Value = Me.cEstado
        cmdSQL.Parameters.Add("@cObs", SqlDbType.Varchar, 1250).Value = Me.cObs
        cmdSQL.Parameters.Add("@bCumplePerfil", SqlDbType.Bit).Value = Me.bCumplePerfil
        cmdSQL.Parameters.Add("@iCodUsuarioFeedback", SqlDbType.Int).Value = Me.iCodUsuarioFeedback
        cmdSQL.Parameters.Add("@cTipoValidaFeedback", SqlDbType.Varchar, 2).Value = Me.cTipoValidaFeedback
        cmdSQL.Parameters.Add("@iCodUsuarioRptaContrata", SqlDbType.Int).Value = Me.iCodUsuarioRptaContrata
        cmdSQL.Parameters.Add("@dFechaRptaContrata", SqlDbType.Datetime).Value = Me.dFechaRptaContrata
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.Datetime).Value = Me.dFechaSis

        Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
        If pCodInsert > 0 Then
            Me.iCodConvocatoriaDetalle = pCodInsert
        Else
            Me.iCodConvocatoriaDetalle = 0
        End If
    End Sub
    Public Sub Modificar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "UPDATE  dbo.ConvocatoriaDetalle SET iCodConvocatoria=@iCodConvocatoria,iCodCandidatoInforme=@iCodCandidatoInforme,iTipoPostulacion=@iTipoPostulacion,dFechaMintra=@dFechaMintra,dFechaLiberadoExceptuado=@dFechaLiberadoExceptuado,iRanking=@iRanking,dFechaPropuesta=@dFechaPropuesta,cObsConsultor=@cObsConsultor,dFechaCargaCV=@dFechaCargaCV,dFechaContactoContrata1=@dFechaContactoContrata1,dFechaRptaConformidad=@dFechaRptaConformidad,cSeleccionado=@cSeleccionado,cRptaContrata=@cRptaContrata,cRptaConformidad=@cRptaConformidad,dFechaVerificaFeedback=@dFechaVerificaFeedback,cFeedbackCorrecto=@cFeedbackCorrecto,cEstado=@cEstado,cObs=@cObs,bCumplePerfil=@bCumplePerfil,iCodUsuarioFeedback=@iCodUsuarioFeedback,cTipoValidaFeedback=@cTipoValidaFeedback,iCodUsuarioRptaContrata=@iCodUsuarioRptaContrata,dFechaRptaContrata=@dFechaRptaContrata,iCodUsuario=@iCodUsuario,dFechaSis=@dFechaSis WHERE iCodConvocatoriaDetalle=@iCodConvocatoriaDetalle"
        cmdSQL.Parameters.Add("@iCodConvocatoriaDetalle", SqlDbType.Int).Value = Me.iCodConvocatoriaDetalle
        cmdSQL.Parameters.Add("@iCodConvocatoria", SqlDbType.Int).Value = Me.iCodConvocatoria
        cmdSQL.Parameters.Add("@iCodCandidatoInforme", SqlDbType.Int).Value = Me.iCodCandidatoInforme
        cmdSQL.Parameters.Add("@iTipoPostulacion", SqlDbType.Tinyint).Value = Me.iTipoPostulacion
        cmdSQL.Parameters.Add("@dFechaMintra", SqlDbType.Datetime).Value = Me.dFechaMintra
        cmdSQL.Parameters.Add("@dFechaLiberadoExceptuado", SqlDbType.Date).Value = Me.dFechaLiberadoExceptuado
        cmdSQL.Parameters.Add("@iRanking", SqlDbType.Tinyint).Value = Me.iRanking
        cmdSQL.Parameters.Add("@dFechaPropuesta", SqlDbType.Datetime).Value = Me.dFechaPropuesta
        cmdSQL.Parameters.Add("@cObsConsultor", SqlDbType.Varchar, 500).Value = Me.cObsConsultor
        cmdSQL.Parameters.Add("@dFechaCargaCV", SqlDbType.Date).Value = Me.dFechaCargaCV
        cmdSQL.Parameters.Add("@dFechaContactoContrata1", SqlDbType.Date).Value = Me.dFechaContactoContrata1
        cmdSQL.Parameters.Add("@dFechaRptaConformidad", SqlDbType.Datetime).Value = Me.dFechaRptaConformidad
        cmdSQL.Parameters.Add("@cSeleccionado", SqlDbType.Varchar, 3).Value = Me.cSeleccionado
        cmdSQL.Parameters.Add("@cRptaContrata", SqlDbType.Varchar, 100).Value = Me.cRptaContrata
        cmdSQL.Parameters.Add("@cRptaConformidad", SqlDbType.Varchar, 50).Value = Me.cRptaConformidad
        cmdSQL.Parameters.Add("@dFechaVerificaFeedback", SqlDbType.Datetime).Value = Me.dFechaVerificaFeedback
        cmdSQL.Parameters.Add("@cFeedbackCorrecto", SqlDbType.Varchar, 3).Value = Me.cFeedbackCorrecto
        cmdSQL.Parameters.Add("@cEstado", SqlDbType.Varchar, 15).Value = Me.cEstado
        cmdSQL.Parameters.Add("@cObs", SqlDbType.Varchar, 1250).Value = Me.cObs
        cmdSQL.Parameters.Add("@bCumplePerfil", SqlDbType.Bit).Value = Me.bCumplePerfil
        cmdSQL.Parameters.Add("@iCodUsuarioFeedback", SqlDbType.Int).Value = Me.iCodUsuarioFeedback
        cmdSQL.Parameters.Add("@cTipoValidaFeedback", SqlDbType.Varchar, 2).Value = Me.cTipoValidaFeedback
        cmdSQL.Parameters.Add("@iCodUsuarioRptaContrata", SqlDbType.Int).Value = Me.iCodUsuarioRptaContrata
        cmdSQL.Parameters.Add("@dFechaRptaContrata", SqlDbType.Datetime).Value = Me.dFechaRptaContrata
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.Datetime).Value = Me.dFechaSis

        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub ModificarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "UPDATE  dbo.ConvocatoriaDetalle SET iCodConvocatoria=@iCodConvocatoria,iCodCandidatoInforme=@iCodCandidatoInforme,iTipoPostulacion=@iTipoPostulacion,dFechaMintra=@dFechaMintra,dFechaLiberadoExceptuado=@dFechaLiberadoExceptuado,iRanking=@iRanking,dFechaPropuesta=@dFechaPropuesta,cObsConsultor=@cObsConsultor,dFechaCargaCV=@dFechaCargaCV,dFechaContactoContrata1=@dFechaContactoContrata1,dFechaRptaConformidad=@dFechaRptaConformidad,cSeleccionado=@cSeleccionado,cRptaContrata=@cRptaContrata,cRptaConformidad=@cRptaConformidad,dFechaVerificaFeedback=@dFechaVerificaFeedback,cFeedbackCorrecto=@cFeedbackCorrecto,cEstado=@cEstado,cObs=@cObs,bCumplePerfil=@bCumplePerfil,iCodUsuarioFeedback=@iCodUsuarioFeedback,cTipoValidaFeedback=@cTipoValidaFeedback,iCodUsuarioRptaContrata=@iCodUsuarioRptaContrata,dFechaRptaContrata=@dFechaRptaContrata,iCodUsuario=@iCodUsuario,dFechaSis=@dFechaSis WHERE iCodConvocatoriaDetalle=@iCodConvocatoriaDetalle"
        cmdSQL.Parameters.Add("@iCodConvocatoriaDetalle", SqlDbType.Int).Value = Me.iCodConvocatoriaDetalle
        cmdSQL.Parameters.Add("@iCodConvocatoria", SqlDbType.Int).Value = Me.iCodConvocatoria
        cmdSQL.Parameters.Add("@iCodCandidatoInforme", SqlDbType.Int).Value = Me.iCodCandidatoInforme
        cmdSQL.Parameters.Add("@iTipoPostulacion", SqlDbType.Tinyint).Value = Me.iTipoPostulacion
        cmdSQL.Parameters.Add("@dFechaMintra", SqlDbType.Datetime).Value = Me.dFechaMintra
        cmdSQL.Parameters.Add("@dFechaLiberadoExceptuado", SqlDbType.Date).Value = Me.dFechaLiberadoExceptuado
        cmdSQL.Parameters.Add("@iRanking", SqlDbType.Tinyint).Value = Me.iRanking
        cmdSQL.Parameters.Add("@dFechaPropuesta", SqlDbType.Datetime).Value = Me.dFechaPropuesta
        cmdSQL.Parameters.Add("@cObsConsultor", SqlDbType.Varchar, 500).Value = Me.cObsConsultor
        cmdSQL.Parameters.Add("@dFechaCargaCV", SqlDbType.Date).Value = Me.dFechaCargaCV
        cmdSQL.Parameters.Add("@dFechaContactoContrata1", SqlDbType.Date).Value = Me.dFechaContactoContrata1
        cmdSQL.Parameters.Add("@dFechaRptaConformidad", SqlDbType.Datetime).Value = Me.dFechaRptaConformidad
        cmdSQL.Parameters.Add("@cSeleccionado", SqlDbType.Varchar, 3).Value = Me.cSeleccionado
        cmdSQL.Parameters.Add("@cRptaContrata", SqlDbType.Varchar, 100).Value = Me.cRptaContrata
        cmdSQL.Parameters.Add("@cRptaConformidad", SqlDbType.Varchar, 50).Value = Me.cRptaConformidad
        cmdSQL.Parameters.Add("@dFechaVerificaFeedback", SqlDbType.Datetime).Value = Me.dFechaVerificaFeedback
        cmdSQL.Parameters.Add("@cFeedbackCorrecto", SqlDbType.Varchar, 3).Value = Me.cFeedbackCorrecto
        cmdSQL.Parameters.Add("@cEstado", SqlDbType.Varchar, 15).Value = Me.cEstado
        cmdSQL.Parameters.Add("@cObs", SqlDbType.Varchar, 1250).Value = Me.cObs
        cmdSQL.Parameters.Add("@bCumplePerfil", SqlDbType.Bit).Value = Me.bCumplePerfil
        cmdSQL.Parameters.Add("@iCodUsuarioFeedback", SqlDbType.Int).Value = Me.iCodUsuarioFeedback
        cmdSQL.Parameters.Add("@cTipoValidaFeedback", SqlDbType.Varchar, 2).Value = Me.cTipoValidaFeedback
        cmdSQL.Parameters.Add("@iCodUsuarioRptaContrata", SqlDbType.Int).Value = Me.iCodUsuarioRptaContrata
        cmdSQL.Parameters.Add("@dFechaRptaContrata", SqlDbType.Datetime).Value = Me.dFechaRptaContrata
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.Datetime).Value = Me.dFechaSis

        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub Eliminar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "DELETE from  dbo.ConvocatoriaDetalle  WHERE iCodConvocatoriaDetalle=@iCodConvocatoriaDetalle"
        'cmdSQL.CommandText = "UPDATE dbo.ConvocatoriaDetalle  SET bAnulado=1 WHERE  iCodConvocatoriaDetalle=@iCodConvocatoriaDetalle"
        cmdSQL.Parameters.Add("@iCodConvocatoriaDetalle", SqlDbType.Int).Value = Me.iCodConvocatoriaDetalle
        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub EliminarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "DELETE from  dbo.ConvocatoriaDetalle  WHERE iCodConvocatoriaDetalle=@iCodConvocatoriaDetalle"
        'cmdSQL.CommandText = "UPDATE dbo.ConvocatoriaDetalle  SET bAnulado=1 WHERE  iCodConvocatoriaDetalle=@iCodConvocatoriaDetalle"
        cmdSQL.Parameters.Add("@iCodConvocatoriaDetalle", SqlDbType.Int).Value = Me.iCodConvocatoriaDetalle
        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub getRecord()
        Dim readers As IDataReader
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL

        If bTransaccion = True Then cmdSQL.Transaction = Me.mc.miTransact Else 

        cmdSQL.CommandText = "SELECT * FROM dbo.ConvocatoriaDetalle WHERE iCodConvocatoriaDetalle=@iCodConvocatoriaDetalle"
        cmdSQL.Parameters.Add("@iCodConvocatoriaDetalle", SqlDbType.Int).Value = Me.iCodConvocatoriaDetalle
        readers = cmdSQL.ExecuteReader
        If readers.Read() Then
            Me.iCodConvocatoriaDetalle = CStr(readers.GetValue(0))
            Me.iCodConvocatoria = CStr(readers.GetValue(1))
            Me.iCodCandidatoInforme = CStr(readers.GetValue(2))
            Me.iTipoPostulacion = CStr(readers.GetValue(3))
            Me.dFechaMintra = CStr(readers.GetValue(4))
            Me.dFechaLiberadoExceptuado = CStr(readers.GetValue(5))
            Me.iRanking = CStr(readers.GetValue(6))
            Me.dFechaPropuesta = CStr(readers.GetValue(7))
            Me.cObsConsultor = CStr(readers.GetValue(8))
            Me.dFechaCargaCV = CStr(readers.GetValue(9))
            Me.dFechaContactoContrata1 = CStr(readers.GetValue(10))
            Me.dFechaRptaConformidad = CStr(readers.GetValue(11))
            Me.cSeleccionado = CStr(readers.GetValue(12))
            Me.cRptaContrata = CStr(readers.GetValue(13))
            Me.cRptaConformidad = CStr(readers.GetValue(14))
            Me.dFechaVerificaFeedback = CStr(readers.GetValue(15))
            Me.cFeedbackCorrecto = CStr(readers.GetValue(16))
            Me.cEstado = CStr(readers.GetValue(17))
            Me.cObs = CStr(readers.GetValue(18))
            Me.bCumplePerfil = CStr(readers.GetValue(19))
            Me.iCodUsuarioFeedback = CStr(readers.GetValue(20))
            Me.cTipoValidaFeedback = CStr(readers.GetValue(21))
            Me.iCodUsuarioRptaContrata = CStr(readers.GetValue(22))
            Me.dFechaRptaContrata = CStr(readers.GetValue(23))
            Me.iCodUsuario = CStr(readers.GetValue(24))
            Me.dFechaSis = CStr(readers.GetValue(25))
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
        cmdSQL.CommandText = "SELECT * FROM dbo.ConvocatoriaDetalle"
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


    '************************************


    Public pCodConvocatoriaMain As String
    Public pTipoProcesoFeedback As String
    Public Function ListaRespuestasFeedback() As DataTable
        Dim Query As String
        Dim pTabla As String = "ConvocatoriaDetalle"
        Dim pNombreGrupo As String = "RespuestaFeedback"
        Dim readers As DataTable
        Query = " select cValueMember as ValueMember,cDisplayMember as DisplayMember From TDCatalogo where " & _
            " cTabla='" & Trim(pTabla) & "'  and cNombreGrupo='" & Trim(pNombreGrupo) & "' and cValor='S' order by iOrden asc "
        'InputBox("", "", Query)
        readers = mc.ExecuteDataTable(Query)
        Return readers
    End Function

    Public Sub UpdateFeedback()

        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "UPDATE dbo.ConvocatoriaDetalle  SET dFechaContactoContrata1=GETDATE(),cSeleccionado=@cSeleccionado,cRptaContrata=@cRptaContrata,cObs=@cObs,iCodUsuarioRptaContrata=@iCodUsuarioRptaContrata,dFechaRptaContrata=@dFechaRptaContrata   WHERE iCodConvocatoriaDetalle=@iCodConvocatoriaDetalle"
        'cmdSQL.CommandText = "UPDATE dbo.ConvocatoriaDetalle  SET bAnulado=1 WHERE  iCodConvocatoriaDetalle=@iCodConvocatoriaDetalle"
        cmdSQL.Parameters.Add("@iCodConvocatoriaDetalle", SqlDbType.Int).Value = Me.iCodConvocatoriaDetalle
        'cmdSQL.Parameters.Add("@dFechaContactoContrata1", SqlDbType.Date).Value = Me.dFechaContactoContrata1
         cmdSQL.Parameters.Add("@cSeleccionado", SqlDbType.VarChar, 3).Value = Me.cSeleccionado
        cmdSQL.Parameters.Add("@cRptaContrata", SqlDbType.VarChar, 100).Value = Me.cRptaContrata
        cmdSQL.Parameters.Add("@cObs", SqlDbType.VarChar, 1250).Value = Me.cObs
        cmdSQL.Parameters.Add("@iCodUsuarioRptaContrata", SqlDbType.Int).Value = Me.iCodUsuarioRptaContrata
        cmdSQL.Parameters.Add("@dFechaRptaContrata", SqlDbType.DateTime).Value = Me.dFechaRptaContrata
        cmdSQL.ExecuteNonQuery()


    End Sub

    Public Function GetRecordFeedback() As DataTable
 
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = "SP_ROW_FeedbackPersona"
        cmdSQL.Parameters.Add("@iCodConvocatoriaDetalle", SqlDbType.Int).Value = Me.iCodConvocatoriaDetalle

        Dim readers As SqlDataReader
        readers = cmdSQL.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(readers)
        Return dt

    End Function

    Public Sub UpdateFeedbackNoCumplePerfil()

        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = "SP_UPD_ConvocatoriaDetalleFeedback"
        cmdSQL.Parameters.Add("@iCodConvocatoriaMain", SqlDbType.Int).Value = Me.pCodConvocatoriaMain
        cmdSQL.Parameters.Add("@cTipoProcesoFeedback", SqlDbType.VarChar, 10).Value = Me.pTipoProcesoFeedback
        cmdSQL.ExecuteNonQuery()
    End Sub

    Public Sub UpdateFeedbackMasivo()

        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = "SP_UPD_ConvocatoriaDetalleFeedbackMasivo"
        cmdSQL.Parameters.Add("@iCodConvocatoria", SqlDbType.Int).Value = Me.iCodConvocatoria
        cmdSQL.Parameters.Add("@iCodUsuarioRptaContrata", SqlDbType.Int).Value = Me.iCodUsuarioRptaContrata
        cmdSQL.Parameters.Add("@cTipoProcesoFeedback", SqlDbType.VarChar, 4).Value = Me.pTipoProcesoFeedback
        cmdSQL.ExecuteNonQuery()
    End Sub

    Public Function ListaConvocatoriaPosicionesResumenFeedback() As DataTable

        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = "SP_DTW_ConvocatoriaResumenPosicionFeedback"
        cmdSQL.Parameters.Add("@iCodConvocatoriaMain", SqlDbType.Int).Value = Me.pCodConvocatoriaMain

        Dim readers As SqlDataReader
        readers = cmdSQL.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(readers)
        Return dt

    End Function

    Public Sub SetEstadoProceso()
        Select Case Me.iTipoPostulacion

            Case 1   'GRTPE
                Me.cEstado = "D"

            Case 2   'SISTEMA
                Me.cEstado = "E"
                Me.dFechaCargaCV = "1900-01-01"
            Case 3   'EXCEPTUADO
                Me.cEstado = "D"

            Case 4   'PREFERENCIAL
                Me.cEstado = "D"

            Case 5  'SOLICITADO
                Me.cEstado = "D"
                'Me.dFechaCargaCV = "1900-01-01"
            Case 6   'VIRTUAL APP
                Me.cEstado = "D"

            Case 7   'STAKEHOLDER
                Me.cEstado = "E"
                Me.dFechaCargaCV = "1900-01-01"
            Case 8   'PROPUESTO ATM
                Me.cEstado = "D"

            Case Else ' OTRAS OPCIONES POR DEFECTO ESTAN DISPONIBLE
                Me.cEstado = "D"

        End Select
    End Sub
End Class
