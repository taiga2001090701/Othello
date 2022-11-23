Imports System.Drawing
Imports System.IO
Imports System.Net.Sockets
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports Scripting

Public Class Game
    'Form
    Dim fp As New Player
    Dim fc As New Connect
    Dim fr As New Result
    Dim fu As New Chat
    'Argument
    Public pm, ne, sc, cu, ae, afl, he As Byte 'Player Number, Network Enabled, Server or Client, Chat Using, AI Enabled, AI Former or Latter, History Enabled
    Dim a1, a2 As Byte 'battle AI algorithm number, study AI algorithm number
    Public hp As String 'History Patterns 
    'Common
    Dim a, b As Byte 'vertical button number, horizontal button number
    Dim p1, p2, p3, p4 As Byte 'Player 1-4 points
    Dim pt, pnm, ge, sd As Byte 'Player Turn, Player Number Memory, Game End, Slow Disabled
    Dim cb, cx As Byte 'Check Button clicked, Check Exception
    Dim bs, bh, hn As String 'Button name String, Button History, History Name
    'Online
    Public sh, ch, ch1, ch2, ch3 As String 'Server Host name, Client Host name, Client Host name 1-3
    Public sp, cp, cp1, cp2, cp3 As Integer 'Server Port number, Client Port number, Client Port number 1-3
    Dim ce, nc, scn As Byte 'player Click Enabled, Network Control enabled, Server and Client Number
    'AI Common
    Dim gec, brs, aic, wtp(1) As Byte 'Game End Check, Byte of Rundom number Save, AI Circle mode number, Where To Put 
    Dim grs As String 'Game Result String
    'AI Algorithm 1 & 2 Parameter
    Dim aidl As ULong 'AI Data Length
    Dim aim, ain, eon As Byte
    Dim aid, aip, ait, aie As String
    'AI Algorithm 3 Parameter
    Dim bpo, bpot As Byte
    Dim bai, bait As Byte
    Dim ail, ailt As String
    Dim baiu, bais, baiw, baig, baio As Byte
    Dim aiu, ais, aiw, aig, aio As String
    Dim aiwt, aiwtt, aiox As String
    Dim ss(8, 8), sst(8, 8), sstt(8, 8) As Byte 'Stone Set, Stone Set Temporary, Stone Set Temporary Temporary
    'Component
    Dim path As New Drawing2D.GraphicsPath()
    Dim bt As Button
    Dim rdm As New Random(Date.Now.Second)
    Private udpClient, udpx, udp1, udp2, udp3 As UdpClient
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
            If ae = 1 AndAlso afl = 1 Then
                LP.Text = "Player Black AI's Turn"
            Else
                LP.Text = "Player Black's Turn"
            End If
            LP.ForeColor = Color.Black
            p1 = 2
            p2 = 2
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
        End If
        ce = 0
        nc = 0
        pt = 1
        pnm = 1
        ge = 0
        gec = 0
        sd = 0
        EC()
        If ne = 1 Then
            If pm = 2 Then
                If sc = 0 Then
                    Text = "Game - Player Black"
                    fp.Text = "Player List - Player Black"
                Else
                    Text = "Game - Player White"
                    fp.Text = "Player List - Player White"
                End If
            ElseIf pm = 4 Then
                fc.sc = sc
                If sc = 0 Then
                    scn = 1
                    fc.sh = sh
                    fc.sp = sp
                    fc.ch1 = ch1
                    fc.cp1 = cp1
                    fc.ch2 = ch2
                    fc.cp2 = cp2
                    fc.ch3 = ch3
                    fc.cp3 = cp3
                    fc.ShowDialog(Me)
                    If fc.cc = 0 Then
                        Close()
                        Exit Sub
                    End If
                    Text = "Game - Player Red"
                    fp.Text = "Player List - Player Red"
                Else
                    fc.sh = sh
                    fc.sp = sp
                    fc.ch = ch
                    fc.cp = cp
                    fc.ShowDialog(Me)
                    If fc.cc = 0 Then
                        Close()
                        Exit Sub
                    End If
                    scn = fc.scn
                    If scn = 2 Then
                        Text = "Game - Player Blue"
                        fp.Text = "Player List - Player Blue"
                    ElseIf scn = 3 Then
                        Text = "Game - Player Yellow"
                        fp.Text = "Player List - Player Yellow"
                    ElseIf scn = 4 Then
                        Text = "Game - Player Green"
                        fp.Text = "Player List - Player Green"
                    End If
                End If
            End If
            MC()
            If sc = 1 Then
                ce = 1
                SCR()
            End If
        End If
        If ae = 1 Then
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
            Dim srs As New StreamReader("AI\Setting.aifo", System.Text.Encoding.GetEncoding("shift_jis"))
            a1 = CByte(srs.ReadLine)
            a2 = CByte(srs.ReadLine)
            srs.Close()
            srs.Dispose()
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
            If afl = 1 Then
                fp.L2.BackColor = Color.Lime
            Else
                fp.L1.BackColor = Color.Lime
            End If
            If a1 = 3 Then
                ss(3, 4) = 3
                ss(4, 3) = 3
                ss(4, 4) = 2
                ss(4, 5) = 1
                ss(5, 4) = 1
                ss(5, 5) = 2
                ss(5, 6) = 3
                ss(6, 5) = 3
            End If
        End If
        fp.P1.Show()
        fp.P2.Hide()
        fp.P3.Hide()
        fp.P4.Hide()
        fp.Show(Me)
        fp.Location = New Point(Left + Width, Top)
        If cu = 1 Then
            fu.pm = pm
            fu.sc = sc
            If pm = 2 Then
                If sc = 0 Then
                    fu.ch = ch
                Else
                    fu.sh = sh
                End If
            Else
                If sc = 0 Then
                    fu.ch1 = ch1
                    fu.ch2 = ch2
                    fu.ch3 = ch3
                Else
                    fu.sh = sh
                End If
                fu.scn = scn
            End If
            fu.Show(Me)
            fu.Location = New Point(Left + Width, Top + fp.Height)
        End If
        If ae = 1 And afl = 1 Then
            TAI.Start()
        End If
        If he = 1 Then
            sd = 1
            For i = 1 To hp.Length / 2
                CType(FindForm.Controls("Button" & hp.Substring(i * 2 - 2, 2)), Button).PerformClick()
            Next
            sd = 0
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

    Private Sub Button_Click(sender As Object, e As EventArgs) Handles Button88.Click, Button87.Click, Button86.Click, Button85.Click, Button84.Click, Button83.Click, Button82.Click, Button81.Click, Button78.Click, Button77.Click, Button76.Click, Button75.Click, Button74.Click, Button73.Click, Button72.Click, Button71.Click, Button68.Click, Button67.Click, Button66.Click, Button65.Click, Button64.Click, Button63.Click, Button62.Click, Button61.Click, Button58.Click, Button57.Click, Button56.Click, Button55.Click, Button54.Click, Button53.Click, Button52.Click, Button51.Click, Button48.Click, Button47.Click, Button46.Click, Button45.Click, Button44.Click, Button43.Click, Button42.Click, Button41.Click, Button38.Click, Button37.Click, Button36.Click, Button35.Click, Button34.Click, Button33.Click, Button32.Click, Button31.Click, Button28.Click, Button27.Click, Button26.Click, Button25.Click, Button24.Click, Button23.Click, Button22.Click, Button21.Click, Button18.Click, Button17.Click, Button16.Click, Button15.Click, Button14.Click, Button13.Click, Button12.Click, Button11.Click
        If ce = 1 Then
            Exit Sub
        End If
        bt = CType(sender, Button)
        a = CByte(bt.Name.Substring(6, 1))
        b = CByte(bt.Name.Substring(7, 1))
        bs = bt.Name.Substring(6, 2)
        If ne = 1 Then
            If nc = 1 Then
                GL()
            End If
        End If
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
                If ae = 1 And a1 = 3 Then
                    For cz = 1 To 8
                        For dz = 1 To 8
                            sst(cz, dz) = ss(cz, dz)
                        Next
                    Next
                    AIA(a, b, pt)
                    For cz = 1 To 8
                        For dz = 1 To 8
                            ss(cz, dz) = sst(cz, dz)
                        Next
                    Next
                End If
                CT()
                If ae = 1 Then
                    If aip = "#" Then
                        If bt.Name.Substring(6, 2) = "34" Then
                            aic = 0
                        ElseIf bt.Name.Substring(6, 2) = "43" Then
                            aic = 1
                        ElseIf bt.Name.Substring(6, 2) = "65" Then
                            aic = 2
                        ElseIf bt.Name.Substring(6, 2) = "56" Then
                            aic = 3
                        End If
                    End If
                    If aic = 0 Then
                        aip &= bt.Name.Substring(6, 2)
                    ElseIf aic = 1 Then
                        aip &= bt.Name.Substring(7, 1) & bt.Name.Substring(6, 1)
                    ElseIf aic = 2 Then
                        aip &= 9 - CInt(bt.Name.Substring(6, 1)) & 9 - CInt(bt.Name.Substring(7, 1))
                    Else
                        aip &= 9 - CInt(bt.Name.Substring(7, 1)) & 9 - CInt(bt.Name.Substring(6, 1))
                    End If
                End If
                bh &= bt.Name.Substring(6, 2)
                EC()
                If gec = 0 Then
                    If ne = 1 Then
                        If pm = 2 Then
                            If nc = 0 Then
                                SCS()
                            Else
                                If pnm = pt Then
                                    ce = 1
                                    SCR()
                                End If
                            End If
                            nc = 0
                        Else
                            If nc = 0 Then
                                SCS()
                            Else
                                If Not pt = scn Then
                                    ce = 1
                                    SCR()
                                End If
                            End If
                            nc = 0
                        End If
                    End If
                    If ae = 1 Then
                        If pt = afl Then
                            AI()
                        End If
                    End If
                End If
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
            If ae = 1 AndAlso afl = 2 Then
                LP.Text = "Player White AI's Turn"
            Else
                LP.Text = "Player White's Turn"
            End If
            LP.ForeColor = Color.White
            fp.L1.Text = "Player Black " & p1
            fp.L2.Text = "Player White " & p2
            fp.P1.Hide()
            fp.P2.Show()
            fp.Refresh()
        ElseIf pm = 2 And pt = 2 Then
            p2 += 1
            pt = 1
            If ae = 1 AndAlso afl = 1 Then
                LP.Text = "Player Black AI's Turn"
            Else
                LP.Text = "Player Black's Turn"
            End If
            LP.ForeColor = Color.Black
            fp.L1.Text = "Player Black " & p1
            fp.L2.Text = "Player White " & p2
            fp.P1.Show()
            fp.P2.Hide()
            fp.Refresh()
        ElseIf pm = 4 And pt = 1 Then
            p1 += 1
            pt = 2
            LP.Text = "Player Blue's Turn"
            LP.ForeColor = Color.SkyBlue
            fp.L1.Text = "Player Red " & p1
            fp.L2.Text = "Player Blue " & p2
            fp.L3.Text = "Player Yellow " & p3
            fp.L4.Text = "Player Green " & p4
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
            fp.L1.Text = "Player Red " & p1
            fp.L2.Text = "Player Blue " & p2
            fp.L3.Text = "Player Yellow " & p3
            fp.L4.Text = "Player Green " & p4
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
            fp.L1.Text = "Player Red " & p1
            fp.L2.Text = "Player Blue " & p2
            fp.L3.Text = "Player Yellow " & p3
            fp.L4.Text = "Player Green " & p4
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
            fp.L1.Text = "Player Red " & p1
            fp.L2.Text = "Player Blue " & p2
            fp.L3.Text = "Player Yellow " & p3
            fp.L4.Text = "Player Green " & p4
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
                If ae = 1 AndAlso afl = 2 Then
                    LP.Text = "Player White AI's Turn"
                Else
                    LP.Text = "Player White's Turn"
                End If
                fp.P1.Hide()
                fp.P2.Show()
                LP.ForeColor = Color.White
            ElseIf pm = 2 And pt = 2 Then
                pt = 1
                If ae = 1 AndAlso afl = 1 Then
                    LP.Text = "Player Black AI's Turn"
                Else
                    LP.Text = "Player Black's Turn"
                End If
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
        ge = 1
        pt = 0
        LP.Text = "Result"
        If pm = 2 Then
            LP.ForeColor = Color.Lime
        Else
            LP.ForeColor = Color.Black
        End If
        fp.Hide()
        If ne = 1 Then
            If nc = 0 Then
                SCS()
            ElseIf sc = 0 And pm = 4 Then
                SCS()
            End If
            nc = 0
        End If
        If pm = 2 Then
            fr.LD.Text = "Black " & p1 & " - White " & p2
            fr.LD.ForeColor = Color.Lime
            If p1 > p2 Then
                fr.LR.Text = "Winner Player Black"
                fr.LR.ForeColor = Color.Black
                If ae = 1 Then
                    grs = "B"
                End If
            ElseIf p1 < p2 Then
                fr.LR.Text = "Winner Player White"
                fr.LR.ForeColor = Color.White
                If ae = 1 Then
                    grs = "W"
                End If
            Else
                fr.LR.Text = "Draw"
                fr.LR.ForeColor = Color.Lime
                If ae = 1 Then
                    grs = "D"
                End If
            End If
        ElseIf pm = 4 Then
            fr.LD.Text = "Red " & p1 & " - Blue " & p2 & " - Yellow " & p3 & " - Green " & p4
            fr.LD.ForeColor = Color.Lime
            If p1 = p2 And p2 = p3 And p3 = p4 Then
                fr.LR.Text = "Draw"
            Else
                fr.LR.Text = "Winner"
                If p1 >= p2 And p1 >= p3 And p1 >= p4 Then
                    fr.LR.Text &= " Player Red"
                    fr.LR.ForeColor = Color.Red
                ElseIf p2 >= p1 And p2 >= p3 And p2 >= p4 Then
                    If fr.LR.Text = "Winner" Then
                        fr.LR.Text &= " Player Blue"
                        fr.LR.ForeColor = Color.SkyBlue
                    Else
                        fr.LR.Text &= " & Player Blue"
                        fr.LR.ForeColor = Color.Black
                    End If
                ElseIf p3 >= p1 And p3 >= p2 And p3 >= p4 Then
                    If fr.LR.Text = "Winner" Then
                        fr.LR.Text &= " Player Yellow"
                        fr.LR.ForeColor = Color.Orange
                    Else
                        fr.LR.Text &= " & Player Yellow"
                        fr.LR.ForeColor = Color.Black
                    End If
                ElseIf p4 >= p1 And p4 >= p2 And p4 >= p3 Then
                    If fr.LR.Text = "Winner" Then
                        fr.LR.Text &= " Player Green"
                        fr.LR.ForeColor = Color.LawnGreen
                    Else
                        fr.LR.Text &= " & Player Green"
                        fr.LR.ForeColor = Color.Black
                    End If
                End If
            End If
        End If
        fr.ShowDialog(Me)
        fr.Dispose()
        If ae = 1 Then
            AIR()
            Text = "Game"
        End If
        Dim result As DialogResult = MessageBox.Show("Do you want to record this game?", "Othello", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        If result = DialogResult.Yes Then
            Dim fn As New Name
            hn = Date.Now.ToString
            fn.LN.Text = hn
            fn.ShowDialog(Me)
            hn = fn.LN.Text
            fn.Dispose()
            Directory.CreateDirectory("Data\")
            If Not IO.File.Exists("Data\H" & pm & ".ghfo") Then
                Dim swx As New StreamWriter("Data\H" & pm & ".ghfo", True, System.Text.Encoding.GetEncoding("shift_jis"))
                swx.WriteLine("Game History Data by GHFO Format")
                swx.Close()
                swx.Dispose()
            End If
            Dim sw As New StreamWriter("Data\H" & pm & ".ghfo", True, System.Text.Encoding.GetEncoding("shift_jis"))
            If pm = 2 Then
                If p1 < 10 AndAlso p2 < 10 Then
                    sw.WriteLine("%" & hn & "?" & Date.Now.ToString & "#" & bh & "!" & "0" & p1 & "0" & p2 & "$")
                ElseIf p1 < 10 Then
                    sw.WriteLine("%" & hn & "?" & Date.Now.ToString & "#" & bh & "!" & "0" & p1 & p2 & "$")
                ElseIf p2 < 10 Then
                    sw.WriteLine("%" & hn & "?" & Date.Now.ToString & "#" & bh & "!" & p1 & "0" & p2 & "$")
                Else
                    sw.WriteLine("%" & hn & "?" & Date.Now.ToString & "#" & bh & "!" & p1 & p2 & "$")
                End If
            Else
                If p1 < 10 AndAlso p2 < 10 AndAlso p3 < 10 AndAlso p4 < 10 Then
                    sw.WriteLine("%" & hn & "?" & Date.Now.ToString & "#" & bh & "!" & "0" & p1 & "0" & p2 & "0" & p3 & "0" & p4 & "$")
                ElseIf p1 < 10 AndAlso p2 < 10 AndAlso p3 < 10 Then
                    sw.WriteLine("%" & hn & "?" & Date.Now.ToString & "#" & bh & "!" & "0" & p1 & "0" & p2 & "0" & p3 & p4 & "$")
                ElseIf p1 < 10 AndAlso p2 < 10 AndAlso p4 < 10 Then
                    sw.WriteLine("%" & hn & "?" & Date.Now.ToString & "#" & bh & "!" & "0" & p1 & "0" & p2 & p3 & "0" & p4 & "$")
                ElseIf p1 < 10 AndAlso p3 < 10 AndAlso p4 < 10 Then
                    sw.WriteLine("%" & hn & "?" & Date.Now.ToString & "#" & bh & "!" & "0" & p1 & p2 & "0" & p3 & "0" & p4 & "$")
                ElseIf p2 < 10 AndAlso p3 < 10 AndAlso p4 < 10 Then
                    sw.WriteLine("%" & hn & "?" & Date.Now.ToString & "#" & bh & "!" & p1 & "0" & p2 & "0" & p3 & "0" & p4 & "$")
                ElseIf p1 < 10 AndAlso p2 < 10 Then
                    sw.WriteLine("%" & hn & "?" & Date.Now.ToString & "#" & bh & "!" & "0" & p1 & "0" & p2 & p3 & p4 & "$")
                ElseIf p2 < 10 AndAlso p3 < 10 Then
                    sw.WriteLine("%" & hn & "?" & Date.Now.ToString & "#" & bh & "!" & p1 & "0" & p2 & "0" & p3 & p4 & "$")
                ElseIf p3 < 10 AndAlso p4 < 10 Then
                    sw.WriteLine("%" & hn & "?" & Date.Now.ToString & "#" & bh & "!" & p1 & p2 & "0" & p3 & "0" & p4 & "$")
                ElseIf p1 < 10 AndAlso p3 < 10 Then
                    sw.WriteLine("%" & hn & "?" & Date.Now.ToString & "#" & bh & "!" & "0" & p1 & p2 & "0" & p3 & p4 & "$")
                ElseIf p1 < 10 AndAlso p4 < 10 Then
                    sw.WriteLine("%" & hn & "?" & Date.Now.ToString & "#" & bh & "!" & "0" & p1 & p2 & p3 & "0" & p4 & "$")
                ElseIf p2 < 10 AndAlso p4 < 10 Then
                    sw.WriteLine("%" & hn & "?" & Date.Now.ToString & "#" & bh & "!" & p1 & "0" & p2 & p3 & "0" & p4 & "$")
                ElseIf p1 < 10 Then
                    sw.WriteLine("%" & hn & "?" & Date.Now.ToString & "#" & bh & "!" & "0" & p1 & p2 & p3 & p4 & "$")
                ElseIf p2 < 10 Then
                    sw.WriteLine("%" & hn & "?" & Date.Now.ToString & "#" & bh & "!" & p1 & "0" & p2 & p3 & p4 & "$")
                ElseIf p3 < 10 Then
                    sw.WriteLine("%" & hn & "?" & Date.Now.ToString & "#" & bh & "!" & p1 & p2 & "0" & p3 & p4 & "$")
                ElseIf p4 < 10 Then
                    sw.WriteLine("%" & hn & "?" & Date.Now.ToString & "#" & bh & "!" & p1 & p2 & p3 & "0" & p4 & "$")
                Else
                    sw.WriteLine("%" & hn & "?" & Date.Now.ToString & "#" & bh & "!" & p1 & p2 & p3 & p4 & "$")
                End If
            End If
            sw.Close()
            sw.Dispose()
        End If
        gec = 1
        Close()
    End Sub

    Sub MC()
        If pm = 2 Then
            If sc = 0 Then
                fp.L1.BackColor = Color.Lime
            Else
                fp.L2.BackColor = Color.Lime
            End If
        Else
            If scn = 1 Then
                fp.L1.BackColor = Color.White
            ElseIf scn = 2 Then
                fp.L2.BackColor = Color.White
            ElseIf scn = 3 Then
                fp.L3.BackColor = Color.White
            ElseIf scn = 4 Then
                fp.L4.BackColor = Color.White
            End If
        End If
    End Sub

    Private Sub TAI_Tick(sender As Object, e As EventArgs) Handles TAI.Tick
        TAI.Stop()
        AI()
    End Sub

    Sub AI()
        Text = "Game - AI Now Thinking"
        LG()
        Refresh()
        If a1 < 3 Then
            If ain = 0 Then
                If aidl > 1 Then
                    ait = aid
                    eon = 0
                    aim = 0
                    aie = ""
                    Do While ait.Contains(aip)
                        If aip = "#" Then
                            eon = 2
                            Exit Do
                        End If
                        ait = ait.Substring(ait.IndexOf(aip))
                        If pt = 1 And ait.Substring(ait.IndexOf("!") + 1, 1) = "B" Then
                            If a1 = 2 Then
                                If CByte(ait.Substring(ait.IndexOf("?") + 1, 2)) > aim Then
                                    aim = CByte(ait.Substring(ait.IndexOf("?") + 1, 2))
                                    If aic = 0 Then
                                        wtp(0) = CByte(ait.Substring(ait.IndexOf(aip) + aip.Length, 1))
                                        wtp(1) = CByte(ait.Substring(ait.IndexOf(aip) + aip.Length + 1, 1))
                                    ElseIf aic = 1 Then
                                        wtp(0) = CByte(ait.Substring(ait.IndexOf(aip) + aip.Length + 1, 1))
                                        wtp(1) = CByte(ait.Substring(ait.IndexOf(aip) + aip.Length, 1))
                                    ElseIf aic = 2 Then
                                        wtp(0) = 9 - CByte(ait.Substring(ait.IndexOf(aip) + aip.Length, 1))
                                        wtp(1) = 9 - CByte(ait.Substring(ait.IndexOf(aip) + aip.Length + 1, 1))
                                    Else
                                        wtp(0) = 9 - CByte(ait.Substring(ait.IndexOf(aip) + aip.Length + 1, 1))
                                        wtp(1) = 9 - CByte(ait.Substring(ait.IndexOf(aip) + aip.Length, 1))
                                    End If
                                    eon = 1
                                End If
                            Else
                                If aic = 0 Then
                                    wtp(0) = CByte(ait.Substring(ait.IndexOf(aip) + aip.Length, 1))
                                    wtp(1) = CByte(ait.Substring(ait.IndexOf(aip) + aip.Length + 1, 1))
                                ElseIf aic = 1 Then
                                    wtp(0) = CByte(ait.Substring(ait.IndexOf(aip) + aip.Length + 1, 1))
                                    wtp(1) = CByte(ait.Substring(ait.IndexOf(aip) + aip.Length, 1))
                                ElseIf aic = 2 Then
                                    wtp(0) = 9 - CByte(ait.Substring(ait.IndexOf(aip) + aip.Length, 1))
                                    wtp(1) = 9 - CByte(ait.Substring(ait.IndexOf(aip) + aip.Length + 1, 1))
                                Else
                                    wtp(0) = 9 - CByte(ait.Substring(ait.IndexOf(aip) + aip.Length + 1, 1))
                                    wtp(1) = 9 - CByte(ait.Substring(ait.IndexOf(aip) + aip.Length, 1))
                                End If
                                eon = 1
                                Exit Do
                            End If
                        ElseIf pt = 2 And ait.Substring(ait.IndexOf("!") + 1, 1) = "W" Then
                            If a1 = 2 Then
                                If CByte(ait.Substring(ait.IndexOf("?") + 3, 2)) > aim Then
                                    aim = CByte(ait.Substring(ait.IndexOf("?") + 3, 2))
                                    If aic = 0 Then
                                        wtp(0) = CByte(ait.Substring(ait.IndexOf(aip) + aip.Length, 1))
                                        wtp(1) = CByte(ait.Substring(ait.IndexOf(aip) + aip.Length + 1, 1))
                                    ElseIf aic = 1 Then
                                        wtp(0) = CByte(ait.Substring(ait.IndexOf(aip) + aip.Length + 1, 1))
                                        wtp(1) = CByte(ait.Substring(ait.IndexOf(aip) + aip.Length, 1))
                                    ElseIf aic = 2 Then
                                        wtp(0) = 9 - CByte(ait.Substring(ait.IndexOf(aip) + aip.Length, 1))
                                        wtp(1) = 9 - CByte(ait.Substring(ait.IndexOf(aip) + aip.Length + 1, 1))
                                    Else
                                        wtp(0) = 9 - CByte(ait.Substring(ait.IndexOf(aip) + aip.Length + 1, 1))
                                        wtp(1) = 9 - CByte(ait.Substring(ait.IndexOf(aip) + aip.Length, 1))
                                    End If
                                    eon = 1
                                End If
                            Else
                                If aic = 0 Then
                                    wtp(0) = CByte(ait.Substring(ait.IndexOf(aip) + aip.Length, 1))
                                    wtp(1) = CByte(ait.Substring(ait.IndexOf(aip) + aip.Length + 1, 1))
                                ElseIf aic = 1 Then
                                    wtp(0) = CByte(ait.Substring(ait.IndexOf(aip) + aip.Length + 1, 1))
                                    wtp(1) = CByte(ait.Substring(ait.IndexOf(aip) + aip.Length, 1))
                                ElseIf aic = 2 Then
                                    wtp(0) = 9 - CByte(ait.Substring(ait.IndexOf(aip) + aip.Length, 1))
                                    wtp(1) = 9 - CByte(ait.Substring(ait.IndexOf(aip) + aip.Length + 1, 1))
                                Else
                                    wtp(0) = 9 - CByte(ait.Substring(ait.IndexOf(aip) + aip.Length + 1, 1))
                                    wtp(1) = 9 - CByte(ait.Substring(ait.IndexOf(aip) + aip.Length, 1))
                                End If
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
                        GL()
                        CType(FindForm.Controls("Button" & wtp(0) & wtp(1)), Button).PerformClick()
                        LG()
                    ElseIf eon = 2 Then
                        GL()
                        Do
                            wtp(0) = rdm.Next(1, 9)
                            wtp(1) = rdm.Next(1, 9)
                            If cx > aie.Length / 3 Then
                                If Not aie.Contains("#" & wtp(0) & wtp(1)) Then
                                    If CType(FindForm.Controls("Button" & wtp(0) & wtp(1)), Button).BackColor = Color.Lime Then
                                        CType(FindForm.Controls("Button" & wtp(0) & wtp(1)), Button).PerformClick()
                                        Exit Do
                                    End If
                                End If
                            Else
                                If CType(FindForm.Controls("Button" & wtp(0) & wtp(1)), Button).BackColor = Color.Lime Then
                                    CType(FindForm.Controls("Button" & wtp(0) & wtp(1)), Button).PerformClick()
                                    Exit Do
                                End If
                            End If
                        Loop
                        LG()
                    End If
                Else
                    ain = 1
                End If
            End If
            If ain = 1 Then
                GL()
                Do
                    wtp(0) = rdm.Next(1, 9)
                    wtp(1) = rdm.Next(1, 9)
                    If CType(FindForm.Controls("Button" & wtp(0) & wtp(1)), Button).BackColor = Color.Lime Then
                        CType(FindForm.Controls("Button" & wtp(0) & wtp(1)), Button).PerformClick()
                        Exit Do
                    End If
                Loop
                LG()
            End If
        Else
            'Prepare
            For c = 1 To 8
                For d = 1 To 8
                    If ss(c, d) = 3 Then
                        ss(c, d) = 0
                    End If
                Next
            Next
            For c = 1 To 8
                For d = 1 To 8
                    If ss(c, d) = 0 Then
                        cb = 0
                        'Right
                        For i = 1 To 7
                            If d + i > 8 Then
                                Exit For
                            Else
                                If ss(c, d + i) = 0 Or ss(c, d + i) = 3 Then
                                    Exit For
                                End If
                                If pt = 1 Then
                                    If ss(c, d + i) = 1 Then
                                        If i <> 1 Then
                                            cb = 1
                                        End If
                                        Exit For
                                    End If
                                ElseIf pt = 2 Then
                                    If ss(c, d + i) = 2 Then
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
                                If ss(c + i, d) = 0 Or ss(c + i, d) = 3 Then
                                    Exit For
                                End If
                                If pt = 1 Then
                                    If ss(c + i, d) = 1 Then
                                        If i <> 1 Then
                                            cb = 1
                                        End If
                                        Exit For
                                    End If
                                ElseIf pt = 2 Then
                                    If ss(c + i, d) = 2 Then
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
                                If ss(c, d - i) = 0 Or ss(c, d - i) = 3 Then
                                    Exit For
                                End If
                                If pt = 1 Then
                                    If ss(c, d - i) = 1 Then
                                        If i <> 1 Then
                                            cb = 1
                                        End If
                                        Exit For
                                    End If
                                ElseIf pt = 2 Then
                                    If ss(c, d - i) = 2 Then
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
                                If ss(c - i, d) = 0 Or ss(c - i, d) = 3 Then
                                    Exit For
                                End If
                                If pt = 1 Then
                                    If ss(c - i, d) = 1 Then
                                        If i <> 1 Then
                                            cb = 1
                                        End If
                                        Exit For
                                    End If
                                ElseIf pt = 2 Then
                                    If ss(c - i, d) = 2 Then
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
                                If ss(c + i, d + i) = 0 Or ss(c + i, d + i) = 3 Then
                                    Exit For
                                End If
                                If pt = 1 Then
                                    If ss(c + i, d + i) = 1 Then
                                        If i <> 1 Then
                                            cb = 1
                                        End If
                                        Exit For
                                    End If
                                ElseIf pt = 2 Then
                                    If ss(c + i, d + i) = 2 Then
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
                                If ss(c + i, d - i) = 0 Or ss(c + i, d - i) = 3 Then
                                    Exit For
                                End If
                                If pt = 1 Then
                                    If ss(c + i, d - i) = 1 Then
                                        If i <> 1 Then
                                            cb = 1
                                        End If
                                        Exit For
                                    End If
                                ElseIf pt = 2 Then
                                    If ss(c + i, d - i) = 2 Then
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
                                If ss(c - i, d - i) = 0 Or ss(c - i, d - i) = 3 Then
                                    Exit For
                                End If
                                If pt = 1 Then
                                    If ss(c - i, d - i) = 1 Then
                                        If i <> 1 Then
                                            cb = 1
                                        End If
                                        Exit For
                                    End If
                                ElseIf pt = 2 Then
                                    If ss(c - i, d - i) = 2 Then
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
                                If ss(c - i, d + i) = 0 Or ss(c - i, d + i) = 3 Then
                                    Exit For
                                End If
                                If pt = 1 Then
                                    If ss(c - i, d + i) = 1 Then
                                        If i <> 1 Then
                                            cb = 1
                                        End If
                                        Exit For
                                    End If
                                ElseIf pt = 2 Then
                                    If ss(c - i, d + i) = 2 Then
                                        If i <> 1 Then
                                            cb = 1
                                        End If
                                        Exit For
                                    End If
                                End If
                            End If
                        Next
                        If cb = 1 Then
                            ss(c, d) = 3
                        End If
                    End If
                Next
            Next
            'Main Process
            baio = 60
            baig = 60
            baiw = 60
            bais = 60
            baiu = 60
            aio = ""
            aig = ""
            aiw = ""
            ais = ""
            aiu = ""
            aiox = ""
            For c = 1 To 8
                For d = 1 To 8
                    If ss(c, d) = 3 Then
                        bai = 0
                        ail = ""
                        'Right
                        bait = 0
                        ailt = ""
                        For i = 1 To 7
                            If d + i > 8 Then
                                Exit For
                            Else
                                If ss(c, d + i) = 0 Or ss(c, d + i) = 3 Then
                                    Exit For
                                End If
                                If pt = 1 Then
                                    If ss(c, d + i) = 1 Then
                                        If i <> 1 Then
                                            If c < 8 Then
                                                If ss(c + 1, d) = 0 OrElse ss(c + 1, d) = 3 Then
                                                    If Not ail.Contains("#" & c + 1 & d) Then
                                                        bait += 1
                                                        ailt &= "#" & c + 1 & d
                                                    End If
                                                End If
                                            End If
                                            If c > 1 Then
                                                If ss(c - 1, d) = 0 OrElse ss(c - 1, d) = 3 Then
                                                    If Not ail.Contains("#" & c - 1 & d) Then
                                                        bait += 1
                                                        ailt &= "#" & c - 1 & d
                                                    End If
                                                End If
                                            End If
                                            If c < 8 Then
                                                If ss(c + 1, d + i) = 0 OrElse ss(c + 1, d + i) = 3 Then
                                                    If Not ail.Contains("#" & c + 1 & d + i) Then
                                                        bait += 1
                                                        ailt &= "#" & c + 1 & d + i
                                                    End If
                                                End If
                                            End If
                                            If c > 1 Then
                                                If ss(c - 1, d + i) = 0 OrElse ss(c - 1, d + i) = 3 Then
                                                    If Not ail.Contains("#" & c - 1 & d + i) Then
                                                        bait += 1
                                                        ailt &= "#" & c - 1 & d + i
                                                    End If
                                                End If
                                            End If
                                            bai += bait
                                            ail &= ailt
                                        End If
                                        Exit For
                                    Else
                                        If c < 8 Then
                                            If ss(c + 1, d + i) = 0 OrElse ss(c + 1, d + i) = 3 Then
                                                If Not ail.Contains("#" & c + 1 & d + i) Then
                                                    bait += 1
                                                    ailt &= "#" & c + 1 & d + i
                                                End If
                                            End If
                                        End If
                                        If c > 1 Then
                                            If ss(c - 1, d + i) = 0 OrElse ss(c - 1, d + i) = 3 Then
                                                If Not ail.Contains("#" & c - 1 & d + i) Then
                                                    bait += 1
                                                    ailt &= "#" & c - 1 & d + i
                                                End If
                                            End If
                                        End If
                                    End If
                                ElseIf pt = 2 Then
                                    If ss(c, d + i) = 2 Then
                                        If i <> 1 Then
                                            If c < 8 Then
                                                If ss(c + 1, d) = 0 OrElse ss(c + 1, d) = 3 Then
                                                    If Not ail.Contains("#" & c + 1 & d) Then
                                                        bait += 1
                                                        ailt &= "#" & c + 1 & d
                                                    End If
                                                End If
                                            End If
                                            If c > 1 Then
                                                If ss(c - 1, d) = 0 OrElse ss(c - 1, d) = 3 Then
                                                    If Not ail.Contains("#" & c - 1 & d) Then
                                                        bait += 1
                                                        ailt &= "#" & c - 1 & d
                                                    End If
                                                End If
                                            End If
                                            If c < 8 Then
                                                If ss(c + 1, d + i) = 0 OrElse ss(c + 1, d + i) = 3 Then
                                                    If Not ail.Contains("#" & c + 1 & d + i) Then
                                                        bait += 1
                                                        ailt &= "#" & c + 1 & d + i
                                                    End If
                                                End If
                                            End If
                                            If c > 1 Then
                                                If ss(c - 1, d + i) = 0 OrElse ss(c - 1, d + i) = 3 Then
                                                    If Not ail.Contains("#" & c - 1 & d + i) Then
                                                        bait += 1
                                                        ailt &= "#" & c - 1 & d + i
                                                    End If
                                                End If
                                            End If
                                            bai += bait
                                            ail &= ailt
                                        End If
                                        Exit For
                                    Else
                                        If c < 8 Then
                                            If ss(c + 1, d + i) = 0 OrElse ss(c + 1, d + i) = 3 Then
                                                If Not ail.Contains("#" & c + 1 & d + i) Then
                                                    bait += 1
                                                    ailt &= "#" & c + 1 & d + i
                                                End If
                                            End If
                                        End If
                                        If c > 1 Then
                                            If ss(c - 1, d + i) = 0 OrElse ss(c - 1, d + i) = 3 Then
                                                If Not ail.Contains("#" & c - 1 & d + i) Then
                                                    bait += 1
                                                    ailt &= "#" & c - 1 & d + i
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        Next
                        'Down
                        bait = 0
                        ailt = ""
                        For i = 1 To 7
                            If c + i > 8 Then
                                Exit For
                            Else
                                If ss(c + i, d) = 0 Or ss(c + i, d) = 3 Then
                                    Exit For
                                End If
                                If pt = 1 Then
                                    If ss(c + i, d) = 1 Then
                                        If i <> 1 Then
                                            If d < 8 Then
                                                If ss(c, d + 1) = 0 OrElse ss(c, d + 1) = 3 Then
                                                    If Not ail.Contains("#" & c & d + 1) Then
                                                        bait += 1
                                                        ailt &= "#" & c & d + 1
                                                    End If
                                                End If
                                            End If
                                            If d > 1 Then
                                                If ss(c, d - 1) = 0 OrElse ss(c, d - 1) = 3 Then
                                                    If Not ail.Contains("#" & c & d - 1) Then
                                                        bait += 1
                                                        ailt &= "#" & c & d - 1
                                                    End If
                                                End If
                                            End If
                                            If d < 8 Then
                                                If ss(c + i, d + 1) = 0 OrElse ss(c + i, d + 1) = 3 Then
                                                    If Not ail.Contains("#" & c + i & d + 1) Then
                                                        bait += 1
                                                        ailt &= "#" & c + i & d + 1
                                                    End If
                                                End If
                                            End If
                                            If d > 1 Then
                                                If ss(c + i, d - 1) = 0 OrElse ss(c + i, d - 1) = 3 Then
                                                    If Not ail.Contains("#" & c + i & d - 1) Then
                                                        bait += 1
                                                        ailt &= "#" & c + i & d - 1
                                                    End If
                                                End If
                                            End If
                                            bai += bait
                                            ail &= ailt
                                        End If
                                        Exit For
                                    Else
                                        If d < 8 Then
                                            If ss(c + i, d + 1) = 0 OrElse ss(c + i, d + 1) = 3 Then
                                                If Not ail.Contains("#" & c + i & d + 1) Then
                                                    bait += 1
                                                    ailt &= "#" & c + i & d + 1
                                                End If
                                            End If
                                        End If
                                        If d > 1 Then
                                            If ss(c + i, d - 1) = 0 OrElse ss(c + i, d - 1) = 3 Then
                                                If Not ail.Contains("#" & c + i & d - 1) Then
                                                    bait += 1
                                                    ailt &= "#" & c + i & d - 1
                                                End If
                                            End If
                                        End If
                                    End If
                                ElseIf pt = 2 Then
                                    If ss(c + i, d) = 2 Then
                                        If i <> 1 Then
                                            If d < 8 Then
                                                If ss(c, d + 1) = 0 OrElse ss(c, d + 1) = 3 Then
                                                    If Not ail.Contains("#" & c & d + 1) Then
                                                        bait += 1
                                                        ailt &= "#" & c & d + 1
                                                    End If
                                                End If
                                            End If
                                            If d > 1 Then
                                                If ss(c, d - 1) = 0 OrElse ss(c, d - 1) = 3 Then
                                                    If Not ail.Contains("#" & c & d - 1) Then
                                                        bait += 1
                                                        ailt &= "#" & c & d - 1
                                                    End If
                                                End If
                                            End If
                                            If d < 8 Then
                                                If ss(c + i, d + 1) = 0 OrElse ss(c + i, d + 1) = 3 Then
                                                    If Not ail.Contains("#" & c + i & d + 1) Then
                                                        bait += 1
                                                        ailt &= "#" & c + i & d + 1
                                                    End If
                                                End If
                                            End If
                                            If d > 1 Then
                                                If ss(c + i, d - 1) = 0 OrElse ss(c + i, d - 1) = 3 Then
                                                    If Not ail.Contains("#" & c + i & d - 1) Then
                                                        bait += 1
                                                        ailt &= "#" & c + i & d - 1
                                                    End If
                                                End If
                                            End If
                                            bai += bait
                                            ail &= ailt
                                        End If
                                        Exit For
                                    Else
                                        If d < 8 Then
                                            If ss(c + i, d + 1) = 0 OrElse ss(c + i, d + 1) = 3 Then
                                                If Not ail.Contains("#" & c + i & d + 1) Then
                                                    bait += 1
                                                    ailt &= "#" & c + i & d + 1
                                                End If
                                            End If
                                        End If
                                        If d > 1 Then
                                            If ss(c + i, d - 1) = 0 OrElse ss(c + i, d - 1) = 3 Then
                                                If Not ail.Contains("#" & c + i & d - 1) Then
                                                    bait += 1
                                                    ailt &= "#" & c + i & d - 1
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        Next
                        'Left
                        bait = 0
                        ailt = ""
                        For i = 1 To 7
                            If d - i < 1 Then
                                Exit For
                            Else
                                If ss(c, d - i) = 0 Or ss(c, d - i) = 3 Then
                                    Exit For
                                End If
                                If pt = 1 Then
                                    If ss(c, d - i) = 1 Then
                                        If i <> 1 Then
                                            If c < 8 Then
                                                If ss(c + 1, d) = 0 OrElse ss(c + 1, d) = 3 Then
                                                    If Not ail.Contains("#" & c + 1 & d) Then
                                                        bait += 1
                                                        ailt &= "#" & c + 1 & d
                                                    End If
                                                End If
                                            End If
                                            If c > 1 Then
                                                If ss(c - 1, d) = 0 OrElse ss(c - 1, d) = 3 Then
                                                    If Not ail.Contains("#" & c - 1 & d) Then
                                                        bait += 1
                                                        ailt &= "#" & c - 1 & d
                                                    End If
                                                End If
                                            End If
                                            If c < 8 Then
                                                If ss(c + 1, d - i) = 0 OrElse ss(c + 1, d - i) = 3 Then
                                                    If Not ail.Contains("#" & c + 1 & d - i) Then
                                                        bait += 1
                                                        ailt &= "#" & c + 1 & d - i
                                                    End If
                                                End If
                                            End If
                                            If c > 1 Then
                                                If ss(c - 1, d - i) = 0 OrElse ss(c - 1, d - i) = 3 Then
                                                    If Not ail.Contains("#" & c - 1 & d - i) Then
                                                        bait += 1
                                                        ailt &= "#" & c - 1 & d - i
                                                    End If
                                                End If
                                            End If
                                            bai += bait
                                            ail &= ailt
                                        End If
                                        Exit For
                                    Else
                                        If c < 8 Then
                                            If ss(c + 1, d - i) = 0 OrElse ss(c + 1, d - i) = 3 Then
                                                If Not ail.Contains("#" & c + 1 & d - i) Then
                                                    bait += 1
                                                    ailt &= "#" & c + 1 & d - i
                                                End If
                                            End If
                                        End If
                                        If c > 1 Then
                                            If ss(c - 1, d - i) = 0 OrElse ss(c - 1, d - i) = 3 Then
                                                If Not ail.Contains("#" & c - 1 & d - i) Then
                                                    bait += 1
                                                    ailt &= "#" & c - 1 & d - i
                                                End If
                                            End If
                                        End If
                                    End If
                                ElseIf pt = 2 Then
                                    If ss(c, d - i) = 2 Then
                                        If i <> 1 Then
                                            If c < 8 Then
                                                If ss(c + 1, d) = 0 OrElse ss(c + 1, d) = 3 Then
                                                    If Not ail.Contains("#" & c + 1 & d) Then
                                                        bait += 1
                                                        ailt &= "#" & c + 1 & d
                                                    End If
                                                End If
                                            End If
                                            If c > 1 Then
                                                If ss(c - 1, d) = 0 OrElse ss(c - 1, d) = 3 Then
                                                    If Not ail.Contains("#" & c - 1 & d) Then
                                                        bait += 1
                                                        ailt &= "#" & c - 1 & d
                                                    End If
                                                End If
                                            End If
                                            If c < 8 Then
                                                If ss(c + 1, d - i) = 0 OrElse ss(c + 1, d - i) = 3 Then
                                                    If Not ail.Contains("#" & c + 1 & d - i) Then
                                                        bait += 1
                                                        ailt &= "#" & c + 1 & d - i
                                                    End If
                                                End If
                                            End If
                                            If c > 1 Then
                                                If ss(c - 1, d - i) = 0 OrElse ss(c - 1, d - i) = 3 Then
                                                    If Not ail.Contains("#" & c - 1 & d - i) Then
                                                        bait += 1
                                                        ailt &= "#" & c - 1 & d - i
                                                    End If
                                                End If
                                            End If
                                            bai += bait
                                            ail &= ailt
                                        End If
                                        Exit For
                                    Else
                                        If c < 8 Then
                                            If ss(c + 1, d - i) = 0 OrElse ss(c + 1, d - i) = 3 Then
                                                If Not ail.Contains("#" & c + 1 & d - i) Then
                                                    bait += 1
                                                    ailt &= "#" & c + 1 & d - i
                                                End If
                                            End If
                                        End If
                                        If c > 1 Then
                                            If ss(c - 1, d - i) = 0 OrElse ss(c - 1, d - i) = 3 Then
                                                If Not ail.Contains("#" & c - 1 & d - i) Then
                                                    bait += 1
                                                    ailt &= "#" & c - 1 & d - i
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        Next
                        'Up
                        bait = 0
                        ailt = ""
                        For i = 1 To 7
                            If c - i < 1 Then
                                Exit For
                            Else
                                If ss(c - i, d) = 0 Or ss(c - i, d) = 3 Then
                                    Exit For
                                End If
                                If pt = 1 Then
                                    If ss(c - i, d) = 1 Then
                                        If i <> 1 Then
                                            If d < 8 Then
                                                If ss(c, d + 1) = 0 OrElse ss(c, d + 1) = 3 Then
                                                    If Not ail.Contains("#" & c & d + 1) Then
                                                        bait += 1
                                                        ailt &= "#" & c & d + 1
                                                    End If
                                                End If
                                            End If
                                            If d > 1 Then
                                                If ss(c, d - 1) = 0 OrElse ss(c, d - 1) = 3 Then
                                                    If Not ail.Contains("#" & c & d - 1) Then
                                                        bait += 1
                                                        ailt &= "#" & c & d - 1
                                                    End If
                                                End If
                                            End If
                                            If d < 8 Then
                                                If ss(c - i, d + 1) = 0 OrElse ss(c - i, d + 1) = 3 Then
                                                    If Not ail.Contains("#" & c - i & d + 1) Then
                                                        bait += 1
                                                        ailt &= "#" & c - i & d + 1
                                                    End If
                                                End If
                                            End If
                                            If d > 1 Then
                                                If ss(c - i, d - 1) = 0 OrElse ss(c - i, d - 1) = 3 Then
                                                    If Not ail.Contains("#" & c - i & d - 1) Then
                                                        bait += 1
                                                        ailt &= "#" & c - i & d - 1
                                                    End If
                                                End If
                                            End If
                                            bai += bait
                                            ail &= ailt
                                        End If
                                        Exit For
                                    Else
                                        If d < 8 Then
                                            If ss(c - i, d + 1) = 0 OrElse ss(c - i, d + 1) = 3 Then
                                                If Not ail.Contains("#" & c - i & d + 1) Then
                                                    bait += 1
                                                    ailt &= "#" & c - i & d + 1
                                                End If
                                            End If
                                        End If
                                        If d > 1 Then
                                            If ss(c - i, d - 1) = 0 OrElse ss(c - i, d - 1) = 3 Then
                                                If Not ail.Contains("#" & c - i & d - 1) Then
                                                    bait += 1
                                                    ailt &= "#" & c - i & d - 1
                                                End If
                                            End If
                                        End If
                                    End If
                                ElseIf pt = 2 Then
                                    If ss(c - i, d) = 2 Then
                                        If i <> 1 Then
                                            If d < 8 Then
                                                If ss(c, d + 1) = 0 OrElse ss(c, d + 1) = 3 Then
                                                    If Not ail.Contains("#" & c & d + 1) Then
                                                        bait += 1
                                                        ailt &= "#" & c & d + 1
                                                    End If
                                                End If
                                            End If
                                            If d > 1 Then
                                                If ss(c, d - 1) = 0 OrElse ss(c, d - 1) = 3 Then
                                                    If Not ail.Contains("#" & c & d - 1) Then
                                                        bait += 1
                                                        ailt &= "#" & c & d - 1
                                                    End If
                                                End If
                                            End If
                                            If d < 8 Then
                                                If ss(c - i, d + 1) = 0 OrElse ss(c - i, d + 1) = 3 Then
                                                    If Not ail.Contains("#" & c - i & d + 1) Then
                                                        bait += 1
                                                        ailt &= "#" & c - i & d + 1
                                                    End If
                                                End If
                                            End If
                                            If d > 1 Then
                                                If ss(c - i, d - 1) = 0 OrElse ss(c - i, d - 1) = 3 Then
                                                    If Not ail.Contains("#" & c - i & d - 1) Then
                                                        bait += 1
                                                        ailt &= "#" & c - i & d - 1
                                                    End If
                                                End If
                                            End If
                                            bai += bait
                                            ail &= ailt
                                        End If
                                        Exit For
                                    Else
                                        If d < 8 Then
                                            If ss(c - i, d + 1) = 0 OrElse ss(c - i, d + 1) = 3 Then
                                                If Not ail.Contains("#" & c - i & d + 1) Then
                                                    bait += 1
                                                    ailt &= "#" & c - i & d + 1
                                                End If
                                            End If
                                        End If
                                        If d > 1 Then
                                            If ss(c - i, d - 1) = 0 OrElse ss(c - i, d - 1) = 3 Then
                                                If Not ail.Contains("#" & c - i & d - 1) Then
                                                    bait += 1
                                                    ailt &= "#" & c - i & d - 1
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        Next
                        'Right and Down
                        bait = 0
                        ailt = ""
                        For i = 1 To 7
                            If c + i > 8 Or d + i > 8 Then
                                Exit For
                            Else
                                If ss(c + i, d + i) = 0 Or ss(c + i, d + i) = 3 Then
                                    Exit For
                                End If
                                If pt = 1 Then
                                    If ss(c + i, d + i) = 1 Then
                                        If i <> 1 Then
                                            If d + i > 1 Then
                                                If ss(c + i, d + i - 1) = 0 OrElse ss(c + i, d + i - 1) = 3 Then
                                                    If Not ail.Contains("#" & c + i & d + i - 1) Then
                                                        bait += 1
                                                        ailt &= "#" & c + i & d + i - 1
                                                    End If
                                                End If
                                            End If
                                            If c + i > 1 Then
                                                If ss(c + i - 1, d + i) = 0 OrElse ss(c + i - 1, d + i) = 3 Then
                                                    If Not ail.Contains("#" & c + i - 1 & d + i) Then
                                                        bait += 1
                                                        ailt &= "#" & c + i - 1 & d + i
                                                    End If
                                                End If
                                            End If
                                            bai += bait
                                            ail &= ailt
                                        End If
                                        Exit For
                                    Else
                                        If d + i > 1 Then
                                            If ss(c + i, d + i - 1) = 0 OrElse ss(c + i, d + i - 1) = 3 Then
                                                If Not ail.Contains("#" & c + i & d + i - 1) Then
                                                    bait += 1
                                                    ailt &= "#" & c + i & d + i - 1
                                                End If
                                            End If
                                        End If
                                        If c + i > 1 Then
                                            If ss(c + i - 1, d + i) = 0 OrElse ss(c + i - 1, d + i) = 3 Then
                                                If Not ail.Contains("#" & c + i - 1 & d + i) Then
                                                    bait += 1
                                                    ailt &= "#" & c + i - 1 & d + i
                                                End If
                                            End If
                                        End If
                                        If c + i < 8 AndAlso d + i > 1 Then
                                            If ss(c + i + 1, d + i - 1) = 0 OrElse ss(c + i + 1, d + i - 1) = 3 Then
                                                If Not ail.Contains("#" & c + i + 1 & d + i - 1) Then
                                                    bait += 1
                                                    ailt &= "#" & c + i + 1 & d + i - 1
                                                End If
                                            End If
                                        End If
                                        If c + i > 1 AndAlso d + i < 8 Then
                                            If ss(c + i - 1, d + i + 1) = 0 OrElse ss(c + i - 1, d + i + 1) = 3 Then
                                                If Not ail.Contains("#" & c + i - 1 & d + i + 1) Then
                                                    bait += 1
                                                    ailt &= "#" & c + i - 1 & d + i + 1
                                                End If
                                            End If
                                        End If
                                    End If
                                ElseIf pt = 2 Then
                                    If ss(c + i, d + i) = 2 Then
                                        If i <> 1 Then
                                            If d + i > 1 Then
                                                If ss(c + i, d + i - 1) = 0 OrElse ss(c + i, d + i - 1) = 3 Then
                                                    If Not ail.Contains("#" & c + i & d + i - 1) Then
                                                        bait += 1
                                                        ailt &= "#" & c + i & d + i - 1
                                                    End If
                                                End If
                                            End If
                                            If c + i > 1 Then
                                                If ss(c + i - 1, d + i) = 0 OrElse ss(c + i - 1, d + i) = 3 Then
                                                    If Not ail.Contains("#" & c + i - 1 & d + i) Then
                                                        bait += 1
                                                        ailt &= "#" & c + i - 1 & d + i
                                                    End If
                                                End If
                                            End If
                                            bai += bait
                                            ail &= ailt
                                        End If
                                        Exit For
                                    Else
                                        If d + i > 1 Then
                                            If ss(c + i, d + i - 1) = 0 OrElse ss(c + i, d + i - 1) = 3 Then
                                                If Not ail.Contains("#" & c + i & d + i - 1) Then
                                                    bait += 1
                                                    ailt &= "#" & c + i & d + i - 1
                                                End If
                                            End If
                                        End If
                                        If c + i > 1 Then
                                            If ss(c + i - 1, d + i) = 0 OrElse ss(c + i - 1, d + i) = 3 Then
                                                If Not ail.Contains("#" & c + i - 1 & d + i) Then
                                                    bait += 1
                                                    ailt &= "#" & c + i - 1 & d + i
                                                End If
                                            End If
                                        End If
                                        If c + i < 8 AndAlso d + i > 1 Then
                                            If ss(c + i + 1, d + i - 1) = 0 OrElse ss(c + i + 1, d + i - 1) = 3 Then
                                                If Not ail.Contains("#" & c + i + 1 & d + i - 1) Then
                                                    bait += 1
                                                    ailt &= "#" & c + i + 1 & d + i - 1
                                                End If
                                            End If
                                        End If
                                        If c + i > 1 AndAlso d + i < 8 Then
                                            If ss(c + i - 1, d + i + 1) = 0 OrElse ss(c + i - 1, d + i + 1) = 3 Then
                                                If Not ail.Contains("#" & c + i - 1 & d + i + 1) Then
                                                    bait += 1
                                                    ailt &= "#" & c + i - 1 & d + i + 1
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        Next
                        'Left and Down
                        bait = 0
                        ailt = ""
                        For i = 1 To 7
                            If c + i > 8 Or d - i < 1 Then
                                Exit For
                            Else
                                If ss(c + i, d - i) = 0 Or ss(c + i, d - i) = 3 Then
                                    Exit For
                                End If
                                If pt = 1 Then
                                    If ss(c + i, d - i) = 1 Then
                                        If i <> 1 Then
                                            If d - i < 8 Then
                                                If ss(c + i, d - i + 1) = 0 OrElse ss(c + i, d - i + 1) = 3 Then
                                                    If Not ail.Contains("#" & c + i & d - i + 1) Then
                                                        bait += 1
                                                        ailt &= "#" & c + i & d - i + 1
                                                    End If
                                                End If
                                            End If
                                            If c + i > 1 Then
                                                If ss(c + i - 1, d - i) = 0 OrElse ss(c + i - 1, d - i) = 3 Then
                                                    If Not ail.Contains("#" & c + i - 1 & d - i) Then
                                                        bait += 1
                                                        ailt &= "#" & c + i - 1 & d - i
                                                    End If
                                                End If
                                            End If
                                            bai += bait
                                            ail &= ailt
                                        End If
                                        Exit For
                                    Else
                                        If d - i < 8 Then
                                            If ss(c + i, d - i + 1) = 0 OrElse ss(c + i, d - i + 1) = 3 Then
                                                If Not ail.Contains("#" & c + i & d - i + 1) Then
                                                    bait += 1
                                                    ailt &= "#" & c + i & d - i + 1
                                                End If
                                            End If
                                        End If
                                        If c + i > 1 Then
                                            If ss(c + i - 1, d - i) = 0 OrElse ss(c + i - 1, d - i) = 3 Then
                                                If Not ail.Contains("#" & c + i - 1 & d - i) Then
                                                    bait += 1
                                                    ailt &= "#" & c + i - 1 & d - i
                                                End If
                                            End If
                                        End If
                                        If c + i < 8 AndAlso d - i < 8 Then
                                            If ss(c + i + 1, d - i + 1) = 0 OrElse ss(c + i + 1, d - i + 1) = 3 Then
                                                If Not ail.Contains("#" & c + i + 1 & d - i + 1) Then
                                                    bait += 1
                                                    ailt &= "#" & c + i + 1 & d - i + 1
                                                End If
                                            End If
                                        End If
                                        If c + i > 1 AndAlso d - i > 1 Then
                                            If ss(c + i - 1, d - i - 1) = 0 OrElse ss(c + i - 1, d - i - 1) = 3 Then
                                                If Not ail.Contains("#" & c + i - 1 & d - i - 1) Then
                                                    bait += 1
                                                    ailt &= "#" & c + i - 1 & d - i - 1
                                                End If
                                            End If
                                        End If
                                    End If
                                ElseIf pt = 2 Then
                                    If ss(c + i, d - i) = 2 Then
                                        If i <> 1 Then
                                            If d - i < 8 Then
                                                If ss(c + i, d - i + 1) = 0 OrElse ss(c + i, d - i + 1) = 3 Then
                                                    If Not ail.Contains("#" & c + i & d - i + 1) Then
                                                        bait += 1
                                                        ailt &= "#" & c + i & d - i + 1
                                                    End If
                                                End If
                                            End If
                                            If c + i > 1 Then
                                                If ss(c + i - 1, d - i) = 0 OrElse ss(c + i - 1, d - i) = 3 Then
                                                    If Not ail.Contains("#" & c + i - 1 & d - i) Then
                                                        bait += 1
                                                        ailt &= "#" & c + i - 1 & d - i
                                                    End If
                                                End If
                                            End If
                                            bai += bait
                                            ail &= ailt
                                        End If
                                        Exit For
                                    Else
                                        If d - i < 8 Then
                                            If ss(c + i, d - i + 1) = 0 OrElse ss(c + i, d - i + 1) = 3 Then
                                                If Not ail.Contains("#" & c + i & d - i + 1) Then
                                                    bait += 1
                                                    ailt &= "#" & c + i & d - i + 1
                                                End If
                                            End If
                                        End If
                                        If c + i > 1 Then
                                            If ss(c + i - 1, d - i) = 0 OrElse ss(c + i - 1, d - i) = 3 Then
                                                If Not ail.Contains("#" & c + i - 1 & d - i) Then
                                                    bait += 1
                                                    ailt &= "#" & c + i - 1 & d - i
                                                End If
                                            End If
                                        End If
                                        If c + i < 8 AndAlso d - i < 8 Then
                                            If ss(c + i + 1, d - i + 1) = 0 OrElse ss(c + i + 1, d - i + 1) = 3 Then
                                                If Not ail.Contains("#" & c + i + 1 & d - i + 1) Then
                                                    bait += 1
                                                    ailt &= "#" & c + i + 1 & d - i + 1
                                                End If
                                            End If
                                        End If
                                        If c + i > 1 AndAlso d - i > 1 Then
                                            If ss(c + i - 1, d - i - 1) = 0 OrElse ss(c + i - 1, d - i - 1) = 3 Then
                                                If Not ail.Contains("#" & c + i - 1 & d - i - 1) Then
                                                    bait += 1
                                                    ailt &= "#" & c + i - 1 & d - i - 1
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        Next
                        'Left and Up
                        bait = 0
                        ailt = ""
                        For i = 1 To 7
                            If c - i < 1 Or d - i < 1 Then
                                Exit For
                            Else
                                If ss(c - i, d - i) = 0 Or ss(c - i, d - i) = 3 Then
                                    Exit For
                                End If
                                If pt = 1 Then
                                    If ss(c - i, d - i) = 1 Then
                                        If i <> 1 Then
                                            If d - i < 8 Then
                                                If ss(c - i, d - i + 1) = 0 OrElse ss(c - i, d - i + 1) = 3 Then
                                                    If Not ail.Contains("#" & c - i & d - i + 1) Then
                                                        bait += 1
                                                        ailt &= "#" & c - i & d - i + 1
                                                    End If
                                                End If
                                            End If
                                            If c - i < 8 Then
                                                If ss(c - i + 1, d - i) = 0 OrElse ss(c - i + 1, d - i) = 3 Then
                                                    If Not ail.Contains("#" & c - i + 1 & d - i) Then
                                                        bait += 1
                                                        ailt &= "#" & c - i + 1 & d - i
                                                    End If
                                                End If
                                            End If
                                            bai += bait
                                            ail &= ailt
                                        End If
                                        Exit For
                                    Else
                                        If d - i < 8 Then
                                            If ss(c - i, d - i + 1) = 0 OrElse ss(c - i, d - i + 1) = 3 Then
                                                If Not ail.Contains("#" & c - i & d - i + 1) Then
                                                    bait += 1
                                                    ailt &= "#" & c - i & d - i + 1
                                                End If
                                            End If
                                        End If
                                        If c - i < 8 Then
                                            If ss(c - i + 1, d - i) = 0 OrElse ss(c - i + 1, d - i) = 3 Then
                                                If Not ail.Contains("#" & c - i + 1 & d - i) Then
                                                    bait += 1
                                                    ailt &= "#" & c - i + 1 & d - i
                                                End If
                                            End If
                                        End If
                                        If c - i < 8 AndAlso d - i > 1 Then
                                            If ss(c - i + 1, d - i - 1) = 0 OrElse ss(c - i + 1, d - i - 1) = 3 Then
                                                If Not ail.Contains("#" & c - i + 1 & d - i - 1) Then
                                                    bait += 1
                                                    ailt &= "#" & c - i + 1 & d - i - 1
                                                End If
                                            End If
                                        End If
                                        If c - i > 1 AndAlso d - i < 8 Then
                                            If ss(c - i - 1, d - i + 1) = 0 OrElse ss(c - i - 1, d - i + 1) = 3 Then
                                                If Not ail.Contains("#" & c - i - 1 & d - i + 1) Then
                                                    bait += 1
                                                    ailt &= "#" & c - i - 1 & d - i + 1
                                                End If
                                            End If
                                        End If
                                    End If
                                ElseIf pt = 2 Then
                                    If ss(c - i, d - i) = 2 Then
                                        If i <> 1 Then
                                            If d - i < 8 Then
                                                If ss(c - i, d - i + 1) = 0 OrElse ss(c - i, d - i + 1) = 3 Then
                                                    If Not ail.Contains("#" & c - i & d - i + 1) Then
                                                        bait += 1
                                                        ailt &= "#" & c - i & d - i + 1
                                                    End If
                                                End If
                                            End If
                                            If c - i < 8 Then
                                                If ss(c - i + 1, d - i) = 0 OrElse ss(c - i + 1, d - i) = 3 Then
                                                    If Not ail.Contains("#" & c - i + 1 & d - i) Then
                                                        bait += 1
                                                        ailt &= "#" & c - i + 1 & d - i
                                                    End If
                                                End If
                                            End If
                                            bai += bait
                                            ail &= ailt
                                        End If
                                        Exit For
                                    Else
                                        If d - i < 8 Then
                                            If ss(c - i, d - i + 1) = 0 OrElse ss(c - i, d - i + 1) = 3 Then
                                                If Not ail.Contains("#" & c - i & d - i + 1) Then
                                                    bait += 1
                                                    ailt &= "#" & c - i & d - i + 1
                                                End If
                                            End If
                                        End If
                                        If c - i < 8 Then
                                            If ss(c - i + 1, d - i) = 0 OrElse ss(c - i + 1, d - i) = 3 Then
                                                If Not ail.Contains("#" & c - i + 1 & d - i) Then
                                                    bait += 1
                                                    ailt &= "#" & c - i + 1 & d - i
                                                End If
                                            End If
                                        End If
                                        If c - i < 8 AndAlso d - i > 1 Then
                                            If ss(c - i + 1, d - i - 1) = 0 OrElse ss(c - i + 1, d - i - 1) = 3 Then
                                                If Not ail.Contains("#" & c - i + 1 & d - i - 1) Then
                                                    bait += 1
                                                    ailt &= "#" & c - i + 1 & d - i - 1
                                                End If
                                            End If
                                        End If
                                        If c - i > 1 AndAlso d - i < 8 Then
                                            If ss(c - i - 1, d - i + 1) = 0 OrElse ss(c - i - 1, d - i + 1) = 3 Then
                                                If Not ail.Contains("#" & c - i - 1 & d - i + 1) Then
                                                    bait += 1
                                                    ailt &= "#" & c - i - 1 & d - i + 1
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        Next
                        'Right and Up
                        bait = 0
                        ailt = ""
                        For i = 1 To 7
                            If c - i < 1 Or d + i > 8 Then
                                Exit For
                            Else
                                If ss(c - i, d + i) = 0 Or ss(c - i, d + i) = 3 Then
                                    Exit For
                                End If
                                If pt = 1 Then
                                    If ss(c - i, d + i) = 1 Then
                                        If i <> 1 Then
                                            If d + i > 1 Then
                                                If ss(c - i, d + i - 1) = 0 OrElse ss(c - i, d + i - 1) = 3 Then
                                                    If Not ail.Contains("#" & c - i & d + i - 1) Then
                                                        bait += 1
                                                        ailt &= "#" & c - i & d + i - 1
                                                    End If
                                                End If
                                            End If
                                            If c - i < 8 Then
                                                If ss(c - i + 1, d + i) = 0 OrElse ss(c - i + 1, d + i) = 3 Then
                                                    If Not ail.Contains("#" & c - i + 1 & d + i) Then
                                                        bait += 1
                                                        ailt &= "#" & c - i + 1 & d + i
                                                    End If
                                                End If
                                            End If
                                            bai += bait
                                            ail &= ailt
                                        End If
                                        Exit For
                                    Else
                                        If d + i > 1 Then
                                            If ss(c - i, d + i - 1) = 0 OrElse ss(c - i, d + i - 1) = 3 Then
                                                If Not ail.Contains("#" & c - i & d + i - 1) Then
                                                    bait += 1
                                                    ailt &= "#" & c - i & d + i - 1
                                                End If
                                            End If
                                        End If
                                        If c - i < 8 Then
                                            If ss(c - i + 1, d + i) = 0 OrElse ss(c - i + 1, d + i) = 3 Then
                                                If Not ail.Contains("#" & c - i + 1 & d + i) Then
                                                    bait += 1
                                                    ailt &= "#" & c - i + 1 & d + i
                                                End If
                                            End If
                                        End If
                                        If c - i < 8 AndAlso d + i < 8 Then
                                            If ss(c - i + 1, d + i + 1) = 0 OrElse ss(c - i + 1, d + i + 1) = 3 Then
                                                If Not ail.Contains("#" & c - i + 1 & d + i + 1) Then
                                                    bait += 1
                                                    ailt &= "#" & c - i + 1 & d + i + 1
                                                End If
                                            End If
                                        End If
                                        If c - i > 1 AndAlso d + i > 1 Then
                                            If ss(c - i - 1, d + i - 1) = 0 OrElse ss(c - i - 1, d + i - 1) = 3 Then
                                                If Not ail.Contains("#" & c - i - 1 & d + i - 1) Then
                                                    bait += 1
                                                    ailt &= "#" & c - i - 1 & d + i - 1
                                                End If
                                            End If
                                        End If
                                    End If
                                ElseIf pt = 2 Then
                                    If ss(c - i, d + i) = 2 Then
                                        If i <> 1 Then
                                            If d + i > 1 Then
                                                If ss(c - i, d + i - 1) = 0 OrElse ss(c - i, d + i - 1) = 3 Then
                                                    If Not ail.Contains("#" & c - i & d + i - 1) Then
                                                        bait += 1
                                                        ailt &= "#" & c - i & d + i - 1
                                                    End If
                                                End If
                                            End If
                                            If c - i < 8 Then
                                                If ss(c - i + 1, d + i) = 0 OrElse ss(c - i + 1, d + i) = 3 Then
                                                    If Not ail.Contains("#" & c - i + 1 & d + i) Then
                                                        bait += 1
                                                        ailt &= "#" & c - i + 1 & d + i
                                                    End If
                                                End If
                                            End If
                                            bai += bait
                                            ail &= ailt
                                        End If
                                        Exit For
                                    Else
                                        If d + i > 1 Then
                                            If ss(c - i, d + i - 1) = 0 OrElse ss(c - i, d + i - 1) = 3 Then
                                                If Not ail.Contains("#" & c - i & d + i - 1) Then
                                                    bait += 1
                                                    ailt &= "#" & c - i & d + i - 1
                                                End If
                                            End If
                                        End If
                                        If c - i < 8 Then
                                            If ss(c - i + 1, d + i) = 0 OrElse ss(c - i + 1, d + i) = 3 Then
                                                If Not ail.Contains("#" & c - i + 1 & d + i) Then
                                                    bait += 1
                                                    ailt &= "#" & c - i + 1 & d + i
                                                End If
                                            End If
                                        End If
                                        If c - i < 8 AndAlso d + i < 8 Then
                                            If ss(c - i + 1, d + i + 1) = 0 OrElse ss(c - i + 1, d + i + 1) = 3 Then
                                                If Not ail.Contains("#" & c - i + 1 & d + i + 1) Then
                                                    bait += 1
                                                    ailt &= "#" & c - i + 1 & d + i + 1
                                                End If
                                            End If
                                        End If
                                        If c - i > 1 AndAlso d + i > 1 Then
                                            If ss(c - i - 1, d + i - 1) = 0 OrElse ss(c - i - 1, d + i - 1) = 3 Then
                                                If Not ail.Contains("#" & c - i - 1 & d + i - 1) Then
                                                    bait += 1
                                                    ailt &= "#" & c - i - 1 & d + i - 1
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        Next
                        'Final Process
                        If bai = baio Then
                            aio &= "#" & c & d
                        ElseIf bai < baio Then
                            baio = bai
                            aio = "#" & c & d
                        End If
                        aiox &= "#" & c & d
                        For cz = 1 To 8
                            For dz = 1 To 8
                                sst(cz, dz) = ss(cz, dz)
                            Next
                        Next
                        bpo = 0
                        AIA(c, d, pt)
                        If bpo = 1 Then
                            If sst(1, 1) < 3 AndAlso sst(1, 8) < 3 AndAlso sst(8, 1) < 3 AndAlso sst(8, 8) < 3 Then
                                For cj = 1 To 8
                                    For dj = 1 To 8
                                        sstt(cj, dj) = sst(cj, dj)
                                    Next
                                Next
                                aiwtt = aiwt
                                bpot = 0
                                For ix = 1 To aiwtt.Length \ 3
                                    For cy = 1 To 8
                                        For dy = 1 To 8
                                            sst(cy, dy) = sstt(cy, dy)
                                        Next
                                    Next
                                    bpo = 0
                                    If pt = 1 Then
                                        AIA(aiwtt.Substring(ix * 3 - 2, 1), aiwtt.Substring(ix * 3 - 1, 1), 2)
                                    Else
                                        AIA(aiwtt.Substring(ix * 3 - 2, 1), aiwtt.Substring(ix * 3 - 1, 1), 1)
                                    End If
                                    If bpo = 1 Then
                                        If sst(1, 1) = 3 OrElse sst(1, 8) = 3 OrElse sst(8, 1) = 3 OrElse sst(8, 8) = 3 Then
                                            bpot = 1
                                        Else
                                            bpot = 2
                                            Exit For
                                        End If
                                    Else
                                        bpot = 3
                                        Exit For
                                    End If
                                Next
                                If bpot = 1 Then
                                    If bai = baiw Then
                                        aiw &= "#" & c & d
                                    ElseIf bai < baiw Then
                                        baiw = bai
                                        aiw = "#" & c & d
                                    End If
                                End If
                                If bpot < 3 Then
                                    If bai = baig Then
                                        aig &= "#" & c & d
                                    ElseIf bai < baig Then
                                        baig = bai
                                        aig = "#" & c & d
                                    End If
                                End If
                                If bpot = 3 Then
                                    If aio.Contains("#" & c & d) Then
                                        aio.Remove(aio.IndexOf("#" & c & d), 3)
                                    End If
                                    aiox.Remove(aio.IndexOf("#" & c & d), 3)
                                End If
                            Else
                                If aio.Contains("#" & c & d) Then
                                    aio.Remove(aio.IndexOf("#" & c & d), 3)
                                End If
                                aiox.Remove(aiox.IndexOf("#" & c & d), 3)
                            End If
                        Else
                            If sst(1, 1) = 3 OrElse sst(1, 8) = 3 OrElse sst(8, 1) = 3 OrElse sst(8, 8) = 3 Then
                                If bai = baiu Then
                                    aiu &= "#" & c & d
                                ElseIf bai < baiu Then
                                    baiu = bai
                                    aiu = "#" & c & d
                                End If
                            End If
                            If bai = bais Then
                                ais &= "#" & c & d
                            ElseIf bai < bais Then
                                bais = bai
                                ais = "#" & c & d
                            End If
                        End If
                    End If
                Next
            Next
            If aiu.Length > 0 Then
                brs = rdm.Next(1, aiu.Length \ 3 + 1)
                wtp(0) = aiu.Substring(brs * 3 - 2, 1)
                wtp(1) = aiu.Substring(brs * 3 - 1, 1)
                GL()
                CType(FindForm.Controls("Button" & wtp(0) & wtp(1)), Button).PerformClick()
                LG()
            ElseIf ais.Length > 0 Then
                brs = rdm.Next(1, ais.Length \ 3 + 1)
                wtp(0) = ais.Substring(brs * 3 - 2, 1)
                wtp(1) = ais.Substring(brs * 3 - 1, 1)
                GL()
                CType(FindForm.Controls("Button" & wtp(0) & wtp(1)), Button).PerformClick()
                LG()
            ElseIf aiw.Length > 0 Then
                brs = rdm.Next(1, aiw.Length \ 3 + 1)
                wtp(0) = aiw.Substring(brs * 3 - 2, 1)
                wtp(1) = aiw.Substring(brs * 3 - 1, 1)
                GL()
                CType(FindForm.Controls("Button" & wtp(0) & wtp(1)), Button).PerformClick()
                LG()
            ElseIf aig.Length > 0 Then
                brs = rdm.Next(1, aig.Length \ 3 + 1)
                wtp(0) = aig.Substring(brs * 3 - 2, 1)
                wtp(1) = aig.Substring(brs * 3 - 1, 1)
                GL()
                CType(FindForm.Controls("Button" & wtp(0) & wtp(1)), Button).PerformClick()
                LG()
            ElseIf aio.Length > 0 Then
                brs = rdm.Next(1, aio.Length \ 3 + 1)
                wtp(0) = aio.Substring(brs * 3 - 2, 1)
                wtp(1) = aio.Substring(brs * 3 - 1, 1)
                GL()
                CType(FindForm.Controls("Button" & wtp(0) & wtp(1)), Button).PerformClick()
                LG()
            ElseIf aiox.Length > 0 Then
                brs = rdm.Next(1, aiox.Length \ 3 + 1)
                wtp(0) = aiox.Substring(brs * 3 - 2, 1)
                wtp(1) = aiox.Substring(brs * 3 - 1, 1)
                GL()
                CType(FindForm.Controls("Button" & wtp(0) & wtp(1)), Button).PerformClick()
                LG()
            Else
                GL()
                Do
                    wtp(0) = rdm.Next(1, 9)
                    wtp(1) = rdm.Next(1, 9)
                    If CType(FindForm.Controls("Button" & wtp(0) & wtp(1)), Button).BackColor = Color.Lime Then
                        CType(FindForm.Controls("Button" & wtp(0) & wtp(1)), Button).PerformClick()
                        Exit Do
                    End If
                Loop
                LG()
            End If
        End If
        GL()
        Text = "Game"
    End Sub

    Sub AIA(c As Byte, d As Byte, ptx As Byte)
        If sst(c, d) = 3 Then
            'Right
            For i = 1 To 7
                If d + i > 8 Then
                    Exit For
                Else
                    If sst(c, d + i) = 0 Or sst(c, d + i) = 3 Then
                        Exit For
                    End If
                    If ptx = 1 Then
                        If sst(c, d + i) = 1 Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    sst(c, d + n) = 1
                                Next
                            End If
                            Exit For
                        End If
                    ElseIf ptx = 2 Then
                        If sst(c, d + i) = 2 Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    sst(c, d + n) = 2
                                Next
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
                    If sst(c + i, d) = 0 Or sst(c + i, d) = 3 Then
                        Exit For
                    End If
                    If ptx = 1 Then
                        If sst(c + i, d) = 1 Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    sst(c + n, d) = 1
                                Next
                            End If
                            Exit For
                        End If
                    ElseIf ptx = 2 Then
                        If sst(c + i, d) = 2 Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    sst(c + n, d) = 2
                                Next
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
                    If sst(c, d - i) = 0 Or sst(c, d - i) = 3 Then
                        Exit For
                    End If
                    If ptx = 1 Then
                        If sst(c, d - i) = 1 Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    sst(c, d - n) = 1
                                Next
                            End If
                            Exit For
                        End If
                    ElseIf ptx = 2 Then
                        If sst(c, d - i) = 2 Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    sst(c, d - n) = 2
                                Next
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
                    If sst(c - i, d) = 0 Or sst(c - i, d) = 3 Then
                        Exit For
                    End If
                    If ptx = 1 Then
                        If sst(c - i, d) = 1 Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    sst(c - n, d) = 1
                                Next
                            End If
                            Exit For
                        End If
                    ElseIf ptx = 2 Then
                        If sst(c - i, d) = 2 Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    sst(c - n, d) = 2
                                Next
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
                    If sst(c + i, d + i) = 0 Or sst(c + i, d + i) = 3 Then
                        Exit For
                    End If
                    If ptx = 1 Then
                        If sst(c + i, d + i) = 1 Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    sst(c + n, d + n) = 1
                                Next
                            End If
                            Exit For
                        End If
                    ElseIf ptx = 2 Then
                        If sst(c + i, d + i) = 2 Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    sst(c + n, d + n) = 2
                                Next
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
                    If sst(c + i, d - i) = 0 Or sst(c + i, d - i) = 3 Then
                        Exit For
                    End If
                    If ptx = 1 Then
                        If sst(c + i, d - i) = 1 Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    sst(c + n, d - n) = 1
                                Next
                            End If
                            Exit For
                        End If
                    ElseIf ptx = 2 Then
                        If sst(c + i, d - i) = 2 Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    sst(c + n, d - n) = 2
                                Next
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
                    If sst(c - i, d - i) = 0 Or sst(c - i, d - i) = 3 Then
                        Exit For
                    End If
                    If ptx = 1 Then
                        If sst(c - i, d - i) = 1 Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    sst(c - n, d - n) = 1
                                Next
                            End If
                            Exit For
                        End If
                    ElseIf ptx = 2 Then
                        If sst(c - i, d - i) = 2 Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    sst(c - n, d - n) = 2
                                Next
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
                    If sst(c - i, d + i) = 0 Or sst(c - i, d + i) = 3 Then
                        Exit For
                    End If
                    If ptx = 1 Then
                        If sst(c - i, d + i) = 1 Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    sst(c - n, d + n) = 1
                                Next
                            End If
                            Exit For
                        End If
                    ElseIf ptx = 2 Then
                        If sst(c - i, d + i) = 2 Then
                            If i <> 1 Then
                                For n = 0 To i - 1
                                    sst(c - n, d + n) = 2
                                Next
                            End If
                            Exit For
                        End If
                    End If
                End If
            Next
            For nn = 1 To 2
                If ptx = 1 Then
                    ptx = 2
                Else
                    ptx = 1
                End If
                For cq = 1 To 8
                    For dq = 1 To 8
                        If sst(cq, dq) = 3 Then
                            sst(cq, dq) = 0
                        End If
                    Next
                Next
                cx = 0
                aiwt = ""
                For cq = 1 To 8
                    For dq = 1 To 8
                        If sst(cq, dq) = 0 Then
                            cb = 0
                            'Right
                            For i = 1 To 7
                                If dq + i > 8 Then
                                    Exit For
                                Else
                                    If sst(cq, dq + i) = 0 Or sst(cq, dq + i) = 3 Then
                                        Exit For
                                    End If
                                    If ptx = 1 Then
                                        If sst(cq, dq + i) = 1 Then
                                            If i <> 1 Then
                                                cb = 1
                                            End If
                                            Exit For
                                        End If
                                    ElseIf ptx = 2 Then
                                        If sst(cq, dq + i) = 2 Then
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
                                If cq + i > 8 Then
                                    Exit For
                                Else
                                    If sst(cq + i, dq) = 0 Or sst(cq + i, dq) = 3 Then
                                        Exit For
                                    End If
                                    If ptx = 1 Then
                                        If sst(cq + i, dq) = 1 Then
                                            If i <> 1 Then
                                                cb = 1
                                            End If
                                            Exit For
                                        End If
                                    ElseIf ptx = 2 Then
                                        If sst(cq + i, dq) = 2 Then
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
                                If dq - i < 1 Then
                                    Exit For
                                Else
                                    If sst(cq, dq - i) = 0 Or sst(cq, dq - i) = 3 Then
                                        Exit For
                                    End If
                                    If ptx = 1 Then
                                        If sst(cq, dq - i) = 1 Then
                                            If i <> 1 Then
                                                cb = 1
                                            End If
                                            Exit For
                                        End If
                                    ElseIf ptx = 2 Then
                                        If sst(cq, dq - i) = 2 Then
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
                                If cq - i < 1 Then
                                    Exit For
                                Else
                                    If sst(cq - i, dq) = 0 Or sst(cq - i, dq) = 3 Then
                                        Exit For
                                    End If
                                    If ptx = 1 Then
                                        If sst(cq - i, dq) = 1 Then
                                            If i <> 1 Then
                                                cb = 1
                                            End If
                                            Exit For
                                        End If
                                    ElseIf ptx = 2 Then
                                        If sst(cq - i, dq) = 2 Then
                                            If i <> 1 Then
                                                cb = 1
                                            End If
                                            Exit For
                                        End If
                                    End If
                                End If
                            Next
                            'Right and dqown
                            For i = 1 To 7
                                If cq + i > 8 Or dq + i > 8 Then
                                    Exit For
                                Else
                                    If sst(cq + i, dq + i) = 0 Or sst(cq + i, dq + i) = 3 Then
                                        Exit For
                                    End If
                                    If ptx = 1 Then
                                        If sst(cq + i, dq + i) = 1 Then
                                            If i <> 1 Then
                                                cb = 1
                                            End If
                                            Exit For
                                        End If
                                    ElseIf ptx = 2 Then
                                        If sst(cq + i, dq + i) = 2 Then
                                            If i <> 1 Then
                                                cb = 1
                                            End If
                                            Exit For
                                        End If
                                    End If
                                End If
                            Next
                            'Left and dqown
                            For i = 1 To 7
                                If cq + i > 8 Or dq - i < 1 Then
                                    Exit For
                                Else
                                    If sst(cq + i, dq - i) = 0 Or sst(cq + i, dq - i) = 3 Then
                                        Exit For
                                    End If
                                    If ptx = 1 Then
                                        If sst(cq + i, dq - i) = 1 Then
                                            If i <> 1 Then
                                                cb = 1
                                            End If
                                            Exit For
                                        End If
                                    ElseIf ptx = 2 Then
                                        If sst(cq + i, dq - i) = 2 Then
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
                                If cq - i < 1 Or dq - i < 1 Then
                                    Exit For
                                Else
                                    If sst(cq - i, dq - i) = 0 Or sst(cq - i, dq - i) = 3 Then
                                        Exit For
                                    End If
                                    If ptx = 1 Then
                                        If sst(cq - i, dq - i) = 1 Then
                                            If i <> 1 Then
                                                cb = 1
                                            End If
                                            Exit For
                                        End If
                                    ElseIf ptx = 2 Then
                                        If sst(cq - i, dq - i) = 2 Then
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
                                If cq - i < 1 Or dq + i > 8 Then
                                    Exit For
                                Else
                                    If sst(cq - i, dq + i) = 0 Or sst(cq - i, dq + i) = 3 Then
                                        Exit For
                                    End If
                                    If ptx = 1 Then
                                        If sst(cq - i, dq + i) = 1 Then
                                            If i <> 1 Then
                                                cb = 1
                                            End If
                                            Exit For
                                        End If
                                    ElseIf ptx = 2 Then
                                        If sst(cq - i, dq + i) = 2 Then
                                            If i <> 1 Then
                                                cb = 1
                                            End If
                                            Exit For
                                        End If
                                    End If
                                End If
                            Next
                            If cb = 1 Then
                                sst(cq, dq) = 3
                                aiwt &= "#" & cq & dq
                                cx = 1
                            End If
                        End If
                    Next
                Next
                If cx = 1 Then
                    If nn = 1 Then
                        bpo = 1
                    End If
                    Exit For
                End If
            Next
        End If
    End Sub

    Sub AIR()
        If ain = 1 Then
            Dim sw As New StreamWriter("AI\AI.aifo", True, System.Text.Encoding.GetEncoding("shift_jis"))
            If p1 < 10 AndAlso p2 < 10 Then
                sw.WriteLine(aip & "!" & grs & "?" & "0" & p1 & "0" & p2 & "$")
            ElseIf p1 < 10 Then
                sw.WriteLine(aip & "!" & grs & "?" & "0" & p1 & p2 & "$")
            ElseIf p2 < 10 Then
                sw.WriteLine(aip & "!" & grs & "?" & p1 & "0" & p2 & "$")
            Else
                sw.WriteLine(aip & "!" & grs & "?" & p1 & p2 & "$")
            End If
            sw.Close()
            sw.Dispose()
        ElseIf a1 = 3 Then
            If Not aid.Contains(aip) Then
                Dim sw As New StreamWriter("AI\AI.aifo", True, System.Text.Encoding.GetEncoding("shift_jis"))
                If p1 < 10 AndAlso p2 < 10 Then
                    sw.WriteLine(aip & "!" & grs & "?" & "0" & p1 & "0" & p2 & "$")
                ElseIf p1 < 10 Then
                    sw.WriteLine(aip & "!" & grs & "?" & "0" & p1 & p2 & "$")
                ElseIf p2 < 10 Then
                    sw.WriteLine(aip & "!" & grs & "?" & p1 & "0" & p2 & "$")
                Else
                    sw.WriteLine(aip & "!" & grs & "?" & p1 & p2 & "$")
                End If
                sw.Close()
                sw.Dispose()
            End If
        End If
    End Sub

    Sub SCS()
        If sc = 0 Then
            ce = 1
            Dim sendBytes As Byte() = System.Text.Encoding.UTF8.GetBytes(bs)
            If pm = 2 Then
                Try
                    udpClient = New UdpClient()
                Catch ex As SocketException
                    MsgBox("クライアントとの接続に問題が発生しました" & vbCrLf & "設定からやり直してください")
                    Close()
                    Exit Sub
                End Try
                udpClient.BeginSend(sendBytes, sendBytes.Length, ch, cp, AddressOf SendCallback, udpClient)
                udpClient.Dispose()
            Else
                Try
                    udp1 = New UdpClient()
                Catch ex As SocketException
                    MsgBox("クライアントとの接続に問題が発生しました" & vbCrLf & "設定からやり直してください")
                    Close()
                    Exit Sub
                End Try
                Try
                    udp2 = New UdpClient()
                Catch ex As SocketException
                    MsgBox("クライアントとの接続に問題が発生しました" & vbCrLf & "設定からやり直してください")
                    Close()
                    Exit Sub
                End Try
                Try
                    udp3 = New UdpClient()
                Catch ex As SocketException
                    MsgBox("クライアントとの接続に問題が発生しました" & vbCrLf & "設定からやり直してください")
                    Close()
                    Exit Sub
                End Try
                udp1.BeginSend(sendBytes, sendBytes.Length, ch1, cp1, AddressOf SendCallback, udp1)
                udp2.BeginSend(sendBytes, sendBytes.Length, ch2, cp2, AddressOf SendCallback, udp2)
                udp3.BeginSend(sendBytes, sendBytes.Length, ch3, cp3, AddressOf SendCallback, udp3)
                udp1.Dispose()
                udp2.Dispose()
                udp3.Dispose()
            End If
            If pnm = pt Then
                ce = 0
                Exit Sub
            End If
            If ge = 1 Then
                Exit Sub
            End If
            SCR()
        Else
            ce = 1
            Dim sendBytes As Byte() = System.Text.Encoding.UTF8.GetBytes(bs)
            If pm = 2 Then
                Try
                    udpClient = New UdpClient()
                Catch ex As SocketException
                    MsgBox("サーバーとの接続に問題が発生しました" & vbCrLf & "設定からやり直してください")
                    Close()
                    Exit Sub
                End Try
                udpClient.BeginSend(sendBytes, sendBytes.Length, sh, sp, AddressOf SendCallback, udpClient)
                udpClient.Dispose()
            Else
                Try
                    udpClient = New UdpClient(New Net.IPEndPoint(Net.IPAddress.Any, cp))
                Catch ex As SocketException
                    MsgBox("サーバーとの接続に問題が発生しました" & vbCrLf & "設定からやり直してください")
                    Close()
                    Exit Sub
                End Try
                udpClient.BeginSend(sendBytes, sendBytes.Length, sh, sp, AddressOf SendCallback, udpClient)
                udpClient.Dispose()
            End If
            If pnm = pt Then
                ce = 0
                Exit Sub
            End If
            If ge = 1 Then
                Exit Sub
            End If
            SCR()
        End If
    End Sub

    Sub SCSX(str As String, cnx As Integer)
        Dim sendBytes As Byte() = System.Text.Encoding.UTF8.GetBytes(str)
        Try
            udpx = New UdpClient()
        Catch ex As SocketException
            MsgBox("クライアントとの接続に問題が発生しました" & vbCrLf & "設定からやり直してください")
            Close()
            Exit Sub
        End Try
        If cnx = 1 Then
            udpx.BeginSend(sendBytes, sendBytes.Length, ch1, cp1, AddressOf SendCallback, udpx)
        ElseIf cnx = 2 Then
            udpx.BeginSend(sendBytes, sendBytes.Length, ch2, cp2, AddressOf SendCallback, udpx)
        ElseIf cnx = 3 Then
            udpx.BeginSend(sendBytes, sendBytes.Length, ch3, cp3, AddressOf SendCallback, udpx)
        End If
        udpx.Dispose()
    End Sub

    Sub SCR()
        LG()
        If sc = 0 Then
            Dim localEP As New Net.IPEndPoint(Net.IPAddress.Any, sp)
            Try
                udpClient = New UdpClient(localEP)
            Catch ex As SocketException
                MsgBox("クライアントとの接続に問題が発生しました" & vbCrLf & "設定からやり直してください")
                Close()
                Exit Sub
            End Try
            udpClient.BeginReceive(AddressOf ReceiveCallback, udpClient)
        Else
            Dim localEP As New Net.IPEndPoint(Net.IPAddress.Any, cp)
            Try
                udpClient = New UdpClient(localEP)
            Catch ex As SocketException
                MsgBox("サーバーとの接続に問題が発生しました" & vbCrLf & "設定からやり直してください")
                Close()
                Exit Sub
            End Try
            udpClient.BeginReceive(AddressOf ReceiveCallback, udpClient)
        End If
    End Sub

    Private Sub SendCallback(ar As IAsyncResult)
        Dim udp As UdpClient = DirectCast(ar.AsyncState, UdpClient)
        Try
            udp.EndSend(ar)
        Catch ex As SocketException
            Return
        Catch ex As ObjectDisposedException
            Return
        End Try
        udp.Dispose()
    End Sub

    Private Sub ReceiveCallback(ar As IAsyncResult)
        Dim udp As UdpClient = DirectCast(ar.AsyncState, UdpClient)
        Dim remoteEP As Net.IPEndPoint = Nothing
        Dim rcvBytes As Byte()
        Try
            rcvBytes = udp.EndReceive(ar, remoteEP)
        Catch ex As SocketException
            Return
        Catch ex As ObjectDisposedException
            Return
        End Try
        udp.Dispose()
        Dim rcvMsg As String = System.Text.Encoding.UTF8.GetString(rcvBytes)
        ce = 0
        nc = 1
        Task.Run(Sub()
                     Invoke(New DelButPerCli(AddressOf ButPerCli), CType(FindForm.Controls("Button" & rcvMsg), Button))
                 End Sub)
        If pm = 4 And sc = 0 Then
            If Array.IndexOf(Net.Dns.GetHostAddresses(ch1), remoteEP.Address) >= 0 And remoteEP.Port = cp1 Then
                SCSX(rcvMsg, 2)
                SCSX(rcvMsg, 3)
            ElseIf Array.IndexOf(Net.Dns.GetHostAddresses(ch2), remoteEP.Address) >= 0 And remoteEP.Port = cp2 Then
                SCSX(rcvMsg, 1)
                SCSX(rcvMsg, 3)
            ElseIf Array.IndexOf(Net.Dns.GetHostAddresses(ch3), remoteEP.Address) >= 0 And remoteEP.Port = cp3 Then
                SCSX(rcvMsg, 1)
                SCSX(rcvMsg, 2)
            End If
        End If
    End Sub

    Delegate Sub DelButPerCli(ByVal But As Button)

    Private Sub ButPerCli(ByVal But As Button)
        But.PerformClick()
    End Sub

    Private Sub Game_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        fp.Hide()
        fu.cpc = 1
        fu.Close()
        If Not udpClient Is Nothing Then
            udpClient.Dispose()
        End If
    End Sub
End Class