Public Class RptFormatoA5

    Private Sub RptFormatoA5_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint
        Me.DisplayName = ExtraerCadena(GetCurrentColumnValue("cNroContrato").ToString(), 20) & " " & _
            ExtraerCadena(Trim(GetCurrentColumnValue("cNomCorto").ToString()), 30) & " - " & _
            "RDP ANEXO 5 N° " & GetCurrentColumnValue("cCorrelativo")
    End Sub
    Public Function ExtraerCadena(ByVal miCadena As String, ByVal iCaracteres As Integer) As String
        ExtraerCadena = ""
        Dim iLongCadena As Integer = miCadena.Length()

        If iLongCadena <= iCaracteres Then
            iCaracteres = iLongCadena
        End If

        ExtraerCadena = Mid(miCadena, 1, iCaracteres)
        '\/:*?”<>|
        ExtraerCadena = ExtraerCadena.Replace("\", "")
        ExtraerCadena = ExtraerCadena.Replace("/", "")
        ExtraerCadena = ExtraerCadena.Replace(":", "")
        ExtraerCadena = ExtraerCadena.Replace("*", "")
        ExtraerCadena = ExtraerCadena.Replace("?", "")
        ExtraerCadena = ExtraerCadena.Replace("""", "")
        ExtraerCadena = ExtraerCadena.Replace("<", "")
        ExtraerCadena = ExtraerCadena.Replace(">", "")
        ExtraerCadena = ExtraerCadena.Replace("|", "")
        Return ExtraerCadena
    End Function
End Class