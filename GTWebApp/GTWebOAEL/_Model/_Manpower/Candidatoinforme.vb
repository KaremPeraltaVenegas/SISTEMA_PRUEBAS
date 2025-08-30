Imports System.Data.SqlClient
Public Class Candidatoinforme
    '*************************************
    Public cMecanismo As String
    Public cProcedencia As String
    '*************************************
    Public iCodCandidatoInforme As String
    Public cDNI As String
    Public cUbigeo As String
    Public cApellidos As String
    Public cNombres As String
    Public cSexo As String
    Public cEstCivil As String
    Public cFono As String
    Public cCorreo As String
    Public dFechaNac As String
    Public cCUI As String
    Public cDireccion As String
    Public cCondicion As String
    Public cPuestoEspecialidad As String
    Public cOcupacion As String
    Public cOcupacion2 As String
    Public cEducaSecundaria As String
    Public cEducaTecnica As String
    Public cEducaSuperior As String
    Public cExpLaboral As String
    Public cEmprEx1 As String
    Public cCargoEx1 As String
    Public dFechaIniEx1 As String
    Public dFechaFinEx1 As String
    Public cEmprEx2 As String
    Public cCargoEx2 As String
    Public dFechaIniEx2 As String
    Public dFechaFinEx2 As String
    Public cComunidad As String
    Public cMOCMONC As String
    Public cObservacion As String
    Public cAptitud As String
    Public cUbigeoResidencia As String
    Public dFechaDisponible As String
    Public cCapacitacion As String
    Public cLicenciaConducir As String
    Public cCertificacion As String
    Public iPAsertividad As String
    Public iPTrabajoEquipo As String
    Public iPComEfectiva As String
    Public iPAdaptabilidad As String
    Public iEEstable As String
    Public iEInestable As String
    Public iCCompromiso As String
    Public iSRptoNorma As String
    Public iSIperC As String
    Public iSActitud As String
    Public dFechaRegistro As String
    Public iCodUsuarioRegistra As String
    Public dFechaEvaluacion As String
    Public bEvaluado As String
    Public dFechaVerificativa As String
    Public bVerificativa As String
    Public iEstadoVerificativa As String
    Public iResultadoVerificativa As String
    Public dFechaCargaBox As String
    Public bSustentoCV As String
    Public bContratado As String
    Public bCargaBox As String
    Public bDNIMoq As String
    Public bCasadoMoq As String
    Public bConviveMoq As String
    Public bHijosMoq As String
    Public bRucMoq As String
    Public bEstudioMoq As String
    Public bTrabajoMoq As String
    Public cTipoDoc As String
    Public iTipoIngreso As String
    Public cPaisNacimiento As String
    Public iTiempoExperiencia As String
    Public cDNIConyuge As String
    Public cUbigeoConyuge As String
    Public cApellidosConyuge As String
    Public cNombresConyuge As String
    Public cDNIHijo As String
    Public cUbigeoHijo As String
    Public cApellidosHijo As String
    Public cNombresHijo As String
    Public bComunidadPadron As String
    Public bComunidadConstancia As String
    Public bCip As String
    Public bCumplePefil As String
    Public bDisponible As String
    Public dFechaEmisionDni As String
    Public cEmpresaTrabaja As String
    Public dFechaEvaluacionResultado As String
    Public iCodPersonaEvalua As String
    Public bDiscapacitado As String
    Public bPrioritario As String
    Public iCodUsuario As String
    Public dFechaSis As String
    Public qSelect As String
    Public cTipoOpe As Char
    Public bTransaccion As Boolean = False
    Public mc As New ConnectSQL
    Public dFechaBusqueda As String
    Public Function ListaDatos() As DataTable
        Dim Query As String
        Dim readers As DataTable
        Query = "SELECT * FROM dbo.CandidatoInforme"
        readers = mc.ExecuteDataTable(Query)
        Return readers
    End Function
    Public Sub Insertar()
        'Dim Query As String
        'SETTING INICIALES
        'Me.bSustentoCV = "1900-01-01"
        Me.bContratado = CBool(0)
        'Me.cCapacitacion = ""

        'Me.cEmprEx1 = EscapeComilla(Me.cEmprEx1)
        'Me.cEmprEx2 = EscapeComilla(Me.cEmprEx2)
        'Me.cApellidos = EscapeComilla(Me.cApellidos)
        'Me.cNombres = EscapeComilla(Me.cNombres)

        'Me.cNombresConyuge = EscapeComilla(Me.cNombresConyuge)
        'Me.cApellidosConyuge = EscapeComilla(Me.cApellidosConyuge)
        'Me.cNombresHijo = EscapeComilla(Me.cNombresHijo)
        'Me.cApellidosHijo = EscapeComilla(Me.cApellidosHijo)

        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "INSERT into dbo.CandidatoInforme (cDNI,cUbigeo,cApellidos,cNombres,cSexo,cEstCivil,cFono,cCorreo,dFechaNac,cCUI,cDireccion,cCondicion,cPuestoEspecialidad,cOcupacion,cOcupacion2,cEducaSecundaria,cEducaTecnica,cEducaSuperior,cExpLaboral,cEmprEx1,cCargoEx1,dFechaIniEx1,dFechaFinEx1,cEmprEx2,cCargoEx2,dFechaIniEx2,dFechaFinEx2,cComunidad,cMOCMONC,cObservacion,cAptitud,cUbigeoResidencia,dFechaDisponible,cCapacitacion,cLicenciaConducir,cCertificacion,iPAsertividad,iPTrabajoEquipo,iPComEfectiva,iPAdaptabilidad,iEEstable,iEInestable,iCCompromiso,iSRptoNorma,iSIperC,iSActitud,dFechaRegistro,iCodUsuarioRegistra,dFechaEvaluacion,bEvaluado,dFechaVerificativa,bVerificativa,iEstadoVerificativa,iResultadoVerificativa,dFechaCargaBox,bSustentoCV,bContratado,bCargaBox,bDNIMoq,bCasadoMoq,bConviveMoq,bHijosMoq,bRucMoq,bEstudioMoq,bTrabajoMoq,cTipoDoc,iTipoIngreso,cPaisNacimiento,iTiempoExperiencia,cDNIConyuge,cUbigeoConyuge,cApellidosConyuge,cNombresConyuge,cDNIHijo,cUbigeoHijo,cApellidosHijo,cNombresHijo,bComunidadPadron,bComunidadConstancia,bCip,bCumplePefil,bDisponible,dFechaEmisionDni,cEmpresaTrabaja,dFechaEvaluacionResultado,iCodPersonaEvalua,bDiscapacitado,bPrioritario,iCodUsuario,dFechaSis ) VALUES(@cDNI,@cUbigeo,@cApellidos,@cNombres,@cSexo,@cEstCivil,@cFono,@cCorreo,@dFechaNac,@cCUI,@cDireccion,@cCondicion,@cPuestoEspecialidad,@cOcupacion,@cOcupacion2,@cEducaSecundaria,@cEducaTecnica,@cEducaSuperior,@cExpLaboral,@cEmprEx1,@cCargoEx1,@dFechaIniEx1,@dFechaFinEx1,@cEmprEx2,@cCargoEx2,@dFechaIniEx2,@dFechaFinEx2,@cComunidad,@cMOCMONC,@cObservacion,@cAptitud,@cUbigeoResidencia,@dFechaDisponible,@cCapacitacion,@cLicenciaConducir,@cCertificacion,@iPAsertividad,@iPTrabajoEquipo,@iPComEfectiva,@iPAdaptabilidad,@iEEstable,@iEInestable,@iCCompromiso,@iSRptoNorma,@iSIperC,@iSActitud,@dFechaRegistro,@iCodUsuarioRegistra,@dFechaEvaluacion,@bEvaluado,@dFechaVerificativa,@bVerificativa,@iEstadoVerificativa,@iResultadoVerificativa,@dFechaCargaBox,@bSustentoCV,@bContratado,@bCargaBox,@bDNIMoq,@bCasadoMoq,@bConviveMoq,@bHijosMoq,@bRucMoq,@bEstudioMoq,@bTrabajoMoq,@cTipoDoc,@iTipoIngreso,@cPaisNacimiento,@iTiempoExperiencia,@cDNIConyuge,@cUbigeoConyuge,@cApellidosConyuge,@cNombresConyuge,@cDNIHijo,@cUbigeoHijo,@cApellidosHijo,@cNombresHijo,@bComunidadPadron,@bComunidadConstancia,@bCip,@bCumplePefil,@bDisponible,@dFechaEmisionDni,@cEmpresaTrabaja,@dFechaEvaluacionResultado,@iCodPersonaEvalua,@bDiscapacitado,@bPrioritario,@iCodUsuario,@dFechaSis); SELECT SCOPE_IDENTITY(); "
        cmdSQL.Parameters.Add("@cDNI", SqlDbType.VarChar, 20).Value = Me.cDNI
        cmdSQL.Parameters.Add("@cUbigeo", SqlDbType.VarChar, 8).Value = Me.cUbigeo
        cmdSQL.Parameters.Add("@cApellidos", SqlDbType.VarChar, 60).Value = Me.cApellidos
        cmdSQL.Parameters.Add("@cNombres", SqlDbType.VarChar, 60).Value = Me.cNombres
        cmdSQL.Parameters.Add("@cSexo", SqlDbType.VarChar, 2).Value = Me.cSexo
        cmdSQL.Parameters.Add("@cEstCivil", SqlDbType.VarChar, 20).Value = Me.cEstCivil
        cmdSQL.Parameters.Add("@cFono", SqlDbType.VarChar, 30).Value = Me.cFono
        cmdSQL.Parameters.Add("@cCorreo", SqlDbType.VarChar, 70).Value = Me.cCorreo
        cmdSQL.Parameters.Add("@dFechaNac", SqlDbType.Date).Value = Me.dFechaNac
        cmdSQL.Parameters.Add("@cCUI", SqlDbType.VarChar, 50).Value = Me.cCUI
        cmdSQL.Parameters.Add("@cDireccion", SqlDbType.VarChar, 100).Value = Me.cDireccion
        cmdSQL.Parameters.Add("@cCondicion", SqlDbType.VarChar, 250).Value = Me.cCondicion
        cmdSQL.Parameters.Add("@cPuestoEspecialidad", SqlDbType.VarChar, 250).Value = Me.cPuestoEspecialidad
        cmdSQL.Parameters.Add("@cOcupacion", SqlDbType.VarChar, 250).Value = Me.cOcupacion
        cmdSQL.Parameters.Add("@cOcupacion2", SqlDbType.VarChar, 70).Value = Me.cOcupacion2
        cmdSQL.Parameters.Add("@cEducaSecundaria", SqlDbType.VarChar, 50).Value = Me.cEducaSecundaria
        cmdSQL.Parameters.Add("@cEducaTecnica", SqlDbType.VarChar, 50).Value = Me.cEducaTecnica
        cmdSQL.Parameters.Add("@cEducaSuperior", SqlDbType.VarChar, 50).Value = Me.cEducaSuperior
        cmdSQL.Parameters.Add("@cExpLaboral", SqlDbType.VarChar, 500).Value = Me.cExpLaboral
        cmdSQL.Parameters.Add("@cEmprEx1", SqlDbType.VarChar, 150).Value = Me.cEmprEx1
        cmdSQL.Parameters.Add("@cCargoEx1", SqlDbType.VarChar, 80).Value = Me.cCargoEx1
        cmdSQL.Parameters.Add("@dFechaIniEx1", SqlDbType.Date).Value = Me.dFechaIniEx1
        cmdSQL.Parameters.Add("@dFechaFinEx1", SqlDbType.Date).Value = Me.dFechaFinEx1
        cmdSQL.Parameters.Add("@cEmprEx2", SqlDbType.VarChar, 150).Value = Me.cEmprEx2
        cmdSQL.Parameters.Add("@cCargoEx2", SqlDbType.VarChar, 80).Value = Me.cCargoEx2
        cmdSQL.Parameters.Add("@dFechaIniEx2", SqlDbType.Date).Value = Me.dFechaIniEx2
        cmdSQL.Parameters.Add("@dFechaFinEx2", SqlDbType.Date).Value = Me.dFechaFinEx2
        cmdSQL.Parameters.Add("@cComunidad", SqlDbType.VarChar, 60).Value = Me.cComunidad
        cmdSQL.Parameters.Add("@cMOCMONC", SqlDbType.VarChar, 10).Value = Me.cMOCMONC
        cmdSQL.Parameters.Add("@cObservacion", SqlDbType.VarChar, 120).Value = Me.cObservacion
        cmdSQL.Parameters.Add("@cAptitud", SqlDbType.VarChar, 50).Value = Me.cAptitud
        cmdSQL.Parameters.Add("@cUbigeoResidencia", SqlDbType.VarChar, 40).Value = Me.cUbigeoResidencia
        cmdSQL.Parameters.Add("@dFechaDisponible", SqlDbType.Date).Value = Me.dFechaDisponible
        cmdSQL.Parameters.Add("@cCapacitacion", SqlDbType.VarChar, 50).Value = Me.cCapacitacion
        cmdSQL.Parameters.Add("@cLicenciaConducir", SqlDbType.VarChar, 25).Value = Me.cLicenciaConducir
        cmdSQL.Parameters.Add("@cCertificacion", SqlDbType.VarChar, 60).Value = Me.cCertificacion
        cmdSQL.Parameters.Add("@iPAsertividad", SqlDbType.TinyInt).Value = Me.iPAsertividad
        cmdSQL.Parameters.Add("@iPTrabajoEquipo", SqlDbType.TinyInt).Value = Me.iPTrabajoEquipo
        cmdSQL.Parameters.Add("@iPComEfectiva", SqlDbType.TinyInt).Value = Me.iPComEfectiva
        cmdSQL.Parameters.Add("@iPAdaptabilidad", SqlDbType.TinyInt).Value = Me.iPAdaptabilidad
        cmdSQL.Parameters.Add("@iEEstable", SqlDbType.TinyInt).Value = Me.iEEstable
        cmdSQL.Parameters.Add("@iEInestable", SqlDbType.TinyInt).Value = Me.iEInestable
        cmdSQL.Parameters.Add("@iCCompromiso", SqlDbType.TinyInt).Value = Me.iCCompromiso
        cmdSQL.Parameters.Add("@iSRptoNorma", SqlDbType.TinyInt).Value = Me.iSRptoNorma
        cmdSQL.Parameters.Add("@iSIperC", SqlDbType.TinyInt).Value = Me.iSIperC
        cmdSQL.Parameters.Add("@iSActitud", SqlDbType.TinyInt).Value = Me.iSActitud
        cmdSQL.Parameters.Add("@dFechaRegistro", SqlDbType.Date).Value = Me.dFechaRegistro
        cmdSQL.Parameters.Add("@iCodUsuarioRegistra", SqlDbType.SmallInt).Value = Me.iCodUsuarioRegistra
        cmdSQL.Parameters.Add("@dFechaEvaluacion", SqlDbType.Date).Value = Me.dFechaEvaluacion
        cmdSQL.Parameters.Add("@bEvaluado", SqlDbType.Bit).Value = Me.bEvaluado
        cmdSQL.Parameters.Add("@dFechaVerificativa", SqlDbType.Date).Value = Me.dFechaVerificativa
        cmdSQL.Parameters.Add("@bVerificativa", SqlDbType.Bit).Value = Me.bVerificativa
        cmdSQL.Parameters.Add("@iEstadoVerificativa", SqlDbType.TinyInt).Value = Me.iEstadoVerificativa
        cmdSQL.Parameters.Add("@iResultadoVerificativa", SqlDbType.TinyInt).Value = Me.iResultadoVerificativa
        cmdSQL.Parameters.Add("@dFechaCargaBox", SqlDbType.Date).Value = Me.dFechaCargaBox
        cmdSQL.Parameters.Add("@bSustentoCV", SqlDbType.Bit).Value = Me.bSustentoCV
        cmdSQL.Parameters.Add("@bContratado", SqlDbType.Bit).Value = Me.bContratado
        cmdSQL.Parameters.Add("@bCargaBox", SqlDbType.Bit).Value = Me.bCargaBox
        cmdSQL.Parameters.Add("@bDNIMoq", SqlDbType.Bit).Value = Me.bDNIMoq
        cmdSQL.Parameters.Add("@bCasadoMoq", SqlDbType.Bit).Value = Me.bCasadoMoq
        cmdSQL.Parameters.Add("@bConviveMoq", SqlDbType.Bit).Value = Me.bConviveMoq
        cmdSQL.Parameters.Add("@bHijosMoq", SqlDbType.Bit).Value = Me.bHijosMoq
        cmdSQL.Parameters.Add("@bRucMoq", SqlDbType.Bit).Value = Me.bRucMoq
        cmdSQL.Parameters.Add("@bEstudioMoq", SqlDbType.Bit).Value = Me.bEstudioMoq
        cmdSQL.Parameters.Add("@bTrabajoMoq", SqlDbType.Bit).Value = Me.bTrabajoMoq
        cmdSQL.Parameters.Add("@cTipoDoc", SqlDbType.VarChar, 5).Value = Me.cTipoDoc
        cmdSQL.Parameters.Add("@iTipoIngreso", SqlDbType.TinyInt).Value = Me.iTipoIngreso
        cmdSQL.Parameters.Add("@cPaisNacimiento", SqlDbType.VarChar, 30).Value = Me.cPaisNacimiento
        cmdSQL.Parameters.Add("@iTiempoExperiencia", SqlDbType.SmallInt).Value = Me.iTiempoExperiencia
        cmdSQL.Parameters.Add("@cDNIConyuge", SqlDbType.VarChar, 10).Value = Me.cDNIConyuge
        cmdSQL.Parameters.Add("@cUbigeoConyuge", SqlDbType.VarChar, 8).Value = Me.cUbigeoConyuge
        cmdSQL.Parameters.Add("@cApellidosConyuge", SqlDbType.VarChar, 50).Value = Me.cApellidosConyuge
        cmdSQL.Parameters.Add("@cNombresConyuge", SqlDbType.VarChar, 50).Value = Me.cNombresConyuge
        cmdSQL.Parameters.Add("@cDNIHijo", SqlDbType.VarChar, 10).Value = Me.cDNIHijo
        cmdSQL.Parameters.Add("@cUbigeoHijo", SqlDbType.VarChar, 8).Value = Me.cUbigeoHijo
        cmdSQL.Parameters.Add("@cApellidosHijo", SqlDbType.VarChar, 50).Value = Me.cApellidosHijo
        cmdSQL.Parameters.Add("@cNombresHijo", SqlDbType.VarChar, 50).Value = Me.cNombresHijo
        cmdSQL.Parameters.Add("@bComunidadPadron", SqlDbType.Bit).Value = Me.bComunidadPadron
        cmdSQL.Parameters.Add("@bComunidadConstancia", SqlDbType.Bit).Value = Me.bComunidadConstancia
        cmdSQL.Parameters.Add("@bCip", SqlDbType.Bit).Value = Me.bCip
        cmdSQL.Parameters.Add("@bCumplePefil", SqlDbType.Bit).Value = Me.bCumplePefil
        cmdSQL.Parameters.Add("@bDisponible", SqlDbType.Bit).Value = Me.bDisponible
        cmdSQL.Parameters.Add("@dFechaEmisionDni", SqlDbType.Date).Value = Me.dFechaEmisionDni
        cmdSQL.Parameters.Add("@cEmpresaTrabaja", SqlDbType.VarChar, 50).Value = Me.cEmpresaTrabaja
        cmdSQL.Parameters.Add("@dFechaEvaluacionResultado", SqlDbType.Date).Value = Me.dFechaEvaluacionResultado
        cmdSQL.Parameters.Add("@iCodPersonaEvalua", SqlDbType.Int).Value = Me.iCodPersonaEvalua
        cmdSQL.Parameters.Add("@bDiscapacitado", SqlDbType.Bit).Value = Me.bDiscapacitado
        cmdSQL.Parameters.Add("@bPrioritario", SqlDbType.Bit).Value = Me.bPrioritario
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.DateTime).Value = Me.dFechaSis

        Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
        If pCodInsert > 0 Then
            Me.iCodCandidatoInforme = pCodInsert
        Else
            Me.iCodCandidatoInforme = 0
        End If
    End Sub
    Public Sub InsertarTransact()
        'SETTING INICIALES
        'Me.bSustentoCV = "1900-01-01"
        'MsgBox("insert T")
        Me.bContratado = CBool(0)
        'Me.cEmprEx1 = EscapeComilla(Me.cEmprEx1)
        'Me.cEmprEx2 = EscapeComilla(Me.cEmprEx2)
        'Me.cApellidos = EscapeComilla(Me.cApellidos)
        'Me.cNombres = EscapeComilla(Me.cNombres)
        'Me.cOcupacion = EscapeComilla(Me.cOcupacion)

        'Me.cNombresConyuge = EscapeComilla(Me.cNombresConyuge)
        'Me.cApellidosConyuge = EscapeComilla(Me.cApellidosConyuge)
        'Me.cNombresHijo = EscapeComilla(Me.cNombresHijo)
        'Me.cApellidosHijo = EscapeComilla(Me.cApellidosHijo)
        'Me.cCapacitacion = ""

        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "INSERT into dbo.CandidatoInforme (cDNI,cUbigeo,cApellidos,cNombres,cSexo,cEstCivil,cFono,cCorreo,dFechaNac,cCUI,cDireccion,cCondicion,cPuestoEspecialidad,cOcupacion,cOcupacion2,cEducaSecundaria,cEducaTecnica,cEducaSuperior,cExpLaboral,cEmprEx1,cCargoEx1,dFechaIniEx1,dFechaFinEx1,cEmprEx2,cCargoEx2,dFechaIniEx2,dFechaFinEx2,cComunidad,cMOCMONC,cObservacion,cAptitud,cUbigeoResidencia,dFechaDisponible,cCapacitacion,cLicenciaConducir,cCertificacion,iPAsertividad,iPTrabajoEquipo,iPComEfectiva,iPAdaptabilidad,iEEstable,iEInestable,iCCompromiso,iSRptoNorma,iSIperC,iSActitud,dFechaRegistro,iCodUsuarioRegistra,dFechaEvaluacion,bEvaluado,dFechaVerificativa,bVerificativa,iEstadoVerificativa,iResultadoVerificativa,dFechaCargaBox,bSustentoCV,bContratado,bCargaBox,bDNIMoq,bCasadoMoq,bConviveMoq,bHijosMoq,bRucMoq,bEstudioMoq,bTrabajoMoq,cTipoDoc,iTipoIngreso,cPaisNacimiento,iTiempoExperiencia,cDNIConyuge,cUbigeoConyuge,cApellidosConyuge,cNombresConyuge,cDNIHijo,cUbigeoHijo,cApellidosHijo,cNombresHijo,bComunidadPadron,bComunidadConstancia,bCip,bCumplePefil,bDisponible,dFechaEmisionDni,cEmpresaTrabaja,dFechaEvaluacionResultado,iCodPersonaEvalua,bDiscapacitado,bPrioritario,iCodUsuario,dFechaSis ) VALUES(@cDNI,@cUbigeo,@cApellidos,@cNombres,@cSexo,@cEstCivil,@cFono,@cCorreo,@dFechaNac,@cCUI,@cDireccion,@cCondicion,@cPuestoEspecialidad,@cOcupacion,@cOcupacion2,@cEducaSecundaria,@cEducaTecnica,@cEducaSuperior,@cExpLaboral,@cEmprEx1,@cCargoEx1,@dFechaIniEx1,@dFechaFinEx1,@cEmprEx2,@cCargoEx2,@dFechaIniEx2,@dFechaFinEx2,@cComunidad,@cMOCMONC,@cObservacion,@cAptitud,@cUbigeoResidencia,@dFechaDisponible,@cCapacitacion,@cLicenciaConducir,@cCertificacion,@iPAsertividad,@iPTrabajoEquipo,@iPComEfectiva,@iPAdaptabilidad,@iEEstable,@iEInestable,@iCCompromiso,@iSRptoNorma,@iSIperC,@iSActitud,@dFechaRegistro,@iCodUsuarioRegistra,@dFechaEvaluacion,@bEvaluado,@dFechaVerificativa,@bVerificativa,@iEstadoVerificativa,@iResultadoVerificativa,@dFechaCargaBox,@bSustentoCV,@bContratado,@bCargaBox,@bDNIMoq,@bCasadoMoq,@bConviveMoq,@bHijosMoq,@bRucMoq,@bEstudioMoq,@bTrabajoMoq,@cTipoDoc,@iTipoIngreso,@cPaisNacimiento,@iTiempoExperiencia,@cDNIConyuge,@cUbigeoConyuge,@cApellidosConyuge,@cNombresConyuge,@cDNIHijo,@cUbigeoHijo,@cApellidosHijo,@cNombresHijo,@bComunidadPadron,@bComunidadConstancia,@bCip,@bCumplePefil,@bDisponible,@dFechaEmisionDni,@cEmpresaTrabaja,@dFechaEvaluacionResultado,@iCodPersonaEvalua,@bDiscapacitado,@bPrioritario,@iCodUsuario,@dFechaSis); SELECT SCOPE_IDENTITY(); "
        cmdSQL.Parameters.Add("@cDNI", SqlDbType.VarChar, 20).Value = Me.cDNI
        cmdSQL.Parameters.Add("@cUbigeo", SqlDbType.VarChar, 8).Value = Me.cUbigeo
        cmdSQL.Parameters.Add("@cApellidos", SqlDbType.VarChar, 60).Value = Me.cApellidos
        cmdSQL.Parameters.Add("@cNombres", SqlDbType.VarChar, 60).Value = Me.cNombres
        cmdSQL.Parameters.Add("@cSexo", SqlDbType.VarChar, 2).Value = Me.cSexo
        cmdSQL.Parameters.Add("@cEstCivil", SqlDbType.VarChar, 20).Value = Me.cEstCivil
        cmdSQL.Parameters.Add("@cFono", SqlDbType.VarChar, 30).Value = Me.cFono
        cmdSQL.Parameters.Add("@cCorreo", SqlDbType.VarChar, 70).Value = Me.cCorreo
        cmdSQL.Parameters.Add("@dFechaNac", SqlDbType.Date).Value = Me.dFechaNac
        cmdSQL.Parameters.Add("@cCUI", SqlDbType.VarChar, 50).Value = Me.cCUI
        cmdSQL.Parameters.Add("@cDireccion", SqlDbType.VarChar, 100).Value = Me.cDireccion
        cmdSQL.Parameters.Add("@cCondicion", SqlDbType.VarChar, 250).Value = Me.cCondicion
        cmdSQL.Parameters.Add("@cPuestoEspecialidad", SqlDbType.VarChar, 250).Value = Me.cPuestoEspecialidad
        cmdSQL.Parameters.Add("@cOcupacion", SqlDbType.VarChar, 250).Value = Me.cOcupacion
        cmdSQL.Parameters.Add("@cOcupacion2", SqlDbType.VarChar, 70).Value = Me.cOcupacion2
        cmdSQL.Parameters.Add("@cEducaSecundaria", SqlDbType.VarChar, 50).Value = Me.cEducaSecundaria
        cmdSQL.Parameters.Add("@cEducaTecnica", SqlDbType.VarChar, 50).Value = Me.cEducaTecnica
        cmdSQL.Parameters.Add("@cEducaSuperior", SqlDbType.VarChar, 50).Value = Me.cEducaSuperior
        cmdSQL.Parameters.Add("@cExpLaboral", SqlDbType.VarChar, 500).Value = Me.cExpLaboral
        cmdSQL.Parameters.Add("@cEmprEx1", SqlDbType.VarChar, 150).Value = Me.cEmprEx1
        cmdSQL.Parameters.Add("@cCargoEx1", SqlDbType.VarChar, 80).Value = Me.cCargoEx1
        cmdSQL.Parameters.Add("@dFechaIniEx1", SqlDbType.Date).Value = Me.dFechaIniEx1
        cmdSQL.Parameters.Add("@dFechaFinEx1", SqlDbType.Date).Value = Me.dFechaFinEx1
        cmdSQL.Parameters.Add("@cEmprEx2", SqlDbType.VarChar, 150).Value = Me.cEmprEx2
        cmdSQL.Parameters.Add("@cCargoEx2", SqlDbType.VarChar, 80).Value = Me.cCargoEx2
        cmdSQL.Parameters.Add("@dFechaIniEx2", SqlDbType.Date).Value = Me.dFechaIniEx2
        cmdSQL.Parameters.Add("@dFechaFinEx2", SqlDbType.Date).Value = Me.dFechaFinEx2
        cmdSQL.Parameters.Add("@cComunidad", SqlDbType.VarChar, 60).Value = Me.cComunidad
        cmdSQL.Parameters.Add("@cMOCMONC", SqlDbType.VarChar, 10).Value = Me.cMOCMONC
        cmdSQL.Parameters.Add("@cObservacion", SqlDbType.VarChar, 120).Value = Me.cObservacion
        cmdSQL.Parameters.Add("@cAptitud", SqlDbType.VarChar, 50).Value = Me.cAptitud
        cmdSQL.Parameters.Add("@cUbigeoResidencia", SqlDbType.VarChar, 40).Value = Me.cUbigeoResidencia
        cmdSQL.Parameters.Add("@dFechaDisponible", SqlDbType.Date).Value = Me.dFechaDisponible
        cmdSQL.Parameters.Add("@cCapacitacion", SqlDbType.VarChar, 50).Value = Me.cCapacitacion
        cmdSQL.Parameters.Add("@cLicenciaConducir", SqlDbType.VarChar, 25).Value = Me.cLicenciaConducir
        cmdSQL.Parameters.Add("@cCertificacion", SqlDbType.VarChar, 60).Value = Me.cCertificacion
        cmdSQL.Parameters.Add("@iPAsertividad", SqlDbType.TinyInt).Value = Me.iPAsertividad
        cmdSQL.Parameters.Add("@iPTrabajoEquipo", SqlDbType.TinyInt).Value = Me.iPTrabajoEquipo
        cmdSQL.Parameters.Add("@iPComEfectiva", SqlDbType.TinyInt).Value = Me.iPComEfectiva
        cmdSQL.Parameters.Add("@iPAdaptabilidad", SqlDbType.TinyInt).Value = Me.iPAdaptabilidad
        cmdSQL.Parameters.Add("@iEEstable", SqlDbType.TinyInt).Value = Me.iEEstable
        cmdSQL.Parameters.Add("@iEInestable", SqlDbType.TinyInt).Value = Me.iEInestable
        cmdSQL.Parameters.Add("@iCCompromiso", SqlDbType.TinyInt).Value = Me.iCCompromiso
        cmdSQL.Parameters.Add("@iSRptoNorma", SqlDbType.TinyInt).Value = Me.iSRptoNorma
        cmdSQL.Parameters.Add("@iSIperC", SqlDbType.TinyInt).Value = Me.iSIperC
        cmdSQL.Parameters.Add("@iSActitud", SqlDbType.TinyInt).Value = Me.iSActitud
        cmdSQL.Parameters.Add("@dFechaRegistro", SqlDbType.Date).Value = Me.dFechaRegistro
        cmdSQL.Parameters.Add("@iCodUsuarioRegistra", SqlDbType.SmallInt).Value = Me.iCodUsuarioRegistra
        cmdSQL.Parameters.Add("@dFechaEvaluacion", SqlDbType.Date).Value = Me.dFechaEvaluacion
        cmdSQL.Parameters.Add("@bEvaluado", SqlDbType.Bit).Value = Me.bEvaluado
        cmdSQL.Parameters.Add("@dFechaVerificativa", SqlDbType.Date).Value = Me.dFechaVerificativa
        cmdSQL.Parameters.Add("@bVerificativa", SqlDbType.Bit).Value = Me.bVerificativa
        cmdSQL.Parameters.Add("@iEstadoVerificativa", SqlDbType.TinyInt).Value = Me.iEstadoVerificativa
        cmdSQL.Parameters.Add("@iResultadoVerificativa", SqlDbType.TinyInt).Value = Me.iResultadoVerificativa
        cmdSQL.Parameters.Add("@dFechaCargaBox", SqlDbType.Date).Value = Me.dFechaCargaBox
        cmdSQL.Parameters.Add("@bSustentoCV", SqlDbType.Bit).Value = Me.bSustentoCV
        cmdSQL.Parameters.Add("@bContratado", SqlDbType.Bit).Value = Me.bContratado
        cmdSQL.Parameters.Add("@bCargaBox", SqlDbType.Bit).Value = Me.bCargaBox
        cmdSQL.Parameters.Add("@bDNIMoq", SqlDbType.Bit).Value = Me.bDNIMoq
        cmdSQL.Parameters.Add("@bCasadoMoq", SqlDbType.Bit).Value = Me.bCasadoMoq
        cmdSQL.Parameters.Add("@bConviveMoq", SqlDbType.Bit).Value = Me.bConviveMoq
        cmdSQL.Parameters.Add("@bHijosMoq", SqlDbType.Bit).Value = Me.bHijosMoq
        cmdSQL.Parameters.Add("@bRucMoq", SqlDbType.Bit).Value = Me.bRucMoq
        cmdSQL.Parameters.Add("@bEstudioMoq", SqlDbType.Bit).Value = Me.bEstudioMoq
        cmdSQL.Parameters.Add("@bTrabajoMoq", SqlDbType.Bit).Value = Me.bTrabajoMoq
        cmdSQL.Parameters.Add("@cTipoDoc", SqlDbType.VarChar, 5).Value = Me.cTipoDoc
        cmdSQL.Parameters.Add("@iTipoIngreso", SqlDbType.TinyInt).Value = Me.iTipoIngreso
        cmdSQL.Parameters.Add("@cPaisNacimiento", SqlDbType.VarChar, 30).Value = Me.cPaisNacimiento
        cmdSQL.Parameters.Add("@iTiempoExperiencia", SqlDbType.SmallInt).Value = Me.iTiempoExperiencia
        cmdSQL.Parameters.Add("@cDNIConyuge", SqlDbType.VarChar, 10).Value = Me.cDNIConyuge
        cmdSQL.Parameters.Add("@cUbigeoConyuge", SqlDbType.VarChar, 8).Value = Me.cUbigeoConyuge
        cmdSQL.Parameters.Add("@cApellidosConyuge", SqlDbType.VarChar, 50).Value = Me.cApellidosConyuge
        cmdSQL.Parameters.Add("@cNombresConyuge", SqlDbType.VarChar, 50).Value = Me.cNombresConyuge
        cmdSQL.Parameters.Add("@cDNIHijo", SqlDbType.VarChar, 10).Value = Me.cDNIHijo
        cmdSQL.Parameters.Add("@cUbigeoHijo", SqlDbType.VarChar, 8).Value = Me.cUbigeoHijo
        cmdSQL.Parameters.Add("@cApellidosHijo", SqlDbType.VarChar, 50).Value = Me.cApellidosHijo
        cmdSQL.Parameters.Add("@cNombresHijo", SqlDbType.VarChar, 50).Value = Me.cNombresHijo
        cmdSQL.Parameters.Add("@bComunidadPadron", SqlDbType.Bit).Value = Me.bComunidadPadron
        cmdSQL.Parameters.Add("@bComunidadConstancia", SqlDbType.Bit).Value = Me.bComunidadConstancia
        cmdSQL.Parameters.Add("@bCip", SqlDbType.Bit).Value = Me.bCip
        cmdSQL.Parameters.Add("@bCumplePefil", SqlDbType.Bit).Value = Me.bCumplePefil
        cmdSQL.Parameters.Add("@bDisponible", SqlDbType.Bit).Value = Me.bDisponible
        cmdSQL.Parameters.Add("@dFechaEmisionDni", SqlDbType.Date).Value = Me.dFechaEmisionDni
        cmdSQL.Parameters.Add("@cEmpresaTrabaja", SqlDbType.VarChar, 50).Value = Me.cEmpresaTrabaja
        cmdSQL.Parameters.Add("@dFechaEvaluacionResultado", SqlDbType.Date).Value = Me.dFechaEvaluacionResultado
        cmdSQL.Parameters.Add("@iCodPersonaEvalua", SqlDbType.Int).Value = Me.iCodPersonaEvalua
        cmdSQL.Parameters.Add("@bDiscapacitado", SqlDbType.Bit).Value = Me.bDiscapacitado
        cmdSQL.Parameters.Add("@bPrioritario", SqlDbType.Bit).Value = Me.bPrioritario
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.DateTime).Value = Me.dFechaSis

        Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
        If pCodInsert > 0 Then
            Me.iCodCandidatoInforme = pCodInsert
        Else
            Me.iCodCandidatoInforme = 0
        End If
    End Sub
    Public Sub Modificar()
        'Me.cEmprEx1 = EscapeComilla(Me.cEmprEx1)
        'Me.cEmprEx2 = EscapeComilla(Me.cEmprEx2)
        'Me.cApellidos = EscapeComilla(Me.cApellidos)
        'Me.cNombres = EscapeComilla(Me.cNombres)
        'Me.cOcupacion = EscapeComilla(Me.cOcupacion)

        'Me.cNombresConyuge = EscapeComilla(Me.cNombresConyuge)
        'Me.cApellidosConyuge = EscapeComilla(Me.cApellidosConyuge)
        'Me.cNombresHijo = EscapeComilla(Me.cNombresHijo)
        'Me.cApellidosHijo = EscapeComilla(Me.cApellidosHijo)
        'Me.cCapacitacion = ""


        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "UPDATE  dbo.CandidatoInforme SET cDNI=@cDNI,cUbigeo=@cUbigeo,cApellidos=@cApellidos,cNombres=@cNombres,cSexo=@cSexo,cEstCivil=@cEstCivil,cFono=@cFono,cCorreo=@cCorreo,dFechaNac=@dFechaNac,cCUI=@cCUI,cDireccion=@cDireccion,cCondicion=@cCondicion,cPuestoEspecialidad=@cPuestoEspecialidad,cOcupacion=@cOcupacion,cOcupacion2=@cOcupacion2,cEducaSecundaria=@cEducaSecundaria,cEducaTecnica=@cEducaTecnica,cEducaSuperior=@cEducaSuperior,cExpLaboral=@cExpLaboral,cEmprEx1=@cEmprEx1,cCargoEx1=@cCargoEx1,dFechaIniEx1=@dFechaIniEx1,dFechaFinEx1=@dFechaFinEx1,cEmprEx2=@cEmprEx2,cCargoEx2=@cCargoEx2,dFechaIniEx2=@dFechaIniEx2,dFechaFinEx2=@dFechaFinEx2,cComunidad=@cComunidad,cMOCMONC=@cMOCMONC,cObservacion=@cObservacion,cAptitud=@cAptitud,cUbigeoResidencia=@cUbigeoResidencia,dFechaDisponible=@dFechaDisponible,cCapacitacion=@cCapacitacion,cLicenciaConducir=@cLicenciaConducir,cCertificacion=@cCertificacion,iPAsertividad=@iPAsertividad,iPTrabajoEquipo=@iPTrabajoEquipo,iPComEfectiva=@iPComEfectiva,iPAdaptabilidad=@iPAdaptabilidad,iEEstable=@iEEstable,iEInestable=@iEInestable,iCCompromiso=@iCCompromiso,iSRptoNorma=@iSRptoNorma,iSIperC=@iSIperC,iSActitud=@iSActitud,dFechaRegistro=@dFechaRegistro,iCodUsuarioRegistra=@iCodUsuarioRegistra,dFechaEvaluacion=@dFechaEvaluacion,bEvaluado=@bEvaluado,dFechaVerificativa=@dFechaVerificativa,bVerificativa=@bVerificativa,iEstadoVerificativa=@iEstadoVerificativa,iResultadoVerificativa=@iResultadoVerificativa,dFechaCargaBox=@dFechaCargaBox,bSustentoCV=@bSustentoCV,bContratado=@bContratado,bCargaBox=@bCargaBox,bDNIMoq=@bDNIMoq,bCasadoMoq=@bCasadoMoq,bConviveMoq=@bConviveMoq,bHijosMoq=@bHijosMoq,bRucMoq=@bRucMoq,bEstudioMoq=@bEstudioMoq,bTrabajoMoq=@bTrabajoMoq,cTipoDoc=@cTipoDoc,iTipoIngreso=@iTipoIngreso,cPaisNacimiento=@cPaisNacimiento,iTiempoExperiencia=@iTiempoExperiencia,cDNIConyuge=@cDNIConyuge,cUbigeoConyuge=@cUbigeoConyuge,cApellidosConyuge=@cApellidosConyuge,cNombresConyuge=@cNombresConyuge,cDNIHijo=@cDNIHijo,cUbigeoHijo=@cUbigeoHijo,cApellidosHijo=@cApellidosHijo,cNombresHijo=@cNombresHijo,bComunidadPadron=@bComunidadPadron,bComunidadConstancia=@bComunidadConstancia,bCip=@bCip,bCumplePefil=@bCumplePefil,bDisponible=@bDisponible,dFechaEmisionDni=@dFechaEmisionDni,cEmpresaTrabaja=@cEmpresaTrabaja,dFechaEvaluacionResultado=@dFechaEvaluacionResultado,iCodPersonaEvalua=@iCodPersonaEvalua,bDiscapacitado=@bDiscapacitado,bPrioritario=@bPrioritario,iCodUsuario=@iCodUsuario,dFechaSis=@dFechaSis WHERE iCodCandidatoInforme=@iCodCandidatoInforme"
        cmdSQL.Parameters.Add("@iCodCandidatoInforme", SqlDbType.Int).Value = Me.iCodCandidatoInforme
        cmdSQL.Parameters.Add("@cDNI", SqlDbType.VarChar, 20).Value = Me.cDNI
        cmdSQL.Parameters.Add("@cUbigeo", SqlDbType.VarChar, 8).Value = Me.cUbigeo
        cmdSQL.Parameters.Add("@cApellidos", SqlDbType.VarChar, 60).Value = Me.cApellidos
        cmdSQL.Parameters.Add("@cNombres", SqlDbType.VarChar, 60).Value = Me.cNombres
        cmdSQL.Parameters.Add("@cSexo", SqlDbType.VarChar, 2).Value = Me.cSexo
        cmdSQL.Parameters.Add("@cEstCivil", SqlDbType.VarChar, 20).Value = Me.cEstCivil
        cmdSQL.Parameters.Add("@cFono", SqlDbType.VarChar, 30).Value = Me.cFono
        cmdSQL.Parameters.Add("@cCorreo", SqlDbType.VarChar, 70).Value = Me.cCorreo
        cmdSQL.Parameters.Add("@dFechaNac", SqlDbType.Date).Value = Me.dFechaNac
        cmdSQL.Parameters.Add("@cCUI", SqlDbType.VarChar, 50).Value = Me.cCUI
        cmdSQL.Parameters.Add("@cDireccion", SqlDbType.VarChar, 100).Value = Me.cDireccion
        cmdSQL.Parameters.Add("@cCondicion", SqlDbType.VarChar, 250).Value = Me.cCondicion
        cmdSQL.Parameters.Add("@cPuestoEspecialidad", SqlDbType.VarChar, 250).Value = Me.cPuestoEspecialidad
        cmdSQL.Parameters.Add("@cOcupacion", SqlDbType.VarChar, 250).Value = Me.cOcupacion
        cmdSQL.Parameters.Add("@cOcupacion2", SqlDbType.VarChar, 70).Value = Me.cOcupacion2
        cmdSQL.Parameters.Add("@cEducaSecundaria", SqlDbType.VarChar, 50).Value = Me.cEducaSecundaria
        cmdSQL.Parameters.Add("@cEducaTecnica", SqlDbType.VarChar, 50).Value = Me.cEducaTecnica
        cmdSQL.Parameters.Add("@cEducaSuperior", SqlDbType.VarChar, 50).Value = Me.cEducaSuperior
        cmdSQL.Parameters.Add("@cExpLaboral", SqlDbType.VarChar, 500).Value = Me.cExpLaboral
        cmdSQL.Parameters.Add("@cEmprEx1", SqlDbType.VarChar, 150).Value = Me.cEmprEx1
        cmdSQL.Parameters.Add("@cCargoEx1", SqlDbType.VarChar, 80).Value = Me.cCargoEx1
        cmdSQL.Parameters.Add("@dFechaIniEx1", SqlDbType.Date).Value = Me.dFechaIniEx1
        cmdSQL.Parameters.Add("@dFechaFinEx1", SqlDbType.Date).Value = Me.dFechaFinEx1
        cmdSQL.Parameters.Add("@cEmprEx2", SqlDbType.VarChar, 150).Value = Me.cEmprEx2
        cmdSQL.Parameters.Add("@cCargoEx2", SqlDbType.VarChar, 80).Value = Me.cCargoEx2
        cmdSQL.Parameters.Add("@dFechaIniEx2", SqlDbType.Date).Value = Me.dFechaIniEx2
        cmdSQL.Parameters.Add("@dFechaFinEx2", SqlDbType.Date).Value = Me.dFechaFinEx2
        cmdSQL.Parameters.Add("@cComunidad", SqlDbType.VarChar, 60).Value = Me.cComunidad
        cmdSQL.Parameters.Add("@cMOCMONC", SqlDbType.VarChar, 10).Value = Me.cMOCMONC
        cmdSQL.Parameters.Add("@cObservacion", SqlDbType.VarChar, 120).Value = Me.cObservacion
        cmdSQL.Parameters.Add("@cAptitud", SqlDbType.VarChar, 50).Value = Me.cAptitud
        cmdSQL.Parameters.Add("@cUbigeoResidencia", SqlDbType.VarChar, 40).Value = Me.cUbigeoResidencia
        cmdSQL.Parameters.Add("@dFechaDisponible", SqlDbType.Date).Value = Me.dFechaDisponible
        cmdSQL.Parameters.Add("@cCapacitacion", SqlDbType.VarChar, 50).Value = Me.cCapacitacion
        cmdSQL.Parameters.Add("@cLicenciaConducir", SqlDbType.VarChar, 25).Value = Me.cLicenciaConducir
        cmdSQL.Parameters.Add("@cCertificacion", SqlDbType.VarChar, 60).Value = Me.cCertificacion
        cmdSQL.Parameters.Add("@iPAsertividad", SqlDbType.TinyInt).Value = Me.iPAsertividad
        cmdSQL.Parameters.Add("@iPTrabajoEquipo", SqlDbType.TinyInt).Value = Me.iPTrabajoEquipo
        cmdSQL.Parameters.Add("@iPComEfectiva", SqlDbType.TinyInt).Value = Me.iPComEfectiva
        cmdSQL.Parameters.Add("@iPAdaptabilidad", SqlDbType.TinyInt).Value = Me.iPAdaptabilidad
        cmdSQL.Parameters.Add("@iEEstable", SqlDbType.TinyInt).Value = Me.iEEstable
        cmdSQL.Parameters.Add("@iEInestable", SqlDbType.TinyInt).Value = Me.iEInestable
        cmdSQL.Parameters.Add("@iCCompromiso", SqlDbType.TinyInt).Value = Me.iCCompromiso
        cmdSQL.Parameters.Add("@iSRptoNorma", SqlDbType.TinyInt).Value = Me.iSRptoNorma
        cmdSQL.Parameters.Add("@iSIperC", SqlDbType.TinyInt).Value = Me.iSIperC
        cmdSQL.Parameters.Add("@iSActitud", SqlDbType.TinyInt).Value = Me.iSActitud
        cmdSQL.Parameters.Add("@dFechaRegistro", SqlDbType.Date).Value = Me.dFechaRegistro
        cmdSQL.Parameters.Add("@iCodUsuarioRegistra", SqlDbType.SmallInt).Value = Me.iCodUsuarioRegistra
        cmdSQL.Parameters.Add("@dFechaEvaluacion", SqlDbType.Date).Value = Me.dFechaEvaluacion
        cmdSQL.Parameters.Add("@bEvaluado", SqlDbType.Bit).Value = Me.bEvaluado
        cmdSQL.Parameters.Add("@dFechaVerificativa", SqlDbType.Date).Value = Me.dFechaVerificativa
        cmdSQL.Parameters.Add("@bVerificativa", SqlDbType.Bit).Value = Me.bVerificativa
        cmdSQL.Parameters.Add("@iEstadoVerificativa", SqlDbType.TinyInt).Value = Me.iEstadoVerificativa
        cmdSQL.Parameters.Add("@iResultadoVerificativa", SqlDbType.TinyInt).Value = Me.iResultadoVerificativa
        cmdSQL.Parameters.Add("@dFechaCargaBox", SqlDbType.Date).Value = Me.dFechaCargaBox
        cmdSQL.Parameters.Add("@bSustentoCV", SqlDbType.Bit).Value = Me.bSustentoCV
        cmdSQL.Parameters.Add("@bContratado", SqlDbType.Bit).Value = Me.bContratado
        cmdSQL.Parameters.Add("@bCargaBox", SqlDbType.Bit).Value = Me.bCargaBox
        cmdSQL.Parameters.Add("@bDNIMoq", SqlDbType.Bit).Value = Me.bDNIMoq
        cmdSQL.Parameters.Add("@bCasadoMoq", SqlDbType.Bit).Value = Me.bCasadoMoq
        cmdSQL.Parameters.Add("@bConviveMoq", SqlDbType.Bit).Value = Me.bConviveMoq
        cmdSQL.Parameters.Add("@bHijosMoq", SqlDbType.Bit).Value = Me.bHijosMoq
        cmdSQL.Parameters.Add("@bRucMoq", SqlDbType.Bit).Value = Me.bRucMoq
        cmdSQL.Parameters.Add("@bEstudioMoq", SqlDbType.Bit).Value = Me.bEstudioMoq
        cmdSQL.Parameters.Add("@bTrabajoMoq", SqlDbType.Bit).Value = Me.bTrabajoMoq
        cmdSQL.Parameters.Add("@cTipoDoc", SqlDbType.VarChar, 5).Value = Me.cTipoDoc
        cmdSQL.Parameters.Add("@iTipoIngreso", SqlDbType.TinyInt).Value = Me.iTipoIngreso
        cmdSQL.Parameters.Add("@cPaisNacimiento", SqlDbType.VarChar, 30).Value = Me.cPaisNacimiento
        cmdSQL.Parameters.Add("@iTiempoExperiencia", SqlDbType.SmallInt).Value = Me.iTiempoExperiencia
        cmdSQL.Parameters.Add("@cDNIConyuge", SqlDbType.VarChar, 10).Value = Me.cDNIConyuge
        cmdSQL.Parameters.Add("@cUbigeoConyuge", SqlDbType.VarChar, 8).Value = Me.cUbigeoConyuge
        cmdSQL.Parameters.Add("@cApellidosConyuge", SqlDbType.VarChar, 50).Value = Me.cApellidosConyuge
        cmdSQL.Parameters.Add("@cNombresConyuge", SqlDbType.VarChar, 50).Value = Me.cNombresConyuge
        cmdSQL.Parameters.Add("@cDNIHijo", SqlDbType.VarChar, 10).Value = Me.cDNIHijo
        cmdSQL.Parameters.Add("@cUbigeoHijo", SqlDbType.VarChar, 8).Value = Me.cUbigeoHijo
        cmdSQL.Parameters.Add("@cApellidosHijo", SqlDbType.VarChar, 50).Value = Me.cApellidosHijo
        cmdSQL.Parameters.Add("@cNombresHijo", SqlDbType.VarChar, 50).Value = Me.cNombresHijo
        cmdSQL.Parameters.Add("@bComunidadPadron", SqlDbType.Bit).Value = Me.bComunidadPadron
        cmdSQL.Parameters.Add("@bComunidadConstancia", SqlDbType.Bit).Value = Me.bComunidadConstancia
        cmdSQL.Parameters.Add("@bCip", SqlDbType.Bit).Value = Me.bCip
        cmdSQL.Parameters.Add("@bCumplePefil", SqlDbType.Bit).Value = Me.bCumplePefil
        cmdSQL.Parameters.Add("@bDisponible", SqlDbType.Bit).Value = Me.bDisponible
        cmdSQL.Parameters.Add("@dFechaEmisionDni", SqlDbType.Date).Value = Me.dFechaEmisionDni
        cmdSQL.Parameters.Add("@cEmpresaTrabaja", SqlDbType.VarChar, 50).Value = Me.cEmpresaTrabaja
        cmdSQL.Parameters.Add("@dFechaEvaluacionResultado", SqlDbType.Date).Value = Me.dFechaEvaluacionResultado
        cmdSQL.Parameters.Add("@iCodPersonaEvalua", SqlDbType.Int).Value = Me.iCodPersonaEvalua
        cmdSQL.Parameters.Add("@bDiscapacitado", SqlDbType.Bit).Value = Me.bDiscapacitado
        cmdSQL.Parameters.Add("@bPrioritario", SqlDbType.Bit).Value = Me.bPrioritario
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.DateTime).Value = Me.dFechaSis

        cmdSQL.ExecuteNonQuery()

    End Sub
    Public Sub ModificarTransact()
        'Me.cEmprEx1 = EscapeComilla(Me.cEmprEx1)
        'Me.cEmprEx2 = EscapeComilla(Me.cEmprEx2)
        'Me.cApellidos = EscapeComilla(Me.cApellidos)
        'Me.cNombres = EscapeComilla(Me.cNombres)
        'Me.cOcupacion = EscapeComilla(Me.cOcupacion)

        'Me.cNombresConyuge = EscapeComilla(Me.cNombresConyuge)
        'Me.cApellidosConyuge = EscapeComilla(Me.cApellidosConyuge)
        'Me.cNombresHijo = EscapeComilla(Me.cNombresHijo)
        'Me.cApellidosHijo = EscapeComilla(Me.cApellidosHijo)
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "UPDATE  dbo.CandidatoInforme SET cDNI=@cDNI,cUbigeo=@cUbigeo,cApellidos=@cApellidos,cNombres=@cNombres,cSexo=@cSexo,cEstCivil=@cEstCivil,cFono=@cFono,cCorreo=@cCorreo,dFechaNac=@dFechaNac,cCUI=@cCUI,cDireccion=@cDireccion,cCondicion=@cCondicion,cPuestoEspecialidad=@cPuestoEspecialidad,cOcupacion=@cOcupacion,cOcupacion2=@cOcupacion2,cEducaSecundaria=@cEducaSecundaria,cEducaTecnica=@cEducaTecnica,cEducaSuperior=@cEducaSuperior,cExpLaboral=@cExpLaboral,cEmprEx1=@cEmprEx1,cCargoEx1=@cCargoEx1,dFechaIniEx1=@dFechaIniEx1,dFechaFinEx1=@dFechaFinEx1,cEmprEx2=@cEmprEx2,cCargoEx2=@cCargoEx2,dFechaIniEx2=@dFechaIniEx2,dFechaFinEx2=@dFechaFinEx2,cComunidad=@cComunidad,cMOCMONC=@cMOCMONC,cObservacion=@cObservacion,cAptitud=@cAptitud,cUbigeoResidencia=@cUbigeoResidencia,dFechaDisponible=@dFechaDisponible,cCapacitacion=@cCapacitacion,cLicenciaConducir=@cLicenciaConducir,cCertificacion=@cCertificacion,iPAsertividad=@iPAsertividad,iPTrabajoEquipo=@iPTrabajoEquipo,iPComEfectiva=@iPComEfectiva,iPAdaptabilidad=@iPAdaptabilidad,iEEstable=@iEEstable,iEInestable=@iEInestable,iCCompromiso=@iCCompromiso,iSRptoNorma=@iSRptoNorma,iSIperC=@iSIperC,iSActitud=@iSActitud,dFechaRegistro=@dFechaRegistro,iCodUsuarioRegistra=@iCodUsuarioRegistra,dFechaEvaluacion=@dFechaEvaluacion,bEvaluado=@bEvaluado,dFechaVerificativa=@dFechaVerificativa,bVerificativa=@bVerificativa,iEstadoVerificativa=@iEstadoVerificativa,iResultadoVerificativa=@iResultadoVerificativa,dFechaCargaBox=@dFechaCargaBox,bSustentoCV=@bSustentoCV,bContratado=@bContratado,bCargaBox=@bCargaBox,bDNIMoq=@bDNIMoq,bCasadoMoq=@bCasadoMoq,bConviveMoq=@bConviveMoq,bHijosMoq=@bHijosMoq,bRucMoq=@bRucMoq,bEstudioMoq=@bEstudioMoq,bTrabajoMoq=@bTrabajoMoq,cTipoDoc=@cTipoDoc,iTipoIngreso=@iTipoIngreso,cPaisNacimiento=@cPaisNacimiento,iTiempoExperiencia=@iTiempoExperiencia,cDNIConyuge=@cDNIConyuge,cUbigeoConyuge=@cUbigeoConyuge,cApellidosConyuge=@cApellidosConyuge,cNombresConyuge=@cNombresConyuge,cDNIHijo=@cDNIHijo,cUbigeoHijo=@cUbigeoHijo,cApellidosHijo=@cApellidosHijo,cNombresHijo=@cNombresHijo,bComunidadPadron=@bComunidadPadron,bComunidadConstancia=@bComunidadConstancia,bCip=@bCip,bCumplePefil=@bCumplePefil,bDisponible=@bDisponible,dFechaEmisionDni=@dFechaEmisionDni,cEmpresaTrabaja=@cEmpresaTrabaja,dFechaEvaluacionResultado=@dFechaEvaluacionResultado,iCodPersonaEvalua=@iCodPersonaEvalua,bDiscapacitado=@bDiscapacitado,bPrioritario=@bPrioritario,iCodUsuario=@iCodUsuario,dFechaSis=@dFechaSis WHERE iCodCandidatoInforme=@iCodCandidatoInforme"
        cmdSQL.Parameters.Add("@iCodCandidatoInforme", SqlDbType.Int).Value = Me.iCodCandidatoInforme
        cmdSQL.Parameters.Add("@cDNI", SqlDbType.VarChar, 20).Value = Me.cDNI
        cmdSQL.Parameters.Add("@cUbigeo", SqlDbType.VarChar, 8).Value = Me.cUbigeo
        cmdSQL.Parameters.Add("@cApellidos", SqlDbType.VarChar, 60).Value = Me.cApellidos
        cmdSQL.Parameters.Add("@cNombres", SqlDbType.VarChar, 60).Value = Me.cNombres
        cmdSQL.Parameters.Add("@cSexo", SqlDbType.VarChar, 2).Value = Me.cSexo
        cmdSQL.Parameters.Add("@cEstCivil", SqlDbType.VarChar, 20).Value = Me.cEstCivil
        cmdSQL.Parameters.Add("@cFono", SqlDbType.VarChar, 30).Value = Me.cFono
        cmdSQL.Parameters.Add("@cCorreo", SqlDbType.VarChar, 70).Value = Me.cCorreo
        cmdSQL.Parameters.Add("@dFechaNac", SqlDbType.Date).Value = Me.dFechaNac
        cmdSQL.Parameters.Add("@cCUI", SqlDbType.VarChar, 50).Value = Me.cCUI
        cmdSQL.Parameters.Add("@cDireccion", SqlDbType.VarChar, 100).Value = Me.cDireccion
        cmdSQL.Parameters.Add("@cCondicion", SqlDbType.VarChar, 250).Value = Me.cCondicion
        cmdSQL.Parameters.Add("@cPuestoEspecialidad", SqlDbType.VarChar, 250).Value = Me.cPuestoEspecialidad
        cmdSQL.Parameters.Add("@cOcupacion", SqlDbType.VarChar, 250).Value = Me.cOcupacion
        cmdSQL.Parameters.Add("@cOcupacion2", SqlDbType.VarChar, 70).Value = Me.cOcupacion2
        cmdSQL.Parameters.Add("@cEducaSecundaria", SqlDbType.VarChar, 50).Value = Me.cEducaSecundaria
        cmdSQL.Parameters.Add("@cEducaTecnica", SqlDbType.VarChar, 50).Value = Me.cEducaTecnica
        cmdSQL.Parameters.Add("@cEducaSuperior", SqlDbType.VarChar, 50).Value = Me.cEducaSuperior
        cmdSQL.Parameters.Add("@cExpLaboral", SqlDbType.VarChar, 500).Value = Me.cExpLaboral
        cmdSQL.Parameters.Add("@cEmprEx1", SqlDbType.VarChar, 150).Value = Me.cEmprEx1
        cmdSQL.Parameters.Add("@cCargoEx1", SqlDbType.VarChar, 80).Value = Me.cCargoEx1
        cmdSQL.Parameters.Add("@dFechaIniEx1", SqlDbType.Date).Value = Me.dFechaIniEx1
        cmdSQL.Parameters.Add("@dFechaFinEx1", SqlDbType.Date).Value = Me.dFechaFinEx1
        cmdSQL.Parameters.Add("@cEmprEx2", SqlDbType.VarChar, 150).Value = Me.cEmprEx2
        cmdSQL.Parameters.Add("@cCargoEx2", SqlDbType.VarChar, 80).Value = Me.cCargoEx2
        cmdSQL.Parameters.Add("@dFechaIniEx2", SqlDbType.Date).Value = Me.dFechaIniEx2
        cmdSQL.Parameters.Add("@dFechaFinEx2", SqlDbType.Date).Value = Me.dFechaFinEx2
        cmdSQL.Parameters.Add("@cComunidad", SqlDbType.VarChar, 60).Value = Me.cComunidad
        cmdSQL.Parameters.Add("@cMOCMONC", SqlDbType.VarChar, 10).Value = Me.cMOCMONC
        cmdSQL.Parameters.Add("@cObservacion", SqlDbType.VarChar, 120).Value = Me.cObservacion
        cmdSQL.Parameters.Add("@cAptitud", SqlDbType.VarChar, 50).Value = Me.cAptitud
        cmdSQL.Parameters.Add("@cUbigeoResidencia", SqlDbType.VarChar, 40).Value = Me.cUbigeoResidencia
        cmdSQL.Parameters.Add("@dFechaDisponible", SqlDbType.Date).Value = Me.dFechaDisponible
        cmdSQL.Parameters.Add("@cCapacitacion", SqlDbType.VarChar, 50).Value = Me.cCapacitacion
        cmdSQL.Parameters.Add("@cLicenciaConducir", SqlDbType.VarChar, 25).Value = Me.cLicenciaConducir
        cmdSQL.Parameters.Add("@cCertificacion", SqlDbType.VarChar, 60).Value = Me.cCertificacion
        cmdSQL.Parameters.Add("@iPAsertividad", SqlDbType.TinyInt).Value = Me.iPAsertividad
        cmdSQL.Parameters.Add("@iPTrabajoEquipo", SqlDbType.TinyInt).Value = Me.iPTrabajoEquipo
        cmdSQL.Parameters.Add("@iPComEfectiva", SqlDbType.TinyInt).Value = Me.iPComEfectiva
        cmdSQL.Parameters.Add("@iPAdaptabilidad", SqlDbType.TinyInt).Value = Me.iPAdaptabilidad
        cmdSQL.Parameters.Add("@iEEstable", SqlDbType.TinyInt).Value = Me.iEEstable
        cmdSQL.Parameters.Add("@iEInestable", SqlDbType.TinyInt).Value = Me.iEInestable
        cmdSQL.Parameters.Add("@iCCompromiso", SqlDbType.TinyInt).Value = Me.iCCompromiso
        cmdSQL.Parameters.Add("@iSRptoNorma", SqlDbType.TinyInt).Value = Me.iSRptoNorma
        cmdSQL.Parameters.Add("@iSIperC", SqlDbType.TinyInt).Value = Me.iSIperC
        cmdSQL.Parameters.Add("@iSActitud", SqlDbType.TinyInt).Value = Me.iSActitud
        cmdSQL.Parameters.Add("@dFechaRegistro", SqlDbType.Date).Value = Me.dFechaRegistro
        cmdSQL.Parameters.Add("@iCodUsuarioRegistra", SqlDbType.SmallInt).Value = Me.iCodUsuarioRegistra
        cmdSQL.Parameters.Add("@dFechaEvaluacion", SqlDbType.Date).Value = Me.dFechaEvaluacion
        cmdSQL.Parameters.Add("@bEvaluado", SqlDbType.Bit).Value = Me.bEvaluado
        cmdSQL.Parameters.Add("@dFechaVerificativa", SqlDbType.Date).Value = Me.dFechaVerificativa
        cmdSQL.Parameters.Add("@bVerificativa", SqlDbType.Bit).Value = Me.bVerificativa
        cmdSQL.Parameters.Add("@iEstadoVerificativa", SqlDbType.TinyInt).Value = Me.iEstadoVerificativa
        cmdSQL.Parameters.Add("@iResultadoVerificativa", SqlDbType.TinyInt).Value = Me.iResultadoVerificativa
        cmdSQL.Parameters.Add("@dFechaCargaBox", SqlDbType.Date).Value = Me.dFechaCargaBox
        cmdSQL.Parameters.Add("@bSustentoCV", SqlDbType.Bit).Value = Me.bSustentoCV
        cmdSQL.Parameters.Add("@bContratado", SqlDbType.Bit).Value = Me.bContratado
        cmdSQL.Parameters.Add("@bCargaBox", SqlDbType.Bit).Value = Me.bCargaBox
        cmdSQL.Parameters.Add("@bDNIMoq", SqlDbType.Bit).Value = Me.bDNIMoq
        cmdSQL.Parameters.Add("@bCasadoMoq", SqlDbType.Bit).Value = Me.bCasadoMoq
        cmdSQL.Parameters.Add("@bConviveMoq", SqlDbType.Bit).Value = Me.bConviveMoq
        cmdSQL.Parameters.Add("@bHijosMoq", SqlDbType.Bit).Value = Me.bHijosMoq
        cmdSQL.Parameters.Add("@bRucMoq", SqlDbType.Bit).Value = Me.bRucMoq
        cmdSQL.Parameters.Add("@bEstudioMoq", SqlDbType.Bit).Value = Me.bEstudioMoq
        cmdSQL.Parameters.Add("@bTrabajoMoq", SqlDbType.Bit).Value = Me.bTrabajoMoq
        cmdSQL.Parameters.Add("@cTipoDoc", SqlDbType.VarChar, 5).Value = Me.cTipoDoc
        cmdSQL.Parameters.Add("@iTipoIngreso", SqlDbType.TinyInt).Value = Me.iTipoIngreso
        cmdSQL.Parameters.Add("@cPaisNacimiento", SqlDbType.VarChar, 30).Value = Me.cPaisNacimiento
        cmdSQL.Parameters.Add("@iTiempoExperiencia", SqlDbType.SmallInt).Value = Me.iTiempoExperiencia
        cmdSQL.Parameters.Add("@cDNIConyuge", SqlDbType.VarChar, 10).Value = Me.cDNIConyuge
        cmdSQL.Parameters.Add("@cUbigeoConyuge", SqlDbType.VarChar, 8).Value = Me.cUbigeoConyuge
        cmdSQL.Parameters.Add("@cApellidosConyuge", SqlDbType.VarChar, 50).Value = Me.cApellidosConyuge
        cmdSQL.Parameters.Add("@cNombresConyuge", SqlDbType.VarChar, 50).Value = Me.cNombresConyuge
        cmdSQL.Parameters.Add("@cDNIHijo", SqlDbType.VarChar, 10).Value = Me.cDNIHijo
        cmdSQL.Parameters.Add("@cUbigeoHijo", SqlDbType.VarChar, 8).Value = Me.cUbigeoHijo
        cmdSQL.Parameters.Add("@cApellidosHijo", SqlDbType.VarChar, 50).Value = Me.cApellidosHijo
        cmdSQL.Parameters.Add("@cNombresHijo", SqlDbType.VarChar, 50).Value = Me.cNombresHijo
        cmdSQL.Parameters.Add("@bComunidadPadron", SqlDbType.Bit).Value = Me.bComunidadPadron
        cmdSQL.Parameters.Add("@bComunidadConstancia", SqlDbType.Bit).Value = Me.bComunidadConstancia
        cmdSQL.Parameters.Add("@bCip", SqlDbType.Bit).Value = Me.bCip
        cmdSQL.Parameters.Add("@bCumplePefil", SqlDbType.Bit).Value = Me.bCumplePefil
        cmdSQL.Parameters.Add("@bDisponible", SqlDbType.Bit).Value = Me.bDisponible
        cmdSQL.Parameters.Add("@dFechaEmisionDni", SqlDbType.Date).Value = Me.dFechaEmisionDni
        cmdSQL.Parameters.Add("@cEmpresaTrabaja", SqlDbType.VarChar, 50).Value = Me.cEmpresaTrabaja
        cmdSQL.Parameters.Add("@dFechaEvaluacionResultado", SqlDbType.Date).Value = Me.dFechaEvaluacionResultado
        cmdSQL.Parameters.Add("@iCodPersonaEvalua", SqlDbType.Int).Value = Me.iCodPersonaEvalua
        cmdSQL.Parameters.Add("@bDiscapacitado", SqlDbType.Bit).Value = Me.bDiscapacitado
        cmdSQL.Parameters.Add("@bPrioritario", SqlDbType.Bit).Value = Me.bPrioritario
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.DateTime).Value = Me.dFechaSis

        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub Eliminar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "DELETE from  dbo.CandidatoInforme  WHERE iCodCandidatoInforme=@iCodCandidatoInforme"
        'cmdSQL.CommandText = "UPDATE dbo.CandidatoInforme  SET bAnulado=1 WHERE  iCodCandidatoInforme=@iCodCandidatoInforme"
        cmdSQL.Parameters.Add("@iCodCandidatoInforme", SqlDbType.Int).Value = Me.iCodCandidatoInforme
        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub EliminarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "DELETE from  dbo.CandidatoInforme  WHERE iCodCandidatoInforme=@iCodCandidatoInforme"
        'cmdSQL.CommandText = "UPDATE dbo.CandidatoInforme  SET bAnulado=1 WHERE  iCodCandidatoInforme=@iCodCandidatoInforme"
        cmdSQL.Parameters.Add("@iCodCandidatoInforme", SqlDbType.Int).Value = Me.iCodCandidatoInforme
        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub getRecord()
        Dim readers As IDataReader
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL

        If bTransaccion = True Then cmdSQL.Transaction = Me.mc.miTransact Else 

        cmdSQL.CommandText = "SELECT * FROM dbo.CandidatoInforme WHERE iCodCandidatoInforme=@iCodCandidatoInforme"
        cmdSQL.Parameters.Add("@iCodCandidatoInforme", SqlDbType.Int).Value = Me.iCodCandidatoInforme
        readers = cmdSQL.ExecuteReader
        If readers.Read() Then
            Me.iCodCandidatoInforme = CStr(readers.GetValue(0))
            Me.cDNI = CStr(readers.GetValue(1))
            Me.cUbigeo = CStr(readers.GetValue(2))
            Me.cApellidos = CStr(readers.GetValue(3))
            Me.cNombres = CStr(readers.GetValue(4))
            Me.cSexo = CStr(readers.GetValue(5))
            Me.cEstCivil = CStr(readers.GetValue(6))
            Me.cFono = CStr(readers.GetValue(7))
            Me.cCorreo = CStr(readers.GetValue(8))
            Me.dFechaNac = CStr(readers.GetValue(9))
            Me.cCUI = CStr(readers.GetValue(10))
            Me.cDireccion = CStr(readers.GetValue(11))
            Me.cCondicion = CStr(readers.GetValue(12))
            Me.cPuestoEspecialidad = CStr(readers.GetValue(13))
            Me.cOcupacion = CStr(readers.GetValue(14))
            Me.cOcupacion2 = CStr(readers.GetValue(15))
            Me.cEducaSecundaria = CStr(readers.GetValue(16))
            Me.cEducaTecnica = CStr(readers.GetValue(17))
            Me.cEducaSuperior = CStr(readers.GetValue(18))
            Me.cExpLaboral = CStr(readers.GetValue(19))
            Me.cEmprEx1 = CStr(readers.GetValue(20))
            Me.cCargoEx1 = CStr(readers.GetValue(21))
            Me.dFechaIniEx1 = CStr(readers.GetValue(22))
            Me.dFechaFinEx1 = CStr(readers.GetValue(23))
            Me.cEmprEx2 = CStr(readers.GetValue(24))
            Me.cCargoEx2 = CStr(readers.GetValue(25))
            Me.dFechaIniEx2 = CStr(readers.GetValue(26))
            Me.dFechaFinEx2 = CStr(readers.GetValue(27))
            Me.cComunidad = CStr(readers.GetValue(28))
            Me.cMOCMONC = CStr(readers.GetValue(29))
            Me.cObservacion = CStr(readers.GetValue(30))
            Me.cAptitud = CStr(readers.GetValue(31))
            Me.cUbigeoResidencia = CStr(readers.GetValue(32))
            Me.dFechaDisponible = CStr(readers.GetValue(33))
            Me.cCapacitacion = CStr(readers.GetValue(34))
            Me.cLicenciaConducir = CStr(readers.GetValue(35))
            Me.cCertificacion = CStr(readers.GetValue(36))
            Me.iPAsertividad = CStr(readers.GetValue(37))
            Me.iPTrabajoEquipo = CStr(readers.GetValue(38))
            Me.iPComEfectiva = CStr(readers.GetValue(39))
            Me.iPAdaptabilidad = CStr(readers.GetValue(40))
            Me.iEEstable = CStr(readers.GetValue(41))
            Me.iEInestable = CStr(readers.GetValue(42))
            Me.iCCompromiso = CStr(readers.GetValue(43))
            Me.iSRptoNorma = CStr(readers.GetValue(44))
            Me.iSIperC = CStr(readers.GetValue(45))
            Me.iSActitud = CStr(readers.GetValue(46))
            Me.dFechaRegistro = CStr(readers.GetValue(47))
            Me.iCodUsuarioRegistra = CStr(readers.GetValue(48))
            Me.dFechaEvaluacion = CStr(readers.GetValue(49))
            Me.bEvaluado = CStr(readers.GetValue(50))
            Me.dFechaVerificativa = CStr(readers.GetValue(51))
            Me.bVerificativa = CStr(readers.GetValue(52))
            Me.iEstadoVerificativa = CStr(readers.GetValue(53))
            Me.iResultadoVerificativa = CStr(readers.GetValue(54))
            Me.dFechaCargaBox = CStr(readers.GetValue(55))
            Me.bSustentoCV = CStr(readers.GetValue(56))
            Me.bContratado = CStr(readers.GetValue(57))
            Me.bCargaBox = CStr(readers.GetValue(58))
            Me.bDNIMoq = CStr(readers.GetValue(59))
            Me.bCasadoMoq = CStr(readers.GetValue(60))
            Me.bConviveMoq = CStr(readers.GetValue(61))
            Me.bHijosMoq = CStr(readers.GetValue(62))
            Me.bRucMoq = CStr(readers.GetValue(63))
            Me.bEstudioMoq = CStr(readers.GetValue(64))
            Me.bTrabajoMoq = CStr(readers.GetValue(65))
            Me.cTipoDoc = CStr(readers.GetValue(66))
            Me.iTipoIngreso = CStr(readers.GetValue(67))
            Me.cPaisNacimiento = CStr(readers.GetValue(68))
            Me.iTiempoExperiencia = CStr(readers.GetValue(69))
            Me.cDNIConyuge = CStr(readers.GetValue(70))
            Me.cUbigeoConyuge = CStr(readers.GetValue(71))
            Me.cApellidosConyuge = CStr(readers.GetValue(72))
            Me.cNombresConyuge = CStr(readers.GetValue(73))
            Me.cDNIHijo = CStr(readers.GetValue(74))
            Me.cUbigeoHijo = CStr(readers.GetValue(75))
            Me.cApellidosHijo = CStr(readers.GetValue(76))
            Me.cNombresHijo = CStr(readers.GetValue(77))
            Me.bComunidadPadron = CStr(readers.GetValue(78))
            Me.bComunidadConstancia = CStr(readers.GetValue(79))
            Me.bCip = CStr(readers.GetValue(80))
            Me.bCumplePefil = CStr(readers.GetValue(81))
            Me.bDisponible = CStr(readers.GetValue(82))
            Me.dFechaEmisionDni = CStr(readers.GetValue(83))
            Me.cEmpresaTrabaja = CStr(readers.GetValue(84))
            Me.dFechaEvaluacionResultado = CStr(readers.GetValue(85))
            Me.iCodPersonaEvalua = CStr(readers.GetValue(86))
            Me.bDiscapacitado = CStr(readers.GetValue(87))
            Me.bPrioritario = CStr(readers.GetValue(88))
            Me.iCodUsuario = CStr(readers.GetValue(89))
            Me.dFechaSis = CStr(readers.GetValue(90))
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
        cmdSQL.CommandText = "SELECT * FROM dbo.CandidatoInforme"
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
    '*****************************************************************************************************************************
    '*****************************************************************************************************************************
    Public Sub UpdateEvaluacion()
        Dim Query As String
        Query = String.Format("UPDATE  Candidatoinforme SET cAptitud='{1}',iPAsertividad='{3}',iPTrabajoEquipo='{4}',iPComEfectiva='{5}',iPAdaptabilidad='{6}',iEEstable='{7}',iEInestable='{8}',iCCompromiso='{9}',iSRptoNorma='{10}',iSIperC='{11}',iSActitud='{12}',dFechaEvaluacion='{13}',bEvaluado='{14}' WHERE iCodCandidatoInforme={0}", Me.iCodCandidatoInforme, Me.cAptitud, Me.cCapacitacion, Me.iPAsertividad, Me.iPTrabajoEquipo, Me.iPComEfectiva, Me.iPAdaptabilidad, Me.iEEstable, Me.iEInestable, Me.iCCompromiso, Me.iSRptoNorma, Me.iSIperC, Me.iSActitud, Me.dFechaEvaluacion, Me.bEvaluado)
        mc.ExecuteQuery(Query)
    End Sub

    Public Sub UpdateEvaluacionTransact()
        Dim Query As String
        Query = String.Format("UPDATE  Candidatoinforme SET cAptitud='{1}',iPAsertividad='{3}',iPTrabajoEquipo='{4}',iPComEfectiva='{5}',iPAdaptabilidad='{6}',iEEstable='{7}',iEInestable='{8}',iCCompromiso='{9}',iSRptoNorma='{10}',iSIperC='{11}',iSActitud='{12}',dFechaEvaluacion='{13}',bEvaluado='{14}' WHERE iCodCandidatoInforme={0}", Me.iCodCandidatoInforme, Me.cAptitud, Me.cCapacitacion, Me.iPAsertividad, Me.iPTrabajoEquipo, Me.iPComEfectiva, Me.iPAdaptabilidad, Me.iEEstable, Me.iEInestable, Me.iCCompromiso, Me.iSRptoNorma, Me.iSIperC, Me.iSActitud, Me.dFechaEvaluacion, Me.bEvaluado)
        mc.ExecuteQueryTransact(Query)
    End Sub
    Public Sub UpdateVerificativaTransact()
        Dim Query As String
        Query = String.Format("UPDATE  Candidatoinforme SET dFechaVerificativa='{1}',bVerificativa='{2}',iEstadoVerificativa='{3}' WHERE iCodCandidatoInforme={0}", Me.iCodCandidatoInforme, Me.dFechaVerificativa, Me.bVerificativa, Me.iEstadoVerificativa)

        mc.ExecuteQueryTransact(Query)
    End Sub
    Public Sub UpdateVerificativaSemaforo()
        Dim Query As String
        Query = String.Format("UPDATE  Candidatoinforme SET dFechaVerificativa='{1}',iResultadoVerificativa='{2}',iEstadoVerificativa='{3}',bVerificativa='{4}' WHERE iCodCandidatoInforme={0}", Me.iCodCandidatoInforme, Me.dFechaVerificativa, Me.iResultadoVerificativa, Me.iEstadoVerificativa, Me.bVerificativa)
        mc.ExecuteQuery(Query)
    End Sub
    Public Sub UpdateCargaBox()
        Dim Query As String
        Query = String.Format("UPDATE  Candidatoinforme SET dFechaCargaBox='{1}',bCargaBox='{2}' WHERE iCodCandidatoInforme={0}", Me.iCodCandidatoInforme, Me.dFechaCargaBox, Me.bCargaBox)
        mc.ExecuteQuery(Query)
    End Sub
    Public Sub UpdateCIP()
        Dim Query As String
        Query = String.Format("UPDATE  Candidatoinforme SET bCip='{1}'  WHERE iCodCandidatoInforme={0}", Me.iCodCandidatoInforme, Me.bCip)
        mc.ExecuteQuery(Query)
    End Sub
    Public Sub UpdateFechaOPA()
        Dim Query As String
        Query = String.Format("UPDATE  Candidatoinforme SET dFechaDisponible='{1}' WHERE iCodCandidatoInforme={0}", Me.iCodCandidatoInforme, Me.dFechaDisponible)
        mc.ExecuteQuery(Query)

    End Sub
    Public Sub FuerzaLaboralInicia()
        Dim Query As String
        Query = String.Format("UPDATE  Candidatoinforme SET bContratado='0',cEmpresaTrabaja=''")
        mc.ExecuteQuery(Query)
    End Sub
    Public Sub FuerzaLaboralContratar()
        Dim Query As String

        Query = String.Format("UPDATE  Candidatoinforme SET bContratado='1',cEmpresaTrabaja='{1}' WHERE iCodCandidatoInforme={0}", Me.iCodCandidatoInforme, Me.cEmpresaTrabaja)
        mc.ExecuteQuery(Query)

    End Sub
    Public Sub FuerzaLaboralLiberar()
        Dim Query As String

        Query = String.Format("UPDATE  Candidatoinforme SET bContratado='0',cEmpresaTrabaja='' WHERE iCodCandidatoInforme={0}", Me.iCodCandidatoInforme)
        mc.ExecuteQuery(Query)

    End Sub
    Public Sub UpdateDisponibilidad()
        Dim Query As String
        'Me.dFechaDisponible()
        Query = String.Format("UPDATE  Candidatoinforme SET  bDisponible='{1}',dFechaDisponible='{2}' WHERE iCodCandidatoInforme={0}", Me.iCodCandidatoInforme, Me.bDisponible, Me.dFechaDisponible)
        mc.ExecuteQuery(Query)

    End Sub
    Public Sub UpdateDisponibilidadByDNI()
        Dim Query As String

        Query = String.Format("UPDATE  Candidatoinforme SET  bDisponible='{1}',dFechaDisponible='{2}' WHERE cDNI='{0}'", Me.cDNI, Me.bDisponible, Me.dFechaDisponible)
        mc.ExecuteQuery(Query)

    End Sub
    Public Sub UpdateDisponibilidadTransact()
        Dim Query As String
        'Me.dFechaDisponible()
        Query = String.Format("UPDATE  Candidatoinforme SET  bDisponible='{1}',dFechaDisponible='{2}' WHERE iCodCandidatoInforme={0}", Me.iCodCandidatoInforme, Me.bDisponible, Me.dFechaDisponible)
        mc.ExecuteQueryTransact(Query)

    End Sub
    Public Sub UpdateCopiaExpedienteTransact()
        Dim Query As String
        Query = String.Format("UPDATE  Candidatoinforme SET dFechaCargaBox='{1}',bCargaBox='1' WHERE cDNI='{0}'", Me.cDNI, Me.dFechaCargaBox)
        mc.ExecuteQueryTransact(Query)
    End Sub
    Public Sub UpdateTipoIngresoTransact()
        Dim Query As String
        'Me.dFechaDisponible()
        Query = String.Format("UPDATE  Candidatoinforme SET  iTipoIngreso=1  WHERE iCodCandidatoInforme={0}", Me.iCodCandidatoInforme)
        mc.ExecuteQueryTransact(Query)

    End Sub
    Public Function ListaUbigeos() As DataTable
        Dim miDataTable As New DataTable
        miDataTable.Columns.Add("ValueMember")
        miDataTable.Columns.Add("DisplayMember")
        With miDataTable
            .Rows.Add("1", "1-AMAZONAS")
            .Rows.Add("2", "2-ANCASH")
            .Rows.Add("3", "3-APURIMAC")
            .Rows.Add("4", "4-AREQUIPA")
            .Rows.Add("5", "5-AYACUCHO")
            .Rows.Add("6", "6-CAJAMARCA")
            .Rows.Add("7", "7-CUSCO")
            .Rows.Add("8", "8-HUANCAVELICA")
            .Rows.Add("9", "9-HUANUCO")
            .Rows.Add("10", "10-ICA ")
            .Rows.Add("11", "11-JUNIN")
            .Rows.Add("12", "12-LA LIBERTAD")
            .Rows.Add("13", "13-LAMBAYEQUE")
            .Rows.Add("14", "14-LIMA")
            .Rows.Add("15", "15-LORETO")
            .Rows.Add("16", "16-MADRE DE DIOS")
            .Rows.Add("17", "17-MOQUEGUA")
            .Rows.Add("18", "18-PASCO")
            .Rows.Add("19", "19-PIURA")
            .Rows.Add("20", "20-PUNO")
            .Rows.Add("21", "21-SAN MARTIN")
            .Rows.Add("22", "22-TACNA")
            .Rows.Add("23", "23-TUMBES")
            .Rows.Add("24", "24-CALLAO")
            .Rows.Add("25", "25-UCAYALI")
            .Rows.Add("0", "0-NO ESPECIFICA")
            .Rows.Add("99", "99-EXTRANJERO")
        End With
        Return miDataTable
    End Function

    Public Function ListaAptitud() As DataTable
        Dim miDataTable As New DataTable
        miDataTable.Columns.Add("ValueMember")
        miDataTable.Columns.Add("DisplayMember")
        With miDataTable
            .Rows.Add("APTO", "APTO")
            .Rows.Add("APTO CAPACITABLE", "APTO CAPACITABLE")
            .Rows.Add("NO APTO", "NO APTO")
        End With
        Return miDataTable
    End Function
    Public Function ListaCondicion() As DataTable
        Dim miDataTable As New DataTable
        miDataTable.Columns.Add("ValueMember")
        miDataTable.Columns.Add("DisplayMember")
        With miDataTable
            .Rows.Add("LOCAL", "LOCAL")
            .Rows.Add("FORANEO", "FORANEO")
            .Rows.Add("RESIDENTE", "RESIDENTE")
            .Rows.Add("COMUNIDAD", "COMUNIDAD")
        End With
        Return miDataTable
    End Function
    Public Function ListaSexo() As DataTable
        Dim miDataTable As New DataTable
        miDataTable.Columns.Add("ValueMember")
        miDataTable.Columns.Add("DisplayMember")
        With miDataTable
            .Rows.Add("M", "M")
            .Rows.Add("F", "F")
        End With
        Return miDataTable
    End Function
    Public Function ListaEstadoCivil() As DataTable
        Dim miDataTable As New DataTable
        miDataTable.Columns.Add("ValueMember")
        miDataTable.Columns.Add("DisplayMember")
        With miDataTable
            .Rows.Add("SOLTERO", "SOLTERO")
            .Rows.Add("CASADO", "CASADO")
            .Rows.Add("CONVIVIENTE", "CONVIVIENTE")
            .Rows.Add("VIUDO", "VIUDO")
            .Rows.Add("DIVORCIADO", "DIVORCIADO")
        End With
        Return miDataTable
    End Function
    Public Function ListaTieneExperiencia() As DataTable
        Dim miDataTable As New DataTable
        miDataTable.Columns.Add("ValueMember")
        miDataTable.Columns.Add("DisplayMember")
        With miDataTable
            .Rows.Add("SI", "SI")
            .Rows.Add("NO", "NO")
        End With
        Return miDataTable
    End Function
    Public Function ListaTipoMO() As DataTable
        Dim miDataTable As New DataTable
        miDataTable.Columns.Add("ValueMember")
        miDataTable.Columns.Add("DisplayMember")
        With miDataTable
            .Rows.Add("MOC", "MOC")
            .Rows.Add("MONC", "MONC")
        End With
        Return miDataTable
    End Function
    Public Function ListaComunidades() As DataTable
        Dim miDataTable As New DataTable
        Dim Query As String
        Dim readers As IDataReader
        miDataTable.Columns.Add("ValueMember")
        miDataTable.Columns.Add("DisplayMember")
        Query = String.Format("SELECT * FROM Comunidad  order by cComunidad")
        readers = mc.ExecuteReader(Query)
        While readers.Read()
            miDataTable.Rows.Add(CStr(readers.GetValue(0)), CStr(readers.GetValue(0)))
        End While
        readers.Close()
        Return miDataTable
    End Function

    Public Function TDPais() As DataTable
        Dim miDataTable As New DataTable
        miDataTable.Columns.Add("ValueMember")
        miDataTable.Columns.Add("DisplayMember")
        With miDataTable
            .Rows.Add("ARGENTINA ", "ARGENTINA ")
            .Rows.Add("BOLIVIA", "BOLIVIA")
            .Rows.Add("BRASIL ", "BRASIL ")
            .Rows.Add("CHILE ", "CHILE ")
            .Rows.Add("COLOMBIA ", "COLOMBIA ")
            .Rows.Add("COSTA RICA ", "COSTA RICA ")
            .Rows.Add("ECUADOR", "ECUADOR")
            .Rows.Add("EL SALVADOR ", "EL SALVADOR ")
            .Rows.Add("GUATEMALA ", "GUATEMALA ")
            .Rows.Add("HONDURAS ", "HONDURAS ")
            .Rows.Add("MÉXICO ", "MÉXICO ")
            .Rows.Add("NICARAGUA ", "NICARAGUA ")
            .Rows.Add("PANAMÁ", "PANAMÁ")
            .Rows.Add("PARAGUAY ", "PARAGUAY ")
            .Rows.Add("PERÚ", "PERÚ")
            .Rows.Add("PUERTO RICO", "PUERTO RICO")
            .Rows.Add("REPÚBLICA DOMINICANA", "REPÚBLICA DOMINICANA")
            .Rows.Add("URUGUAY ", "URUGUAY ")
            .Rows.Add("VENEZUELA", "VENEZUELA")
            .Rows.Add("OTRO", "OTRO")
        End With
        Return miDataTable
    End Function


    Public Function TDTipoDocumento() As DataTable
        Dim miDataTable As New DataTable
        miDataTable.Columns.Add("ValueMember")
        miDataTable.Columns.Add("DisplayMember")
        With miDataTable
            .Rows.Add("DNI", "DNI")
            .Rows.Add("CE", "CARNET EXTRANJERIA")
            .Rows.Add("PAS", "PASAPORTE")
        End With
        Return miDataTable
    End Function

    Public Function TDIdioma() As DataTable
        Dim miDataTable As New DataTable
        miDataTable.Columns.Add("ValueMember")
        miDataTable.Columns.Add("DisplayMember")
        With miDataTable
            .Rows.Add("ESPAÑOL", "ESPAÑOL")
            .Rows.Add("INGLES", "INGLES")
            .Rows.Add("PORTUGUES", "PORTUGUES")
            .Rows.Add("FRANCES", "FRANCES")
            .Rows.Add("COREANO", "COREANO")
            .Rows.Add("JAPONÉS", "JAPONÉS")
            .Rows.Add("OTRO", "OTRO")
        End With
        Return miDataTable
    End Function
    Public Function TDNivelIdioma() As DataTable
        Dim miDataTable As New DataTable
        miDataTable.Columns.Add("ValueMember")
        miDataTable.Columns.Add("DisplayMember")
        With miDataTable
            .Rows.Add("BASICO", "BASICO")
            .Rows.Add("INTERMEDIO", "INTERMEDIO")
            .Rows.Add("AVANZADO", "AVANZADO")
            .Rows.Add("NATIVO", "NATIVO")
        End With
        Return miDataTable
    End Function
    Public Function GetAptitud(ByVal iPos As String) As String
        GetAptitud = ""
        Select Case iPos
            Case "APTO"
                GetAptitud = "1: El candidato es una persona asertiva lo cual le permite propiciar el trabajo en equipo, colaborando y respetando las ideas de sus pares, pudiendo adaptarse a nuevos entornos laborales. Es estable emocionalmente, conociendo sus fortalezas y debilidades. Posee un nivel de compromiso óptimo siendo una persona proactiva en su entorno laboral, cumpliendo sus funciones sin requerir supervisión. Demuestra un comporamiento seguro, identificando situaciones peligrosas y planteando medidas de control de seguridad para estas situaciones."
            Case "APTO CAPACITABLE"
                GetAptitud = "2: El candidato sugiere ideas para el cumplimiento de los objetivos en su grupo de trabajo, sin embargo le cuesta comprometerse en la ejecución de los mismos. Requiere un mejor control de sus emociones en situaciones que le generen estrés, lo cual ocasiona cierta inseguridad de sus fortalezas en su grupo de trabajo. Requiere supervición para el cumplimiento de sus tareas. El conocimento de trabajo seguro necesita ser reforzado para que la identificación de situaciones riesgosas y peligrosas sean una constante en su trabajo diario por lo cual se sugiere capacitaciones en temas de seguridad y habilidades sociales."
            Case "NO APTO"
                GetAptitud = "3: El candidato no cuenta con las competencias esperadas para el puesto, se sugiere que sea capacitado para que estas competencias puedan desarrollarse."
        End Select

        Return GetAptitud

    End Function


    Public Function ListaCandidatosGrid() As IDataReader
        Dim Query As String
        Dim readers As IDataReader
        Query = "Select * from m_CandidatosInformeMinimal where bEvaluado=1 order by dFechaEvaluacion"
        readers = mc.ExecuteReader(Query)
        Return readers
    End Function
    Public Function ListaCandidatosParaPostularSugerido() As IDataReader
        Dim Query As String
        Dim readers As IDataReader
        'CCONDICION<>FORANEO
        'EVALUADO=SI
        'VERIFICATIVA= 0     -> sin riesgo
        'IESTADOVERIFICATIVA=3  RESPONDIDO
        'captitud<>no apto
        Query = "Select * from m_CandidatosInformeMinimal where cCondicion<>'FORANEO' and bEvaluado=1 and bVerificativa=0 and iEstadoVerificativa=3 and cAptitud<>'NO APTO' order by dFechaEvaluacion desc,cnomcompleto asc"
        readers = mc.ExecuteReader(Query)
        Return readers
    End Function
    Public Function ListaCandidatosParaPostularSugeridoByFiltro(ByVal pTipo As String, ByVal pOcupacionEspecialidadDNI As String) As IDataReader
        Dim Query, pArgumento As String
        Dim readers As IDataReader
        pArgumento = ""
        'CCONDICION<>FORANEO
        'EVALUADO=SI
        'VERIFICATIVA= 0     -> sin riesgo
        'IESTADOVERIFICATIVA=3  RESPONDIDO
        'captitud<>no apto
        If pTipo = "O" Then
            pArgumento = " and cOcupacion='" & pOcupacionEspecialidadDNI & "' "
        ElseIf pTipo = "E" Then
            pArgumento = " and cPuestoEspecialidad='" & pOcupacionEspecialidadDNI & "' "
        ElseIf pTipo = "T" Then
            pArgumento = " "
        ElseIf pTipo = "D" Then
            pArgumento = " and cDNI='" & pOcupacionEspecialidadDNI & "' "
        End If
        'Query = "Select * from m_CandidatosInformeMinimal where cCondicion<>'FORANEO' and bEvaluado=1 and bVerificativa=0 and iEstadoVerificativa=3 and cAptitud<>'NO APTO' " & pArgumento & " order by dFechaEvaluacion desc,cnomcompleto asc"

        Query = "Select * from m_CandidatosInformeMinimal where cCondicion<>'FORANEO' and bEvaluado=1 and  iEstadoVerificativa=3  " & pArgumento & " order by dFechaEvaluacion desc,cnomcompleto asc"

        readers = mc.ExecuteReader(Query)

        Return readers

    End Function
    Public Function ListaCandidatosParaPostularSugeridoOcupaciones(ByVal pTipo As String) As DataTable
        Dim Query As String = ""
        Dim readers As DataTable
        'CCONDICION<>FORANEO
        'EVALUADO=SI
        'VERIFICATIVA= 0     -> sin riesgo
        'IESTADOVERIFICATIVA=3  RESPONDIDO
        'captitud<>no apto
        If pTipo = "O" Then
            Query = "Select cOcupacion as Ocupacion from m_CandidatosInformeMinimal where cCondicion<>'FORANEO' and bEvaluado=1 and bVerificativa=0 and iEstadoVerificativa=3 and cAptitud<>'NO APTO' group by cOcupacion order by cOcupacion"

        ElseIf pTipo = "E" Then
            Query = "Select cPuestoEspecialidad  as Especialidad from m_CandidatosInformeMinimal where cCondicion<>'FORANEO' and bEvaluado=1 and bVerificativa=0 and iEstadoVerificativa=3 and cAptitud<>'NO APTO' group by cPuestoEspecialidad order by cPuestoEspecialidad"

        End If

        readers = mc.ExecuteDataTable(Query)

        Return readers

    End Function
    Public Function ListaCandidatosParaPostularSugeridoDNI(ByVal pDNI As String) As DataTable
        Dim Query As String = ""
        Dim readers As DataTable
        'CCONDICION<>FORANEO
        'EVALUADO=SI
        'VERIFICATIVA= 0     -> sin riesgo
        'IESTADOVERIFICATIVA=3  RESPONDIDO
        'captitud<>no apto

        Query = "Select cPuestoEspecialidad  as Especialidad from m_CandidatosInformeMinimal where cCondicion<>'FORANEO' and bEvaluado=1 and bVerificativa=0 and iEstadoVerificativa=3 and cAptitud<>'NO APTO' group by cPuestoEspecialidad order by cPuestoEspecialidad"


        readers = mc.ExecuteDataTable(Query)

        Return readers

    End Function
    Public Function ListaCandidatosAptos() As IDataReader
        Dim Query As String
        Dim readers As IDataReader
        Query = "Select * from m_CandidatosInformeMinimal where bEvaluado=1 order by dFechaEvaluacion"
        readers = mc.ExecuteReader(Query)
        Return readers
    End Function

    Public Function ExisteRecordByDNI() As Boolean
        Dim Query, Query2 As String
        Dim readers As IDataReader
        Query2 = ""
        Dim count As Integer
        Query = String.Format("SELECT count(*) FROM Candidatoinforme WHERE cDNI='{0}'", Trim(Me.cDNI))
        count = mc.ExecuteScalar(Query)
        If (count > 0) Then 'SI EXISTE EXTRAEMOS DATOS
            Query2 = String.Format("SELECT iCodCandidatoInforme,cDNI,cApellidos,cNombres,dFechaEvaluacion,bEvaluado,dFechaVerificativa,bVerificativa,iEstadoVerificativa,cCondicion,bCargabox,cOcupacion FROM Candidatoinforme WHERE cDNI='{0}'", Trim(Me.cDNI))
            readers = mc.ExecuteGetRecord(Query2)
            readers.Read()
            Me.iCodCandidatoInforme = CStr(readers.GetValue(0))
            Me.cDNI = CStr(readers.GetValue(1))
            Me.cApellidos = CStr(readers.GetValue(2))
            Me.cNombres = CStr(readers.GetValue(3))
            Me.dFechaEvaluacion = CStr(readers.GetValue(4))
            Me.bEvaluado = CStr(readers.GetValue(5))
            Me.dFechaVerificativa = CStr(readers.GetValue(6))
            Me.bVerificativa = CStr(readers.GetValue(7))
            Me.iEstadoVerificativa = CStr(readers.GetValue(8))
            Me.cCondicion = CStr(readers.GetValue(9))
            Me.bCargaBox = CStr(readers.GetValue(10))
            Me.cOcupacion = CStr(readers.GetValue(11))
            readers.Close()
            Return True
        Else
            Return False
        End If
    End Function
    Public Function ExisteRecordByDNICompleto() As Boolean
        Dim Query, Query2 As String
        Dim readers As IDataReader
        Query2 = ""
        Dim count As Integer
        Query = String.Format("SELECT count(*) FROM Candidatoinforme WHERE cDNI='{0}'", Trim(Me.cDNI))
        count = mc.ExecuteScalar(Query)
        If (count > 0) Then 'SI EXISTE EXTRAEMOS DATOS
            'Query2 = String.Format("SELECT iCodCandidatoInforme,cDNI,cApellidos,cNombres,dFechaEvaluacion,bEvaluado,dFechaVerificativa,bVerificativa,iEstadoVerificativa,cCondicion,bCargabox,cOcupacion FROM Candidatoinforme WHERE cDNI='{0}'", Trim(Me.cDNI))
            'readers = mc.ExecuteGetRecord(Query2)
            Query2 = String.Format("SELECT * FROM Candidatoinforme WHERE cDNI='{0}'", Trim(Me.cDNI))
            readers = mc.ExecuteGetRecord(Query2)
            readers.Read()
            Me.iCodCandidatoInforme = CStr(readers.GetValue(0))
            Me.cDNI = CStr(readers.GetValue(1))
            Me.cUbigeo = CStr(readers.GetValue(2))
            Me.cApellidos = CStr(readers.GetValue(3))
            Me.cNombres = CStr(readers.GetValue(4))
            Me.cSexo = CStr(readers.GetValue(5))
            Me.cEstCivil = CStr(readers.GetValue(6))
            Me.cFono = CStr(readers.GetValue(7))
            Me.cCorreo = CStr(readers.GetValue(8))
            Me.dFechaNac = CStr(readers.GetValue(9))
            Me.cCUI = CStr(readers.GetValue(10))
            Me.cDireccion = CStr(readers.GetValue(11))
            Me.cCondicion = CStr(readers.GetValue(12))
            Me.cPuestoEspecialidad = CStr(readers.GetValue(13))
            Me.cOcupacion = CStr(readers.GetValue(14))
            Me.cOcupacion2 = CStr(readers.GetValue(15))
            Me.cEducaSecundaria = CStr(readers.GetValue(16))
            Me.cEducaTecnica = CStr(readers.GetValue(17))
            Me.cEducaSuperior = CStr(readers.GetValue(18))
            Me.cExpLaboral = CStr(readers.GetValue(19))
            Me.cEmprEx1 = CStr(readers.GetValue(20))
            Me.cCargoEx1 = CStr(readers.GetValue(21))
            Me.dFechaIniEx1 = CStr(readers.GetValue(22))
            Me.dFechaFinEx1 = CStr(readers.GetValue(23))
            Me.cEmprEx2 = CStr(readers.GetValue(24))
            Me.cCargoEx2 = CStr(readers.GetValue(25))
            Me.dFechaIniEx2 = CStr(readers.GetValue(26))
            Me.dFechaFinEx2 = CStr(readers.GetValue(27))
            Me.cComunidad = CStr(readers.GetValue(28))
            Me.cMOCMONC = CStr(readers.GetValue(29))
            Me.cObservacion = CStr(readers.GetValue(30))
            Me.cAptitud = CStr(readers.GetValue(31))
            Me.cUbigeoResidencia = CStr(readers.GetValue(32))
            Me.dFechaDisponible = CStr(readers.GetValue(33))
            Me.cCapacitacion = CStr(readers.GetValue(34))
            Me.cLicenciaConducir = CStr(readers.GetValue(35))
            Me.cCertificacion = CStr(readers.GetValue(36))
            Me.iPAsertividad = CStr(readers.GetValue(37))
            Me.iPTrabajoEquipo = CStr(readers.GetValue(38))
            Me.iPComEfectiva = CStr(readers.GetValue(39))
            Me.iPAdaptabilidad = CStr(readers.GetValue(40))
            Me.iEEstable = CStr(readers.GetValue(41))
            Me.iEInestable = CStr(readers.GetValue(42))
            Me.iCCompromiso = CStr(readers.GetValue(43))
            Me.iSRptoNorma = CStr(readers.GetValue(44))
            Me.iSIperC = CStr(readers.GetValue(45))
            Me.iSActitud = CStr(readers.GetValue(46))
            Me.dFechaRegistro = CStr(readers.GetValue(47))
            Me.iCodUsuarioRegistra = CStr(readers.GetValue(48))
            Me.dFechaEvaluacion = CStr(readers.GetValue(49))
            Me.bEvaluado = CStr(readers.GetValue(50))
            Me.dFechaVerificativa = CStr(readers.GetValue(51))
            Me.bVerificativa = CStr(readers.GetValue(52))
            Me.iEstadoVerificativa = CStr(readers.GetValue(53))
            Me.iResultadoVerificativa = CStr(readers.GetValue(54))
            Me.dFechaCargaBox = CStr(readers.GetValue(55))
            Me.bSustentoCV = CStr(readers.GetValue(56))
            Me.bContratado = CStr(readers.GetValue(57))
            Me.bCargaBox = CStr(readers.GetValue(58))
            Me.bDNIMoq = CStr(readers.GetValue(59))
            Me.bCasadoMoq = CStr(readers.GetValue(60))
            Me.bConviveMoq = CStr(readers.GetValue(61))
            Me.bHijosMoq = CStr(readers.GetValue(62))
            Me.bRucMoq = CStr(readers.GetValue(63))
            Me.bEstudioMoq = CStr(readers.GetValue(64))
            Me.bTrabajoMoq = CStr(readers.GetValue(65))
            Me.cTipoDoc = CStr(readers.GetValue(66))
            Me.iTipoIngreso = CStr(readers.GetValue(67))
            Me.cPaisNacimiento = CStr(readers.GetValue(68))
            Me.iTiempoExperiencia = CStr(readers.GetValue(69))
            Me.cDNIConyuge = CStr(readers.GetValue(70))
            Me.cUbigeoConyuge = CStr(readers.GetValue(71))
            Me.cApellidosConyuge = CStr(readers.GetValue(72))
            Me.cNombresConyuge = CStr(readers.GetValue(73))
            Me.cDNIHijo = CStr(readers.GetValue(74))
            Me.cUbigeoHijo = CStr(readers.GetValue(75))
            Me.cApellidosHijo = CStr(readers.GetValue(76))
            Me.cNombresHijo = CStr(readers.GetValue(77))
            Me.bComunidadPadron = CStr(readers.GetValue(78))
            Me.bComunidadConstancia = CStr(readers.GetValue(79))
            Me.bCip = CStr(readers.GetValue(80))
            Me.bCumplePefil = CStr(readers.GetValue(81))
            Me.bDisponible = CStr(readers.GetValue(82))
            Me.dFechaEmisionDni = CStr(readers.GetValue(83))
            Me.cEmpresaTrabaja = CStr(readers.GetValue(84))
            Me.dFechaEvaluacionResultado = CStr(readers.GetValue(85))
            Me.iCodPersonaEvalua = CStr(readers.GetValue(86))
            Me.bDiscapacitado = CStr(readers.GetValue(87))
            Me.bPrioritario = CStr(readers.GetValue(88))
            Me.iCodUsuario = CStr(readers.GetValue(89))
            Me.dFechaSis = CStr(readers.GetValue(90))
            readers.Close()
            Return True
        Else
            Return False
        End If
    End Function
    Public Function ExisteRecordByDNITransact() As Boolean
        Dim Query, Query2 As String
        Dim readers As IDataReader
        Query2 = ""
        Dim count As Integer
        Query = String.Format("SELECT count(*) FROM Candidatoinforme WHERE cDNI='{0}'", Trim(Me.cDNI))
        count = mc.ExecuteScalarTransact(Query)
        If (count > 0) Then 'SI EXISTE EXTRAEMOS DATOS
            Query2 = String.Format("SELECT iCodCandidatoInforme,cDNI,cApellidos,cNombres,dFechaEvaluacion,bEvaluado,dFechaVerificativa,bVerificativa,iEstadoVerificativa FROM Candidatoinforme WHERE cDNI='{0}'", Trim(Me.cDNI))
            readers = mc.ExecuteGetRecordTransact(Query2)
            readers.Read()
            Me.iCodCandidatoInforme = CStr(readers.GetValue(0))
            Me.cDNI = CStr(readers.GetValue(1))
            Me.cApellidos = CStr(readers.GetValue(2))
            Me.cNombres = CStr(readers.GetValue(3))
            Me.dFechaEvaluacion = CStr(readers.GetValue(4))
            Me.bEvaluado = CStr(readers.GetValue(5))
            Me.dFechaVerificativa = CStr(readers.GetValue(6))
            Me.bVerificativa = CStr(readers.GetValue(7))
            Me.iEstadoVerificativa = CStr(readers.GetValue(8))
            readers.Close()
            Return True
        Else
            Return False
        End If
    End Function
    Public Function ExisteDNI() As Boolean
        Dim Query As String
        Dim count As Integer
        Query = String.Format("SELECT count(*) FROM Candidatoinforme WHERE cDNI='{0}'", Trim(Me.cDNI))
        count = mc.ExecuteScalar(Query)
        If (count > 0) Then 'SI EXISTE EXTRAEMOS DATOS           
            Return True
        Else
            Return False
        End If
    End Function
    Public Function TienePostulaciones() As Boolean
        Dim Query As String
        Dim count As Integer
        Query = String.Format("SELECT count(*) FROM convocatoriadetalle WHERE iCodCandidatoInforme={0}", Trim(Me.iCodCandidatoInforme))
        count = mc.ExecuteScalar(Query)
        If (count > 0) Then 'SI EXISTE           
            Return True
        Else
            Return False
        End If
    End Function
    Public Function NoTieneFechaExpedienteCV() As Boolean
        Dim Query, Query2 As String
        Dim readers As IDataReader
        Query2 = ""
        Dim count As Integer
        Query = String.Format("SELECT count(*) FROM Candidatoinforme WHERE  bCargaBox='0' and cDNI='{0}'", Trim(Me.cDNI))
        count = mc.ExecuteScalarTransact(Query)
        If (count > 0) Then 'SI EXISTE EXTRAEMOS DATOS
            Query2 = String.Format("SELECT iCodCandidatoInforme,cDNI,dFechaEvaluacion,bEvaluado FROM Candidatoinforme WHERE cDNI='{0}'", Trim(Me.cDNI))
            readers = mc.ExecuteGetRecordTransact(Query2)
            readers.Read()
            Me.iCodCandidatoInforme = CStr(readers.GetValue(0))
            Me.cDNI = CStr(readers.GetValue(1))

            Me.dFechaEvaluacion = CStr(readers.GetValue(2))


            Me.bEvaluado = CStr(readers.GetValue(3))

            readers.Close()
            Return True
        Else
            Return False
        End If

        'dFechaCargaBox='{1}',bCargaBox='1' WHERE cDNI='{0}'
    End Function

    Public Function ListaTDUbigeos() As DataTable
        Dim miDataTable As New DataTable
        Dim Query As String
        Dim readers As IDataReader
        miDataTable.Columns.Add("ValueMember")
        miDataTable.Columns.Add("DisplayMember")
        Query = String.Format("SELECT * FROM TDUbigeo")
        readers = mc.ExecuteReader(Query)
        While readers.Read()
            miDataTable.Rows.Add(CStr(readers.GetValue(1)), CStr(readers.GetValue(1)) & " - " & CStr(readers.GetValue(2)) & " - " & CStr(readers.GetValue(3)) & " - " & CStr(readers.GetValue(4)))
        End While
        readers.Close()
        Return miDataTable
    End Function
    Public Function ListaTDPais() As DataTable
        Dim miDataTable As New DataTable
        Dim Query As String
        Query = String.Format("SELECT cPais as ValueMember,cPais as DisplayMember FROM TDPais")
        miDataTable = mc.ExecuteDataTable(Query)
        Return miDataTable
    End Function
    Public Sub getRecordByDNI()
        Dim Query As String
        Dim readers As IDataReader
        Query = String.Format("SELECT * FROM Candidatoinforme WHERE cDNI='{0}'", Me.cDNI)

        readers = mc.ExecuteGetRecord(Query)
        If readers.Read() Then
            Me.iCodCandidatoInforme = CStr(readers.GetValue(0))
            Me.cDNI = CStr(readers.GetValue(1))
            Me.cUbigeo = CStr(readers.GetValue(2))
            Me.cApellidos = CStr(readers.GetValue(3))
            Me.cNombres = CStr(readers.GetValue(4))
            Me.cSexo = CStr(readers.GetValue(5))
            Me.cEstCivil = CStr(readers.GetValue(6))
            Me.cFono = CStr(readers.GetValue(7))
            Me.cCorreo = CStr(readers.GetValue(8))
            Me.dFechaNac = CStr(readers.GetValue(9))
            Me.cCUI = CStr(readers.GetValue(10))
            Me.cDireccion = CStr(readers.GetValue(11))
            Me.cCondicion = CStr(readers.GetValue(12))
            Me.cPuestoEspecialidad = CStr(readers.GetValue(13))
            Me.cOcupacion = CStr(readers.GetValue(14))
            Me.cOcupacion2 = CStr(readers.GetValue(15))
            Me.cEducaSecundaria = CStr(readers.GetValue(16))
            Me.cEducaTecnica = CStr(readers.GetValue(17))
            Me.cEducaSuperior = CStr(readers.GetValue(18))
            Me.cExpLaboral = CStr(readers.GetValue(19))
            Me.cEmprEx1 = CStr(readers.GetValue(20))
            Me.cCargoEx1 = CStr(readers.GetValue(21))
            Me.dFechaIniEx1 = CStr(readers.GetValue(22))
            Me.dFechaFinEx1 = CStr(readers.GetValue(23))
            Me.cEmprEx2 = CStr(readers.GetValue(24))
            Me.cCargoEx2 = CStr(readers.GetValue(25))
            Me.dFechaIniEx2 = CStr(readers.GetValue(26))
            Me.dFechaFinEx2 = CStr(readers.GetValue(27))
            Me.cComunidad = CStr(readers.GetValue(28))
            Me.cMOCMONC = CStr(readers.GetValue(29))
            Me.cObservacion = CStr(readers.GetValue(30))
            Me.cAptitud = CStr(readers.GetValue(31))
            Me.cUbigeoResidencia = CStr(readers.GetValue(32))
            Me.dFechaDisponible = CStr(readers.GetValue(33))
            Me.cCapacitacion = CStr(readers.GetValue(34))
            Me.cLicenciaConducir = CStr(readers.GetValue(35))
            Me.cCertificacion = CStr(readers.GetValue(36))
            Me.iPAsertividad = CStr(readers.GetValue(37))
            Me.iPTrabajoEquipo = CStr(readers.GetValue(38))
            Me.iPComEfectiva = CStr(readers.GetValue(39))
            Me.iPAdaptabilidad = CStr(readers.GetValue(40))
            Me.iEEstable = CStr(readers.GetValue(41))
            Me.iEInestable = CStr(readers.GetValue(42))
            Me.iCCompromiso = CStr(readers.GetValue(43))
            Me.iSRptoNorma = CStr(readers.GetValue(44))
            Me.iSIperC = CStr(readers.GetValue(45))
            Me.iSActitud = CStr(readers.GetValue(46))
            Me.dFechaRegistro = CStr(readers.GetValue(47))
            Me.iCodUsuarioRegistra = CStr(readers.GetValue(48))
            Me.dFechaEvaluacion = CStr(readers.GetValue(49))
            Me.bEvaluado = CStr(readers.GetValue(50))
            Me.dFechaVerificativa = CStr(readers.GetValue(51))
            Me.bVerificativa = CStr(readers.GetValue(52))
            Me.iEstadoVerificativa = CStr(readers.GetValue(53))
            Me.iResultadoVerificativa = CStr(readers.GetValue(54))
            Me.dFechaCargaBox = CStr(readers.GetValue(55))
            Me.bSustentoCV = CStr(readers.GetValue(56))
            Me.bContratado = CStr(readers.GetValue(57))
            Me.bCargaBox = CStr(readers.GetValue(58))
            Me.bDNIMoq = CStr(readers.GetValue(59))
            Me.bCasadoMoq = CStr(readers.GetValue(60))
            Me.bConviveMoq = CStr(readers.GetValue(61))
            Me.bHijosMoq = CStr(readers.GetValue(62))
            Me.bRucMoq = CStr(readers.GetValue(63))
            Me.bEstudioMoq = CStr(readers.GetValue(64))
            Me.bTrabajoMoq = CStr(readers.GetValue(65))
            Me.cTipoDoc = CStr(readers.GetValue(66))
            Me.iTipoIngreso = CStr(readers.GetValue(67))
            Me.cPaisNacimiento = CStr(readers.GetValue(68))
            Me.iTiempoExperiencia = CStr(readers.GetValue(69))
            Me.cDNIConyuge = CStr(readers.GetValue(70))
            Me.cUbigeoConyuge = CStr(readers.GetValue(71))
            Me.cApellidosConyuge = CStr(readers.GetValue(72))
            Me.cNombresConyuge = CStr(readers.GetValue(73))
            Me.cDNIHijo = CStr(readers.GetValue(74))
            Me.cUbigeoHijo = CStr(readers.GetValue(75))
            Me.cApellidosHijo = CStr(readers.GetValue(76))
            Me.cNombresHijo = CStr(readers.GetValue(77))
            Me.bComunidadPadron = CStr(readers.GetValue(78))
            Me.bComunidadConstancia = CStr(readers.GetValue(79))
            Me.bCip = CStr(readers.GetValue(80))
            Me.bCumplePefil = CStr(readers.GetValue(81))
            Me.bDisponible = CStr(readers.GetValue(82))
            Me.dFechaEmisionDni = CStr(readers.GetValue(83))
            Me.cEmpresaTrabaja = CStr(readers.GetValue(84))
            Me.dFechaEvaluacionResultado = CStr(readers.GetValue(85))
            Me.iCodPersonaEvalua = CStr(readers.GetValue(86))
            Me.bDiscapacitado = CStr(readers.GetValue(87))
            Me.bPrioritario = CStr(readers.GetValue(88))
            Me.iCodUsuario = CStr(readers.GetValue(89))
            Me.dFechaSis = CStr(readers.GetValue(90))
        End If
        readers.Close()
    End Sub
    Public Function ExisteRecordCompletoByDNI() As Boolean
        Dim Query, Query2 As String
        Dim readers As IDataReader
        Query2 = ""
        Dim count As Integer
        Query = String.Format("SELECT count(*) FROM Candidatoinforme WHERE cDNI='{0}'", Trim(Me.cDNI))
        count = mc.ExecuteScalar(Query)
        If (count > 0) Then 'SI EXISTE EXTRAEMOS DATOS
            Query2 = String.Format("SELECT * FROM Candidatoinforme WHERE cDNI='{0}'", Trim(Me.cDNI))
            readers = mc.ExecuteGetRecord(Query2)
            readers.Read()
            Me.iCodCandidatoInforme = CStr(readers.GetValue(0))
            Me.cDNI = CStr(readers.GetValue(1))
            Me.cUbigeo = CStr(readers.GetValue(2))
            Me.cApellidos = CStr(readers.GetValue(3))
            Me.cNombres = CStr(readers.GetValue(4))
            Me.cSexo = CStr(readers.GetValue(5))
            Me.cEstCivil = CStr(readers.GetValue(6))
            Me.cFono = CStr(readers.GetValue(7))
            Me.cCorreo = CStr(readers.GetValue(8))
            Me.dFechaNac = CStr(readers.GetValue(9))
            Me.cCUI = CStr(readers.GetValue(10))
            Me.cDireccion = CStr(readers.GetValue(11))
            Me.cCondicion = CStr(readers.GetValue(12))
            Me.cPuestoEspecialidad = CStr(readers.GetValue(13))
            Me.cOcupacion = CStr(readers.GetValue(14))
            Me.cOcupacion2 = CStr(readers.GetValue(15))
            Me.cEducaSecundaria = CStr(readers.GetValue(16))
            Me.cEducaTecnica = CStr(readers.GetValue(17))
            Me.cEducaSuperior = CStr(readers.GetValue(18))
            Me.cExpLaboral = CStr(readers.GetValue(19))
            Me.cEmprEx1 = CStr(readers.GetValue(20))
            Me.cCargoEx1 = CStr(readers.GetValue(21))
            Me.dFechaIniEx1 = CStr(readers.GetValue(22))
            Me.dFechaFinEx1 = CStr(readers.GetValue(23))
            Me.cEmprEx2 = CStr(readers.GetValue(24))
            Me.cCargoEx2 = CStr(readers.GetValue(25))
            Me.dFechaIniEx2 = CStr(readers.GetValue(26))
            Me.dFechaFinEx2 = CStr(readers.GetValue(27))
            Me.cComunidad = CStr(readers.GetValue(28))
            Me.cMOCMONC = CStr(readers.GetValue(29))
            Me.cObservacion = CStr(readers.GetValue(30))
            Me.cAptitud = CStr(readers.GetValue(31))
            Me.cUbigeoResidencia = CStr(readers.GetValue(32))
            Me.dFechaDisponible = CStr(readers.GetValue(33))
            Me.cCapacitacion = CStr(readers.GetValue(34))
            Me.cLicenciaConducir = CStr(readers.GetValue(35))
            Me.cCertificacion = CStr(readers.GetValue(36))
            Me.iPAsertividad = CStr(readers.GetValue(37))
            Me.iPTrabajoEquipo = CStr(readers.GetValue(38))
            Me.iPComEfectiva = CStr(readers.GetValue(39))
            Me.iPAdaptabilidad = CStr(readers.GetValue(40))
            Me.iEEstable = CStr(readers.GetValue(41))
            Me.iEInestable = CStr(readers.GetValue(42))
            Me.iCCompromiso = CStr(readers.GetValue(43))
            Me.iSRptoNorma = CStr(readers.GetValue(44))
            Me.iSIperC = CStr(readers.GetValue(45))
            Me.iSActitud = CStr(readers.GetValue(46))
            Me.dFechaRegistro = CStr(readers.GetValue(47))
            Me.iCodUsuarioRegistra = CStr(readers.GetValue(48))
            Me.dFechaEvaluacion = CStr(readers.GetValue(49))
            Me.bEvaluado = CStr(readers.GetValue(50))
            Me.dFechaVerificativa = CStr(readers.GetValue(51))
            Me.bVerificativa = CStr(readers.GetValue(52))
            Me.iEstadoVerificativa = CStr(readers.GetValue(53))
            Me.iResultadoVerificativa = CStr(readers.GetValue(54))
            Me.dFechaCargaBox = CStr(readers.GetValue(55))
            Me.bSustentoCV = CStr(readers.GetValue(56))
            Me.bContratado = CStr(readers.GetValue(57))
            Me.bCargaBox = CStr(readers.GetValue(58))
            Me.bDNIMoq = CStr(readers.GetValue(59))
            Me.bCasadoMoq = CStr(readers.GetValue(60))
            Me.bConviveMoq = CStr(readers.GetValue(61))
            Me.bHijosMoq = CStr(readers.GetValue(62))
            Me.bRucMoq = CStr(readers.GetValue(63))
            Me.bEstudioMoq = CStr(readers.GetValue(64))
            Me.bTrabajoMoq = CStr(readers.GetValue(65))
            Me.cTipoDoc = CStr(readers.GetValue(66))
            Me.iTipoIngreso = CStr(readers.GetValue(67))
            Me.cPaisNacimiento = CStr(readers.GetValue(68))
            Me.iTiempoExperiencia = CStr(readers.GetValue(69))
            Me.cDNIConyuge = CStr(readers.GetValue(70))
            Me.cUbigeoConyuge = CStr(readers.GetValue(71))
            Me.cApellidosConyuge = CStr(readers.GetValue(72))
            Me.cNombresConyuge = CStr(readers.GetValue(73))
            Me.cDNIHijo = CStr(readers.GetValue(74))
            Me.cUbigeoHijo = CStr(readers.GetValue(75))
            Me.cApellidosHijo = CStr(readers.GetValue(76))
            Me.cNombresHijo = CStr(readers.GetValue(77))
            Me.bComunidadPadron = CStr(readers.GetValue(78))
            Me.bComunidadConstancia = CStr(readers.GetValue(79))
            Me.bCip = CStr(readers.GetValue(80))
            Me.bCumplePefil = CStr(readers.GetValue(81))
            Me.bDisponible = CStr(readers.GetValue(82))
            Me.dFechaEmisionDni = CStr(readers.GetValue(83))
            Me.cEmpresaTrabaja = CStr(readers.GetValue(84))
            Me.dFechaEvaluacionResultado = CStr(readers.GetValue(85))
            Me.iCodPersonaEvalua = CStr(readers.GetValue(86))
            Me.bDiscapacitado = CStr(readers.GetValue(87))
            Me.bPrioritario = CStr(readers.GetValue(88))
            Me.iCodUsuario = CStr(readers.GetValue(89))
            Me.dFechaSis = CStr(readers.GetValue(90))
            readers.Close()
            Return True
        Else
            Return False
        End If
    End Function
    '***************************************** METODOS WEB
    Public Function GetCandidatoByDNIStat(ByVal pDNI As String, ByVal pTipoDoc As String) As DataTable
        Dim Query As String = ""
        Dim readers As DataTable

        Query = " exec dbo.SP_DT_CandidatoByDNIStat " & _
                     " @cDNI='" & Trim(pDNI) & "',   " & _
                     " @cTipoDoc='" & Trim(pTipoDoc) & "'   "

        readers = mc.ExecuteDataTable(Query)

        Return readers

    End Function
    Public Function GetCandidatoByDNIStatFL(ByVal pDNI As String, ByVal pTipoDoc As String) As DataTable
        Dim Query As String = ""
        Dim readers As DataTable

        Query = " exec dbo.SP_DT_CandidatoByDNIStatFL " & _
                     " @cDNI='" & Trim(pDNI) & "',   " & _
                     " @cTipoDoc='" & Trim(pTipoDoc) & "'"

        readers = mc.ExecuteDataTable(Query)

        Return readers

    End Function

    Public Function GetCandidatoListaPGI() As DataTable
        Dim Query As String = ""
        Dim readers As DataTable

        Query = " exec dbo.SP_DT_GetAnexoDetalleByCodigoCI " & _
                     " @iCodCandidatoInforme='" & Trim(Me.iCodCandidatoInforme) & "'   "

        readers = mc.ExecuteDataTable(Query)

        Return readers

    End Function
    Public Function GetCandidatoListaFFLL() As DataTable
        Dim Query As String = ""
        Dim readers As DataTable

        Query = " exec dbo.SP_FL_GetFFLLHistorialByCI " & _
                     " @iCodCandidatoInforme='" & Trim(Me.iCodCandidatoInforme) & "'   "

        readers = mc.ExecuteDataTable(Query)

        Return readers

    End Function

    Public Function GetCandidatoPostulaciones() As DataTable


        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = "SP_DT_PostulacionesByDNI"
        cmdSQL.Parameters.Add("@cDNI", SqlDbType.VarChar, 15).Value = Trim(Me.cDNI)


        Dim readers As SqlDataReader
        readers = cmdSQL.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(readers)
        Return dt

    End Function
    Public Function GetCandidatoPostulacionesByCI() As DataTable

        'MsgBox(Me.iCodCandidatoInforme)
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = "SP_DT_PostulacionesByCI"
        cmdSQL.Parameters.Add("@iCodCandidatoInforme", SqlDbType.Int).Value = Me.iCodCandidatoInforme


        Dim readers As SqlDataReader
        readers = cmdSQL.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(readers)
        Return dt

    End Function
    Public Function ListaCondicionWeb() As DataTable
        Dim miDataTable As New DataTable
        miDataTable.Columns.Add("ValueMember")
        miDataTable.Columns.Add("DisplayMember")
        With miDataTable
            .Rows.Add("LOCAL", "LOCAL")
            .Rows.Add("FORANEO", "FORANEO")
        End With
        Return miDataTable
    End Function

    Public Sub UpdateUbigeoTransact()
        Dim Query As String
        'Me.dFechaDisponible()
        Query = String.Format("UPDATE  Candidatoinforme SET  cUbigeo='{1}' WHERE iCodCandidatoInforme={0}", Me.iCodCandidatoInforme, Me.cUbigeo)
        mc.ExecuteQueryTransact(Query)

    End Sub

    Public Function GetCandidatoWebOAEL() As DataTable
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = "SP_DT_CandidatoByDNIWebOAEL"
        cmdSQL.Parameters.Add("@cDNI", SqlDbType.VarChar, 15).Value = Me.cDNI

        Dim readers As SqlDataReader
        readers = cmdSQL.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(readers)
        Return dt
    End Function
    Public Function GetCandidatoInformePorDniYTipoDoc(ByVal pDNI As String, ByVal pTipoDoc As String) As DataTable
        Dim Query As String = ""
        Dim readers As DataTable

        Query = " exec main.SP_ROW_CandidatoInformePorDni_Y_TipoDoc " &
                     " @cDNI='" & Trim(pDNI) & "',   " &
                     " @cTipoDoc='" & Trim(pTipoDoc) & "'   "
        readers = mc.ExecuteDataTable(Query)

        Return readers

    End Function

    Public Function GetCandidatoInformePorCodigo(ByVal pCodRegistroPostulante As String) As DataTable
        Dim Query As String = ""
        Dim readers As DataTable

        Query = " exec main.SP_ROW_CandidatoInformePorCodigo " &
                     " @iCodCandidatoInforme=" & Trim(pCodRegistroPostulante)
        readers = mc.ExecuteDataTable(Query)

        Return readers

    End Function

    Public Sub UpdateDatosContactoTransact()
        Dim Query As String
        Query = String.Format("UPDATE  Candidatoinforme SET  iTipoIngreso=1,cFono='{1}',cCorreo='{2}',cCUI='{3}',cSexo='{4}',cEstCivil='{5}',cUbigeo='{6}',cUbigeoResidencia='{7}'  WHERE iCodCandidatoInforme={0}", Me.iCodCandidatoInforme, Me.cFono, Me.cCorreo, Me.cCUI, Me.cSexo, Me.cEstCivil, Me.cUbigeo, Me.cUbigeoResidencia)
        mc.ExecuteQueryTransact(Query)
    End Sub

    Public Function ListaPostulantesPorMesRegistrado() As DataTable

        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = "main.SP_DT_ListaCandidatoInformePorMesRegistrado"
        cmdSQL.Parameters.Add("@dFechaBusqueda", SqlDbType.Date).Value = Me.dFechaBusqueda
        Dim readers As SqlDataReader
        readers = cmdSQL.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(readers)
        Return dt
    End Function

    Public Function ListaPostulantesPorDni() As DataTable

        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = "main.SP_DT_ListaCandidatoInformePorDni"
        cmdSQL.Parameters.Add("@cDniBusqueda", SqlDbType.VarChar).Value = Me.cDNI
        Dim readers As SqlDataReader
        readers = cmdSQL.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(readers)
        Return dt
    End Function
End Class
