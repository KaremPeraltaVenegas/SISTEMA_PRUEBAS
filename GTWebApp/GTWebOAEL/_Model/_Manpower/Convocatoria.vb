Imports System.Data.SqlClient
Public Class Convocatoria
Public iCodConvocatoria As String
Public iCodConvocatoriaMain As String
Public IDREQ As String
Public COD_DETALLE As String
Public cMOCMONC As String
Public cPerfil As String
Public cDesPerfil As String
Public iCantidad As String
Public iEstado As String
Public bLiberado As String
Public iLiberado As String
Public bCoberturado As String
Public iExceptuado As String
Public dFechaLiberaExceptua As String
Public cObs As String
Public bSituacion As String
Public cAreaPerfil As String
Public iTiempoExpRequerida As String
Public iTiempoExpDeseable As String
Public cCategoriaRCC As String
Public cOcupacionRCC As String
Public cEspecialidadRCC As String
Public cTipoPerfil As String
Public cRegimenLaboral As String
Public cConocimiento As String
Public cEspecializacion As String
Public iTotal As String
Public bResolicitado As String
Public iTipoObra As String
Public cFrenteLugarTrabajo As String
Public dFechaEstimadaIngreso As String
Public iPeriodoContrataMeses As String
Public iCodOcupacion As String
Public cFuncionesPuesto As String
Public iEscalaRemunerativa As String
Public cOtrosBeneficios As String
Public iEdadMinimaRequerida As String
Public iEdadMaximaRequerida As String
Public cExperiencia As String
Public cCompetencias As String
Public cGenero As String
    Public iGradoInstruccion As String
    Public iCodUsuarioAprobador As String
    Public dFechaAprobacion As String
    Public cNotasAprobador As String

    Public cUrlExterna As String
    Public iBandaSalarialMin As String
    Public iBandaSalarialMax As String

    Public iCodUsuario As String
    Public dFechaSis As String
    Public iCodUsuarioModificacion As String
    Public dFechaModificacion As String
    Public qSelect As String
    Public cTipoOpe As Char
    Public bTransaccion As Boolean = False
    Public mc As New ConnectSQL
    Public Function ListaDatos() As DataTable
        Dim Query As String
        Dim readers As DataTable
        Query = "SELECT * FROM dbo.Convocatoria"
        readers = mc.ExecuteDataTable(Query)
        Return readers
    End Function
    Public Sub Insertar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "INSERT into dbo.Convocatoria (iCodConvocatoriaMain,IDREQ,COD_DETALLE,cMOCMONC,cPerfil,cDesPerfil,iCantidad,iEstado,bLiberado,iLiberado,bCoberturado,iExceptuado,dFechaLiberaExceptua,cObs,bSituacion,cAreaPerfil,iTiempoExpRequerida,iTiempoExpDeseable,cCategoriaRCC,cOcupacionRCC,cEspecialidadRCC,cTipoPerfil,cRegimenLaboral,cConocimiento,cEspecializacion,iTotal,bResolicitado,iTipoObra,cFrenteLugarTrabajo,dFechaEstimadaIngreso,iPeriodoContrataMeses,iCodOcupacion,cFuncionesPuesto,iEscalaRemunerativa,cOtrosBeneficios,iEdadMinimaRequerida,iEdadMaximaRequerida,cExperiencia,cCompetencias,cGenero,iGradoInstruccion,iCodUsuarioAprobador,dFechaAprobacion,cNotasAprobador,cUrlExterna,iBandaSalarialMin,iBandaSalarialMax,iCodUsuario,dFechaSis,iCodUsuarioModificacion,dFechaModificacion ) VALUES(@iCodConvocatoriaMain,@IDREQ,@COD_DETALLE,@cMOCMONC,@cPerfil,@cDesPerfil,@iCantidad,@iEstado,@bLiberado,@iLiberado,@bCoberturado,@iExceptuado,@dFechaLiberaExceptua,@cObs,@bSituacion,@cAreaPerfil,@iTiempoExpRequerida,@iTiempoExpDeseable,@cCategoriaRCC,@cOcupacionRCC,@cEspecialidadRCC,@cTipoPerfil,@cRegimenLaboral,@cConocimiento,@cEspecializacion,@iTotal,@bResolicitado,@iTipoObra,@cFrenteLugarTrabajo,@dFechaEstimadaIngreso,@iPeriodoContrataMeses,@iCodOcupacion,@cFuncionesPuesto,@iEscalaRemunerativa,@cOtrosBeneficios,@iEdadMinimaRequerida,@iEdadMaximaRequerida,@cExperiencia,@cCompetencias,@cGenero,@iGradoInstruccion,@iCodUsuarioAprobador,@dFechaAprobacion,@cNotasAprobador,@cUrlExterna,@iBandaSalarialMin,@iBandaSalarialMax,@iCodUsuario,@dFechaSis,@iCodUsuarioModificacion,@dFechaModificacion); SELECT SCOPE_IDENTITY(); "
        cmdSQL.Parameters.Add("@iCodConvocatoriaMain", SqlDbType.Int).Value = Me.iCodConvocatoriaMain
        cmdSQL.Parameters.Add("@IDREQ", SqlDbType.Float).Value = Me.IDREQ
        cmdSQL.Parameters.Add("@COD_DETALLE", SqlDbType.Float).Value = Me.COD_DETALLE
        cmdSQL.Parameters.Add("@cMOCMONC", SqlDbType.VarChar, 10).Value = Me.cMOCMONC
        cmdSQL.Parameters.Add("@cPerfil", SqlDbType.VarChar, 120).Value = Me.cPerfil
        cmdSQL.Parameters.Add("@cDesPerfil", SqlDbType.VarChar, -1).Value = Me.cDesPerfil
        cmdSQL.Parameters.Add("@iCantidad", SqlDbType.SmallInt).Value = Me.iCantidad
        cmdSQL.Parameters.Add("@iEstado", SqlDbType.SmallInt).Value = Me.iEstado
        cmdSQL.Parameters.Add("@bLiberado", SqlDbType.Bit).Value = Me.bLiberado
        cmdSQL.Parameters.Add("@iLiberado", SqlDbType.SmallInt).Value = Me.iLiberado
        cmdSQL.Parameters.Add("@bCoberturado", SqlDbType.Bit).Value = Me.bCoberturado
        cmdSQL.Parameters.Add("@iExceptuado", SqlDbType.SmallInt).Value = Me.iExceptuado
        cmdSQL.Parameters.Add("@dFechaLiberaExceptua", SqlDbType.Date).Value = Me.dFechaLiberaExceptua
        cmdSQL.Parameters.Add("@cObs", SqlDbType.VarChar, 250).Value = Me.cObs
        cmdSQL.Parameters.Add("@bSituacion", SqlDbType.Bit).Value = Me.bSituacion
        cmdSQL.Parameters.Add("@cAreaPerfil", SqlDbType.VarChar, 15).Value = Me.cAreaPerfil
        cmdSQL.Parameters.Add("@iTiempoExpRequerida", SqlDbType.TinyInt).Value = Me.iTiempoExpRequerida
        cmdSQL.Parameters.Add("@iTiempoExpDeseable", SqlDbType.TinyInt).Value = Me.iTiempoExpDeseable
        cmdSQL.Parameters.Add("@cCategoriaRCC", SqlDbType.VarChar, 50).Value = Me.cCategoriaRCC
        cmdSQL.Parameters.Add("@cOcupacionRCC", SqlDbType.VarChar, 50).Value = Me.cOcupacionRCC
        cmdSQL.Parameters.Add("@cEspecialidadRCC", SqlDbType.VarChar, 50).Value = Me.cEspecialidadRCC
        cmdSQL.Parameters.Add("@cTipoPerfil", SqlDbType.VarChar, 15).Value = Me.cTipoPerfil
        cmdSQL.Parameters.Add("@cRegimenLaboral", SqlDbType.VarChar, 50).Value = Me.cRegimenLaboral
        cmdSQL.Parameters.Add("@cConocimiento", SqlDbType.VarChar, 100).Value = Me.cConocimiento
        cmdSQL.Parameters.Add("@cEspecializacion", SqlDbType.VarChar, 80).Value = Me.cEspecializacion
        cmdSQL.Parameters.Add("@iTotal", SqlDbType.SmallInt).Value = Me.iTotal
        cmdSQL.Parameters.Add("@bResolicitado", SqlDbType.Bit).Value = Me.bResolicitado

        If Me.iTipoObra = "NULL" Then
            cmdSQL.Parameters.Add("@iTipoObra", SqlDbType.Int).Value = DBNull.Value
        Else
            cmdSQL.Parameters.Add("@iTipoObra", SqlDbType.TinyInt).Value = CInt(Me.iTipoObra)
        End If



        cmdSQL.Parameters.Add("@cFrenteLugarTrabajo", SqlDbType.VarChar, -1).Value = Me.cFrenteLugarTrabajo

        If Me.dFechaEstimadaIngreso = "NULL" Then
            cmdSQL.Parameters.Add("@dFechaEstimadaIngreso", SqlDbType.DateTime).Value = DBNull.Value
        Else
            cmdSQL.Parameters.Add("@dFechaEstimadaIngreso", SqlDbType.DateTime).Value = Me.dFechaEstimadaIngreso
        End If

        cmdSQL.Parameters.Add("@iPeriodoContrataMeses", SqlDbType.TinyInt).Value = Me.iPeriodoContrataMeses
        cmdSQL.Parameters.Add("@iCodOcupacion", SqlDbType.Int).Value = Me.iCodOcupacion
        cmdSQL.Parameters.Add("@cFuncionesPuesto", SqlDbType.VarChar, -1).Value = Me.cFuncionesPuesto
        cmdSQL.Parameters.Add("@iEscalaRemunerativa", SqlDbType.TinyInt).Value = Me.iEscalaRemunerativa
        cmdSQL.Parameters.Add("@cOtrosBeneficios", SqlDbType.VarChar, -1).Value = Me.cOtrosBeneficios
        cmdSQL.Parameters.Add("@iEdadMinimaRequerida", SqlDbType.TinyInt).Value = Me.iEdadMinimaRequerida
        cmdSQL.Parameters.Add("@iEdadMaximaRequerida", SqlDbType.TinyInt).Value = Me.iEdadMaximaRequerida
        cmdSQL.Parameters.Add("@cExperiencia", SqlDbType.NVarChar, -1).Value = Me.cExperiencia
        cmdSQL.Parameters.Add("@cCompetencias", SqlDbType.VarChar, -1).Value = Me.cCompetencias
        cmdSQL.Parameters.Add("@cGenero", SqlDbType.Char, 1).Value = Me.cGenero
        cmdSQL.Parameters.Add("@iGradoInstruccion", SqlDbType.TinyInt).Value = Me.iGradoInstruccion

        If Me.iCodUsuarioAprobador = "NULL" Then
            cmdSQL.Parameters.Add("@iCodUsuarioAprobador", SqlDbType.Int).Value = DBNull.Value
        Else

            cmdSQL.Parameters.Add("@iCodUsuarioAprobador", SqlDbType.Int).Value = CInt(Me.iCodUsuarioAprobador)
        End If

        If Me.dFechaAprobacion = "NULL" Then
            cmdSQL.Parameters.Add("@dFechaAprobacion", SqlDbType.DateTime).Value = DBNull.Value
        Else
            cmdSQL.Parameters.Add("@dFechaAprobacion", SqlDbType.DateTime).Value = CDate(Me.dFechaAprobacion)
        End If
        cmdSQL.Parameters.Add("@cNotasAprobador", SqlDbType.VarChar, -1).Value = Me.cNotasAprobador

        cmdSQL.Parameters.Add("@cUrlExterna", SqlDbType.VarChar, -1).Value = Me.cUrlExterna
        cmdSQL.Parameters.Add("@iBandaSalarialMin", SqlDbType.SmallInt).Value = Me.iBandaSalarialMin
        cmdSQL.Parameters.Add("@iBandaSalarialMax", SqlDbType.SmallInt).Value = Me.iBandaSalarialMax

        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.DateTime).Value = Me.dFechaSis

        If Me.iCodUsuarioModificacion = "NULL" Then
            cmdSQL.Parameters.Add("@iCodUsuarioModificacion", SqlDbType.Int).Value = DBNull.Value
        Else
            cmdSQL.Parameters.Add("@iCodUsuarioModificacion", SqlDbType.Int).Value = CInt(Me.iCodUsuarioModificacion)
        End If

        If Me.dFechaModificacion = "NULL" Then
            cmdSQL.Parameters.Add("@dFechaModificacion", SqlDbType.DateTime).Value = DBNull.Value
        Else
            cmdSQL.Parameters.Add("@dFechaModificacion", SqlDbType.DateTime).Value = CDate(Me.dFechaModificacion)
        End If

        Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
        If pCodInsert > 0 Then
            Me.iCodConvocatoria = pCodInsert
        Else
            Me.iCodConvocatoria = 0
        End If
    End Sub
    Public Sub InsertarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "INSERT into dbo.Convocatoria (iCodConvocatoriaMain,IDREQ,COD_DETALLE,cMOCMONC,cPerfil,cDesPerfil,iCantidad,iEstado,bLiberado,iLiberado,bCoberturado,iExceptuado,dFechaLiberaExceptua,cObs,bSituacion,cAreaPerfil,iTiempoExpRequerida,iTiempoExpDeseable,cCategoriaRCC,cOcupacionRCC,cEspecialidadRCC,cTipoPerfil,cRegimenLaboral,cConocimiento,cEspecializacion,iTotal,bResolicitado,iTipoObra,cFrenteLugarTrabajo,dFechaEstimadaIngreso,iPeriodoContrataMeses,iCodOcupacion,cFuncionesPuesto,iEscalaRemunerativa,cOtrosBeneficios,iEdadMinimaRequerida,iEdadMaximaRequerida,cExperiencia,cCompetencias,cGenero,iGradoInstruccion,iCodUsuarioAprobador,dFechaAprobacion,cNotasAprobador,cUrlExterna,iBandaSalarialMin,iBandaSalarialMax,iCodUsuario,dFechaSis,iCodUsuarioModificacion,dFechaModificacion ) VALUES(@iCodConvocatoriaMain,@IDREQ,@COD_DETALLE,@cMOCMONC,@cPerfil,@cDesPerfil,@iCantidad,@iEstado,@bLiberado,@iLiberado,@bCoberturado,@iExceptuado,@dFechaLiberaExceptua,@cObs,@bSituacion,@cAreaPerfil,@iTiempoExpRequerida,@iTiempoExpDeseable,@cCategoriaRCC,@cOcupacionRCC,@cEspecialidadRCC,@cTipoPerfil,@cRegimenLaboral,@cConocimiento,@cEspecializacion,@iTotal,@bResolicitado,@iTipoObra,@cFrenteLugarTrabajo,@dFechaEstimadaIngreso,@iPeriodoContrataMeses,@iCodOcupacion,@cFuncionesPuesto,@iEscalaRemunerativa,@cOtrosBeneficios,@iEdadMinimaRequerida,@iEdadMaximaRequerida,@cExperiencia,@cCompetencias,@cGenero,@iGradoInstruccion,@iCodUsuarioAprobador,@dFechaAprobacion,@cNotasAprobador,@cUrlExterna,@iBandaSalarialMin,@iBandaSalarialMax,@iCodUsuario,@dFechaSis,@iCodUsuarioModificacion,@dFechaModificacion); SELECT SCOPE_IDENTITY(); "
        cmdSQL.Parameters.Add("@iCodConvocatoriaMain", SqlDbType.Int).Value = Me.iCodConvocatoriaMain
        cmdSQL.Parameters.Add("@IDREQ", SqlDbType.Float).Value = Me.IDREQ
        cmdSQL.Parameters.Add("@COD_DETALLE", SqlDbType.Float).Value = Me.COD_DETALLE
        cmdSQL.Parameters.Add("@cMOCMONC", SqlDbType.VarChar, 10).Value = Me.cMOCMONC
        cmdSQL.Parameters.Add("@cPerfil", SqlDbType.VarChar, 120).Value = Me.cPerfil
        cmdSQL.Parameters.Add("@cDesPerfil", SqlDbType.VarChar, -1).Value = Me.cDesPerfil
        cmdSQL.Parameters.Add("@iCantidad", SqlDbType.SmallInt).Value = Me.iCantidad
        cmdSQL.Parameters.Add("@iEstado", SqlDbType.SmallInt).Value = Me.iEstado
        cmdSQL.Parameters.Add("@bLiberado", SqlDbType.Bit).Value = Me.bLiberado
        cmdSQL.Parameters.Add("@iLiberado", SqlDbType.SmallInt).Value = Me.iLiberado
        cmdSQL.Parameters.Add("@bCoberturado", SqlDbType.Bit).Value = Me.bCoberturado
        cmdSQL.Parameters.Add("@iExceptuado", SqlDbType.SmallInt).Value = Me.iExceptuado
        cmdSQL.Parameters.Add("@dFechaLiberaExceptua", SqlDbType.Date).Value = Me.dFechaLiberaExceptua
        cmdSQL.Parameters.Add("@cObs", SqlDbType.VarChar, 250).Value = Me.cObs
        cmdSQL.Parameters.Add("@bSituacion", SqlDbType.Bit).Value = Me.bSituacion
        cmdSQL.Parameters.Add("@cAreaPerfil", SqlDbType.VarChar, 15).Value = Me.cAreaPerfil
        cmdSQL.Parameters.Add("@iTiempoExpRequerida", SqlDbType.TinyInt).Value = Me.iTiempoExpRequerida
        cmdSQL.Parameters.Add("@iTiempoExpDeseable", SqlDbType.TinyInt).Value = Me.iTiempoExpDeseable
        cmdSQL.Parameters.Add("@cCategoriaRCC", SqlDbType.VarChar, 50).Value = Me.cCategoriaRCC
        cmdSQL.Parameters.Add("@cOcupacionRCC", SqlDbType.VarChar, 50).Value = Me.cOcupacionRCC
        cmdSQL.Parameters.Add("@cEspecialidadRCC", SqlDbType.VarChar, 50).Value = Me.cEspecialidadRCC
        cmdSQL.Parameters.Add("@cTipoPerfil", SqlDbType.VarChar, 15).Value = Me.cTipoPerfil
        cmdSQL.Parameters.Add("@cRegimenLaboral", SqlDbType.VarChar, 50).Value = Me.cRegimenLaboral
        cmdSQL.Parameters.Add("@cConocimiento", SqlDbType.VarChar, 100).Value = Me.cConocimiento
        cmdSQL.Parameters.Add("@cEspecializacion", SqlDbType.VarChar, 80).Value = Me.cEspecializacion
        cmdSQL.Parameters.Add("@iTotal", SqlDbType.SmallInt).Value = Me.iTotal
        cmdSQL.Parameters.Add("@bResolicitado", SqlDbType.Bit).Value = Me.bResolicitado

        If Me.iTipoObra = "NULL" Then
            cmdSQL.Parameters.Add("@iTipoObra", SqlDbType.Int).Value = DBNull.Value
        Else
            cmdSQL.Parameters.Add("@iTipoObra", SqlDbType.TinyInt).Value = CInt(Me.iTipoObra)
        End If



        cmdSQL.Parameters.Add("@cFrenteLugarTrabajo", SqlDbType.VarChar, -1).Value = Me.cFrenteLugarTrabajo

        If Me.dFechaEstimadaIngreso = "NULL" Then
            cmdSQL.Parameters.Add("@dFechaEstimadaIngreso", SqlDbType.DateTime).Value = DBNull.Value
        Else
            cmdSQL.Parameters.Add("@dFechaEstimadaIngreso", SqlDbType.DateTime).Value = Me.dFechaEstimadaIngreso
        End If

        cmdSQL.Parameters.Add("@iPeriodoContrataMeses", SqlDbType.TinyInt).Value = Me.iPeriodoContrataMeses
        cmdSQL.Parameters.Add("@iCodOcupacion", SqlDbType.Int).Value = Me.iCodOcupacion
        cmdSQL.Parameters.Add("@cFuncionesPuesto", SqlDbType.VarChar, -1).Value = Me.cFuncionesPuesto
        cmdSQL.Parameters.Add("@iEscalaRemunerativa", SqlDbType.TinyInt).Value = Me.iEscalaRemunerativa
        cmdSQL.Parameters.Add("@cOtrosBeneficios", SqlDbType.VarChar, -1).Value = Me.cOtrosBeneficios
        cmdSQL.Parameters.Add("@iEdadMinimaRequerida", SqlDbType.TinyInt).Value = Me.iEdadMinimaRequerida
        cmdSQL.Parameters.Add("@iEdadMaximaRequerida", SqlDbType.TinyInt).Value = Me.iEdadMaximaRequerida
        cmdSQL.Parameters.Add("@cExperiencia", SqlDbType.NVarChar, -1).Value = Me.cExperiencia
        cmdSQL.Parameters.Add("@cCompetencias", SqlDbType.VarChar, -1).Value = Me.cCompetencias
        cmdSQL.Parameters.Add("@cGenero", SqlDbType.Char, 1).Value = Me.cGenero
        cmdSQL.Parameters.Add("@iGradoInstruccion", SqlDbType.TinyInt).Value = Me.iGradoInstruccion

        If Me.iCodUsuarioAprobador = "NULL" Then
            cmdSQL.Parameters.Add("@iCodUsuarioAprobador", SqlDbType.Int).Value = DBNull.Value
        Else

            cmdSQL.Parameters.Add("@iCodUsuarioAprobador", SqlDbType.Int).Value = CInt(Me.iCodUsuarioAprobador)
        End If

        If Me.dFechaAprobacion = "NULL" Then
            cmdSQL.Parameters.Add("@dFechaAprobacion", SqlDbType.DateTime).Value = DBNull.Value
        Else
            cmdSQL.Parameters.Add("@dFechaAprobacion", SqlDbType.DateTime).Value = CDate(Me.dFechaAprobacion)
        End If
        cmdSQL.Parameters.Add("@cNotasAprobador", SqlDbType.VarChar, -1).Value = Me.cNotasAprobador

        cmdSQL.Parameters.Add("@cUrlExterna", SqlDbType.VarChar, -1).Value = Me.cUrlExterna
        cmdSQL.Parameters.Add("@iBandaSalarialMin", SqlDbType.SmallInt).Value = Me.iBandaSalarialMin
        cmdSQL.Parameters.Add("@iBandaSalarialMax", SqlDbType.SmallInt).Value = Me.iBandaSalarialMax

        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.DateTime).Value = Me.dFechaSis

        If Me.iCodUsuarioModificacion = "NULL" Then
            cmdSQL.Parameters.Add("@iCodUsuarioModificacion", SqlDbType.Int).Value = DBNull.Value
        Else
            cmdSQL.Parameters.Add("@iCodUsuarioModificacion", SqlDbType.Int).Value = CInt(Me.iCodUsuarioModificacion)
        End If

        If Me.dFechaModificacion = "NULL" Then
            cmdSQL.Parameters.Add("@dFechaModificacion", SqlDbType.DateTime).Value = DBNull.Value
        Else
            cmdSQL.Parameters.Add("@dFechaModificacion", SqlDbType.DateTime).Value = CDate(Me.dFechaModificacion)
        End If

        Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
        If pCodInsert > 0 Then
            Me.iCodConvocatoria = pCodInsert
        Else
            Me.iCodConvocatoria = 0
        End If
    End Sub
    Public Sub Modificar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "UPDATE  dbo.Convocatoria SET iCodConvocatoriaMain=@iCodConvocatoriaMain,IDREQ=@IDREQ,COD_DETALLE=@COD_DETALLE,cMOCMONC=@cMOCMONC,cPerfil=@cPerfil,cDesPerfil=@cDesPerfil,iCantidad=@iCantidad,iEstado=@iEstado,bLiberado=@bLiberado,iLiberado=@iLiberado,bCoberturado=@bCoberturado,iExceptuado=@iExceptuado,dFechaLiberaExceptua=@dFechaLiberaExceptua,cObs=@cObs,bSituacion=@bSituacion,cAreaPerfil=@cAreaPerfil,iTiempoExpRequerida=@iTiempoExpRequerida,iTiempoExpDeseable=@iTiempoExpDeseable,cCategoriaRCC=@cCategoriaRCC,cOcupacionRCC=@cOcupacionRCC,cEspecialidadRCC=@cEspecialidadRCC,cTipoPerfil=@cTipoPerfil,cRegimenLaboral=@cRegimenLaboral,cConocimiento=@cConocimiento,cEspecializacion=@cEspecializacion,iTotal=@iTotal,bResolicitado=@bResolicitado,iTipoObra=@iTipoObra,cFrenteLugarTrabajo=@cFrenteLugarTrabajo,dFechaEstimadaIngreso=@dFechaEstimadaIngreso,iPeriodoContrataMeses=@iPeriodoContrataMeses,iCodOcupacion=@iCodOcupacion,cFuncionesPuesto=@cFuncionesPuesto,iEscalaRemunerativa=@iEscalaRemunerativa,cOtrosBeneficios=@cOtrosBeneficios,iEdadMinimaRequerida=@iEdadMinimaRequerida,iEdadMaximaRequerida=@iEdadMaximaRequerida,cExperiencia=@cExperiencia,cCompetencias=@cCompetencias,cGenero=@cGenero,iGradoInstruccion=@iGradoInstruccion,iCodUsuarioAprobador=@iCodUsuarioAprobador,dFechaAprobacion=@dFechaAprobacion,cNotasAprobador=@cNotasAprobador,cUrlExterna=@cUrlExterna,iBandaSalarialMin=@iBandaSalarialMin,iBandaSalarialMax=@iBandaSalarialMax,iCodUsuario=@iCodUsuario,dFechaSis=@dFechaSis,iCodUsuarioModificacion=@iCodUsuarioModificacion,dFechaModificacion=@dFechaModificacion WHERE iCodConvocatoria=@iCodConvocatoria"
        cmdSQL.Parameters.Add("@iCodConvocatoria", SqlDbType.Int).Value = Me.iCodConvocatoria
        cmdSQL.Parameters.Add("@iCodConvocatoriaMain", SqlDbType.Int).Value = Me.iCodConvocatoriaMain
        cmdSQL.Parameters.Add("@IDREQ", SqlDbType.Float).Value = Me.IDREQ
        cmdSQL.Parameters.Add("@COD_DETALLE", SqlDbType.Float).Value = Me.COD_DETALLE
        cmdSQL.Parameters.Add("@cMOCMONC", SqlDbType.VarChar, 5).Value = Me.cMOCMONC
        cmdSQL.Parameters.Add("@cPerfil", SqlDbType.VarChar, 120).Value = Me.cPerfil
        cmdSQL.Parameters.Add("@cDesPerfil", SqlDbType.VarChar, -1).Value = Me.cDesPerfil
        cmdSQL.Parameters.Add("@iCantidad", SqlDbType.SmallInt).Value = Me.iCantidad
        cmdSQL.Parameters.Add("@iEstado", SqlDbType.SmallInt).Value = Me.iEstado
        cmdSQL.Parameters.Add("@bLiberado", SqlDbType.Bit).Value = Me.bLiberado
        cmdSQL.Parameters.Add("@iLiberado", SqlDbType.SmallInt).Value = Me.iLiberado
        cmdSQL.Parameters.Add("@bCoberturado", SqlDbType.Bit).Value = Me.bCoberturado
        cmdSQL.Parameters.Add("@iExceptuado", SqlDbType.SmallInt).Value = Me.iExceptuado
        cmdSQL.Parameters.Add("@dFechaLiberaExceptua", SqlDbType.Date).Value = Me.dFechaLiberaExceptua
        cmdSQL.Parameters.Add("@cObs", SqlDbType.VarChar, 250).Value = Me.cObs
        cmdSQL.Parameters.Add("@bSituacion", SqlDbType.Bit).Value = Me.bSituacion
        cmdSQL.Parameters.Add("@cAreaPerfil", SqlDbType.VarChar, 15).Value = Me.cAreaPerfil
        cmdSQL.Parameters.Add("@iTiempoExpRequerida", SqlDbType.TinyInt).Value = Me.iTiempoExpRequerida
        cmdSQL.Parameters.Add("@iTiempoExpDeseable", SqlDbType.TinyInt).Value = Me.iTiempoExpDeseable
        cmdSQL.Parameters.Add("@cCategoriaRCC", SqlDbType.VarChar, 50).Value = Me.cCategoriaRCC
        cmdSQL.Parameters.Add("@cOcupacionRCC", SqlDbType.VarChar, 50).Value = Me.cOcupacionRCC
        cmdSQL.Parameters.Add("@cEspecialidadRCC", SqlDbType.VarChar, 50).Value = Me.cEspecialidadRCC
        cmdSQL.Parameters.Add("@cTipoPerfil", SqlDbType.VarChar, 15).Value = Me.cTipoPerfil
        cmdSQL.Parameters.Add("@cRegimenLaboral", SqlDbType.VarChar, 50).Value = Me.cRegimenLaboral
        cmdSQL.Parameters.Add("@cConocimiento", SqlDbType.VarChar, 100).Value = Me.cConocimiento
        cmdSQL.Parameters.Add("@cEspecializacion", SqlDbType.VarChar, 80).Value = Me.cEspecializacion
        cmdSQL.Parameters.Add("@iTotal", SqlDbType.SmallInt).Value = Me.iTotal
        cmdSQL.Parameters.Add("@bResolicitado", SqlDbType.Bit).Value = Me.bResolicitado
        If Me.iTipoObra = "NULL" Then
            cmdSQL.Parameters.Add("@iTipoObra", SqlDbType.Int).Value = DBNull.Value
        Else
            cmdSQL.Parameters.Add("@iTipoObra", SqlDbType.TinyInt).Value = CInt(Me.iTipoObra)
        End If
        cmdSQL.Parameters.Add("@cFrenteLugarTrabajo", SqlDbType.Varchar, -1).Value = Me.cFrenteLugarTrabajo

        If Me.dFechaEstimadaIngreso = "NULL" Then
            cmdSQL.Parameters.Add("@dFechaEstimadaIngreso", SqlDbType.DateTime).Value = DBNull.Value
        Else
            cmdSQL.Parameters.Add("@dFechaEstimadaIngreso", SqlDbType.DateTime).Value = Me.dFechaEstimadaIngreso
        End If
        cmdSQL.Parameters.Add("@iPeriodoContrataMeses", SqlDbType.Tinyint).Value = Me.iPeriodoContrataMeses
        cmdSQL.Parameters.Add("@iCodOcupacion", SqlDbType.Int).Value = Me.iCodOcupacion
        cmdSQL.Parameters.Add("@cFuncionesPuesto", SqlDbType.VarChar, -1).Value = Me.cFuncionesPuesto
        cmdSQL.Parameters.Add("@iEscalaRemunerativa", SqlDbType.TinyInt).Value = Me.iEscalaRemunerativa
        cmdSQL.Parameters.Add("@cOtrosBeneficios", SqlDbType.VarChar, -1).Value = Me.cOtrosBeneficios
        cmdSQL.Parameters.Add("@iEdadMinimaRequerida", SqlDbType.TinyInt).Value = Me.iEdadMinimaRequerida
        cmdSQL.Parameters.Add("@iEdadMaximaRequerida", SqlDbType.TinyInt).Value = Me.iEdadMaximaRequerida
        cmdSQL.Parameters.Add("@cExperiencia", SqlDbType.NVarChar, -1).Value = Me.cExperiencia
        cmdSQL.Parameters.Add("@cCompetencias", SqlDbType.VarChar, -1).Value = Me.cCompetencias
        cmdSQL.Parameters.Add("@cGenero", SqlDbType.Char, 1).Value = Me.cGenero
        cmdSQL.Parameters.Add("@iGradoInstruccion", SqlDbType.TinyInt).Value = Me.iGradoInstruccion

        If Me.iCodUsuarioAprobador = "NULL" Then
            cmdSQL.Parameters.Add("@iCodUsuarioAprobador", SqlDbType.Int).Value = DBNull.Value
        Else

            cmdSQL.Parameters.Add("@iCodUsuarioAprobador", SqlDbType.Int).Value = CInt(Me.iCodUsuarioAprobador)
        End If

        If Me.dFechaAprobacion = "NULL" Then
            cmdSQL.Parameters.Add("@dFechaAprobacion", SqlDbType.DateTime).Value = DBNull.Value
        Else
            cmdSQL.Parameters.Add("@dFechaAprobacion", SqlDbType.DateTime).Value = CDate(Me.dFechaAprobacion)
        End If

        cmdSQL.Parameters.Add("@cNotasAprobador", SqlDbType.VarChar, -1).Value = Me.cNotasAprobador

        cmdSQL.Parameters.Add("@cUrlExterna", SqlDbType.VarChar, -1).Value = Me.cUrlExterna
        cmdSQL.Parameters.Add("@iBandaSalarialMin", SqlDbType.SmallInt).Value = Me.iBandaSalarialMin
        cmdSQL.Parameters.Add("@iBandaSalarialMax", SqlDbType.SmallInt).Value = Me.iBandaSalarialMax

        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.DateTime).Value = Me.dFechaSis

        If Me.iCodUsuarioModificacion = "NULL" Then
            cmdSQL.Parameters.Add("@iCodUsuarioModificacion", SqlDbType.Int).Value = DBNull.Value
        Else
            cmdSQL.Parameters.Add("@iCodUsuarioModificacion", SqlDbType.Int).Value = CInt(Me.iCodUsuarioModificacion)
        End If

        If Me.dFechaModificacion = "NULL" Then
            cmdSQL.Parameters.Add("@dFechaModificacion", SqlDbType.DateTime).Value = DBNull.Value
        Else
            cmdSQL.Parameters.Add("@dFechaModificacion", SqlDbType.DateTime).Value = CDate(Me.dFechaModificacion)
        End If

        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub ModificarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "UPDATE  dbo.Convocatoria SET iCodConvocatoriaMain=@iCodConvocatoriaMain,IDREQ=@IDREQ,COD_DETALLE=@COD_DETALLE,cMOCMONC=@cMOCMONC,cPerfil=@cPerfil,cDesPerfil=@cDesPerfil,iCantidad=@iCantidad,iEstado=@iEstado,bLiberado=@bLiberado,iLiberado=@iLiberado,bCoberturado=@bCoberturado,iExceptuado=@iExceptuado,dFechaLiberaExceptua=@dFechaLiberaExceptua,cObs=@cObs,bSituacion=@bSituacion,cAreaPerfil=@cAreaPerfil,iTiempoExpRequerida=@iTiempoExpRequerida,iTiempoExpDeseable=@iTiempoExpDeseable,cCategoriaRCC=@cCategoriaRCC,cOcupacionRCC=@cOcupacionRCC,cEspecialidadRCC=@cEspecialidadRCC,cTipoPerfil=@cTipoPerfil,cRegimenLaboral=@cRegimenLaboral,cConocimiento=@cConocimiento,cEspecializacion=@cEspecializacion,iTotal=@iTotal,bResolicitado=@bResolicitado,iTipoObra=@iTipoObra,cFrenteLugarTrabajo=@cFrenteLugarTrabajo,dFechaEstimadaIngreso=@dFechaEstimadaIngreso,iPeriodoContrataMeses=@iPeriodoContrataMeses,iCodOcupacion=@iCodOcupacion,cFuncionesPuesto=@cFuncionesPuesto,iEscalaRemunerativa=@iEscalaRemunerativa,cOtrosBeneficios=@cOtrosBeneficios,iEdadMinimaRequerida=@iEdadMinimaRequerida,iEdadMaximaRequerida=@iEdadMaximaRequerida,cExperiencia=@cExperiencia,cCompetencias=@cCompetencias,cGenero=@cGenero,iGradoInstruccion=@iGradoInstruccion,iCodUsuarioAprobador=@iCodUsuarioAprobador,dFechaAprobacion=@dFechaAprobacion,cNotasAprobador=@cNotasAprobador,cUrlExterna=@cUrlExterna,iBandaSalarialMin=@iBandaSalarialMin,iBandaSalarialMax=@iBandaSalarialMax,iCodUsuario=@iCodUsuario,dFechaSis=@dFechaSis,iCodUsuarioModificacion=@iCodUsuarioModificacion,dFechaModificacion=@dFechaModificacion WHERE iCodConvocatoria=@iCodConvocatoria"
        cmdSQL.Parameters.Add("@iCodConvocatoria", SqlDbType.Int).Value = Me.iCodConvocatoria
        cmdSQL.Parameters.Add("@iCodConvocatoriaMain", SqlDbType.Int).Value = Me.iCodConvocatoriaMain
        cmdSQL.Parameters.Add("@IDREQ", SqlDbType.Float).Value = Me.IDREQ
        cmdSQL.Parameters.Add("@COD_DETALLE", SqlDbType.Float).Value = Me.COD_DETALLE
        cmdSQL.Parameters.Add("@cMOCMONC", SqlDbType.VarChar, 5).Value = Me.cMOCMONC
        cmdSQL.Parameters.Add("@cPerfil", SqlDbType.VarChar, 120).Value = Me.cPerfil
        cmdSQL.Parameters.Add("@cDesPerfil", SqlDbType.VarChar, -1).Value = Me.cDesPerfil
        cmdSQL.Parameters.Add("@iCantidad", SqlDbType.SmallInt).Value = Me.iCantidad
        cmdSQL.Parameters.Add("@iEstado", SqlDbType.SmallInt).Value = Me.iEstado
        cmdSQL.Parameters.Add("@bLiberado", SqlDbType.Bit).Value = Me.bLiberado
        cmdSQL.Parameters.Add("@iLiberado", SqlDbType.SmallInt).Value = Me.iLiberado
        cmdSQL.Parameters.Add("@bCoberturado", SqlDbType.Bit).Value = Me.bCoberturado
        cmdSQL.Parameters.Add("@iExceptuado", SqlDbType.SmallInt).Value = Me.iExceptuado
        cmdSQL.Parameters.Add("@dFechaLiberaExceptua", SqlDbType.Date).Value = Me.dFechaLiberaExceptua
        cmdSQL.Parameters.Add("@cObs", SqlDbType.VarChar, 250).Value = Me.cObs
        cmdSQL.Parameters.Add("@bSituacion", SqlDbType.Bit).Value = Me.bSituacion
        cmdSQL.Parameters.Add("@cAreaPerfil", SqlDbType.VarChar, 15).Value = Me.cAreaPerfil
        cmdSQL.Parameters.Add("@iTiempoExpRequerida", SqlDbType.TinyInt).Value = Me.iTiempoExpRequerida
        cmdSQL.Parameters.Add("@iTiempoExpDeseable", SqlDbType.TinyInt).Value = Me.iTiempoExpDeseable
        cmdSQL.Parameters.Add("@cCategoriaRCC", SqlDbType.VarChar, 50).Value = Me.cCategoriaRCC
        cmdSQL.Parameters.Add("@cOcupacionRCC", SqlDbType.VarChar, 50).Value = Me.cOcupacionRCC
        cmdSQL.Parameters.Add("@cEspecialidadRCC", SqlDbType.VarChar, 50).Value = Me.cEspecialidadRCC
        cmdSQL.Parameters.Add("@cTipoPerfil", SqlDbType.VarChar, 15).Value = Me.cTipoPerfil
        cmdSQL.Parameters.Add("@cRegimenLaboral", SqlDbType.VarChar, 50).Value = Me.cRegimenLaboral
        cmdSQL.Parameters.Add("@cConocimiento", SqlDbType.VarChar, 100).Value = Me.cConocimiento
        cmdSQL.Parameters.Add("@cEspecializacion", SqlDbType.VarChar, 80).Value = Me.cEspecializacion
        cmdSQL.Parameters.Add("@iTotal", SqlDbType.SmallInt).Value = Me.iTotal
        cmdSQL.Parameters.Add("@bResolicitado", SqlDbType.Bit).Value = Me.bResolicitado
        If Me.iTipoObra = "NULL" Then
            cmdSQL.Parameters.Add("@iTipoObra", SqlDbType.Int).Value = DBNull.Value
        Else
            cmdSQL.Parameters.Add("@iTipoObra", SqlDbType.TinyInt).Value = CInt(Me.iTipoObra)
        End If
        cmdSQL.Parameters.Add("@cFrenteLugarTrabajo", SqlDbType.VarChar, -1).Value = Me.cFrenteLugarTrabajo

        If Me.dFechaEstimadaIngreso = "NULL" Then
            cmdSQL.Parameters.Add("@dFechaEstimadaIngreso", SqlDbType.DateTime).Value = DBNull.Value
        Else
            cmdSQL.Parameters.Add("@dFechaEstimadaIngreso", SqlDbType.DateTime).Value = Me.dFechaEstimadaIngreso
        End If
        cmdSQL.Parameters.Add("@iPeriodoContrataMeses", SqlDbType.TinyInt).Value = Me.iPeriodoContrataMeses
        cmdSQL.Parameters.Add("@iCodOcupacion", SqlDbType.Int).Value = Me.iCodOcupacion
        cmdSQL.Parameters.Add("@cFuncionesPuesto", SqlDbType.VarChar, -1).Value = Me.cFuncionesPuesto
        cmdSQL.Parameters.Add("@iEscalaRemunerativa", SqlDbType.TinyInt).Value = Me.iEscalaRemunerativa
        cmdSQL.Parameters.Add("@cOtrosBeneficios", SqlDbType.VarChar, -1).Value = Me.cOtrosBeneficios
        cmdSQL.Parameters.Add("@iEdadMinimaRequerida", SqlDbType.TinyInt).Value = Me.iEdadMinimaRequerida
        cmdSQL.Parameters.Add("@iEdadMaximaRequerida", SqlDbType.TinyInt).Value = Me.iEdadMaximaRequerida
        cmdSQL.Parameters.Add("@cExperiencia", SqlDbType.NVarChar, -1).Value = Me.cExperiencia
        cmdSQL.Parameters.Add("@cCompetencias", SqlDbType.VarChar, -1).Value = Me.cCompetencias
        cmdSQL.Parameters.Add("@cGenero", SqlDbType.Char, 1).Value = Me.cGenero
        cmdSQL.Parameters.Add("@iGradoInstruccion", SqlDbType.TinyInt).Value = Me.iGradoInstruccion

        If Me.iCodUsuarioAprobador = "NULL" Then
            cmdSQL.Parameters.Add("@iCodUsuarioAprobador", SqlDbType.Int).Value = DBNull.Value
        Else

            cmdSQL.Parameters.Add("@iCodUsuarioAprobador", SqlDbType.Int).Value = CInt(Me.iCodUsuarioAprobador)
        End If

        If Me.dFechaAprobacion = "NULL" Then
            cmdSQL.Parameters.Add("@dFechaAprobacion", SqlDbType.DateTime).Value = DBNull.Value
        Else
            cmdSQL.Parameters.Add("@dFechaAprobacion", SqlDbType.DateTime).Value = CDate(Me.dFechaAprobacion)
        End If

        cmdSQL.Parameters.Add("@cNotasAprobador", SqlDbType.VarChar, -1).Value = Me.cNotasAprobador

        cmdSQL.Parameters.Add("@cUrlExterna", SqlDbType.VarChar, -1).Value = Me.cUrlExterna
        cmdSQL.Parameters.Add("@iBandaSalarialMin", SqlDbType.SmallInt).Value = Me.iBandaSalarialMin
        cmdSQL.Parameters.Add("@iBandaSalarialMax", SqlDbType.SmallInt).Value = Me.iBandaSalarialMax

        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.DateTime).Value = Me.dFechaSis

        If Me.iCodUsuarioModificacion = "NULL" Then
            cmdSQL.Parameters.Add("@iCodUsuarioModificacion", SqlDbType.Int).Value = DBNull.Value
        Else
            cmdSQL.Parameters.Add("@iCodUsuarioModificacion", SqlDbType.Int).Value = CInt(Me.iCodUsuarioModificacion)
        End If

        If Me.dFechaModificacion = "NULL" Then
            cmdSQL.Parameters.Add("@dFechaModificacion", SqlDbType.DateTime).Value = DBNull.Value
        Else
            cmdSQL.Parameters.Add("@dFechaModificacion", SqlDbType.DateTime).Value = CDate(Me.dFechaModificacion)
        End If

        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub Eliminar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "DELETE from  dbo.Convocatoria  WHERE iCodConvocatoria=@iCodConvocatoria"
        'cmdSQL.CommandText = "UPDATE dbo.Convocatoria  SET bAnulado=1 WHERE  iCodConvocatoria=@iCodConvocatoria"
        cmdSQL.Parameters.Add("@iCodConvocatoria", SqlDbType.Int).Value = Me.iCodConvocatoria
        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub EliminarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "DELETE from  dbo.Convocatoria  WHERE iCodConvocatoria=@iCodConvocatoria"
        'cmdSQL.CommandText = "UPDATE dbo.Convocatoria  SET bAnulado=1 WHERE  iCodConvocatoria=@iCodConvocatoria"
        cmdSQL.Parameters.Add("@iCodConvocatoria", SqlDbType.Int).Value = Me.iCodConvocatoria
        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub getRecord()
        Dim readers As IDataReader
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL

        If bTransaccion = True Then cmdSQL.Transaction = Me.mc.miTransact Else 

        cmdSQL.CommandText = "SELECT * FROM dbo.Convocatoria WHERE iCodConvocatoria=@iCodConvocatoria"
        cmdSQL.Parameters.Add("@iCodConvocatoria", SqlDbType.Int).Value = Me.iCodConvocatoria
        readers = cmdSQL.ExecuteReader
        If readers.Read() Then
            Me.iCodConvocatoria = CStr(readers.GetValue(0))
            Me.iCodConvocatoriaMain = CStr(readers.GetValue(1))
            Me.IDREQ = CStr(readers.GetValue(2))
            Me.COD_DETALLE = CStr(readers.GetValue(3))
            Me.cMOCMONC = CStr(readers.GetValue(4))
            Me.cPerfil = CStr(readers.GetValue(5))
            Me.cDesPerfil = CStr(readers.GetValue(6))
            Me.iCantidad = CStr(readers.GetValue(7))
            Me.iEstado = CStr(readers.GetValue(8))
            Me.bLiberado = CStr(readers.GetValue(9))
            Me.iLiberado = CStr(readers.GetValue(10))
            Me.bCoberturado = CStr(readers.GetValue(11))
            Me.iExceptuado = CStr(readers.GetValue(12))
            Me.dFechaLiberaExceptua = CStr(readers.GetValue(13))
            Me.cObs = CStr(readers.GetValue(14))
            Me.bSituacion = CStr(readers.GetValue(15))
            Me.cAreaPerfil = CStr(readers.GetValue(16))
            Me.iTiempoExpRequerida = CStr(readers.GetValue(17))
            Me.iTiempoExpDeseable = CStr(readers.GetValue(18))
            Me.cCategoriaRCC = CStr(readers.GetValue(19))
            Me.cOcupacionRCC = CStr(readers.GetValue(20))
            Me.cEspecialidadRCC = CStr(readers.GetValue(21))
            Me.cTipoPerfil = CStr(readers.GetValue(22))
            Me.cRegimenLaboral = CStr(readers.GetValue(23))
            Me.cConocimiento = CStr(readers.GetValue(24))
            Me.cEspecializacion = CStr(readers.GetValue(25))
            Me.iTotal = CStr(readers.GetValue(26))
            Me.bResolicitado = CStr(readers.GetValue(27))
            Me.iTipoObra = CStr(IIf(readers.GetValue(28) Is DBNull.Value, "NULL", readers.GetValue(28)))
            Me.cFrenteLugarTrabajo = CStr(IIf(readers.GetValue(29) Is DBNull.Value, "NULL", readers.GetValue(29)))
            Me.dFechaEstimadaIngreso = CStr(IIf(readers.GetValue(30) Is DBNull.Value, "NULL", readers.GetValue(30)))
            Me.iPeriodoContrataMeses = CStr(readers.GetValue(31))
            Me.iCodOcupacion = CStr(readers.GetValue(32))
            Me.cFuncionesPuesto = CStr(readers.GetValue(33))
            Me.iEscalaRemunerativa = CStr(readers.GetValue(34))
            Me.cOtrosBeneficios = CStr(readers.GetValue(35))
            Me.iEdadMinimaRequerida = CStr(readers.GetValue(36))
            Me.iEdadMaximaRequerida = CStr(readers.GetValue(37))
            Me.cExperiencia = CStr(readers.GetValue(38))
            Me.cCompetencias = CStr(readers.GetValue(39))
            Me.cGenero = CStr(readers.GetValue(40))
            Me.iGradoInstruccion = CStr(readers.GetValue(41))
            Me.iCodUsuarioAprobador = CStr(IIf(readers.GetValue(42) Is DBNull.Value, "NULL", readers.GetValue(42)))
            Me.dFechaAprobacion = CStr(IIf(readers.GetValue(43) Is DBNull.Value, "NULL", readers.GetValue(43)))
            Me.cNotasAprobador = CStr(readers.GetValue(44))


            Me.cUrlExterna = CStr(readers.GetValue(45))
            Me.iBandaSalarialMin = CStr(readers.GetValue(46))
            Me.iBandaSalarialMax = CStr(readers.GetValue(47))



            Me.iCodUsuario = CStr(readers.GetValue(48))
            Me.dFechaSis = CStr(readers.GetValue(49))
            Me.iCodUsuarioModificacion = CStr(IIf(readers.GetValue(50) Is DBNull.Value, "NULL", readers.GetValue(50)))
            Me.dFechaModificacion = CStr(IIf(readers.GetValue(51) Is DBNull.Value, "NULL", readers.GetValue(51)))
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
	cmdSQL.CommandText = "SELECT * FROM dbo.Convocatoria"
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
    '******************************************************************************
	Public Function ListaConvocatoriasPorConvocatoriaMain() As DataTable
		Dim Query As String
		Dim readers As DataTable
		Query = " exec dbo.SP_DT_ConvocatoriasPorConvocatoriaMain " &
					   " @iCodConvocatoriaMain=" & Trim(Me.iCodConvocatoriaMain)
		'InputBox("", "", Query)
		readers = mc.ExecuteDataTable(Query)
		Return readers
	End Function

	Public Function obtenerConvocatoriaPorId() As DataTable

		Dim cmdSQL As New SqlCommand
		cmdSQL.Parameters.Clear()
		cmdSQL.Connection = ConnectSQL.linkSQL
		cmdSQL.CommandType = CommandType.StoredProcedure
		cmdSQL.CommandText = "SP_ROW_Convocatoria"
		cmdSQL.Parameters.Add("@iCodConvocatoria", SqlDbType.Int).Value = Me.iCodConvocatoria

		Dim readers As SqlDataReader
		readers = cmdSQL.ExecuteReader()
		Dim dt As New DataTable
		dt.Load(readers)
		Return dt

    End Function

    Public Sub UpdateRegistroWeb()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "UPDATE  dbo.Convocatoria SET cMOCMONC=@cMOCMONC,cPerfil=@cPerfil,cDesPerfil=@cDesPerfil,iCantidad=@iCantidad,iTiempoExpRequerida=@iTiempoExpRequerida,iCodOcupacion=@iCodOcupacion,iEdadMinimaRequerida=@iEdadMinimaRequerida,iEdadMaximaRequerida=@iEdadMaximaRequerida,cGenero=@cGenero,iGradoInstruccion=@iGradoInstruccion,iBandaSalarialMin=@iBandaSalarialMin,iBandaSalarialMax=@iBandaSalarialMax,iCodUsuarioModificacion=@iCodUsuarioModificacion,dFechaModificacion=@dFechaModificacion WHERE iCodConvocatoria=@iCodConvocatoria"
        cmdSQL.Parameters.Add("@iCodConvocatoria", SqlDbType.Int).Value = Me.iCodConvocatoria
        cmdSQL.Parameters.Add("@cMOCMONC", SqlDbType.VarChar, 5).Value = Me.cMOCMONC
        cmdSQL.Parameters.Add("@cPerfil", SqlDbType.VarChar, 120).Value = Me.cPerfil
        cmdSQL.Parameters.Add("@cDesPerfil", SqlDbType.VarChar, -1).Value = Me.cDesPerfil
        cmdSQL.Parameters.Add("@iCantidad", SqlDbType.SmallInt).Value = Me.iCantidad
        'cmdSQL.Parameters.Add("@cObs", SqlDbType.VarChar, 250).Value = Me.cObs
        cmdSQL.Parameters.Add("@iTiempoExpRequerida", SqlDbType.TinyInt).Value = Me.iTiempoExpRequerida



        cmdSQL.Parameters.Add("@iCodOcupacion", SqlDbType.Int).Value = Me.iCodOcupacion
        cmdSQL.Parameters.Add("@iEdadMinimaRequerida", SqlDbType.TinyInt).Value = Me.iEdadMinimaRequerida
        cmdSQL.Parameters.Add("@iEdadMaximaRequerida", SqlDbType.TinyInt).Value = Me.iEdadMaximaRequerida
        cmdSQL.Parameters.Add("@cGenero", SqlDbType.Char, 1).Value = Me.cGenero
        cmdSQL.Parameters.Add("@iGradoInstruccion", SqlDbType.TinyInt).Value = Me.iGradoInstruccion





        cmdSQL.Parameters.Add("@iBandaSalarialMin", SqlDbType.SmallInt).Value = Me.iBandaSalarialMin
        cmdSQL.Parameters.Add("@iBandaSalarialMax", SqlDbType.SmallInt).Value = Me.iBandaSalarialMax



        If Me.iCodUsuarioModificacion = "NULL" Then
            cmdSQL.Parameters.Add("@iCodUsuarioModificacion", SqlDbType.Int).Value = DBNull.Value
        Else
            cmdSQL.Parameters.Add("@iCodUsuarioModificacion", SqlDbType.Int).Value = CInt(Me.iCodUsuarioModificacion)
        End If

        If Me.dFechaModificacion = "NULL" Then
            cmdSQL.Parameters.Add("@dFechaModificacion", SqlDbType.DateTime).Value = DBNull.Value
        Else
            cmdSQL.Parameters.Add("@dFechaModificacion", SqlDbType.DateTime).Value = CDate(Me.dFechaModificacion)
        End If

        cmdSQL.ExecuteNonQuery()
    End Sub

    Public Function ListaConvocatoriasVigentes() As DataTable

        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = "main.SP_DT_ListaConvocatoriasVigentes"

        Dim readers As SqlDataReader
        readers = cmdSQL.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(readers)
        Return dt

    End Function

End Class
