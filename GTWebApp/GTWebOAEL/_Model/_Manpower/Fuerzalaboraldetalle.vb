Imports System.Data.SqlClient
Public Class Fuerzalaboraldetalle
    Public iCodFuerzaLaboralDetalle As String
    Public iCodFuerzaLaboral As String
    Public iCodCandidatoInforme As String
    Public iCodSubContrata As String
    Public cTipoCargo As String
    Public cOcupacion As String
    Public cMOCMONC As String
    Public cRotacion As String
    Public cTurno As String
    Public cTipoContrato As String
    Public cRegimenLaboral As String
    Public iHorasHombre As String
    Public cLugarPernocte As String
    Public cAreaTrabajo As String
    Public dFechaIni As String
    Public dFechaCese As String
    Public cMotivoCese As String
    Public cObs As String
    Public iCalificacion As String
    Public bDevolvioFotocheck As String
    Public iEstado As String
    Public bCesado As String
    Public bConsentimiento As String
    Public iPeriodo As String
    Public iMes As String
    Public cGrupo As String
    Public cNivel As String
    Public cSituacionLaboral As String
    Public iCodUsuarioModifica As String
    Public dFechaModifica As String
    Public iCodUsuarioCierra As String
    Public dFechaCierre As String
    Public iCodOcupacion As String
    Public dFechaTerminoContrato As String
    Public nSalarioBase As String
    Public iCodUsuario As String
    Public dFechaSis As String
    Public qSelect As String
    Public cTipoOpe As Char
    Public bTransaccion As Boolean = False
    Public mc As New ConnectSQL
    Public Function ListaDatos() As DataTable
        Dim Query As String
        Dim readers As DataTable
        Query = "SELECT * FROM dbo.FuerzaLaboralDetalle"
        readers = mc.ExecuteDataTable(Query)
        Return readers
    End Function
    Public Sub Insertar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "INSERT into dbo.FuerzaLaboralDetalle (iCodFuerzaLaboral,iCodCandidatoInforme,iCodSubContrata,cTipoCargo,cOcupacion,cMOCMONC,cRotacion,cTurno,cTipoContrato,cRegimenLaboral,iHorasHombre,cLugarPernocte,cAreaTrabajo,dFechaIni,dFechaCese,cMotivoCese,cObs,iCalificacion,bDevolvioFotocheck,iEstado,bCesado,bConsentimiento,iPeriodo,iMes,cGrupo,cNivel,cSituacionLaboral,iCodUsuarioModifica,dFechaModifica,iCodUsuarioCierra,dFechaCierre,iCodOcupacion,dFechaTerminoContrato,nSalarioBase,iCodUsuario,dFechaSis ) VALUES(@iCodFuerzaLaboral,@iCodCandidatoInforme,@iCodSubContrata,@cTipoCargo,@cOcupacion,@cMOCMONC,@cRotacion,@cTurno,@cTipoContrato,@cRegimenLaboral,@iHorasHombre,@cLugarPernocte,@cAreaTrabajo,@dFechaIni,@dFechaCese,@cMotivoCese,@cObs,@iCalificacion,@bDevolvioFotocheck,@iEstado,@bCesado,@bConsentimiento,@iPeriodo,@iMes,@cGrupo,@cNivel,@cSituacionLaboral,@iCodUsuarioModifica,@dFechaModifica,@iCodUsuarioCierra,@dFechaCierre,@iCodOcupacion,@dFechaTerminoContrato,@nSalarioBase,@iCodUsuario,@dFechaSis); SELECT SCOPE_IDENTITY(); "
        cmdSQL.Parameters.Add("@iCodFuerzaLaboral", SqlDbType.Int).Value = Me.iCodFuerzaLaboral
        cmdSQL.Parameters.Add("@iCodCandidatoInforme", SqlDbType.Int).Value = Me.iCodCandidatoInforme
        cmdSQL.Parameters.Add("@iCodSubContrata", SqlDbType.Int).Value = Me.iCodSubContrata
        cmdSQL.Parameters.Add("@cTipoCargo", SqlDbType.Varchar, 15).Value = Me.cTipoCargo
        cmdSQL.Parameters.Add("@cOcupacion", SqlDbType.Varchar, 100).Value = Me.cOcupacion
        cmdSQL.Parameters.Add("@cMOCMONC", SqlDbType.Varchar, 5).Value = Me.cMOCMONC
        cmdSQL.Parameters.Add("@cRotacion", SqlDbType.Varchar, 8).Value = Me.cRotacion
        cmdSQL.Parameters.Add("@cTurno", SqlDbType.Varchar, 8).Value = Me.cTurno
        cmdSQL.Parameters.Add("@cTipoContrato", SqlDbType.Varchar, 50).Value = Me.cTipoContrato
        cmdSQL.Parameters.Add("@cRegimenLaboral", SqlDbType.Varchar, 50).Value = Me.cRegimenLaboral
        cmdSQL.Parameters.Add("@iHorasHombre", SqlDbType.Smallint).Value = Me.iHorasHombre
        cmdSQL.Parameters.Add("@cLugarPernocte", SqlDbType.Varchar, 55).Value = Me.cLugarPernocte
        cmdSQL.Parameters.Add("@cAreaTrabajo", SqlDbType.Varchar, 70).Value = Me.cAreaTrabajo
        cmdSQL.Parameters.Add("@dFechaIni", SqlDbType.Date).Value = Me.dFechaIni
        cmdSQL.Parameters.Add("@dFechaCese", SqlDbType.Date).Value = Me.dFechaCese
        cmdSQL.Parameters.Add("@cMotivoCese", SqlDbType.Varchar, 50).Value = Me.cMotivoCese
        cmdSQL.Parameters.Add("@cObs", SqlDbType.Text, 800).Value = Me.cObs
        cmdSQL.Parameters.Add("@iCalificacion", SqlDbType.Tinyint).Value = Me.iCalificacion
        cmdSQL.Parameters.Add("@bDevolvioFotocheck", SqlDbType.Bit).Value = Me.bDevolvioFotocheck
        cmdSQL.Parameters.Add("@iEstado", SqlDbType.Tinyint).Value = Me.iEstado
        cmdSQL.Parameters.Add("@bCesado", SqlDbType.Bit).Value = Me.bCesado
        cmdSQL.Parameters.Add("@bConsentimiento", SqlDbType.Bit).Value = Me.bConsentimiento
        cmdSQL.Parameters.Add("@iPeriodo", SqlDbType.Smallint).Value = Me.iPeriodo
        cmdSQL.Parameters.Add("@iMes", SqlDbType.Tinyint).Value = Me.iMes
        cmdSQL.Parameters.Add("@cGrupo", SqlDbType.Varchar, 10).Value = Me.cGrupo
        cmdSQL.Parameters.Add("@cNivel", SqlDbType.Varchar, 20).Value = Me.cNivel
        cmdSQL.Parameters.Add("@cSituacionLaboral", SqlDbType.Varchar, 50).Value = Me.cSituacionLaboral
        cmdSQL.Parameters.Add("@iCodUsuarioModifica", SqlDbType.Int).Value = Me.iCodUsuarioModifica
        cmdSQL.Parameters.Add("@dFechaModifica", SqlDbType.Datetime).Value = Me.dFechaModifica
        cmdSQL.Parameters.Add("@iCodUsuarioCierra", SqlDbType.Int).Value = Me.iCodUsuarioCierra
        cmdSQL.Parameters.Add("@dFechaCierre", SqlDbType.Datetime).Value = Me.dFechaCierre
        cmdSQL.Parameters.Add("@iCodOcupacion", SqlDbType.Int).Value = Me.iCodOcupacion
        cmdSQL.Parameters.Add("@dFechaTerminoContrato", SqlDbType.Date).Value = Me.dFechaTerminoContrato
        cmdSQL.Parameters.Add("@nSalarioBase", SqlDbType.Decimal).Value = Me.nSalarioBase
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.Datetime).Value = Me.dFechaSis

        Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
        If pCodInsert > 0 Then
            Me.iCodFuerzaLaboralDetalle = pCodInsert
        Else
            Me.iCodFuerzaLaboralDetalle = 0
        End If
    End Sub
    Public Sub InsertarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "INSERT into dbo.FuerzaLaboralDetalle (iCodFuerzaLaboral,iCodCandidatoInforme,iCodSubContrata,cTipoCargo,cOcupacion,cMOCMONC,cRotacion,cTurno,cTipoContrato,cRegimenLaboral,iHorasHombre,cLugarPernocte,cAreaTrabajo,dFechaIni,dFechaCese,cMotivoCese,cObs,iCalificacion,bDevolvioFotocheck,iEstado,bCesado,bConsentimiento,iPeriodo,iMes,cGrupo,cNivel,cSituacionLaboral,iCodUsuarioModifica,dFechaModifica,iCodUsuarioCierra,dFechaCierre,iCodOcupacion,dFechaTerminoContrato,nSalarioBase,iCodUsuario,dFechaSis ) VALUES(@iCodFuerzaLaboral,@iCodCandidatoInforme,@iCodSubContrata,@cTipoCargo,@cOcupacion,@cMOCMONC,@cRotacion,@cTurno,@cTipoContrato,@cRegimenLaboral,@iHorasHombre,@cLugarPernocte,@cAreaTrabajo,@dFechaIni,@dFechaCese,@cMotivoCese,@cObs,@iCalificacion,@bDevolvioFotocheck,@iEstado,@bCesado,@bConsentimiento,@iPeriodo,@iMes,@cGrupo,@cNivel,@cSituacionLaboral,@iCodUsuarioModifica,@dFechaModifica,@iCodUsuarioCierra,@dFechaCierre,@iCodOcupacion,@dFechaTerminoContrato,@nSalarioBase,@iCodUsuario,@dFechaSis); SELECT SCOPE_IDENTITY(); "
        cmdSQL.Parameters.Add("@iCodFuerzaLaboral", SqlDbType.Int).Value = Me.iCodFuerzaLaboral
        cmdSQL.Parameters.Add("@iCodCandidatoInforme", SqlDbType.Int).Value = Me.iCodCandidatoInforme
        cmdSQL.Parameters.Add("@iCodSubContrata", SqlDbType.Int).Value = Me.iCodSubContrata
        cmdSQL.Parameters.Add("@cTipoCargo", SqlDbType.Varchar, 15).Value = Me.cTipoCargo
        cmdSQL.Parameters.Add("@cOcupacion", SqlDbType.Varchar, 100).Value = Me.cOcupacion
        cmdSQL.Parameters.Add("@cMOCMONC", SqlDbType.Varchar, 5).Value = Me.cMOCMONC
        cmdSQL.Parameters.Add("@cRotacion", SqlDbType.Varchar, 8).Value = Me.cRotacion
        cmdSQL.Parameters.Add("@cTurno", SqlDbType.Varchar, 8).Value = Me.cTurno
        cmdSQL.Parameters.Add("@cTipoContrato", SqlDbType.Varchar, 50).Value = Me.cTipoContrato
        cmdSQL.Parameters.Add("@cRegimenLaboral", SqlDbType.Varchar, 50).Value = Me.cRegimenLaboral
        cmdSQL.Parameters.Add("@iHorasHombre", SqlDbType.Smallint).Value = Me.iHorasHombre
        cmdSQL.Parameters.Add("@cLugarPernocte", SqlDbType.Varchar, 55).Value = Me.cLugarPernocte
        cmdSQL.Parameters.Add("@cAreaTrabajo", SqlDbType.Varchar, 70).Value = Me.cAreaTrabajo
        cmdSQL.Parameters.Add("@dFechaIni", SqlDbType.Date).Value = Me.dFechaIni
        cmdSQL.Parameters.Add("@dFechaCese", SqlDbType.Date).Value = Me.dFechaCese
        cmdSQL.Parameters.Add("@cMotivoCese", SqlDbType.Varchar, 50).Value = Me.cMotivoCese
        cmdSQL.Parameters.Add("@cObs", SqlDbType.Text, 800).Value = Me.cObs
        cmdSQL.Parameters.Add("@iCalificacion", SqlDbType.Tinyint).Value = Me.iCalificacion
        cmdSQL.Parameters.Add("@bDevolvioFotocheck", SqlDbType.Bit).Value = Me.bDevolvioFotocheck
        cmdSQL.Parameters.Add("@iEstado", SqlDbType.Tinyint).Value = Me.iEstado
        cmdSQL.Parameters.Add("@bCesado", SqlDbType.Bit).Value = Me.bCesado
        cmdSQL.Parameters.Add("@bConsentimiento", SqlDbType.Bit).Value = Me.bConsentimiento
        cmdSQL.Parameters.Add("@iPeriodo", SqlDbType.Smallint).Value = Me.iPeriodo
        cmdSQL.Parameters.Add("@iMes", SqlDbType.Tinyint).Value = Me.iMes
        cmdSQL.Parameters.Add("@cGrupo", SqlDbType.Varchar, 10).Value = Me.cGrupo
        cmdSQL.Parameters.Add("@cNivel", SqlDbType.Varchar, 20).Value = Me.cNivel
        cmdSQL.Parameters.Add("@cSituacionLaboral", SqlDbType.Varchar, 50).Value = Me.cSituacionLaboral
        cmdSQL.Parameters.Add("@iCodUsuarioModifica", SqlDbType.Int).Value = Me.iCodUsuarioModifica
        cmdSQL.Parameters.Add("@dFechaModifica", SqlDbType.Datetime).Value = Me.dFechaModifica
        cmdSQL.Parameters.Add("@iCodUsuarioCierra", SqlDbType.Int).Value = Me.iCodUsuarioCierra
        cmdSQL.Parameters.Add("@dFechaCierre", SqlDbType.Datetime).Value = Me.dFechaCierre
        cmdSQL.Parameters.Add("@iCodOcupacion", SqlDbType.Int).Value = Me.iCodOcupacion
        cmdSQL.Parameters.Add("@dFechaTerminoContrato", SqlDbType.Date).Value = Me.dFechaTerminoContrato
        cmdSQL.Parameters.Add("@nSalarioBase", SqlDbType.Decimal).Value = Me.nSalarioBase
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.Datetime).Value = Me.dFechaSis

        Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
        If pCodInsert > 0 Then
            Me.iCodFuerzaLaboralDetalle = pCodInsert
        Else
            Me.iCodFuerzaLaboralDetalle = 0
        End If
    End Sub
    Public Sub Modificar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "UPDATE  dbo.FuerzaLaboralDetalle SET iCodFuerzaLaboral=@iCodFuerzaLaboral,iCodCandidatoInforme=@iCodCandidatoInforme,iCodSubContrata=@iCodSubContrata,cTipoCargo=@cTipoCargo,cOcupacion=@cOcupacion,cMOCMONC=@cMOCMONC,cRotacion=@cRotacion,cTurno=@cTurno,cTipoContrato=@cTipoContrato,cRegimenLaboral=@cRegimenLaboral,iHorasHombre=@iHorasHombre,cLugarPernocte=@cLugarPernocte,cAreaTrabajo=@cAreaTrabajo,dFechaIni=@dFechaIni,dFechaCese=@dFechaCese,cMotivoCese=@cMotivoCese,cObs=@cObs,iCalificacion=@iCalificacion,bDevolvioFotocheck=@bDevolvioFotocheck,iEstado=@iEstado,bCesado=@bCesado,bConsentimiento=@bConsentimiento,iPeriodo=@iPeriodo,iMes=@iMes,cGrupo=@cGrupo,cNivel=@cNivel,cSituacionLaboral=@cSituacionLaboral,iCodUsuarioModifica=@iCodUsuarioModifica,dFechaModifica=@dFechaModifica,iCodUsuarioCierra=@iCodUsuarioCierra,dFechaCierre=@dFechaCierre,iCodOcupacion=@iCodOcupacion,dFechaTerminoContrato=@dFechaTerminoContrato,nSalarioBase=@nSalarioBase,iCodUsuario=@iCodUsuario,dFechaSis=@dFechaSis WHERE iCodFuerzaLaboralDetalle=@iCodFuerzaLaboralDetalle"
        cmdSQL.Parameters.Add("@iCodFuerzaLaboralDetalle", SqlDbType.Int).Value = Me.iCodFuerzaLaboralDetalle
        cmdSQL.Parameters.Add("@iCodFuerzaLaboral", SqlDbType.Int).Value = Me.iCodFuerzaLaboral
        cmdSQL.Parameters.Add("@iCodCandidatoInforme", SqlDbType.Int).Value = Me.iCodCandidatoInforme
        cmdSQL.Parameters.Add("@iCodSubContrata", SqlDbType.Int).Value = Me.iCodSubContrata
        cmdSQL.Parameters.Add("@cTipoCargo", SqlDbType.Varchar, 15).Value = Me.cTipoCargo
        cmdSQL.Parameters.Add("@cOcupacion", SqlDbType.Varchar, 100).Value = Me.cOcupacion
        cmdSQL.Parameters.Add("@cMOCMONC", SqlDbType.Varchar, 5).Value = Me.cMOCMONC
        cmdSQL.Parameters.Add("@cRotacion", SqlDbType.Varchar, 8).Value = Me.cRotacion
        cmdSQL.Parameters.Add("@cTurno", SqlDbType.Varchar, 8).Value = Me.cTurno
        cmdSQL.Parameters.Add("@cTipoContrato", SqlDbType.Varchar, 50).Value = Me.cTipoContrato
        cmdSQL.Parameters.Add("@cRegimenLaboral", SqlDbType.Varchar, 50).Value = Me.cRegimenLaboral
        cmdSQL.Parameters.Add("@iHorasHombre", SqlDbType.Smallint).Value = Me.iHorasHombre
        cmdSQL.Parameters.Add("@cLugarPernocte", SqlDbType.Varchar, 55).Value = Me.cLugarPernocte
        cmdSQL.Parameters.Add("@cAreaTrabajo", SqlDbType.Varchar, 70).Value = Me.cAreaTrabajo
        cmdSQL.Parameters.Add("@dFechaIni", SqlDbType.Date).Value = Me.dFechaIni
        cmdSQL.Parameters.Add("@dFechaCese", SqlDbType.Date).Value = Me.dFechaCese
        cmdSQL.Parameters.Add("@cMotivoCese", SqlDbType.Varchar, 50).Value = Me.cMotivoCese
        cmdSQL.Parameters.Add("@cObs", SqlDbType.Text, 800).Value = Me.cObs
        cmdSQL.Parameters.Add("@iCalificacion", SqlDbType.Tinyint).Value = Me.iCalificacion
        cmdSQL.Parameters.Add("@bDevolvioFotocheck", SqlDbType.Bit).Value = Me.bDevolvioFotocheck
        cmdSQL.Parameters.Add("@iEstado", SqlDbType.Tinyint).Value = Me.iEstado
        cmdSQL.Parameters.Add("@bCesado", SqlDbType.Bit).Value = Me.bCesado
        cmdSQL.Parameters.Add("@bConsentimiento", SqlDbType.Bit).Value = Me.bConsentimiento
        cmdSQL.Parameters.Add("@iPeriodo", SqlDbType.Smallint).Value = Me.iPeriodo
        cmdSQL.Parameters.Add("@iMes", SqlDbType.Tinyint).Value = Me.iMes
        cmdSQL.Parameters.Add("@cGrupo", SqlDbType.Varchar, 10).Value = Me.cGrupo
        cmdSQL.Parameters.Add("@cNivel", SqlDbType.Varchar, 20).Value = Me.cNivel
        cmdSQL.Parameters.Add("@cSituacionLaboral", SqlDbType.Varchar, 50).Value = Me.cSituacionLaboral
        cmdSQL.Parameters.Add("@iCodUsuarioModifica", SqlDbType.Int).Value = Me.iCodUsuarioModifica
        cmdSQL.Parameters.Add("@dFechaModifica", SqlDbType.Datetime).Value = Me.dFechaModifica
        cmdSQL.Parameters.Add("@iCodUsuarioCierra", SqlDbType.Int).Value = Me.iCodUsuarioCierra
        cmdSQL.Parameters.Add("@dFechaCierre", SqlDbType.Datetime).Value = Me.dFechaCierre
        cmdSQL.Parameters.Add("@iCodOcupacion", SqlDbType.Int).Value = Me.iCodOcupacion
        cmdSQL.Parameters.Add("@dFechaTerminoContrato", SqlDbType.Date).Value = Me.dFechaTerminoContrato
        cmdSQL.Parameters.Add("@nSalarioBase", SqlDbType.Decimal).Value = Me.nSalarioBase
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.Datetime).Value = Me.dFechaSis

        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub ModificarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "UPDATE  dbo.FuerzaLaboralDetalle SET iCodFuerzaLaboral=@iCodFuerzaLaboral,iCodCandidatoInforme=@iCodCandidatoInforme,iCodSubContrata=@iCodSubContrata,cTipoCargo=@cTipoCargo,cOcupacion=@cOcupacion,cMOCMONC=@cMOCMONC,cRotacion=@cRotacion,cTurno=@cTurno,cTipoContrato=@cTipoContrato,cRegimenLaboral=@cRegimenLaboral,iHorasHombre=@iHorasHombre,cLugarPernocte=@cLugarPernocte,cAreaTrabajo=@cAreaTrabajo,dFechaIni=@dFechaIni,dFechaCese=@dFechaCese,cMotivoCese=@cMotivoCese,cObs=@cObs,iCalificacion=@iCalificacion,bDevolvioFotocheck=@bDevolvioFotocheck,iEstado=@iEstado,bCesado=@bCesado,bConsentimiento=@bConsentimiento,iPeriodo=@iPeriodo,iMes=@iMes,cGrupo=@cGrupo,cNivel=@cNivel,cSituacionLaboral=@cSituacionLaboral,iCodUsuarioModifica=@iCodUsuarioModifica,dFechaModifica=@dFechaModifica,iCodUsuarioCierra=@iCodUsuarioCierra,dFechaCierre=@dFechaCierre,iCodOcupacion=@iCodOcupacion,dFechaTerminoContrato=@dFechaTerminoContrato,nSalarioBase=@nSalarioBase,iCodUsuario=@iCodUsuario,dFechaSis=@dFechaSis WHERE iCodFuerzaLaboralDetalle=@iCodFuerzaLaboralDetalle"
        cmdSQL.Parameters.Add("@iCodFuerzaLaboralDetalle", SqlDbType.Int).Value = Me.iCodFuerzaLaboralDetalle
        cmdSQL.Parameters.Add("@iCodFuerzaLaboral", SqlDbType.Int).Value = Me.iCodFuerzaLaboral
        cmdSQL.Parameters.Add("@iCodCandidatoInforme", SqlDbType.Int).Value = Me.iCodCandidatoInforme
        cmdSQL.Parameters.Add("@iCodSubContrata", SqlDbType.Int).Value = Me.iCodSubContrata
        cmdSQL.Parameters.Add("@cTipoCargo", SqlDbType.Varchar, 15).Value = Me.cTipoCargo
        cmdSQL.Parameters.Add("@cOcupacion", SqlDbType.Varchar, 100).Value = Me.cOcupacion
        cmdSQL.Parameters.Add("@cMOCMONC", SqlDbType.Varchar, 5).Value = Me.cMOCMONC
        cmdSQL.Parameters.Add("@cRotacion", SqlDbType.Varchar, 8).Value = Me.cRotacion
        cmdSQL.Parameters.Add("@cTurno", SqlDbType.Varchar, 8).Value = Me.cTurno
        cmdSQL.Parameters.Add("@cTipoContrato", SqlDbType.Varchar, 50).Value = Me.cTipoContrato
        cmdSQL.Parameters.Add("@cRegimenLaboral", SqlDbType.Varchar, 50).Value = Me.cRegimenLaboral
        cmdSQL.Parameters.Add("@iHorasHombre", SqlDbType.Smallint).Value = Me.iHorasHombre
        cmdSQL.Parameters.Add("@cLugarPernocte", SqlDbType.Varchar, 55).Value = Me.cLugarPernocte
        cmdSQL.Parameters.Add("@cAreaTrabajo", SqlDbType.Varchar, 70).Value = Me.cAreaTrabajo
        cmdSQL.Parameters.Add("@dFechaIni", SqlDbType.Date).Value = Me.dFechaIni
        cmdSQL.Parameters.Add("@dFechaCese", SqlDbType.Date).Value = Me.dFechaCese
        cmdSQL.Parameters.Add("@cMotivoCese", SqlDbType.Varchar, 50).Value = Me.cMotivoCese
        cmdSQL.Parameters.Add("@cObs", SqlDbType.Text, 800).Value = Me.cObs
        cmdSQL.Parameters.Add("@iCalificacion", SqlDbType.Tinyint).Value = Me.iCalificacion
        cmdSQL.Parameters.Add("@bDevolvioFotocheck", SqlDbType.Bit).Value = Me.bDevolvioFotocheck
        cmdSQL.Parameters.Add("@iEstado", SqlDbType.Tinyint).Value = Me.iEstado
        cmdSQL.Parameters.Add("@bCesado", SqlDbType.Bit).Value = Me.bCesado
        cmdSQL.Parameters.Add("@bConsentimiento", SqlDbType.Bit).Value = Me.bConsentimiento
        cmdSQL.Parameters.Add("@iPeriodo", SqlDbType.Smallint).Value = Me.iPeriodo
        cmdSQL.Parameters.Add("@iMes", SqlDbType.Tinyint).Value = Me.iMes
        cmdSQL.Parameters.Add("@cGrupo", SqlDbType.Varchar, 10).Value = Me.cGrupo
        cmdSQL.Parameters.Add("@cNivel", SqlDbType.Varchar, 20).Value = Me.cNivel
        cmdSQL.Parameters.Add("@cSituacionLaboral", SqlDbType.Varchar, 50).Value = Me.cSituacionLaboral
        cmdSQL.Parameters.Add("@iCodUsuarioModifica", SqlDbType.Int).Value = Me.iCodUsuarioModifica
        cmdSQL.Parameters.Add("@dFechaModifica", SqlDbType.Datetime).Value = Me.dFechaModifica
        cmdSQL.Parameters.Add("@iCodUsuarioCierra", SqlDbType.Int).Value = Me.iCodUsuarioCierra
        cmdSQL.Parameters.Add("@dFechaCierre", SqlDbType.Datetime).Value = Me.dFechaCierre
        cmdSQL.Parameters.Add("@iCodOcupacion", SqlDbType.Int).Value = Me.iCodOcupacion
        cmdSQL.Parameters.Add("@dFechaTerminoContrato", SqlDbType.Date).Value = Me.dFechaTerminoContrato
        cmdSQL.Parameters.Add("@nSalarioBase", SqlDbType.Decimal).Value = Me.nSalarioBase
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.Datetime).Value = Me.dFechaSis

        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub Eliminar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "DELETE from  dbo.FuerzaLaboralDetalle  WHERE iCodFuerzaLaboralDetalle=@iCodFuerzaLaboralDetalle"
        'cmdSQL.CommandText = "UPDATE dbo.FuerzaLaboralDetalle  SET bAnulado=1 WHERE  iCodFuerzaLaboralDetalle=@iCodFuerzaLaboralDetalle"
        cmdSQL.Parameters.Add("@iCodFuerzaLaboralDetalle", SqlDbType.Int).Value = Me.iCodFuerzaLaboralDetalle
        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub EliminarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "DELETE from  dbo.FuerzaLaboralDetalle  WHERE iCodFuerzaLaboralDetalle=@iCodFuerzaLaboralDetalle"
        'cmdSQL.CommandText = "UPDATE dbo.FuerzaLaboralDetalle  SET bAnulado=1 WHERE  iCodFuerzaLaboralDetalle=@iCodFuerzaLaboralDetalle"
        cmdSQL.Parameters.Add("@iCodFuerzaLaboralDetalle", SqlDbType.Int).Value = Me.iCodFuerzaLaboralDetalle
        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub getRecord()
        Dim readers As IDataReader
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL

        If bTransaccion = True Then cmdSQL.Transaction = Me.mc.miTransact Else 

        cmdSQL.CommandText = "SELECT * FROM dbo.FuerzaLaboralDetalle WHERE iCodFuerzaLaboralDetalle=@iCodFuerzaLaboralDetalle"
        cmdSQL.Parameters.Add("@iCodFuerzaLaboralDetalle", SqlDbType.Int).Value = Me.iCodFuerzaLaboralDetalle
        readers = cmdSQL.ExecuteReader
        If readers.Read() Then
            Me.iCodFuerzaLaboralDetalle = CStr(readers.GetValue(0))
            Me.iCodFuerzaLaboral = CStr(readers.GetValue(1))
            Me.iCodCandidatoInforme = CStr(readers.GetValue(2))
            Me.iCodSubContrata = CStr(readers.GetValue(3))
            Me.cTipoCargo = CStr(readers.GetValue(4))
            Me.cOcupacion = CStr(readers.GetValue(5))
            Me.cMOCMONC = CStr(readers.GetValue(6))
            Me.cRotacion = CStr(readers.GetValue(7))
            Me.cTurno = CStr(readers.GetValue(8))
            Me.cTipoContrato = CStr(readers.GetValue(9))
            Me.cRegimenLaboral = CStr(readers.GetValue(10))
            Me.iHorasHombre = CStr(readers.GetValue(11))
            Me.cLugarPernocte = CStr(readers.GetValue(12))
            Me.cAreaTrabajo = CStr(readers.GetValue(13))
            Me.dFechaIni = CStr(readers.GetValue(14))
            Me.dFechaCese = CStr(readers.GetValue(15))
            Me.cMotivoCese = CStr(readers.GetValue(16))
            Me.cObs = CStr(readers.GetValue(17))
            Me.iCalificacion = CStr(readers.GetValue(18))
            Me.bDevolvioFotocheck = CStr(readers.GetValue(19))
            Me.iEstado = CStr(readers.GetValue(20))
            Me.bCesado = CStr(readers.GetValue(21))
            Me.bConsentimiento = CStr(readers.GetValue(22))
            Me.iPeriodo = CStr(readers.GetValue(23))
            Me.iMes = CStr(readers.GetValue(24))
            Me.cGrupo = CStr(readers.GetValue(25))
            Me.cNivel = CStr(readers.GetValue(26))
            Me.cSituacionLaboral = CStr(readers.GetValue(27))
            Me.iCodUsuarioModifica = CStr(readers.GetValue(28))
            Me.dFechaModifica = CStr(readers.GetValue(29))
            Me.iCodUsuarioCierra = CStr(readers.GetValue(30))
            Me.dFechaCierre = CStr(readers.GetValue(31))
            Me.iCodOcupacion = CStr(readers.GetValue(32))
            Me.dFechaTerminoContrato = CStr(readers.GetValue(33))
            Me.nSalarioBase = CStr(readers.GetValue(34))
            Me.iCodUsuario = CStr(readers.GetValue(35))
            Me.dFechaSis = CStr(readers.GetValue(36))
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
        cmdSQL.CommandText = "SELECT * FROM dbo.FuerzaLaboralDetalle"
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
    '*******************************************************************
    Public Function ListaLugarPernocte() As DataTable
        Dim Query As String
        Dim pTabla As String = "FuerzaLaboralDetalle"
        Dim pNombreGrupo As String = "LugarPernocte"
        Dim readers As DataTable
        Query = " select cValueMember as ValueMember,cDisplayMember as DisplayMember From TDCatalogo where " & _
            " cTabla='" & Trim(pTabla) & "'  and cNombreGrupo='" & Trim(pNombreGrupo) & "' order by iOrden asc "
        'InputBox("", "", Query)
        readers = mc.ExecuteDataTable(Query)
        Return readers
    End Function

    Public Function ListaRotacion() As DataTable
        Dim Query As String
        Dim pTabla As String = "FuerzaLaboralDetalle"
        Dim pNombreGrupo As String = "Rotacion"
        Dim readers As DataTable
        Query = " select cValueMember as ValueMember,cDisplayMember as DisplayMember From TDCatalogo where " & _
            " cTabla='" & Trim(pTabla) & "'  and cNombreGrupo='" & Trim(pNombreGrupo) & "' order by cDisplayMember asc "
        'InputBox("", "", Query)
        readers = mc.ExecuteDataTable(Query)
        Return readers
    End Function
    Public Function ListaMotivoCese() As DataTable
        Dim Query As String
        Dim pTabla As String = "FuerzaLaboralDetalle"
        Dim pNombreGrupo As String = "MotivoCese"
        Dim readers As DataTable
        Query = " select cValueMember as ValueMember,cDisplayMember as DisplayMember From TDCatalogo where " & _
            " cTabla='" & Trim(pTabla) & "'  and cNombreGrupo='" & Trim(pNombreGrupo) & "' order by cDisplayMember asc "
        'InputBox("", "", Query)
        readers = mc.ExecuteDataTable(Query)
        Return readers
    End Function
    Public Function ListaDetalleFuerzaLaboral() As DataTable
        Dim Query As String
        Dim readers As DataTable
        Query = " exec dbo.SP_FL_DetalleFuerzaLaboral " & _
                       " @iCodFuerzaLaboral='" & Trim(Me.iCodFuerzaLaboral) & "'   "
        'InputBox("", "", Query)
        readers = mc.ExecuteDataTable(Query)
        Return readers
    End Function
    Public Function GetRecordDetalleCI() As DataTable
        Dim Query As String
        Dim readers As DataTable
        Query = " exec dbo.SP_FL_GetFuerzaLaboralDetalleCI " & _
                       " @iCodFuerzaLaboralDetalle='" & Trim(Me.iCodFuerzaLaboralDetalle) & "'   "

        readers = mc.ExecuteDataTable(Query)
        Return readers
    End Function
    Public Function GetRecordDetalleCese() As DataTable
        'Dim Query As String
        'Dim readers As DataTable
        'Query = String.Format("SELECT iCodFuerzaLaboralDetalle,convert(varchar, dFechaCese, 103) as dFechaCese,cObs,iCalificacion,cMotivoCese,bDevolvioFotocheck FROM FuerzaLaboralDetalle where iCodFuerzaLaboralDetalle={0}", Me.iCodFuerzaLaboralDetalle)
        'readers = mc.ExecuteDataTable(Query)
        'Return readers



        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "SELECT iCodFuerzaLaboralDetalle,convert(varchar, dFechaCese, 103) as dFechaCese,cObs,iCalificacion,cMotivoCese,bDevolvioFotocheck FROM FuerzaLaboralDetalle where iCodFuerzaLaboralDetalle=@iCodFuerzaLaboralDetalle"
        cmdSQL.Parameters.Add("@iCodFuerzaLaboralDetalle", SqlDbType.Int).Value = Me.iCodFuerzaLaboralDetalle


        'cmdSQL.ExecuteNonQuery()




        Dim readers As SqlDataReader
        readers = cmdSQL.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(readers)
        Return dt

    End Function
    Public Sub UpdatePersonaCese()
        'Dim Query As String
        'Query = String.Format("UPDATE Fuerzalaboraldetalle SET bCesado=1,dFechaCese='{1}',cMotivoCese='{2}',cObs='{3}',iCalificacion='{4}',iCodUsuarioModifica='{5}',bDevolvioFotocheck='{6}',dFechaModifica=GETDATE() WHERE iCodFuerzaLaboralDetalle={0}", Me.iCodFuerzaLaboralDetalle, Me.dFechaCese, Me.cMotivoCese, Me.cObs, Me.iCalificacion, Me.iCodUsuarioModifica, Me.bDevolvioFotocheck)
        'mc.ExecuteQueryTransact(Query)

        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL

        cmdSQL.CommandText = "UPDATE dbo.Fuerzalaboraldetalle SET bCesado=1,dFechaCese=@dFechaCese,cMotivoCese=@cMotivoCese,cObs=@cObs,iCalificacion=@iCalificacion,iCodUsuarioModifica=@iCodUsuarioModifica,bDevolvioFotocheck=@bDevolvioFotocheck,dFechaModifica=GETDATE() WHERE iCodFuerzaLaboralDetalle=@iCodFuerzaLaboralDetalle"

        'cmdSQL.Parameters.Add("@bCesado", SqlDbType.Bit).Value = Me.bCesado
        cmdSQL.Parameters.Add("@dFechaCese", SqlDbType.Date).Value = Me.dFechaCese
        cmdSQL.Parameters.Add("@cMotivoCese", SqlDbType.VarChar, 50).Value = Me.cMotivoCese
        cmdSQL.Parameters.Add("@cObs", SqlDbType.Text).Value = Me.cObs
        cmdSQL.Parameters.Add("@iCalificacion", SqlDbType.TinyInt).Value = Me.iCalificacion
        cmdSQL.Parameters.Add("@iCodUsuarioModifica", SqlDbType.Int).Value = Me.iCodUsuarioModifica
        cmdSQL.Parameters.Add("@bDevolvioFotocheck", SqlDbType.Bit).Value = Me.bDevolvioFotocheck
        cmdSQL.Parameters.Add("@iCodFuerzaLaboralDetalle", SqlDbType.Int).Value = Me.iCodFuerzaLaboralDetalle

        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub EliminarNuevoColaborador()
        'Dim Query As String
        'Query = String.Format("DELETE from Fuerzalaboraldetalle WHERE iCodFuerzaLaboralDetalle={0} and iEstado=1", Me.iCodFuerzaLaboralDetalle)
        ''Query = String.Format("UPDATE Fuerzalaboraldetalle SET bAnulado=1 WHERE iCodFuerzaLaboralDetalle={0}", Me.iCodFuerzaLaboralDetalle)
        'mc.ExecuteQuery(Query)


        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "DELETE from Fuerzalaboraldetalle WHERE iCodFuerzaLaboralDetalle=@iCodFuerzaLaboralDetalle and iEstado=1"
        cmdSQL.Parameters.Add("@iCodFuerzaLaboralDetalle", SqlDbType.Int).Value = Me.iCodFuerzaLaboralDetalle
        cmdSQL.ExecuteNonQuery()
    End Sub
End Class
