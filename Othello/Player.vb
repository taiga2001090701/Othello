Imports System.Drawing

Public Class Player
    Public pm As Byte
    Private Sub Player_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If pm = 2 Then
            L1.Show()
            L2.Show()
            L3.Hide()
            L4.Hide()
            L1.ForeColor = Color.Black
            L2.ForeColor = Color.White
            L1.Text = "Player Black 2"
            L2.Text = "Player White 2"
        ElseIf pm = 4 Then
            L1.Show()
            L2.Show()
            L3.Show()
            L4.Show()
            L1.ForeColor = Color.Red
            L2.ForeColor = Color.SkyBlue
            L3.ForeColor = Color.Orange
            L4.ForeColor = Color.LawnGreen
            L1.Text = "Player Red 2"
            L2.Text = "Player Blue 2"
            L3.Text = "Player Yellow 2"
            L4.Text = "Player Green 2"
        End If
    End Sub

    Private Sub Player_Closing(ByVal sender As Object, ByVal e As ComponentModel.CancelEventArgs) Handles MyBase.Closing
        e.Cancel = True
    End Sub
End Class