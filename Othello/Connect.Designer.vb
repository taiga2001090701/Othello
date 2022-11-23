<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Connect
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Connect))
        Me.L3 = New System.Windows.Forms.Label()
        Me.L4 = New System.Windows.Forms.Label()
        Me.L2 = New System.Windows.Forms.Label()
        Me.L1 = New System.Windows.Forms.Label()
        Me.TOT = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'L3
        '
        Me.L3.AutoSize = True
        Me.L3.Font = New System.Drawing.Font("MS UI Gothic", 32.0!)
        Me.L3.Location = New System.Drawing.Point(12, 124)
        Me.L3.Margin = New System.Windows.Forms.Padding(3, 3, 10, 10)
        Me.L3.Name = "L3"
        Me.L3.Size = New System.Drawing.Size(385, 43)
        Me.L3.TabIndex = 7
        Me.L3.Text = "Player 3 Connecting"
        '
        'L4
        '
        Me.L4.AutoSize = True
        Me.L4.Font = New System.Drawing.Font("MS UI Gothic", 32.0!)
        Me.L4.Location = New System.Drawing.Point(12, 180)
        Me.L4.Margin = New System.Windows.Forms.Padding(3, 3, 10, 10)
        Me.L4.Name = "L4"
        Me.L4.Size = New System.Drawing.Size(385, 43)
        Me.L4.TabIndex = 6
        Me.L4.Text = "Player 4 Connecting"
        '
        'L2
        '
        Me.L2.AutoSize = True
        Me.L2.Font = New System.Drawing.Font("MS UI Gothic", 32.0!)
        Me.L2.Location = New System.Drawing.Point(12, 68)
        Me.L2.Margin = New System.Windows.Forms.Padding(3, 3, 10, 10)
        Me.L2.Name = "L2"
        Me.L2.Size = New System.Drawing.Size(385, 43)
        Me.L2.TabIndex = 5
        Me.L2.Text = "Player 2 Connecting"
        '
        'L1
        '
        Me.L1.AutoSize = True
        Me.L1.Font = New System.Drawing.Font("MS UI Gothic", 32.0!)
        Me.L1.Location = New System.Drawing.Point(12, 12)
        Me.L1.Margin = New System.Windows.Forms.Padding(3, 3, 10, 10)
        Me.L1.Name = "L1"
        Me.L1.Size = New System.Drawing.Size(385, 43)
        Me.L1.TabIndex = 4
        Me.L1.Text = "Player 1 Connecting"
        '
        'TOT
        '
        Me.TOT.Interval = 10000
        '
        'Connect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.Green
        Me.ClientSize = New System.Drawing.Size(400, 244)
        Me.Controls.Add(Me.L3)
        Me.Controls.Add(Me.L4)
        Me.Controls.Add(Me.L2)
        Me.Controls.Add(Me.L1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Connect"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Connect"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents L3 As Windows.Forms.Label
    Friend WithEvents L4 As Windows.Forms.Label
    Friend WithEvents L2 As Windows.Forms.Label
    Friend WithEvents L1 As Windows.Forms.Label
    Friend WithEvents TOT As Windows.Forms.Timer
End Class
