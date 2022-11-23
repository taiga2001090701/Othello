Imports System.Collections
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms
Imports Scripting

Public Class History
    'Form
    Dim fp As New Player
    'Argument
    Public pm As Byte 'Player Number, Network Enabled, Server or Client, Chat Using, AI Enabled, AI Former or Latter
    'Common
    Dim a, b As Byte 'vertical button number, horizontal button number
    Dim p1, p2, p3, p4 As Byte 'Player 1-4 points
    Dim pt, pnm, sd As Byte 'Player Turn, Player Number Memory, Game End, Slow Disabled
    Dim cb, cx As Byte 'Check Button clicked, Check Exception
    Dim thn, chn As ULong 'Total History Number, Current History Number
    Dim fp1, fp2, fp3, fp4 As Byte 'Final Points
    Dim rt, st As String 'Read Text, Steps Text
    Dim dls As New Stack() 'Data List Stack
    Dim apm(60, 8, 8) As Byte 'All Patterns Memory
    Dim cs, ts As Byte 'Current Steps, Total Steps
    'Component
    Dim path As New Drawing2D.GraphicsPath()
    Dim rdm As New Random(Date.Now.Second)
    Dim fso As New FileSystemObject
    Dim fsots As TextStream
    Private Sub Game_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        path.AddEllipse(New Rectangle(0, 0, 60, 60))
        Button44.Region = New Region(path)
        Button45.Region = New Region(path)
        Button54.Region = New Region(path)
        Button55.Region = New Region(path)
        If pm = 2 Then
            fp.pm = 2
            Button44.BackColor = Color.White
            Button45.BackColor = Color.Black
            Button54.BackColor = Color.Black
            Button55.BackColor = Color.White
            LP.Text = "Player Black's Turn"
            LP.ForeColor = Color.Black
            p1 = 2
            p2 = 2
            apm(0, 4, 4) = 2
            apm(0, 4, 5) = 1
            apm(0, 5, 4) = 1
            apm(0, 5, 5) = 2
            apm(0, 0, 0) = 1
            apm(0, 0, 1) = 2
            apm(0, 0, 2) = 2
            If IO.File.Exists("Data\H" & pm & ".ghfo") Then
                fsots = fso.OpenTextFile("Data\H" & pm & ".ghfo", IOMode.ForAppending)
                thn = fsots.Line - 2
                fsots.Close()
                If thn = 0 Then
                    MsgBox("Game History Data Not Found")
                    Close()
                    Exit Sub
                End If
                chn = 1
                Dim sr As New StreamReader("Data\H" & pm & ".ghfo", System.Text.Encoding.GetEncoding("shift_jis"))
                sr.ReadLine()
                For i As ULong = 1 To thn
                    rt = sr.ReadLine
                    dls.Push(rt.Substring(rt.IndexOf("%") + 1, rt.IndexOf("?") - rt.IndexOf("%") - 1))
                Next
                sr.Close()
                For i As ULong = 1 To thn
                    CBH.Items.Add(dls.Pop)
                Next
                CBH.SelectedIndex = 0
                cs = 0
                st = rt.Substring(rt.IndexOf("#") + 1, rt.IndexOf("!") - rt.IndexOf("#") - 1)
                ts = st.Length / 2
                fp1 = CByte(rt.Substring(rt.IndexOf("!") + 1, 2))
                fp2 = CByte(rt.Substring(rt.IndexOf("!") + 3, 2))
                Text = "History - " & rt.Substring(rt.IndexOf("?") + 1, rt.IndexOf("#") - rt.IndexOf("?") - 1)
            Else
                MsgBox("Game History Data Not Found")
                Close()
                Exit Sub
            End If
        ElseIf pm = 4 Then
            fp.pm = 4
            Button44.BackColor = Color.Red
            Button45.BackColor = Color.SkyBlue
            Button54.BackColor = Color.Orange
            Button55.BackColor = Color.LawnGreen
            Button65.BackColor = Color.Red
            Button53.BackColor = Color.SkyBlue
            Button46.BackColor = Color.Orange
            Button34.BackColor = Color.LawnGreen
            Button65.Region = New Region(path)
            Button53.Region = New Region(path)
            Button46.Region = New Region(path)
            Button34.Region = New Region(path)
            LP.Text = "Player Red's Turn"
            LP.ForeColor = Color.Red
            p1 = 2
            p2 = 2
            p3 = 2
            p4 = 2
            apm(0, 4, 4) = 1
            apm(0, 4, 5) = 2
            apm(0, 5, 4) = 3
            apm(0, 5, 5) = 4
            apm(0, 6, 5) = 1
            apm(0, 5, 3) = 2
            apm(0, 4, 6) = 3
            apm(0, 3, 4) = 4
            apm(0, 0, 0) = 1
            apm(0, 0, 1) = 2
            apm(0, 0, 2) = 2
            apm(0, 0, 3) = 2
            apm(0, 0, 4) = 2
            If IO.File.Exists("Data\H" & pm & ".ghfo") Then
                fsots = fso.OpenTextFile("Data\H" & pm & ".ghfo", IOMode.ForAppending)
                thn = fsots.Line - 2
                fsots.Close()
                If thn = 0 Then
                    MsgBox("Game History Data Not Found")
                    Close()
                    Exit Sub
                End If
                chn = 1
                Dim sr As New StreamReader("Data\H" & pm & ".ghfo", System.Text.Encoding.GetEncoding("shift_jis"))
                sr.ReadLine()
                For i As ULong = 1 To thn
                    rt = sr.ReadLine
                    dls.Push(rt.Substring(rt.IndexOf("%") + 1, rt.IndexOf("?") - rt.IndexOf("%") - 1))
                Next
                sr.Close()
                For i As ULong = 1 To thn
                    CBH.Items.Add(dls.Pop)
                Next
                CBH.SelectedIndex = 0
                cs = 0
                st = rt.Substring(rt.IndexOf("#") + 1, rt.IndexOf("!") - rt.IndexOf("#") - 1)
                ts = st.Length / 2
                fp1 = CByte(rt.Substring(rt.IndexOf("!") + 1, 2))
                fp2 = CByte(rt.Substring(rt.IndexOf("!") + 3, 2))
                fp3 = CByte(rt.Substring(rt.IndexOf("!") + 5, 2))
                fp4 = CByte(rt.Substring(rt.IndexOf("!") + 7, 2))
                Text = "History - " & rt.Substring(rt.IndexOf("?") + 1, rt.IndexOf("#") - rt.IndexOf("?") - 1)
            Else
                MsgBox("Game History Data Not Found")
                Close()
                Exit Sub
            End If
        End If
        pt = 1
        pnm = 1
        sd = 0
        EC()
        fp.P1.Show()
        fp.P2.Hide()
        fp.P3.Hide()
        fp.P4.Hide()
        fp.Show(Me)
        fp.Location = New Point(Left + Width, Top)
        If pm = 2 Then
            fp.L1.Text &= " (" & fp1 & ")"
            fp.L2.Text &= " (" & fp2 & ")"
        ElseIf pm = 4 Then
            fp.L1.Text &= " (" & fp1 & ")"
            fp.L2.Text &= " (" & fp2 & ")"
            fp.L3.Text &= " (" & fp3 & ")"
            fp.L4.Text &= " (" & fp4 & ")"
        End If
    End Sub

    Private Sub Button_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles Button88.PreviewKeyDown, Button87.PreviewKeyDown, Button86.PreviewKeyDown, Button85.PreviewKeyDown, Button84.PreviewKeyDown, Button83.PreviewKeyDown, Button82.PreviewKeyDown, Button81.PreviewKeyDown, Button78.PreviewKeyDown, Button77.PreviewKeyDown, Button76.PreviewKeyDown, Button75.PreviewKeyDown, Button74.PreviewKeyDown, Button73.PreviewKeyDown, Button72.PreviewKeyDown, Button71.PreviewKeyDown, Button68.PreviewKeyDown, Button67.PreviewKeyDown, Button66.PreviewKeyDown, Button65.PreviewKeyDown, Button64.PreviewKeyDown, Button63.PreviewKeyDown, Button62.PreviewKeyDown, Button61.PreviewKeyDown, Button58.PreviewKeyDown, Button57.PreviewKeyDown, Button56.PreviewKeyDown, Button55.PreviewKeyDown, Button54.PreviewKeyDown, Button53.PreviewKeyDown, Button52.PreviewKeyDown, Button51.PreviewKeyDown, Button48.PreviewKeyDown, Button47.PreviewKeyDown, Button46.PreviewKeyDown, Button45.PreviewKeyDown, Button44.PreviewKeyDown, Button43.PreviewKeyDown, Button42.PreviewKeyDown, Button41.PreviewKeyDown, Button38.PreviewKeyDown, Button37.PreviewKeyDown, Button36.PreviewKeyDown, Button35.PreviewKeyDown, Button34.PreviewKeyDown, Button33.PreviewKeyDown, Button32.PreviewKeyDown, Button31.PreviewKeyDown, Button28.PreviewKeyDown, Button27.PreviewKeyDown, Button26.PreviewKeyDown, Button25.PreviewKeyDown, Button24.PreviewKeyDown, Button23.PreviewKeyDown, Button22.PreviewKeyDown, Button21.PreviewKeyDown, Button18.PreviewKeyDown, Button17.PreviewKeyDown, Button16.PreviewKeyDown, Button15.PreviewKeyDown, Button14.PreviewKeyDown, Button13.PreviewKeyDown, Button12.PreviewKeyDown, Button11.PreviewKeyDown
        Select Case e.KeyCode
            Case Keys.Up
                e.IsInputKey = True
                If CInt(CType(sender, Button).Name.Substring(6, 1)) > 1 Then
                    CType(FindForm.Controls("Button" & CInt(CType(sender, Button).Name.Substring(6, 1)) - 1 & CInt(CType(sender, Button).Name.Substring(7, 1))), Button).Focus()
                End If
            Case Keys.Down
                e.IsInputKey = True
                If CInt(CType(sender, Button).Name.Substring(6, 1)) < 8 Then
                    CType(FindForm.Controls("Button" & CInt(CType(sender, Button).Name.Substring(6, 1)) + 1 & CInt(CType(sender, Button).Name.Substring(7, 1))), Button).Focus()
                End If
            Case Keys.Left
                e.IsInputKey = True
                If CInt(CType(sender, Button).Name.Substring(7, 1)) > 1 Then
                    CType(FindForm.Controls("Button" & CInt(CType(sender, Button).Name.Substring(6, 1)) & CInt(CType(sender, Button).Name.Substring(7, 1)) - 1), Button).Focus()
                End If
            Case Keys.Right
                e.IsInputKey = True
                If CInt(CType(sender, Button).Name.Substring(7, 1)) < 8 Then
                    CType(FindForm.Controls("Button" & CInt(CType(sender, Button).Name.Substring(6, 1)) & CInt(CType(sender, Button).Name.Substring(7, 1)) + 1), Button).Focus()
                End If
        End Select
    End Sub

    Private Sub Button_Enter(sender As Object, e As EventArgs) Handles Button88.Enter, Button87.Enter, Button86.Enter, Button85.Enter, Button84.Enter, Button83.Enter, Button82.Enter, Button81.Enter, Button78.Enter, Button77.Enter, Button76.Enter, Button75.Enter, Button74.Enter, Button73.Enter, Button72.Enter, Button71.Enter, Button68.Enter, Button67.Enter, Button66.Enter, Button65.Enter, Button64.Enter, Button63.Enter, Button62.Enter, Button61.Enter, Button58.Enter, Button57.Enter, Button56.Enter, Button55.Enter, Button54.Enter, Button53.Enter, Button52.Enter, Button51.Enter, Button48.Enter, Button47.Enter, Button46.Enter, Button45.Enter, Button44.Enter, Button43.Enter, Button42.Enter, Button41.Enter, Button38.Enter, Button37.Enter, Button36.Enter, Button35.Enter, Button34.Enter, Button33.Enter, Button32.Enter, Button31.Enter, Button28.Enter, Button27.Enter, Button26.Enter, Button25.Enter, Button24.Enter, Button23.Enter, Button22.Enter, Button21.Enter, Button18.Enter, Button17.Enter, Button16.Enter, Button15.Enter, Button14.Enter, Button13.Enter, Button12.Enter, Button11.Enter
        If CType(sender, Button).BackColor = Color.Green Or CType(sender, Button).BackColor = Color.Lime Then
            CType(sender, Button).FlatAppearance.BorderColor = Color.White
        End If
    End Sub

    Private Sub Button_Leave(sender As Object, e As EventArgs) Handles Button88.Leave, Button87.Leave, Button86.Leave, Button85.Leave, Button84.Leave, Button83.Leave, Button82.Leave, Button81.Leave, Button78.Leave, Button77.Leave, Button76.Leave, Button75.Leave, Button74.Leave, Button73.Leave, Button72.Leave, Button71.Leave, Button68.Leave, Button67.Leave, Button66.Leave, Button65.Leave, Button64.Leave, Button63.Leave, Button62.Leave, Button61.Leave, Button58.Leave, Button57.Leave, Button56.Leave, Button55.Leave, Button54.Leave, Button53.Leave, Button52.Leave, Button51.Leave, Button48.Leave, Button47.Leave, Button46.Leave, Button45.Leave, Button44.Leave, Button43.Leave, Button42.Leave, Button41.Leave, Button38.Leave, Button37.Leave, Button36.Leave, Button35.Leave, Button34.Leave, Button33.Leave, Button32.Leave, Button31.Leave, Button28.Leave, Button27.Leave, Button26.Leave, Button25.Leave, Button24.Leave, Button23.Leave, Button22.Leave, Button21.Leave, Button18.Leave, Button17.Leave, Button16.Leave, Button15.Leave, Button14.Leave, Button13.Leave, Button12.Leave, Button11.Leave
        CType(sender, Button).FlatAppearance.BorderColor = Color.Black
    End Sub

    Private Sub BC(seb As String)
        a = CByte(seb.Substring(0, 1))
        b = CByte(seb.Substring(1, 1))
        If CType(FindForm.Controls("Button" & a & b), Button).BackColor = Color.Lime Then
            LG()
            cb = 0
            CType(FindForm.Controls("Button" & a & b), Button).Region = New Region(path)
            If pm = 2 And pt = 1 Then
                CType(FindForm.Controls("Button" & a & b), Button).BackColor = Color.Black
                If sd = 0 Then
                    BA()
                    CType(FindForm.Controls("Button" & a & b), Button).BackColor = Color.Lime
                    BA()
                    CType(FindForm.Controls("Button" & a & b), Button).BackColor = Color.Black
                    BA()
                    CType(FindForm.Controls("Button" & a & b), Button).BackColor = Color.Lime
                    BA()
                    CType(FindForm.Controls("Button" & a & b), Button).BackColor = Color.Black
                    BA()
                End If
            ElseIf pm = 2 And pt = 2 Then
                CType(FindForm.Controls("Button" & a & b), Button).BackColor = Color.White
                If sd = 0 Then
                    BA()
                    CType(FindForm.Controls("Button" & a & b), Button).BackColor = Color.Lime
                    BA()
                    CType(FindForm.Controls("Button" & a & b), Button).BackColor = Color.White
                    BA()
                    CType(FindForm.Controls("Button" & a & b), Button).BackColor = Color.Lime
                    BA()
                    CType(FindForm.Controls("Button" & a & b), Button).BackColor = Color.White
                    BA()
                End If
            ElseIf pm = 4 And pt = 1 Then
                CType(FindForm.Controls("Button" & a & b), Button).BackColor = Color.Red
                If sd = 0 Then
                    BA()
                    CType(FindForm.Controls("Button" & a & b), Button).BackColor = Color.Lime
                    BA()
                    CType(FindForm.Controls("Button" & a & b), Button).BackColor = Color.Red
                    BA()
                    CType(FindForm.Controls("Button" & a & b), Button).BackColor = Color.Lime
                    BA()
                    CType(FindForm.Controls("Button" & a & b), Button).BackColor = Color.Red
                    BA()
                End If
            ElseIf pm = 4 And pt = 2 Then
                CType(FindForm.Controls("Button" & a & b), Button).BackColor = Color.SkyBlue
                If sd = 0 Then
                    BA()
                    CType(FindForm.Controls("Button" & a & b), Button).BackColor = Color.Lime
                    BA()
                    CType(FindForm.Controls("Button" & a & b), Button).BackColor = Color.SkyBlue
                    BA()
                    CType(FindForm.Controls("Button" & a & b), Button).BackColor = Color.Lime
                    BA()
                    CType(FindForm.Controls("Button" & a & b), Button).BackColor = Color.SkyBlue
                    BA()
                End If
            ElseIf pm = 4 And pt = 3 Then
                CType(FindForm.Controls("Button" & a & b), Button).BackColor = Color.Orange
                If sd = 0 Then
                    BA()
                    CType(FindForm.Controls("Button" & a & b), Button).BackColor = Color.Lime
                    BA()
                    CType(FindForm.Controls("Button" & a & b), Button).BackColor = Color.Orange
                    BA()
                    CType(FindForm.Controls("Button" & a & b), Button).BackColor = Color.Lime
                    BA()
                    CType(FindForm.Controls("Button" & a & b), Button).BackColor = Color.Orange
                    BA()
                End If
            ElseIf pm = 4 And pt = 4 Then
                CType(FindForm.Controls("Button" & a & b), Button).BackColor = Color.LawnGreen
                If sd = 0 Then
                    BA()
                    CType(FindForm.Controls("Button" & a & b), Button).BackColor = Color.Lime
                    BA()
                    CType(FindForm.Controls("Button" & a & b), Button).BackColor = Color.LawnGreen
                    BA()
                    CType(FindForm.Controls("Button" & a & b), Button).BackColor = Color.Lime
                    BA()
                    CType(FindForm.Controls("Button" & a & b), Button).BackColor = Color.LawnGreen
                    BA()
                End If
            End If
            'Right
            For i = 1 To 7
                If b + i > 8 Then
                    Exit For
                Else
                    If CType(FindForm.Controls("Button" & a & b + i), Button).BackColor = Color.Green Or CType(FindForm.Controls("Button" & a & b + i), Button).BackColor = Color.Lime Then
                        Exit For
                    End If
                    If pm = 2 And pt = 1 Then
                        If CType(FindForm.Controls("Button" & a & b + i), Button).BackColor = Color.Black Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    CType(FindForm.Controls("Button" & a & b + n), Button).BackColor = Color.Black
                                    BA()
                                Next
                                'Ctype(FindForm.Controls("Button" & a & b), Button).Region = new Region(path)
                                p1 += i - 1
                                p2 -= i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    ElseIf pm = 2 And pt = 2 Then
                        If CType(FindForm.Controls("Button" & a & b + i), Button).BackColor = Color.White Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    CType(FindForm.Controls("Button" & a & b + n), Button).BackColor = Color.White
                                    BA()
                                Next
                                'Ctype(FindForm.Controls("Button" & a & b), Button).Region = new Region(path)
                                p1 -= i - 1
                                p2 += i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    ElseIf pm = 4 And pt = 1 Then
                        If CType(FindForm.Controls("Button" & a & b + i), Button).BackColor = Color.Red Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    If CType(FindForm.Controls("Button" & a & b + n), Button).BackColor = Color.SkyBlue Then
                                        p2 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a & b + n), Button).BackColor = Color.Orange Then
                                        p3 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a & b + n), Button).BackColor = Color.LawnGreen Then
                                        p4 -= 1
                                    End If
                                    CType(FindForm.Controls("Button" & a & b + n), Button).BackColor = Color.Red
                                    BA()
                                Next
                                'Ctype(FindForm.Controls("Button" & a & b), Button).Region = new Region(path)
                                p1 += i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    ElseIf pm = 4 And pt = 2 Then
                        If CType(FindForm.Controls("Button" & a & b + i), Button).BackColor = Color.SkyBlue Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    If CType(FindForm.Controls("Button" & a & b + n), Button).BackColor = Color.Red Then
                                        p1 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a & b + n), Button).BackColor = Color.Orange Then
                                        p3 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a & b + n), Button).BackColor = Color.LawnGreen Then
                                        p4 -= 1
                                    End If
                                    CType(FindForm.Controls("Button" & a & b + n), Button).BackColor = Color.SkyBlue
                                    BA()
                                Next
                                'Ctype(FindForm.Controls("Button" & a & b), Button).Region = new Region(path)
                                p2 += i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    ElseIf pm = 4 And pt = 3 Then
                        If CType(FindForm.Controls("Button" & a & b + i), Button).BackColor = Color.Orange Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    If CType(FindForm.Controls("Button" & a & b + n), Button).BackColor = Color.Red Then
                                        p1 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a & b + n), Button).BackColor = Color.SkyBlue Then
                                        p2 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a & b + n), Button).BackColor = Color.LawnGreen Then
                                        p4 -= 1
                                    End If
                                    CType(FindForm.Controls("Button" & a & b + n), Button).BackColor = Color.Orange
                                    BA()
                                Next
                                'Ctype(FindForm.Controls("Button" & a & b), Button).Region = new Region(path)
                                p3 += i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    ElseIf pm = 4 And pt = 4 Then
                        If CType(FindForm.Controls("Button" & a & b + i), Button).BackColor = Color.LawnGreen Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    If CType(FindForm.Controls("Button" & a & b + n), Button).BackColor = Color.Red Then
                                        p1 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a & b + n), Button).BackColor = Color.SkyBlue Then
                                        p2 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a & b + n), Button).BackColor = Color.Orange Then
                                        p3 -= 1
                                    End If
                                    CType(FindForm.Controls("Button" & a & b + n), Button).BackColor = Color.LawnGreen
                                    BA()
                                Next
                                'Ctype(FindForm.Controls("Button" & a & b), Button).Region = new Region(path)
                                p4 += i - 1
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
                    If CType(FindForm.Controls("Button" & a + i & b), Button).BackColor = Color.Green Or CType(FindForm.Controls("Button" & a + i & b), Button).BackColor = Color.Lime Then
                        Exit For
                    End If
                    If pm = 2 And pt = 1 Then
                        If CType(FindForm.Controls("Button" & a + i & b), Button).BackColor = Color.Black Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    CType(FindForm.Controls("Button" & a + n & b), Button).BackColor = Color.Black
                                    BA()
                                Next
                                'Ctype(FindForm.Controls("Button" & a & b), Button).Region = new Region(path)
                                p1 += i - 1
                                p2 -= i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    ElseIf pm = 2 And pt = 2 Then
                        If CType(FindForm.Controls("Button" & a + i & b), Button).BackColor = Color.White Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    CType(FindForm.Controls("Button" & a + n & b), Button).BackColor = Color.White
                                    BA()
                                Next
                                'Ctype(FindForm.Controls("Button" & a & b), Button).Region = new Region(path)
                                p1 -= i - 1
                                p2 += i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    ElseIf pm = 4 And pt = 1 Then
                        If CType(FindForm.Controls("Button" & a + i & b), Button).BackColor = Color.Red Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    If CType(FindForm.Controls("Button" & a + n & b), Button).BackColor = Color.SkyBlue Then
                                        p2 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a + n & b), Button).BackColor = Color.Orange Then
                                        p3 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a + n & b), Button).BackColor = Color.LawnGreen Then
                                        p4 -= 1
                                    End If
                                    CType(FindForm.Controls("Button" & a + n & b), Button).BackColor = Color.Red
                                    BA()
                                Next
                                'Ctype(FindForm.Controls("Button" & a & b), Button).Region = new Region(path)
                                p1 += i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    ElseIf pm = 4 And pt = 2 Then
                        If CType(FindForm.Controls("Button" & a + i & b), Button).BackColor = Color.SkyBlue Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    If CType(FindForm.Controls("Button" & a + n & b), Button).BackColor = Color.Red Then
                                        p1 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a + n & b), Button).BackColor = Color.Orange Then
                                        p3 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a + n & b), Button).BackColor = Color.LawnGreen Then
                                        p4 -= 1
                                    End If
                                    CType(FindForm.Controls("Button" & a + n & b), Button).BackColor = Color.SkyBlue
                                    BA()
                                Next
                                'Ctype(FindForm.Controls("Button" & a & b), Button).Region = new Region(path)
                                p2 += i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    ElseIf pm = 4 And pt = 3 Then
                        If CType(FindForm.Controls("Button" & a + i & b), Button).BackColor = Color.Orange Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    If CType(FindForm.Controls("Button" & a + n & b), Button).BackColor = Color.Red Then
                                        p1 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a + n & b), Button).BackColor = Color.SkyBlue Then
                                        p2 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a + n & b), Button).BackColor = Color.LawnGreen Then
                                        p4 -= 1
                                    End If
                                    CType(FindForm.Controls("Button" & a + n & b), Button).BackColor = Color.Orange
                                    BA()
                                Next
                                'Ctype(FindForm.Controls("Button" & a & b), Button).Region = new Region(path)
                                p3 += i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    ElseIf pm = 4 And pt = 4 Then
                        If CType(FindForm.Controls("Button" & a + i & b), Button).BackColor = Color.LawnGreen Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    If CType(FindForm.Controls("Button" & a + n & b), Button).BackColor = Color.Red Then
                                        p1 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a + n & b), Button).BackColor = Color.SkyBlue Then
                                        p2 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a + n & b), Button).BackColor = Color.Orange Then
                                        p3 -= 1
                                    End If
                                    CType(FindForm.Controls("Button" & a + n & b), Button).BackColor = Color.LawnGreen
                                    BA()
                                Next
                                'Ctype(FindForm.Controls("Button" & a & b), Button).Region = new Region(path)
                                p4 += i - 1
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
                    If CType(FindForm.Controls("Button" & a & b - i), Button).BackColor = Color.Green Or CType(FindForm.Controls("Button" & a & b - i), Button).BackColor = Color.Lime Then
                        Exit For
                    End If
                    If pm = 2 And pt = 1 Then
                        If CType(FindForm.Controls("Button" & a & b - i), Button).BackColor = Color.Black Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    CType(FindForm.Controls("Button" & a & b - n), Button).BackColor = Color.Black
                                    BA()
                                Next
                                'Ctype(FindForm.Controls("Button" & a & b), Button).Region = new Region(path)
                                p1 += i - 1
                                p2 -= i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    ElseIf pm = 2 And pt = 2 Then
                        If CType(FindForm.Controls("Button" & a & b - i), Button).BackColor = Color.White Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    CType(FindForm.Controls("Button" & a & b - n), Button).BackColor = Color.White
                                    BA()
                                Next
                                'Ctype(FindForm.Controls("Button" & a & b), Button).Region = new Region(path)
                                p1 -= i - 1
                                p2 += i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    ElseIf pm = 4 And pt = 1 Then
                        If CType(FindForm.Controls("Button" & a & b - i), Button).BackColor = Color.Red Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    If CType(FindForm.Controls("Button" & a & b - n), Button).BackColor = Color.SkyBlue Then
                                        p2 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a & b - n), Button).BackColor = Color.Orange Then
                                        p3 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a & b - n), Button).BackColor = Color.LawnGreen Then
                                        p4 -= 1
                                    End If
                                    CType(FindForm.Controls("Button" & a & b - n), Button).BackColor = Color.Red
                                    BA()
                                Next
                                'Ctype(FindForm.Controls("Button" & a & b), Button).Region = new Region(path)
                                p1 += i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    ElseIf pm = 4 And pt = 2 Then
                        If CType(FindForm.Controls("Button" & a & b - i), Button).BackColor = Color.SkyBlue Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    If CType(FindForm.Controls("Button" & a & b - n), Button).BackColor = Color.Red Then
                                        p1 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a & b - n), Button).BackColor = Color.Orange Then
                                        p3 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a & b - n), Button).BackColor = Color.LawnGreen Then
                                        p4 -= 1
                                    End If
                                    CType(FindForm.Controls("Button" & a & b - n), Button).BackColor = Color.SkyBlue
                                    BA()
                                Next
                                'Ctype(FindForm.Controls("Button" & a & b), Button).Region = new Region(path)
                                p2 += i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    ElseIf pm = 4 And pt = 3 Then
                        If CType(FindForm.Controls("Button" & a & b - i), Button).BackColor = Color.Orange Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    If CType(FindForm.Controls("Button" & a & b - n), Button).BackColor = Color.Red Then
                                        p1 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a & b - n), Button).BackColor = Color.SkyBlue Then
                                        p2 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a & b - n), Button).BackColor = Color.LawnGreen Then
                                        p4 -= 1
                                    End If
                                    CType(FindForm.Controls("Button" & a & b - n), Button).BackColor = Color.Orange
                                    BA()
                                Next
                                'Ctype(FindForm.Controls("Button" & a & b), Button).Region = new Region(path)
                                p3 += i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    ElseIf pm = 4 And pt = 4 Then
                        If CType(FindForm.Controls("Button" & a & b - i), Button).BackColor = Color.LawnGreen Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    If CType(FindForm.Controls("Button" & a & b - n), Button).BackColor = Color.Red Then
                                        p1 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a & b - n), Button).BackColor = Color.SkyBlue Then
                                        p2 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a & b - n), Button).BackColor = Color.Orange Then
                                        p3 -= 1
                                    End If
                                    CType(FindForm.Controls("Button" & a & b - n), Button).BackColor = Color.LawnGreen
                                    BA()
                                Next
                                'Ctype(FindForm.Controls("Button" & a & b), Button).Region = new Region(path)
                                p4 += i - 1
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
                    If CType(FindForm.Controls("Button" & a - i & b), Button).BackColor = Color.Green Or CType(FindForm.Controls("Button" & a - i & b), Button).BackColor = Color.Lime Then
                        Exit For
                    End If
                    If pm = 2 And pt = 1 Then
                        If CType(FindForm.Controls("Button" & a - i & b), Button).BackColor = Color.Black Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    CType(FindForm.Controls("Button" & a - n & b), Button).BackColor = Color.Black
                                    BA()
                                Next
                                'Ctype(FindForm.Controls("Button" & a & b), Button).Region = new Region(path)
                                p1 += i - 1
                                p2 -= i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    ElseIf pm = 2 And pt = 2 Then
                        If CType(FindForm.Controls("Button" & a - i & b), Button).BackColor = Color.White Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    CType(FindForm.Controls("Button" & a - n & b), Button).BackColor = Color.White
                                    BA()
                                Next
                                'Ctype(FindForm.Controls("Button" & a & b), Button).Region = new Region(path)
                                p1 -= i - 1
                                p2 += i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    ElseIf pm = 4 And pt = 1 Then
                        If CType(FindForm.Controls("Button" & a - i & b), Button).BackColor = Color.Red Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    If CType(FindForm.Controls("Button" & a - n & b), Button).BackColor = Color.SkyBlue Then
                                        p2 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a - n & b), Button).BackColor = Color.Orange Then
                                        p3 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a - n & b), Button).BackColor = Color.LawnGreen Then
                                        p4 -= 1
                                    End If
                                    CType(FindForm.Controls("Button" & a - n & b), Button).BackColor = Color.Red
                                    BA()
                                Next
                                'Ctype(FindForm.Controls("Button" & a & b), Button).Region = new Region(path)
                                p1 += i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    ElseIf pm = 4 And pt = 2 Then
                        If CType(FindForm.Controls("Button" & a - i & b), Button).BackColor = Color.SkyBlue Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    If CType(FindForm.Controls("Button" & a - n & b), Button).BackColor = Color.Red Then
                                        p1 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a - n & b), Button).BackColor = Color.Orange Then
                                        p3 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a - n & b), Button).BackColor = Color.LawnGreen Then
                                        p4 -= 1
                                    End If
                                    CType(FindForm.Controls("Button" & a - n & b), Button).BackColor = Color.SkyBlue
                                    BA()
                                Next
                                'Ctype(FindForm.Controls("Button" & a & b), Button).Region = new Region(path)
                                p2 += i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    ElseIf pm = 4 And pt = 3 Then
                        If CType(FindForm.Controls("Button" & a - i & b), Button).BackColor = Color.Orange Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    If CType(FindForm.Controls("Button" & a - n & b), Button).BackColor = Color.Red Then
                                        p1 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a - n & b), Button).BackColor = Color.SkyBlue Then
                                        p2 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a - n & b), Button).BackColor = Color.LawnGreen Then
                                        p4 -= 1
                                    End If
                                    CType(FindForm.Controls("Button" & a - n & b), Button).BackColor = Color.Orange
                                    BA()
                                Next
                                'Ctype(FindForm.Controls("Button" & a & b), Button).Region = new Region(path)
                                p3 += i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    ElseIf pm = 4 And pt = 4 Then
                        If CType(FindForm.Controls("Button" & a - i & b), Button).BackColor = Color.LawnGreen Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    If CType(FindForm.Controls("Button" & a - n & b), Button).BackColor = Color.Red Then
                                        p1 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a - n & b), Button).BackColor = Color.SkyBlue Then
                                        p2 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a - n & b), Button).BackColor = Color.Orange Then
                                        p3 -= 1
                                    End If
                                    CType(FindForm.Controls("Button" & a - n & b), Button).BackColor = Color.LawnGreen
                                    BA()
                                Next
                                'Ctype(FindForm.Controls("Button" & a & b), Button).Region = new Region(path)
                                p4 += i - 1
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
                    If CType(FindForm.Controls("Button" & a + i & b + i), Button).BackColor = Color.Green Or CType(FindForm.Controls("Button" & a + i & b + i), Button).BackColor = Color.Lime Then
                        Exit For
                    End If
                    If pm = 2 And pt = 1 Then
                        If CType(FindForm.Controls("Button" & a + i & b + i), Button).BackColor = Color.Black Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    CType(FindForm.Controls("Button" & a + n & b + n), Button).BackColor = Color.Black
                                    BA()
                                Next
                                'Ctype(FindForm.Controls("Button" & a & b), Button).Region = new Region(path)
                                p1 += i - 1
                                p2 -= i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    ElseIf pm = 2 And pt = 2 Then
                        If CType(FindForm.Controls("Button" & a + i & b + i), Button).BackColor = Color.White Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    CType(FindForm.Controls("Button" & a + n & b + n), Button).BackColor = Color.White
                                    BA()
                                Next
                                'Ctype(FindForm.Controls("Button" & a & b), Button).Region = new Region(path)
                                p1 -= i - 1
                                p2 += i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    ElseIf pm = 4 And pt = 1 Then
                        If CType(FindForm.Controls("Button" & a + i & b + i), Button).BackColor = Color.Red Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    If CType(FindForm.Controls("Button" & a + n & b + n), Button).BackColor = Color.SkyBlue Then
                                        p2 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a + n & b + n), Button).BackColor = Color.Orange Then
                                        p3 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a + n & b + n), Button).BackColor = Color.LawnGreen Then
                                        p4 -= 1
                                    End If
                                    CType(FindForm.Controls("Button" & a + n & b + n), Button).BackColor = Color.Red
                                    BA()
                                Next
                                'Ctype(FindForm.Controls("Button" & a & b), Button).Region = new Region(path)
                                p1 += i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    ElseIf pm = 4 And pt = 2 Then
                        If CType(FindForm.Controls("Button" & a + i & b + i), Button).BackColor = Color.SkyBlue Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    If CType(FindForm.Controls("Button" & a + n & b + n), Button).BackColor = Color.Red Then
                                        p1 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a + n & b + n), Button).BackColor = Color.Orange Then
                                        p3 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a + n & b + n), Button).BackColor = Color.LawnGreen Then
                                        p4 -= 1
                                    End If
                                    CType(FindForm.Controls("Button" & a + n & b + n), Button).BackColor = Color.SkyBlue
                                    BA()
                                Next
                                'Ctype(FindForm.Controls("Button" & a & b), Button).Region = new Region(path)
                                p2 += i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    ElseIf pm = 4 And pt = 3 Then
                        If CType(FindForm.Controls("Button" & a + i & b + i), Button).BackColor = Color.Orange Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    If CType(FindForm.Controls("Button" & a + n & b + n), Button).BackColor = Color.Red Then
                                        p1 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a + n & b + n), Button).BackColor = Color.SkyBlue Then
                                        p2 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a + n & b + n), Button).BackColor = Color.LawnGreen Then
                                        p4 -= 1
                                    End If
                                    CType(FindForm.Controls("Button" & a + n & b + n), Button).BackColor = Color.Orange
                                    BA()
                                Next
                                'Ctype(FindForm.Controls("Button" & a & b), Button).Region = new Region(path)
                                p3 += i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    ElseIf pm = 4 And pt = 4 Then
                        If CType(FindForm.Controls("Button" & a + i & b + i), Button).BackColor = Color.LawnGreen Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    If CType(FindForm.Controls("Button" & a + n & b + n), Button).BackColor = Color.Red Then
                                        p1 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a + n & b + n), Button).BackColor = Color.SkyBlue Then
                                        p2 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a + n & b + n), Button).BackColor = Color.Orange Then
                                        p3 -= 1
                                    End If
                                    CType(FindForm.Controls("Button" & a + n & b + n), Button).BackColor = Color.LawnGreen
                                    BA()
                                Next
                                'Ctype(FindForm.Controls("Button" & a & b), Button).Region = new Region(path)
                                p4 += i - 1
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
                    If CType(FindForm.Controls("Button" & a + i & b - i), Button).BackColor = Color.Green Or CType(FindForm.Controls("Button" & a + i & b - i), Button).BackColor = Color.Lime Then
                        Exit For
                    End If
                    If pm = 2 And pt = 1 Then
                        If CType(FindForm.Controls("Button" & a + i & b - i), Button).BackColor = Color.Black Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    CType(FindForm.Controls("Button" & a + n & b - n), Button).BackColor = Color.Black
                                    BA()
                                Next
                                'Ctype(FindForm.Controls("Button" & a & b), Button).Region = new Region(path)
                                p1 += i - 1
                                p2 -= i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    ElseIf pm = 2 And pt = 2 Then
                        If CType(FindForm.Controls("Button" & a + i & b - i), Button).BackColor = Color.White Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    CType(FindForm.Controls("Button" & a + n & b - n), Button).BackColor = Color.White
                                    BA()
                                Next
                                'Ctype(FindForm.Controls("Button" & a & b), Button).Region = new Region(path)
                                p1 -= i - 1
                                p2 += i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    ElseIf pm = 4 And pt = 1 Then
                        If CType(FindForm.Controls("Button" & a + i & b - i), Button).BackColor = Color.Red Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    If CType(FindForm.Controls("Button" & a + n & b - n), Button).BackColor = Color.SkyBlue Then
                                        p2 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a + n & b - n), Button).BackColor = Color.Orange Then
                                        p3 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a + n & b - n), Button).BackColor = Color.LawnGreen Then
                                        p4 -= 1
                                    End If
                                    CType(FindForm.Controls("Button" & a + n & b - n), Button).BackColor = Color.Red
                                    BA()
                                Next
                                'Ctype(FindForm.Controls("Button" & a & b), Button).Region = new Region(path)
                                p1 += i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    ElseIf pm = 4 And pt = 2 Then
                        If CType(FindForm.Controls("Button" & a + i & b - i), Button).BackColor = Color.SkyBlue Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    If CType(FindForm.Controls("Button" & a + n & b - n), Button).BackColor = Color.Red Then
                                        p1 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a + n & b - n), Button).BackColor = Color.Orange Then
                                        p3 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a + n & b - n), Button).BackColor = Color.LawnGreen Then
                                        p4 -= 1
                                    End If
                                    CType(FindForm.Controls("Button" & a + n & b - n), Button).BackColor = Color.SkyBlue
                                    BA()
                                Next
                                'Ctype(FindForm.Controls("Button" & a & b), Button).Region = new Region(path)
                                p2 += i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    ElseIf pm = 4 And pt = 3 Then
                        If CType(FindForm.Controls("Button" & a + i & b - i), Button).BackColor = Color.Orange Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    If CType(FindForm.Controls("Button" & a + n & b - n), Button).BackColor = Color.Red Then
                                        p1 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a + n & b - n), Button).BackColor = Color.SkyBlue Then
                                        p2 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a + n & b - n), Button).BackColor = Color.LawnGreen Then
                                        p4 -= 1
                                    End If
                                    CType(FindForm.Controls("Button" & a + n & b - n), Button).BackColor = Color.Orange
                                    BA()
                                Next
                                'Ctype(FindForm.Controls("Button" & a & b), Button).Region = new Region(path)
                                p3 += i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    ElseIf pm = 4 And pt = 4 Then
                        If CType(FindForm.Controls("Button" & a + i & b - i), Button).BackColor = Color.LawnGreen Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    If CType(FindForm.Controls("Button" & a + n & b - n), Button).BackColor = Color.Red Then
                                        p1 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a + n & b - n), Button).BackColor = Color.SkyBlue Then
                                        p2 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a + n & b - n), Button).BackColor = Color.Orange Then
                                        p3 -= 1
                                    End If
                                    CType(FindForm.Controls("Button" & a + n & b - n), Button).BackColor = Color.LawnGreen
                                    BA()
                                Next
                                'Ctype(FindForm.Controls("Button" & a & b), Button).Region = new Region(path)
                                p4 += i - 1
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
                    If CType(FindForm.Controls("Button" & a - i & b - i), Button).BackColor = Color.Green Or CType(FindForm.Controls("Button" & a - i & b - i), Button).BackColor = Color.Lime Then
                        Exit For
                    End If
                    If pm = 2 And pt = 1 Then
                        If CType(FindForm.Controls("Button" & a - i & b - i), Button).BackColor = Color.Black Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    CType(FindForm.Controls("Button" & a - n & b - n), Button).BackColor = Color.Black
                                    BA()
                                Next
                                'Ctype(FindForm.Controls("Button" & a & b), Button).Region = new Region(path)
                                p1 += i - 1
                                p2 -= i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    ElseIf pm = 2 And pt = 2 Then
                        If CType(FindForm.Controls("Button" & a - i & b - i), Button).BackColor = Color.White Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    CType(FindForm.Controls("Button" & a - n & b - n), Button).BackColor = Color.White
                                    BA()
                                Next
                                'Ctype(FindForm.Controls("Button" & a & b), Button).Region = new Region(path)
                                p1 -= i - 1
                                p2 += i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    ElseIf pm = 4 And pt = 1 Then
                        If CType(FindForm.Controls("Button" & a - i & b - i), Button).BackColor = Color.Red Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    If CType(FindForm.Controls("Button" & a - n & b - n), Button).BackColor = Color.SkyBlue Then
                                        p2 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a - n & b - n), Button).BackColor = Color.Orange Then
                                        p3 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a - n & b - n), Button).BackColor = Color.LawnGreen Then
                                        p4 -= 1
                                    End If
                                    CType(FindForm.Controls("Button" & a - n & b - n), Button).BackColor = Color.Red
                                    BA()
                                Next
                                'Ctype(FindForm.Controls("Button" & a & b), Button).Region = new Region(path)
                                p1 += i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    ElseIf pm = 4 And pt = 2 Then
                        If CType(FindForm.Controls("Button" & a - i & b - i), Button).BackColor = Color.SkyBlue Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    If CType(FindForm.Controls("Button" & a - n & b - n), Button).BackColor = Color.Red Then
                                        p1 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a - n & b - n), Button).BackColor = Color.Orange Then
                                        p3 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a - n & b - n), Button).BackColor = Color.LawnGreen Then
                                        p4 -= 1
                                    End If
                                    CType(FindForm.Controls("Button" & a - n & b - n), Button).BackColor = Color.SkyBlue
                                    BA()
                                Next
                                'Ctype(FindForm.Controls("Button" & a & b), Button).Region = new Region(path)
                                p2 += i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    ElseIf pm = 4 And pt = 3 Then
                        If CType(FindForm.Controls("Button" & a - i & b - i), Button).BackColor = Color.Orange Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    If CType(FindForm.Controls("Button" & a - n & b - n), Button).BackColor = Color.Red Then
                                        p1 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a - n & b - n), Button).BackColor = Color.SkyBlue Then
                                        p2 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a - n & b - n), Button).BackColor = Color.LawnGreen Then
                                        p4 -= 1
                                    End If
                                    CType(FindForm.Controls("Button" & a - n & b - n), Button).BackColor = Color.Orange
                                    BA()
                                Next
                                'Ctype(FindForm.Controls("Button" & a & b), Button).Region = new Region(path)
                                p3 += i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    ElseIf pm = 4 And pt = 4 Then
                        If CType(FindForm.Controls("Button" & a - i & b - i), Button).BackColor = Color.LawnGreen Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    If CType(FindForm.Controls("Button" & a - n & b - n), Button).BackColor = Color.Red Then
                                        p1 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a - n & b - n), Button).BackColor = Color.SkyBlue Then
                                        p2 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a - n & b - n), Button).BackColor = Color.Orange Then
                                        p3 -= 1
                                    End If
                                    CType(FindForm.Controls("Button" & a - n & b - n), Button).BackColor = Color.LawnGreen
                                    BA()
                                Next
                                'Ctype(FindForm.Controls("Button" & a & b), Button).Region = new Region(path)
                                p4 += i - 1
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
                    If CType(FindForm.Controls("Button" & a - i & b + i), Button).BackColor = Color.Green Or CType(FindForm.Controls("Button" & a - i & b + i), Button).BackColor = Color.Lime Then
                        Exit For
                    End If
                    If pm = 2 And pt = 1 Then
                        If CType(FindForm.Controls("Button" & a - i & b + i), Button).BackColor = Color.Black Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    CType(FindForm.Controls("Button" & a - n & b + n), Button).BackColor = Color.Black
                                    BA()
                                Next
                                'Ctype(FindForm.Controls("Button" & a & b), Button).Region = new Region(path)
                                p1 += i - 1
                                p2 -= i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    ElseIf pm = 2 And pt = 2 Then
                        If CType(FindForm.Controls("Button" & a - i & b + i), Button).BackColor = Color.White Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    CType(FindForm.Controls("Button" & a - n & b + n), Button).BackColor = Color.White
                                    BA()
                                Next
                                'Ctype(FindForm.Controls("Button" & a & b), Button).Region = new Region(path)
                                p1 -= i - 1
                                p2 += i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    ElseIf pm = 4 And pt = 1 Then
                        If CType(FindForm.Controls("Button" & a - i & b + i), Button).BackColor = Color.Red Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    If CType(FindForm.Controls("Button" & a - n & b + n), Button).BackColor = Color.SkyBlue Then
                                        p2 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a - n & b + n), Button).BackColor = Color.Orange Then
                                        p3 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a - n & b + n), Button).BackColor = Color.LawnGreen Then
                                        p4 -= 1
                                    End If
                                    CType(FindForm.Controls("Button" & a - n & b + n), Button).BackColor = Color.Red
                                    BA()
                                Next
                                'Ctype(FindForm.Controls("Button" & a & b), Button).Region = new Region(path)
                                p1 += i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    ElseIf pm = 4 And pt = 2 Then
                        If CType(FindForm.Controls("Button" & a - i & b + i), Button).BackColor = Color.SkyBlue Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    If CType(FindForm.Controls("Button" & a - n & b + n), Button).BackColor = Color.Red Then
                                        p1 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a - n & b + n), Button).BackColor = Color.Orange Then
                                        p3 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a - n & b + n), Button).BackColor = Color.LawnGreen Then
                                        p4 -= 1
                                    End If
                                    CType(FindForm.Controls("Button" & a - n & b + n), Button).BackColor = Color.SkyBlue
                                    BA()
                                Next
                                'Ctype(FindForm.Controls("Button" & a & b), Button).Region = new Region(path)
                                p2 += i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    ElseIf pm = 4 And pt = 3 Then
                        If CType(FindForm.Controls("Button" & a - i & b + i), Button).BackColor = Color.Orange Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    If CType(FindForm.Controls("Button" & a - n & b + n), Button).BackColor = Color.Red Then
                                        p1 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a - n & b + n), Button).BackColor = Color.SkyBlue Then
                                        p2 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a - n & b + n), Button).BackColor = Color.LawnGreen Then
                                        p4 -= 1
                                    End If
                                    CType(FindForm.Controls("Button" & a - n & b + n), Button).BackColor = Color.Orange
                                    BA()
                                Next
                                'Ctype(FindForm.Controls("Button" & a & b), Button).Region = new Region(path)
                                p3 += i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    ElseIf pm = 4 And pt = 4 Then
                        If CType(FindForm.Controls("Button" & a - i & b + i), Button).BackColor = Color.LawnGreen Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    If CType(FindForm.Controls("Button" & a - n & b + n), Button).BackColor = Color.Red Then
                                        p1 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a - n & b + n), Button).BackColor = Color.SkyBlue Then
                                        p2 -= 1
                                    End If
                                    If CType(FindForm.Controls("Button" & a - n & b + n), Button).BackColor = Color.Orange Then
                                        p3 -= 1
                                    End If
                                    CType(FindForm.Controls("Button" & a - n & b + n), Button).BackColor = Color.LawnGreen
                                    BA()
                                Next
                                'Ctype(FindForm.Controls("Button" & a & b), Button).Region = new Region(path)
                                p4 += i - 1
                                cb = 1
                            End If
                            Exit For
                        End If
                    End If
                End If
            Next
            'Reload
            If cb = 1 Then
                pnm = pt
                CT()
                EC()
            End If
        End If
    End Sub

    Sub BA()
        If sd = 0 Then
            Refresh()
            Threading.Thread.Sleep(200)
        End If
    End Sub

    Sub LG()
        For c = 1 To 8
            For d = 1 To 8
                If CType(FindForm.Controls("Button" & c & d), Button).BackColor = Color.Lime Then
                    CType(FindForm.Controls("Button" & c & d), Button).BackColor = Color.Green
                End If
            Next
        Next
    End Sub

    Sub GL()
        cx = 0
        For c = 1 To 8
            For d = 1 To 8
                If CType(FindForm.Controls("Button" & c & d), Button).BackColor = Color.Green Then
                    cb = 0
                    'Right
                    For i = 1 To 7
                        If d + i > 8 Then
                            Exit For
                        Else
                            If CType(FindForm.Controls("Button" & c & d + i), Button).BackColor = Color.Green Or CType(FindForm.Controls("Button" & c & d + i), Button).BackColor = Color.Lime Then
                                Exit For
                            End If
                            If pm = 2 And pt = 1 Then
                                If CType(FindForm.Controls("Button" & c & d + i), Button).BackColor = Color.Black Then
                                    If i <> 1 Then
                                        cb = 1
                                    End If
                                    Exit For
                                End If
                            ElseIf pm = 2 And pt = 2 Then
                                If CType(FindForm.Controls("Button" & c & d + i), Button).BackColor = Color.White Then
                                    If i <> 1 Then
                                        cb = 1
                                    End If
                                    Exit For
                                End If
                            ElseIf pm = 4 And pt = 1 Then
                                If CType(FindForm.Controls("Button" & c & d + i), Button).BackColor = Color.Red Then
                                    If i <> 1 Then
                                        cb = 1
                                    End If
                                    Exit For
                                End If
                            ElseIf pm = 4 And pt = 2 Then
                                If CType(FindForm.Controls("Button" & c & d + i), Button).BackColor = Color.SkyBlue Then
                                    If i <> 1 Then
                                        cb = 1
                                    End If
                                    Exit For
                                End If
                            ElseIf pm = 4 And pt = 3 Then
                                If CType(FindForm.Controls("Button" & c & d + i), Button).BackColor = Color.Orange Then
                                    If i <> 1 Then
                                        cb = 1
                                    End If
                                    Exit For
                                End If
                            ElseIf pm = 4 And pt = 4 Then
                                If CType(FindForm.Controls("Button" & c & d + i), Button).BackColor = Color.LawnGreen Then
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
                            If CType(FindForm.Controls("Button" & c + i & d), Button).BackColor = Color.Green Or CType(FindForm.Controls("Button" & c + i & d), Button).BackColor = Color.Lime Then
                                Exit For
                            End If
                            If pm = 2 And pt = 1 Then
                                If CType(FindForm.Controls("Button" & c + i & d), Button).BackColor = Color.Black Then
                                    If i <> 1 Then
                                        cb = 1
                                    End If
                                    Exit For
                                End If
                            ElseIf pm = 2 And pt = 2 Then
                                If CType(FindForm.Controls("Button" & c + i & d), Button).BackColor = Color.White Then
                                    If i <> 1 Then
                                        cb = 1
                                    End If
                                    Exit For
                                End If
                            ElseIf pm = 4 And pt = 1 Then
                                If CType(FindForm.Controls("Button" & c + i & d), Button).BackColor = Color.Red Then
                                    If i <> 1 Then
                                        cb = 1
                                    End If
                                    Exit For
                                End If
                            ElseIf pm = 4 And pt = 2 Then
                                If CType(FindForm.Controls("Button" & c + i & d), Button).BackColor = Color.SkyBlue Then
                                    If i <> 1 Then
                                        cb = 1
                                    End If
                                    Exit For
                                End If
                            ElseIf pm = 4 And pt = 3 Then
                                If CType(FindForm.Controls("Button" & c + i & d), Button).BackColor = Color.Orange Then
                                    If i <> 1 Then
                                        cb = 1
                                    End If
                                    Exit For
                                End If
                            ElseIf pm = 4 And pt = 4 Then
                                If CType(FindForm.Controls("Button" & c + i & d), Button).BackColor = Color.LawnGreen Then
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
                            If CType(FindForm.Controls("Button" & c & d - i), Button).BackColor = Color.Green Or CType(FindForm.Controls("Button" & c & d - i), Button).BackColor = Color.Lime Then
                                Exit For
                            End If
                            If pm = 2 And pt = 1 Then
                                If CType(FindForm.Controls("Button" & c & d - i), Button).BackColor = Color.Black Then
                                    If i <> 1 Then
                                        cb = 1
                                    End If
                                    Exit For
                                End If
                            ElseIf pm = 2 And pt = 2 Then
                                If CType(FindForm.Controls("Button" & c & d - i), Button).BackColor = Color.White Then
                                    If i <> 1 Then
                                        cb = 1
                                    End If
                                    Exit For
                                End If
                            ElseIf pm = 4 And pt = 1 Then
                                If CType(FindForm.Controls("Button" & c & d - i), Button).BackColor = Color.Red Then
                                    If i <> 1 Then
                                        cb = 1
                                    End If
                                    Exit For
                                End If
                            ElseIf pm = 4 And pt = 2 Then
                                If CType(FindForm.Controls("Button" & c & d - i), Button).BackColor = Color.SkyBlue Then
                                    If i <> 1 Then
                                        cb = 1
                                    End If
                                    Exit For
                                End If
                            ElseIf pm = 4 And pt = 3 Then
                                If CType(FindForm.Controls("Button" & c & d - i), Button).BackColor = Color.Orange Then
                                    If i <> 1 Then
                                        cb = 1
                                    End If
                                    Exit For
                                End If
                            ElseIf pm = 4 And pt = 4 Then
                                If CType(FindForm.Controls("Button" & c & d - i), Button).BackColor = Color.LawnGreen Then
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
                            If CType(FindForm.Controls("Button" & c - i & d), Button).BackColor = Color.Green Or CType(FindForm.Controls("Button" & c - i & d), Button).BackColor = Color.Lime Then
                                Exit For
                            End If
                            If pm = 2 And pt = 1 Then
                                If CType(FindForm.Controls("Button" & c - i & d), Button).BackColor = Color.Black Then
                                    If i <> 1 Then
                                        cb = 1
                                    End If
                                    Exit For
                                End If
                            ElseIf pm = 2 And pt = 2 Then
                                If CType(FindForm.Controls("Button" & c - i & d), Button).BackColor = Color.White Then
                                    If i <> 1 Then
                                        cb = 1
                                    End If
                                    Exit For
                                End If
                            ElseIf pm = 4 And pt = 1 Then
                                If CType(FindForm.Controls("Button" & c - i & d), Button).BackColor = Color.Red Then
                                    If i <> 1 Then
                                        cb = 1
                                    End If
                                    Exit For
                                End If
                            ElseIf pm = 4 And pt = 2 Then
                                If CType(FindForm.Controls("Button" & c - i & d), Button).BackColor = Color.SkyBlue Then
                                    If i <> 1 Then
                                        cb = 1
                                    End If
                                    Exit For
                                End If
                            ElseIf pm = 4 And pt = 3 Then
                                If CType(FindForm.Controls("Button" & c - i & d), Button).BackColor = Color.Orange Then
                                    If i <> 1 Then
                                        cb = 1
                                    End If
                                    Exit For
                                End If
                            ElseIf pm = 4 And pt = 4 Then
                                If CType(FindForm.Controls("Button" & c - i & d), Button).BackColor = Color.LawnGreen Then
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
                            If CType(FindForm.Controls("Button" & c + i & d + i), Button).BackColor = Color.Green Or CType(FindForm.Controls("Button" & c + i & d + i), Button).BackColor = Color.Lime Then
                                Exit For
                            End If
                            If pm = 2 And pt = 1 Then
                                If CType(FindForm.Controls("Button" & c + i & d + i), Button).BackColor = Color.Black Then
                                    If i <> 1 Then
                                        cb = 1
                                    End If
                                    Exit For
                                End If
                            ElseIf pm = 2 And pt = 2 Then
                                If CType(FindForm.Controls("Button" & c + i & d + i), Button).BackColor = Color.White Then
                                    If i <> 1 Then
                                        cb = 1
                                    End If
                                    Exit For
                                End If
                            ElseIf pm = 4 And pt = 1 Then
                                If CType(FindForm.Controls("Button" & c + i & d + i), Button).BackColor = Color.Red Then
                                    If i <> 1 Then
                                        cb = 1
                                    End If
                                    Exit For
                                End If
                            ElseIf pm = 4 And pt = 2 Then
                                If CType(FindForm.Controls("Button" & c + i & d + i), Button).BackColor = Color.SkyBlue Then
                                    If i <> 1 Then
                                        cb = 1
                                    End If
                                    Exit For
                                End If
                            ElseIf pm = 4 And pt = 3 Then
                                If CType(FindForm.Controls("Button" & c + i & d + i), Button).BackColor = Color.Orange Then
                                    If i <> 1 Then
                                        cb = 1
                                    End If
                                    Exit For
                                End If
                            ElseIf pm = 4 And pt = 4 Then
                                If CType(FindForm.Controls("Button" & c + i & d + i), Button).BackColor = Color.LawnGreen Then
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
                            If CType(FindForm.Controls("Button" & c + i & d - i), Button).BackColor = Color.Green Or CType(FindForm.Controls("Button" & c + i & d - i), Button).BackColor = Color.Lime Then
                                Exit For
                            End If
                            If pm = 2 And pt = 1 Then
                                If CType(FindForm.Controls("Button" & c + i & d - i), Button).BackColor = Color.Black Then
                                    If i <> 1 Then
                                        cb = 1
                                    End If
                                    Exit For
                                End If
                            ElseIf pm = 2 And pt = 2 Then
                                If CType(FindForm.Controls("Button" & c + i & d - i), Button).BackColor = Color.White Then
                                    If i <> 1 Then
                                        cb = 1
                                    End If
                                    Exit For
                                End If
                            ElseIf pm = 4 And pt = 1 Then
                                If CType(FindForm.Controls("Button" & c + i & d - i), Button).BackColor = Color.Red Then
                                    If i <> 1 Then
                                        cb = 1
                                    End If
                                    Exit For
                                End If
                            ElseIf pm = 4 And pt = 2 Then
                                If CType(FindForm.Controls("Button" & c + i & d - i), Button).BackColor = Color.SkyBlue Then
                                    If i <> 1 Then
                                        cb = 1
                                    End If
                                    Exit For
                                End If
                            ElseIf pm = 4 And pt = 3 Then
                                If CType(FindForm.Controls("Button" & c + i & d - i), Button).BackColor = Color.Orange Then
                                    If i <> 1 Then
                                        cb = 1
                                    End If
                                    Exit For
                                End If
                            ElseIf pm = 4 And pt = 4 Then
                                If CType(FindForm.Controls("Button" & c + i & d - i), Button).BackColor = Color.LawnGreen Then
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
                            If CType(FindForm.Controls("Button" & c - i & d - i), Button).BackColor = Color.Green Or CType(FindForm.Controls("Button" & c - i & d - i), Button).BackColor = Color.Lime Then
                                Exit For
                            End If
                            If pm = 2 And pt = 1 Then
                                If CType(FindForm.Controls("Button" & c - i & d - i), Button).BackColor = Color.Black Then
                                    If i <> 1 Then
                                        cb = 1
                                    End If
                                    Exit For
                                End If
                            ElseIf pm = 2 And pt = 2 Then
                                If CType(FindForm.Controls("Button" & c - i & d - i), Button).BackColor = Color.White Then
                                    If i <> 1 Then
                                        cb = 1
                                    End If
                                    Exit For
                                End If
                            ElseIf pm = 4 And pt = 1 Then
                                If CType(FindForm.Controls("Button" & c - i & d - i), Button).BackColor = Color.Red Then
                                    If i <> 1 Then
                                        cb = 1
                                    End If
                                    Exit For
                                End If
                            ElseIf pm = 4 And pt = 2 Then
                                If CType(FindForm.Controls("Button" & c - i & d - i), Button).BackColor = Color.SkyBlue Then
                                    If i <> 1 Then
                                        cb = 1
                                    End If
                                    Exit For
                                End If
                            ElseIf pm = 4 And pt = 3 Then
                                If CType(FindForm.Controls("Button" & c - i & d - i), Button).BackColor = Color.Orange Then
                                    If i <> 1 Then
                                        cb = 1
                                    End If
                                    Exit For
                                End If
                            ElseIf pm = 4 And pt = 4 Then
                                If CType(FindForm.Controls("Button" & c - i & d - i), Button).BackColor = Color.LawnGreen Then
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
                            If CType(FindForm.Controls("Button" & c - i & d + i), Button).BackColor = Color.Green Or CType(FindForm.Controls("Button" & c - i & d + i), Button).BackColor = Color.Lime Then
                                Exit For
                            End If
                            If pm = 2 And pt = 1 Then
                                If CType(FindForm.Controls("Button" & c - i & d + i), Button).BackColor = Color.Black Then
                                    If i <> 1 Then
                                        cb = 1
                                    End If
                                    Exit For
                                End If
                            ElseIf pm = 2 And pt = 2 Then
                                If CType(FindForm.Controls("Button" & c - i & d + i), Button).BackColor = Color.White Then
                                    If i <> 1 Then
                                        cb = 1
                                    End If
                                    Exit For
                                End If
                            ElseIf pm = 4 And pt = 1 Then
                                If CType(FindForm.Controls("Button" & c - i & d + i), Button).BackColor = Color.Red Then
                                    If i <> 1 Then
                                        cb = 1
                                    End If
                                    Exit For
                                End If
                            ElseIf pm = 4 And pt = 2 Then
                                If CType(FindForm.Controls("Button" & c - i & d + i), Button).BackColor = Color.SkyBlue Then
                                    If i <> 1 Then
                                        cb = 1
                                    End If
                                    Exit For
                                End If
                            ElseIf pm = 4 And pt = 3 Then
                                If CType(FindForm.Controls("Button" & c - i & d + i), Button).BackColor = Color.Orange Then
                                    If i <> 1 Then
                                        cb = 1
                                    End If
                                    Exit For
                                End If
                            ElseIf pm = 4 And pt = 4 Then
                                If CType(FindForm.Controls("Button" & c - i & d + i), Button).BackColor = Color.LawnGreen Then
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
                        CType(FindForm.Controls("Button" & c & d), Button).BackColor = Color.Lime
                    End If
                End If
            Next
        Next
    End Sub

    Sub CT()
        If pm = 2 And pt = 1 Then
            p1 += 1
            pt = 2
            LP.Text = "Player White's Turn"
            LP.ForeColor = Color.White
            fp.L1.Text = "Player Black " & p1 & " (" & fp1 & ")"
            fp.L2.Text = "Player White " & p2 & " (" & fp2 & ")"
            fp.P1.Hide()
            fp.P2.Show()
            fp.Refresh()
        ElseIf pm = 2 And pt = 2 Then
            p2 += 1
            pt = 1
            LP.Text = "Player Black's Turn"
            LP.ForeColor = Color.Black
            fp.L1.Text = "Player Black " & p1 & " (" & fp1 & ")"
            fp.L2.Text = "Player White " & p2 & " (" & fp2 & ")"
            fp.P1.Show()
            fp.P2.Hide()
            fp.Refresh()
        ElseIf pm = 4 And pt = 1 Then
            p1 += 1
            pt = 2
            LP.Text = "Player Blue's Turn"
            LP.ForeColor = Color.SkyBlue
            fp.L1.Text = "Player Red " & p1 & " (" & fp1 & ")"
            fp.L2.Text = "Player Blue " & p2 & " (" & fp2 & ")"
            fp.L3.Text = "Player Yellow " & p3 & " (" & fp3 & ")"
            fp.L4.Text = "Player Green " & p4 & " (" & fp4 & ")"
            fp.P1.Hide()
            fp.P2.Show()
            fp.P3.Hide()
            fp.P4.Hide()
            fp.Refresh()
        ElseIf pm = 4 And pt = 2 Then
            p2 += 1
            pt = 3
            LP.Text = "Player Yellow's Turn"
            LP.ForeColor = Color.Orange
            fp.L1.Text = "Player Red " & p1 & " (" & fp1 & ")"
            fp.L2.Text = "Player Blue " & p2 & " (" & fp2 & ")"
            fp.L3.Text = "Player Yellow " & p3 & " (" & fp3 & ")"
            fp.L4.Text = "Player Green " & p4 & " (" & fp4 & ")"
            fp.P1.Hide()
            fp.P2.Hide()
            fp.P3.Show()
            fp.P4.Hide()
            fp.Refresh()
        ElseIf pm = 4 And pt = 3 Then
            p3 += 1
            pt = 4
            LP.Text = "Player Green's Turn"
            LP.ForeColor = Color.LawnGreen
            fp.L1.Text = "Player Red " & p1 & " (" & fp1 & ")"
            fp.L2.Text = "Player Blue " & p2 & " (" & fp2 & ")"
            fp.L3.Text = "Player Yellow " & p3 & " (" & fp3 & ")"
            fp.L4.Text = "Player Green " & p4 & " (" & fp4 & ")"
            fp.P1.Hide()
            fp.P2.Hide()
            fp.P3.Hide()
            fp.P4.Show()
            fp.Refresh()
        ElseIf pm = 4 And pt = 4 Then
            p4 += 1
            pt = 1
            LP.Text = "Player Red's Turn"
            LP.ForeColor = Color.Red
            fp.L1.Text = "Player Red " & p1 & " (" & fp1 & ")"
            fp.L2.Text = "Player Blue " & p2 & " (" & fp2 & ")"
            fp.L3.Text = "Player Yellow " & p3 & " (" & fp3 & ")"
            fp.L4.Text = "Player Green " & p4 & " (" & fp4 & ")"
            fp.P1.Show()
            fp.P2.Hide()
            fp.P3.Hide()
            fp.P4.Hide()
            fp.Refresh()
        End If
    End Sub

    Sub EC()
        For p = 1 To pm
            LG()
            GL()
            If cx >= 1 Then
                Exit Sub
            End If
            If pm = 2 And pt = 1 Then
                pt = 2
                LP.Text = "Player White's Turn"
                fp.P1.Hide()
                fp.P2.Show()
                LP.ForeColor = Color.White
            ElseIf pm = 2 And pt = 2 Then
                pt = 1
                LP.Text = "Player Black's Turn"
                LP.ForeColor = Color.Black
                fp.P1.Show()
                fp.P2.Hide()
            ElseIf pm = 4 And pt = 1 Then
                pt = 2
                LP.Text = "Player Blue's Turn"
                LP.ForeColor = Color.SkyBlue
                fp.P1.Hide()
                fp.P2.Show()
                fp.P3.Hide()
                fp.P4.Hide()
            ElseIf pm = 4 And pt = 2 Then
                pt = 3
                LP.Text = "Player Yellow's Turn"
                LP.ForeColor = Color.Orange
                fp.P1.Hide()
                fp.P2.Hide()
                fp.P3.Show()
                fp.P4.Hide()
            ElseIf pm = 4 And pt = 3 Then
                pt = 4
                LP.Text = "Player Green's Turn"
                LP.ForeColor = Color.LawnGreen
                fp.P1.Hide()
                fp.P2.Hide()
                fp.P3.Hide()
                fp.P4.Show()
            ElseIf pm = 4 And pt = 4 Then
                pt = 1
                LP.Text = "Player Red's Turn"
                LP.ForeColor = Color.Red
                fp.P1.Show()
                fp.P2.Hide()
                fp.P3.Hide()
                fp.P4.Hide()
            End If
        Next
        pt = 0
        LP.Text = "Result"
        If pm = 2 Then
            LP.ForeColor = Color.Lime
        Else
            LP.ForeColor = Color.Black
        End If
        fp.P1.Hide()
        fp.P2.Hide()
        fp.P3.Hide()
        fp.P4.Hide()
    End Sub

    Private Sub BDP_Click(sender As Object, e As EventArgs) Handles BDP.Click
        If chn = thn Then
            MsgBox("This is the Oldest Game History Data!")
        Else
            chn += 1
            CBH.SelectedIndex = chn - 1
        End If
    End Sub

    Private Sub BDN_Click(sender As Object, e As EventArgs) Handles BDN.Click
        If chn = 1 Then
            MsgBox("This is the Newest Game History Data!")
        Else
            chn -= 1
            CBH.SelectedIndex = chn - 1
        End If
    End Sub

    Private Sub CBH_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBH.SelectedIndexChanged
        chn = CBH.SelectedIndex + 1
        Dim sr As New StreamReader("Data\H" & pm & ".ghfo", System.Text.Encoding.GetEncoding("shift_jis"))
        sr.ReadLine()
        For i As ULong = 1 To thn - chn + 1
            rt = sr.ReadLine
        Next
        sr.Close()
        BR()
    End Sub

    Sub BR()
        cs = 0
        st = rt.Substring(rt.IndexOf("#") + 1, rt.IndexOf("!") - rt.IndexOf("#") - 1)
        Text = "History - " & rt.Substring(rt.IndexOf("?") + 1, rt.IndexOf("#") - rt.IndexOf("?") - 1)
        ts = st.Length / 2
        If pm = 2 Then
            fp1 = CByte(rt.Substring(rt.IndexOf("!") + 1, 2))
            fp2 = CByte(rt.Substring(rt.IndexOf("!") + 3, 2))
            fp.L1.Text = "Player Black 2 (" & fp1 & ")"
            fp.L2.Text = "Player White 2 (" & fp2 & ")"
        ElseIf pm = 4 Then
            fp1 = CByte(rt.Substring(rt.IndexOf("!") + 1, 2))
            fp2 = CByte(rt.Substring(rt.IndexOf("!") + 3, 2))
            fp3 = CByte(rt.Substring(rt.IndexOf("!") + 5, 2))
            fp4 = CByte(rt.Substring(rt.IndexOf("!") + 7, 2))
            fp.L1.Text = "Player Red 2 (" & fp1 & ")"
            fp.L2.Text = "Player Blue 2 (" & fp2 & ")"
            fp.L3.Text = "Player Yellow 2 (" & fp3 & ")"
            fp.L4.Text = "Player Green 2 (" & fp4 & ")"
        End If
        For c = 1 To 8
            For d = 1 To 8
                CType(FindForm.Controls("Button" & c & d), Button).BackColor = Color.Green
                CType(FindForm.Controls("Button" & c & d), Button).Region = New Region()
            Next
        Next
        If pm = 2 Then
            Button44.BackColor = Color.White
            Button45.BackColor = Color.Black
            Button54.BackColor = Color.Black
            Button55.BackColor = Color.White
            Button44.Region = New Region(path)
            Button45.Region = New Region(path)
            Button54.Region = New Region(path)
            Button55.Region = New Region(path)
            LP.Text = "Player Black's Turn"
            LP.ForeColor = Color.Black
            p1 = 2
            p2 = 2
            apm(0, 4, 4) = 2
            apm(0, 4, 5) = 1
            apm(0, 5, 4) = 1
            apm(0, 5, 5) = 2
            apm(0, 0, 0) = 1
            apm(0, 0, 1) = 2
            apm(0, 0, 2) = 2
        ElseIf pm = 4 Then
            Button44.BackColor = Color.Red
            Button45.BackColor = Color.SkyBlue
            Button54.BackColor = Color.Orange
            Button55.BackColor = Color.LawnGreen
            Button65.BackColor = Color.Red
            Button53.BackColor = Color.SkyBlue
            Button46.BackColor = Color.Orange
            Button34.BackColor = Color.LawnGreen
            Button44.Region = New Region(path)
            Button45.Region = New Region(path)
            Button54.Region = New Region(path)
            Button55.Region = New Region(path)
            Button65.Region = New Region(path)
            Button53.Region = New Region(path)
            Button46.Region = New Region(path)
            Button34.Region = New Region(path)
            LP.Text = "Player Red's Turn"
            LP.ForeColor = Color.Red
            p1 = 2
            p2 = 2
            p3 = 2
            p4 = 2
            apm(0, 4, 4) = 1
            apm(0, 4, 5) = 2
            apm(0, 5, 4) = 3
            apm(0, 5, 5) = 4
            apm(0, 6, 5) = 1
            apm(0, 5, 3) = 2
            apm(0, 4, 6) = 3
            apm(0, 3, 4) = 4
            apm(0, 0, 0) = 1
            apm(0, 0, 1) = 2
            apm(0, 0, 2) = 2
            apm(0, 0, 3) = 2
            apm(0, 0, 4) = 2
        End If
        pt = 1
        pnm = 1
        sd = 0
        EC()
        fp.P1.Show()
        fp.P2.Hide()
        fp.P3.Hide()
        fp.P4.Hide()
    End Sub

    Private Sub BF_Click(sender As Object, e As EventArgs) Handles BF.Click
        BEF()
        If cs = 0 Then
            MsgBox("This is the First Step!")
        Else
            BR()
        End If
        BET()
    End Sub

    Private Sub BP_Click(sender As Object, e As EventArgs) Handles BP.Click
        BEF()
        If cs = 0 Then
            MsgBox("This is the First Step!")
        Else
            cs -= 1
            LG()
            For ix = 1 To 8
                For iy = 1 To 8
                    If pm = 2 Then
                        Select Case apm(cs, ix, iy)
                            Case 1
                                CType(FindForm.Controls("Button" & ix & iy), Button).BackColor = Color.Black
                            Case 2
                                CType(FindForm.Controls("Button" & ix & iy), Button).BackColor = Color.White
                            Case Else
                                CType(FindForm.Controls("Button" & ix & iy), Button).BackColor = Color.Green
                                CType(FindForm.Controls("Button" & ix & iy), Button).Region = New Region()
                        End Select
                    ElseIf pm = 4 Then
                        Select Case apm(cs, ix, iy)
                            Case 1
                                CType(FindForm.Controls("Button" & ix & iy), Button).BackColor = Color.Red
                            Case 2
                                CType(FindForm.Controls("Button" & ix & iy), Button).BackColor = Color.SkyBlue
                            Case 3
                                CType(FindForm.Controls("Button" & ix & iy), Button).BackColor = Color.Orange
                            Case 4
                                CType(FindForm.Controls("Button" & ix & iy), Button).BackColor = Color.LawnGreen
                            Case Else
                                CType(FindForm.Controls("Button" & ix & iy), Button).BackColor = Color.Green
                                CType(FindForm.Controls("Button" & ix & iy), Button).Region = New Region()
                        End Select
                    End If
                Next
            Next
            pt = apm(cs, 0, 0)
            GL()
            p1 = apm(cs, 0, 1)
            p2 = apm(cs, 0, 2)
            If pm = 2 Then
                Select Case pt
                    Case 1
                        LP.Text = "Player Black's Turn"
                        LP.ForeColor = Color.Black
                        fp.L1.Text = "Player Black " & p1 & " (" & fp1 & ")"
                        fp.L2.Text = "Player White " & p2 & " (" & fp2 & ")"
                        fp.P1.Show()
                        fp.P2.Hide()
                        fp.Refresh()
                    Case 2
                        LP.Text = "Player White's Turn"
                        LP.ForeColor = Color.White
                        fp.L1.Text = "Player Black " & p1 & " (" & fp1 & ")"
                        fp.L2.Text = "Player White " & p2 & " (" & fp2 & ")"
                        fp.P1.Hide()
                        fp.P2.Show()
                        fp.Refresh()
                End Select
            ElseIf pm = 4 Then
                p3 = apm(cs, 0, 3)
                p4 = apm(cs, 0, 4)
                Select Case pt
                    Case 1
                        LP.Text = "Player Red's Turn"
                        LP.ForeColor = Color.Red
                        fp.L1.Text = "Player Red " & p1 & " (" & fp1 & ")"
                        fp.L2.Text = "Player Blue " & p2 & " (" & fp2 & ")"
                        fp.L3.Text = "Player Yellow " & p3 & " (" & fp3 & ")"
                        fp.L4.Text = "Player Green " & p4 & " (" & fp4 & ")"
                        fp.P1.Show()
                        fp.P2.Hide()
                        fp.P3.Hide()
                        fp.P4.Hide()
                        fp.Refresh()
                    Case 2
                        LP.Text = "Player Blue's Turn"
                        LP.ForeColor = Color.SkyBlue
                        fp.L1.Text = "Player Red " & p1 & " (" & fp1 & ")"
                        fp.L2.Text = "Player Blue " & p2 & " (" & fp2 & ")"
                        fp.L3.Text = "Player Yellow " & p3 & " (" & fp3 & ")"
                        fp.L4.Text = "Player Green " & p4 & " (" & fp4 & ")"
                        fp.P1.Hide()
                        fp.P2.Show()
                        fp.P3.Hide()
                        fp.P4.Hide()
                        fp.Refresh()
                    Case 3
                        LP.Text = "Player Yellow's Turn"
                        LP.ForeColor = Color.Orange
                        fp.L1.Text = "Player Red " & p1 & " (" & fp1 & ")"
                        fp.L2.Text = "Player Blue " & p2 & " (" & fp2 & ")"
                        fp.L3.Text = "Player Yellow " & p3 & " (" & fp3 & ")"
                        fp.L4.Text = "Player Green " & p4 & " (" & fp4 & ")"
                        fp.P1.Hide()
                        fp.P2.Hide()
                        fp.P3.Show()
                        fp.P4.Hide()
                        fp.Refresh()
                    Case 4
                        LP.Text = "Player Green's Turn"
                        LP.ForeColor = Color.LawnGreen
                        fp.L1.Text = "Player Red " & p1 & " (" & fp1 & ")"
                        fp.L2.Text = "Player Blue " & p2 & " (" & fp2 & ")"
                        fp.L3.Text = "Player Yellow " & p3 & " (" & fp3 & ")"
                        fp.L4.Text = "Player Green " & p4 & " (" & fp4 & ")"
                        fp.P1.Hide()
                        fp.P2.Hide()
                        fp.P3.Hide()
                        fp.P4.Show()
                        fp.Refresh()
                End Select
            End If
        End If
        BET()
    End Sub

    Private Sub BN_Click(sender As Object, e As EventArgs) Handles BN.Click
        BEF()
        If cs = ts Then
            MsgBox("This is the Last Step!")
        Else
            cs += 1
            BC(st.Substring(cs * 2 - 2, 2))
            For ix = 1 To 8
                For iy = 1 To 8
                    If pm = 2 Then
                        Select Case CType(FindForm.Controls("Button" & ix & iy), Button).BackColor
                            Case Color.Black
                                apm(cs, ix, iy) = 1
                            Case Color.White
                                apm(cs, ix, iy) = 2
                        End Select
                    ElseIf pm = 4 Then
                        Select Case CType(FindForm.Controls("Button" & ix & iy), Button).BackColor
                            Case Color.Red
                                apm(cs, ix, iy) = 1
                            Case Color.SkyBlue
                                apm(cs, ix, iy) = 2
                            Case Color.Orange
                                apm(cs, ix, iy) = 3
                            Case Color.LawnGreen
                                apm(cs, ix, iy) = 4
                        End Select
                    End If
                Next
            Next
            apm(cs, 0, 0) = pt
            apm(cs, 0, 1) = p1
            apm(cs, 0, 2) = p2
            If pm = 4 Then
                apm(cs, 0, 3) = p3
                apm(cs, 0, 4) = p4
            End If
        End If
        BET()
    End Sub

    Private Sub BL_Click(sender As Object, e As EventArgs) Handles BL.Click
        BEF()
        If cs = ts Then
            MsgBox("This is the Last Step!")
        Else
            sd = 1
            For i = cs + 1 To ts
                BC(st.Substring(i * 2 - 2, 2))
                For ix = 1 To 8
                    For iy = 1 To 8
                        If pm = 2 Then
                            Select Case CType(FindForm.Controls("Button" & ix & iy), Button).BackColor
                                Case Color.Black
                                    apm(i, ix, iy) = 1
                                Case Color.White
                                    apm(i, ix, iy) = 2
                            End Select
                        ElseIf pm = 4 Then
                            Select Case CType(FindForm.Controls("Button" & ix & iy), Button).BackColor
                                Case Color.Red
                                    apm(i, ix, iy) = 1
                                Case Color.SkyBlue
                                    apm(i, ix, iy) = 2
                                Case Color.Orange
                                    apm(i, ix, iy) = 3
                                Case Color.LawnGreen
                                    apm(i, ix, iy) = 4
                            End Select
                        End If
                    Next
                Next
                apm(i, 0, 0) = pt
                apm(i, 0, 1) = p1
                apm(i, 0, 2) = p2
                If pm = 4 Then
                    apm(i, 0, 3) = p3
                    apm(i, 0, 4) = p4
                End If
            Next
            cs = ts
            sd = 0
        End If
        BET()
    End Sub

    Sub BET()
        BDP.Enabled = True
        BDN.Enabled = True
        CBH.Enabled = True
        BF.Enabled = True
        BP.Enabled = True
        BN.Enabled = True
        BL.Enabled = True
    End Sub

    Sub BEF()
        BDP.Enabled = False
        BDN.Enabled = False
        CBH.Enabled = False
        BF.Enabled = False
        BP.Enabled = False
        BN.Enabled = False
        BL.Enabled = False
    End Sub

    Private Sub Button_Click(sender As Object, e As EventArgs) Handles Button88.Click, Button87.Click, Button86.Click, Button85.Click, Button84.Click, Button83.Click, Button82.Click, Button81.Click, Button78.Click, Button77.Click, Button76.Click, Button75.Click, Button74.Click, Button73.Click, Button72.Click, Button71.Click, Button68.Click, Button67.Click, Button66.Click, Button65.Click, Button64.Click, Button63.Click, Button62.Click, Button61.Click, Button58.Click, Button57.Click, Button56.Click, Button55.Click, Button54.Click, Button53.Click, Button52.Click, Button51.Click, Button48.Click, Button47.Click, Button46.Click, Button45.Click, Button44.Click, Button43.Click, Button42.Click, Button41.Click, Button38.Click, Button37.Click, Button36.Click, Button35.Click, Button34.Click, Button33.Click, Button32.Click, Button31.Click, Button28.Click, Button27.Click, Button26.Click, Button25.Click, Button24.Click, Button23.Click, Button22.Click, Button21.Click, Button18.Click, Button17.Click, Button16.Click, Button15.Click, Button14.Click, Button13.Click, Button12.Click, Button11.Click
        If sender.Backcolor = Color.Lime Then
            fp.Hide()
            Dim fg As New Game
            fg.pm = pm
            fg.ne = 0
            fg.cu = 0
            fg.ae = 0
            fg.he = 1
            fg.hp = st.Substring(0, cs * 2) & sender.Name.substring(6, 2)
            fg.ShowDialog(Me)
            fg.Dispose()
            fp.Show()
        End If
    End Sub

    Private Sub Game_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        fp.Hide()
    End Sub
End Class