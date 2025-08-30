Imports System.Data.SqlClient
Public Class Contratistacontrato
    Public iCodContratistaContrato As String
    Public iCodContrata As String
    Public cNroContrato As String
    Public cNomContrato As String
    Public cZona As String
    Public iHeadCount As String
    Public cTipoFFLL As String
    Public cTipoContrato As String
    Public cGrupoContrato As String
    Public cFase As String
    Public dFechaTermino As String
    Public iCodClienteArea As String
    Public cAreaUsuaria As String
    Public cAreaUsuariaSupervisor As String
    Public bCerrado As String
    Public iCodRubroIntervencion As String
    Public iCodLineaInversion As String
    Public iCodCliente As String
    Public iCodClienteContrato As String
    Public cProvinciaEjecucion As String
    Public iCodGrupoIntervencion As String
    Public cAreaOperacional As String
    Public cTipoValoracionPGS As String
    Public iMOCForaneo As String
    Public iMOCLocal As String
    Public iMOSCForaneo As String
    Public iMOSCLocal As String
    Public iMONCForaneo As String
    Public iMONCLocal As String
    Public nTasaMOCLocal As String
    Public nTasaMOSCLocal As String
    Public nTasaMONCLocal As String
    Public cAnotaciones As String
    Public dFechaInicio As String
    Public cDatosContacto As String
    Public iEstado As String
    Public cEstado As String
    Public iCodUsuarioEstado As String
    Public dFechaEstado As String
    Public iCodUsuarioEnvio As String
    Public dFechaUsuarioEnvio As String
    Public iCodUsuarioAprueba As String
    Public dFechaUsuarioAprueba As String
    Public bReporteFFLL As String
    Public iCodUsuarioCreacion As String
    Public dFechaCreacion As String
    Public cObs As String
    Public iCodUsuario As String
    Public dFechaSis As String
    Public qSelect As String
    Public cTipoOpe As Char
    Public bTransaccion As Boolean = False
    Public mc As New ConnectSQL
    Public Function ListaDatos() As DataTable
        Dim Query As String
        Dim readers As DataTable
        Query = "SELECT * FROM dbo.ContratistaContrato"
        readers = mc.ExecuteDataTable(Query)
        Return readers
    End Function
    Public Sub Insertar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "INSERT into dbo.ContratistaContrato (iCodContrata,cNroContrato,cNomContrato,cZona,iHeadCount,cTipoFFLL,cTipoContrato,cGrupoContrato,cFase,dFechaTermino,iCodClienteArea,cAreaUsuaria,cAreaUsuariaSupervisor,bCerrado,iCodRubroIntervencion,iCodLineaInversion,iCodCliente,iCodClienteContrato,cProvinciaEjecucion,iCodGrupoIntervencion,cAreaOperacional,cTipoValoracionPGS,iMOCForaneo,iMOCLocal,iMOSCForaneo,iMOSCLocal,iMONCForaneo,iMONCLocal,nTasaMOCLocal,nTasaMOSCLocal,nTasaMONCLocal,cAnotaciones,dFechaInicio,cDatosContacto,iEstado,cEstado,iCodUsuarioEstado,dFechaEstado,iCodUsuarioEnvio,dFechaUsuarioEnvio,iCodUsuarioAprueba,dFechaUsuarioAprueba,bReporteFFLL,iCodUsuarioCreacion,dFechaCreacion,cObs,iCodUsuario,dFechaSis ) VALUES(@iCodContrata,@cNroContrato,@cNomContrato,@cZona,@iHeadCount,@cTipoFFLL,@cTipoContrato,@cGrupoContrato,@cFase,@dFechaTermino,@iCodClienteArea,@cAreaUsuaria,@cAreaUsuariaSupervisor,@bCerrado,@iCodRubroIntervencion,@iCodLineaInversion,@iCodCliente,@iCodClienteContrato,@cProvinciaEjecucion,@iCodGrupoIntervencion,@cAreaOperacional,@cTipoValoracionPGS,@iMOCForaneo,@iMOCLocal,@iMOSCForaneo,@iMOSCLocal,@iMONCForaneo,@iMONCLocal,@nTasaMOCLocal,@nTasaMOSCLocal,@nTasaMONCLocal,@cAnotaciones,@dFechaInicio,@cDatosContacto,@iEstado,@cEstado,@iCodUsuarioEstado,@dFechaEstado,@iCodUsuarioEnvio,@dFechaUsuarioEnvio,@iCodUsuarioAprueba,@dFechaUsuarioAprueba,@bReporteFFLL,@iCodUsuarioCreacion,@dFechaCreacion,@cObs,@iCodUsuario,@dFechaSis); SELECT SCOPE_IDENTITY(); "
        cmdSQL.Parameters.Add("@iCodContrata", SqlDbType.Int).Value = Me.iCodContrata
        cmdSQL.Parameters.Add("@cNroContrato", SqlDbType.Varchar, 50).Value = Me.cNroContrato
        cmdSQL.Parameters.Add("@cNomContrato", SqlDbType.Varchar, 250).Value = Me.cNomContrato
        cmdSQL.Parameters.Add("@cZona", SqlDbType.Varchar, 45).Value = Me.cZona
        cmdSQL.Parameters.Add("@iHeadCount", SqlDbType.Smallint).Value = Me.iHeadCount
        cmdSQL.Parameters.Add("@cTipoFFLL", SqlDbType.Varchar, 5).Value = Me.cTipoFFLL
        cmdSQL.Parameters.Add("@cTipoContrato", SqlDbType.Varchar, 10).Value = Me.cTipoContrato
        cmdSQL.Parameters.Add("@cGrupoContrato", SqlDbType.Varchar, 3).Value = Me.cGrupoContrato
        cmdSQL.Parameters.Add("@cFase", SqlDbType.Varchar, 2).Value = Me.cFase
        cmdSQL.Parameters.Add("@dFechaTermino", SqlDbType.Date).Value = Me.dFechaTermino
        cmdSQL.Parameters.Add("@iCodClienteArea", SqlDbType.Int).Value = Me.iCodClienteArea
        cmdSQL.Parameters.Add("@cAreaUsuaria", SqlDbType.Varchar, 100).Value = Me.cAreaUsuaria
        cmdSQL.Parameters.Add("@cAreaUsuariaSupervisor", SqlDbType.Varchar, 100).Value = Me.cAreaUsuariaSupervisor
        cmdSQL.Parameters.Add("@bCerrado", SqlDbType.Bit).Value = Me.bCerrado
        cmdSQL.Parameters.Add("@iCodRubroIntervencion", SqlDbType.Int).Value = Me.iCodRubroIntervencion
        cmdSQL.Parameters.Add("@iCodLineaInversion", SqlDbType.Int).Value = Me.iCodLineaInversion
        cmdSQL.Parameters.Add("@iCodCliente", SqlDbType.Int).Value = Me.iCodCliente
        cmdSQL.Parameters.Add("@iCodClienteContrato", SqlDbType.Int).Value = Me.iCodClienteContrato
        cmdSQL.Parameters.Add("@cProvinciaEjecucion", SqlDbType.Varchar, 50).Value = Me.cProvinciaEjecucion
        cmdSQL.Parameters.Add("@iCodGrupoIntervencion", SqlDbType.Int).Value = Me.iCodGrupoIntervencion
        cmdSQL.Parameters.Add("@cAreaOperacional", SqlDbType.Varchar, 30).Value = Me.cAreaOperacional
        cmdSQL.Parameters.Add("@cTipoValoracionPGS", SqlDbType.Varchar, 5).Value = Me.cTipoValoracionPGS
        cmdSQL.Parameters.Add("@iMOCForaneo", SqlDbType.Int).Value = Me.iMOCForaneo
        cmdSQL.Parameters.Add("@iMOCLocal", SqlDbType.Int).Value = Me.iMOCLocal
        cmdSQL.Parameters.Add("@iMOSCForaneo", SqlDbType.Int).Value = Me.iMOSCForaneo
        cmdSQL.Parameters.Add("@iMOSCLocal", SqlDbType.Int).Value = Me.iMOSCLocal
        cmdSQL.Parameters.Add("@iMONCForaneo", SqlDbType.Int).Value = Me.iMONCForaneo
        cmdSQL.Parameters.Add("@iMONCLocal", SqlDbType.Int).Value = Me.iMONCLocal
        cmdSQL.Parameters.Add("@nTasaMOCLocal", SqlDbType.Decimal).Value = Me.nTasaMOCLocal
        cmdSQL.Parameters.Add("@nTasaMOSCLocal", SqlDbType.Decimal).Value = Me.nTasaMOSCLocal
        cmdSQL.Parameters.Add("@nTasaMONCLocal", SqlDbType.Decimal).Value = Me.nTasaMONCLocal
        cmdSQL.Parameters.Add("@cAnotaciones", SqlDbType.Varchar, 1000).Value = Me.cAnotaciones
        cmdSQL.Parameters.Add("@dFechaInicio", SqlDbType.Date).Value = Me.dFechaInicio
        cmdSQL.Parameters.Add("@cDatosContacto", SqlDbType.Varchar, -1).Value = Me.cDatosContacto
        cmdSQL.Parameters.Add("@iEstado", SqlDbType.Tinyint).Value = Me.iEstado
        cmdSQL.Parameters.Add("@cEstado", SqlDbType.VarChar, 30).Value = Me.cEstado
        cmdSQL.Parameters.Add("@iCodUsuarioEstado", SqlDbType.Int).Value = Me.iCodUsuarioEstado
        cmdSQL.Parameters.Add("@dFechaEstado", SqlDbType.Datetime).Value = Me.dFechaEstado
        cmdSQL.Parameters.Add("@iCodUsuarioEnvio", SqlDbType.Int).Value = Me.iCodUsuarioEnvio
        cmdSQL.Parameters.Add("@dFechaUsuarioEnvio", SqlDbType.Datetime).Value = Me.dFechaUsuarioEnvio
        cmdSQL.Parameters.Add("@iCodUsuarioAprueba", SqlDbType.Int).Value = Me.iCodUsuarioAprueba
        cmdSQL.Parameters.Add("@dFechaUsuarioAprueba", SqlDbType.Datetime).Value = Me.dFechaUsuarioAprueba
        cmdSQL.Parameters.Add("@bReporteFFLL", SqlDbType.Bit).Value = Me.bReporteFFLL
        cmdSQL.Parameters.Add("@iCodUsuarioCreacion", SqlDbType.Int).Value = Me.iCodUsuarioCreacion
        cmdSQL.Parameters.Add("@dFechaCreacion", SqlDbType.Datetime).Value = Me.dFechaCreacion
        cmdSQL.Parameters.Add("@cObs", SqlDbType.Varchar, -1).Value = Me.cObs
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.Datetime).Value = Me.dFechaSis

        Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
        If pCodInsert > 0 Then
            Me.iCodContratistaContrato = pCodInsert
        Else
            Me.iCodContratistaContrato = 0
        End If
    End Sub
    Public Sub InsertarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "INSERT into dbo.ContratistaContrato (iCodContrata,cNroContrato,cNomContrato,cZona,iHeadCount,cTipoFFLL,cTipoContrato,cGrupoContrato,cFase,dFechaTermino,iCodClienteArea,cAreaUsuaria,cAreaUsuariaSupervisor,bCerrado,iCodRubroIntervencion,iCodLineaInversion,iCodCliente,iCodClienteContrato,cProvinciaEjecucion,iCodGrupoIntervencion,cAreaOperacional,cTipoValoracionPGS,iMOCForaneo,iMOCLocal,iMOSCForaneo,iMOSCLocal,iMONCForaneo,iMONCLocal,nTasaMOCLocal,nTasaMOSCLocal,nTasaMONCLocal,cAnotaciones,dFechaInicio,cDatosContacto,iEstado,cEstado,iCodUsuarioEstado,dFechaEstado,iCodUsuarioEnvio,dFechaUsuarioEnvio,iCodUsuarioAprueba,dFechaUsuarioAprueba,bReporteFFLL,iCodUsuarioCreacion,dFechaCreacion,cObs,iCodUsuario,dFechaSis ) VALUES(@iCodContrata,@cNroContrato,@cNomContrato,@cZona,@iHeadCount,@cTipoFFLL,@cTipoContrato,@cGrupoContrato,@cFase,@dFechaTermino,@iCodClienteArea,@cAreaUsuaria,@cAreaUsuariaSupervisor,@bCerrado,@iCodRubroIntervencion,@iCodLineaInversion,@iCodCliente,@iCodClienteContrato,@cProvinciaEjecucion,@iCodGrupoIntervencion,@cAreaOperacional,@cTipoValoracionPGS,@iMOCForaneo,@iMOCLocal,@iMOSCForaneo,@iMOSCLocal,@iMONCForaneo,@iMONCLocal,@nTasaMOCLocal,@nTasaMOSCLocal,@nTasaMONCLocal,@cAnotaciones,@dFechaInicio,@cDatosContacto,@iEstado,@cEstado,@iCodUsuarioEstado,@dFechaEstado,@iCodUsuarioEnvio,@dFechaUsuarioEnvio,@iCodUsuarioAprueba,@dFechaUsuarioAprueba,@bReporteFFLL,@iCodUsuarioCreacion,@dFechaCreacion,@cObs,@iCodUsuario,@dFechaSis); SELECT SCOPE_IDENTITY(); "
        cmdSQL.Parameters.Add("@iCodContrata", SqlDbType.Int).Value = Me.iCodContrata
        cmdSQL.Parameters.Add("@cNroContrato", SqlDbType.Varchar, 50).Value = Me.cNroContrato
        cmdSQL.Parameters.Add("@cNomContrato", SqlDbType.Varchar, 250).Value = Me.cNomContrato
        cmdSQL.Parameters.Add("@cZona", SqlDbType.Varchar, 45).Value = Me.cZona
        cmdSQL.Parameters.Add("@iHeadCount", SqlDbType.Smallint).Value = Me.iHeadCount
        cmdSQL.Parameters.Add("@cTipoFFLL", SqlDbType.Varchar, 5).Value = Me.cTipoFFLL
        cmdSQL.Parameters.Add("@cTipoContrato", SqlDbType.Varchar, 10).Value = Me.cTipoContrato
        cmdSQL.Parameters.Add("@cGrupoContrato", SqlDbType.Varchar, 3).Value = Me.cGrupoContrato
        cmdSQL.Parameters.Add("@cFase", SqlDbType.Varchar, 2).Value = Me.cFase
        cmdSQL.Parameters.Add("@dFechaTermino", SqlDbType.Date).Value = Me.dFechaTermino
        cmdSQL.Parameters.Add("@iCodClienteArea", SqlDbType.Int).Value = Me.iCodClienteArea
        cmdSQL.Parameters.Add("@cAreaUsuaria", SqlDbType.Varchar, 100).Value = Me.cAreaUsuaria
        cmdSQL.Parameters.Add("@cAreaUsuariaSupervisor", SqlDbType.Varchar, 100).Value = Me.cAreaUsuariaSupervisor
        cmdSQL.Parameters.Add("@bCerrado", SqlDbType.Bit).Value = Me.bCerrado
        cmdSQL.Parameters.Add("@iCodRubroIntervencion", SqlDbType.Int).Value = Me.iCodRubroIntervencion
        cmdSQL.Parameters.Add("@iCodLineaInversion", SqlDbType.Int).Value = Me.iCodLineaInversion
        cmdSQL.Parameters.Add("@iCodCliente", SqlDbType.Int).Value = Me.iCodCliente
        cmdSQL.Parameters.Add("@iCodClienteContrato", SqlDbType.Int).Value = Me.iCodClienteContrato
        cmdSQL.Parameters.Add("@cProvinciaEjecucion", SqlDbType.Varchar, 50).Value = Me.cProvinciaEjecucion
        cmdSQL.Parameters.Add("@iCodGrupoIntervencion", SqlDbType.Int).Value = Me.iCodGrupoIntervencion
        cmdSQL.Parameters.Add("@cAreaOperacional", SqlDbType.Varchar, 30).Value = Me.cAreaOperacional
        cmdSQL.Parameters.Add("@cTipoValoracionPGS", SqlDbType.Varchar, 5).Value = Me.cTipoValoracionPGS
        cmdSQL.Parameters.Add("@iMOCForaneo", SqlDbType.Int).Value = Me.iMOCForaneo
        cmdSQL.Parameters.Add("@iMOCLocal", SqlDbType.Int).Value = Me.iMOCLocal
        cmdSQL.Parameters.Add("@iMOSCForaneo", SqlDbType.Int).Value = Me.iMOSCForaneo
        cmdSQL.Parameters.Add("@iMOSCLocal", SqlDbType.Int).Value = Me.iMOSCLocal
        cmdSQL.Parameters.Add("@iMONCForaneo", SqlDbType.Int).Value = Me.iMONCForaneo
        cmdSQL.Parameters.Add("@iMONCLocal", SqlDbType.Int).Value = Me.iMONCLocal
        cmdSQL.Parameters.Add("@nTasaMOCLocal", SqlDbType.Decimal).Value = Me.nTasaMOCLocal
        cmdSQL.Parameters.Add("@nTasaMOSCLocal", SqlDbType.Decimal).Value = Me.nTasaMOSCLocal
        cmdSQL.Parameters.Add("@nTasaMONCLocal", SqlDbType.Decimal).Value = Me.nTasaMONCLocal
        cmdSQL.Parameters.Add("@cAnotaciones", SqlDbType.Varchar, 1000).Value = Me.cAnotaciones
        cmdSQL.Parameters.Add("@dFechaInicio", SqlDbType.Date).Value = Me.dFechaInicio
        cmdSQL.Parameters.Add("@cDatosContacto", SqlDbType.Varchar, -1).Value = Me.cDatosContacto
        cmdSQL.Parameters.Add("@iEstado", SqlDbType.Tinyint).Value = Me.iEstado
        cmdSQL.Parameters.Add("@cEstado", SqlDbType.VarChar, 30).Value = Me.cEstado
        cmdSQL.Parameters.Add("@iCodUsuarioEstado", SqlDbType.Int).Value = Me.iCodUsuarioEstado
        cmdSQL.Parameters.Add("@dFechaEstado", SqlDbType.Datetime).Value = Me.dFechaEstado
        cmdSQL.Parameters.Add("@iCodUsuarioEnvio", SqlDbType.Int).Value = Me.iCodUsuarioEnvio
        cmdSQL.Parameters.Add("@dFechaUsuarioEnvio", SqlDbType.Datetime).Value = Me.dFechaUsuarioEnvio
        cmdSQL.Parameters.Add("@iCodUsuarioAprueba", SqlDbType.Int).Value = Me.iCodUsuarioAprueba
        cmdSQL.Parameters.Add("@dFechaUsuarioAprueba", SqlDbType.Datetime).Value = Me.dFechaUsuarioAprueba
        cmdSQL.Parameters.Add("@bReporteFFLL", SqlDbType.Bit).Value = Me.bReporteFFLL
        cmdSQL.Parameters.Add("@iCodUsuarioCreacion", SqlDbType.Int).Value = Me.iCodUsuarioCreacion
        cmdSQL.Parameters.Add("@dFechaCreacion", SqlDbType.Datetime).Value = Me.dFechaCreacion
        cmdSQL.Parameters.Add("@cObs", SqlDbType.Varchar, -1).Value = Me.cObs
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.Datetime).Value = Me.dFechaSis

        Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
        If pCodInsert > 0 Then
            Me.iCodContratistaContrato = pCodInsert
        Else
            Me.iCodContratistaContrato = 0
        End If
    End Sub
    Public Sub Modificar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "UPDATE  dbo.ContratistaContrato SET iCodContrata=@iCodContrata,cNroContrato=@cNroContrato,cNomContrato=@cNomContrato,cZona=@cZona,iHeadCount=@iHeadCount,cTipoFFLL=@cTipoFFLL,cTipoContrato=@cTipoContrato,cGrupoContrato=@cGrupoContrato,cFase=@cFase,dFechaTermino=@dFechaTermino,iCodClienteArea=@iCodClienteArea,cAreaUsuaria=@cAreaUsuaria,cAreaUsuariaSupervisor=@cAreaUsuariaSupervisor,bCerrado=@bCerrado,iCodRubroIntervencion=@iCodRubroIntervencion,iCodLineaInversion=@iCodLineaInversion,iCodCliente=@iCodCliente,iCodClienteContrato=@iCodClienteContrato,cProvinciaEjecucion=@cProvinciaEjecucion,iCodGrupoIntervencion=@iCodGrupoIntervencion,cAreaOperacional=@cAreaOperacional,cTipoValoracionPGS=@cTipoValoracionPGS,iMOCForaneo=@iMOCForaneo,iMOCLocal=@iMOCLocal,iMOSCForaneo=@iMOSCForaneo,iMOSCLocal=@iMOSCLocal,iMONCForaneo=@iMONCForaneo,iMONCLocal=@iMONCLocal,nTasaMOCLocal=@nTasaMOCLocal,nTasaMOSCLocal=@nTasaMOSCLocal,nTasaMONCLocal=@nTasaMONCLocal,cAnotaciones=@cAnotaciones,dFechaInicio=@dFechaInicio,cDatosContacto=@cDatosContacto,iEstado=@iEstado,cEstado=@cEstado,iCodUsuarioEstado=@iCodUsuarioEstado,dFechaEstado=@dFechaEstado,iCodUsuarioEnvio=@iCodUsuarioEnvio,dFechaUsuarioEnvio=@dFechaUsuarioEnvio,iCodUsuarioAprueba=@iCodUsuarioAprueba,dFechaUsuarioAprueba=@dFechaUsuarioAprueba,bReporteFFLL=@bReporteFFLL,iCodUsuarioCreacion=@iCodUsuarioCreacion,dFechaCreacion=@dFechaCreacion,cObs=@cObs,iCodUsuario=@iCodUsuario,dFechaSis=@dFechaSis WHERE iCodContratistaContrato=@iCodContratistaContrato"
        cmdSQL.Parameters.Add("@iCodContratistaContrato", SqlDbType.Smallint).Value = Me.iCodContratistaContrato
        cmdSQL.Parameters.Add("@iCodContrata", SqlDbType.Int).Value = Me.iCodContrata
        cmdSQL.Parameters.Add("@cNroContrato", SqlDbType.Varchar, 50).Value = Me.cNroContrato
        cmdSQL.Parameters.Add("@cNomContrato", SqlDbType.Varchar, 250).Value = Me.cNomContrato
        cmdSQL.Parameters.Add("@cZona", SqlDbType.Varchar, 45).Value = Me.cZona
        cmdSQL.Parameters.Add("@iHeadCount", SqlDbType.Smallint).Value = Me.iHeadCount
        cmdSQL.Parameters.Add("@cTipoFFLL", SqlDbType.Varchar, 5).Value = Me.cTipoFFLL
        cmdSQL.Parameters.Add("@cTipoContrato", SqlDbType.Varchar, 10).Value = Me.cTipoContrato
        cmdSQL.Parameters.Add("@cGrupoContrato", SqlDbType.Varchar, 3).Value = Me.cGrupoContrato
        cmdSQL.Parameters.Add("@cFase", SqlDbType.Varchar, 2).Value = Me.cFase
        cmdSQL.Parameters.Add("@dFechaTermino", SqlDbType.Date).Value = Me.dFechaTermino
        cmdSQL.Parameters.Add("@iCodClienteArea", SqlDbType.Int).Value = Me.iCodClienteArea
        cmdSQL.Parameters.Add("@cAreaUsuaria", SqlDbType.Varchar, 100).Value = Me.cAreaUsuaria
        cmdSQL.Parameters.Add("@cAreaUsuariaSupervisor", SqlDbType.Varchar, 100).Value = Me.cAreaUsuariaSupervisor
        cmdSQL.Parameters.Add("@bCerrado", SqlDbType.Bit).Value = Me.bCerrado
        cmdSQL.Parameters.Add("@iCodRubroIntervencion", SqlDbType.Int).Value = Me.iCodRubroIntervencion
        cmdSQL.Parameters.Add("@iCodLineaInversion", SqlDbType.Int).Value = Me.iCodLineaInversion
        cmdSQL.Parameters.Add("@iCodCliente", SqlDbType.Int).Value = Me.iCodCliente
        cmdSQL.Parameters.Add("@iCodClienteContrato", SqlDbType.Int).Value = Me.iCodClienteContrato
        cmdSQL.Parameters.Add("@cProvinciaEjecucion", SqlDbType.Varchar, 50).Value = Me.cProvinciaEjecucion
        cmdSQL.Parameters.Add("@iCodGrupoIntervencion", SqlDbType.Int).Value = Me.iCodGrupoIntervencion
        cmdSQL.Parameters.Add("@cAreaOperacional", SqlDbType.Varchar, 30).Value = Me.cAreaOperacional
        cmdSQL.Parameters.Add("@cTipoValoracionPGS", SqlDbType.Varchar, 5).Value = Me.cTipoValoracionPGS
        cmdSQL.Parameters.Add("@iMOCForaneo", SqlDbType.Int).Value = Me.iMOCForaneo
        cmdSQL.Parameters.Add("@iMOCLocal", SqlDbType.Int).Value = Me.iMOCLocal
        cmdSQL.Parameters.Add("@iMOSCForaneo", SqlDbType.Int).Value = Me.iMOSCForaneo
        cmdSQL.Parameters.Add("@iMOSCLocal", SqlDbType.Int).Value = Me.iMOSCLocal
        cmdSQL.Parameters.Add("@iMONCForaneo", SqlDbType.Int).Value = Me.iMONCForaneo
        cmdSQL.Parameters.Add("@iMONCLocal", SqlDbType.Int).Value = Me.iMONCLocal
        cmdSQL.Parameters.Add("@nTasaMOCLocal", SqlDbType.Decimal).Value = Me.nTasaMOCLocal
        cmdSQL.Parameters.Add("@nTasaMOSCLocal", SqlDbType.Decimal).Value = Me.nTasaMOSCLocal
        cmdSQL.Parameters.Add("@nTasaMONCLocal", SqlDbType.Decimal).Value = Me.nTasaMONCLocal
        cmdSQL.Parameters.Add("@cAnotaciones", SqlDbType.Varchar, 1000).Value = Me.cAnotaciones
        cmdSQL.Parameters.Add("@dFechaInicio", SqlDbType.Date).Value = Me.dFechaInicio
        cmdSQL.Parameters.Add("@cDatosContacto", SqlDbType.Varchar, -1).Value = Me.cDatosContacto
        cmdSQL.Parameters.Add("@iEstado", SqlDbType.Tinyint).Value = Me.iEstado
        cmdSQL.Parameters.Add("@cEstado", SqlDbType.VarChar, 30).Value = Me.cEstado
        cmdSQL.Parameters.Add("@iCodUsuarioEstado", SqlDbType.Int).Value = Me.iCodUsuarioEstado
        cmdSQL.Parameters.Add("@dFechaEstado", SqlDbType.Datetime).Value = Me.dFechaEstado
        cmdSQL.Parameters.Add("@iCodUsuarioEnvio", SqlDbType.Int).Value = Me.iCodUsuarioEnvio
        cmdSQL.Parameters.Add("@dFechaUsuarioEnvio", SqlDbType.Datetime).Value = Me.dFechaUsuarioEnvio
        cmdSQL.Parameters.Add("@iCodUsuarioAprueba", SqlDbType.Int).Value = Me.iCodUsuarioAprueba
        cmdSQL.Parameters.Add("@dFechaUsuarioAprueba", SqlDbType.Datetime).Value = Me.dFechaUsuarioAprueba
        cmdSQL.Parameters.Add("@bReporteFFLL", SqlDbType.Bit).Value = Me.bReporteFFLL
        cmdSQL.Parameters.Add("@iCodUsuarioCreacion", SqlDbType.Int).Value = Me.iCodUsuarioCreacion
        cmdSQL.Parameters.Add("@dFechaCreacion", SqlDbType.Datetime).Value = Me.dFechaCreacion
        cmdSQL.Parameters.Add("@cObs", SqlDbType.Varchar, -1).Value = Me.cObs
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.Datetime).Value = Me.dFechaSis

        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub ModificarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "UPDATE  dbo.ContratistaContrato SET iCodContrata=@iCodContrata,cNroContrato=@cNroContrato,cNomContrato=@cNomContrato,cZona=@cZona,iHeadCount=@iHeadCount,cTipoFFLL=@cTipoFFLL,cTipoContrato=@cTipoContrato,cGrupoContrato=@cGrupoContrato,cFase=@cFase,dFechaTermino=@dFechaTermino,iCodClienteArea=@iCodClienteArea,cAreaUsuaria=@cAreaUsuaria,cAreaUsuariaSupervisor=@cAreaUsuariaSupervisor,bCerrado=@bCerrado,iCodRubroIntervencion=@iCodRubroIntervencion,iCodLineaInversion=@iCodLineaInversion,iCodCliente=@iCodCliente,iCodClienteContrato=@iCodClienteContrato,cProvinciaEjecucion=@cProvinciaEjecucion,iCodGrupoIntervencion=@iCodGrupoIntervencion,cAreaOperacional=@cAreaOperacional,cTipoValoracionPGS=@cTipoValoracionPGS,iMOCForaneo=@iMOCForaneo,iMOCLocal=@iMOCLocal,iMOSCForaneo=@iMOSCForaneo,iMOSCLocal=@iMOSCLocal,iMONCForaneo=@iMONCForaneo,iMONCLocal=@iMONCLocal,nTasaMOCLocal=@nTasaMOCLocal,nTasaMOSCLocal=@nTasaMOSCLocal,nTasaMONCLocal=@nTasaMONCLocal,cAnotaciones=@cAnotaciones,dFechaInicio=@dFechaInicio,cDatosContacto=@cDatosContacto,iEstado=@iEstado,cEstado=@cEstado,iCodUsuarioEstado=@iCodUsuarioEstado,dFechaEstado=@dFechaEstado,iCodUsuarioEnvio=@iCodUsuarioEnvio,dFechaUsuarioEnvio=@dFechaUsuarioEnvio,iCodUsuarioAprueba=@iCodUsuarioAprueba,dFechaUsuarioAprueba=@dFechaUsuarioAprueba,bReporteFFLL=@bReporteFFLL,iCodUsuarioCreacion=@iCodUsuarioCreacion,dFechaCreacion=@dFechaCreacion,cObs=@cObs,iCodUsuario=@iCodUsuario,dFechaSis=@dFechaSis WHERE iCodContratistaContrato=@iCodContratistaContrato"
        cmdSQL.Parameters.Add("@iCodContratistaContrato", SqlDbType.Smallint).Value = Me.iCodContratistaContrato
        cmdSQL.Parameters.Add("@iCodContrata", SqlDbType.Int).Value = Me.iCodContrata
        cmdSQL.Parameters.Add("@cNroContrato", SqlDbType.Varchar, 50).Value = Me.cNroContrato
        cmdSQL.Parameters.Add("@cNomContrato", SqlDbType.Varchar, 250).Value = Me.cNomContrato
        cmdSQL.Parameters.Add("@cZona", SqlDbType.Varchar, 45).Value = Me.cZona
        cmdSQL.Parameters.Add("@iHeadCount", SqlDbType.Smallint).Value = Me.iHeadCount
        cmdSQL.Parameters.Add("@cTipoFFLL", SqlDbType.Varchar, 5).Value = Me.cTipoFFLL
        cmdSQL.Parameters.Add("@cTipoContrato", SqlDbType.Varchar, 10).Value = Me.cTipoContrato
        cmdSQL.Parameters.Add("@cGrupoContrato", SqlDbType.Varchar, 3).Value = Me.cGrupoContrato
        cmdSQL.Parameters.Add("@cFase", SqlDbType.Varchar, 2).Value = Me.cFase
        cmdSQL.Parameters.Add("@dFechaTermino", SqlDbType.Date).Value = Me.dFechaTermino
        cmdSQL.Parameters.Add("@iCodClienteArea", SqlDbType.Int).Value = Me.iCodClienteArea
        cmdSQL.Parameters.Add("@cAreaUsuaria", SqlDbType.Varchar, 100).Value = Me.cAreaUsuaria
        cmdSQL.Parameters.Add("@cAreaUsuariaSupervisor", SqlDbType.Varchar, 100).Value = Me.cAreaUsuariaSupervisor
        cmdSQL.Parameters.Add("@bCerrado", SqlDbType.Bit).Value = Me.bCerrado
        cmdSQL.Parameters.Add("@iCodRubroIntervencion", SqlDbType.Int).Value = Me.iCodRubroIntervencion
        cmdSQL.Parameters.Add("@iCodLineaInversion", SqlDbType.Int).Value = Me.iCodLineaInversion
        cmdSQL.Parameters.Add("@iCodCliente", SqlDbType.Int).Value = Me.iCodCliente
        cmdSQL.Parameters.Add("@iCodClienteContrato", SqlDbType.Int).Value = Me.iCodClienteContrato
        cmdSQL.Parameters.Add("@cProvinciaEjecucion", SqlDbType.Varchar, 50).Value = Me.cProvinciaEjecucion
        cmdSQL.Parameters.Add("@iCodGrupoIntervencion", SqlDbType.Int).Value = Me.iCodGrupoIntervencion
        cmdSQL.Parameters.Add("@cAreaOperacional", SqlDbType.Varchar, 30).Value = Me.cAreaOperacional
        cmdSQL.Parameters.Add("@cTipoValoracionPGS", SqlDbType.Varchar, 5).Value = Me.cTipoValoracionPGS
        cmdSQL.Parameters.Add("@iMOCForaneo", SqlDbType.Int).Value = Me.iMOCForaneo
        cmdSQL.Parameters.Add("@iMOCLocal", SqlDbType.Int).Value = Me.iMOCLocal
        cmdSQL.Parameters.Add("@iMOSCForaneo", SqlDbType.Int).Value = Me.iMOSCForaneo
        cmdSQL.Parameters.Add("@iMOSCLocal", SqlDbType.Int).Value = Me.iMOSCLocal
        cmdSQL.Parameters.Add("@iMONCForaneo", SqlDbType.Int).Value = Me.iMONCForaneo
        cmdSQL.Parameters.Add("@iMONCLocal", SqlDbType.Int).Value = Me.iMONCLocal
        cmdSQL.Parameters.Add("@nTasaMOCLocal", SqlDbType.Decimal).Value = Me.nTasaMOCLocal
        cmdSQL.Parameters.Add("@nTasaMOSCLocal", SqlDbType.Decimal).Value = Me.nTasaMOSCLocal
        cmdSQL.Parameters.Add("@nTasaMONCLocal", SqlDbType.Decimal).Value = Me.nTasaMONCLocal
        cmdSQL.Parameters.Add("@cAnotaciones", SqlDbType.Varchar, 1000).Value = Me.cAnotaciones
        cmdSQL.Parameters.Add("@dFechaInicio", SqlDbType.Date).Value = Me.dFechaInicio
        cmdSQL.Parameters.Add("@cDatosContacto", SqlDbType.Varchar, -1).Value = Me.cDatosContacto
        cmdSQL.Parameters.Add("@iEstado", SqlDbType.Tinyint).Value = Me.iEstado
        cmdSQL.Parameters.Add("@cEstado", SqlDbType.VarChar, 30).Value = Me.cEstado
        cmdSQL.Parameters.Add("@iCodUsuarioEstado", SqlDbType.Int).Value = Me.iCodUsuarioEstado
        cmdSQL.Parameters.Add("@dFechaEstado", SqlDbType.Datetime).Value = Me.dFechaEstado
        cmdSQL.Parameters.Add("@iCodUsuarioEnvio", SqlDbType.Int).Value = Me.iCodUsuarioEnvio
        cmdSQL.Parameters.Add("@dFechaUsuarioEnvio", SqlDbType.Datetime).Value = Me.dFechaUsuarioEnvio
        cmdSQL.Parameters.Add("@iCodUsuarioAprueba", SqlDbType.Int).Value = Me.iCodUsuarioAprueba
        cmdSQL.Parameters.Add("@dFechaUsuarioAprueba", SqlDbType.Datetime).Value = Me.dFechaUsuarioAprueba
        cmdSQL.Parameters.Add("@bReporteFFLL", SqlDbType.Bit).Value = Me.bReporteFFLL
        cmdSQL.Parameters.Add("@iCodUsuarioCreacion", SqlDbType.Int).Value = Me.iCodUsuarioCreacion
        cmdSQL.Parameters.Add("@dFechaCreacion", SqlDbType.Datetime).Value = Me.dFechaCreacion
        cmdSQL.Parameters.Add("@cObs", SqlDbType.Varchar, -1).Value = Me.cObs
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.Datetime).Value = Me.dFechaSis

        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub Eliminar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "DELETE from  dbo.ContratistaContrato  WHERE iCodContratistaContrato=@iCodContratistaContrato"
        'cmdSQL.CommandText = "UPDATE dbo.ContratistaContrato  SET bAnulado=1 WHERE  iCodContratistaContrato=@iCodContratistaContrato"
        cmdSQL.Parameters.Add("@iCodContratistaContrato", SqlDbType.Smallint).Value = Me.iCodContratistaContrato
        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub EliminarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "DELETE from  dbo.ContratistaContrato  WHERE iCodContratistaContrato=@iCodContratistaContrato"
        'cmdSQL.CommandText = "UPDATE dbo.ContratistaContrato  SET bAnulado=1 WHERE  iCodContratistaContrato=@iCodContratistaContrato"
        cmdSQL.Parameters.Add("@iCodContratistaContrato", SqlDbType.Smallint).Value = Me.iCodContratistaContrato
        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub getRecord()
        Dim readers As IDataReader
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL

        If bTransaccion = True Then cmdSQL.Transaction = Me.mc.miTransact Else 

        cmdSQL.CommandText = "SELECT * FROM dbo.ContratistaContrato WHERE iCodContratistaContrato=@iCodContratistaContrato"
        cmdSQL.Parameters.Add("@iCodContratistaContrato", SqlDbType.Smallint).Value = Me.iCodContratistaContrato
        readers = cmdSQL.ExecuteReader
        If readers.Read() Then
            Me.iCodContratistaContrato = CStr(readers.GetValue(0))
            Me.iCodContrata = CStr(readers.GetValue(1))
            Me.cNroContrato = CStr(readers.GetValue(2))
            Me.cNomContrato = CStr(readers.GetValue(3))
            Me.cZona = CStr(readers.GetValue(4))
            Me.iHeadCount = CStr(readers.GetValue(5))
            Me.cTipoFFLL = CStr(readers.GetValue(6))
            Me.cTipoContrato = CStr(readers.GetValue(7))
            Me.cGrupoContrato = CStr(readers.GetValue(8))
            Me.cFase = CStr(readers.GetValue(9))
            Me.dFechaTermino = CStr(readers.GetValue(10))
            Me.iCodClienteArea = CStr(readers.GetValue(11))
            Me.cAreaUsuaria = CStr(readers.GetValue(12))
            Me.cAreaUsuariaSupervisor = CStr(readers.GetValue(13))
            Me.bCerrado = CStr(readers.GetValue(14))
            Me.iCodRubroIntervencion = CStr(readers.GetValue(15))
            Me.iCodLineaInversion = CStr(readers.GetValue(16))
            Me.iCodCliente = CStr(readers.GetValue(17))
            Me.iCodClienteContrato = CStr(readers.GetValue(18))
            Me.cProvinciaEjecucion = CStr(readers.GetValue(19))
            Me.iCodGrupoIntervencion = CStr(readers.GetValue(20))
            Me.cAreaOperacional = CStr(readers.GetValue(21))
            Me.cTipoValoracionPGS = CStr(readers.GetValue(22))
            Me.iMOCForaneo = CStr(readers.GetValue(23))
            Me.iMOCLocal = CStr(readers.GetValue(24))
            Me.iMOSCForaneo = CStr(readers.GetValue(25))
            Me.iMOSCLocal = CStr(readers.GetValue(26))
            Me.iMONCForaneo = CStr(readers.GetValue(27))
            Me.iMONCLocal = CStr(readers.GetValue(28))
            Me.nTasaMOCLocal = CStr(readers.GetValue(29))
            Me.nTasaMOSCLocal = CStr(readers.GetValue(30))
            Me.nTasaMONCLocal = CStr(readers.GetValue(31))
            Me.cAnotaciones = CStr(readers.GetValue(32))
            Me.dFechaInicio = CStr(readers.GetValue(33))
            Me.cDatosContacto = CStr(readers.GetValue(34))
            Me.iEstado = CStr(readers.GetValue(35))
            Me.cEstado = CStr(readers.GetValue(36))
            Me.iCodUsuarioEstado = CStr(readers.GetValue(37))
            Me.dFechaEstado = CStr(readers.GetValue(38))
            Me.iCodUsuarioEnvio = CStr(readers.GetValue(39))
            Me.dFechaUsuarioEnvio = CStr(readers.GetValue(40))
            Me.iCodUsuarioAprueba = CStr(readers.GetValue(41))
            Me.dFechaUsuarioAprueba = CStr(readers.GetValue(42))
            Me.bReporteFFLL = CStr(readers.GetValue(43))
            Me.iCodUsuarioCreacion = CStr(readers.GetValue(44))
            Me.dFechaCreacion = CStr(readers.GetValue(45))
            Me.cObs = CStr(readers.GetValue(46))
            Me.iCodUsuario = CStr(readers.GetValue(47))
            Me.dFechaSis = CStr(readers.GetValue(48))
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
        cmdSQL.CommandText = "SELECT * FROM dbo.ContratistaContrato"
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

    '*********************************************************************************************
    Public Function ListaContratos() As DataTable
        'Dim Query As String
        'Query = String.Format("SELECT iCodContratistaContrato as ValueMember,cGrupoContrato + ' ' + cNroContrato as DisplayMember FROM Contratistacontrato where iCodContrata={0}", Me.iCodContrata)
        'Return mc.ExecuteDataTable(Query)
        If Me.iCodContrata = "" Or Me.iCodContrata Is Nothing Then
            Me.iCodContrata = -1
        End If
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = "SP_DT_ContratosByContrata"
        cmdSQL.Parameters.Add("@iCodContrata", SqlDbType.Int).Value = Me.iCodContrata
        

        Dim readers As SqlDataReader
        readers = cmdSQL.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(readers)
        Return dt

    End Function
    Public Function ListaContratosCompletoPorContrata() As DataTable
        'Dim Query As String
        'Query = String.Format("SELECT iCodContratistaContrato as ValueMember,cGrupoContrato + ' ' + cNroContrato as DisplayMember FROM Contratistacontrato where iCodContrata={0}", Me.iCodContrata)
        'Return mc.ExecuteDataTable(Query)
        If Me.iCodContrata = "" Or Me.iCodContrata Is Nothing Then
            Me.iCodContrata = -1
        End If
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = "SP_DTW_ContratosPorContrata"
        cmdSQL.Parameters.Add("@iCodContrata", SqlDbType.Int).Value = Me.iCodContrata


        Dim readers As SqlDataReader
        readers = cmdSQL.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(readers)
        Return dt

    End Function
    Public Function GetContratistaContratoPorCodigo(ByVal _iCodContratistaContrato As Integer) As DataTable
        Dim Query As String = ""
        Dim readers As DataTable

        Query = " exec dbo.SP_ROW_ContratistaContrato" &
                       " @iCodContratistaContrato=" & Trim(_iCodContratistaContrato)

        readers = mc.ExecuteDataTable(Query)
        Return readers
    End Function
    Public Function AnulacionContratistaContrato() As Integer
        'Dim Query As String = ""
        'Dim readers As IDataReader
        'Dim respuesta As Integer

        'Query = " exec dbo.SP_ACTU_ContratistaContratoAnulacion" &
        '               " @iCodContratistaContrato=" & Trim(_iCodContratistaContrato)

        'readers = mc.ExecuteReader(Query)
        'While readers.Read()
        '    respuesta = CInt(readers.GetValue(0))
        'End While
        'Return respuesta

        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = "dbo.SP_ACTU_ContratistaContratoAnulacion"
        cmdSQL.Parameters.Add("@iCodContratistaContrato", SqlDbType.Int).Value = Me.iCodContratistaContrato
        cmdSQL.Parameters.Add("@dFechaEstado", SqlDbType.DateTime).Value = Me.dFechaEstado
        cmdSQL.Parameters.Add("@iCodUsuarioEstado", SqlDbType.Int).Value = Me.iCodUsuarioEstado

        Return CInt(cmdSQL.ExecuteScalar())
    End Function

    Public Sub UpdateContrato()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "UPDATE  dbo.ContratistaContrato SET iCodContrata=@iCodContrata,cNroContrato=@cNroContrato,cNomContrato=@cNomContrato,cZona=@cZona,iHeadCount=@iHeadCount,dFechaTermino=@dFechaTermino,cAreaUsuaria=@cAreaUsuaria,cAreaUsuariaSupervisor=@cAreaUsuariaSupervisor,cDatosContacto=@cDatosContacto,iCodUsuario=@iCodUsuario,dFechaSis=@dFechaSis WHERE iCodContratistaContrato=@iCodContratistaContrato"
        cmdSQL.Parameters.Add("@iCodContratistaContrato", SqlDbType.SmallInt).Value = Me.iCodContratistaContrato
        cmdSQL.Parameters.Add("@iCodContrata", SqlDbType.Int).Value = Me.iCodContrata
        cmdSQL.Parameters.Add("@cNroContrato", SqlDbType.VarChar, 50).Value = Me.cNroContrato
        cmdSQL.Parameters.Add("@cNomContrato", SqlDbType.VarChar, 250).Value = Me.cNomContrato
        cmdSQL.Parameters.Add("@cZona", SqlDbType.VarChar, 45).Value = Me.cZona
        cmdSQL.Parameters.Add("@iHeadCount", SqlDbType.SmallInt).Value = Me.iHeadCount
        cmdSQL.Parameters.Add("@dFechaTermino", SqlDbType.Date).Value = Me.dFechaTermino
        cmdSQL.Parameters.Add("@cAreaUsuaria", SqlDbType.VarChar, 100).Value = Me.cAreaUsuaria
        cmdSQL.Parameters.Add("@cAreaUsuariaSupervisor", SqlDbType.VarChar, 100).Value = Me.cAreaUsuariaSupervisor
        cmdSQL.Parameters.Add("@cDatosContacto", SqlDbType.VarChar, -1).Value = Me.cDatosContacto
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.DateTime).Value = Me.dFechaSis

        cmdSQL.ExecuteNonQuery()
    End Sub
End Class
