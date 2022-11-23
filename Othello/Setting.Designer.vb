<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Setting
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Setting))
        Me.G1 = New System.Windows.Forms.GroupBox()
        Me.RB3 = New System.Windows.Forms.RadioButton()
        Me.RB2 = New System.Windows.Forms.RadioButton()
        Me.RB1 = New System.Windows.Forms.RadioButton()
        Me.G2 = New System.Windows.Forms.GroupBox()
        Me.RS2 = New System.Windows.Forms.RadioButton()
        Me.RS1 = New System.Windows.Forms.RadioButton()
        Me.G3 = New System.Windows.Forms.GroupBox()
        Me.BD = New System.Windows.Forms.Button()
        Me.BE = New System.Windows.Forms.Button()
        Me.BI = New System.Windows.Forms.Button()
        Me.BOK = New System.Windows.Forms.Button()
        Me.G4 = New System.Windows.Forms.GroupBox()
        Me.BCA = New System.Windows.Forms.Button()
        Me.G1.SuspendLayout()
        Me.G2.SuspendLayout()
        Me.G3.SuspendLayout()
        Me.G4.SuspendLayout()
        Me.SuspendLayout()
        '
        'G1
        '
        Me.G1.AutoSize = True
        Me.G1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.G1.Controls.Add(Me.RB3)
        Me.G1.Controls.Add(Me.RB2)
        Me.G1.Controls.Add(Me.RB1)
        Me.G1.Font = New System.Drawing.Font("MS UI Gothic", 20.0!, System.Drawing.FontStyle.Bold)
        Me.G1.ForeColor = System.Drawing.Color.Red
        Me.G1.Location = New System.Drawing.Point(12, 12)
        Me.G1.Margin = New System.Windows.Forms.Padding(3, 3, 10, 3)
        Me.G1.Name = "G1"
        Me.G1.Padding = New System.Windows.Forms.Padding(2)
        Me.G1.Size = New System.Drawing.Size(562, 160)
        Me.G1.TabIndex = 0
        Me.G1.TabStop = False
        Me.G1.Text = "Battle AI Algorithm"
        '
        'RB3
        '
        Me.RB3.AutoSize = True
        Me.RB3.Font = New System.Drawing.Font("MS UI Gothic", 18.0!)
        Me.RB3.Location = New System.Drawing.Point(12, 100)
        Me.RB3.Margin = New System.Windows.Forms.Padding(10, 3, 10, 3)
        Me.RB3.Name = "RB3"
        Me.RB3.Size = New System.Drawing.Size(538, 28)
        Me.RB3.TabIndex = 4
        Me.RB3.Text = "Algorithm Pattern 3 - No Data Reference Algorithm"
        Me.RB3.UseVisualStyleBackColor = True
        '
        'RB2
        '
        Me.RB2.AutoSize = True
        Me.RB2.Font = New System.Drawing.Font("MS UI Gothic", 18.0!)
        Me.RB2.Location = New System.Drawing.Point(12, 66)
        Me.RB2.Margin = New System.Windows.Forms.Padding(10, 3, 10, 3)
        Me.RB2.Name = "RB2"
        Me.RB2.Size = New System.Drawing.Size(501, 28)
        Me.RB2.TabIndex = 3
        Me.RB2.Text = "Algorithm Pattern 2 - Maximum Point Algorithm"
        Me.RB2.UseVisualStyleBackColor = True
        '
        'RB1
        '
        Me.RB1.AutoSize = True
        Me.RB1.Checked = True
        Me.RB1.Font = New System.Drawing.Font("MS UI Gothic", 18.0!)
        Me.RB1.Location = New System.Drawing.Point(12, 32)
        Me.RB1.Margin = New System.Windows.Forms.Padding(10, 3, 10, 3)
        Me.RB1.Name = "RB1"
        Me.RB1.Size = New System.Drawing.Size(418, 28)
        Me.RB1.TabIndex = 2
        Me.RB1.TabStop = True
        Me.RB1.Text = "Algorithm Pattern 1 - Noraml Algorithm"
        Me.RB1.UseVisualStyleBackColor = True
        '
        'G2
        '
        Me.G2.AutoSize = True
        Me.G2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.G2.Controls.Add(Me.RS2)
        Me.G2.Controls.Add(Me.RS1)
        Me.G2.Font = New System.Drawing.Font("MS UI Gothic", 20.0!, System.Drawing.FontStyle.Bold)
        Me.G2.ForeColor = System.Drawing.Color.SkyBlue
        Me.G2.Location = New System.Drawing.Point(12, 178)
        Me.G2.Margin = New System.Windows.Forms.Padding(3, 3, 10, 3)
        Me.G2.Name = "G2"
        Me.G2.Padding = New System.Windows.Forms.Padding(2)
        Me.G2.Size = New System.Drawing.Size(604, 126)
        Me.G2.TabIndex = 1
        Me.G2.TabStop = False
        Me.G2.Text = "Study AI Algorithm"
        '
        'RS2
        '
        Me.RS2.AutoSize = True
        Me.RS2.Font = New System.Drawing.Font("MS UI Gothic", 18.0!)
        Me.RS2.Location = New System.Drawing.Point(12, 66)
        Me.RS2.Margin = New System.Windows.Forms.Padding(10, 3, 10, 3)
        Me.RS2.Name = "RS2"
        Me.RS2.Size = New System.Drawing.Size(580, 28)
        Me.RS2.TabIndex = 5
        Me.RS2.Text = "Algorithm Pattern 2 - Victory Aggressiveness Alrogithm"
        Me.RS2.UseVisualStyleBackColor = True
        '
        'RS1
        '
        Me.RS1.AutoSize = True
        Me.RS1.Checked = True
        Me.RS1.Font = New System.Drawing.Font("MS UI Gothic", 18.0!)
        Me.RS1.Location = New System.Drawing.Point(12, 32)
        Me.RS1.Margin = New System.Windows.Forms.Padding(10, 3, 10, 3)
        Me.RS1.Name = "RS1"
        Me.RS1.Size = New System.Drawing.Size(418, 28)
        Me.RS1.TabIndex = 4
        Me.RS1.TabStop = True
        Me.RS1.Text = "Algorithm Pattern 1 - Normal Algorithm"
        Me.RS1.UseVisualStyleBackColor = True
        '
        'G3
        '
        Me.G3.AutoSize = True
        Me.G3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.G3.Controls.Add(Me.BD)
        Me.G3.Controls.Add(Me.BE)
        Me.G3.Controls.Add(Me.BI)
        Me.G3.Font = New System.Drawing.Font("MS UI Gothic", 20.0!, System.Drawing.FontStyle.Bold)
        Me.G3.ForeColor = System.Drawing.Color.Orange
        Me.G3.Location = New System.Drawing.Point(12, 310)
        Me.G3.Name = "G3"
        Me.G3.Padding = New System.Windows.Forms.Padding(2)
        Me.G3.Size = New System.Drawing.Size(364, 104)
        Me.G3.TabIndex = 2
        Me.G3.TabStop = False
        Me.G3.Text = "Study Data"
        '
        'BD
        '
        Me.BD.Font = New System.Drawing.Font("MS UI Gothic", 18.0!)
        Me.BD.Location = New System.Drawing.Point(252, 32)
        Me.BD.Margin = New System.Windows.Forms.Padding(10, 3, 10, 3)
        Me.BD.Name = "BD"
        Me.BD.Size = New System.Drawing.Size(100, 40)
        Me.BD.TabIndex = 2
        Me.BD.Text = "Delete"
        Me.BD.UseVisualStyleBackColor = True
        '
        'BE
        '
        Me.BE.Font = New System.Drawing.Font("MS UI Gothic", 18.0!)
        Me.BE.Location = New System.Drawing.Point(132, 32)
        Me.BE.Margin = New System.Windows.Forms.Padding(10, 3, 10, 3)
        Me.BE.Name = "BE"
        Me.BE.Size = New System.Drawing.Size(100, 40)
        Me.BE.TabIndex = 1
        Me.BE.Text = "Export"
        Me.BE.UseVisualStyleBackColor = True
        '
        'BI
        '
        Me.BI.Font = New System.Drawing.Font("MS UI Gothic", 18.0!)
        Me.BI.Location = New System.Drawing.Point(12, 32)
        Me.BI.Margin = New System.Windows.Forms.Padding(10, 3, 10, 3)
        Me.BI.Name = "BI"
        Me.BI.Size = New System.Drawing.Size(100, 40)
        Me.BI.TabIndex = 0
        Me.BI.Text = "Import"
        Me.BI.UseVisualStyleBackColor = True
        '
        'BOK
        '
        Me.BOK.Font = New System.Drawing.Font("MS UI Gothic", 18.0!)
        Me.BOK.ForeColor = System.Drawing.Color.Lime
        Me.BOK.Location = New System.Drawing.Point(12, 32)
        Me.BOK.Margin = New System.Windows.Forms.Padding(10, 3, 10, 3)
        Me.BOK.Name = "BOK"
        Me.BOK.Size = New System.Drawing.Size(100, 40)
        Me.BOK.TabIndex = 3
        Me.BOK.Text = "OK"
        Me.BOK.UseVisualStyleBackColor = True
        '
        'G4
        '
        Me.G4.AutoSize = True
        Me.G4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.G4.Controls.Add(Me.BCA)
        Me.G4.Controls.Add(Me.BOK)
        Me.G4.Font = New System.Drawing.Font("MS UI Gothic", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.G4.ForeColor = System.Drawing.Color.Lime
        Me.G4.Location = New System.Drawing.Point(382, 310)
        Me.G4.Margin = New System.Windows.Forms.Padding(3, 3, 10, 10)
        Me.G4.Name = "G4"
        Me.G4.Padding = New System.Windows.Forms.Padding(2)
        Me.G4.Size = New System.Drawing.Size(244, 104)
        Me.G4.TabIndex = 4
        Me.G4.TabStop = False
        Me.G4.Text = "Control"
        '
        'BCA
        '
        Me.BCA.Font = New System.Drawing.Font("MS UI Gothic", 18.0!)
        Me.BCA.ForeColor = System.Drawing.Color.Lime
        Me.BCA.Location = New System.Drawing.Point(132, 32)
        Me.BCA.Margin = New System.Windows.Forms.Padding(10, 3, 10, 3)
        Me.BCA.Name = "BCA"
        Me.BCA.Size = New System.Drawing.Size(100, 40)
        Me.BCA.TabIndex = 4
        Me.BCA.Text = "Cancel"
        Me.BCA.UseVisualStyleBackColor = True
        '
        'Setting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(636, 437)
        Me.Controls.Add(Me.G4)
        Me.Controls.Add(Me.G3)
        Me.Controls.Add(Me.G2)
        Me.Controls.Add(Me.G1)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.Name = "Setting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Setting"
        Me.G1.ResumeLayout(False)
        Me.G1.PerformLayout()
        Me.G2.ResumeLayout(False)
        Me.G2.PerformLayout()
        Me.G3.ResumeLayout(False)
        Me.G4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents G1 As Windows.Forms.GroupBox
    Friend WithEvents G2 As Windows.Forms.GroupBox
    Friend WithEvents G3 As Windows.Forms.GroupBox
    Friend WithEvents BI As Windows.Forms.Button
    Friend WithEvents BD As Windows.Forms.Button
    Friend WithEvents BE As Windows.Forms.Button
    Friend WithEvents RB2 As Windows.Forms.RadioButton
    Friend WithEvents RB1 As Windows.Forms.RadioButton
    Friend WithEvents RS2 As Windows.Forms.RadioButton
    Friend WithEvents RS1 As Windows.Forms.RadioButton
    Friend WithEvents BOK As Windows.Forms.Button
    Friend WithEvents RB3 As Windows.Forms.RadioButton
    Friend WithEvents G4 As Windows.Forms.GroupBox
    Friend WithEvents BCA As Windows.Forms.Button
End Class
