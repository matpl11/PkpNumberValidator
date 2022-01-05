Class MainWindow
    Private Function CheckConstructionArea(o As Char)
        Dim e As Integer
        If (Short.TryParse(o, e)) Then
            If (e > 0 AndAlso e <= 9) Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function
    Private Sub ValidationResult(a As Boolean)
        If a = True Then
            validationResultBox.Content = "Numer prawidłowy"
        Else
            validationResultBox.Content = "Numer nieprawidłowy"
        End If
    End Sub
    Private Sub ClickOnValidate(sender As Object, e As RoutedEventArgs)
        Dim givenNumber As String
        Dim res As Boolean

        givenNumber = numberBox.Text
        If givenNumber.Length <= 6 Then
            For i = 0 To givenNumber.Length
                If i = 0 Then
                    res = CheckConstructionArea(givenNumber(i))
                    If res = False Then
                        ValidationResult(False)
                        Return
                    End If
                End If
                If i = 1 Then

                End If
                If i = givenNumber.Length Then
                    ValidationResult(True)
                End If
            Next
        Else
            ValidationResult(False)
        End If

    End Sub
End Class
