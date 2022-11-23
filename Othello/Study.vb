Imports System.IO
Imports Scripting

Public Class Study
    Dim pt As Byte
    Dim a, b As Byte
    Dim cb, cx, gec As Byte
    Dim p1, p2 As Byte
    Dim fp, tp As String
    Dim pn, pnm As ULong
    Dim bd(88) As Integer
    Dim wtp(1), ain, eon, aig, aif As Byte
    Dim a1, a2 As Byte
    Dim gr, aip, aid, ait, aie As String
    Dim aidl As ULong
    Dim rdm As New Random(Date.Now.Second)

    Private Sub Study_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BE.Enabled = False
        Directory.CreateDirectory("AI\")
        If Not IO.File.Exists("AI\AI.aifo") Then
            Dim sw As New StreamWriter("AI\AI.aifo", True, System.Text.Encoding.GetEncoding("shift_jis"))
            sw.WriteLine("AI Data by AIFO Format")
            sw.Close()
            sw.Dispose()
        End If
        If Not IO.File.Exists("AI\Setting.aifo") Then
            Dim sw As New StreamWriter("AI\Setting.aifo", False, System.Text.Encoding.GetEncoding("shift_jis"))
            sw.WriteLine("1")
            sw.WriteLine("1")
            sw.Close()
            sw.Dispose()
        End If
        Dim sr As New StreamReader("AI\Setting.aifo", System.Text.Encoding.GetEncoding("shift_jis"))
        a1 = CByte(sr.ReadLine)
        a2 = CByte(sr.ReadLine)
        sr.Close()
        sr.Dispose()
        Dim Fso As New FileSystemObject
        Dim FsoTS As TextStream
        FsoTS = Fso.OpenTextFile("AI\AI.aifo", IOMode.ForAppending)
        aidl = FsoTS.Line - 1
        FsoTS.Close()
        FsoTS = Nothing
        Fso = Nothing
        If aidl - 1 <= 1 Then
            LTP.Text = "Total " & aidl - 1 & " Pattern"
        Else
            LTP.Text = "Total " & aidl - 1 & " Patterns"
        End If
        aig = 0
    End Sub

    Private Sub BS_Click(sender As Object, e As EventArgs) Handles BS.Click
        BS.Enabled = False
        BE.Enabled = True
        TPC.Enabled = False
        If Not IsNumeric(TPC.Text) Then
            MsgBox("実行回数を数値で指定してください")
            Exit Sub
        End If
        pn = 0
        pnm = CInt(TPC.Text)
        aig = 1
        aif = 0
        Reload()
    End Sub

    Private Sub BE_Click(sender As Object, e As EventArgs) Handles BE.Click
        aif = 1
    End Sub

    Sub Reload()
        If pn <= 1 Then
            LPC.Text = pn & " Pattern Finished"
        Else
            LPC.Text = pn & " Patterns Finished"
        End If
        If aif = 1 Then
            MsgBox("学習が中断されました" & vbCrLf & "（" & pn & " 回分完了）")
            If aidl <= 1 Then
                LTP.Text = "Total " & aidl & " Pattern"
            Else
                LTP.Text = "Total " & aidl & " Patterns"
            End If
            BS.Enabled = True
            BE.Enabled = False
            TPC.Enabled = True
            aig = 0
            Exit Sub
        ElseIf pn = pnm And pn > 0 Then
            MsgBox("指定回数分（" & pnm & " 回分）の学習が完了しました")
            If aidl <= 1 Then
                LTP.Text = "Total " & aidl & " Pattern"
            Else
                LTP.Text = "Total " & aidl & " Patterns"
            End If
            BS.Enabled = True
            BE.Enabled = False
            TPC.Enabled = True
            aig = 0
            Exit Sub
        End If
        p1 = 2
        p2 = 2
        For i = 0 To 88
            bd(i) = 0
        Next
        bd(44) = 2
        bd(45) = 1
        bd(54) = 1
        bd(55) = 2
        pt = 1
        gec = 0
        EC()
        Dim Fso As New FileSystemObject
        Dim FsoTS As TextStream
        FsoTS = Fso.OpenTextFile("AI\AI.aifo", IOMode.ForAppending)
        aidl = FsoTS.Line - 1
        FsoTS.Close()
        FsoTS = Nothing
        Fso = Nothing
        Dim sr As New StreamReader("AI\AI.aifo", System.Text.Encoding.GetEncoding("shift_jis"))
        aid = sr.ReadToEnd
        sr.Close()
        sr.Dispose()
        ain = 0
        aip = "#"
        rdm = New Random(Date.Now.Second)
        TAS.Start()
    End Sub

    Private Sub TAS_Tick(sender As Object, e As EventArgs) Handles TAS.Tick
        TAS.Stop()
        AI()
        Reload()
    End Sub

    Sub PP(bt As Integer)
        a = CByte(bt.ToString.Substring(0, 1))
        b = CByte(bt.ToString.Substring(1, 1))
        If bd(bt) = 3 Then
            cb = 0
            'Right
            For i = 1 To 7
                If b + i > 8 Then
                    Exit For
                Else
                    If bd(a * 10 + b + i) = 0 Or bd(a * 10 + b + i) = 3 Then
                        Exit For
                    End If
                    If pt = 1 Then
                        If bd(a * 10 + b + i) = 1 Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    bd(a * 10 + b + n) = 1
                                Next
                                p1 += i - 1
                                p2 -= i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    ElseIf pt = 2 Then
                        If bd(a * 10 + b + i) = 2 Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    bd(a * 10 + b + n) = 2
                                Next
                                p1 -= i - 1
                                p2 += i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    End If
                End If
            Next
            'Down
            For i = 1 To 7
                If a + i > 8 Then
                    Exit For
                Else
                    If bd((a + i) * 10 + b) = 0 Or bd((a + i) * 10 + b) = 3 Then
                        Exit For
                    End If
                    If pt = 1 Then
                        If bd((a + i) * 10 + b) = 1 Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    bd((a + n) * 10 + b) = 1
                                Next
                                p1 += i - 1
                                p2 -= i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    ElseIf pt = 2 Then
                        If bd((a + i) * 10 + b) = 2 Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    bd((a + n) * 10 + b) = 2
                                Next
                                p1 -= i - 1
                                p2 += i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    End If
                End If
            Next
            'Left
            For i = 1 To 7
                If b - i < 1 Then
                    Exit For
                Else
                    If bd(a * 10 + b - i) = 0 Or bd(a * 10 + b - i) = 3 Then
                        Exit For
                    End If
                    If pt = 1 Then
                        If bd(a * 10 + b - i) = 1 Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    bd(a * 10 + b - n) = 1
                                Next
                                p1 += i - 1
                                p2 -= i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    ElseIf pt = 2 Then
                        If bd(a * 10 + b - i) = 2 Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    bd(a * 10 + b - n) = 2
                                Next
                                p1 -= i - 1
                                p2 += i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    End If
                End If
            Next
            'Up
            For i = 1 To 7
                If a - i < 1 Then
                    Exit For
                Else
                    If bd((a - i) * 10 + b) = 0 Or bd((a - i) * 10 + b) = 3 Then
                        Exit For
                    End If
                    If pt = 1 Then
                        If bd((a - i) * 10 + b) = 1 Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    bd((a - n) * 10 + b) = 1
                                Next
                                p1 += i - 1
                                p2 -= i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    ElseIf pt = 2 Then
                        If bd((a - i) * 10 + b) = 2 Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    bd((a - n) * 10 + b) = 2
                                Next
                                p1 -= i - 1
                                p2 += i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    End If
                End If
            Next
            'Right and Down
            For i = 1 To 7
                If a + i > 8 Or b + i > 8 Then
                    Exit For
                Else
                    If bd((a + i) * 10 + b + i) = 0 Or bd((a + i) * 10 + b + i) = 3 Then
                        Exit For
                    End If
                    If pt = 1 Then
                        If bd((a + i) * 10 + b + i) = 1 Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    bd((a + n) * 10 + b + n) = 1
                                Next
                                p1 += i - 1
                                p2 -= i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    ElseIf pt = 2 Then
                        If bd((a + i) * 10 + b + i) = 2 Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    bd((a + n) * 10 + b + n) = 2
                                Next
                                p1 -= i - 1
                                p2 += i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    End If
                End If
            Next
            'Left and Down
            For i = 1 To 7
                If a + i > 8 Or b - i < 1 Then
                    Exit For
                Else
                    If bd((a + i) * 10 + b - i) = 0 Or bd((a + i) * 10 + b - i) = 3 Then
                        Exit For
                    End If
                    If pt = 1 Then
                        If bd((a + i) * 10 + b - i) = 1 Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    bd((a + n) * 10 + b - n) = 1
                                Next
                                p1 += i - 1
                                p2 -= i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    ElseIf pt = 2 Then
                        If bd((a + i) * 10 + b - i) = 2 Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    bd((a + n) * 10 + b - n) = 2
                                Next
                                p1 -= i - 1
                                p2 += i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    End If
                End If
            Next
            'Left and Up
            For i = 1 To 7
                If a - i < 1 Or b - i < 1 Then
                    Exit For
                Else
                    If bd((a - i) * 10 + b - i) = 0 Or bd((a - i) * 10 + b - i) = 3 Then
                        Exit For
                    End If
                    If pt = 1 Then
                        If bd((a - i) * 10 + b - i) = 1 Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    bd((a - n) * 10 + b - n) = 1
                                Next
                                p1 += i - 1
                                p2 -= i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    ElseIf pt = 2 Then
                        If bd((a - i) * 10 + b - i) = 2 Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    bd((a - n) * 10 + b - n) = 2
                                Next
                                p1 -= i - 1
                                p2 += i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    End If
                End If
            Next
            'Right and Up
            For i = 1 To 7
                If a - i < 1 Or b + i > 8 Then
                    Exit For
                Else
                    If bd((a - i) * 10 + b + i) = 0 Or bd((a - i) * 10 + b + i) = 3 Then
                        Exit For
                    End If
                    If pt = 1 Then
                        If bd((a - i) * 10 + b + i) = 1 Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    bd((a - n) * 10 + b + n) = 1
                                Next
                                p1 += i - 1
                                p2 -= i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    ElseIf pt = 2 Then
                        If bd((a - i) * 10 + b + i) = 2 Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    bd((a - n) * 10 + b + n) = 2
                                Next
                                p1 -= i - 1
                                p2 += i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    End If
                End If
            Next
            'Reload
            If cb = 1 Then
                CT()
                aip &= bt
                EC()
                If gec = 0 Then
                    AI()
                Else
                    pn += 1
                End If
            End If
        End If
    End Sub

    Sub CT()
        If pt = 1 Then
            p1 += 1
            pt = 2
        ElseIf pt = 2 Then
            p2 += 1
            pt = 1
        End If
    End Sub

    Sub EC()
        For p = 1 To 2
            cx = 0
            For n = 1 To 8
                For m = 1 To 8
                    If bd(n * 10 + m) = 3 Then
                        bd(n * 10 + m) = 0
                    End If
                Next
            Next
            For c = 1 To 8
                For d = 1 To 8
                    If bd(c * 10 + d) = 0 Then
                        cb = 0
                        'Right
                        For i = 1 To 7
                            If d + i > 8 Then
                                Exit For
                            Else
                                If bd(c * 10 + d + i) = 0 Or bd(c * 10 + d + i) = 3 Then
                                    Exit For
                                End If
                                If pt = 1 Then
                                    If bd(c * 10 + d + i) = 1 Then
                                        If i <> 1 Then
                                            cb = 1
                                        End If
                                        Exit For
                                    End If
                                ElseIf pt = 2 Then
                                    If bd(c * 10 + d + i) = 2 Then
                                        If i <> 1 Then
                                            cb = 1
                                        End If
                                        Exit For
                                    End If
                                End If
                            End If
                        Next
                        'Down
                        For i = 1 To 7
                            If c + i > 8 Then
                                Exit For
                            Else
                                If bd((c + i) * 10 + d) = 0 Or bd((c + i) * 10 + d) = 3 Then
                                    Exit For
                                End If
                                If pt = 1 Then
                                    If bd((c + i) * 10 + d) = 1 Then
                                        If i <> 1 Then
                                            cb = 1
                                        End If
                                        Exit For
                                    End If
                                ElseIf pt = 2 Then
                                    If bd((c + i) * 10 + d) = 2 Then
                                        If i <> 1 Then
                                            cb = 1
                                        End If
                                        Exit For
                                    End If
                                End If
                            End If
                        Next
                        'Left
                        For i = 1 To 7
                            If d - i < 1 Then
                                Exit For
                            Else
                                If bd(c * 10 + d - i) = 0 Or bd(c * 10 + d - i) = 3 Then
                                    Exit For
                                End If
                                If pt = 1 Then
                                    If bd(c * 10 + d - i) = 1 Then
                                        If i <> 1 Then
                                            cb = 1
                                        End If
                                        Exit For
                                    End If
                                ElseIf pt = 2 Then
                                    If bd(c * 10 + d - i) = 2 Then
                                        If i <> 1 Then
                                            cb = 1
                                        End If
                                        Exit For
                                    End If
                                End If
                            End If
                        Next
                        'Up
                        For i = 1 To 7
                            If c - i < 1 Then
                                Exit For
                            Else
                                If bd((c - i) * 10 + d) = 0 Or bd((c - i) * 10 + d) = 3 Then
                                    Exit For
                                End If
                                If pt = 1 Then
                                    If bd((c - i) * 10 + d) = 1 Then
                                        If i <> 1 Then
                                            cb = 1
                                        End If
                                        Exit For
                                    End If
                                ElseIf pt = 2 Then
                                    If bd((c - i) * 10 + d) = 2 Then
                                        If i <> 1 Then
                                            cb = 1
                                        End If
                                        Exit For
                                    End If
                                End If
                            End If
                        Next
                        'Right and Down
                        For i = 1 To 7
                            If c + i > 8 Or d + i > 8 Then
                                Exit For
                            Else
                                If bd((c + i) * 10 + d + i) = 0 Or bd((c + i) * 10 + d + i) = 3 Then
                                    Exit For
                                End If
                                If pt = 1 Then
                                    If bd((c + i) * 10 + d + i) = 1 Then
                                        If i <> 1 Then
                                            cb = 1
                                        End If
                                        Exit For
                                    End If
                                ElseIf pt = 2 Then
                                    If bd((c + i) * 10 + d + i) = 2 Then
                                        If i <> 1 Then
                                            cb = 1
                                        End If
                                        Exit For
                                    End If
                                End If
                            End If
                        Next
                        'Left and Down
                        For i = 1 To 7
                            If c + i > 8 Or d - i < 1 Then
                                Exit For
                            Else
                                If bd((c + i) * 10 + d - i) = 0 Or bd((c + i) * 10 + d - i) = 3 Then
                                    Exit For
                                End If
                                If pt = 1 Then
                                    If bd((c + i) * 10 + d - i) = 1 Then
                                        If i <> 1 Then
                                            cb = 1
                                        End If
                                        Exit For
                                    End If
                                ElseIf pt = 2 Then
                                    If bd((c + i) * 10 + d - i) = 2 Then
                                        If i <> 1 Then
                                            cb = 1
                                        End If
                                        Exit For
                                    End If
                                End If
                            End If
                        Next
                        'Left and Up
                        For i = 1 To 7
                            If c - i < 1 Or d - i < 1 Then
                                Exit For
                            Else
                                If bd((c - i) * 10 + d - i) = 0 Or bd((c - i) * 10 + d - i) = 3 Then
                                    Exit For
                                End If
                                If pt = 1 Then
                                    If bd((c - i) * 10 + d - i) = 1 Then
                                        If i <> 1 Then
                                            cb = 1
                                        End If
                                        Exit For
                                    End If
                                ElseIf pt = 2 Then
                                    If bd((c - i) * 10 + d - i) = 2 Then
                                        If i <> 1 Then
                                            cb = 1
                                        End If
                                        Exit For
                                    End If
                                End If
                            End If
                        Next
                        'Right and Up
                        For i = 1 To 7
                            If c - i < 1 Or d + i > 8 Then
                                Exit For
                            Else
                                If bd((c - i) * 10 + d + i) = 0 Or bd((c - i) * 10 + d + i) = 3 Then
                                    Exit For
                                End If
                                If pt = 1 Then
                                    If bd((c - i) * 10 + d + i) = 1 Then
                                        If i <> 1 Then
                                            cb = 1
                                        End If
                                        Exit For
                                    End If
                                ElseIf pt = 2 Then
                                    If bd((c - i) * 10 + d + i) = 2 Then
                                        If i <> 1 Then
                                            cb = 1
                                        End If
                                        Exit For
                                    End If
                                End If
                            End If
                        Next
                        If cb = 1 Then
                            cx += 1
                            bd(c * 10 + d) = 3
                        End If
                    End If
                Next
            Next
            If cx >= 1 Then
                Exit Sub
            End If
            If pt = 1 Then
                pt = 2
            ElseIf pt = 2 Then
                pt = 1
            End If
        Next
        If p1 > p2 Then
            gr = "B"
        ElseIf p1 < p2 Then
            gr = "W"
        Else
            gr = "D"
        End If
        AIR()
        gec = 1
    End Sub

    Sub AI()
        If ain = 0 Then
            If aidl > 1 Then
                ait = aid
                eon = 0
                aie = ""
                Do While ait.Contains(aip)
                    If aip = "#" Then
                        wtp(0) = 3
                        wtp(1) = 4
                        eon = 1
                        Exit Do
                    End If
                    ait = ait.Substring(ait.IndexOf(aip))
                    If a2 = 2 Then
                        If pt = 1 And ait.Substring(ait.IndexOf("!") + 1, 1) = "B" Then
                            wtp(0) = ait.Substring(ait.IndexOf(aip) + aip.Length, 1)
                            wtp(1) = ait.Substring(ait.IndexOf(aip) + aip.Length + 1, 1)
                            eon = 1
                            Exit Do
                        ElseIf pt = 2 And ait.Substring(ait.IndexOf("!") + 1, 1) = "W" Then
                            wtp(0) = ait.Substring(ait.IndexOf(aip) + aip.Length, 1)
                            wtp(1) = ait.Substring(ait.IndexOf(aip) + aip.Length + 1, 1)
                            eon = 1
                            Exit Do
                        End If
                    End If
                    If ait.Substring(ait.IndexOf("!") + 1, 1) = "W" Or ait.Substring(ait.IndexOf("!") + 1, 1) = "D" And pt = 1 Then
                        aie &= "#" & ait.Substring(ait.IndexOf(aip) + aip.Length, 2)
                    ElseIf ait.Substring(ait.IndexOf("!") + 1, 1) = "B" Or ait.Substring(ait.IndexOf("!") + 1, 1) = "D" And pt = 2 Then
                        aie &= "#" & ait.Substring(ait.IndexOf(aip) + aip.Length, 2)
                    End If
                    ait = ait.Substring(ait.IndexOf("$") + 3)
                    eon = 2
                Loop
                If eon = 0 Then
                    ain = 1
                ElseIf eon = 1 Then
                    PP(wtp(0) * 10 + wtp(1))
                    Exit Sub
                ElseIf eon = 2 Then
                    Do
                        wtp(0) = rdm.Next(1, 9)
                        wtp(1) = rdm.Next(1, 9)
                        If cx > aie.Length / 3 Then
                            If Not aie.Contains("#" & wtp(0) & wtp(1)) Then
                                If bd(wtp(0) * 10 + wtp(1)) = 3 Then
                                    PP(wtp(0) * 10 + wtp(1))
                                    Exit Sub
                                End If
                            End If
                        Else
                            If bd(wtp(0) * 10 + wtp(1)) = 3 Then
                                PP(wtp(0) * 10 + wtp(1))
                                Exit Sub
                            End If
                        End If
                    Loop
                End If
            Else
                ain = 1
            End If
        End If
        If ain = 1 Then
            Do
                wtp(0) = rdm.Next(1, 9)
                wtp(1) = rdm.Next(1, 9)
                If bd(wtp(0) * 10 + wtp(1)) = 3 Then
                    PP(wtp(0) * 10 + wtp(1))
                    Exit Do
                End If
            Loop
        End If
    End Sub

    Sub AIR()
        If ain = 1 Then
            Dim sw As New StreamWriter("AI\AI.aifo", True, System.Text.Encoding.GetEncoding("shift_jis"))
            If p1 < 10 And p2 < 10 Then
                sw.WriteLine(aip & "!" & gr & "?" & "0" & p1 & "0" & p2 & "$")
            ElseIf p1 < 10 Then
                sw.WriteLine(aip & "!" & gr & "?" & "0" & p1 & p2 & "$")
            ElseIf p2 < 10 Then
                sw.WriteLine(aip & "!" & gr & "?" & p1 & "0" & p2 & "$")
            Else
                sw.WriteLine(aip & "!" & gr & "?" & p1 & p2 & "$")
            End If
            sw.Close()
            sw.Dispose()
        End If
    End Sub

    Private Sub Game_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If aig = 1 Then
            e.Cancel = True
        End If
    End Sub
End Class