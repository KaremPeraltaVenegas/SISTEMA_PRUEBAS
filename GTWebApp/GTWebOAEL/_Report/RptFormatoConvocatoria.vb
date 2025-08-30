Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraRichEdit.Model

Public Class RptFormatoConvocatoria

    Private Sub CellPerfil_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CellPerfil.BeforePrint

        'Dim cp As CharacterProperties = doc.BeginUpdateCharacters(range)
        'cp.FontName = "Comic Sans MS"
        'cp.FontSize = 18
        'cp.ForeColor = Color.Yellow
        'cp.BackColor = Color.Blue
        'cp.Underline = UnderlineType.DoubleWave
        'cp.UnderlineColor = Color.White


        Dim cell As XRTableCell = CType(sender, XRTableCell)
        Dim tag As String = cell.Tag.ToString()
        Dim currentText As String = cell.Text

       

        If tag = "TagPerfil" Then
            cell.Controls.Clear()
            cell.Controls.Add(New XRRichText() With {.WidthF = 720,
            .Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)),
            .Html = currentText
            })
            'cell.Visible = False
        End If
    End Sub
End Class