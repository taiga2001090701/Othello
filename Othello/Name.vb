Public Class Name
    Private Sub BO_Click(sender As Object, e As EventArgs) Handles BO.Click
        With LN.Text
            If .Contains("#") OrElse .Contains("?") OrElse .Contains("!") OrElse .Contains("$") OrElse .Contains("%") Then
                MsgBox("You cant use ""#"" ""?"" ""!"" ""$"" ""%"" for the name!")
            Else
                Close()
            End If
        End With
    End Sub
End Class