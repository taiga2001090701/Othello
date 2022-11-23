Imports System.IO
Imports Scripting

Public Class Import
    Public fl As String
    Dim rfl As ULong
    Dim mf1, mf2 As String
    Dim mfa, rf As String
    Dim ic As ULong
    Dim ce As Byte
    Dim tb, tn As Date
    Dim tp, ta As TimeSpan
    Private Sub Import_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim srf As New StreamReader(fl, System.Text.Encoding.GetEncoding("shift_jis"))
        mf1 = srf.ReadLine
        mf2 = srf.ReadLine
        srf.Close()
        srf.Dispose()
        If Not mf1 = "AI Data by AIFO Format" Then
            MsgBox("選択されたファイルが適切なフォーマットで保存されていません")
            Close()
            Exit Sub
        ElseIf mf2 = "" Then
            MsgBox("選択されたファイルには有効な追加学習データが含まれていません")
            Close()
            Exit Sub
        End If
        Dim Fso As New FileSystemObject
        Dim FsoTS As TextStream
        FsoTS = Fso.OpenTextFile(fl, IOMode.ForAppending)
        rfl = FsoTS.Line - 2
        FsoTS.Close()
        FsoTS = Nothing
        Fso = Nothing
        PB.Maximum = rfl
        ce = 0
        TS.Start()
    End Sub

    Private Async Sub TS_Tick(sender As Object, e As EventArgs) Handles TS.Tick
        TS.Stop()
        ic = 0
        Dim srm As New StreamReader("AI\AI.aifo", System.Text.Encoding.GetEncoding("shift_jis"))
        mfa = srm.ReadLine
        mfa = Await srm.ReadToEndAsync
        srm.Close()
        srm.Dispose()
        Dim srr As New StreamReader(fl, System.Text.Encoding.GetEncoding("shift_jis"))
        Dim swm As New StreamWriter("AI\AI.aifo", True, System.Text.Encoding.GetEncoding("shift_jis"))
        rf = srr.ReadLine()
        tb = Date.Now
        For i As ULong = 1 To rfl
            rf = Await srr.ReadLineAsync
            If mfa.Contains(rf) = False And rf.Substring(0, 3) = "#34" Then
                swm.WriteLine(rf)
                ic += 1
            End If
            PB.Value = i
            tn = Date.Now
            tp = (tn - tb)
            ta = TimeSpan.FromTicks(tp.Ticks * (rfl - i) \ i)
            If rfl - i = 0 Then
                LE.Text = "Completed"
            Else
                LE.Text = "Estimated " & ta.Hours & ":" & ta.Minutes & ":" & ta.Seconds & ":" & ta.Milliseconds
            End If
        Next
        srr.Close()
        srr.Dispose()
        swm.Close()
        swm.Dispose()
        MsgBox(ic & "回分の学習データのインポート処理完了")
        ce = 1
        Close()
    End Sub

    Private Sub Import_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If ce = 0 Then
            e.Cancel = True
        End If
    End Sub
End Class