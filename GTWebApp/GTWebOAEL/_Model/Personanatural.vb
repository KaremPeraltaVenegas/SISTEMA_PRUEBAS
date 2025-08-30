Imports System.Data.SqlClient
Public Class Personanatural
    Public iCodPersonaNatural As String

    Public iCodPersona As String
    Public cApelP As String
    Public cApelM As String
    Public cNombres As String
    Public cSexo As String
    Public cFuncion As String
    Public iCodTipoEstadoCivil As String
    Public dFechaNac As String
    Public cLugarNac As String
    Public cFono As String
    Public cCorreo As String
    Public cCusp As String
    Public cLicenciaConducir As String
    Public cCargo As String
    Public cGrupoSanguineo As String
    Public iCodTipoGradoInstruccion As String
    Public iCodDepartamentoRes As String
    Public iCodProvinciaRes As String
    Public iCodDistritoRes As String
    Public iCodDepartamentoNac As String
    Public iNroDependientes As String
    Public iSituacion As String
    Public cCodigoPlanilla As String
    Public iCodPersonaCargo As String
    Public qSelect As String
    Public cTipoOpe As Char
    Public bTransaccion As Boolean = False
    Public mc As New ConnectSQL
    Public Function ListaDatos() As DataTable
        Dim Query As String
        Dim readers As DataTable
        Query = "SELECT * FROM dbo.PersonaNatural"
        readers = mc.ExecuteDataTable(Query)
        Return readers
    End Function
    Public Sub Insertar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "INSERT into dbo.PersonaNatural (iCodPersona,cApelP,cApelM,cNombres,cSexo,cFuncion,iCodTipoEstadoCivil,dFechaNac,cLugarNac,cFono,cCorreo,cCusp,cLicenciaConducir,cCargo,cGrupoSanguineo,iCodTipoGradoInstruccion,iCodDepartamentoRes,iCodProvinciaRes,iCodDistritoRes,iCodDepartamentoNac,iNroDependientes,iSituacion,cCodigoPlanilla,iCodPersonaCargo ) VALUES(@iCodPersona,@cApelP,@cApelM,@cNombres,@cSexo,@cFuncion,@iCodTipoEstadoCivil,@dFechaNac,@cLugarNac,@cFono,@cCorreo,@cCusp,@cLicenciaConducir,@cCargo,@cGrupoSanguineo,@iCodTipoGradoInstruccion,@iCodDepartamentoRes,@iCodProvinciaRes,@iCodDistritoRes,@iCodDepartamentoNac,@iNroDependientes,@iSituacion,@cCodigoPlanilla,@iCodPersonaCargo); SELECT SCOPE_IDENTITY(); "

        cmdSQL.Parameters.Add("@iCodPersona", SqlDbType.Int).Value = Me.iCodPersona
        cmdSQL.Parameters.Add("@cApelP", SqlDbType.Varchar, 100).Value = Me.cApelP
        cmdSQL.Parameters.Add("@cApelM", SqlDbType.Varchar, 100).Value = Me.cApelM
        cmdSQL.Parameters.Add("@cNombres", SqlDbType.Varchar, 100).Value = Me.cNombres
        cmdSQL.Parameters.Add("@cSexo", SqlDbType.Char, 1).Value = Me.cSexo
        cmdSQL.Parameters.Add("@cFuncion", SqlDbType.Char, 2).Value = Me.cFuncion
        cmdSQL.Parameters.Add("@iCodTipoEstadoCivil", SqlDbType.Int).Value = Me.iCodTipoEstadoCivil
        cmdSQL.Parameters.Add("@dFechaNac", SqlDbType.Date).Value = Me.dFechaNac
        cmdSQL.Parameters.Add("@cLugarNac", SqlDbType.Varchar, 100).Value = Me.cLugarNac
        cmdSQL.Parameters.Add("@cFono", SqlDbType.Varchar, 50).Value = Me.cFono
        cmdSQL.Parameters.Add("@cCorreo", SqlDbType.Varchar, 100).Value = Me.cCorreo
        cmdSQL.Parameters.Add("@cCusp", SqlDbType.Varchar, 20).Value = Me.cCusp
        cmdSQL.Parameters.Add("@cLicenciaConducir", SqlDbType.Varchar, 20).Value = Me.cLicenciaConducir
        cmdSQL.Parameters.Add("@cCargo", SqlDbType.Varchar, 150).Value = Me.cCargo
        cmdSQL.Parameters.Add("@cGrupoSanguineo", SqlDbType.Varchar, 5).Value = Me.cGrupoSanguineo
        cmdSQL.Parameters.Add("@iCodTipoGradoInstruccion", SqlDbType.Int).Value = Me.iCodTipoGradoInstruccion
        cmdSQL.Parameters.Add("@iCodDepartamentoRes", SqlDbType.Int).Value = Me.iCodDepartamentoRes
        cmdSQL.Parameters.Add("@iCodProvinciaRes", SqlDbType.Int).Value = Me.iCodProvinciaRes
        cmdSQL.Parameters.Add("@iCodDistritoRes", SqlDbType.Int).Value = Me.iCodDistritoRes
        cmdSQL.Parameters.Add("@iCodDepartamentoNac", SqlDbType.Int).Value = Me.iCodDepartamentoNac
        cmdSQL.Parameters.Add("@iNroDependientes", SqlDbType.Int).Value = Me.iNroDependientes
        cmdSQL.Parameters.Add("@iSituacion", SqlDbType.Int).Value = Me.iSituacion
        cmdSQL.Parameters.Add("@cCodigoPlanilla", SqlDbType.Varchar, 6).Value = Me.cCodigoPlanilla
        cmdSQL.Parameters.Add("@iCodPersonaCargo", SqlDbType.Int).Value = Me.iCodPersonaCargo

        Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
        If pCodInsert > 0 Then
            Me.iCodPersonaNatural = pCodInsert
        Else
            Me.iCodPersonaNatural = 0
        End If
    End Sub
    Public Sub InsertarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "INSERT into dbo.PersonaNatural (iCodPersona,cApelP,cApelM,cNombres,cSexo,cFuncion,iCodTipoEstadoCivil,dFechaNac,cLugarNac,cFono,cCorreo,cCusp,cLicenciaConducir,cCargo,cGrupoSanguineo,iCodTipoGradoInstruccion,iCodDepartamentoRes,iCodProvinciaRes,iCodDistritoRes,iCodDepartamentoNac,iNroDependientes,iSituacion,cCodigoPlanilla,iCodPersonaCargo ) VALUES(@iCodPersona,@cApelP,@cApelM,@cNombres,@cSexo,@cFuncion,@iCodTipoEstadoCivil,@dFechaNac,@cLugarNac,@cFono,@cCorreo,@cCusp,@cLicenciaConducir,@cCargo,@cGrupoSanguineo,@iCodTipoGradoInstruccion,@iCodDepartamentoRes,@iCodProvinciaRes,@iCodDistritoRes,@iCodDepartamentoNac,@iNroDependientes,@iSituacion,@cCodigoPlanilla,@iCodPersonaCargo); SELECT SCOPE_IDENTITY(); "


        cmdSQL.Parameters.Add("@iCodPersona", SqlDbType.Int).Value = Me.iCodPersona
        cmdSQL.Parameters.Add("@cApelP", SqlDbType.Varchar, 100).Value = Me.cApelP
        cmdSQL.Parameters.Add("@cApelM", SqlDbType.Varchar, 100).Value = Me.cApelM
        cmdSQL.Parameters.Add("@cNombres", SqlDbType.Varchar, 100).Value = Me.cNombres
        cmdSQL.Parameters.Add("@cSexo", SqlDbType.Char, 1).Value = Me.cSexo
        cmdSQL.Parameters.Add("@cFuncion", SqlDbType.Char, 2).Value = Me.cFuncion
        cmdSQL.Parameters.Add("@iCodTipoEstadoCivil", SqlDbType.Int).Value = Me.iCodTipoEstadoCivil
        cmdSQL.Parameters.Add("@dFechaNac", SqlDbType.Date).Value = Me.dFechaNac
        cmdSQL.Parameters.Add("@cLugarNac", SqlDbType.Varchar, 100).Value = Me.cLugarNac
        cmdSQL.Parameters.Add("@cFono", SqlDbType.Varchar, 50).Value = Me.cFono
        cmdSQL.Parameters.Add("@cCorreo", SqlDbType.Varchar, 100).Value = Me.cCorreo
        cmdSQL.Parameters.Add("@cCusp", SqlDbType.Varchar, 20).Value = Me.cCusp
        cmdSQL.Parameters.Add("@cLicenciaConducir", SqlDbType.Varchar, 20).Value = Me.cLicenciaConducir
        cmdSQL.Parameters.Add("@cCargo", SqlDbType.Varchar, 150).Value = Me.cCargo
        cmdSQL.Parameters.Add("@cGrupoSanguineo", SqlDbType.Varchar, 5).Value = Me.cGrupoSanguineo
        cmdSQL.Parameters.Add("@iCodTipoGradoInstruccion", SqlDbType.Int).Value = Me.iCodTipoGradoInstruccion
        cmdSQL.Parameters.Add("@iCodDepartamentoRes", SqlDbType.Int).Value = Me.iCodDepartamentoRes
        cmdSQL.Parameters.Add("@iCodProvinciaRes", SqlDbType.Int).Value = Me.iCodProvinciaRes
        cmdSQL.Parameters.Add("@iCodDistritoRes", SqlDbType.Int).Value = Me.iCodDistritoRes
        cmdSQL.Parameters.Add("@iCodDepartamentoNac", SqlDbType.Int).Value = Me.iCodDepartamentoNac
        cmdSQL.Parameters.Add("@iNroDependientes", SqlDbType.Int).Value = Me.iNroDependientes
        cmdSQL.Parameters.Add("@iSituacion", SqlDbType.Int).Value = Me.iSituacion
        cmdSQL.Parameters.Add("@cCodigoPlanilla", SqlDbType.Varchar, 6).Value = Me.cCodigoPlanilla
        cmdSQL.Parameters.Add("@iCodPersonaCargo", SqlDbType.Int).Value = Me.iCodPersonaCargo

        Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
        If pCodInsert > 0 Then
            Me.iCodPersonaNatural = pCodInsert
        Else
            Me.iCodPersonaNatural = 0
        End If
    End Sub
    Public Sub Modificar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "UPDATE  dbo.PersonaNatural SET  iCodPersona=@iCodPersona,cApelP=@cApelP,cApelM=@cApelM,cNombres=@cNombres,cSexo=@cSexo,cFuncion=@cFuncion,iCodTipoEstadoCivil=@iCodTipoEstadoCivil,dFechaNac=@dFechaNac,cLugarNac=@cLugarNac,cFono=@cFono,cCorreo=@cCorreo,cCusp=@cCusp,cLicenciaConducir=@cLicenciaConducir,cCargo=@cCargo,cGrupoSanguineo=@cGrupoSanguineo,iCodTipoGradoInstruccion=@iCodTipoGradoInstruccion,iCodDepartamentoRes=@iCodDepartamentoRes,iCodProvinciaRes=@iCodProvinciaRes,iCodDistritoRes=@iCodDistritoRes,iCodDepartamentoNac=@iCodDepartamentoNac,iNroDependientes=@iNroDependientes,iSituacion=@iSituacion,cCodigoPlanilla=@cCodigoPlanilla,iCodPersonaCargo=@iCodPersonaCargo WHERE iCodPersonaNatural=@iCodPersonaNatural"

        cmdSQL.Parameters.Add("@iCodPersonaNatural", SqlDbType.Int).Value = Me.iCodPersonaNatural
        cmdSQL.Parameters.Add("@iCodPersona", SqlDbType.Int).Value = Me.iCodPersona
        cmdSQL.Parameters.Add("@cApelP", SqlDbType.Varchar, 100).Value = Me.cApelP
        cmdSQL.Parameters.Add("@cApelM", SqlDbType.Varchar, 100).Value = Me.cApelM
        cmdSQL.Parameters.Add("@cNombres", SqlDbType.Varchar, 100).Value = Me.cNombres
        cmdSQL.Parameters.Add("@cSexo", SqlDbType.Char, 1).Value = Me.cSexo
        cmdSQL.Parameters.Add("@cFuncion", SqlDbType.Char, 2).Value = Me.cFuncion
        cmdSQL.Parameters.Add("@iCodTipoEstadoCivil", SqlDbType.Int).Value = Me.iCodTipoEstadoCivil
        cmdSQL.Parameters.Add("@dFechaNac", SqlDbType.Date).Value = Me.dFechaNac
        cmdSQL.Parameters.Add("@cLugarNac", SqlDbType.Varchar, 100).Value = Me.cLugarNac
        cmdSQL.Parameters.Add("@cFono", SqlDbType.Varchar, 50).Value = Me.cFono
        cmdSQL.Parameters.Add("@cCorreo", SqlDbType.Varchar, 100).Value = Me.cCorreo
        cmdSQL.Parameters.Add("@cCusp", SqlDbType.Varchar, 20).Value = Me.cCusp
        cmdSQL.Parameters.Add("@cLicenciaConducir", SqlDbType.Varchar, 20).Value = Me.cLicenciaConducir
        cmdSQL.Parameters.Add("@cCargo", SqlDbType.Varchar, 150).Value = Me.cCargo
        cmdSQL.Parameters.Add("@cGrupoSanguineo", SqlDbType.Varchar, 5).Value = Me.cGrupoSanguineo
        cmdSQL.Parameters.Add("@iCodTipoGradoInstruccion", SqlDbType.Int).Value = Me.iCodTipoGradoInstruccion
        cmdSQL.Parameters.Add("@iCodDepartamentoRes", SqlDbType.Int).Value = Me.iCodDepartamentoRes
        cmdSQL.Parameters.Add("@iCodProvinciaRes", SqlDbType.Int).Value = Me.iCodProvinciaRes
        cmdSQL.Parameters.Add("@iCodDistritoRes", SqlDbType.Int).Value = Me.iCodDistritoRes
        cmdSQL.Parameters.Add("@iCodDepartamentoNac", SqlDbType.Int).Value = Me.iCodDepartamentoNac
        cmdSQL.Parameters.Add("@iNroDependientes", SqlDbType.Int).Value = Me.iNroDependientes
        cmdSQL.Parameters.Add("@iSituacion", SqlDbType.Int).Value = Me.iSituacion
        cmdSQL.Parameters.Add("@cCodigoPlanilla", SqlDbType.Varchar, 6).Value = Me.cCodigoPlanilla
        cmdSQL.Parameters.Add("@iCodPersonaCargo", SqlDbType.Int).Value = Me.iCodPersonaCargo

        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub ModificarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "UPDATE  dbo.PersonaNatural SET  iCodPersona=@iCodPersona,cApelP=@cApelP,cApelM=@cApelM,cNombres=@cNombres,cSexo=@cSexo,cFuncion=@cFuncion,iCodTipoEstadoCivil=@iCodTipoEstadoCivil,dFechaNac=@dFechaNac,cLugarNac=@cLugarNac,cFono=@cFono,cCorreo=@cCorreo,cCusp=@cCusp,cLicenciaConducir=@cLicenciaConducir,cCargo=@cCargo,cGrupoSanguineo=@cGrupoSanguineo,iCodTipoGradoInstruccion=@iCodTipoGradoInstruccion,iCodDepartamentoRes=@iCodDepartamentoRes,iCodProvinciaRes=@iCodProvinciaRes,iCodDistritoRes=@iCodDistritoRes,iCodDepartamentoNac=@iCodDepartamentoNac,iNroDependientes=@iNroDependientes,iSituacion=@iSituacion,cCodigoPlanilla=@cCodigoPlanilla,iCodPersonaCargo=@iCodPersonaCargo WHERE iCodPersonaNatural=@iCodPersonaNatural"

        cmdSQL.Parameters.Add("@iCodPersonaNatural", SqlDbType.Int).Value = Me.iCodPersonaNatural
        cmdSQL.Parameters.Add("@iCodPersona", SqlDbType.Int).Value = Me.iCodPersona
        cmdSQL.Parameters.Add("@cApelP", SqlDbType.Varchar, 100).Value = Me.cApelP
        cmdSQL.Parameters.Add("@cApelM", SqlDbType.Varchar, 100).Value = Me.cApelM
        cmdSQL.Parameters.Add("@cNombres", SqlDbType.Varchar, 100).Value = Me.cNombres
        cmdSQL.Parameters.Add("@cSexo", SqlDbType.Char, 1).Value = Me.cSexo
        cmdSQL.Parameters.Add("@cFuncion", SqlDbType.Char, 2).Value = Me.cFuncion
        cmdSQL.Parameters.Add("@iCodTipoEstadoCivil", SqlDbType.Int).Value = Me.iCodTipoEstadoCivil
        cmdSQL.Parameters.Add("@dFechaNac", SqlDbType.Date).Value = Me.dFechaNac
        cmdSQL.Parameters.Add("@cLugarNac", SqlDbType.Varchar, 100).Value = Me.cLugarNac
        cmdSQL.Parameters.Add("@cFono", SqlDbType.Varchar, 50).Value = Me.cFono
        cmdSQL.Parameters.Add("@cCorreo", SqlDbType.Varchar, 100).Value = Me.cCorreo
        cmdSQL.Parameters.Add("@cCusp", SqlDbType.Varchar, 20).Value = Me.cCusp
        cmdSQL.Parameters.Add("@cLicenciaConducir", SqlDbType.Varchar, 20).Value = Me.cLicenciaConducir
        cmdSQL.Parameters.Add("@cCargo", SqlDbType.Varchar, 150).Value = Me.cCargo
        cmdSQL.Parameters.Add("@cGrupoSanguineo", SqlDbType.Varchar, 5).Value = Me.cGrupoSanguineo
        cmdSQL.Parameters.Add("@iCodTipoGradoInstruccion", SqlDbType.Int).Value = Me.iCodTipoGradoInstruccion
        cmdSQL.Parameters.Add("@iCodDepartamentoRes", SqlDbType.Int).Value = Me.iCodDepartamentoRes
        cmdSQL.Parameters.Add("@iCodProvinciaRes", SqlDbType.Int).Value = Me.iCodProvinciaRes
        cmdSQL.Parameters.Add("@iCodDistritoRes", SqlDbType.Int).Value = Me.iCodDistritoRes
        cmdSQL.Parameters.Add("@iCodDepartamentoNac", SqlDbType.Int).Value = Me.iCodDepartamentoNac
        cmdSQL.Parameters.Add("@iNroDependientes", SqlDbType.Int).Value = Me.iNroDependientes
        cmdSQL.Parameters.Add("@iSituacion", SqlDbType.Int).Value = Me.iSituacion
        cmdSQL.Parameters.Add("@cCodigoPlanilla", SqlDbType.Varchar, 6).Value = Me.cCodigoPlanilla
        cmdSQL.Parameters.Add("@iCodPersonaCargo", SqlDbType.Int).Value = Me.iCodPersonaCargo

        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub Eliminar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "DELETE from  dbo.PersonaNatural  WHERE iCodPersonaNatural=@iCodPersonaNatural"
        'cmdSQL.CommandText = "UPDATE dbo.PersonaNatural  SET bAnulado=1 WHERE  iCodPersonaNatural=@iCodPersonaNatural"
        cmdSQL.Parameters.Add("@iCodPersonaNatural", SqlDbType.Int).Value = Me.iCodPersonaNatural
        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub EliminarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "DELETE from  dbo.PersonaNatural  WHERE iCodPersonaNatural=@iCodPersonaNatural"
        'cmdSQL.CommandText = "UPDATE dbo.PersonaNatural  SET bAnulado=1 WHERE  iCodPersonaNatural=@iCodPersonaNatural"
        cmdSQL.Parameters.Add("@iCodPersonaNatural", SqlDbType.Int).Value = Me.iCodPersonaNatural
        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub getRecord()
        Dim readers As IDataReader
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL

        If bTransaccion = True Then cmdSQL.Transaction = Me.mc.miTransact Else 

        cmdSQL.CommandText = "SELECT * FROM dbo.PersonaNatural WHERE iCodPersonaNatural=@iCodPersonaNatural"
        cmdSQL.Parameters.Add("@iCodPersonaNatural", SqlDbType.Int).Value = Me.iCodPersonaNatural
        readers = cmdSQL.ExecuteReader
        If readers.Read() Then
            Me.iCodPersonaNatural = CStr(readers.GetValue(0))

            Me.iCodPersona = CStr(readers.GetValue(1))
            Me.cApelP = CStr(readers.GetValue(2))
            Me.cApelM = CStr(readers.GetValue(3))
            Me.cNombres = CStr(readers.GetValue(4))
            Me.cSexo = CStr(readers.GetValue(5))
            Me.cFuncion = CStr(readers.GetValue(6))
            Me.iCodTipoEstadoCivil = CStr(readers.GetValue(7))
            Me.dFechaNac = CStr(readers.GetValue(8))
            Me.cLugarNac = CStr(readers.GetValue(9))
            Me.cFono = CStr(readers.GetValue(10))
            Me.cCorreo = CStr(readers.GetValue(11))
            Me.cCusp = CStr(readers.GetValue(12))
            Me.cLicenciaConducir = CStr(readers.GetValue(13))
            Me.cCargo = CStr(readers.GetValue(14))
            Me.cGrupoSanguineo = CStr(readers.GetValue(15))
            Me.iCodTipoGradoInstruccion = CStr(readers.GetValue(16))
            Me.iCodDepartamentoRes = CStr(readers.GetValue(17))
            Me.iCodProvinciaRes = CStr(readers.GetValue(18))
            Me.iCodDistritoRes = CStr(readers.GetValue(19))
            Me.iCodDepartamentoNac = CStr(readers.GetValue(20))
            Me.iNroDependientes = CStr(readers.GetValue(21))
            Me.iSituacion = CStr(readers.GetValue(22))
            Me.cCodigoPlanilla = CStr(readers.GetValue(23))
            Me.iCodPersonaCargo = CStr(readers.GetValue(24))
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
        cmdSQL.CommandText = "SELECT * FROM dbo.PersonaNatural"
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

    '*****************************************
    Public Function GetPersonaByDNI(ByVal pDNI As String, ByVal pTipoDoc As String) As DataTable
      


        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = "dbo.SP_ROW_PersonaByDNI"
        cmdSQL.Parameters.Add("@cDNI", SqlDbType.VarChar, 15).Value = Trim(pDNI)

        Dim readers As SqlDataReader
        readers = cmdSQL.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(readers)
        Return dt
    End Function
    Public Sub UpdateDataWeb()
        'Dim Query As String

        'Query = String.Format("UPDATE Personanatural SET cCorreo='{1}',cFono='{2}' WHERE iCodPersona={0}", Me.iCodPersona, Me.cCorreo, Me.cFono)

        'mc.ExecuteQueryTransact(Query)


        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        'If bTransaccion = True Then cmdSQL.Transaction = Me.mc.miTransact Else 
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "UPDATE Personanatural SET cCorreo=@cCorreo,cFono=@cFono WHERE iCodPersona=@iCodPersona"
        cmdSQL.Parameters.Add("@iCodPersona", SqlDbType.Int).Value = Me.iCodPersona
        cmdSQL.Parameters.Add("@cFono", SqlDbType.VarChar, 50).Value = Me.cFono
        cmdSQL.Parameters.Add("@cCorreo", SqlDbType.VarChar, 100).Value = Me.cCorreo

        cmdSQL.ExecuteNonQuery()
         

    End Sub
End Class
