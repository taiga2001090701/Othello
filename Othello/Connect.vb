Imports System.Drawing
Imports System.Net.Sockets
Imports System.Windows.Forms

Public Class Connect
    Public sc, scn, cc As Byte
    Public sh, ch, ch1, ch2, ch3 As String
    Public sp, cp, cp1, cp2, cp3 As Integer
    Dim sss As String
    Dim sct As Byte
    Private udpClient As UdpClient = Nothing
    Dim csc As Byte
    Private Sub Connect_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cc = 0
        csc = 0
        L1.ForeColor = Color.Red
        L2.ForeColor = Color.SkyBlue
        L3.ForeColor = Color.Orange
        L4.ForeColor = Color.LawnGreen
        L1.Text = "Player Red Connecting"
        L2.Text = "Player Blue Connecting"
        L3.Text = "Player Yellow Connecting"
        L4.Text = "Player Green Connecting"
        If sc = 0 Then
            L1.BackColor = Color.White
            L1.Text = "Player Red Ready"
            SCR()
        Else
            TOT.Start()
            SCS("C", 0)
        End If
    End Sub

    Private Sub TOT_Tick(sender As Object, e As EventArgs) Handles TOT.Tick
        TOT.Stop()
        MsgBox("サーバーに接続できませんでした" & vbCrLf & "サーバーが起動していない可能性があります" & vbCrLf & "設定からやり直してください")
        Close()
    End Sub

    Sub SCS(str As String, cnx As Integer)
        If sc = 0 Then
            Dim sendBytes As Byte() = System.Text.Encoding.UTF8.GetBytes(str)
            Try
                udpClient = New UdpClient()
            Catch ex As SocketException
                MsgBox("クライアントとの接続に問題が発生しました" & vbCrLf & "設定からやり直してください")
                Invoke(New DelFormClose(AddressOf FormClose), Me)
                Exit Sub
            End Try
            If cnx = 2 Then
                udpClient.BeginSend(sendBytes, sendBytes.Length, ch1, cp1, AddressOf SendCallback, udpClient)
            ElseIf cnx = 3 Then
                udpClient.BeginSend(sendBytes, sendBytes.Length, ch2, cp2, AddressOf SendCallback, udpClient)
            ElseIf cnx = 4 Then
                udpClient.BeginSend(sendBytes, sendBytes.Length, ch3, cp3, AddressOf SendCallback, udpClient)
            End If
            udpClient.Dispose()
        Else
            Dim sendBytes As Byte() = System.Text.Encoding.UTF8.GetBytes(str)
            Try
                udpClient = New UdpClient(New Net.IPEndPoint(Net.IPAddress.Any, cp))
            Catch ex As SocketException
                TOT.Stop()
                MsgBox("サーバーとの接続に問題が発生しました" & vbCrLf & "設定からやり直してください")
                Invoke(New DelFormClose(AddressOf FormClose), Me)
                Exit Sub
            End Try
            udpClient.BeginSend(sendBytes, sendBytes.Length, sh, sp, AddressOf SendCallback, udpClient)
            udpClient.Dispose()
            If str = "R" Then
                Exit Sub
            End If
            SCR()
        End If
    End Sub

    Sub SCR()
        If sc = 0 Then
            Dim localEP As New Net.IPEndPoint(Net.IPAddress.Any, sp)
            Try
                udpClient = New UdpClient(localEP)
            Catch ex As SocketException
                MsgBox("クライアントとの接続に問題が発生しました" & vbCrLf & "設定からやり直してください")
                Invoke(New DelFormClose(AddressOf FormClose), Me)
                Exit Sub
            End Try
            udpClient.BeginReceive(AddressOf ReceiveCallback, udpClient)
        Else
            Dim localEP As New Net.IPEndPoint(Net.IPAddress.Any, cp)
            Try
                udpClient = New UdpClient(localEP)
            Catch ex As SocketException
                TOT.Stop()
                MsgBox("サーバーとの接続に問題が発生しました" & vbCrLf & "設定からやり直してください")
                Invoke(New DelFormClose(AddressOf FormClose), Me)
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
        If sc = 0 Then
            If rcvMsg = "C" Then
                If Array.IndexOf(Net.Dns.GetHostAddresses(ch1), remoteEP.Address) >= 0 And remoteEP.Port = cp1 Then
                    Invoke(New DelSetText(AddressOf SetText), L2, "Player Blue Ready")
                    sss = "2"
                    If L3.Text.Contains("Ready") Then
                        sss &= "3"
                    End If
                    If L4.Text.Contains("Ready") Then
                        sss &= "4"
                    End If
                    SCS(sss, 2)
                    Threading.Thread.Sleep(100)
                    SCS("P2", 2)
                    SCS("P2", 3)
                    SCS("P2", 4)
                    csc += 1
                ElseIf Array.IndexOf(Net.Dns.GetHostAddresses(ch2), remoteEP.Address) >= 0 And remoteEP.Port = cp2 Then
                    Invoke(New DelSetText(AddressOf SetText), L3, "Player Yellow Ready")
                    sss = "3"
                    If L2.Text.Contains("Ready") Then
                        sss &= "2"
                    End If
                    If L4.Text.Contains("Ready") Then
                        sss &= "4"
                    End If
                    SCS(sss, 3)
                    Threading.Thread.Sleep(100)
                    SCS("P3", 2)
                    SCS("P3", 3)
                    SCS("P3", 4)
                    csc += 1
                ElseIf Array.IndexOf(Net.Dns.GetHostAddresses(ch3), remoteEP.Address) >= 0 And remoteEP.Port = cp3 Then
                    Invoke(New DelSetText(AddressOf SetText), L4, "Player Green Ready")
                    sss = "4"
                    If L2.Text.Contains("Ready") Then
                        sss &= "2"
                    End If
                    If L3.Text.Contains("Ready") Then
                        sss &= "3"
                    End If
                    SCS(sss, 4)
                    Threading.Thread.Sleep(100)
                    SCS("P4", 2)
                    SCS("P4", 3)
                    SCS("P4", 4)
                    csc += 1
                End If
                If csc < 3 Then
                    SCR()
                Else
                    Threading.Thread.Sleep(100)
                    SCS("S", 2)
                    SCR()
                End If
            ElseIf rcvMsg = "R" Then
                csc += 1
                If csc = 4 Then
                    SCS("S", 3)
                    SCR()
                ElseIf csc = 5 Then
                    SCS("S", 4)
                    SCR()
                Else
                    cc = 1
                    Threading.Thread.Sleep(1000)
                    Invoke(New DelFormClose(AddressOf FormClose), Me)
                End If
            End If
        Else
            If IsNumeric(rcvMsg) Then
                TOT.Stop()
                scn = CByte(rcvMsg.Substring(0, 1))
                Invoke(New DelSetText(AddressOf SetText), L1, "Player Red Ready")
                If scn = 2 Then
                    Invoke(New DelSetColor(AddressOf SetColor), L2, Color.White)
                ElseIf scn = 3 Then
                    Invoke(New DelSetColor(AddressOf SetColor), L3, Color.White)
                ElseIf scn = 4 Then
                    Invoke(New DelSetColor(AddressOf SetColor), L4, Color.White)
                End If
                If rcvMsg.Length >= 2 Then
                    sct = CByte(rcvMsg.Substring(1, 1))
                    If sct = 2 Then
                        Invoke(New DelSetText(AddressOf SetText), L2, "Player Blue Ready")
                    ElseIf sct = 3 Then
                        Invoke(New DelSetText(AddressOf SetText), L3, "Player Yellow Ready")
                    ElseIf sct = 4 Then
                        Invoke(New DelSetText(AddressOf SetText), L4, "Player Green Ready")
                    End If
                End If
                If rcvMsg.Length >= 3 Then
                    sct = CByte(rcvMsg.Substring(2, 1))
                    If sct = 2 Then
                        Invoke(New DelSetText(AddressOf SetText), L2, "Player Blue Ready")
                    ElseIf sct = 3 Then
                        Invoke(New DelSetText(AddressOf SetText), L3, "Player Yellow Ready")
                    ElseIf sct = 4 Then
                        Invoke(New DelSetText(AddressOf SetText), L4, "Player Green Ready")
                    End If
                End If
                SCR()
            ElseIf rcvMsg.Substring(0, 1) = "P" Then
                sct = CByte(rcvMsg.Substring(1, 1))
                If sct = 2 Then
                    Invoke(New DelSetText(AddressOf SetText), L2, "Player Blue Ready")
                ElseIf sct = 3 Then
                    Invoke(New DelSetText(AddressOf SetText), L3, "Player Yellow Ready")
                ElseIf sct = 4 Then
                    Invoke(New DelSetText(AddressOf SetText), L4, "Player Green Ready")
                End If
                SCR()
            ElseIf rcvMsg = "S" Then
                Threading.Thread.Sleep(100)
                SCS("R", 0)
                cc = 1
                Threading.Thread.Sleep(1000)
                Invoke(New DelFormClose(AddressOf FormClose), Me)
            End If
        End If
    End Sub

    Delegate Sub DelSetColor(ByVal Lab As Label, ByVal Col As Color)

    Private Sub SetColor(ByVal Lab As Label, ByVal Col As Color)
        Lab.BackColor = Col
    End Sub

    Delegate Sub DelSetText(ByVal Lab As Label, ByVal Txt As String)

    Private Sub SetText(ByVal Lab As Label, ByVal Txt As String)
        Lab.Text = Txt
    End Sub

    Delegate Sub DelFormClose(ByVal Fo As Form)

    Private Sub FormClose(ByVal Fo As Form)
        Fo.Close()
    End Sub

    Private Sub Game_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If sc = 1 Then
            TOT.Stop()
        End If
        If Not udpClient Is Nothing Then
            udpClient.Dispose()
        End If
    End Sub
End Class