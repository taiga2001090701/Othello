Imports System.IO
Imports System.Windows.Forms

Public Class Setting
    Dim co As Byte
    Dim s1, s2 As Byte
    Dim ofd As New OpenFileDialog()
    Dim sfd As New SaveFileDialog()
    Private Sub Setting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        s1 = CByte(sr.ReadLine)
        s2 = CByte(sr.ReadLine)
        sr.Close()
        sr.Dispose()
        If s1 = 1 Then
            RB1.Checked = True
        ElseIf s1 = 2 Then
            RB2.Checked = True
        Else
            RB3.checked = True
        End If
        If s2 = 1 Then
            RS1.Checked = True
        Else
            RS2.Checked = True
        End If
        co = 0
        sfd.FileName = "AI.aifo"
        sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        sfd.Filter = "AIFOファイル(*.aifo)|*.aifo"
        sfd.FilterIndex = 1
        sfd.Title = "保存先のファイルを選択してください"
        sfd.RestoreDirectory = True
        ofd.FileName = "AI.aifo"
        ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        ofd.Filter = "AIFOファイル(*.aifo)|*.aifo"
        ofd.FilterIndex = 1
        ofd.Title = "開くファイルを選択してください"
        ofd.RestoreDirectory = True
    End Sub

    Private Sub BI_Click(sender As Object, e As EventArgs) Handles BI.Click
        If ofd.ShowDialog() = DialogResult.OK Then
            Dim fp As New Import
            fp.fl = ofd.FileName
            fp.ShowDialog(Me)
            fp.Dispose()
        End If
    End Sub

    Private Sub BE_Click(sender As Object, e As EventArgs) Handles BE.Click
        If sfd.ShowDialog() = DialogResult.OK Then
            IO.File.Copy("AI\AI.aifo", sfd.FileName)
        End If
    End Sub

    Private Sub BD_Click(sender As Object, e As EventArgs) Handles BD.Click
        Dim result As DialogResult = MessageBox.Show("本当に学習データを削除しますか？", "Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
        If result = DialogResult.OK Then
            IO.File.Delete("AI\AI.aifo")
        End If
    End Sub

    Private Sub BOK_Click(sender As Object, e As EventArgs) Handles BOK.Click
        Dim sw As New StreamWriter("AI\Setting.aifo", False, System.Text.Encoding.GetEncoding("shift_jis"))
        If RB1.Checked Then
            sw.WriteLine("1")
        ElseIf RB2.Checked Then
            sw.WriteLine("2")
        ElseIf RB3.Checked Then
            sw.WriteLine("3")
        End If
        If RS1.Checked Then
            sw.WriteLine("1")
        ElseIf RS2.Checked Then
            sw.WriteLine("2")
        End If
        co = 1
        sw.Close()
        sw.Dispose()
        Close()
    End Sub

    Private Sub BCA_Click(sender As Object, e As EventArgs) Handles BCA.Click
        Close()
    End Sub

    Private Sub Setting_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If co = 0 Then
            If RB1.Checked = False And s1 = 1 OrElse RB2.Checked = False And s1 = 2 OrElse RB3.Checked = False And s1 = 3 OrElse RS1.Checked = False And s2 = 1 OrElse RS2.Checked = False And s2 = 2 Then
                Dim result As DialogResult = MessageBox.Show("変更を保存しますか？", "Alert", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                If result = DialogResult.Cancel Then
                    e.Cancel = True
                ElseIf result = DialogResult.Yes Then
                    Dim sw As New StreamWriter("AI\Setting.aifo", False, System.Text.Encoding.GetEncoding("shift_jis"))
                    If RB1.Checked Then
                        sw.WriteLine("1")
                    ElseIf RB2.Checked Then
                        sw.WriteLine("2")
                    ElseIf RB3.Checked Then
                        sw.WriteLine("3")
                    End If
                    If RS1.Checked Then
                        sw.WriteLine("1")
                    ElseIf RS2.Checked Then
                        sw.WriteLine("2")
                    End If
                    sw.Close()
                    sw.Dispose()
                End If
            End If
        End If
    End Sub
End Class