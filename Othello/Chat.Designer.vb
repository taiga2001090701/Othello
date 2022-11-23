<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Chat
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Chat))
        Me.SA = New System.Windows.Forms.Button()
        Me.N1 = New System.Windows.Forms.TextBox()
        Me.S1 = New System.Windows.Forms.Button()
        Me.N2 = New System.Windows.Forms.TextBox()
        Me.S2 = New System.Windows.Forms.Button()
        Me.N3 = New System.Windows.Forms.TextBox()
        Me.S3 = New System.Windows.Forms.Button()
        Me.N4 = New System.Windows.Forms.TextBox()
        Me.S4 = New System.Windows.Forms.Button()
        Me.TS = New System.Windows.Forms.TextBox()
        Me.TL = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'SA
        '
        Me.SA.BackColor = System.Drawing.Color.White
        Me.SA.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.SA.Location = New System.Drawing.Point(588, 12)
        Me.SA.Name = "SA"
        Me.SA.Size = New System.Drawing.Size(75, 64)
        Me.SA.TabIndex = 0
        Me.SA.Text = "Send to All"
        Me.SA.UseVisualStyleBackColor = False
        '
        'N1
        '
        Me.N1.BackColor = System.Drawing.Color.Green
        Me.N1.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.N1.ForeColor = System.Drawing.Color.Red
        Me.N1.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.N1.Location = New System.Drawing.Point(13, 17)
        Me.N1.MaxLength = 15
        Me.N1.Name = "N1"
        Me.N1.Size = New System.Drawing.Size(200, 21)
        Me.N1.TabIndex = 1
        Me.N1.Text = "Player Red"
        '
        'S1
        '
        Me.S1.BackColor = System.Drawing.Color.Red
        Me.S1.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.S1.Location = New System.Drawing.Point(219, 12)
        Me.S1.Name = "S1"
        Me.S1.Size = New System.Drawing.Size(75, 29)
        Me.S1.TabIndex = 2
        Me.S1.Text = "Send"
        Me.S1.UseVisualStyleBackColor = False
        '
        'N2
        '
        Me.N2.BackColor = System.Drawing.Color.Green
        Me.N2.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.N2.ForeColor = System.Drawing.Color.SkyBlue
        Me.N2.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.N2.Location = New System.Drawing.Point(13, 52)
        Me.N2.MaxLength = 15
        Me.N2.Name = "N2"
        Me.N2.Size = New System.Drawing.Size(200, 21)
        Me.N2.TabIndex = 3
        Me.N2.Text = "Player Blue"
        '
        'S2
        '
        Me.S2.BackColor = System.Drawing.Color.SkyBlue
        Me.S2.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.S2.Location = New System.Drawing.Point(219, 47)
        Me.S2.Name = "S2"
        Me.S2.Size = New System.Drawing.Size(75, 29)
        Me.S2.TabIndex = 4
        Me.S2.Text = "Send"
        Me.S2.UseVisualStyleBackColor = False
        '
        'N3
        '
        Me.N3.BackColor = System.Drawing.Color.Green
        Me.N3.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.N3.ForeColor = System.Drawing.Color.Orange
        Me.N3.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.N3.Location = New System.Drawing.Point(300, 17)
        Me.N3.MaxLength = 15
        Me.N3.Name = "N3"
        Me.N3.Size = New System.Drawing.Size(200, 21)
        Me.N3.TabIndex = 5
        Me.N3.Text = "Player Yellow"
        '
        'S3
        '
        Me.S3.BackColor = System.Drawing.Color.Orange
        Me.S3.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.S3.Location = New System.Drawing.Point(507, 12)
        Me.S3.Name = "S3"
        Me.S3.Size = New System.Drawing.Size(75, 29)
        Me.S3.TabIndex = 6
        Me.S3.Text = "Send"
        Me.S3.UseVisualStyleBackColor = False
        '
        'N4
        '
        Me.N4.BackColor = System.Drawing.Color.Green
        Me.N4.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.N4.ForeColor = System.Drawing.Color.LawnGreen
        Me.N4.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.N4.Location = New System.Drawing.Point(300, 52)
        Me.N4.MaxLength = 15
        Me.N4.Name = "N4"
        Me.N4.Size = New System.Drawing.Size(200, 21)
        Me.N4.TabIndex = 7
        Me.N4.Text = "Player Green"
        '
        'S4
        '
        Me.S4.BackColor = System.Drawing.Color.LawnGreen
        Me.S4.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.S4.Location = New System.Drawing.Point(506, 47)
        Me.S4.Name = "S4"
        Me.S4.Size = New System.Drawing.Size(75, 29)
        Me.S4.TabIndex = 8
        Me.S4.Text = "Send"
        Me.S4.UseVisualStyleBackColor = False
        '
        'TS
        '
        Me.TS.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.TS.Location = New System.Drawing.Point(13, 84)
        Me.TS.Name = "TS"
        Me.TS.Size = New System.Drawing.Size(650, 23)
        Me.TS.TabIndex = 9
        '
        'TL
        '
        Me.TL.BackColor = System.Drawing.Color.White
        Me.TL.Font = New System.Drawing.Font("ＭＳ ゴシック", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TL.Location = New System.Drawing.Point(13, 113)
        Me.TL.Margin = New System.Windows.Forms.Padding(3, 3, 10, 10)
        Me.TL.Name = "TL"
        Me.TL.ReadOnly = True
        Me.TL.Size = New System.Drawing.Size(650, 300)
        Me.TL.TabIndex = 10
        Me.TL.Text = ""
        Me.TL.WordWrap = False
        '
        'Chat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.Green
        Me.ClientSize = New System.Drawing.Size(675, 422)
        Me.Controls.Add(Me.TL)
        Me.Controls.Add(Me.TS)
        Me.Controls.Add(Me.S4)
        Me.Controls.Add(Me.N4)
        Me.Controls.Add(Me.S3)
        Me.Controls.Add(Me.N3)
        Me.Controls.Add(Me.S2)
        Me.Controls.Add(Me.N2)
        Me.Controls.Add(Me.S1)
        Me.Controls.Add(Me.N1)
        Me.Controls.Add(Me.SA)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Chat"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Chat"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SA As Windows.Forms.Button
    Friend WithEvents N1 As Windows.Forms.TextBox
    Friend WithEvents S1 As Windows.Forms.Button
    Friend WithEvents N2 As Windows.Forms.TextBox
    Friend WithEvents S2 As Windows.Forms.Button
    Friend WithEvents N3 As Windows.Forms.TextBox
    Friend WithEvents S3 As Windows.Forms.Button
    Friend WithEvents N4 As Windows.Forms.TextBox
    Friend WithEvents S4 As Windows.Forms.Button
    Friend WithEvents TS As Windows.Forms.TextBox
    Friend WithEvents TL As Windows.Forms.RichTextBox
End Class
