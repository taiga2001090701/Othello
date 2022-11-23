<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.B2 = New System.Windows.Forms.Button()
        Me.B4 = New System.Windows.Forms.Button()
        Me.BAS = New System.Windows.Forms.Button()
        Me.B2N = New System.Windows.Forms.Button()
        Me.B4N = New System.Windows.Forms.Button()
        Me.B4NC = New System.Windows.Forms.Button()
        Me.B2NC = New System.Windows.Forms.Button()
        Me.G1 = New System.Windows.Forms.GroupBox()
        Me.G2 = New System.Windows.Forms.GroupBox()
        Me.BAE = New System.Windows.Forms.Button()
        Me.BAL = New System.Windows.Forms.Button()
        Me.BAF = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BH4 = New System.Windows.Forms.Button()
        Me.BH2 = New System.Windows.Forms.Button()
        Me.G1.SuspendLayout()
        Me.G2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'B2
        '
        Me.B2.BackColor = System.Drawing.Color.Red
        Me.B2.Font = New System.Drawing.Font("MS UI Gothic", 20.0!)
        Me.B2.Location = New System.Drawing.Point(6, 26)
        Me.B2.Name = "B2"
        Me.B2.Size = New System.Drawing.Size(706, 40)
        Me.B2.TabIndex = 0
        Me.B2.Text = "2 Players"
        Me.B2.UseVisualStyleBackColor = False
        '
        'B4
        '
        Me.B4.BackColor = System.Drawing.Color.Orange
        Me.B4.Font = New System.Drawing.Font("MS UI Gothic", 20.0!)
        Me.B4.Location = New System.Drawing.Point(6, 118)
        Me.B4.Name = "B4"
        Me.B4.Size = New System.Drawing.Size(706, 40)
        Me.B4.TabIndex = 3
        Me.B4.Text = "4 Players"
        Me.B4.UseVisualStyleBackColor = False
        '
        'BAS
        '
        Me.BAS.BackColor = System.Drawing.Color.Magenta
        Me.BAS.Font = New System.Drawing.Font("MS UI Gothic", 20.0!)
        Me.BAS.Location = New System.Drawing.Point(6, 26)
        Me.BAS.Name = "BAS"
        Me.BAS.Size = New System.Drawing.Size(706, 40)
        Me.BAS.TabIndex = 6
        Me.BAS.Text = "AI Auto Study"
        Me.BAS.UseVisualStyleBackColor = False
        '
        'B2N
        '
        Me.B2N.BackColor = System.Drawing.Color.SkyBlue
        Me.B2N.Font = New System.Drawing.Font("MS UI Gothic", 20.0!)
        Me.B2N.Location = New System.Drawing.Point(6, 72)
        Me.B2N.Name = "B2N"
        Me.B2N.Size = New System.Drawing.Size(350, 40)
        Me.B2N.TabIndex = 1
        Me.B2N.Text = "2 Players / Online"
        Me.B2N.UseVisualStyleBackColor = False
        '
        'B4N
        '
        Me.B4N.BackColor = System.Drawing.Color.LawnGreen
        Me.B4N.Font = New System.Drawing.Font("MS UI Gothic", 20.0!)
        Me.B4N.Location = New System.Drawing.Point(6, 164)
        Me.B4N.Name = "B4N"
        Me.B4N.Size = New System.Drawing.Size(350, 40)
        Me.B4N.TabIndex = 4
        Me.B4N.Text = "4 Players / Online"
        Me.B4N.UseVisualStyleBackColor = False
        '
        'B4NC
        '
        Me.B4NC.BackColor = System.Drawing.Color.LawnGreen
        Me.B4NC.Font = New System.Drawing.Font("MS UI Gothic", 20.0!)
        Me.B4NC.Location = New System.Drawing.Point(362, 164)
        Me.B4NC.Name = "B4NC"
        Me.B4NC.Size = New System.Drawing.Size(350, 40)
        Me.B4NC.TabIndex = 5
        Me.B4NC.Text = "4 Players / Online / Chat"
        Me.B4NC.UseVisualStyleBackColor = False
        '
        'B2NC
        '
        Me.B2NC.BackColor = System.Drawing.Color.SkyBlue
        Me.B2NC.Font = New System.Drawing.Font("MS UI Gothic", 20.0!)
        Me.B2NC.Location = New System.Drawing.Point(362, 72)
        Me.B2NC.Name = "B2NC"
        Me.B2NC.Size = New System.Drawing.Size(350, 40)
        Me.B2NC.TabIndex = 2
        Me.B2NC.Text = "2 Players / Online / Chat"
        Me.B2NC.UseVisualStyleBackColor = False
        '
        'G1
        '
        Me.G1.AutoSize = True
        Me.G1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.G1.Controls.Add(Me.B2)
        Me.G1.Controls.Add(Me.B4NC)
        Me.G1.Controls.Add(Me.B2N)
        Me.G1.Controls.Add(Me.B4N)
        Me.G1.Controls.Add(Me.B2NC)
        Me.G1.Controls.Add(Me.B4)
        Me.G1.Font = New System.Drawing.Font("MS UI Gothic", 15.0!, System.Drawing.FontStyle.Bold)
        Me.G1.Location = New System.Drawing.Point(12, 12)
        Me.G1.Name = "G1"
        Me.G1.Size = New System.Drawing.Size(718, 230)
        Me.G1.TabIndex = 7
        Me.G1.TabStop = False
        Me.G1.Text = "Normal Mode"
        '
        'G2
        '
        Me.G2.AutoSize = True
        Me.G2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.G2.Controls.Add(Me.BAE)
        Me.G2.Controls.Add(Me.BAL)
        Me.G2.Controls.Add(Me.BAF)
        Me.G2.Controls.Add(Me.BAS)
        Me.G2.Font = New System.Drawing.Font("MS UI Gothic", 15.0!, System.Drawing.FontStyle.Bold)
        Me.G2.Location = New System.Drawing.Point(12, 248)
        Me.G2.Margin = New System.Windows.Forms.Padding(3, 3, 10, 10)
        Me.G2.Name = "G2"
        Me.G2.Size = New System.Drawing.Size(718, 184)
        Me.G2.TabIndex = 8
        Me.G2.TabStop = False
        Me.G2.Text = "AI Mode"
        '
        'BAE
        '
        Me.BAE.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BAE.Font = New System.Drawing.Font("MS UI Gothic", 20.0!)
        Me.BAE.Location = New System.Drawing.Point(6, 118)
        Me.BAE.Name = "BAE"
        Me.BAE.Size = New System.Drawing.Size(706, 40)
        Me.BAE.TabIndex = 9
        Me.BAE.Text = "AI Setting"
        Me.BAE.UseVisualStyleBackColor = False
        '
        'BAL
        '
        Me.BAL.BackColor = System.Drawing.Color.Yellow
        Me.BAL.Font = New System.Drawing.Font("MS UI Gothic", 20.0!)
        Me.BAL.Location = New System.Drawing.Point(362, 72)
        Me.BAL.Name = "BAL"
        Me.BAL.Size = New System.Drawing.Size(350, 40)
        Me.BAL.TabIndex = 8
        Me.BAL.Text = "You vs White AI"
        Me.BAL.UseVisualStyleBackColor = False
        '
        'BAF
        '
        Me.BAF.BackColor = System.Drawing.Color.Yellow
        Me.BAF.Font = New System.Drawing.Font("MS UI Gothic", 20.0!)
        Me.BAF.Location = New System.Drawing.Point(6, 72)
        Me.BAF.Name = "BAF"
        Me.BAF.Size = New System.Drawing.Size(350, 40)
        Me.BAF.TabIndex = 7
        Me.BAF.Text = "Black AI vs You"
        Me.BAF.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.AutoSize = True
        Me.GroupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GroupBox1.Controls.Add(Me.BH4)
        Me.GroupBox1.Controls.Add(Me.BH2)
        Me.GroupBox1.Font = New System.Drawing.Font("MS UI Gothic", 15.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 445)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 3, 10, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(718, 138)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "History Mode"
        '
        'BH4
        '
        Me.BH4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BH4.Font = New System.Drawing.Font("MS UI Gothic", 20.0!)
        Me.BH4.Location = New System.Drawing.Point(6, 72)
        Me.BH4.Name = "BH4"
        Me.BH4.Size = New System.Drawing.Size(706, 40)
        Me.BH4.TabIndex = 8
        Me.BH4.Text = "4 Players"
        Me.BH4.UseVisualStyleBackColor = False
        '
        'BH2
        '
        Me.BH2.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BH2.Font = New System.Drawing.Font("MS UI Gothic", 20.0!)
        Me.BH2.Location = New System.Drawing.Point(6, 26)
        Me.BH2.Name = "BH2"
        Me.BH2.Size = New System.Drawing.Size(706, 40)
        Me.BH2.TabIndex = 7
        Me.BH2.Text = "2 Players"
        Me.BH2.UseVisualStyleBackColor = False
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(741, 582)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.G2)
        Me.Controls.Add(Me.G1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Main Menu"
        Me.G1.ResumeLayout(False)
        Me.G2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents B2 As Windows.Forms.Button
    Friend WithEvents B4 As Windows.Forms.Button
    Friend WithEvents BAS As Windows.Forms.Button
    Friend WithEvents B2N As Windows.Forms.Button
    Friend WithEvents B4N As Windows.Forms.Button
    Friend WithEvents B4NC As Windows.Forms.Button
    Friend WithEvents B2NC As Windows.Forms.Button
    Friend WithEvents G1 As Windows.Forms.GroupBox
    Friend WithEvents G2 As Windows.Forms.GroupBox
    Friend WithEvents BAL As Windows.Forms.Button
    Friend WithEvents BAF As Windows.Forms.Button
    Friend WithEvents BAE As Windows.Forms.Button
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents BH4 As Windows.Forms.Button
    Friend WithEvents BH2 As Windows.Forms.Button
End Class
