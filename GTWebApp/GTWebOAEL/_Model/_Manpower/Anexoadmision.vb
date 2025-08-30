Imports System.Data.SqlClient

Public Class Anexoadmision
    Public iCodAnexoAdmision As String
    Public iCodContrata As String
    Public iCodContratistaContrato As String
    Public iCodAnexoAdmisionTipo As String
    Public iCodConvocatoriaMain As String
    Public iCodSubContrata As String
    Public iCodCliente As String
    Public iCodClienteArea As String
    Public cGrupo As String
    Public dFechaSolicitud As String
    Public cNroAnexo As String
    Public iCorrelativo As String
    Public iPeriodo As String
    Public iCodPersonaGestor As String
    Public cPersonaSolicita As String
    Public cPersonaSolicitaCargo As String
    Public cAreaUsuaria As String
    Public cNotas As String
    Public cTipo As String
    Public cEstado As String
    Public iCodUsuarioRegistra As String
    Public dFechaRegistro As String
    Public iCodUsuarioContrataEnvia As String
    Public dFechaUsuarioContrataEnvia As String
    Public iCodUsuarioValidaDoc As String
    Public dFechaValidaDoc As String
    Public iCodUsuarioAprueba As String
    Public dFechaAprobacion As String
    Public bAprobadoAAQ As String
    Public dFechaAprobadoAAQ As String
    Public cNotasAprobadoAAQ As String
    Public iCodUsuarioAprobadoAAQ As String
    Public dFechaUsuarioAprobadoAAQ As String
    Public bNotificado As String
    Public iCodUsuarioNotifica As String
    Public dFechaNotifica As String
    Public cCorreoNotifica As String
    Public cNotasNotifica As String
    Public bApruebaAreaAAQ As String
    Public dFechaApruebaAreaAAQ As String
    Public cNotasApruebaAreaAAQ As String
    Public iCodUsuarioApruebaAreaAAQ As String
    Public dFechaUsuarioApruebaAreaAAQ As String
    Public cObsDocumento As String
    Public cTipoObs As String
    Public dFechaObs As String
    Public iCodUsuarioObserva As String
    Public iCodUsuario As String
    Public dFechaSis As String
    Public qSelect As String
    Public cTipoOpe As Char
    Public bTransaccion As Boolean = False
    Public mc As New ConnectSQL
    Public Function ListaDatos() As DataTable
        Dim Query As String
        Dim readers As DataTable
        Query = "SELECT * FROM dbo.AnexoAdmision"
        readers = mc.ExecuteDataTable(Query)
        Return readers
    End Function
    Public Sub Insertar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "INSERT into dbo.AnexoAdmision (iCodContrata,iCodContratistaContrato,iCodAnexoAdmisionTipo,iCodConvocatoriaMain,iCodSubContrata,iCodCliente,iCodClienteArea,cGrupo,dFechaSolicitud,cNroAnexo,iCorrelativo,iPeriodo,iCodPersonaGestor,cPersonaSolicita,cPersonaSolicitaCargo,cAreaUsuaria,cNotas,cTipo,cEstado,iCodUsuarioRegistra,dFechaRegistro,iCodUsuarioContrataEnvia,dFechaUsuarioContrataEnvia,iCodUsuarioValidaDoc,dFechaValidaDoc,iCodUsuarioAprueba,dFechaAprobacion,bAprobadoAAQ,dFechaAprobadoAAQ,cNotasAprobadoAAQ,iCodUsuarioAprobadoAAQ,dFechaUsuarioAprobadoAAQ,bNotificado,iCodUsuarioNotifica,dFechaNotifica,cCorreoNotifica,cNotasNotifica,bApruebaAreaAAQ,dFechaApruebaAreaAAQ,cNotasApruebaAreaAAQ,iCodUsuarioApruebaAreaAAQ,dFechaUsuarioApruebaAreaAAQ,cObsDocumento,cTipoObs,dFechaObs,iCodUsuarioObserva,iCodUsuario,dFechaSis ) VALUES(@iCodContrata,@iCodContratistaContrato,@iCodAnexoAdmisionTipo,@iCodConvocatoriaMain,@iCodSubContrata,@iCodCliente,@iCodClienteArea,@cGrupo,@dFechaSolicitud,@cNroAnexo,@iCorrelativo,@iPeriodo,@iCodPersonaGestor,@cPersonaSolicita,@cPersonaSolicitaCargo,@cAreaUsuaria,@cNotas,@cTipo,@cEstado,@iCodUsuarioRegistra,@dFechaRegistro,@iCodUsuarioContrataEnvia,@dFechaUsuarioContrataEnvia,@iCodUsuarioValidaDoc,@dFechaValidaDoc,@iCodUsuarioAprueba,@dFechaAprobacion,@bAprobadoAAQ,@dFechaAprobadoAAQ,@cNotasAprobadoAAQ,@iCodUsuarioAprobadoAAQ,@dFechaUsuarioAprobadoAAQ,@bNotificado,@iCodUsuarioNotifica,@dFechaNotifica,@cCorreoNotifica,@cNotasNotifica,@bApruebaAreaAAQ,@dFechaApruebaAreaAAQ,@cNotasApruebaAreaAAQ,@iCodUsuarioApruebaAreaAAQ,@dFechaUsuarioApruebaAreaAAQ,@cObsDocumento,@cTipoObs,@dFechaObs,@iCodUsuarioObserva,@iCodUsuario,@dFechaSis); SELECT SCOPE_IDENTITY(); "
        cmdSQL.Parameters.Add("@iCodContrata", SqlDbType.Int).Value = Me.iCodContrata
        cmdSQL.Parameters.Add("@iCodContratistaContrato", SqlDbType.Smallint).Value = Me.iCodContratistaContrato
        cmdSQL.Parameters.Add("@iCodAnexoAdmisionTipo", SqlDbType.Tinyint).Value = Me.iCodAnexoAdmisionTipo
        cmdSQL.Parameters.Add("@iCodConvocatoriaMain", SqlDbType.Int).Value = Me.iCodConvocatoriaMain
        cmdSQL.Parameters.Add("@iCodSubContrata", SqlDbType.Int).Value = Me.iCodSubContrata
        cmdSQL.Parameters.Add("@iCodCliente", SqlDbType.Int).Value = Me.iCodCliente
        cmdSQL.Parameters.Add("@iCodClienteArea", SqlDbType.Int).Value = Me.iCodClienteArea
        cmdSQL.Parameters.Add("@cGrupo", SqlDbType.Varchar, 8).Value = Me.cGrupo
        cmdSQL.Parameters.Add("@dFechaSolicitud", SqlDbType.Date).Value = Me.dFechaSolicitud
        cmdSQL.Parameters.Add("@cNroAnexo", SqlDbType.Varchar, 25).Value = Me.cNroAnexo
        cmdSQL.Parameters.Add("@iCorrelativo", SqlDbType.Smallint).Value = Me.iCorrelativo
        cmdSQL.Parameters.Add("@iPeriodo", SqlDbType.Smallint).Value = Me.iPeriodo
        cmdSQL.Parameters.Add("@iCodPersonaGestor", SqlDbType.Int).Value = Me.iCodPersonaGestor
        cmdSQL.Parameters.Add("@cPersonaSolicita", SqlDbType.Varchar, 50).Value = Me.cPersonaSolicita
        cmdSQL.Parameters.Add("@cPersonaSolicitaCargo", SqlDbType.Varchar, 50).Value = Me.cPersonaSolicitaCargo
        cmdSQL.Parameters.Add("@cAreaUsuaria", SqlDbType.Varchar, 50).Value = Me.cAreaUsuaria
        cmdSQL.Parameters.Add("@cNotas", SqlDbType.Varchar, 1500).Value = Me.cNotas
        cmdSQL.Parameters.Add("@cTipo", SqlDbType.Char, 1).Value = Me.cTipo
        cmdSQL.Parameters.Add("@cEstado", SqlDbType.Char, 1).Value = Me.cEstado
        cmdSQL.Parameters.Add("@iCodUsuarioRegistra", SqlDbType.Int).Value = Me.iCodUsuarioRegistra
        cmdSQL.Parameters.Add("@dFechaRegistro", SqlDbType.Datetime).Value = Me.dFechaRegistro
        cmdSQL.Parameters.Add("@iCodUsuarioContrataEnvia", SqlDbType.Int).Value = Me.iCodUsuarioContrataEnvia
        cmdSQL.Parameters.Add("@dFechaUsuarioContrataEnvia", SqlDbType.Datetime).Value = Me.dFechaUsuarioContrataEnvia
        cmdSQL.Parameters.Add("@iCodUsuarioValidaDoc", SqlDbType.Int).Value = Me.iCodUsuarioValidaDoc
        cmdSQL.Parameters.Add("@dFechaValidaDoc", SqlDbType.Datetime).Value = Me.dFechaValidaDoc
        cmdSQL.Parameters.Add("@iCodUsuarioAprueba", SqlDbType.Int).Value = Me.iCodUsuarioAprueba
        cmdSQL.Parameters.Add("@dFechaAprobacion", SqlDbType.Datetime).Value = Me.dFechaAprobacion
        cmdSQL.Parameters.Add("@bAprobadoAAQ", SqlDbType.Bit).Value = Me.bAprobadoAAQ
        cmdSQL.Parameters.Add("@dFechaAprobadoAAQ", SqlDbType.Date).Value = Me.dFechaAprobadoAAQ
        cmdSQL.Parameters.Add("@cNotasAprobadoAAQ", SqlDbType.Varchar, 250).Value = Me.cNotasAprobadoAAQ
        cmdSQL.Parameters.Add("@iCodUsuarioAprobadoAAQ", SqlDbType.Int).Value = Me.iCodUsuarioAprobadoAAQ
        cmdSQL.Parameters.Add("@dFechaUsuarioAprobadoAAQ", SqlDbType.Datetime).Value = Me.dFechaUsuarioAprobadoAAQ
        cmdSQL.Parameters.Add("@bNotificado", SqlDbType.Bit).Value = Me.bNotificado
        cmdSQL.Parameters.Add("@iCodUsuarioNotifica", SqlDbType.Int).Value = Me.iCodUsuarioNotifica
        cmdSQL.Parameters.Add("@dFechaNotifica", SqlDbType.Datetime).Value = Me.dFechaNotifica
        cmdSQL.Parameters.Add("@cCorreoNotifica", SqlDbType.Varchar, 70).Value = Me.cCorreoNotifica
        cmdSQL.Parameters.Add("@cNotasNotifica", SqlDbType.Varchar, 500).Value = Me.cNotasNotifica
        cmdSQL.Parameters.Add("@bApruebaAreaAAQ", SqlDbType.Bit).Value = Me.bApruebaAreaAAQ
        cmdSQL.Parameters.Add("@dFechaApruebaAreaAAQ", SqlDbType.Date).Value = Me.dFechaApruebaAreaAAQ
        cmdSQL.Parameters.Add("@cNotasApruebaAreaAAQ", SqlDbType.Varchar, 500).Value = Me.cNotasApruebaAreaAAQ
        cmdSQL.Parameters.Add("@iCodUsuarioApruebaAreaAAQ", SqlDbType.Int).Value = Me.iCodUsuarioApruebaAreaAAQ
        cmdSQL.Parameters.Add("@dFechaUsuarioApruebaAreaAAQ", SqlDbType.Datetime).Value = Me.dFechaUsuarioApruebaAreaAAQ
        cmdSQL.Parameters.Add("@cObsDocumento", SqlDbType.Varchar, 1500).Value = Me.cObsDocumento
        cmdSQL.Parameters.Add("@cTipoObs", SqlDbType.Varchar, 4).Value = Me.cTipoObs
        cmdSQL.Parameters.Add("@dFechaObs", SqlDbType.Datetime).Value = Me.dFechaObs
        cmdSQL.Parameters.Add("@iCodUsuarioObserva", SqlDbType.Int).Value = Me.iCodUsuarioObserva
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Smallint).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.Datetime).Value = Me.dFechaSis

        Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
        If pCodInsert > 0 Then
            Me.iCodAnexoAdmision = pCodInsert
        Else
            Me.iCodAnexoAdmision = 0
        End If
    End Sub
    Public Sub InsertarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "INSERT into dbo.AnexoAdmision (iCodContrata,iCodContratistaContrato,iCodAnexoAdmisionTipo,iCodConvocatoriaMain,iCodSubContrata,iCodCliente,iCodClienteArea,cGrupo,dFechaSolicitud,cNroAnexo,iCorrelativo,iPeriodo,iCodPersonaGestor,cPersonaSolicita,cPersonaSolicitaCargo,cAreaUsuaria,cNotas,cTipo,cEstado,iCodUsuarioRegistra,dFechaRegistro,iCodUsuarioContrataEnvia,dFechaUsuarioContrataEnvia,iCodUsuarioValidaDoc,dFechaValidaDoc,iCodUsuarioAprueba,dFechaAprobacion,bAprobadoAAQ,dFechaAprobadoAAQ,cNotasAprobadoAAQ,iCodUsuarioAprobadoAAQ,dFechaUsuarioAprobadoAAQ,bNotificado,iCodUsuarioNotifica,dFechaNotifica,cCorreoNotifica,cNotasNotifica,bApruebaAreaAAQ,dFechaApruebaAreaAAQ,cNotasApruebaAreaAAQ,iCodUsuarioApruebaAreaAAQ,dFechaUsuarioApruebaAreaAAQ,cObsDocumento,cTipoObs,dFechaObs,iCodUsuarioObserva,iCodUsuario,dFechaSis ) VALUES(@iCodContrata,@iCodContratistaContrato,@iCodAnexoAdmisionTipo,@iCodConvocatoriaMain,@iCodSubContrata,@iCodCliente,@iCodClienteArea,@cGrupo,@dFechaSolicitud,@cNroAnexo,@iCorrelativo,@iPeriodo,@iCodPersonaGestor,@cPersonaSolicita,@cPersonaSolicitaCargo,@cAreaUsuaria,@cNotas,@cTipo,@cEstado,@iCodUsuarioRegistra,@dFechaRegistro,@iCodUsuarioContrataEnvia,@dFechaUsuarioContrataEnvia,@iCodUsuarioValidaDoc,@dFechaValidaDoc,@iCodUsuarioAprueba,@dFechaAprobacion,@bAprobadoAAQ,@dFechaAprobadoAAQ,@cNotasAprobadoAAQ,@iCodUsuarioAprobadoAAQ,@dFechaUsuarioAprobadoAAQ,@bNotificado,@iCodUsuarioNotifica,@dFechaNotifica,@cCorreoNotifica,@cNotasNotifica,@bApruebaAreaAAQ,@dFechaApruebaAreaAAQ,@cNotasApruebaAreaAAQ,@iCodUsuarioApruebaAreaAAQ,@dFechaUsuarioApruebaAreaAAQ,@cObsDocumento,@cTipoObs,@dFechaObs,@iCodUsuarioObserva,@iCodUsuario,@dFechaSis); SELECT SCOPE_IDENTITY(); "
        cmdSQL.Parameters.Add("@iCodContrata", SqlDbType.Int).Value = Me.iCodContrata
        cmdSQL.Parameters.Add("@iCodContratistaContrato", SqlDbType.Smallint).Value = Me.iCodContratistaContrato
        cmdSQL.Parameters.Add("@iCodAnexoAdmisionTipo", SqlDbType.Tinyint).Value = Me.iCodAnexoAdmisionTipo
        cmdSQL.Parameters.Add("@iCodConvocatoriaMain", SqlDbType.Int).Value = Me.iCodConvocatoriaMain
        cmdSQL.Parameters.Add("@iCodSubContrata", SqlDbType.Int).Value = Me.iCodSubContrata
        cmdSQL.Parameters.Add("@iCodCliente", SqlDbType.Int).Value = Me.iCodCliente
        cmdSQL.Parameters.Add("@iCodClienteArea", SqlDbType.Int).Value = Me.iCodClienteArea
        cmdSQL.Parameters.Add("@cGrupo", SqlDbType.Varchar, 8).Value = Me.cGrupo
        cmdSQL.Parameters.Add("@dFechaSolicitud", SqlDbType.Date).Value = Me.dFechaSolicitud
        cmdSQL.Parameters.Add("@cNroAnexo", SqlDbType.Varchar, 25).Value = Me.cNroAnexo
        cmdSQL.Parameters.Add("@iCorrelativo", SqlDbType.Smallint).Value = Me.iCorrelativo
        cmdSQL.Parameters.Add("@iPeriodo", SqlDbType.Smallint).Value = Me.iPeriodo
        cmdSQL.Parameters.Add("@iCodPersonaGestor", SqlDbType.Int).Value = Me.iCodPersonaGestor
        cmdSQL.Parameters.Add("@cPersonaSolicita", SqlDbType.Varchar, 50).Value = Me.cPersonaSolicita
        cmdSQL.Parameters.Add("@cPersonaSolicitaCargo", SqlDbType.Varchar, 50).Value = Me.cPersonaSolicitaCargo
        cmdSQL.Parameters.Add("@cAreaUsuaria", SqlDbType.Varchar, 50).Value = Me.cAreaUsuaria
        cmdSQL.Parameters.Add("@cNotas", SqlDbType.Varchar, 1500).Value = Me.cNotas
        cmdSQL.Parameters.Add("@cTipo", SqlDbType.Char, 1).Value = Me.cTipo
        cmdSQL.Parameters.Add("@cEstado", SqlDbType.Char, 1).Value = Me.cEstado
        cmdSQL.Parameters.Add("@iCodUsuarioRegistra", SqlDbType.Int).Value = Me.iCodUsuarioRegistra
        cmdSQL.Parameters.Add("@dFechaRegistro", SqlDbType.Datetime).Value = Me.dFechaRegistro
        cmdSQL.Parameters.Add("@iCodUsuarioContrataEnvia", SqlDbType.Int).Value = Me.iCodUsuarioContrataEnvia
        cmdSQL.Parameters.Add("@dFechaUsuarioContrataEnvia", SqlDbType.Datetime).Value = Me.dFechaUsuarioContrataEnvia
        cmdSQL.Parameters.Add("@iCodUsuarioValidaDoc", SqlDbType.Int).Value = Me.iCodUsuarioValidaDoc
        cmdSQL.Parameters.Add("@dFechaValidaDoc", SqlDbType.Datetime).Value = Me.dFechaValidaDoc
        cmdSQL.Parameters.Add("@iCodUsuarioAprueba", SqlDbType.Int).Value = Me.iCodUsuarioAprueba
        cmdSQL.Parameters.Add("@dFechaAprobacion", SqlDbType.Datetime).Value = Me.dFechaAprobacion
        cmdSQL.Parameters.Add("@bAprobadoAAQ", SqlDbType.Bit).Value = Me.bAprobadoAAQ
        cmdSQL.Parameters.Add("@dFechaAprobadoAAQ", SqlDbType.Date).Value = Me.dFechaAprobadoAAQ
        cmdSQL.Parameters.Add("@cNotasAprobadoAAQ", SqlDbType.Varchar, 250).Value = Me.cNotasAprobadoAAQ
        cmdSQL.Parameters.Add("@iCodUsuarioAprobadoAAQ", SqlDbType.Int).Value = Me.iCodUsuarioAprobadoAAQ
        cmdSQL.Parameters.Add("@dFechaUsuarioAprobadoAAQ", SqlDbType.Datetime).Value = Me.dFechaUsuarioAprobadoAAQ
        cmdSQL.Parameters.Add("@bNotificado", SqlDbType.Bit).Value = Me.bNotificado
        cmdSQL.Parameters.Add("@iCodUsuarioNotifica", SqlDbType.Int).Value = Me.iCodUsuarioNotifica
        cmdSQL.Parameters.Add("@dFechaNotifica", SqlDbType.Datetime).Value = Me.dFechaNotifica
        cmdSQL.Parameters.Add("@cCorreoNotifica", SqlDbType.Varchar, 70).Value = Me.cCorreoNotifica
        cmdSQL.Parameters.Add("@cNotasNotifica", SqlDbType.Varchar, 500).Value = Me.cNotasNotifica
        cmdSQL.Parameters.Add("@bApruebaAreaAAQ", SqlDbType.Bit).Value = Me.bApruebaAreaAAQ
        cmdSQL.Parameters.Add("@dFechaApruebaAreaAAQ", SqlDbType.Date).Value = Me.dFechaApruebaAreaAAQ
        cmdSQL.Parameters.Add("@cNotasApruebaAreaAAQ", SqlDbType.Varchar, 500).Value = Me.cNotasApruebaAreaAAQ
        cmdSQL.Parameters.Add("@iCodUsuarioApruebaAreaAAQ", SqlDbType.Int).Value = Me.iCodUsuarioApruebaAreaAAQ
        cmdSQL.Parameters.Add("@dFechaUsuarioApruebaAreaAAQ", SqlDbType.Datetime).Value = Me.dFechaUsuarioApruebaAreaAAQ
        cmdSQL.Parameters.Add("@cObsDocumento", SqlDbType.Varchar, 1500).Value = Me.cObsDocumento
        cmdSQL.Parameters.Add("@cTipoObs", SqlDbType.Varchar, 4).Value = Me.cTipoObs
        cmdSQL.Parameters.Add("@dFechaObs", SqlDbType.Datetime).Value = Me.dFechaObs
        cmdSQL.Parameters.Add("@iCodUsuarioObserva", SqlDbType.Int).Value = Me.iCodUsuarioObserva
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Smallint).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.Datetime).Value = Me.dFechaSis

        Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
        If pCodInsert > 0 Then
            Me.iCodAnexoAdmision = pCodInsert
        Else
            Me.iCodAnexoAdmision = 0
        End If
    End Sub
    Public Sub Modificar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "UPDATE  dbo.AnexoAdmision SET iCodContrata=@iCodContrata,iCodContratistaContrato=@iCodContratistaContrato,iCodAnexoAdmisionTipo=@iCodAnexoAdmisionTipo,iCodConvocatoriaMain=@iCodConvocatoriaMain,iCodSubContrata=@iCodSubContrata,iCodCliente=@iCodCliente,iCodClienteArea=@iCodClienteArea,cGrupo=@cGrupo,dFechaSolicitud=@dFechaSolicitud,cNroAnexo=@cNroAnexo,iCorrelativo=@iCorrelativo,iPeriodo=@iPeriodo,iCodPersonaGestor=@iCodPersonaGestor,cPersonaSolicita=@cPersonaSolicita,cPersonaSolicitaCargo=@cPersonaSolicitaCargo,cAreaUsuaria=@cAreaUsuaria,cNotas=@cNotas,cTipo=@cTipo,cEstado=@cEstado,iCodUsuarioRegistra=@iCodUsuarioRegistra,dFechaRegistro=@dFechaRegistro,iCodUsuarioContrataEnvia=@iCodUsuarioContrataEnvia,dFechaUsuarioContrataEnvia=@dFechaUsuarioContrataEnvia,iCodUsuarioValidaDoc=@iCodUsuarioValidaDoc,dFechaValidaDoc=@dFechaValidaDoc,iCodUsuarioAprueba=@iCodUsuarioAprueba,dFechaAprobacion=@dFechaAprobacion,bAprobadoAAQ=@bAprobadoAAQ,dFechaAprobadoAAQ=@dFechaAprobadoAAQ,cNotasAprobadoAAQ=@cNotasAprobadoAAQ,iCodUsuarioAprobadoAAQ=@iCodUsuarioAprobadoAAQ,dFechaUsuarioAprobadoAAQ=@dFechaUsuarioAprobadoAAQ,bNotificado=@bNotificado,iCodUsuarioNotifica=@iCodUsuarioNotifica,dFechaNotifica=@dFechaNotifica,cCorreoNotifica=@cCorreoNotifica,cNotasNotifica=@cNotasNotifica,bApruebaAreaAAQ=@bApruebaAreaAAQ,dFechaApruebaAreaAAQ=@dFechaApruebaAreaAAQ,cNotasApruebaAreaAAQ=@cNotasApruebaAreaAAQ,iCodUsuarioApruebaAreaAAQ=@iCodUsuarioApruebaAreaAAQ,dFechaUsuarioApruebaAreaAAQ=@dFechaUsuarioApruebaAreaAAQ,cObsDocumento=@cObsDocumento,cTipoObs=@cTipoObs,dFechaObs=@dFechaObs,iCodUsuarioObserva=@iCodUsuarioObserva,iCodUsuario=@iCodUsuario,dFechaSis=@dFechaSis WHERE iCodAnexoAdmision=@iCodAnexoAdmision"
        cmdSQL.Parameters.Add("@iCodAnexoAdmision", SqlDbType.Int).Value = Me.iCodAnexoAdmision
        cmdSQL.Parameters.Add("@iCodContrata", SqlDbType.Int).Value = Me.iCodContrata
        cmdSQL.Parameters.Add("@iCodContratistaContrato", SqlDbType.Smallint).Value = Me.iCodContratistaContrato
        cmdSQL.Parameters.Add("@iCodAnexoAdmisionTipo", SqlDbType.Tinyint).Value = Me.iCodAnexoAdmisionTipo
        cmdSQL.Parameters.Add("@iCodConvocatoriaMain", SqlDbType.Int).Value = Me.iCodConvocatoriaMain
        cmdSQL.Parameters.Add("@iCodSubContrata", SqlDbType.Int).Value = Me.iCodSubContrata
        cmdSQL.Parameters.Add("@iCodCliente", SqlDbType.Int).Value = Me.iCodCliente
        cmdSQL.Parameters.Add("@iCodClienteArea", SqlDbType.Int).Value = Me.iCodClienteArea
        cmdSQL.Parameters.Add("@cGrupo", SqlDbType.Varchar, 8).Value = Me.cGrupo
        cmdSQL.Parameters.Add("@dFechaSolicitud", SqlDbType.Date).Value = Me.dFechaSolicitud
        cmdSQL.Parameters.Add("@cNroAnexo", SqlDbType.Varchar, 25).Value = Me.cNroAnexo
        cmdSQL.Parameters.Add("@iCorrelativo", SqlDbType.Smallint).Value = Me.iCorrelativo
        cmdSQL.Parameters.Add("@iPeriodo", SqlDbType.Smallint).Value = Me.iPeriodo
        cmdSQL.Parameters.Add("@iCodPersonaGestor", SqlDbType.Int).Value = Me.iCodPersonaGestor
        cmdSQL.Parameters.Add("@cPersonaSolicita", SqlDbType.Varchar, 50).Value = Me.cPersonaSolicita
        cmdSQL.Parameters.Add("@cPersonaSolicitaCargo", SqlDbType.Varchar, 50).Value = Me.cPersonaSolicitaCargo
        cmdSQL.Parameters.Add("@cAreaUsuaria", SqlDbType.Varchar, 50).Value = Me.cAreaUsuaria
        cmdSQL.Parameters.Add("@cNotas", SqlDbType.Varchar, 1500).Value = Me.cNotas
        cmdSQL.Parameters.Add("@cTipo", SqlDbType.Char, 1).Value = Me.cTipo
        cmdSQL.Parameters.Add("@cEstado", SqlDbType.Char, 1).Value = Me.cEstado
        cmdSQL.Parameters.Add("@iCodUsuarioRegistra", SqlDbType.Int).Value = Me.iCodUsuarioRegistra
        cmdSQL.Parameters.Add("@dFechaRegistro", SqlDbType.Datetime).Value = Me.dFechaRegistro
        cmdSQL.Parameters.Add("@iCodUsuarioContrataEnvia", SqlDbType.Int).Value = Me.iCodUsuarioContrataEnvia
        cmdSQL.Parameters.Add("@dFechaUsuarioContrataEnvia", SqlDbType.Datetime).Value = Me.dFechaUsuarioContrataEnvia
        cmdSQL.Parameters.Add("@iCodUsuarioValidaDoc", SqlDbType.Int).Value = Me.iCodUsuarioValidaDoc
        cmdSQL.Parameters.Add("@dFechaValidaDoc", SqlDbType.Datetime).Value = Me.dFechaValidaDoc
        cmdSQL.Parameters.Add("@iCodUsuarioAprueba", SqlDbType.Int).Value = Me.iCodUsuarioAprueba
        cmdSQL.Parameters.Add("@dFechaAprobacion", SqlDbType.Datetime).Value = Me.dFechaAprobacion
        cmdSQL.Parameters.Add("@bAprobadoAAQ", SqlDbType.Bit).Value = Me.bAprobadoAAQ
        cmdSQL.Parameters.Add("@dFechaAprobadoAAQ", SqlDbType.Date).Value = Me.dFechaAprobadoAAQ
        cmdSQL.Parameters.Add("@cNotasAprobadoAAQ", SqlDbType.Varchar, 250).Value = Me.cNotasAprobadoAAQ
        cmdSQL.Parameters.Add("@iCodUsuarioAprobadoAAQ", SqlDbType.Int).Value = Me.iCodUsuarioAprobadoAAQ
        cmdSQL.Parameters.Add("@dFechaUsuarioAprobadoAAQ", SqlDbType.Datetime).Value = Me.dFechaUsuarioAprobadoAAQ
        cmdSQL.Parameters.Add("@bNotificado", SqlDbType.Bit).Value = Me.bNotificado
        cmdSQL.Parameters.Add("@iCodUsuarioNotifica", SqlDbType.Int).Value = Me.iCodUsuarioNotifica
        cmdSQL.Parameters.Add("@dFechaNotifica", SqlDbType.Datetime).Value = Me.dFechaNotifica
        cmdSQL.Parameters.Add("@cCorreoNotifica", SqlDbType.Varchar, 70).Value = Me.cCorreoNotifica
        cmdSQL.Parameters.Add("@cNotasNotifica", SqlDbType.Varchar, 500).Value = Me.cNotasNotifica
        cmdSQL.Parameters.Add("@bApruebaAreaAAQ", SqlDbType.Bit).Value = Me.bApruebaAreaAAQ
        cmdSQL.Parameters.Add("@dFechaApruebaAreaAAQ", SqlDbType.Date).Value = Me.dFechaApruebaAreaAAQ
        cmdSQL.Parameters.Add("@cNotasApruebaAreaAAQ", SqlDbType.Varchar, 500).Value = Me.cNotasApruebaAreaAAQ
        cmdSQL.Parameters.Add("@iCodUsuarioApruebaAreaAAQ", SqlDbType.Int).Value = Me.iCodUsuarioApruebaAreaAAQ
        cmdSQL.Parameters.Add("@dFechaUsuarioApruebaAreaAAQ", SqlDbType.Datetime).Value = Me.dFechaUsuarioApruebaAreaAAQ
        cmdSQL.Parameters.Add("@cObsDocumento", SqlDbType.Varchar, 1500).Value = Me.cObsDocumento
        cmdSQL.Parameters.Add("@cTipoObs", SqlDbType.Varchar, 4).Value = Me.cTipoObs
        cmdSQL.Parameters.Add("@dFechaObs", SqlDbType.Datetime).Value = Me.dFechaObs
        cmdSQL.Parameters.Add("@iCodUsuarioObserva", SqlDbType.Int).Value = Me.iCodUsuarioObserva
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Smallint).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.Datetime).Value = Me.dFechaSis

        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub ModificarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "UPDATE  dbo.AnexoAdmision SET iCodContrata=@iCodContrata,iCodContratistaContrato=@iCodContratistaContrato,iCodAnexoAdmisionTipo=@iCodAnexoAdmisionTipo,iCodConvocatoriaMain=@iCodConvocatoriaMain,iCodSubContrata=@iCodSubContrata,iCodCliente=@iCodCliente,iCodClienteArea=@iCodClienteArea,cGrupo=@cGrupo,dFechaSolicitud=@dFechaSolicitud,cNroAnexo=@cNroAnexo,iCorrelativo=@iCorrelativo,iPeriodo=@iPeriodo,iCodPersonaGestor=@iCodPersonaGestor,cPersonaSolicita=@cPersonaSolicita,cPersonaSolicitaCargo=@cPersonaSolicitaCargo,cAreaUsuaria=@cAreaUsuaria,cNotas=@cNotas,cTipo=@cTipo,cEstado=@cEstado,iCodUsuarioRegistra=@iCodUsuarioRegistra,dFechaRegistro=@dFechaRegistro,iCodUsuarioContrataEnvia=@iCodUsuarioContrataEnvia,dFechaUsuarioContrataEnvia=@dFechaUsuarioContrataEnvia,iCodUsuarioValidaDoc=@iCodUsuarioValidaDoc,dFechaValidaDoc=@dFechaValidaDoc,iCodUsuarioAprueba=@iCodUsuarioAprueba,dFechaAprobacion=@dFechaAprobacion,bAprobadoAAQ=@bAprobadoAAQ,dFechaAprobadoAAQ=@dFechaAprobadoAAQ,cNotasAprobadoAAQ=@cNotasAprobadoAAQ,iCodUsuarioAprobadoAAQ=@iCodUsuarioAprobadoAAQ,dFechaUsuarioAprobadoAAQ=@dFechaUsuarioAprobadoAAQ,bNotificado=@bNotificado,iCodUsuarioNotifica=@iCodUsuarioNotifica,dFechaNotifica=@dFechaNotifica,cCorreoNotifica=@cCorreoNotifica,cNotasNotifica=@cNotasNotifica,bApruebaAreaAAQ=@bApruebaAreaAAQ,dFechaApruebaAreaAAQ=@dFechaApruebaAreaAAQ,cNotasApruebaAreaAAQ=@cNotasApruebaAreaAAQ,iCodUsuarioApruebaAreaAAQ=@iCodUsuarioApruebaAreaAAQ,dFechaUsuarioApruebaAreaAAQ=@dFechaUsuarioApruebaAreaAAQ,cObsDocumento=@cObsDocumento,cTipoObs=@cTipoObs,dFechaObs=@dFechaObs,iCodUsuarioObserva=@iCodUsuarioObserva,iCodUsuario=@iCodUsuario,dFechaSis=@dFechaSis WHERE iCodAnexoAdmision=@iCodAnexoAdmision"
        cmdSQL.Parameters.Add("@iCodAnexoAdmision", SqlDbType.Int).Value = Me.iCodAnexoAdmision
        cmdSQL.Parameters.Add("@iCodContrata", SqlDbType.Int).Value = Me.iCodContrata
        cmdSQL.Parameters.Add("@iCodContratistaContrato", SqlDbType.Smallint).Value = Me.iCodContratistaContrato
        cmdSQL.Parameters.Add("@iCodAnexoAdmisionTipo", SqlDbType.Tinyint).Value = Me.iCodAnexoAdmisionTipo
        cmdSQL.Parameters.Add("@iCodConvocatoriaMain", SqlDbType.Int).Value = Me.iCodConvocatoriaMain
        cmdSQL.Parameters.Add("@iCodSubContrata", SqlDbType.Int).Value = Me.iCodSubContrata
        cmdSQL.Parameters.Add("@iCodCliente", SqlDbType.Int).Value = Me.iCodCliente
        cmdSQL.Parameters.Add("@iCodClienteArea", SqlDbType.Int).Value = Me.iCodClienteArea
        cmdSQL.Parameters.Add("@cGrupo", SqlDbType.Varchar, 8).Value = Me.cGrupo
        cmdSQL.Parameters.Add("@dFechaSolicitud", SqlDbType.Date).Value = Me.dFechaSolicitud
        cmdSQL.Parameters.Add("@cNroAnexo", SqlDbType.Varchar, 25).Value = Me.cNroAnexo
        cmdSQL.Parameters.Add("@iCorrelativo", SqlDbType.Smallint).Value = Me.iCorrelativo
        cmdSQL.Parameters.Add("@iPeriodo", SqlDbType.Smallint).Value = Me.iPeriodo
        cmdSQL.Parameters.Add("@iCodPersonaGestor", SqlDbType.Int).Value = Me.iCodPersonaGestor
        cmdSQL.Parameters.Add("@cPersonaSolicita", SqlDbType.Varchar, 50).Value = Me.cPersonaSolicita
        cmdSQL.Parameters.Add("@cPersonaSolicitaCargo", SqlDbType.Varchar, 50).Value = Me.cPersonaSolicitaCargo
        cmdSQL.Parameters.Add("@cAreaUsuaria", SqlDbType.Varchar, 50).Value = Me.cAreaUsuaria
        cmdSQL.Parameters.Add("@cNotas", SqlDbType.Varchar, 1500).Value = Me.cNotas
        cmdSQL.Parameters.Add("@cTipo", SqlDbType.Char, 1).Value = Me.cTipo
        cmdSQL.Parameters.Add("@cEstado", SqlDbType.Char, 1).Value = Me.cEstado
        cmdSQL.Parameters.Add("@iCodUsuarioRegistra", SqlDbType.Int).Value = Me.iCodUsuarioRegistra
        cmdSQL.Parameters.Add("@dFechaRegistro", SqlDbType.Datetime).Value = Me.dFechaRegistro
        cmdSQL.Parameters.Add("@iCodUsuarioContrataEnvia", SqlDbType.Int).Value = Me.iCodUsuarioContrataEnvia
        cmdSQL.Parameters.Add("@dFechaUsuarioContrataEnvia", SqlDbType.Datetime).Value = Me.dFechaUsuarioContrataEnvia
        cmdSQL.Parameters.Add("@iCodUsuarioValidaDoc", SqlDbType.Int).Value = Me.iCodUsuarioValidaDoc
        cmdSQL.Parameters.Add("@dFechaValidaDoc", SqlDbType.Datetime).Value = Me.dFechaValidaDoc
        cmdSQL.Parameters.Add("@iCodUsuarioAprueba", SqlDbType.Int).Value = Me.iCodUsuarioAprueba
        cmdSQL.Parameters.Add("@dFechaAprobacion", SqlDbType.Datetime).Value = Me.dFechaAprobacion
        cmdSQL.Parameters.Add("@bAprobadoAAQ", SqlDbType.Bit).Value = Me.bAprobadoAAQ
        cmdSQL.Parameters.Add("@dFechaAprobadoAAQ", SqlDbType.Date).Value = Me.dFechaAprobadoAAQ
        cmdSQL.Parameters.Add("@cNotasAprobadoAAQ", SqlDbType.Varchar, 250).Value = Me.cNotasAprobadoAAQ
        cmdSQL.Parameters.Add("@iCodUsuarioAprobadoAAQ", SqlDbType.Int).Value = Me.iCodUsuarioAprobadoAAQ
        cmdSQL.Parameters.Add("@dFechaUsuarioAprobadoAAQ", SqlDbType.Datetime).Value = Me.dFechaUsuarioAprobadoAAQ
        cmdSQL.Parameters.Add("@bNotificado", SqlDbType.Bit).Value = Me.bNotificado
        cmdSQL.Parameters.Add("@iCodUsuarioNotifica", SqlDbType.Int).Value = Me.iCodUsuarioNotifica
        cmdSQL.Parameters.Add("@dFechaNotifica", SqlDbType.Datetime).Value = Me.dFechaNotifica
        cmdSQL.Parameters.Add("@cCorreoNotifica", SqlDbType.Varchar, 70).Value = Me.cCorreoNotifica
        cmdSQL.Parameters.Add("@cNotasNotifica", SqlDbType.Varchar, 500).Value = Me.cNotasNotifica
        cmdSQL.Parameters.Add("@bApruebaAreaAAQ", SqlDbType.Bit).Value = Me.bApruebaAreaAAQ
        cmdSQL.Parameters.Add("@dFechaApruebaAreaAAQ", SqlDbType.Date).Value = Me.dFechaApruebaAreaAAQ
        cmdSQL.Parameters.Add("@cNotasApruebaAreaAAQ", SqlDbType.Varchar, 500).Value = Me.cNotasApruebaAreaAAQ
        cmdSQL.Parameters.Add("@iCodUsuarioApruebaAreaAAQ", SqlDbType.Int).Value = Me.iCodUsuarioApruebaAreaAAQ
        cmdSQL.Parameters.Add("@dFechaUsuarioApruebaAreaAAQ", SqlDbType.Datetime).Value = Me.dFechaUsuarioApruebaAreaAAQ
        cmdSQL.Parameters.Add("@cObsDocumento", SqlDbType.Varchar, 1500).Value = Me.cObsDocumento
        cmdSQL.Parameters.Add("@cTipoObs", SqlDbType.Varchar, 4).Value = Me.cTipoObs
        cmdSQL.Parameters.Add("@dFechaObs", SqlDbType.Datetime).Value = Me.dFechaObs
        cmdSQL.Parameters.Add("@iCodUsuarioObserva", SqlDbType.Int).Value = Me.iCodUsuarioObserva
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Smallint).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.Datetime).Value = Me.dFechaSis

        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub Eliminar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "DELETE from  dbo.AnexoAdmision  WHERE iCodAnexoAdmision=@iCodAnexoAdmision"
        'cmdSQL.CommandText = "UPDATE dbo.AnexoAdmision  SET bAnulado=1 WHERE  iCodAnexoAdmision=@iCodAnexoAdmision"
        cmdSQL.Parameters.Add("@iCodAnexoAdmision", SqlDbType.Int).Value = Me.iCodAnexoAdmision
        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub EliminarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "DELETE from  dbo.AnexoAdmision  WHERE iCodAnexoAdmision=@iCodAnexoAdmision"
        'cmdSQL.CommandText = "UPDATE dbo.AnexoAdmision  SET bAnulado=1 WHERE  iCodAnexoAdmision=@iCodAnexoAdmision"
        cmdSQL.Parameters.Add("@iCodAnexoAdmision", SqlDbType.Int).Value = Me.iCodAnexoAdmision
        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub getRecord()
        Dim readers As IDataReader
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL

        If bTransaccion = True Then cmdSQL.Transaction = Me.mc.miTransact Else 

        cmdSQL.CommandText = "SELECT * FROM dbo.AnexoAdmision WHERE iCodAnexoAdmision=@iCodAnexoAdmision"
        cmdSQL.Parameters.Add("@iCodAnexoAdmision", SqlDbType.Int).Value = Me.iCodAnexoAdmision
        readers = cmdSQL.ExecuteReader
        If readers.Read() Then
            Me.iCodAnexoAdmision = CStr(readers.GetValue(0))
            Me.iCodContrata = CStr(readers.GetValue(1))
            Me.iCodContratistaContrato = CStr(readers.GetValue(2))
            Me.iCodAnexoAdmisionTipo = CStr(readers.GetValue(3))
            Me.iCodConvocatoriaMain = CStr(readers.GetValue(4))
            Me.iCodSubContrata = CStr(readers.GetValue(5))
            Me.iCodCliente = CStr(readers.GetValue(6))
            Me.iCodClienteArea = CStr(readers.GetValue(7))
            Me.cGrupo = CStr(readers.GetValue(8))
            Me.dFechaSolicitud = CStr(readers.GetValue(9))
            Me.cNroAnexo = CStr(readers.GetValue(10))
            Me.iCorrelativo = CStr(readers.GetValue(11))
            Me.iPeriodo = CStr(readers.GetValue(12))
            Me.iCodPersonaGestor = CStr(readers.GetValue(13))
            Me.cPersonaSolicita = CStr(readers.GetValue(14))
            Me.cPersonaSolicitaCargo = CStr(readers.GetValue(15))
            Me.cAreaUsuaria = CStr(readers.GetValue(16))
            Me.cNotas = CStr(readers.GetValue(17))
            Me.cTipo = CStr(readers.GetValue(18))
            Me.cEstado = CStr(readers.GetValue(19))
            Me.iCodUsuarioRegistra = CStr(readers.GetValue(20))
            Me.dFechaRegistro = CStr(readers.GetValue(21))
            Me.iCodUsuarioContrataEnvia = CStr(readers.GetValue(22))
            Me.dFechaUsuarioContrataEnvia = CStr(readers.GetValue(23))
            Me.iCodUsuarioValidaDoc = CStr(readers.GetValue(24))
            Me.dFechaValidaDoc = CStr(readers.GetValue(25))
            Me.iCodUsuarioAprueba = CStr(readers.GetValue(26))
            Me.dFechaAprobacion = CStr(readers.GetValue(27))
            Me.bAprobadoAAQ = CStr(readers.GetValue(28))
            Me.dFechaAprobadoAAQ = CStr(readers.GetValue(29))
            Me.cNotasAprobadoAAQ = CStr(readers.GetValue(30))
            Me.iCodUsuarioAprobadoAAQ = CStr(readers.GetValue(31))
            Me.dFechaUsuarioAprobadoAAQ = CStr(readers.GetValue(32))
            Me.bNotificado = CStr(readers.GetValue(33))
            Me.iCodUsuarioNotifica = CStr(readers.GetValue(34))
            Me.dFechaNotifica = CStr(readers.GetValue(35))
            Me.cCorreoNotifica = CStr(readers.GetValue(36))
            Me.cNotasNotifica = CStr(readers.GetValue(37))
            Me.bApruebaAreaAAQ = CStr(readers.GetValue(38))
            Me.dFechaApruebaAreaAAQ = CStr(readers.GetValue(39))
            Me.cNotasApruebaAreaAAQ = CStr(readers.GetValue(40))
            Me.iCodUsuarioApruebaAreaAAQ = CStr(readers.GetValue(41))
            Me.dFechaUsuarioApruebaAreaAAQ = CStr(readers.GetValue(42))
            Me.cObsDocumento = CStr(readers.GetValue(43))
            Me.cTipoObs = CStr(readers.GetValue(44))
            Me.dFechaObs = CStr(readers.GetValue(45))
            Me.iCodUsuarioObserva = CStr(readers.GetValue(46))
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
        cmdSQL.CommandText = "SELECT * FROM dbo.AnexoAdmision"
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
    '************************************************************************************************
    Public Sub Anular()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        'cmdSQL.CommandText = "DELETE from  dbo.AnexoAdmision  WHERE iCodAnexoAdmision=@iCodAnexoAdmision"
        cmdSQL.CommandText = "UPDATE dbo.AnexoAdmision  SET cEstado='A',iCodUsuario=@iCodUsuario,dFechaSis=GETDATE() WHERE  iCodAnexoAdmision=@iCodAnexoAdmision"
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.SmallInt).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@iCodAnexoAdmision", SqlDbType.Int).Value = Me.iCodAnexoAdmision

        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Function ListaTipoFormato() As DataTable
        Dim miDataTable As New DataTable
        miDataTable.Columns.Add("ValueMember")
        miDataTable.Columns.Add("DisplayMember")
        With miDataTable
            .Rows.Add("P", "PGI")
            .Rows.Add("A", "ANEXO 05")
        End With
        Return miDataTable
    End Function

    Public Function ListaGrupoAnexo() As DataTable
        Dim miDataTable As New DataTable
        miDataTable.Columns.Add("ValueMember")
        miDataTable.Columns.Add("DisplayMember")
        With miDataTable
            .Rows.Add("L", "LOCAL")
            .Rows.Add("F", "FORANEO")
        End With
        Return miDataTable
    End Function

    Public Sub CambiarEstado()
        'Dim Query As String
        'Query = String.Format("UPDATE Anexoadmision SET dFechaAprobacion=GETDATE(),cEstado='{1}' WHERE iCodAnexoAdmision={0}", Me.iCodAnexoAdmision, Me.cEstado)
        'mc.ExecuteQuery(Query)


        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "UPDATE dbo.Anexoadmision SET dFechaAprobacion=GETDATE(),cEstado=@cEstado WHERE iCodAnexoAdmision=@iCodAnexoAdmision"
        'cmdSQL.CommandText = "UPDATE dbo.AnexoAdmision  SET bAnulado=1 WHERE  iCodAnexoAdmision=@iCodAnexoAdmision"
        cmdSQL.Parameters.Add("@cEstado", SqlDbType.Char, 1).Value = Me.cEstado
        cmdSQL.Parameters.Add("@iCodAnexoAdmision", SqlDbType.Int).Value = Me.iCodAnexoAdmision
        cmdSQL.ExecuteNonQuery()

    End Sub



    Public Sub EnviarOAEL()
        'Dim Query As String
        'Query = String.Format("UPDATE Anexoadmision SET dFechaAprobacion=GETDATE(),cEstado='{1}' WHERE iCodAnexoAdmision={0}", Me.iCodAnexoAdmision, Me.cEstado)
        'mc.ExecuteQuery(Query)


        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "UPDATE dbo.Anexoadmision SET  iCodUsuarioContrataEnvia=@iCodUsuarioContrataEnvia,dFechaUsuarioContrataEnvia=@dFechaUsuarioContrataEnvia,cEstado=@cEstado WHERE iCodAnexoAdmision=@iCodAnexoAdmision"
        'cmdSQL.CommandText = "UPDATE dbo.AnexoAdmision  SET bAnulado=1 WHERE  iCodAnexoAdmision=@iCodAnexoAdmision"
        cmdSQL.Parameters.Add("@iCodUsuarioContrataEnvia", SqlDbType.Int).Value = Me.iCodUsuarioContrataEnvia
        cmdSQL.Parameters.Add("@dFechaUsuarioContrataEnvia", SqlDbType.DateTime).Value = Me.dFechaUsuarioContrataEnvia
        cmdSQL.Parameters.Add("@cEstado", SqlDbType.Char, 1).Value = Me.cEstado
        cmdSQL.Parameters.Add("@iCodAnexoAdmision", SqlDbType.Int).Value = Me.iCodAnexoAdmision
        cmdSQL.ExecuteNonQuery()

    End Sub

    Public Function ListaSolicitudes(ByVal pCodContrata As String, ByVal pFechaIni As String, ByVal pFechaFin As String, ByVal pTipoVista As String, ByVal pEstado As String) As DataTable
        Dim Query As String
        Dim readers As DataTable
        Query = " exec dbo.SP_PGI_GetAnexoAdmisionLista " & _
                       " @iCodContrata='" & Trim(pCodContrata) & "'," & _
         " @dFechaSolicitudIni='" & Trim(pFechaIni) & "'," & _
         " @dFechaSolicitudFin='" & Trim(pFechaFin) & "'," & _
         " @cTipoVista='" & Trim(pTipoVista) & "'," & _
        " @pEstado='" & Trim(pEstado) & "'"
        'InputBox("", "", Query)
        readers = mc.ExecuteDataTable(Query)
        Return readers
    End Function


    Public Function ListaSolicitudesSeguimiento(ByVal pCodContrata As String, ByVal pFechaIni As String, ByVal pFechaFin As String, ByVal pTipoVista As String, ByVal pEstado As String) As DataTable
        Dim Query As String
        Dim readers As DataTable
        Query = " exec dbo.SP_PGI_GetAnexoAdmisionListaSeguimiento " & _
                       " @iCodContrata='" & Trim(pCodContrata) & "'," & _
         " @dFechaSolicitudIni='" & Trim(pFechaIni) & "'," & _
         " @dFechaSolicitudFin='" & Trim(pFechaFin) & "'," & _
         " @cTipoVista='" & Trim(pTipoVista) & "'," & _
        " @pEstado='" & Trim(pEstado) & "'"
        'InputBox("", "", Query)
        readers = mc.ExecuteDataTable(Query)
        Return readers
    End Function
End Class
