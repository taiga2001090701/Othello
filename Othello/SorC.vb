Public Class SorC
    Public pm, ne, cu, ae As Byte

    Private Sub SorC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If pm = 2 Then
            GC1.Text = "Client"
            GC2.Hide()
            GC3.Hide()
        End If
        'SH.Enabled = False
    End Sub

    Private Sub CheckedChanged(sender As Object, e As EventArgs) Handles RS.CheckedChanged, RC.CheckedChanged
        If pm = 2 Then
            If RS.Checked = True Then
                'SH.Text = "localhost"
                'SH.Enabled = False
                'CH1.Enabled = True
            Else
                'SH.Enabled = True
                'CH1.Text = "localhost"
                'CH1.Enabled = False
            End If
        ElseIf pm = 4 Then
            If RS.Checked = True Then
                GC1.Text = "Client 1"
                GC2.Show()
                GC3.Show()
                SH.Text = "localhost"
                SH.Enabled = False
                CH1.Enabled = True
                SP.Text = "50001"
                CP1.Text = "50002"
                CP2.Text = "50003"
                CP3.Text = "50004"
            Else
                GC1.Text = "Client"
                GC2.Hide()
                GC3.Hide()
                SH.Enabled = True
                CH1.Text = "localhost"
                CH1.Enabled = False
                CP1.Text = ""
            End If
        End If
    End Sub

    Private Sub BS_Click(sender As Object, e As EventArgs) Handles BS.Click
        If SH.Text = Nothing Then
            MsgBox("ホスト名が空欄です")
            Exit Sub
        End If
        If SP.Text = Nothing Then
            MsgBox("ポート番号が空欄です")
            Exit Sub
        End If
        If CH1.Text = Nothing Then
            MsgBox("ホスト名が空欄です")
            Exit Sub
        End If
        If CP1.Text = Nothing Then
            MsgBox("ポート番号が空欄です")
            Exit Sub
        End If
        If Not IsNumeric(SP.Text) Then
            MsgBox("ポート番号には数字のみを入力してください")
            Exit Sub
        End If
        If Not IsNumeric(CP1.Text) Then
            MsgBox("ポート番号には数字のみを入力してください")
            Exit Sub
        End If
        If pm = 2 And cu = 1 Then
            If CInt(SP.Text) = 50011 Or CInt(SP.Text) = 50012 Then
                MsgBox("予約されたポート番号は使えません（50011/50012）")
                Exit Sub
            End If
            If CInt(CP1.Text) = 50011 Or CInt(CP1.Text) = 50012 Then
                MsgBox("予約されたポート番号は使えません（50011/50012）")
                Exit Sub
            End If
        End If
        If pm = 4 Then
            If CH2.Text = Nothing Then
                MsgBox("ホスト名が空欄です")
                Exit Sub
            End If
            If CP2.Text = Nothing Then
                MsgBox("ポート番号が空欄です")
                Exit Sub
            End If
            If CH3.Text = Nothing Then
                MsgBox("ホスト名が空欄です")
                Exit Sub
            End If
            If CP3.Text = Nothing Then
                MsgBox("ポート番号が空欄です")
                Exit Sub
            End If
            If Not IsNumeric(CP2.Text) Then
                MsgBox("ポート番号には数字のみを入力してください")
                Exit Sub
            End If
            If Not IsNumeric(CP3.Text) Then
                MsgBox("ポート番号には数字のみを入力してください")
                Exit Sub
            End If
            If cu = 1 Then
                If CInt(CP2.Text) = 50011 Or CInt(CP2.Text) = 50012 Or CInt(CP2.Text) = 50013 Or CInt(CP2.Text) = 50014 Then
                    MsgBox("予約されたポート番号は使えません（50011/50012/50013/50014）")
                    Exit Sub
                End If
                If CInt(CP3.Text) = 50011 Or CInt(CP3.Text) = 50012 Or CInt(CP3.Text) = 50013 Or CInt(CP3.Text) = 50014 Then
                    MsgBox("予約されたポート番号は使えません（50011/50012/50013/50014）")
                    Exit Sub
                End If
            End If
        End If
        Hide()
        Dim f As New Game
        f.pm = pm
        f.ne = ne
        f.cu = cu
        If RS.Checked = True Then
            f.sc = 0
        Else
            f.sc = 1
        End If
        If pm = 2 Then
            f.sh = SH.Text
            f.sp = CInt(SP.Text)
            f.ch = CH1.Text
            f.cp = CInt(CP1.Text)
        Else
            f.sh = SH.Text
            f.sp = CInt(SP.Text)
            f.ch = CH1.Text
            f.cp = CInt(CP1.Text)
            f.ch1 = CH1.Text
            f.cp1 = CInt(CP1.Text)
            f.ch2 = CH2.Text
            f.cp2 = CInt(CP2.Text)
            f.ch3 = CH3.Text
            f.cp3 = CInt(CP3.Text)
        End If
        f.ShowDialog(Me)
        f.Dispose()
        Show()
    End Sub
End Class