Imports System.Drawing

Public Class RptCandidatoFichaPostulante

    Private Sub Detail_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles Detail.BeforePrint
        On Error Resume Next
        Dim dFechaIni As Date = CDate(GetCurrentColumnValue("dFechaIni"))
        Dim dFechaFin As Date = CDate(GetCurrentColumnValue("dFechaFin"))
        Dim CRecordFecha As New FechaDiferencia(dFechaIni, dFechaFin)
        cTiempoExperiencia.Text = CRecordFecha.ToString()
    End Sub



    Sub SetTextoDescripcionCompetencia()
        Dim pAptitud = CStr(GetCurrentColumnValue("cAptitud"))

        If pAptitud = "SIN DATOS" Then
            cValueNivel.Text = "--"
            'LblAptitud.ForeColor = Color.FromArgb(192, 0, 0)
        ElseIf pAptitud = "APTO" Then
            cValueNivel.Text = "ALTA"
            cValueNivel.ForeColor = Color.Green
        ElseIf pAptitud = "APTO CAPACITABLE" Then
            cValueNivel.Text = "MEDIA"
            cValueNivel.ForeColor = Color.Orange
        ElseIf pAptitud = "NO APTO" Then
            cValueNivel.Text = "BAJA"
            cValueNivel.ForeColor = Color.FromArgb(192, 0, 0)
        End If



        Dim pSecurity = CInt(GetCurrentColumnValue("iResultadoVerificativa"))

        If pSecurity = 0 Then
            cValueCompatibilidad.Text = "--"
            'LblLaboral.ForeColor = Color.FromArgb(192, 0, 0)
        ElseIf pSecurity = 1 Then
            cValueCompatibilidad.Text = "ALTA"
            cValueCompatibilidad.ForeColor = Color.Green
        ElseIf pSecurity = 2 Then
            cValueCompatibilidad.Text = "MEDIA"
            cValueCompatibilidad.ForeColor = Color.Orange
        ElseIf pSecurity = 3 Then
            cValueCompatibilidad.Text = "BAJA"
            cValueCompatibilidad.ForeColor = Color.FromArgb(192, 0, 0)
        End If
    End Sub

    Private Sub RptCandidatoFichaPostulante_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles Me.BeforePrint
        SetTextoDescripcionCompetencia()
    End Sub
End Class