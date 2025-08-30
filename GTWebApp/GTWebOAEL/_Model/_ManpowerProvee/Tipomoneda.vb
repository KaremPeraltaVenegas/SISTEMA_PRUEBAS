Imports System.Data.SqlClient
Public Class Tipomoneda
Public iCodTipoMoneda As String
Public cCodigoSunat As String
Public cDesMoneda As String
Public cNomMoneda As String
Public cPais As String
Public qSelect As String
Public cTipoOpe as Char
Public bTransaccion as Boolean=False
Public mc as New ConnectSQL
 Public Function ListaDatos() As DataTable
	Dim Query As String
	Dim readers As DataTable
	Query = "SELECT * FROM prov.TipoMoneda"
	readers = mc.ExecuteDataTable(Query)
	Return readers
End Function
 Public Sub Insertar()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.CommandText ="INSERT into prov.TipoMoneda (cCodigoSunat,cDesMoneda,cNomMoneda,cPais ) VALUES(@cCodigoSunat,@cDesMoneda,@cNomMoneda,@cPais); SELECT SCOPE_IDENTITY(); "
	cmdSQL.Parameters.Add("@cCodigoSunat", SqlDbType.Varchar,5).Value = Me.cCodigoSunat
	cmdSQL.Parameters.Add("@cDesMoneda", SqlDbType.Varchar,20).Value = Me.cDesMoneda
	cmdSQL.Parameters.Add("@cNomMoneda", SqlDbType.Varchar,50).Value = Me.cNomMoneda
	cmdSQL.Parameters.Add("@cPais", SqlDbType.Varchar,35).Value = Me.cPais

	Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
	If pCodInsert > 0 Then
		Me.iCodTipoMoneda=pCodInsert
	Else
		Me.iCodTipoMoneda=0
	End If
End Sub
 Public Sub InsertarTransact()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.Transaction = Me.mc.miTransact 
	cmdSQL.CommandText ="INSERT into prov.TipoMoneda (cCodigoSunat,cDesMoneda,cNomMoneda,cPais ) VALUES(@cCodigoSunat,@cDesMoneda,@cNomMoneda,@cPais); SELECT SCOPE_IDENTITY(); "
	cmdSQL.Parameters.Add("@cCodigoSunat", SqlDbType.Varchar,5).Value = Me.cCodigoSunat
	cmdSQL.Parameters.Add("@cDesMoneda", SqlDbType.Varchar,20).Value = Me.cDesMoneda
	cmdSQL.Parameters.Add("@cNomMoneda", SqlDbType.Varchar,50).Value = Me.cNomMoneda
	cmdSQL.Parameters.Add("@cPais", SqlDbType.Varchar,35).Value = Me.cPais

	Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
	If pCodInsert > 0 Then
		Me.iCodTipoMoneda=pCodInsert
	Else
		Me.iCodTipoMoneda=0
	End If
End Sub
 Public Sub Modificar()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.CommandText = "UPDATE  prov.TipoMoneda SET cCodigoSunat=@cCodigoSunat,cDesMoneda=@cDesMoneda,cNomMoneda=@cNomMoneda,cPais=@cPais WHERE iCodTipoMoneda=@iCodTipoMoneda"
	cmdSQL.Parameters.Add("@iCodTipoMoneda", SqlDbType.Tinyint).Value = Me.iCodTipoMoneda
	cmdSQL.Parameters.Add("@cCodigoSunat", SqlDbType.Varchar,5).Value = Me.cCodigoSunat
	cmdSQL.Parameters.Add("@cDesMoneda", SqlDbType.Varchar,20).Value = Me.cDesMoneda
	cmdSQL.Parameters.Add("@cNomMoneda", SqlDbType.Varchar,50).Value = Me.cNomMoneda
	cmdSQL.Parameters.Add("@cPais", SqlDbType.Varchar,35).Value = Me.cPais

	cmdSQL.ExecuteNonQuery()
End Sub
 Public Sub ModificarTransact()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.Transaction = Me.mc.miTransact 
	cmdSQL.CommandText = "UPDATE  prov.TipoMoneda SET cCodigoSunat=@cCodigoSunat,cDesMoneda=@cDesMoneda,cNomMoneda=@cNomMoneda,cPais=@cPais WHERE iCodTipoMoneda=@iCodTipoMoneda"
	cmdSQL.Parameters.Add("@iCodTipoMoneda", SqlDbType.Tinyint).Value = Me.iCodTipoMoneda
	cmdSQL.Parameters.Add("@cCodigoSunat", SqlDbType.Varchar,5).Value = Me.cCodigoSunat
	cmdSQL.Parameters.Add("@cDesMoneda", SqlDbType.Varchar,20).Value = Me.cDesMoneda
	cmdSQL.Parameters.Add("@cNomMoneda", SqlDbType.Varchar,50).Value = Me.cNomMoneda
	cmdSQL.Parameters.Add("@cPais", SqlDbType.Varchar,35).Value = Me.cPais

	cmdSQL.ExecuteNonQuery()
End Sub
 Public Sub Eliminar()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.CommandText = "DELETE from  prov.TipoMoneda  WHERE iCodTipoMoneda=@iCodTipoMoneda"
'cmdSQL.CommandText = "UPDATE prov.TipoMoneda  SET bAnulado=1 WHERE  iCodTipoMoneda=@iCodTipoMoneda"
cmdSQL.Parameters.Add("@iCodTipoMoneda", SqlDbType.Tinyint).Value = Me.iCodTipoMoneda
	cmdSQL.ExecuteNonQuery()
End Sub
 Public Sub EliminarTransact()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.Transaction = Me.mc.miTransact 
	cmdSQL.CommandText = "DELETE from  prov.TipoMoneda  WHERE iCodTipoMoneda=@iCodTipoMoneda"
'cmdSQL.CommandText = "UPDATE prov.TipoMoneda  SET bAnulado=1 WHERE  iCodTipoMoneda=@iCodTipoMoneda"
cmdSQL.Parameters.Add("@iCodTipoMoneda", SqlDbType.Tinyint).Value = Me.iCodTipoMoneda
	cmdSQL.ExecuteNonQuery()
End Sub
Public Sub getRecord()
	Dim readers As IDataReader
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	
	If bTransaccion=True Then cmdSQL.Transaction = Me.mc.miTransact Else 

	cmdSQL.CommandText = "SELECT * FROM prov.TipoMoneda WHERE iCodTipoMoneda=@iCodTipoMoneda"
	cmdSQL.Parameters.Add("@iCodTipoMoneda", SqlDbType.Tinyint).Value = Me.iCodTipoMoneda
	readers = cmdSQL.ExecuteReader
	If readers.Read() Then
		Me.iCodTipoMoneda = CStr(readers.GetValue(0))
		Me.cCodigoSunat = CStr(readers.GetValue(1))
		Me.cDesMoneda = CStr(readers.GetValue(2))
		Me.cNomMoneda = CStr(readers.GetValue(3))
		Me.cPais = CStr(readers.GetValue(4))
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
	cmdSQL.CommandText = "SELECT * FROM prov.TipoMoneda"
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
    '*********************************************************

    Public Function ListaTipoMoneda() As DataTable
        Dim miDataTable As New DataTable
        Dim readers As IDataReader
        miDataTable.Columns.Add("ValueMember")
        miDataTable.Columns.Add("DisplayMember")
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "SELECT * FROM prov.TipoMoneda"
        readers = cmdSQL.ExecuteReader
        While readers.Read()
            miDataTable.Rows.Add(CStr(readers.GetValue(0)), CStr(readers.GetValue(2)))
        End While
        readers.Close()
        Return miDataTable
    End Function
End Class
