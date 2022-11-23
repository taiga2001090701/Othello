<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Name
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Name))
        Me.BO = New System.Windows.Forms.Button()
        Me.LN = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'BO
        '
        Me.BO.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.BO.Location = New System.Drawing.Point(218, 12)
        Me.BO.Margin = New System.Windows.Forms.Padding(3, 3, 10, 10)
        Me.BO.Name = "BO"
        Me.BO.Size = New System.Drawing.Size(75, 30)
        Me.BO.TabIndex = 0
        Me.BO.Text = "OK"
        Me.BO.UseVisualStyleBackColor = True
        '
        'LN
        '
        Me.LN.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.LN.Location = New System.Drawing.Point(12, 16)
        Me.LN.Name = "LN"
        Me.LN.Size = New System.Drawing.Size(200, 23)
        Me.LN.TabIndex = 1
        '
        'Name
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(308, 55)
        Me.ControlBox = False
        Me.Controls.Add(Me.LN)
        Me.Controls.Add(Me.BO)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Name"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Name"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BO As Windows.Forms.Button
    Friend WithEvents LN As Windows.Forms.TextBox
End Class
