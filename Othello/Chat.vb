Imports System.Drawing
Imports System.Net.Sockets
Imports System.Threading.Tasks
Imports System.Windows.Forms

Public Class Chat
    Public cpc, pm, sc, scn As Byte
    Public sh, ch, ch1, ch2, ch3 As String
    Dim pn1, pn2, pn3, pn4 As String
    Dim st As String
    Dim tsh, tsm, tss, tsa As String
    Dim td As Date
    Dim bt As Button
    Dim sendBytes As Byte()
    Dim localEP As Net.IPEndPoint
    Private udpS, udpR, udpX As UdpClient
    Private Sub Chat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        td = Date.Now
        tsh = td.Hour.ToString
        If tsh.Length = 1 Then
            tsh = "0" & tsh
        End If
        tsm = td.Minute.ToString
        If tsm.Length = 1 Then
            tsm = "0" & tsm
        End If
        tss = td.Second.ToString
        If tss.Length = 1 Then
            tss = "0" & tss
        End If
        tsa = "[" & tsh & ":" & tsm & ":" & tss & "]"
        If pm = 2 Then
            SA.Hide()
            N1.ForeColor = Color.Black
            N1.Text = "Player Black"
            N2.ForeColor = Color.White
            N2.Text = "Player White"
            S1.ForeColor = Color.Lime
            S1.BackColor = Color.Black
            S2.ForeColor = Color.Lime
            S2.BackColor = Color.White
            N3.Hide()
            N4.Hide()
            S3.Hide()
            S4.Hide()
            If sc = 0 Then
                N1.BackColor = Color.Lime
                S1.Hide()
            Else
                N2.BackColor = Color.Lime
                S2.Hide()
            End If
            If sc = 0 Then
                Text = "Chat - Player Black"
            ElseIf sc = 1 Then
                Text = "Chat - Player White"
            End If
            TL.BackColor = Color.Orange
            TL.SelectionStart = TL.Text.Length
            TL.SelectionColor = Color.Red
            TL.AppendText(tsa & "      <Game Server>  ⇒         <Everyone>  Chat Started")
        ElseIf pm = 4 Then
            If scn = 1 Then
                N1.BackColor = Color.White
                S1.Hide()
            ElseIf scn = 2 Then
                N2.BackColor = Color.White
                S2.Hide()
            ElseIf scn = 3 Then
                N3.BackColor = Color.White
                S3.Hide()
            ElseIf scn = 4 Then
                N4.BackColor = Color.White
                S4.Hide()
            End If
            If scn = 1 Then
                Text = "Chat - Player Red"
            ElseIf scn = 2 Then
                Text = "Chat - Player Blue"
            ElseIf scn = 3 Then
                Text = "Chat - Player Yellow"
            ElseIf scn = 4 Then
                Text = "Chat - Player Green"
            End If
            TL.BackColor = Color.White
            TL.SelectionStart = TL.Text.Length
            TL.SelectionColor = Color.Black
            TL.AppendText(tsa & "      <Game Server>  ⇒         <Everyone>  Chat Started")
        End If
        cpc = 0
        SCR()
    End Sub

    Private Sub S_Click(sender As Object, e As EventArgs) Handles S1.Click, S2.Click, S3.Click, S4.Click, SA.Click
        If TS.Text = "" Then
            MsgBox("送信するメッセージを入力してください")
            Exit Sub
        End If
        If N1.Text = "" Then
            MsgBox("プレイヤー名を入力してください")
            Exit Sub
        End If
        If N2.Text = "" Then
            MsgBox("プレイヤー名を入力してください")
            Exit Sub
        End If
        If N3.Text = "" Then
            MsgBox("プレイヤー名を入力してください")
            Exit Sub
        End If
        If N4.Text = "" Then
            MsgBox("プレイヤー名を入力してください")
            Exit Sub
        End If
        bt = CType(sender, Button)
        st = bt.Name.Substring(1, 1)
        td = Date.Now
        tsh = td.Hour.ToString
        If tsh.Length = 1 Then
            tsh = "0" & tsh
        End If
        tsm = td.Minute.ToString
        If tsm.Length = 1 Then
            tsm = "0" & tsm
        End If
        tss = td.Second.ToString
        If tss.Length = 1 Then
            tss = "0" & tss
        End If
        tsa = "[" & tsh & ":" & tsm & ":" & tss & "]"
        pn1 = "<" & N1.Text & ">"
        If pn1.Length < 17 Then
            For i = 1 To 17 - pn1.Length
                pn1 = " " & pn1
            Next
        End If
        pn2 = "<" & N2.Text & ">"
        If pn2.Length < 17 Then
            For i = 1 To 17 - pn2.Length
                pn2 = " " & pn2
            Next
        End If
        pn3 = "<" & N3.Text & ">"
        If pn3.Length < 17 Then
            For i = 1 To 17 - pn3.Length
                pn3 = " " & pn3
            Next
        End If
        pn4 = "<" & N4.Text & ">"
        If pn4.Length < 17 Then
            For i = 1 To 17 - pn4.Length
                pn4 = " " & pn4
            Next
        End If
        If pm = 2 Then
            If sc = 0 Then
                TL.SelectionStart = TL.Text.Length
                TL.SelectionColor = Color.Black
                TL.AppendText(vbCrLf & tsa & "  " & pn1 & "  ⇒  " & pn2 & "  " & TS.Text)
            Else
                TL.SelectionStart = TL.Text.Length
                TL.SelectionColor = Color.White
                TL.AppendText(vbCrLf & tsa & "  " & pn2 & "  ⇒  " & pn1 & "  " & TS.Text)
            End If
            SCS(tsa & TS.Text)
        Else
            If st = "1" Then
                If scn = 2 Then
                    TL.SelectionStart = TL.Text.Length
                    TL.SelectionColor = Color.SkyBlue
                    TL.AppendText(vbCrLf & tsa & "  " & pn2 & "  ⇒  " & pn1 & "  " & TS.Text)
                    SCS(tsa & "21" & TS.Text)
                ElseIf scn = 3 Then
                    TL.SelectionStart = TL.Text.Length
                    TL.SelectionColor = Color.Orange
                    TL.AppendText(vbCrLf & tsa & "  " & pn3 & "  ⇒  " & pn1 & "  " & TS.Text)
                    SCS(tsa & "31" & TS.Text)
                ElseIf scn = 4 Then
                    TL.SelectionColor = Color.LawnGreen
                    TL.AppendText(vbCrLf & tsa & "  " & pn4 & "  ⇒  " & pn1 & "  " & TS.Text)
                    SCS(tsa & "41" & TS.Text)
                End If
            ElseIf st = "2" Then
                If scn = 1 Then
                    TL.SelectionStart = TL.Text.Length
                    TL.SelectionColor = Color.Red
                    TL.AppendText(vbCrLf & tsa & "  " & pn1 & "  ⇒  " & pn2 & "  " & TS.Text)
                    SCS(tsa & "12" & TS.Text)
                ElseIf scn = 3 Then
                    TL.SelectionStart = TL.Text.Length
                    TL.SelectionColor = Color.Orange
                    TL.AppendText(vbCrLf & tsa & "  " & pn3 & "  ⇒  " & pn2 & "  " & TS.Text)
                    SCS(tsa & "32" & TS.Text)
                ElseIf scn = 4 Then
                    TL.SelectionStart = TL.Text.Length
                    TL.SelectionColor = Color.LawnGreen
                    TL.AppendText(vbCrLf & tsa & "  " & pn4 & "  ⇒  " & pn2 & "  " & TS.Text)
                    SCS(tsa & "42" & TS.Text)
                End If
            ElseIf st = "3" Then
                If scn = 1 Then
                    TL.SelectionStart = TL.Text.Length
                    TL.SelectionColor = Color.Red
                    TL.AppendText(vbCrLf & tsa & "  " & pn1 & "  ⇒  " & pn3 & "  " & TS.Text)
                    SCS(tsa & "13" & TS.Text)
                ElseIf scn = 2 Then
                    TL.SelectionStart = TL.Text.Length
                    TL.SelectionColor = Color.SkyBlue
                    TL.AppendText(vbCrLf & tsa & "  " & pn2 & "  ⇒  " & pn3 & "  " & TS.Text)
                    SCS(tsa & "23" & TS.Text)
                ElseIf scn = 4 Then
                    TL.SelectionStart = TL.Text.Length
                    TL.SelectionColor = Color.LawnGreen
                    TL.AppendText(vbCrLf & tsa & "  " & pn4 & "  ⇒  " & pn3 & "  " & TS.Text)
                    SCS(tsa & "43" & TS.Text)
                End If
            ElseIf st = "4" Then
                If scn = 1 Then
                    TL.SelectionStart = TL.Text.Length
                    TL.SelectionColor = Color.Red
                    TL.AppendText(vbCrLf & tsa & "  " & pn1 & "  ⇒  " & pn4 & "  " & TS.Text)
                    SCS(tsa & "14 " & TS.Text)
                ElseIf scn = 2 Then
                    TL.SelectionStart = TL.Text.Length
                    TL.SelectionColor = Color.SkyBlue
                    TL.AppendText(vbCrLf & tsa & "  " & pn2 & "  ⇒  " & pn4 & "  " & TS.Text)
                    SCS(tsa & "24" & TS.Text)
                ElseIf scn = 3 Then
                    TL.SelectionStart = TL.Text.Length
                    TL.SelectionColor = Color.Orange
                    TL.AppendText(vbCrLf & tsa & "  " & pn3 & "  ⇒  " & pn4 & "  " & TS.Text)
                    SCS(tsa & "34" & TS.Text)
                End If
            Else
                If scn = 1 Then
                    TL.SelectionStart = TL.Text.Length
                    TL.SelectionColor = Color.Red
                    TL.AppendText(vbCrLf & tsa & "  " & pn1 & "  ⇒         <Everyone>  " & TS.Text)
                    SCS(tsa & "1A" & TS.Text)
                ElseIf scn = 2 Then
                    TL.SelectionStart = TL.Text.Length
                    TL.SelectionColor = Color.SkyBlue
                    TL.AppendText(vbCrLf & tsa & "  " & pn2 & "  ⇒         <Everyone>  " & TS.Text)
                    SCS(tsa & "2A" & TS.Text)
                ElseIf scn = 3 Then
                    TL.SelectionStart = TL.Text.Length
                    TL.SelectionColor = Color.Orange
                    TL.AppendText(vbCrLf & tsa & "  " & pn3 & "  ⇒         <Everyone>  " & TS.Text)
                    SCS(tsa & "3A" & TS.Text)
                ElseIf scn = 4 Then
                    TL.SelectionStart = TL.Text.Length
                    TL.SelectionColor = Color.LawnGreen
                    TL.AppendText(vbCrLf & tsa & "  " & pn4 & "  ⇒         <Everyone>  " & TS.Text)
                    SCS(tsa & "4A" & TS.Text)
                End If
            End If
        End If
        TS.Text = ""
    End Sub

    Sub SCS(bs As String)
        sendBytes = System.Text.Encoding.UTF8.GetBytes(bs)
        If sc = 0 Then
            If pm = 2 Then
                Try
                    udpS = New UdpClient()
                Catch ex As SocketException
                    MsgBox("クライアントとの接続に問題が発生しました" & vbCrLf & "送信をやり直してください")
                    Exit Sub
                End Try
                udpS.BeginSend(sendBytes, sendBytes.Length, ch, 50012, AddressOf SendCallback, udpS)
            Else
                If st = "2" Then
                    Try
                        udpS = New UdpClient()
                    Catch ex As SocketException
                        MsgBox("クライアントとの接続に問題が発生しました" & vbCrLf & "送信をやり直してください")
                        Exit Sub
                    End Try
                    udpS.BeginSend(sendBytes, sendBytes.Length, ch1, 50012, AddressOf SendCallback, udpS)
                ElseIf st = "3" Then
                    Try
                        udpS = New UdpClient()
                    Catch ex As SocketException
                        MsgBox("クライアントとの接続に問題が発生しました" & vbCrLf & "送信をやり直してください")
                        Exit Sub
                    End Try
                    udpS.BeginSend(sendBytes, sendBytes.Length, ch2, 50013, AddressOf SendCallback, udpS)
                ElseIf st = "4" Then
                    Try
                        udpS = New UdpClient()
                    Catch ex As SocketException
                        MsgBox("クライアントとの接続に問題が発生しました" & vbCrLf & "送信をやり直してください")
                        Exit Sub
                    End Try
                    udpS.BeginSend(sendBytes, sendBytes.Length, ch3, 50014, AddressOf SendCallback, udpS)
                ElseIf st = "A" Then
                    Try
                        udpS = New UdpClient()
                    Catch ex As SocketException
                        MsgBox("クライアントとの接続に問題が発生しました" & vbCrLf & "送信をやり直してください")
                        Exit Sub
                    End Try
                    udpS.BeginSend(sendBytes, sendBytes.Length, ch1, 50012, AddressOf SendCallback, udpS)
                    Try
                        udpS = New UdpClient()
                    Catch ex As SocketException
                        MsgBox("クライアントとの接続に問題が発生しました" & vbCrLf & "送信をやり直してください")
                        Exit Sub
                    End Try
                    udpS.BeginSend(sendBytes, sendBytes.Length, ch2, 50013, AddressOf SendCallback, udpS)
                    Try
                        udpS = New UdpClient()
                    Catch ex As SocketException
                        MsgBox("クライアントとの接続に問題が発生しました" & vbCrLf & "送信をやり直してください")
                        Exit Sub
                    End Try
                    udpS.BeginSend(sendBytes, sendBytes.Length, ch3, 50014, AddressOf SendCallback, udpS)
                End If
            End If
        Else
            Try
                udpS = New UdpClient()
            Catch ex As SocketException
                MsgBox("サーバーとの接続に問題が発生しました" & vbCrLf & "送信をやり直してください")
                Exit Sub
            End Try
            udpS.BeginSend(sendBytes, sendBytes.Length, sh, 50011, AddressOf SendCallback, udpS)
        End If
        udpS.Dispose()
    End Sub

    Sub SCSX(bs As String, stx As Byte)
        sendBytes = System.Text.Encoding.UTF8.GetBytes(bs)
        Try
            udpX = New UdpClient()
        Catch ex As SocketException
            MsgBox("クライアントとの接続に問題が発生しました" & vbCrLf & "送信をやり直してください")
            Exit Sub
        End Try
        If stx = 2 Then
            udpX.BeginSend(sendBytes, sendBytes.Length, ch1, 50012, AddressOf SendCallback, udpX)
        ElseIf stx = 3 Then
            udpX.BeginSend(sendBytes, sendBytes.Length, ch2, 50013, AddressOf SendCallback, udpX)
        ElseIf stx = 4 Then
            udpX.BeginSend(sendBytes, sendBytes.Length, ch3, 50014, AddressOf SendCallback, udpX)
        End If
        udpX.Dispose()
    End Sub

    Sub SCR()
        If sc = 0 Then
            localEP = New Net.IPEndPoint(Net.IPAddress.Any, 50011)
            Try
                udpR = New UdpClient(localEP)
            Catch ex As SocketException
                MsgBox("クライアントとの接続に問題が発生しました" & vbCrLf & "設定からやり直してください")
                Close()
                Exit Sub
            End Try
        Else
            If pm = 2 Then
                localEP = New Net.IPEndPoint(Net.IPAddress.Any, 50012)
            Else
                If scn = 2 Then
                    localEP = New Net.IPEndPoint(Net.IPAddress.Any, 50012)
                ElseIf scn = 3 Then
                    localEP = New Net.IPEndPoint(Net.IPAddress.Any, 50013)
                ElseIf scn = 4 Then
                    localEP = New Net.IPEndPoint(Net.IPAddress.Any, 50014)
                End If
            End If
            Try
                udpR = New UdpClient(localEP)
            Catch ex As SocketException
                MsgBox("サーバーとの接続に問題が発生しました" & vbCrLf & "設定からやり直してください")
                Close()
                Exit Sub
            End Try
        End If
        udpR.BeginReceive(AddressOf ReceiveCallback, udpR)
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
        Dim rcvMsg As String = System.Text.Encoding.UTF8.GetString(rcvBytes)
        pn1 = "<" & N1.Text & ">"
        If pn1.Length < 17 Then
            For i = 1 To 17 - pn1.Length
                pn1 = " " & pn1
            Next
        End If
        pn2 = "<" & N2.Text & ">"
        If pn2.Length < 17 Then
            For i = 1 To 17 - pn2.Length
                pn2 = " " & pn2
            Next
        End If
        pn3 = "<" & N3.Text & ">"
        If pn3.Length < 17 Then
            For i = 1 To 17 - pn3.Length
                pn3 = " " & pn3
            Next
        End If
        pn4 = "<" & N4.Text & ">"
        If pn4.Length < 17 Then
            For i = 1 To 17 - pn4.Length
                pn4 = " " & pn4
            Next
        End If
        If sc = 0 Then
            If pm = 2 Then
                Invoke(New DelTBTex(AddressOf TBTex), TL, vbCrLf & rcvMsg.Substring(0, 10) & "  " & pn2 & "  ⇒  " & pn1 & "  " & rcvMsg.Substring(10), Color.White)
            Else
                If rcvMsg.Substring(11, 1) = "1" Then
                    If rcvMsg.Substring(10, 1) = "2" Then
                        Invoke(New DelTBTex(AddressOf TBTex), TL, vbCrLf & rcvMsg.Substring(0, 10) & "  " & pn2 & "  ⇒  " & pn1 & "  " & rcvMsg.Substring(12), Color.SkyBlue)
                    ElseIf rcvMsg.Substring(10, 1) = "3" Then
                        Invoke(New DelTBTex(AddressOf TBTex), TL, vbCrLf & rcvMsg.Substring(0, 10) & "  " & pn3 & "  ⇒  " & pn1 & "  " & rcvMsg.Substring(12), Color.Orange)
                    ElseIf rcvMsg.Substring(10, 1) = "4" Then
                        Invoke(New DelTBTex(AddressOf TBTex), TL, vbCrLf & rcvMsg.Substring(0, 10) & "  " & pn4 & "  ⇒  " & pn1 & "  " & rcvMsg.Substring(12), Color.LawnGreen)
                    End If
                ElseIf rcvMsg.Substring(11, 1) = "2" Then
                    SCSX(rcvMsg, 2)
                ElseIf rcvMsg.Substring(11, 1) = "3" Then
                    SCSX(rcvMsg, 3)
                ElseIf rcvMsg.Substring(11, 1) = "4" Then
                    SCSX(rcvMsg, 4)
                ElseIf rcvMsg.Substring(11, 1) = "A" Then
                    If rcvMsg.Substring(10, 1) = "2" Then
                        Task.Run(Sub()
                                     Invoke(New DelTBTex(AddressOf TBTex), TL, vbCrLf & rcvMsg.Substring(0, 10) & "  " & pn2 & "  ⇒         <Everyone>  " & rcvMsg.Substring(12), Color.SkyBlue)
                                 End Sub)
                        SCSX(rcvMsg, 3)
                        SCSX(rcvMsg, 4)
                    ElseIf rcvMsg.Substring(10, 1) = "3" Then
                        Task.Run(Sub()
                                     Invoke(New DelTBTex(AddressOf TBTex), TL, vbCrLf & rcvMsg.Substring(0, 10) & "  " & pn3 & "  ⇒         <Everyone>  " & rcvMsg.Substring(12), Color.Orange)
                                 End Sub)
                        SCSX(rcvMsg, 2)
                        SCSX(rcvMsg, 4)
                    ElseIf rcvMsg.Substring(10, 1) = "4" Then
                        Task.Run(Sub()
                                     Invoke(New DelTBTex(AddressOf TBTex), TL, vbCrLf & rcvMsg.Substring(0, 10) & "  " & pn4 & "  ⇒         <Everyone>  " & rcvMsg.Substring(12), Color.LawnGreen)
                                 End Sub)
                        SCSX(rcvMsg, 2)
                        SCSX(rcvMsg, 3)
                    End If
                End If
            End If
        Else
            If pm = 2 Then
                Invoke(New DelTBTex(AddressOf TBTex), TL, vbCrLf & rcvMsg.Substring(0, 10) & "  " & pn1 & "  ⇒  " & pn2 & "  " & rcvMsg.Substring(10), Color.Black)
            Else
                If rcvMsg.Substring(11, 1) = "2" Then
                    If rcvMsg.Substring(10, 1) = "1" Then
                        Invoke(New DelTBTex(AddressOf TBTex), TL, vbCrLf & rcvMsg.Substring(0, 10) & "  " & pn1 & "  ⇒  " & pn2 & "  " & rcvMsg.Substring(12), Color.Red)
                    ElseIf rcvMsg.Substring(10, 1) = "3" Then
                        Invoke(New DelTBTex(AddressOf TBTex), TL, vbCrLf & rcvMsg.Substring(0, 10) & "  " & pn3 & "  ⇒  " & pn2 & "  " & rcvMsg.Substring(12), Color.Orange)
                    ElseIf rcvMsg.Substring(10, 1) = "4" Then
                        Invoke(New DelTBTex(AddressOf TBTex), TL, vbCrLf & rcvMsg.Substring(0, 10) & "  " & pn4 & "  ⇒  " & pn2 & "  " & rcvMsg.Substring(12), Color.LawnGreen)
                    End If
                ElseIf rcvMsg.Substring(11, 1) = "3" Then
                    If rcvMsg.Substring(10, 1) = "1" Then
                        Invoke(New DelTBTex(AddressOf TBTex), TL, vbCrLf & rcvMsg.Substring(0, 10) & "  " & pn1 & "  ⇒  " & pn3 & "  " & rcvMsg.Substring(12), Color.Red)
                    ElseIf rcvMsg.Substring(10, 1) = "2" Then
                        Invoke(New DelTBTex(AddressOf TBTex), TL, vbCrLf & rcvMsg.Substring(0, 10) & "  " & pn2 & "  ⇒  " & pn3 & "  " & rcvMsg.Substring(12), Color.SkyBlue)
                    ElseIf rcvMsg.Substring(10, 1) = "4" Then
                        Invoke(New DelTBTex(AddressOf TBTex), TL, vbCrLf & rcvMsg.Substring(0, 10) & "  " & pn4 & "  ⇒  " & pn3 & "  " & rcvMsg.Substring(12), Color.LawnGreen)
                    End If
                ElseIf rcvMsg.Substring(11, 1) = "4" Then
                    If rcvMsg.Substring(10, 1) = "1" Then
                        Invoke(New DelTBTex(AddressOf TBTex), TL, vbCrLf & rcvMsg.Substring(0, 10) & "  " & pn1 & "  ⇒  " & pn4 & "  " & rcvMsg.Substring(12), Color.Red)
                    ElseIf rcvMsg.Substring(10, 1) = "2" Then
                        Invoke(New DelTBTex(AddressOf TBTex), TL, vbCrLf & rcvMsg.Substring(0, 10) & "  " & pn2 & "  ⇒  " & pn4 & "  " & rcvMsg.Substring(12), Color.SkyBlue)
                    ElseIf rcvMsg.Substring(10, 1) = "3" Then
                        Invoke(New DelTBTex(AddressOf TBTex), TL, vbCrLf & rcvMsg.Substring(0, 10) & "  " & pn3 & "  ⇒  " & pn4 & "  " & rcvMsg.Substring(12), Color.Orange)
                    End If
                ElseIf rcvMsg.Substring(11, 1) = "A" Then
                    If rcvMsg.Substring(10, 1) = "1" Then
                        Invoke(New DelTBTex(AddressOf TBTex), TL, vbCrLf & rcvMsg.Substring(0, 10) & "  " & pn1 & "  ⇒         <Everyone>  " & rcvMsg.Substring(12), Color.Red)
                    ElseIf rcvMsg.Substring(10, 1) = "2" Then
                        Invoke(New DelTBTex(AddressOf TBTex), TL, vbCrLf & rcvMsg.Substring(0, 10) & "  " & pn2 & "  ⇒         <Everyone>  " & rcvMsg.Substring(12), Color.SkyBlue)
                    ElseIf rcvMsg.Substring(10, 1) = "3" Then
                        Invoke(New DelTBTex(AddressOf TBTex), TL, vbCrLf & rcvMsg.Substring(0, 10) & "  " & pn3 & "  ⇒         <Everyone>  " & rcvMsg.Substring(12), Color.Orange)
                    ElseIf rcvMsg.Substring(10, 1) = "4" Then
                        Invoke(New DelTBTex(AddressOf TBTex), TL, vbCrLf & rcvMsg.Substring(0, 10) & "  " & pn4 & "  ⇒         <Everyone>  " & rcvMsg.Substring(12), Color.LawnGreen)
                    End If
                End If
            End If
        End If
        udp.BeginReceive(AddressOf ReceiveCallback, udp)
    End Sub

    Delegate Sub DelTBTex(ByVal Tex As RichTextBox, ByVal str As String, ByVal Col As Color)

    Private Sub TBTex(ByVal Tex As RichTextBox, ByVal str As String, ByVal Col As Color)
        Tex.SelectionStart = Tex.Text.Length
        Tex.SelectionColor = Col
        Tex.AppendText(str)
    End Sub

    Private Sub Chat_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If cpc = 0 Then
            e.Cancel = True
        Else
            If Not udpR Is Nothing Then
                udpR.Dispose()
            End If
        End If
    End Sub
End Class