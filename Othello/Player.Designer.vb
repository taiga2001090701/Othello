<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Player
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Player))
        Me.L3 = New System.Windows.Forms.Label()
        Me.L4 = New System.Windows.Forms.Label()
        Me.L2 = New System.Windows.Forms.Label()
        Me.L1 = New System.Windows.Forms.Label()
        Me.P4 = New System.Windows.Forms.Label()
        Me.P3 = New System.Windows.Forms.Label()
        Me.P2 = New System.Windows.Forms.Label()
        Me.P1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'L3
        '
        Me.L3.AutoSize = True
        Me.L3.Font = New System.Drawing.Font("MS UI Gothic", 32.0!)
        Me.L3.Location = New System.Drawing.Point(80, 127)
        Me.L3.Margin = New System.Windows.Forms.Padding(3, 3, 10, 10)
        Me.L3.Name = "L3"
        Me.L3.Size = New System.Drawing.Size(132, 43)
        Me.L3.TabIndex = 11
        Me.L3.Text = "Player"
        '
        'L4
        '
        Me.L4.AutoSize = True
        Me.L4.Font = New System.Drawing.Font("MS UI Gothic", 32.0!)
        Me.L4.Location = New System.Drawing.Point(80, 183)
        Me.L4.Margin = New System.Windows.Forms.Padding(3, 3, 10, 10)
        Me.L4.Name = "L4"
        Me.L4.Size = New System.Drawing.Size(132, 43)
        Me.L4.TabIndex = 10
        Me.L4.Text = "Player"
        '
        'L2
        '
        Me.L2.AutoSize = True
        Me.L2.Font = New System.Drawing.Font("MS UI Gothic", 32.0!)
        Me.L2.Location = New System.Drawing.Point(80, 71)
        Me.L2.Margin = New System.Windows.Forms.Padding(3, 3, 10, 10)
        Me.L2.Name = "L2"
        Me.L2.Size = New System.Drawing.Size(132, 43)
        Me.L2.TabIndex = 9
        Me.L2.Text = "Player"
        '
        'L1
        '
        Me.L1.AutoSize = True
        Me.L1.Font = New System.Drawing.Font("MS UI Gothic", 32.0!)
        Me.L1.Location = New System.Drawing.Point(80, 12)
        Me.L1.Margin = New System.Windows.Forms.Padding(3, 3, 10, 10)
        Me.L1.Name = "L1"
        Me.L1.Size = New System.Drawing.Size(132, 43)
        Me.L1.TabIndex = 8
        Me.L1.Text = "Player"
        '
        'P4
        '
        Me.P4.AutoSize = True
        Me.P4.Font = New System.Drawing.Font("MS UI Gothic", 32.0!)
        Me.P4.Location = New System.Drawing.Point(12, 183)
        Me.P4.Margin = New System.Windows.Forms.Padding(3, 3, 3, 10)
        Me.P4.Name = "P4"
        Me.P4.Size = New System.Drawing.Size(62, 43)
        Me.P4.TabIndex = 15
        Me.P4.Text = "⇒"
        '
        'P3
        '
        Me.P3.AutoSize = True
        Me.P3.Font = New System.Drawing.Font("MS UI Gothic", 32.0!)
        Me.P3.Location = New System.Drawing.Point(12, 127)
        Me.P3.Margin = New System.Windows.Forms.Padding(3, 3, 3, 10)
        Me.P3.Name = "P3"
        Me.P3.Size = New System.Drawing.Size(62, 43)
        Me.P3.TabIndex = 14
        Me.P3.Text = "⇒"
        '
        'P2
        '
        Me.P2.AutoSize = True
        Me.P2.Font = New System.Drawing.Font("MS UI Gothic", 32.0!)
        Me.P2.Location = New System.Drawing.Point(12, 71)
        Me.P2.Margin = New System.Windows.Forms.Padding(3, 3, 3, 10)
        Me.P2.Name = "P2"
        Me.P2.Size = New System.Drawing.Size(62, 43)
        Me.P2.TabIndex = 13
        Me.P2.Text = "⇒"
        '
        'P1
        '
        Me.P1.AutoSize = True
        Me.P1.Font = New System.Drawing.Font("MS UI Gothic", 32.0!)
        Me.P1.Location = New System.Drawing.Point(12, 12)
        Me.P1.Margin = New System.Windows.Forms.Padding(3, 3, 3, 10)
        Me.P1.Name = "P1"
        Me.P1.Size = New System.Drawing.Size(62, 43)
        Me.P1.TabIndex = 12
        Me.P1.Text = "⇒"
        '
        'Player
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.Green
        Me.ClientSize = New System.Drawing.Size(224, 236)
        Me.Controls.Add(Me.P4)
        Me.Controls.Add(Me.P3)
        Me.Controls.Add(Me.P2)
        Me.Controls.Add(Me.P1)
        Me.Controls.Add(Me.L3)
        Me.Controls.Add(Me.L4)
        Me.Controls.Add(Me.L2)
        Me.Controls.Add(Me.L1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Player"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Player List"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents L3 As Windows.Forms.Label
    Friend WithEvents L4 As Windows.Forms.Label
    Friend WithEvents L2 As Windows.Forms.Label
    Friend WithEvents L1 As Windows.Forms.Label
    Friend WithEvents P4 As Windows.Forms.Label
    Friend WithEvents P3 As Windows.Forms.Label
    Friend WithEvents P2 As Windows.Forms.Label
    Friend WithEvents P1 As Windows.Forms.Label
End Class
