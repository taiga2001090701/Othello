Public Class Main
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub B2_Click(sender As Object, e As EventArgs) Handles B2.Click
        Hide()
        Dim f As New Game
        f.pm = 2
        f.ne = 0
        f.cu = 0
        f.ae = 0
        f.ShowDialog(Me)
        f.Dispose()
        Show()
    End Sub

    Private Sub B4_Click(sender As Object, e As EventArgs) Handles B4.Click
        Hide()
        Dim f As New Game
        f.pm = 4
        f.ne = 0
        f.cu = 0
        f.ae = 0
        f.ShowDialog(Me)
        f.Dispose()
        Show()
    End Sub

    Private Sub B2N_Click(sender As Object, e As EventArgs) Handles B2N.Click
        Hide()
        Dim f As New SorC
        f.pm = 2
        f.ne = 1
        f.cu = 0
        f.ae = 0
        f.ShowDialog(Me)
        f.Dispose()
        Show()
    End Sub

    Private Sub B4N_Click(sender As Object, e As EventArgs) Handles B4N.Click
        Hide()
        Dim f As New SorC
        f.pm = 4
        f.ne = 1
        f.cu = 0
        f.ae = 0
        f.ShowDialog(Me)
        f.Dispose()
        Show()
    End Sub

    Private Sub B2NC_Click(sender As Object, e As EventArgs) Handles B2NC.Click
        Hide()
        Dim f As New SorC
        f.pm = 2
        f.ne = 1
        f.cu = 1
        f.ae = 0
        f.ShowDialog(Me)
        f.Dispose()
        Show()
    End Sub

    Private Sub B4NC_Click(sender As Object, e As EventArgs) Handles B4NC.Click
        Hide()
        Dim f As New SorC
        f.pm = 4
        f.ne = 1
        f.cu = 1
        f.ae = 0
        f.ShowDialog(Me)
        f.Dispose()
        Show()
    End Sub

    Private Sub BAS_Click(sender As Object, e As EventArgs) Handles BAS.Click
        Hide()
        Dim f As New Study
        f.ShowDialog(Me)
        f.Dispose()
        Show()
    End Sub

    Private Sub BAE_Click(sender As Object, e As EventArgs) Handles BAE.Click
        Hide()
        Dim f As New Setting
        f.ShowDialog(Me)
        f.Dispose()
        Show()
    End Sub

    Private Sub BAF_Click(sender As Object, e As EventArgs) Handles BAF.Click
        Hide()
        Dim f As New Game
        f.pm = 2
        f.ne = 0
        f.cu = 0
        f.ae = 1
        f.afl = 1
        f.ShowDialog(Me)
        f.Dispose()
        Show()
    End Sub

    Private Sub BAL_Click(sender As Object, e As EventArgs) Handles BAL.Click
        Hide()
        Dim f As New Game
        f.pm = 2
        f.ne = 0
        f.cu = 0
        f.ae = 1
        f.afl = 2
        f.ShowDialog(Me)
        f.Dispose()
        Show()
    End Sub

    Private Sub BH2_Click(sender As Object, e As EventArgs) Handles BH2.Click
        Hide()
        Dim f As New History
        f.pm = 2
        f.ShowDialog(Me)
        f.Dispose()
        Show()
    End Sub

    Private Sub BH4_Click(sender As Object, e As EventArgs) Handles BH4.Click
        Hide()
        Dim f As New History
        f.pm = 4
        f.ShowDialog(Me)
        f.Dispose()
        Show()
    End Sub
End Class