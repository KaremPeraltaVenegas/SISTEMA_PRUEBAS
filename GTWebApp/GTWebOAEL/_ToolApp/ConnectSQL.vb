'Imports System.Data.SqlClient
'Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Public Class ConnectSQL
    'Implements IDisposable

    Public Shared linkSQL As SqlConnection
    Public miTransact As SqlTransaction
    Public miCommand As SqlCommand
    Public PC As String = "localhost"
    Public BaseDatos As String
    Public Usuario As String
    Public Clave As String
    Public isConnect As Boolean
    'Public Sub New(ByVal tPC As String, ByVal tUsuario As String, ByVal tClave As String, ByVal tBaseDatos As String)
    '    Me.PC = tPC
    '    Me.Usuario = tUsuario
    '    Me.Clave = tClave
    '    Me.BaseDatos = tBaseDatos
    '    linkSQL = New SqlConnection()


    '    linkSQL.ConnectionString = "Server=" & Me.PC & ";" & _
    '                           ";Initial Catalog=" & Me.BaseDatos & _
    '                          ";User ID=" & Me.Usuario & _
    '                          ";Password=" & Me.Clave & ";MultipleActiveResultSets=True;"

    '    Try
    '        linkSQL.Open()
    '        Me.isConnect = True
    '    Catch mierror As SqlException
    '        Me.isConnect = False
    '        'MsgBox(mierror.Message)
    '    Finally
    '        'con.Dispose()
    '    End Try
    'End Sub
    Public Sub New()

    End Sub
    Public Function OpenConnection() As String
        linkSQL = New SqlConnection()
        'new 10.56.67.4
        'old 10.137.196.156
        Me.PC = "10.56.67.4"
         Me.Usuario = "APPQUELLAVECO"
        Me.Clave = "Gelbert2019."
        Me.BaseDatos = "GTManpowerLocal"

        'Me.PC = "."
        'Me.Usuario = "sa"
        'Me.Clave = "abc123*"
        'Me.BaseDatos = "GTManpowerLocalMLB"


        linkSQL.ConnectionString = "Server=" & Me.PC & ";" &
                               ";Initial Catalog=" & Me.BaseDatos &
                              ";User ID=" & Me.Usuario &
                              ";Password=" & Me.Clave & ";MultipleActiveResultSets=True;"
        'linkSQL.ConnectionString = "data source=DESKTOP-5TLNCQM;initial catalog=GTManpowerLocal;Integrated Security=True;MultipleActiveResultSets=True;"

     


        Try
            If linkSQL.State = ConnectionState.Open Then 'si la conexion esta abierta
                linkSQL.Close()
            End If
            linkSQL.Open()
            Return "OK"
        Catch mierror As SqlException
            Return mierror.Message

        Finally

        End Try
    End Function
    Public Sub CloseConnection()

         Try
            'If linkSQL Is Nothing Then
            '    Exit Try
            'End If

            If linkSQL.State = ConnectionState.Open Then 'si la conexion esta abierta
                linkSQL.Close()
            End If

            linkSQL.Dispose()
        Catch mierror As SqlException

        Finally

        End Try
    End Sub
    Public Function ExecuteReader(ByVal cQuery As String) As IDataReader
        Try
            Dim cmd As New SqlCommand(cQuery, linkSQL)
            Dim readers As SqlDataReader
            readers = cmd.ExecuteReader()
            Return readers
        Catch ex As Exception
            Throw ex
            'MsgBox("Error Ocurrido :" & vbCrLf & ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Public Function ExecuteQuery(ByVal cQuery As String) As Boolean
        Try
            Dim cmd As New SqlCommand(cQuery, linkSQL)
            cmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            'Throw ex
            'MsgBox("Error Ocurrido :" & vbCrLf & ex.Message, MsgBoxStyle.Exclamation)
            Return False
        End Try
    End Function
    Public Function ExecuteGetRecord(ByVal cQuery As String) As IDataReader
        Try
            Dim cmd As New SqlCommand(cQuery, linkSQL)
            Dim readers As SqlDataReader
            readers = cmd.ExecuteReader(CommandBehavior.SingleRow)
            Return readers
        Catch ex As Exception
            Throw ex
            'MsgBox("Error Ocurrido :" & vbCrLf & ex.Message, MsgBoxStyle.Exclamation)
            'Exit Try
        End Try
    End Function
    Public Function ExecuteDataTable(ByVal cQuery As String) As DataTable
        Try
            Dim cmd As New SqlCommand(cQuery, linkSQL)
            Dim readers As SqlDataReader
            readers = cmd.ExecuteReader()
            Dim dt As New DataTable
            dt.Load(readers)
            Return dt
        Catch ex As Exception
            Throw ex
            'MsgBox("Error Ocurrido :" & vbCrLf & ex.Message, MsgBoxStyle.Exclamation)

        End Try
    End Function
    Public Function ExecuteDataSet(ByVal cQuery As String) As DataSet
        Try
            Dim cmd As New SqlCommand(cQuery, linkSQL)
            Return cmd.ExecuteScalar(cQuery)
        Catch ex As Exception
            Throw ex
            'MsgBox("Error Ocurrido :" & vbCrLf & ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Public Function ExecuteScalar(ByVal cQuery As String) As Integer
        Try
            Dim cmd As New SqlCommand(cQuery, linkSQL)
            Return (CInt(cmd.ExecuteScalar()))
        Catch ex As Exception
            Throw ex
            'MsgBox("Error Ocurrido :" & vbCrLf & ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Public Function ExecuteQueryTransact(ByVal cQuery As String) As Boolean
        Try
            Dim cmd As New SqlCommand(cQuery, linkSQL, miTransact)
            cmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ExecuteGetRecordTransact(ByVal cQuery As String) As IDataReader
        Try
            Dim cmd As New SqlCommand(cQuery, linkSQL, miTransact)
            Dim readers As SqlDataReader
            readers = cmd.ExecuteReader(CommandBehavior.SingleRow)
            Return readers
        Catch ex As Exception
            Throw ex
            'MsgBox("Error Ocurrido :" & vbCrLf & ex.Message, MsgBoxStyle.Exclamation)
            'Exit Try
        End Try
    End Function
    Public Function ExecuteScalarTransact(ByVal cQuery As String) As Integer
        Try
            Dim cmd As New SqlCommand(cQuery, linkSQL, miTransact)
            Return (CInt(cmd.ExecuteScalar()))
        Catch ex As Exception
            Throw ex
            'MsgBox("Error Ocurrido :" & vbCrLf & ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Public Function ExecuteReaderTransact(ByVal cQuery As String) As IDataReader
        Try
            Dim cmd As New SqlCommand(cQuery, linkSQL, miTransact)
            Dim readers As SqlDataReader
            readers = cmd.ExecuteReader()
            Return readers
        Catch ex As Exception
            Throw ex
            'MsgBox("Error Ocurrido :" & vbCrLf & ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Public Function ExecuteDataTableTransact(ByVal cQuery As String) As DataTable
        Try
            Dim cmd As New SqlCommand(cQuery, linkSQL, miTransact)
            Dim readers As SqlDataReader
            readers = cmd.ExecuteReader()
            Dim dt As New DataTable
            dt.Load(readers)
            Return dt
        Catch ex As Exception
            Throw ex
            'MsgBox("Error Ocurrido :" & vbCrLf & ex.Message, MsgBoxStyle.Exclamation)

        End Try
    End Function
    Public Function ExecuteGetRecordCommand() As IDataReader
        Try
            'Dim cmd As New SqlCommand()
            'cmd.Connection = linkSQL

            'miCommand.Connection = linkSQL
            Dim readers As SqlDataReader
            readers = miCommand.ExecuteReader(CommandBehavior.SingleRow)
            Return readers
        Catch ex As Exception
            Throw ex
            'MsgBox("Error Ocurrido :" & vbCrLf & ex.Message, MsgBoxStyle.Exclamation)
            'Exit Try
        End Try
    End Function
    Public Function ExecuteQueryGetRows(ByVal cQuery As String) As Integer
        Try
            Dim cmd As New SqlCommand(cQuery, linkSQL)
            Return CInt(cmd.ExecuteNonQuery())
            Return True
        Catch ex As Exception
            'Throw ex
            'MsgBox("Error Ocurrido :" & vbCrLf & ex.Message, MsgBoxStyle.Exclamation)
            Return -1
        End Try
    End Function
End Class


