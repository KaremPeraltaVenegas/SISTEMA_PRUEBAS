Imports System.Data.SqlClient
Public Class Candidatoexperiencialaboral
    Public iCodCandidatoExperienciaLaboral As String
    Public iCodCandidatoInforme As String
    Public iCodOcupacion As String
    Public iCodCandidatoExperienciaNivel As String
    Public cSectorExperiencia As String
    Public cRubroExperiencia As String
    Public cRegimenExperiencia As String
    Public cEmpresa As String
    Public cPuesto As String
    Public cFuncionesLogros As String
    Public cDestacariasEmpresa As String
    Public iPeriodoInicioMes As String
    Public iPeriodoInicioAno As String
    Public iPeriodoFinMes As String
    Public iPeriodoFinAno As String
    Public dFechaIni As String
    Public dFechaFin As String
    Public bActualmenteTrabajado As String
    Public bObservado As String
    Public cObservacionExperiencia As String
    Public cReferenciaPersona As String
    Public cReferenciaPuesto As String
    Public cReferenciaFono As String
    Public cReferenciaCalificacion As String
    Public cReferenciaObs As String
    Public dFechaValidacionExperiencia As String
    Public iCodUsuarioValidaExperiencia As String
    Public cUrlDocumento As String
    Public bActivo As String
    Public bOcupacion1 As String
    Public bOcupacion2 As String
    Public bDocumentado As String
    Public iCodUsuarioRegistro As String
    Public dFechaRegistro As String
    Public iCodUsuario As String
    Public dFechaSis As String
    Public qSelect As String
    Public cTipoOpe As Char
    Public bTransaccion As Boolean = False
    Public mc As New ConnectSQL
    Public Function ListaDatos() As DataTable
        Dim Query As String
        Dim readers As DataTable
        Query = "SELECT * FROM dbo.CandidatoExperienciaLaboral"
        readers = mc.ExecuteDataTable(Query)
        Return readers
    End Function
    Public Sub Insertar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "INSERT into dbo.CandidatoExperienciaLaboral (iCodCandidatoInforme,iCodOcupacion,iCodCandidatoExperienciaNivel,cSectorExperiencia,cRubroExperiencia,cRegimenExperiencia,cEmpresa,cPuesto,cFuncionesLogros,cDestacariasEmpresa,iPeriodoInicioMes,iPeriodoInicioAno,iPeriodoFinMes,iPeriodoFinAno,dFechaIni,dFechaFin,bActualmenteTrabajado,bObservado,cObservacionExperiencia,cReferenciaPersona,cReferenciaPuesto,cReferenciaFono,cReferenciaCalificacion,cReferenciaObs,dFechaValidacionExperiencia,iCodUsuarioValidaExperiencia,cUrlDocumento,bActivo,bOcupacion1,bOcupacion2,bDocumentado,iCodUsuarioRegistro,dFechaRegistro,iCodUsuario,dFechaSis ) VALUES(@iCodCandidatoInforme,@iCodOcupacion,@iCodCandidatoExperienciaNivel,@cSectorExperiencia,@cRubroExperiencia,@cRegimenExperiencia,@cEmpresa,@cPuesto,@cFuncionesLogros,@cDestacariasEmpresa,@iPeriodoInicioMes,@iPeriodoInicioAno,@iPeriodoFinMes,@iPeriodoFinAno,@dFechaIni,@dFechaFin,@bActualmenteTrabajado,@bObservado,@cObservacionExperiencia,@cReferenciaPersona,@cReferenciaPuesto,@cReferenciaFono,@cReferenciaCalificacion,@cReferenciaObs,@dFechaValidacionExperiencia,@iCodUsuarioValidaExperiencia,@cUrlDocumento,@bActivo,@bOcupacion1,@bOcupacion2,@bDocumentado,@iCodUsuarioRegistro,@dFechaRegistro,@iCodUsuario,@dFechaSis); SELECT SCOPE_IDENTITY(); "
        cmdSQL.Parameters.Add("@iCodCandidatoInforme", SqlDbType.Int).Value = Me.iCodCandidatoInforme
        cmdSQL.Parameters.Add("@iCodOcupacion", SqlDbType.Int).Value = Me.iCodOcupacion
        cmdSQL.Parameters.Add("@iCodCandidatoExperienciaNivel", SqlDbType.Smallint).Value = Me.iCodCandidatoExperienciaNivel
        cmdSQL.Parameters.Add("@cSectorExperiencia", SqlDbType.Varchar, 20).Value = Me.cSectorExperiencia
        cmdSQL.Parameters.Add("@cRubroExperiencia", SqlDbType.Varchar, 50).Value = Me.cRubroExperiencia
        cmdSQL.Parameters.Add("@cRegimenExperiencia", SqlDbType.Varchar, 3).Value = Me.cRegimenExperiencia
        cmdSQL.Parameters.Add("@cEmpresa", SqlDbType.Varchar, 220).Value = Me.cEmpresa
        cmdSQL.Parameters.Add("@cPuesto", SqlDbType.Varchar, 100).Value = Me.cPuesto
        cmdSQL.Parameters.Add("@cFuncionesLogros", SqlDbType.Varchar, -1).Value = Me.cFuncionesLogros
        cmdSQL.Parameters.Add("@cDestacariasEmpresa", SqlDbType.Varchar, -1).Value = Me.cDestacariasEmpresa
        cmdSQL.Parameters.Add("@iPeriodoInicioMes", SqlDbType.Tinyint).Value = Me.iPeriodoInicioMes
        cmdSQL.Parameters.Add("@iPeriodoInicioAno", SqlDbType.Smallint).Value = Me.iPeriodoInicioAno
        cmdSQL.Parameters.Add("@iPeriodoFinMes", SqlDbType.Tinyint).Value = Me.iPeriodoFinMes
        cmdSQL.Parameters.Add("@iPeriodoFinAno", SqlDbType.Smallint).Value = Me.iPeriodoFinAno
        cmdSQL.Parameters.Add("@dFechaIni", SqlDbType.Date).Value = Me.dFechaIni
        cmdSQL.Parameters.Add("@dFechaFin", SqlDbType.Date).Value = Me.dFechaFin
        cmdSQL.Parameters.Add("@bActualmenteTrabajado", SqlDbType.Bit).Value = Me.bActualmenteTrabajado
        cmdSQL.Parameters.Add("@bObservado", SqlDbType.Bit).Value = Me.bObservado
        cmdSQL.Parameters.Add("@cObservacionExperiencia", SqlDbType.Varchar, -1).Value = Me.cObservacionExperiencia
        cmdSQL.Parameters.Add("@cReferenciaPersona", SqlDbType.Varchar, 150).Value = Me.cReferenciaPersona
        cmdSQL.Parameters.Add("@cReferenciaPuesto", SqlDbType.Varchar, 70).Value = Me.cReferenciaPuesto
        cmdSQL.Parameters.Add("@cReferenciaFono", SqlDbType.Varchar, 30).Value = Me.cReferenciaFono
        cmdSQL.Parameters.Add("@cReferenciaCalificacion", SqlDbType.Varchar, 2).Value = Me.cReferenciaCalificacion
        cmdSQL.Parameters.Add("@cReferenciaObs", SqlDbType.Varchar, -1).Value = Me.cReferenciaObs
        cmdSQL.Parameters.Add("@dFechaValidacionExperiencia", SqlDbType.Date).Value = Me.dFechaValidacionExperiencia
        cmdSQL.Parameters.Add("@iCodUsuarioValidaExperiencia", SqlDbType.Int).Value = Me.iCodUsuarioValidaExperiencia
        cmdSQL.Parameters.Add("@cUrlDocumento", SqlDbType.Varchar, -1).Value = Me.cUrlDocumento
        cmdSQL.Parameters.Add("@bActivo", SqlDbType.Bit).Value = Me.bActivo
        cmdSQL.Parameters.Add("@bOcupacion1", SqlDbType.Bit).Value = Me.bOcupacion1
        cmdSQL.Parameters.Add("@bOcupacion2", SqlDbType.Bit).Value = Me.bOcupacion2
        cmdSQL.Parameters.Add("@bDocumentado", SqlDbType.Bit).Value = Me.bDocumentado
        cmdSQL.Parameters.Add("@iCodUsuarioRegistro", SqlDbType.Int).Value = Me.iCodUsuarioRegistro
        cmdSQL.Parameters.Add("@dFechaRegistro", SqlDbType.Datetime).Value = Me.dFechaRegistro
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.Datetime).Value = Me.dFechaSis

        Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
        If pCodInsert > 0 Then
            Me.iCodCandidatoExperienciaLaboral = pCodInsert
        Else
            Me.iCodCandidatoExperienciaLaboral = 0
        End If
    End Sub
    Public Sub InsertarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "INSERT into dbo.CandidatoExperienciaLaboral (iCodCandidatoInforme,iCodOcupacion,iCodCandidatoExperienciaNivel,cSectorExperiencia,cRubroExperiencia,cRegimenExperiencia,cEmpresa,cPuesto,cFuncionesLogros,cDestacariasEmpresa,iPeriodoInicioMes,iPeriodoInicioAno,iPeriodoFinMes,iPeriodoFinAno,dFechaIni,dFechaFin,bActualmenteTrabajado,bObservado,cObservacionExperiencia,cReferenciaPersona,cReferenciaPuesto,cReferenciaFono,cReferenciaCalificacion,cReferenciaObs,dFechaValidacionExperiencia,iCodUsuarioValidaExperiencia,cUrlDocumento,bActivo,bOcupacion1,bOcupacion2,bDocumentado,iCodUsuarioRegistro,dFechaRegistro,iCodUsuario,dFechaSis ) VALUES(@iCodCandidatoInforme,@iCodOcupacion,@iCodCandidatoExperienciaNivel,@cSectorExperiencia,@cRubroExperiencia,@cRegimenExperiencia,@cEmpresa,@cPuesto,@cFuncionesLogros,@cDestacariasEmpresa,@iPeriodoInicioMes,@iPeriodoInicioAno,@iPeriodoFinMes,@iPeriodoFinAno,@dFechaIni,@dFechaFin,@bActualmenteTrabajado,@bObservado,@cObservacionExperiencia,@cReferenciaPersona,@cReferenciaPuesto,@cReferenciaFono,@cReferenciaCalificacion,@cReferenciaObs,@dFechaValidacionExperiencia,@iCodUsuarioValidaExperiencia,@cUrlDocumento,@bActivo,@bOcupacion1,@bOcupacion2,@bDocumentado,@iCodUsuarioRegistro,@dFechaRegistro,@iCodUsuario,@dFechaSis); SELECT SCOPE_IDENTITY(); "
        cmdSQL.Parameters.Add("@iCodCandidatoInforme", SqlDbType.Int).Value = Me.iCodCandidatoInforme
        cmdSQL.Parameters.Add("@iCodOcupacion", SqlDbType.Int).Value = Me.iCodOcupacion
        cmdSQL.Parameters.Add("@iCodCandidatoExperienciaNivel", SqlDbType.Smallint).Value = Me.iCodCandidatoExperienciaNivel
        cmdSQL.Parameters.Add("@cSectorExperiencia", SqlDbType.Varchar, 20).Value = Me.cSectorExperiencia
        cmdSQL.Parameters.Add("@cRubroExperiencia", SqlDbType.Varchar, 50).Value = Me.cRubroExperiencia
        cmdSQL.Parameters.Add("@cRegimenExperiencia", SqlDbType.Varchar, 3).Value = Me.cRegimenExperiencia
        cmdSQL.Parameters.Add("@cEmpresa", SqlDbType.Varchar, 220).Value = Me.cEmpresa
        cmdSQL.Parameters.Add("@cPuesto", SqlDbType.Varchar, 100).Value = Me.cPuesto
        cmdSQL.Parameters.Add("@cFuncionesLogros", SqlDbType.Varchar, -1).Value = Me.cFuncionesLogros
        cmdSQL.Parameters.Add("@cDestacariasEmpresa", SqlDbType.Varchar, -1).Value = Me.cDestacariasEmpresa
        cmdSQL.Parameters.Add("@iPeriodoInicioMes", SqlDbType.Tinyint).Value = Me.iPeriodoInicioMes
        cmdSQL.Parameters.Add("@iPeriodoInicioAno", SqlDbType.Smallint).Value = Me.iPeriodoInicioAno
        cmdSQL.Parameters.Add("@iPeriodoFinMes", SqlDbType.Tinyint).Value = Me.iPeriodoFinMes
        cmdSQL.Parameters.Add("@iPeriodoFinAno", SqlDbType.Smallint).Value = Me.iPeriodoFinAno
        cmdSQL.Parameters.Add("@dFechaIni", SqlDbType.Date).Value = Me.dFechaIni
        cmdSQL.Parameters.Add("@dFechaFin", SqlDbType.Date).Value = Me.dFechaFin
        cmdSQL.Parameters.Add("@bActualmenteTrabajado", SqlDbType.Bit).Value = Me.bActualmenteTrabajado
        cmdSQL.Parameters.Add("@bObservado", SqlDbType.Bit).Value = Me.bObservado
        cmdSQL.Parameters.Add("@cObservacionExperiencia", SqlDbType.Varchar, -1).Value = Me.cObservacionExperiencia
        cmdSQL.Parameters.Add("@cReferenciaPersona", SqlDbType.Varchar, 150).Value = Me.cReferenciaPersona
        cmdSQL.Parameters.Add("@cReferenciaPuesto", SqlDbType.Varchar, 70).Value = Me.cReferenciaPuesto
        cmdSQL.Parameters.Add("@cReferenciaFono", SqlDbType.Varchar, 30).Value = Me.cReferenciaFono
        cmdSQL.Parameters.Add("@cReferenciaCalificacion", SqlDbType.Varchar, 2).Value = Me.cReferenciaCalificacion
        cmdSQL.Parameters.Add("@cReferenciaObs", SqlDbType.Varchar, -1).Value = Me.cReferenciaObs
        cmdSQL.Parameters.Add("@dFechaValidacionExperiencia", SqlDbType.Date).Value = Me.dFechaValidacionExperiencia
        cmdSQL.Parameters.Add("@iCodUsuarioValidaExperiencia", SqlDbType.Int).Value = Me.iCodUsuarioValidaExperiencia
        cmdSQL.Parameters.Add("@cUrlDocumento", SqlDbType.Varchar, -1).Value = Me.cUrlDocumento
        cmdSQL.Parameters.Add("@bActivo", SqlDbType.Bit).Value = Me.bActivo
        cmdSQL.Parameters.Add("@bOcupacion1", SqlDbType.Bit).Value = Me.bOcupacion1
        cmdSQL.Parameters.Add("@bOcupacion2", SqlDbType.Bit).Value = Me.bOcupacion2
        cmdSQL.Parameters.Add("@bDocumentado", SqlDbType.Bit).Value = Me.bDocumentado
        cmdSQL.Parameters.Add("@iCodUsuarioRegistro", SqlDbType.Int).Value = Me.iCodUsuarioRegistro
        cmdSQL.Parameters.Add("@dFechaRegistro", SqlDbType.Datetime).Value = Me.dFechaRegistro
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.Datetime).Value = Me.dFechaSis

        Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
        If pCodInsert > 0 Then
            Me.iCodCandidatoExperienciaLaboral = pCodInsert
        Else
            Me.iCodCandidatoExperienciaLaboral = 0
        End If
    End Sub
    Public Sub Modificar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "UPDATE  dbo.CandidatoExperienciaLaboral SET iCodCandidatoInforme=@iCodCandidatoInforme,iCodOcupacion=@iCodOcupacion,iCodCandidatoExperienciaNivel=@iCodCandidatoExperienciaNivel,cSectorExperiencia=@cSectorExperiencia,cRubroExperiencia=@cRubroExperiencia,cRegimenExperiencia=@cRegimenExperiencia,cEmpresa=@cEmpresa,cPuesto=@cPuesto,cFuncionesLogros=@cFuncionesLogros,cDestacariasEmpresa=@cDestacariasEmpresa,iPeriodoInicioMes=@iPeriodoInicioMes,iPeriodoInicioAno=@iPeriodoInicioAno,iPeriodoFinMes=@iPeriodoFinMes,iPeriodoFinAno=@iPeriodoFinAno,dFechaIni=@dFechaIni,dFechaFin=@dFechaFin,bActualmenteTrabajado=@bActualmenteTrabajado,bObservado=@bObservado,cObservacionExperiencia=@cObservacionExperiencia,cReferenciaPersona=@cReferenciaPersona,cReferenciaPuesto=@cReferenciaPuesto,cReferenciaFono=@cReferenciaFono,cReferenciaCalificacion=@cReferenciaCalificacion,cReferenciaObs=@cReferenciaObs,dFechaValidacionExperiencia=@dFechaValidacionExperiencia,iCodUsuarioValidaExperiencia=@iCodUsuarioValidaExperiencia,cUrlDocumento=@cUrlDocumento,bActivo=@bActivo,bOcupacion1=@bOcupacion1,bOcupacion2=@bOcupacion2,bDocumentado=@bDocumentado,iCodUsuarioRegistro=@iCodUsuarioRegistro,dFechaRegistro=@dFechaRegistro,iCodUsuario=@iCodUsuario,dFechaSis=@dFechaSis WHERE iCodCandidatoExperienciaLaboral=@iCodCandidatoExperienciaLaboral"
        cmdSQL.Parameters.Add("@iCodCandidatoExperienciaLaboral", SqlDbType.Int).Value = Me.iCodCandidatoExperienciaLaboral
        cmdSQL.Parameters.Add("@iCodCandidatoInforme", SqlDbType.Int).Value = Me.iCodCandidatoInforme
        cmdSQL.Parameters.Add("@iCodOcupacion", SqlDbType.Int).Value = Me.iCodOcupacion
        cmdSQL.Parameters.Add("@iCodCandidatoExperienciaNivel", SqlDbType.Smallint).Value = Me.iCodCandidatoExperienciaNivel
        cmdSQL.Parameters.Add("@cSectorExperiencia", SqlDbType.Varchar, 20).Value = Me.cSectorExperiencia
        cmdSQL.Parameters.Add("@cRubroExperiencia", SqlDbType.Varchar, 50).Value = Me.cRubroExperiencia
        cmdSQL.Parameters.Add("@cRegimenExperiencia", SqlDbType.Varchar, 3).Value = Me.cRegimenExperiencia
        cmdSQL.Parameters.Add("@cEmpresa", SqlDbType.Varchar, 220).Value = Me.cEmpresa
        cmdSQL.Parameters.Add("@cPuesto", SqlDbType.Varchar, 100).Value = Me.cPuesto
        cmdSQL.Parameters.Add("@cFuncionesLogros", SqlDbType.Varchar, -1).Value = Me.cFuncionesLogros
        cmdSQL.Parameters.Add("@cDestacariasEmpresa", SqlDbType.Varchar, -1).Value = Me.cDestacariasEmpresa
        cmdSQL.Parameters.Add("@iPeriodoInicioMes", SqlDbType.Tinyint).Value = Me.iPeriodoInicioMes
        cmdSQL.Parameters.Add("@iPeriodoInicioAno", SqlDbType.Smallint).Value = Me.iPeriodoInicioAno
        cmdSQL.Parameters.Add("@iPeriodoFinMes", SqlDbType.Tinyint).Value = Me.iPeriodoFinMes
        cmdSQL.Parameters.Add("@iPeriodoFinAno", SqlDbType.Smallint).Value = Me.iPeriodoFinAno
        cmdSQL.Parameters.Add("@dFechaIni", SqlDbType.Date).Value = Me.dFechaIni
        cmdSQL.Parameters.Add("@dFechaFin", SqlDbType.Date).Value = Me.dFechaFin
        cmdSQL.Parameters.Add("@bActualmenteTrabajado", SqlDbType.Bit).Value = Me.bActualmenteTrabajado
        cmdSQL.Parameters.Add("@bObservado", SqlDbType.Bit).Value = Me.bObservado
        cmdSQL.Parameters.Add("@cObservacionExperiencia", SqlDbType.Varchar, -1).Value = Me.cObservacionExperiencia
        cmdSQL.Parameters.Add("@cReferenciaPersona", SqlDbType.Varchar, 150).Value = Me.cReferenciaPersona
        cmdSQL.Parameters.Add("@cReferenciaPuesto", SqlDbType.Varchar, 70).Value = Me.cReferenciaPuesto
        cmdSQL.Parameters.Add("@cReferenciaFono", SqlDbType.Varchar, 30).Value = Me.cReferenciaFono
        cmdSQL.Parameters.Add("@cReferenciaCalificacion", SqlDbType.Varchar, 2).Value = Me.cReferenciaCalificacion
        cmdSQL.Parameters.Add("@cReferenciaObs", SqlDbType.Varchar, -1).Value = Me.cReferenciaObs
        cmdSQL.Parameters.Add("@dFechaValidacionExperiencia", SqlDbType.Date).Value = Me.dFechaValidacionExperiencia
        cmdSQL.Parameters.Add("@iCodUsuarioValidaExperiencia", SqlDbType.Int).Value = Me.iCodUsuarioValidaExperiencia
        cmdSQL.Parameters.Add("@cUrlDocumento", SqlDbType.Varchar, -1).Value = Me.cUrlDocumento
        cmdSQL.Parameters.Add("@bActivo", SqlDbType.Bit).Value = Me.bActivo
        cmdSQL.Parameters.Add("@bOcupacion1", SqlDbType.Bit).Value = Me.bOcupacion1
        cmdSQL.Parameters.Add("@bOcupacion2", SqlDbType.Bit).Value = Me.bOcupacion2
        cmdSQL.Parameters.Add("@bDocumentado", SqlDbType.Bit).Value = Me.bDocumentado
        cmdSQL.Parameters.Add("@iCodUsuarioRegistro", SqlDbType.Int).Value = Me.iCodUsuarioRegistro
        cmdSQL.Parameters.Add("@dFechaRegistro", SqlDbType.Datetime).Value = Me.dFechaRegistro
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.Datetime).Value = Me.dFechaSis

        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub ModificarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "UPDATE  dbo.CandidatoExperienciaLaboral SET iCodCandidatoInforme=@iCodCandidatoInforme,iCodOcupacion=@iCodOcupacion,iCodCandidatoExperienciaNivel=@iCodCandidatoExperienciaNivel,cSectorExperiencia=@cSectorExperiencia,cRubroExperiencia=@cRubroExperiencia,cRegimenExperiencia=@cRegimenExperiencia,cEmpresa=@cEmpresa,cPuesto=@cPuesto,cFuncionesLogros=@cFuncionesLogros,cDestacariasEmpresa=@cDestacariasEmpresa,iPeriodoInicioMes=@iPeriodoInicioMes,iPeriodoInicioAno=@iPeriodoInicioAno,iPeriodoFinMes=@iPeriodoFinMes,iPeriodoFinAno=@iPeriodoFinAno,dFechaIni=@dFechaIni,dFechaFin=@dFechaFin,bActualmenteTrabajado=@bActualmenteTrabajado,bObservado=@bObservado,cObservacionExperiencia=@cObservacionExperiencia,cReferenciaPersona=@cReferenciaPersona,cReferenciaPuesto=@cReferenciaPuesto,cReferenciaFono=@cReferenciaFono,cReferenciaCalificacion=@cReferenciaCalificacion,cReferenciaObs=@cReferenciaObs,dFechaValidacionExperiencia=@dFechaValidacionExperiencia,iCodUsuarioValidaExperiencia=@iCodUsuarioValidaExperiencia,cUrlDocumento=@cUrlDocumento,bActivo=@bActivo,bOcupacion1=@bOcupacion1,bOcupacion2=@bOcupacion2,bDocumentado=@bDocumentado,iCodUsuarioRegistro=@iCodUsuarioRegistro,dFechaRegistro=@dFechaRegistro,iCodUsuario=@iCodUsuario,dFechaSis=@dFechaSis WHERE iCodCandidatoExperienciaLaboral=@iCodCandidatoExperienciaLaboral"
        cmdSQL.Parameters.Add("@iCodCandidatoExperienciaLaboral", SqlDbType.Int).Value = Me.iCodCandidatoExperienciaLaboral
        cmdSQL.Parameters.Add("@iCodCandidatoInforme", SqlDbType.Int).Value = Me.iCodCandidatoInforme
        cmdSQL.Parameters.Add("@iCodOcupacion", SqlDbType.Int).Value = Me.iCodOcupacion
        cmdSQL.Parameters.Add("@iCodCandidatoExperienciaNivel", SqlDbType.Smallint).Value = Me.iCodCandidatoExperienciaNivel
        cmdSQL.Parameters.Add("@cSectorExperiencia", SqlDbType.Varchar, 20).Value = Me.cSectorExperiencia
        cmdSQL.Parameters.Add("@cRubroExperiencia", SqlDbType.Varchar, 50).Value = Me.cRubroExperiencia
        cmdSQL.Parameters.Add("@cRegimenExperiencia", SqlDbType.Varchar, 3).Value = Me.cRegimenExperiencia
        cmdSQL.Parameters.Add("@cEmpresa", SqlDbType.Varchar, 220).Value = Me.cEmpresa
        cmdSQL.Parameters.Add("@cPuesto", SqlDbType.Varchar, 100).Value = Me.cPuesto
        cmdSQL.Parameters.Add("@cFuncionesLogros", SqlDbType.Varchar, -1).Value = Me.cFuncionesLogros
        cmdSQL.Parameters.Add("@cDestacariasEmpresa", SqlDbType.Varchar, -1).Value = Me.cDestacariasEmpresa
        cmdSQL.Parameters.Add("@iPeriodoInicioMes", SqlDbType.Tinyint).Value = Me.iPeriodoInicioMes
        cmdSQL.Parameters.Add("@iPeriodoInicioAno", SqlDbType.Smallint).Value = Me.iPeriodoInicioAno
        cmdSQL.Parameters.Add("@iPeriodoFinMes", SqlDbType.Tinyint).Value = Me.iPeriodoFinMes
        cmdSQL.Parameters.Add("@iPeriodoFinAno", SqlDbType.Smallint).Value = Me.iPeriodoFinAno
        cmdSQL.Parameters.Add("@dFechaIni", SqlDbType.Date).Value = Me.dFechaIni
        cmdSQL.Parameters.Add("@dFechaFin", SqlDbType.Date).Value = Me.dFechaFin
        cmdSQL.Parameters.Add("@bActualmenteTrabajado", SqlDbType.Bit).Value = Me.bActualmenteTrabajado
        cmdSQL.Parameters.Add("@bObservado", SqlDbType.Bit).Value = Me.bObservado
        cmdSQL.Parameters.Add("@cObservacionExperiencia", SqlDbType.Varchar, -1).Value = Me.cObservacionExperiencia
        cmdSQL.Parameters.Add("@cReferenciaPersona", SqlDbType.Varchar, 150).Value = Me.cReferenciaPersona
        cmdSQL.Parameters.Add("@cReferenciaPuesto", SqlDbType.Varchar, 70).Value = Me.cReferenciaPuesto
        cmdSQL.Parameters.Add("@cReferenciaFono", SqlDbType.Varchar, 30).Value = Me.cReferenciaFono
        cmdSQL.Parameters.Add("@cReferenciaCalificacion", SqlDbType.Varchar, 2).Value = Me.cReferenciaCalificacion
        cmdSQL.Parameters.Add("@cReferenciaObs", SqlDbType.Varchar, -1).Value = Me.cReferenciaObs
        cmdSQL.Parameters.Add("@dFechaValidacionExperiencia", SqlDbType.Date).Value = Me.dFechaValidacionExperiencia
        cmdSQL.Parameters.Add("@iCodUsuarioValidaExperiencia", SqlDbType.Int).Value = Me.iCodUsuarioValidaExperiencia
        cmdSQL.Parameters.Add("@cUrlDocumento", SqlDbType.Varchar, -1).Value = Me.cUrlDocumento
        cmdSQL.Parameters.Add("@bActivo", SqlDbType.Bit).Value = Me.bActivo
        cmdSQL.Parameters.Add("@bOcupacion1", SqlDbType.Bit).Value = Me.bOcupacion1
        cmdSQL.Parameters.Add("@bOcupacion2", SqlDbType.Bit).Value = Me.bOcupacion2
        cmdSQL.Parameters.Add("@bDocumentado", SqlDbType.Bit).Value = Me.bDocumentado
        cmdSQL.Parameters.Add("@iCodUsuarioRegistro", SqlDbType.Int).Value = Me.iCodUsuarioRegistro
        cmdSQL.Parameters.Add("@dFechaRegistro", SqlDbType.Datetime).Value = Me.dFechaRegistro
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.Datetime).Value = Me.dFechaSis

        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub Eliminar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "DELETE from  dbo.CandidatoExperienciaLaboral  WHERE iCodCandidatoExperienciaLaboral=@iCodCandidatoExperienciaLaboral"
        'cmdSQL.CommandText = "UPDATE dbo.CandidatoExperienciaLaboral  SET bAnulado=1 WHERE  iCodCandidatoExperienciaLaboral=@iCodCandidatoExperienciaLaboral"
        cmdSQL.Parameters.Add("@iCodCandidatoExperienciaLaboral", SqlDbType.Int).Value = Me.iCodCandidatoExperienciaLaboral
        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub EliminarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "DELETE from  dbo.CandidatoExperienciaLaboral  WHERE iCodCandidatoExperienciaLaboral=@iCodCandidatoExperienciaLaboral"
        'cmdSQL.CommandText = "UPDATE dbo.CandidatoExperienciaLaboral  SET bAnulado=1 WHERE  iCodCandidatoExperienciaLaboral=@iCodCandidatoExperienciaLaboral"
        cmdSQL.Parameters.Add("@iCodCandidatoExperienciaLaboral", SqlDbType.Int).Value = Me.iCodCandidatoExperienciaLaboral
        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub getRecord()
        Dim readers As IDataReader
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL

        If bTransaccion = True Then cmdSQL.Transaction = Me.mc.miTransact Else 

        cmdSQL.CommandText = "SELECT * FROM dbo.CandidatoExperienciaLaboral WHERE iCodCandidatoExperienciaLaboral=@iCodCandidatoExperienciaLaboral"
        cmdSQL.Parameters.Add("@iCodCandidatoExperienciaLaboral", SqlDbType.Int).Value = Me.iCodCandidatoExperienciaLaboral
        readers = cmdSQL.ExecuteReader
        If readers.Read() Then
            Me.iCodCandidatoExperienciaLaboral = CStr(readers.GetValue(0))
            Me.iCodCandidatoInforme = CStr(readers.GetValue(1))
            Me.iCodOcupacion = CStr(readers.GetValue(2))
            Me.iCodCandidatoExperienciaNivel = CStr(readers.GetValue(3))
            Me.cSectorExperiencia = CStr(readers.GetValue(4))
            Me.cRubroExperiencia = CStr(readers.GetValue(5))
            Me.cRegimenExperiencia = CStr(readers.GetValue(6))
            Me.cEmpresa = CStr(readers.GetValue(7))
            Me.cPuesto = CStr(readers.GetValue(8))
            Me.cFuncionesLogros = CStr(readers.GetValue(9))
            Me.cDestacariasEmpresa = CStr(readers.GetValue(10))
            Me.iPeriodoInicioMes = CStr(readers.GetValue(11))
            Me.iPeriodoInicioAno = CStr(readers.GetValue(12))
            Me.iPeriodoFinMes = CStr(readers.GetValue(13))
            Me.iPeriodoFinAno = CStr(readers.GetValue(14))
            Me.dFechaIni = CStr(readers.GetValue(15))
            Me.dFechaFin = CStr(readers.GetValue(16))
            Me.bActualmenteTrabajado = CStr(readers.GetValue(17))
            Me.bObservado = CStr(readers.GetValue(18))
            Me.cObservacionExperiencia = CStr(readers.GetValue(19))
            Me.cReferenciaPersona = CStr(readers.GetValue(20))
            Me.cReferenciaPuesto = CStr(readers.GetValue(21))
            Me.cReferenciaFono = CStr(readers.GetValue(22))
            Me.cReferenciaCalificacion = CStr(readers.GetValue(23))
            Me.cReferenciaObs = CStr(readers.GetValue(24))
            Me.dFechaValidacionExperiencia = CStr(readers.GetValue(25))
            Me.iCodUsuarioValidaExperiencia = CStr(readers.GetValue(26))
            Me.cUrlDocumento = CStr(readers.GetValue(27))
            Me.bActivo = CStr(readers.GetValue(28))
            Me.bOcupacion1 = CStr(readers.GetValue(29))
            Me.bOcupacion2 = CStr(readers.GetValue(30))
            Me.bDocumentado = CStr(readers.GetValue(31))
            Me.iCodUsuarioRegistro = CStr(readers.GetValue(32))
            Me.dFechaRegistro = CStr(readers.GetValue(33))
            Me.iCodUsuario = CStr(readers.GetValue(34))
            Me.dFechaSis = CStr(readers.GetValue(35))
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
        cmdSQL.CommandText = "SELECT * FROM dbo.CandidatoExperienciaLaboral"
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

    '*********************************************************************



    Public Function ListaExperiencias() As DataTable


        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = "SP_DT_CandidatoExperienciaLaboral"

        cmdSQL.Parameters.Add("@iCodCandidatoInforme", SqlDbType.Int).Value = Me.iCodCandidatoInforme

         
        Dim readers As SqlDataReader
        readers = cmdSQL.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(readers)
        Return dt
    End Function


    Public Function ListaSectorExperiencia() As DataTable
        Dim miDataTable As New DataTable
        miDataTable.Columns.Add("ValueMember")
        miDataTable.Columns.Add("DisplayMember")
        With miDataTable
            .Rows.Add("PRIVADO", "PRIVADO")
            .Rows.Add("PUBLICO", "PÚBLICO")
        End With
        Return miDataTable
    End Function
End Class
