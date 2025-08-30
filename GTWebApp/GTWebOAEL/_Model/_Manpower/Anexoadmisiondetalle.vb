Imports System.Data.SqlClient
Public Class Anexoadmisiondetalle
    Public iCodAnexoAdmisionDetalle As String
    Public iCodAnexoAdmision As String
    Public iCodCandidatoInforme As String
    Public iCodSubContrata As String
    Public iCodAnexoAdmisionTipo As String
    Public iCodOcupacion As String
    Public iCodPuesto As String
    Public bPerfilValidar As String
    Public bPerfilAprobado As String
    Public cCargo As String
    Public cMOCMONC As String
    Public cProcesoEtapa As String
    Public cNota As String
    Public cObs As String
    Public bAnulado As String
    Public bNuevo As String
    Public iCodUsuario As String
    Public dFechaSis As String
    Public qSelect As String
    Public cTipoOpe As Char
    Public bTransaccion As Boolean = False
    Public mc As New ConnectSQL
    Public Function ListaDatos() As DataTable
        Dim Query As String
        Dim readers As DataTable
        Query = "SELECT * FROM dbo.AnexoAdmisionDetalle"
        readers = mc.ExecuteDataTable(Query)
        Return readers
    End Function
    Public Sub Insertar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "INSERT into dbo.AnexoAdmisionDetalle (iCodAnexoAdmision,iCodCandidatoInforme,iCodSubContrata,iCodAnexoAdmisionTipo,iCodOcupacion,iCodPuesto,bPerfilValidar,bPerfilAprobado,cCargo,cMOCMONC,cProcesoEtapa,cNota,cObs,bAnulado,bNuevo,iCodUsuario,dFechaSis ) VALUES(@iCodAnexoAdmision,@iCodCandidatoInforme,@iCodSubContrata,@iCodAnexoAdmisionTipo,@iCodOcupacion,@iCodPuesto,@bPerfilValidar,@bPerfilAprobado,@cCargo,@cMOCMONC,@cProcesoEtapa,@cNota,@cObs,@bAnulado,@bNuevo,@iCodUsuario,@dFechaSis); SELECT SCOPE_IDENTITY(); "
        cmdSQL.Parameters.Add("@iCodAnexoAdmision", SqlDbType.Int).Value = Me.iCodAnexoAdmision
        cmdSQL.Parameters.Add("@iCodCandidatoInforme", SqlDbType.Int).Value = Me.iCodCandidatoInforme
        cmdSQL.Parameters.Add("@iCodSubContrata", SqlDbType.Int).Value = Me.iCodSubContrata
        cmdSQL.Parameters.Add("@iCodAnexoAdmisionTipo", SqlDbType.Tinyint).Value = Me.iCodAnexoAdmisionTipo
        cmdSQL.Parameters.Add("@iCodOcupacion", SqlDbType.Int).Value = Me.iCodOcupacion
        cmdSQL.Parameters.Add("@iCodPuesto", SqlDbType.Int).Value = Me.iCodPuesto
        cmdSQL.Parameters.Add("@bPerfilValidar", SqlDbType.Bit).Value = Me.bPerfilValidar
        cmdSQL.Parameters.Add("@bPerfilAprobado", SqlDbType.Bit).Value = Me.bPerfilAprobado
        cmdSQL.Parameters.Add("@cCargo", SqlDbType.Varchar, 90).Value = Me.cCargo
        cmdSQL.Parameters.Add("@cMOCMONC", SqlDbType.Varchar, 5).Value = Me.cMOCMONC
        cmdSQL.Parameters.Add("@cProcesoEtapa", SqlDbType.Char, 1).Value = Me.cProcesoEtapa
        cmdSQL.Parameters.Add("@cNota", SqlDbType.Varchar, 250).Value = Me.cNota
        cmdSQL.Parameters.Add("@cObs", SqlDbType.Varchar, 1500).Value = Me.cObs
        cmdSQL.Parameters.Add("@bAnulado", SqlDbType.Bit).Value = Me.bAnulado
        cmdSQL.Parameters.Add("@bNuevo", SqlDbType.Bit).Value = Me.bNuevo
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.Datetime).Value = Me.dFechaSis

        Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
        If pCodInsert > 0 Then
            Me.iCodAnexoAdmisionDetalle = pCodInsert
        Else
            Me.iCodAnexoAdmisionDetalle = 0
        End If
    End Sub
    Public Sub InsertarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "INSERT into dbo.AnexoAdmisionDetalle (iCodAnexoAdmision,iCodCandidatoInforme,iCodSubContrata,iCodAnexoAdmisionTipo,iCodOcupacion,iCodPuesto,bPerfilValidar,bPerfilAprobado,cCargo,cMOCMONC,cProcesoEtapa,cNota,cObs,bAnulado,bNuevo,iCodUsuario,dFechaSis ) VALUES(@iCodAnexoAdmision,@iCodCandidatoInforme,@iCodSubContrata,@iCodAnexoAdmisionTipo,@iCodOcupacion,@iCodPuesto,@bPerfilValidar,@bPerfilAprobado,@cCargo,@cMOCMONC,@cProcesoEtapa,@cNota,@cObs,@bAnulado,@bNuevo,@iCodUsuario,@dFechaSis); SELECT SCOPE_IDENTITY(); "
        cmdSQL.Parameters.Add("@iCodAnexoAdmision", SqlDbType.Int).Value = Me.iCodAnexoAdmision
        cmdSQL.Parameters.Add("@iCodCandidatoInforme", SqlDbType.Int).Value = Me.iCodCandidatoInforme
        cmdSQL.Parameters.Add("@iCodSubContrata", SqlDbType.Int).Value = Me.iCodSubContrata
        cmdSQL.Parameters.Add("@iCodAnexoAdmisionTipo", SqlDbType.Tinyint).Value = Me.iCodAnexoAdmisionTipo
        cmdSQL.Parameters.Add("@iCodOcupacion", SqlDbType.Int).Value = Me.iCodOcupacion
        cmdSQL.Parameters.Add("@iCodPuesto", SqlDbType.Int).Value = Me.iCodPuesto
        cmdSQL.Parameters.Add("@bPerfilValidar", SqlDbType.Bit).Value = Me.bPerfilValidar
        cmdSQL.Parameters.Add("@bPerfilAprobado", SqlDbType.Bit).Value = Me.bPerfilAprobado
        cmdSQL.Parameters.Add("@cCargo", SqlDbType.Varchar, 90).Value = Me.cCargo
        cmdSQL.Parameters.Add("@cMOCMONC", SqlDbType.Varchar, 5).Value = Me.cMOCMONC
        cmdSQL.Parameters.Add("@cProcesoEtapa", SqlDbType.Char, 1).Value = Me.cProcesoEtapa
        cmdSQL.Parameters.Add("@cNota", SqlDbType.Varchar, 250).Value = Me.cNota
        cmdSQL.Parameters.Add("@cObs", SqlDbType.Varchar, 1500).Value = Me.cObs
        cmdSQL.Parameters.Add("@bAnulado", SqlDbType.Bit).Value = Me.bAnulado
        cmdSQL.Parameters.Add("@bNuevo", SqlDbType.Bit).Value = Me.bNuevo
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.Datetime).Value = Me.dFechaSis

        Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
        If pCodInsert > 0 Then
            Me.iCodAnexoAdmisionDetalle = pCodInsert
        Else
            Me.iCodAnexoAdmisionDetalle = 0
        End If
    End Sub
    Public Sub Modificar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "UPDATE  dbo.AnexoAdmisionDetalle SET iCodAnexoAdmision=@iCodAnexoAdmision,iCodCandidatoInforme=@iCodCandidatoInforme,iCodSubContrata=@iCodSubContrata,iCodAnexoAdmisionTipo=@iCodAnexoAdmisionTipo,iCodOcupacion=@iCodOcupacion,iCodPuesto=@iCodPuesto,bPerfilValidar=@bPerfilValidar,bPerfilAprobado=@bPerfilAprobado,cCargo=@cCargo,cMOCMONC=@cMOCMONC,cProcesoEtapa=@cProcesoEtapa,cNota=@cNota,cObs=@cObs,bAnulado=@bAnulado,bNuevo=@bNuevo,iCodUsuario=@iCodUsuario,dFechaSis=@dFechaSis WHERE iCodAnexoAdmisionDetalle=@iCodAnexoAdmisionDetalle"
        cmdSQL.Parameters.Add("@iCodAnexoAdmisionDetalle", SqlDbType.Int).Value = Me.iCodAnexoAdmisionDetalle
        cmdSQL.Parameters.Add("@iCodAnexoAdmision", SqlDbType.Int).Value = Me.iCodAnexoAdmision
        cmdSQL.Parameters.Add("@iCodCandidatoInforme", SqlDbType.Int).Value = Me.iCodCandidatoInforme
        cmdSQL.Parameters.Add("@iCodSubContrata", SqlDbType.Int).Value = Me.iCodSubContrata
        cmdSQL.Parameters.Add("@iCodAnexoAdmisionTipo", SqlDbType.Tinyint).Value = Me.iCodAnexoAdmisionTipo
        cmdSQL.Parameters.Add("@iCodOcupacion", SqlDbType.Int).Value = Me.iCodOcupacion
        cmdSQL.Parameters.Add("@iCodPuesto", SqlDbType.Int).Value = Me.iCodPuesto
        cmdSQL.Parameters.Add("@bPerfilValidar", SqlDbType.Bit).Value = Me.bPerfilValidar
        cmdSQL.Parameters.Add("@bPerfilAprobado", SqlDbType.Bit).Value = Me.bPerfilAprobado
        cmdSQL.Parameters.Add("@cCargo", SqlDbType.Varchar, 90).Value = Me.cCargo
        cmdSQL.Parameters.Add("@cMOCMONC", SqlDbType.Varchar, 5).Value = Me.cMOCMONC
        cmdSQL.Parameters.Add("@cProcesoEtapa", SqlDbType.Char, 1).Value = Me.cProcesoEtapa
        cmdSQL.Parameters.Add("@cNota", SqlDbType.Varchar, 250).Value = Me.cNota
        cmdSQL.Parameters.Add("@cObs", SqlDbType.Varchar, 1500).Value = Me.cObs
        cmdSQL.Parameters.Add("@bAnulado", SqlDbType.Bit).Value = Me.bAnulado
        cmdSQL.Parameters.Add("@bNuevo", SqlDbType.Bit).Value = Me.bNuevo
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.Datetime).Value = Me.dFechaSis

        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub ModificarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "UPDATE  dbo.AnexoAdmisionDetalle SET iCodAnexoAdmision=@iCodAnexoAdmision,iCodCandidatoInforme=@iCodCandidatoInforme,iCodSubContrata=@iCodSubContrata,iCodAnexoAdmisionTipo=@iCodAnexoAdmisionTipo,iCodOcupacion=@iCodOcupacion,iCodPuesto=@iCodPuesto,bPerfilValidar=@bPerfilValidar,bPerfilAprobado=@bPerfilAprobado,cCargo=@cCargo,cMOCMONC=@cMOCMONC,cProcesoEtapa=@cProcesoEtapa,cNota=@cNota,cObs=@cObs,bAnulado=@bAnulado,bNuevo=@bNuevo,iCodUsuario=@iCodUsuario,dFechaSis=@dFechaSis WHERE iCodAnexoAdmisionDetalle=@iCodAnexoAdmisionDetalle"
        cmdSQL.Parameters.Add("@iCodAnexoAdmisionDetalle", SqlDbType.Int).Value = Me.iCodAnexoAdmisionDetalle
        cmdSQL.Parameters.Add("@iCodAnexoAdmision", SqlDbType.Int).Value = Me.iCodAnexoAdmision
        cmdSQL.Parameters.Add("@iCodCandidatoInforme", SqlDbType.Int).Value = Me.iCodCandidatoInforme
        cmdSQL.Parameters.Add("@iCodSubContrata", SqlDbType.Int).Value = Me.iCodSubContrata
        cmdSQL.Parameters.Add("@iCodAnexoAdmisionTipo", SqlDbType.Tinyint).Value = Me.iCodAnexoAdmisionTipo
        cmdSQL.Parameters.Add("@iCodOcupacion", SqlDbType.Int).Value = Me.iCodOcupacion
        cmdSQL.Parameters.Add("@iCodPuesto", SqlDbType.Int).Value = Me.iCodPuesto
        cmdSQL.Parameters.Add("@bPerfilValidar", SqlDbType.Bit).Value = Me.bPerfilValidar
        cmdSQL.Parameters.Add("@bPerfilAprobado", SqlDbType.Bit).Value = Me.bPerfilAprobado
        cmdSQL.Parameters.Add("@cCargo", SqlDbType.Varchar, 90).Value = Me.cCargo
        cmdSQL.Parameters.Add("@cMOCMONC", SqlDbType.Varchar, 5).Value = Me.cMOCMONC
        cmdSQL.Parameters.Add("@cProcesoEtapa", SqlDbType.Char, 1).Value = Me.cProcesoEtapa
        cmdSQL.Parameters.Add("@cNota", SqlDbType.Varchar, 250).Value = Me.cNota
        cmdSQL.Parameters.Add("@cObs", SqlDbType.Varchar, 1500).Value = Me.cObs
        cmdSQL.Parameters.Add("@bAnulado", SqlDbType.Bit).Value = Me.bAnulado
        cmdSQL.Parameters.Add("@bNuevo", SqlDbType.Bit).Value = Me.bNuevo
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.Datetime).Value = Me.dFechaSis

        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub Eliminar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "DELETE from  dbo.AnexoAdmisionDetalle  WHERE iCodAnexoAdmisionDetalle=@iCodAnexoAdmisionDetalle"
        'cmdSQL.CommandText = "UPDATE dbo.AnexoAdmisionDetalle  SET bAnulado=1 WHERE  iCodAnexoAdmisionDetalle=@iCodAnexoAdmisionDetalle"
        cmdSQL.Parameters.Add("@iCodAnexoAdmisionDetalle", SqlDbType.Int).Value = Me.iCodAnexoAdmisionDetalle
        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub EliminarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "DELETE from  dbo.AnexoAdmisionDetalle  WHERE iCodAnexoAdmisionDetalle=@iCodAnexoAdmisionDetalle"
        'cmdSQL.CommandText = "UPDATE dbo.AnexoAdmisionDetalle  SET bAnulado=1 WHERE  iCodAnexoAdmisionDetalle=@iCodAnexoAdmisionDetalle"
        cmdSQL.Parameters.Add("@iCodAnexoAdmisionDetalle", SqlDbType.Int).Value = Me.iCodAnexoAdmisionDetalle
        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub getRecord()
        Dim readers As IDataReader
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL

        If bTransaccion = True Then cmdSQL.Transaction = Me.mc.miTransact Else 

        cmdSQL.CommandText = "SELECT * FROM dbo.AnexoAdmisionDetalle WHERE iCodAnexoAdmisionDetalle=@iCodAnexoAdmisionDetalle"
        cmdSQL.Parameters.Add("@iCodAnexoAdmisionDetalle", SqlDbType.Int).Value = Me.iCodAnexoAdmisionDetalle
        readers = cmdSQL.ExecuteReader
        If readers.Read() Then
            Me.iCodAnexoAdmisionDetalle = CStr(readers.GetValue(0))
            Me.iCodAnexoAdmision = CStr(readers.GetValue(1))
            Me.iCodCandidatoInforme = CStr(readers.GetValue(2))
            Me.iCodSubContrata = CStr(readers.GetValue(3))
            Me.iCodAnexoAdmisionTipo = CStr(readers.GetValue(4))
            Me.iCodOcupacion = CStr(readers.GetValue(5))
            Me.iCodPuesto = CStr(readers.GetValue(6))
            Me.bPerfilValidar = CStr(readers.GetValue(7))
            Me.bPerfilAprobado = CStr(readers.GetValue(8))
            Me.cCargo = CStr(readers.GetValue(9))
            Me.cMOCMONC = CStr(readers.GetValue(10))
            Me.cProcesoEtapa = CStr(readers.GetValue(11))
            Me.cNota = CStr(readers.GetValue(12))
            Me.cObs = CStr(readers.GetValue(13))
            Me.bAnulado = CStr(readers.GetValue(14))
            Me.bNuevo = CStr(readers.GetValue(15))
            Me.iCodUsuario = CStr(readers.GetValue(16))
            Me.dFechaSis = CStr(readers.GetValue(17))
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
        cmdSQL.CommandText = "SELECT * FROM dbo.AnexoAdmisionDetalle"
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
    Public Sub AnularLista()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        'cmdSQL.CommandText = "DELETE from  dbo.AnexoAdmision  WHERE iCodAnexoAdmision=@iCodAnexoAdmision"
        cmdSQL.CommandText = "UPDATE dbo.AnexoAdmisionDetalle  SET bAnulado=1,iCodUsuario=@iCodUsuario,dFechaSis=GETDATE() WHERE  iCodAnexoAdmision=@iCodAnexoAdmision"
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.SmallInt).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@iCodAnexoAdmision", SqlDbType.Int).Value = Me.iCodAnexoAdmision

        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Function ListaItemsAnexo() As DataTable
        Dim Query As String
        Dim readers As DataTable
        Query = " exec dbo.SP_DT_GetAnexoAdmisionDetalle " & _
                       " @iCodAnexoAdmision='" & Trim(Me.iCodAnexoAdmision) & "'   "

        readers = mc.ExecuteDataTable(Query)
        Return readers
    End Function

    Public Function ListaTipoMotivoRechazo() As DataTable
        Dim Query As String
        Dim pTabla As String = "AnexoAdmisionDetalle"
        Dim pNombreGrupo As String = "MotivoRechazo"
        Dim readers As DataTable
        Query = " select cValueMember as ValueMember,cDisplayMember as DisplayMember From TDCatalogo where " & _
            " cTabla='" & Trim(pTabla) & "'  and cNombreGrupo='" & Trim(pNombreGrupo) & "' order by iOrden asc "
        'InputBox("", "", Query)
        readers = mc.ExecuteDataTable(Query)
        Return readers
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
    Public Sub ActualizarEstado()
        Dim Query As String
        'Query = String.Format("DELETE from Anexoadmisiondetalle WHERE iCodAnexoAdmisionDetalle={0}", Me.iCodAnexoAdmisionDetalle)
        Query = String.Format("UPDATE Anexoadmisiondetalle SET cProcesoEtapa='{1}' WHERE iCodAnexoAdmisionDetalle={0}", Me.iCodAnexoAdmisionDetalle, Me.cProcesoEtapa)

        mc.ExecuteQuery(Query)
    End Sub
    Public Function GetRecordDetalleCI() As DataTable
        Dim Query As String
        'Dim readers As DataTable
        Query = " exec dbo.SP_PGI_GetAnexoAdmisionDetalleCI " & _
                       " @iCodAnexoAdmisionDetalle='" & Trim(Me.iCodAnexoAdmisionDetalle) & "'   "

        GetRecordDetalleCI = mc.ExecuteDataTable(Query)
        Return GetRecordDetalleCI
    End Function

    Public Sub getRecordObs()
        Dim readers As IDataReader
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL

        If bTransaccion = True Then cmdSQL.Transaction = Me.mc.miTransact Else 

        cmdSQL.CommandText = "SELECT cObs FROM dbo.AnexoAdmisionDetalle WHERE iCodAnexoAdmisionDetalle=@iCodAnexoAdmisionDetalle"
        cmdSQL.Parameters.Add("@iCodAnexoAdmisionDetalle", SqlDbType.Int).Value = Me.iCodAnexoAdmisionDetalle
        readers = cmdSQL.ExecuteReader
        If readers.Read() Then
        
            Me.cObs = CStr(readers.GetValue(0))
          
        End If
        readers.Close()
    End Sub
End Class
