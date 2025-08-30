Imports System.Data.SqlClient
Public Class Candidatoestudios
Public iCodCandidatoEstudios As String
Public iCodCandidatoInforme As String
Public cCentroEstudios As String
Public iGradoInstruccion As String
Public cCarrera As String
Public iSituacionAcademica As String
Public iGradoAcademico As String
Public iCicloAcademico As String
Public iRankingAcademico As String
Public iPeriodoInicioMes As String
Public iPeriodoInicioAno As String
Public iPeriodoFinMes As String
Public iPeriodoFinAno As String
Public bPrincipal As String
Public bActivo As String
Public dFechaCreacion As String
Public iCodUsuarioCreacion As String
Public dFechaModificacion As String
Public iCodUsuarioModificacion As String
Public qSelect As String
Public cTipoOpe as Char
Public bTransaccion as Boolean=False
Public mc as New ConnectSQL
 Public Function ListaDatos() As DataTable
	Dim Query As String
	Dim readers As DataTable
	Query = "SELECT * FROM dbo.CandidatoEstudios"
	readers = mc.ExecuteDataTable(Query)
	Return readers
End Function
 Public Sub Insertar()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.CommandText ="INSERT into dbo.CandidatoEstudios (iCodCandidatoInforme,cCentroEstudios,iGradoInstruccion,cCarrera,iSituacionAcademica,iGradoAcademico,iCicloAcademico,iRankingAcademico,iPeriodoInicioMes,iPeriodoInicioAno,iPeriodoFinMes,iPeriodoFinAno,bPrincipal,bActivo,dFechaCreacion,iCodUsuarioCreacion,dFechaModificacion,iCodUsuarioModificacion ) VALUES(@iCodCandidatoInforme,@cCentroEstudios,@iGradoInstruccion,@cCarrera,@iSituacionAcademica,@iGradoAcademico,@iCicloAcademico,@iRankingAcademico,@iPeriodoInicioMes,@iPeriodoInicioAno,@iPeriodoFinMes,@iPeriodoFinAno,@bPrincipal,@bActivo,@dFechaCreacion,@iCodUsuarioCreacion,@dFechaModificacion,@iCodUsuarioModificacion); SELECT SCOPE_IDENTITY(); "
	cmdSQL.Parameters.Add("@iCodCandidatoInforme", SqlDbType.Int).Value = Me.iCodCandidatoInforme
	cmdSQL.Parameters.Add("@cCentroEstudios", SqlDbType.Varchar,250).Value = Me.cCentroEstudios
	cmdSQL.Parameters.Add("@iGradoInstruccion", SqlDbType.Int).Value = Me.iGradoInstruccion
	cmdSQL.Parameters.Add("@cCarrera", SqlDbType.Varchar,250).Value = Me.cCarrera
	cmdSQL.Parameters.Add("@iSituacionAcademica", SqlDbType.Tinyint).Value = Me.iSituacionAcademica
	cmdSQL.Parameters.Add("@iGradoAcademico", SqlDbType.Tinyint).Value = Me.iGradoAcademico
	cmdSQL.Parameters.Add("@iCicloAcademico", SqlDbType.Tinyint).Value = Me.iCicloAcademico
	cmdSQL.Parameters.Add("@iRankingAcademico", SqlDbType.Tinyint).Value = Me.iRankingAcademico
	cmdSQL.Parameters.Add("@iPeriodoInicioMes", SqlDbType.Tinyint).Value = Me.iPeriodoInicioMes
	cmdSQL.Parameters.Add("@iPeriodoInicioAno", SqlDbType.Smallint).Value = Me.iPeriodoInicioAno
	cmdSQL.Parameters.Add("@iPeriodoFinMes", SqlDbType.Tinyint).Value = Me.iPeriodoFinMes
	cmdSQL.Parameters.Add("@iPeriodoFinAno", SqlDbType.Smallint).Value = Me.iPeriodoFinAno
	cmdSQL.Parameters.Add("@bPrincipal", SqlDbType.Bit).Value = Me.bPrincipal
	cmdSQL.Parameters.Add("@bActivo", SqlDbType.Bit).Value = Me.bActivo
	cmdSQL.Parameters.Add("@dFechaCreacion", SqlDbType.Datetime).Value = Me.dFechaCreacion
	cmdSQL.Parameters.Add("@iCodUsuarioCreacion", SqlDbType.Int).Value = Me.iCodUsuarioCreacion
	cmdSQL.Parameters.Add("@dFechaModificacion", SqlDbType.Datetime).Value = Me.dFechaModificacion
	cmdSQL.Parameters.Add("@iCodUsuarioModificacion", SqlDbType.Int).Value = Me.iCodUsuarioModificacion

	Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
	If pCodInsert > 0 Then
		Me.iCodCandidatoEstudios=pCodInsert
	Else
		Me.iCodCandidatoEstudios=0
	End If
End Sub
 Public Sub InsertarTransact()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.Transaction = Me.mc.miTransact 
	cmdSQL.CommandText ="INSERT into dbo.CandidatoEstudios (iCodCandidatoInforme,cCentroEstudios,iGradoInstruccion,cCarrera,iSituacionAcademica,iGradoAcademico,iCicloAcademico,iRankingAcademico,iPeriodoInicioMes,iPeriodoInicioAno,iPeriodoFinMes,iPeriodoFinAno,bPrincipal,bActivo,dFechaCreacion,iCodUsuarioCreacion,dFechaModificacion,iCodUsuarioModificacion ) VALUES(@iCodCandidatoInforme,@cCentroEstudios,@iGradoInstruccion,@cCarrera,@iSituacionAcademica,@iGradoAcademico,@iCicloAcademico,@iRankingAcademico,@iPeriodoInicioMes,@iPeriodoInicioAno,@iPeriodoFinMes,@iPeriodoFinAno,@bPrincipal,@bActivo,@dFechaCreacion,@iCodUsuarioCreacion,@dFechaModificacion,@iCodUsuarioModificacion); SELECT SCOPE_IDENTITY(); "
	cmdSQL.Parameters.Add("@iCodCandidatoInforme", SqlDbType.Int).Value = Me.iCodCandidatoInforme
	cmdSQL.Parameters.Add("@cCentroEstudios", SqlDbType.Varchar,250).Value = Me.cCentroEstudios
	cmdSQL.Parameters.Add("@iGradoInstruccion", SqlDbType.Int).Value = Me.iGradoInstruccion
	cmdSQL.Parameters.Add("@cCarrera", SqlDbType.Varchar,250).Value = Me.cCarrera
	cmdSQL.Parameters.Add("@iSituacionAcademica", SqlDbType.Tinyint).Value = Me.iSituacionAcademica
	cmdSQL.Parameters.Add("@iGradoAcademico", SqlDbType.Tinyint).Value = Me.iGradoAcademico
	cmdSQL.Parameters.Add("@iCicloAcademico", SqlDbType.Tinyint).Value = Me.iCicloAcademico
	cmdSQL.Parameters.Add("@iRankingAcademico", SqlDbType.Tinyint).Value = Me.iRankingAcademico
	cmdSQL.Parameters.Add("@iPeriodoInicioMes", SqlDbType.Tinyint).Value = Me.iPeriodoInicioMes
	cmdSQL.Parameters.Add("@iPeriodoInicioAno", SqlDbType.Smallint).Value = Me.iPeriodoInicioAno
	cmdSQL.Parameters.Add("@iPeriodoFinMes", SqlDbType.Tinyint).Value = Me.iPeriodoFinMes
	cmdSQL.Parameters.Add("@iPeriodoFinAno", SqlDbType.Smallint).Value = Me.iPeriodoFinAno
	cmdSQL.Parameters.Add("@bPrincipal", SqlDbType.Bit).Value = Me.bPrincipal
	cmdSQL.Parameters.Add("@bActivo", SqlDbType.Bit).Value = Me.bActivo
	cmdSQL.Parameters.Add("@dFechaCreacion", SqlDbType.Datetime).Value = Me.dFechaCreacion
	cmdSQL.Parameters.Add("@iCodUsuarioCreacion", SqlDbType.Int).Value = Me.iCodUsuarioCreacion
	cmdSQL.Parameters.Add("@dFechaModificacion", SqlDbType.Datetime).Value = Me.dFechaModificacion
	cmdSQL.Parameters.Add("@iCodUsuarioModificacion", SqlDbType.Int).Value = Me.iCodUsuarioModificacion

	Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
	If pCodInsert > 0 Then
		Me.iCodCandidatoEstudios=pCodInsert
	Else
		Me.iCodCandidatoEstudios=0
	End If
End Sub
 Public Sub Modificar()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.CommandText = "UPDATE  dbo.CandidatoEstudios SET iCodCandidatoInforme=@iCodCandidatoInforme,cCentroEstudios=@cCentroEstudios,iGradoInstruccion=@iGradoInstruccion,cCarrera=@cCarrera,iSituacionAcademica=@iSituacionAcademica,iGradoAcademico=@iGradoAcademico,iCicloAcademico=@iCicloAcademico,iRankingAcademico=@iRankingAcademico,iPeriodoInicioMes=@iPeriodoInicioMes,iPeriodoInicioAno=@iPeriodoInicioAno,iPeriodoFinMes=@iPeriodoFinMes,iPeriodoFinAno=@iPeriodoFinAno,bPrincipal=@bPrincipal,bActivo=@bActivo,dFechaCreacion=@dFechaCreacion,iCodUsuarioCreacion=@iCodUsuarioCreacion,dFechaModificacion=@dFechaModificacion,iCodUsuarioModificacion=@iCodUsuarioModificacion WHERE iCodCandidatoEstudios=@iCodCandidatoEstudios"
	cmdSQL.Parameters.Add("@iCodCandidatoEstudios", SqlDbType.Int).Value = Me.iCodCandidatoEstudios
	cmdSQL.Parameters.Add("@iCodCandidatoInforme", SqlDbType.Int).Value = Me.iCodCandidatoInforme
	cmdSQL.Parameters.Add("@cCentroEstudios", SqlDbType.Varchar,250).Value = Me.cCentroEstudios
	cmdSQL.Parameters.Add("@iGradoInstruccion", SqlDbType.Int).Value = Me.iGradoInstruccion
	cmdSQL.Parameters.Add("@cCarrera", SqlDbType.Varchar,250).Value = Me.cCarrera
	cmdSQL.Parameters.Add("@iSituacionAcademica", SqlDbType.Tinyint).Value = Me.iSituacionAcademica
	cmdSQL.Parameters.Add("@iGradoAcademico", SqlDbType.Tinyint).Value = Me.iGradoAcademico
	cmdSQL.Parameters.Add("@iCicloAcademico", SqlDbType.Tinyint).Value = Me.iCicloAcademico
	cmdSQL.Parameters.Add("@iRankingAcademico", SqlDbType.Tinyint).Value = Me.iRankingAcademico
	cmdSQL.Parameters.Add("@iPeriodoInicioMes", SqlDbType.Tinyint).Value = Me.iPeriodoInicioMes
	cmdSQL.Parameters.Add("@iPeriodoInicioAno", SqlDbType.Smallint).Value = Me.iPeriodoInicioAno
	cmdSQL.Parameters.Add("@iPeriodoFinMes", SqlDbType.Tinyint).Value = Me.iPeriodoFinMes
	cmdSQL.Parameters.Add("@iPeriodoFinAno", SqlDbType.Smallint).Value = Me.iPeriodoFinAno
	cmdSQL.Parameters.Add("@bPrincipal", SqlDbType.Bit).Value = Me.bPrincipal
	cmdSQL.Parameters.Add("@bActivo", SqlDbType.Bit).Value = Me.bActivo
	cmdSQL.Parameters.Add("@dFechaCreacion", SqlDbType.Datetime).Value = Me.dFechaCreacion
	cmdSQL.Parameters.Add("@iCodUsuarioCreacion", SqlDbType.Int).Value = Me.iCodUsuarioCreacion
	cmdSQL.Parameters.Add("@dFechaModificacion", SqlDbType.Datetime).Value = Me.dFechaModificacion
	cmdSQL.Parameters.Add("@iCodUsuarioModificacion", SqlDbType.Int).Value = Me.iCodUsuarioModificacion

	cmdSQL.ExecuteNonQuery()
End Sub
 Public Sub ModificarTransact()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.Transaction = Me.mc.miTransact 
	cmdSQL.CommandText = "UPDATE  dbo.CandidatoEstudios SET iCodCandidatoInforme=@iCodCandidatoInforme,cCentroEstudios=@cCentroEstudios,iGradoInstruccion=@iGradoInstruccion,cCarrera=@cCarrera,iSituacionAcademica=@iSituacionAcademica,iGradoAcademico=@iGradoAcademico,iCicloAcademico=@iCicloAcademico,iRankingAcademico=@iRankingAcademico,iPeriodoInicioMes=@iPeriodoInicioMes,iPeriodoInicioAno=@iPeriodoInicioAno,iPeriodoFinMes=@iPeriodoFinMes,iPeriodoFinAno=@iPeriodoFinAno,bPrincipal=@bPrincipal,bActivo=@bActivo,dFechaCreacion=@dFechaCreacion,iCodUsuarioCreacion=@iCodUsuarioCreacion,dFechaModificacion=@dFechaModificacion,iCodUsuarioModificacion=@iCodUsuarioModificacion WHERE iCodCandidatoEstudios=@iCodCandidatoEstudios"
	cmdSQL.Parameters.Add("@iCodCandidatoEstudios", SqlDbType.Int).Value = Me.iCodCandidatoEstudios
	cmdSQL.Parameters.Add("@iCodCandidatoInforme", SqlDbType.Int).Value = Me.iCodCandidatoInforme
	cmdSQL.Parameters.Add("@cCentroEstudios", SqlDbType.Varchar,250).Value = Me.cCentroEstudios
	cmdSQL.Parameters.Add("@iGradoInstruccion", SqlDbType.Int).Value = Me.iGradoInstruccion
	cmdSQL.Parameters.Add("@cCarrera", SqlDbType.Varchar,250).Value = Me.cCarrera
	cmdSQL.Parameters.Add("@iSituacionAcademica", SqlDbType.Tinyint).Value = Me.iSituacionAcademica
	cmdSQL.Parameters.Add("@iGradoAcademico", SqlDbType.Tinyint).Value = Me.iGradoAcademico
	cmdSQL.Parameters.Add("@iCicloAcademico", SqlDbType.Tinyint).Value = Me.iCicloAcademico
	cmdSQL.Parameters.Add("@iRankingAcademico", SqlDbType.Tinyint).Value = Me.iRankingAcademico
	cmdSQL.Parameters.Add("@iPeriodoInicioMes", SqlDbType.Tinyint).Value = Me.iPeriodoInicioMes
	cmdSQL.Parameters.Add("@iPeriodoInicioAno", SqlDbType.Smallint).Value = Me.iPeriodoInicioAno
	cmdSQL.Parameters.Add("@iPeriodoFinMes", SqlDbType.Tinyint).Value = Me.iPeriodoFinMes
	cmdSQL.Parameters.Add("@iPeriodoFinAno", SqlDbType.Smallint).Value = Me.iPeriodoFinAno
	cmdSQL.Parameters.Add("@bPrincipal", SqlDbType.Bit).Value = Me.bPrincipal
	cmdSQL.Parameters.Add("@bActivo", SqlDbType.Bit).Value = Me.bActivo
	cmdSQL.Parameters.Add("@dFechaCreacion", SqlDbType.Datetime).Value = Me.dFechaCreacion
	cmdSQL.Parameters.Add("@iCodUsuarioCreacion", SqlDbType.Int).Value = Me.iCodUsuarioCreacion
	cmdSQL.Parameters.Add("@dFechaModificacion", SqlDbType.Datetime).Value = Me.dFechaModificacion
	cmdSQL.Parameters.Add("@iCodUsuarioModificacion", SqlDbType.Int).Value = Me.iCodUsuarioModificacion

	cmdSQL.ExecuteNonQuery()
End Sub
 Public Sub Eliminar()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.CommandText = "DELETE from  dbo.CandidatoEstudios  WHERE iCodCandidatoEstudios=@iCodCandidatoEstudios"
'cmdSQL.CommandText = "UPDATE dbo.CandidatoEstudios  SET bAnulado=1 WHERE  iCodCandidatoEstudios=@iCodCandidatoEstudios"
cmdSQL.Parameters.Add("@iCodCandidatoEstudios", SqlDbType.Int).Value = Me.iCodCandidatoEstudios
	cmdSQL.ExecuteNonQuery()
End Sub
 Public Sub EliminarTransact()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.Transaction = Me.mc.miTransact 
	cmdSQL.CommandText = "DELETE from  dbo.CandidatoEstudios  WHERE iCodCandidatoEstudios=@iCodCandidatoEstudios"
'cmdSQL.CommandText = "UPDATE dbo.CandidatoEstudios  SET bAnulado=1 WHERE  iCodCandidatoEstudios=@iCodCandidatoEstudios"
cmdSQL.Parameters.Add("@iCodCandidatoEstudios", SqlDbType.Int).Value = Me.iCodCandidatoEstudios
	cmdSQL.ExecuteNonQuery()
End Sub
Public Sub getRecord()
	Dim readers As IDataReader
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	
	If bTransaccion=True Then cmdSQL.Transaction = Me.mc.miTransact Else 

	cmdSQL.CommandText = "SELECT * FROM dbo.CandidatoEstudios WHERE iCodCandidatoEstudios=@iCodCandidatoEstudios"
	cmdSQL.Parameters.Add("@iCodCandidatoEstudios", SqlDbType.Int).Value = Me.iCodCandidatoEstudios
	readers = cmdSQL.ExecuteReader
	If readers.Read() Then
		Me.iCodCandidatoEstudios = CStr(readers.GetValue(0))
		Me.iCodCandidatoInforme = CStr(readers.GetValue(1))
		Me.cCentroEstudios = CStr(readers.GetValue(2))
		Me.iGradoInstruccion = CStr(readers.GetValue(3))
		Me.cCarrera = CStr(readers.GetValue(4))
		Me.iSituacionAcademica = CStr(readers.GetValue(5))
		Me.iGradoAcademico = CStr(readers.GetValue(6))
		Me.iCicloAcademico = CStr(readers.GetValue(7))
		Me.iRankingAcademico = CStr(readers.GetValue(8))
		Me.iPeriodoInicioMes = CStr(readers.GetValue(9))
		Me.iPeriodoInicioAno = CStr(readers.GetValue(10))
		Me.iPeriodoFinMes = CStr(readers.GetValue(11))
		Me.iPeriodoFinAno = CStr(readers.GetValue(12))
		Me.bPrincipal = CStr(readers.GetValue(13))
		Me.bActivo = CStr(readers.GetValue(14))
		Me.dFechaCreacion = CStr(readers.GetValue(15))
		Me.iCodUsuarioCreacion = CStr(readers.GetValue(16))
		Me.dFechaModificacion = CStr(readers.GetValue(17))
		Me.iCodUsuarioModificacion = CStr(readers.GetValue(18))
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
	cmdSQL.CommandText = "SELECT * FROM dbo.CandidatoEstudios"
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

    '********************************************************************************



    Public Function ListaEstudiosPorPersona() As DataTable 'ok
        Dim readers As IDataReader
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = "SP_DT_CandidatoInformeListaEstudios"
        cmdSQL.Parameters.Add("@iCodCandidatoInforme", SqlDbType.Int).Value = Me.iCodCandidatoInforme
        readers = cmdSQL.ExecuteReader()

        Dim dt As New DataTable
        dt.Load(readers)
		readers.Close()
		Return dt

    End Function
End Class
