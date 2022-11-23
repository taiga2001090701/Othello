<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Study
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.LP = New System.Windows.Forms.Label()
        Me.TAS = New System.Windows.Forms.Timer(Me.components)
        Me.BS = New System.Windows.Forms.Button()
        Me.TPC = New System.Windows.Forms.TextBox()
        Me.LPC = New System.Windows.Forms.Label()
        Me.LTP = New System.Windows.Forms.Label()
        Me.BE = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'LP
        '
        Me.LP.AutoSize = True
        Me.LP.Font = New System.Drawing.Font("MS UI Gothic", 25.0!)
        Me.LP.ForeColor = System.Drawing.Color.Red
        Me.LP.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.LP.Location = New System.Drawing.Point(12, 9)
        Me.LP.Name = "LP"
        Me.LP.Size = New System.Drawing.Size(137, 34)
        Me.LP.TabIndex = 206
        Me.LP.Text = "AI Study"
        '
        'TAS
        '
        Me.TAS.Interval = 10
        '
        'BS
        '
        Me.BS.BackColor = System.Drawing.Color.Red
        Me.BS.Font = New System.Drawing.Font("MS UI Gothic", 16.0!)
        Me.BS.ForeColor = System.Drawing.Color.Green
        Me.BS.Location = New System.Drawing.Point(168, 46)
        Me.BS.Name = "BS"
        Me.BS.Size = New System.Drawing.Size(80, 40)
        Me.BS.TabIndex = 207
        Me.BS.Text = "Start"
        Me.BS.UseVisualStyleBackColor = False
        '
        'TPC
        '
        Me.TPC.BackColor = System.Drawing.Color.Red
        Me.TPC.Font = New System.Drawing.Font("MS UI Gothic", 16.0!)
        Me.TPC.ForeColor = System.Drawing.Color.Green
        Me.TPC.Location = New System.Drawing.Point(12, 53)
        Me.TPC.Name = "TPC"
        Me.TPC.Size = New System.Drawing.Size(150, 29)
        Me.TPC.TabIndex = 208
        Me.TPC.Text = "1000"
        '
        'LPC
        '
        Me.LPC.AutoSize = True
        Me.LPC.Font = New System.Drawing.Font("MS UI Gothic", 25.0!)
        Me.LPC.ForeColor = System.Drawing.Color.Red
        Me.LPC.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.LPC.Location = New System.Drawing.Point(12, 89)
        Me.LPC.Margin = New System.Windows.Forms.Padding(2, 0, 10, 10)
        Me.LPC.Name = "LPC"
        Me.LPC.Size = New System.Drawing.Size(276, 34)
        Me.LPC.TabIndex = 209
        Me.LPC.Text = "0 Pattern Finished"
        '
        'LTP
        '
        Me.LTP.AutoSize = True
        Me.LTP.Font = New System.Drawing.Font("MS UI Gothic", 25.0!)
        Me.LTP.ForeColor = System.Drawing.Color.Red
        Me.LTP.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.LTP.Location = New System.Drawing.Point(12, 124)
        Me.LTP.Margin = New System.Windows.Forms.Padding(2, 0, 10, 10)
        Me.LTP.Name = "LTP"
        Me.LTP.Size = New System.Drawing.Size(231, 34)
        Me.LTP.TabIndex = 210
        Me.LTP.Text = "Total 0 Pattern"
        '
        'BE
        '
        Me.BE.BackColor = System.Drawing.Color.Red
        Me.BE.Font = New System.Drawing.Font("MS UI Gothic", 16.0!)
        Me.BE.ForeColor = System.Drawing.Color.Green
        Me.BE.Location = New System.Drawing.Point(250, 46)
        Me.BE.Margin = New System.Windows.Forms.Padding(3, 3, 10, 3)
        Me.BE.Name = "BE"
        Me.BE.Size = New System.Drawing.Size(80, 40)
        Me.BE.TabIndex = 211
        Me.BE.Text = "Stop"
        Me.BE.UseVisualStyleBackColor = False
        '
        'Study
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.Green
        Me.ClientSize = New System.Drawing.Size(336, 177)
        Me.Controls.Add(Me.BE)
        Me.Controls.Add(Me.LTP)
        Me.Controls.Add(Me.LPC)
        Me.Controls.Add(Me.TPC)
        Me.Controls.Add(Me.BS)
        Me.Controls.Add(Me.LP)
        Me.MaximizeBox = False
        Me.Name = "Study"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Study"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LP As Windows.Forms.Label
    Friend WithEvents TAS As Windows.Forms.Timer
    Friend WithEvents BS As Windows.Forms.Button
    Friend WithEvents TPC As Windows.Forms.TextBox
    Friend WithEvents LPC As Windows.Forms.Label
    Friend WithEvents LTP As Windows.Forms.Label
    Friend WithEvents BE As Windows.Forms.Button
End Class
