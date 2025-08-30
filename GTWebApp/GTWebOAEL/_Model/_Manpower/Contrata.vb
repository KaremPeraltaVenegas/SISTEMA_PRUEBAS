Imports System.Data.SqlClient
Public Class Contrata
    Public iCodContrata As String
    Public cNomContrata As String
    Public cRUC As String
    Public cResponsable As String
    Public cFono As String
    Public cCorreo As String
    Public cContacto1 As String
    Public cFono1 As String
    Public cCorreo1 As String
    Public cContacto2 As String
    Public cFono2 As String
    Public cNomCorto As String
    Public bSubContrata As String
    Public iCodUsuario As String
    Public dFechaSis As String
    Public qSelect As String
    Public cTipoOpe As Char
    Public bTransaccion As Boolean = False
    Public mc As New ConnectSQL
    Public Function ListaDatos() As DataTable
        Dim Query As String
        Dim readers As DataTable
        Query = "SELECT * FROM dbo.Contrata"
        readers = mc.ExecuteDataTable(Query)
        Return readers
    End Function
    Public Sub Insertar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "INSERT into dbo.Contrata (cNomContrata,cRUC,cResponsable,cFono,cCorreo,cContacto1,cFono1,cCorreo1,cContacto2,cFono2,cNomCorto,bSubContrata,iCodUsuario,dFechaSis ) VALUES(@cNomContrata,@cRUC,@cResponsable,@cFono,@cCorreo,@cContacto1,@cFono1,@cCorreo1,@cContacto2,@cFono2,@cNomCorto,@bSubContrata,@iCodUsuario,@dFechaSis); SELECT SCOPE_IDENTITY(); "
        cmdSQL.Parameters.Add("@cNomContrata", SqlDbType.Varchar, 150).Value = Me.cNomContrata
        cmdSQL.Parameters.Add("@cRUC", SqlDbType.Varchar, 11).Value = Me.cRUC
        cmdSQL.Parameters.Add("@cResponsable", SqlDbType.Varchar, 70).Value = Me.cResponsable
        cmdSQL.Parameters.Add("@cFono", SqlDbType.Varchar, 25).Value = Me.cFono
        cmdSQL.Parameters.Add("@cCorreo", SqlDbType.Varchar, 40).Value = Me.cCorreo
        cmdSQL.Parameters.Add("@cContacto1", SqlDbType.Varchar, 70).Value = Me.cContacto1
        cmdSQL.Parameters.Add("@cFono1", SqlDbType.Varchar, 25).Value = Me.cFono1
        cmdSQL.Parameters.Add("@cCorreo1", SqlDbType.Varchar, 40).Value = Me.cCorreo1
        cmdSQL.Parameters.Add("@cContacto2", SqlDbType.Varchar, 70).Value = Me.cContacto2
        cmdSQL.Parameters.Add("@cFono2", SqlDbType.Varchar, 25).Value = Me.cFono2
        cmdSQL.Parameters.Add("@cNomCorto", SqlDbType.Varchar, 100).Value = Me.cNomCorto
        cmdSQL.Parameters.Add("@bSubContrata", SqlDbType.Bit).Value = Me.bSubContrata
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.Datetime).Value = Me.dFechaSis

        Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
        If pCodInsert > 0 Then
            Me.iCodContrata = pCodInsert
        Else
            Me.iCodContrata = 0
        End If
    End Sub
    Public Sub InsertarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "INSERT into dbo.Contrata (cNomContrata,cRUC,cResponsable,cFono,cCorreo,cContacto1,cFono1,cCorreo1,cContacto2,cFono2,cNomCorto,bSubContrata,iCodUsuario,dFechaSis ) VALUES(@cNomContrata,@cRUC,@cResponsable,@cFono,@cCorreo,@cContacto1,@cFono1,@cCorreo1,@cContacto2,@cFono2,@cNomCorto,@bSubContrata,@iCodUsuario,@dFechaSis); SELECT SCOPE_IDENTITY(); "
        cmdSQL.Parameters.Add("@cNomContrata", SqlDbType.Varchar, 150).Value = Me.cNomContrata
        cmdSQL.Parameters.Add("@cRUC", SqlDbType.Varchar, 11).Value = Me.cRUC
        cmdSQL.Parameters.Add("@cResponsable", SqlDbType.Varchar, 70).Value = Me.cResponsable
        cmdSQL.Parameters.Add("@cFono", SqlDbType.Varchar, 25).Value = Me.cFono
        cmdSQL.Parameters.Add("@cCorreo", SqlDbType.Varchar, 40).Value = Me.cCorreo
        cmdSQL.Parameters.Add("@cContacto1", SqlDbType.Varchar, 70).Value = Me.cContacto1
        cmdSQL.Parameters.Add("@cFono1", SqlDbType.Varchar, 25).Value = Me.cFono1
        cmdSQL.Parameters.Add("@cCorreo1", SqlDbType.Varchar, 40).Value = Me.cCorreo1
        cmdSQL.Parameters.Add("@cContacto2", SqlDbType.Varchar, 70).Value = Me.cContacto2
        cmdSQL.Parameters.Add("@cFono2", SqlDbType.Varchar, 25).Value = Me.cFono2
        cmdSQL.Parameters.Add("@cNomCorto", SqlDbType.Varchar, 100).Value = Me.cNomCorto
        cmdSQL.Parameters.Add("@bSubContrata", SqlDbType.Bit).Value = Me.bSubContrata
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.Datetime).Value = Me.dFechaSis

        Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
        If pCodInsert > 0 Then
            Me.iCodContrata = pCodInsert
        Else
            Me.iCodContrata = 0
        End If
    End Sub
    Public Sub Modificar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "UPDATE  dbo.Contrata SET cNomContrata=@cNomContrata,cRUC=@cRUC,cResponsable=@cResponsable,cFono=@cFono,cCorreo=@cCorreo,cContacto1=@cContacto1,cFono1=@cFono1,cCorreo1=@cCorreo1,cContacto2=@cContacto2,cFono2=@cFono2,cNomCorto=@cNomCorto,bSubContrata=@bSubContrata,iCodUsuario=@iCodUsuario,dFechaSis=@dFechaSis WHERE iCodContrata=@iCodContrata"
        cmdSQL.Parameters.Add("@iCodContrata", SqlDbType.Int).Value = Me.iCodContrata
        cmdSQL.Parameters.Add("@cNomContrata", SqlDbType.Varchar, 150).Value = Me.cNomContrata
        cmdSQL.Parameters.Add("@cRUC", SqlDbType.Varchar, 11).Value = Me.cRUC
        cmdSQL.Parameters.Add("@cResponsable", SqlDbType.Varchar, 70).Value = Me.cResponsable
        cmdSQL.Parameters.Add("@cFono", SqlDbType.Varchar, 25).Value = Me.cFono
        cmdSQL.Parameters.Add("@cCorreo", SqlDbType.Varchar, 40).Value = Me.cCorreo
        cmdSQL.Parameters.Add("@cContacto1", SqlDbType.Varchar, 70).Value = Me.cContacto1
        cmdSQL.Parameters.Add("@cFono1", SqlDbType.Varchar, 25).Value = Me.cFono1
        cmdSQL.Parameters.Add("@cCorreo1", SqlDbType.Varchar, 40).Value = Me.cCorreo1
        cmdSQL.Parameters.Add("@cContacto2", SqlDbType.Varchar, 70).Value = Me.cContacto2
        cmdSQL.Parameters.Add("@cFono2", SqlDbType.Varchar, 25).Value = Me.cFono2
        cmdSQL.Parameters.Add("@cNomCorto", SqlDbType.Varchar, 100).Value = Me.cNomCorto
        cmdSQL.Parameters.Add("@bSubContrata", SqlDbType.Bit).Value = Me.bSubContrata
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.Datetime).Value = Me.dFechaSis

        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub ModificarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "UPDATE  dbo.Contrata SET cNomContrata=@cNomContrata,cRUC=@cRUC,cResponsable=@cResponsable,cFono=@cFono,cCorreo=@cCorreo,cContacto1=@cContacto1,cFono1=@cFono1,cCorreo1=@cCorreo1,cContacto2=@cContacto2,cFono2=@cFono2,cNomCorto=@cNomCorto,bSubContrata=@bSubContrata,iCodUsuario=@iCodUsuario,dFechaSis=@dFechaSis WHERE iCodContrata=@iCodContrata"
        cmdSQL.Parameters.Add("@iCodContrata", SqlDbType.Int).Value = Me.iCodContrata
        cmdSQL.Parameters.Add("@cNomContrata", SqlDbType.Varchar, 150).Value = Me.cNomContrata
        cmdSQL.Parameters.Add("@cRUC", SqlDbType.Varchar, 11).Value = Me.cRUC
        cmdSQL.Parameters.Add("@cResponsable", SqlDbType.Varchar, 70).Value = Me.cResponsable
        cmdSQL.Parameters.Add("@cFono", SqlDbType.Varchar, 25).Value = Me.cFono
        cmdSQL.Parameters.Add("@cCorreo", SqlDbType.Varchar, 40).Value = Me.cCorreo
        cmdSQL.Parameters.Add("@cContacto1", SqlDbType.Varchar, 70).Value = Me.cContacto1
        cmdSQL.Parameters.Add("@cFono1", SqlDbType.Varchar, 25).Value = Me.cFono1
        cmdSQL.Parameters.Add("@cCorreo1", SqlDbType.Varchar, 40).Value = Me.cCorreo1
        cmdSQL.Parameters.Add("@cContacto2", SqlDbType.Varchar, 70).Value = Me.cContacto2
        cmdSQL.Parameters.Add("@cFono2", SqlDbType.Varchar, 25).Value = Me.cFono2
        cmdSQL.Parameters.Add("@cNomCorto", SqlDbType.Varchar, 100).Value = Me.cNomCorto
        cmdSQL.Parameters.Add("@bSubContrata", SqlDbType.Bit).Value = Me.bSubContrata
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.Datetime).Value = Me.dFechaSis

        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub Eliminar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "DELETE from  dbo.Contrata  WHERE iCodContrata=@iCodContrata"
        'cmdSQL.CommandText = "UPDATE dbo.Contrata  SET bAnulado=1 WHERE  iCodContrata=@iCodContrata"
        cmdSQL.Parameters.Add("@iCodContrata", SqlDbType.Int).Value = Me.iCodContrata
        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub EliminarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "DELETE from  dbo.Contrata  WHERE iCodContrata=@iCodContrata"
        'cmdSQL.CommandText = "UPDATE dbo.Contrata  SET bAnulado=1 WHERE  iCodContrata=@iCodContrata"
        cmdSQL.Parameters.Add("@iCodContrata", SqlDbType.Int).Value = Me.iCodContrata
        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub getRecord()
        Dim readers As IDataReader
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL

        If bTransaccion = True Then cmdSQL.Transaction = Me.mc.miTransact Else 

        cmdSQL.CommandText = "SELECT * FROM dbo.Contrata WHERE iCodContrata=@iCodContrata"
        cmdSQL.Parameters.Add("@iCodContrata", SqlDbType.Int).Value = Me.iCodContrata
        readers = cmdSQL.ExecuteReader
        If readers.Read() Then
            Me.iCodContrata = CStr(readers.GetValue(0))
            Me.cNomContrata = CStr(readers.GetValue(1))
            Me.cRUC = CStr(readers.GetValue(2))
            Me.cResponsable = CStr(readers.GetValue(3))
            Me.cFono = CStr(readers.GetValue(4))
            Me.cCorreo = CStr(readers.GetValue(5))
            Me.cContacto1 = CStr(readers.GetValue(6))
            Me.cFono1 = CStr(readers.GetValue(7))
            Me.cCorreo1 = CStr(readers.GetValue(8))
            Me.cContacto2 = CStr(readers.GetValue(9))
            Me.cFono2 = CStr(readers.GetValue(10))
            Me.cNomCorto = CStr(readers.GetValue(11))
            Me.bSubContrata = CStr(readers.GetValue(12))
            Me.iCodUsuario = CStr(readers.GetValue(13))
            Me.dFechaSis = CStr(readers.GetValue(14))
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
        cmdSQL.CommandText = "SELECT * FROM dbo.Contrata"
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
    '*************************************************************************************************************
    Public Function ListaContratistas() As DataTable
        Dim miDataTable As New DataTable
        Dim Query As String
        Dim readers As IDataReader
        miDataTable.Columns.Add("ValueMember")
        miDataTable.Columns.Add("DisplayMember")
        Query = String.Format("SELECT iCodContrata,cNomContrata FROM Contrata where bSubContrata=0")
        readers = mc.ExecuteReader(Query)
        While readers.Read()
            miDataTable.Rows.Add(CStr(readers.GetValue(0)), CStr(readers.GetValue(1)))
        End While
        readers.Close()
        Return miDataTable
    End Function
    Public Function ListaContratistasTodo() As DataTable
        Dim miDataTable As New DataTable
        Dim Query As String
        Dim readers As IDataReader
        miDataTable.Columns.Add("ValueMember")
        miDataTable.Columns.Add("DisplayMember")
        Query = String.Format("SELECT iCodContrata,cNomCorto FROM Contrata where cRUC<>'' ")

        readers = mc.ExecuteReader(Query)
        While readers.Read()
            miDataTable.Rows.Add(CStr(readers.GetValue(0)), CStr(readers.GetValue(1)))
        End While
        readers.Close()
        Return miDataTable
    End Function
    Public Function ListaContratistasPrincipales() As DataTable

        Dim Query As String
        Dim readers As DataTable
        Query = String.Format("SELECT iCodContrata as ValueMember,cNomContrata as DisplayMember FROM Contrata where bSubContrata=0 order by cNomContrata")
        readers = mc.ExecuteDataTable(Query)
        Return readers

    End Function
    Public Function ListaContratistasAll() As DataTable

        Dim Query As String
        Dim readers As DataTable
        Query = String.Format("SELECT iCodContrata as ValueMember,cNomContrata as DisplayMember FROM Contrata order by cNomContrata")
        readers = mc.ExecuteDataTable(Query)
        Return readers

    End Function


    Public Function InsertarSubContrata() As Integer

        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = "dbo.SP_INSER_ContrataWeb"
        cmdSQL.Parameters.Add("@cRUC", SqlDbType.VarChar, 11).Value = Me.cRUC
        cmdSQL.Parameters.Add("@cNomContrata", SqlDbType.VarChar, 150).Value = Me.cNomContrata
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario

        Return CInt(cmdSQL.ExecuteScalar())
    End Function
End Class
