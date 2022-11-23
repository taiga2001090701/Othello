<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Result
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Result))
        Me.LR = New System.Windows.Forms.Label()
        Me.LD = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'LR
        '
        Me.LR.AutoSize = True
        Me.LR.Font = New System.Drawing.Font("MS UI Gothic", 32.0!)
        Me.LR.Location = New System.Drawing.Point(8, 40)
        Me.LR.Margin = New System.Windows.Forms.Padding(3, 3, 10, 10)
        Me.LR.Name = "LR"
        Me.LR.Size = New System.Drawing.Size(267, 43)
        Me.LR.TabIndex = 0
        Me.LR.Text = "Winner Player"
        '
        'LD
        '
        Me.LD.AutoSize = True
        Me.LD.Font = New System.Drawing.Font("MS UI Gothic", 16.0!)
        Me.LD.Location = New System.Drawing.Point(12, 12)
        Me.LD.Margin = New System.Windows.Forms.Padding(3, 3, 10, 3)
        Me.LD.Name = "LD"
        Me.LD.Size = New System.Drawing.Size(136, 22)
        Me.LD.TabIndex = 1
        Me.LD.Text = "Black - White"
        '
        'Result
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.BackColor = System.Drawing.Color.Green
        Me.ClientSize = New System.Drawing.Size(281, 96)
        Me.Controls.Add(Me.LD)
        Me.Controls.Add(Me.LR)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Result"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Result"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LR As Windows.Forms.Label
    Friend WithEvents LD As Windows.Forms.Label
End Class
