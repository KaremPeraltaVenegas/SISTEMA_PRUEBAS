Public Class FechaDiferencia
    Private monthDay As Integer() = New Integer(11) {31, -1, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31}
    Private fromDate As DateTime
    Private toDate As DateTime
    Private year As Integer
    Private month As Integer
    Private day As Integer

    Public Sub New(ByVal d1 As DateTime, ByVal d2 As DateTime)
        Dim increment As Integer

        If d1 > d2 Then
            Me.fromDate = d2
            Me.toDate = d1
        Else
            Me.fromDate = d1
            Me.toDate = d2
        End If

        increment = 0

        If Me.fromDate.Day > Me.toDate.Day Then
            increment = Me.monthDay(Me.fromDate.Month - 1)
        End If

        If increment = -1 Then

            If DateTime.IsLeapYear(Me.fromDate.Year) Then
                increment = 29
            Else
                increment = 28
            End If
        End If

        If increment <> 0 Then
            day = (Me.toDate.Day + increment) - Me.fromDate.Day
            increment = 1
        Else
            day = Me.toDate.Day - Me.fromDate.Day
        End If

        If (Me.fromDate.Month + increment) > Me.toDate.Month Then
            Me.month = (Me.toDate.Month + 12) - (Me.fromDate.Month + increment)
            increment = 1
        Else
            Me.month = (Me.toDate.Month) - (Me.fromDate.Month + increment)
            increment = 0
        End If

        Me.year = Me.toDate.Year - (Me.fromDate.Year + increment)
    End Sub

    Public Overrides Function ToString() As String
        Return Me.year & " Año(s), " & Me.month & " mes(es), " & Me.day & " día(s)"
    End Function

    Public ReadOnly Property Years As Integer
        Get
            Return Me.year
        End Get
    End Property

    Public ReadOnly Property Months As Integer
        Get
            Return Me.month
        End Get
    End Property

    Public ReadOnly Property Days As Integer
        Get
            Return Me.day
        End Get
    End Property
End Class

