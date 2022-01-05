Class MainWindow
    Private Function CheckConstructionArea(o As Char, i As Integer)
        Dim e As Integer
        If (Short.TryParse(o, e)) Then
            If (e > 0 AndAlso e <= 9) Then
                Return True
            Else
                If (e = 0 AndAlso i = 1) Then 'Zero jest niedopuszczalne na początku, zwłaszcza w kontekście SWDR-a w TD2
                    Return True
                Else
                    Return False
                End If
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
        For Each el As Char In givenNumber
            If el = "0" Or el = "1" Or el = "2" Or el = "3" Or el = "4" Or el = "5" Or el = "6" Or el = "7" Or el = "8" Or el = "9" Then 'numer ma mieć tylko cyfry
                If givenNumber.Length < 4 Then 'najkrótszy numer poc. ma 4 cyfry
                    ValidationResult(False)
                    Return
                End If
                If givenNumber.Length <= 6 Then
                    For i = 0 To givenNumber.Length
                        If i <= 1 Then 'Sprawdzanie dwóch pierwszych cyfr (obszar konstrukcyjny)
                            res = CheckConstructionArea(givenNumber(i), i)
                            If res = False Then
                                ValidationResult(False)
                                Return
                            End If
                            If givenNumber(0) = "9" AndAlso givenNumber(1) = "9" Then 'Numer pociągu nie może zaczynać się na 99, rezerwa jest tylko jedna
                                ValidationResult(False)
                                Return
                            End If
                        Else
                            If givenNumber.Length = 4 Then
                                ValidationResult(True)
                                Return
                            ElseIf givenNumber.Length = 5 Then
                                If givenNumber.Substring(2) = "000" Then 'numery 5-cyfrowe o końcówkach 001-999 są poprawne, końcówka 000 jest błędna
                                    ValidationResult(False)
                                    Return
                                End If
                            ElseIf givenNumber.Length = 6 Then
                                If Integer.Parse(givenNumber.Substring(3)) > 899 Then 'Cyfry 4,5,6 dla numerów 6-cyfrowych z przedziału 900-999 stosuje się w przypadku konieczności zmiany numeru pociągu z uwagi na opóźnienie powyżej 24 h w celu uniknięcia dublowania się numerów pociągów.
                                    ValidationResult(False)
                                    Return
                                End If
                            End If
                        End If

                        If i = givenNumber.Length Then
                            ValidationResult(True)
                            Return
                        End If
                    Next
                Else
                    ValidationResult(False)
                    Return
                End If
            Else
                ValidationResult(False)
                Return
            End If
        Next
    End Sub
End Class
