<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Import
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Import))
        Me.LN = New System.Windows.Forms.Label()
        Me.PB = New System.Windows.Forms.ProgressBar()
        Me.TS = New System.Windows.Forms.Timer(Me.components)
        Me.LE = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'LN
        '
        Me.LN.AutoSize = True
        Me.LN.Font = New System.Drawing.Font("MS UI Gothic", 20.0!)
        Me.LN.ForeColor = System.Drawing.Color.Red
        Me.LN.Location = New System.Drawing.Point(12, 12)
        Me.LN.Margin = New System.Windows.Forms.Padding(3, 3, 10, 10)
        Me.LN.Name = "LN"
        Me.LN.Size = New System.Drawing.Size(339, 27)
        Me.LN.TabIndex = 0
        Me.LN.Text = "Now Importing AI Study Data"
        '
        'PB
        '
        Me.PB.Location = New System.Drawing.Point(12, 52)
        Me.PB.Margin = New System.Windows.Forms.Padding(3, 3, 10, 10)
        Me.PB.Name = "PB"
        Me.PB.Size = New System.Drawing.Size(334, 23)
        Me.PB.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.PB.TabIndex = 1
        '
        'TS
        '
        '
        'LE
        '
        Me.LE.AutoSize = True
        Me.LE.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.LE.Location = New System.Drawing.Point(12, 88)
        Me.LE.Margin = New System.Windows.Forms.Padding(3, 3, 10, 10)
        Me.LE.Name = "LE"
        Me.LE.Size = New System.Drawing.Size(112, 16)
        Me.LE.TabIndex = 2
        Me.LE.Text = "Estimated Time"
        '
        'Import
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(362, 121)
        Me.ControlBox = False
        Me.Controls.Add(Me.LE)
        Me.Controls.Add(Me.PB)
        Me.Controls.Add(Me.LN)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Import"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Import"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LN As Windows.Forms.Label
    Friend WithEvents PB As Windows.Forms.ProgressBar
    Friend WithEvents TS As Windows.Forms.Timer
    Friend WithEvents LE As Windows.Forms.Label
End Class
