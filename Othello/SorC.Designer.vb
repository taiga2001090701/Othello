<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SorC
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SorC))
        Me.BS = New System.Windows.Forms.Button()
        Me.RS = New System.Windows.Forms.RadioButton()
        Me.RC = New System.Windows.Forms.RadioButton()
        Me.GS = New System.Windows.Forms.GroupBox()
        Me.SP = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SH = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GC1 = New System.Windows.Forms.GroupBox()
        Me.CP1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CH1 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GC2 = New System.Windows.Forms.GroupBox()
        Me.CP2 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CH2 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GC3 = New System.Windows.Forms.GroupBox()
        Me.CP3 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CH3 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GS.SuspendLayout()
        Me.GC1.SuspendLayout()
        Me.GC2.SuspendLayout()
        Me.GC3.SuspendLayout()
        Me.SuspendLayout()
        '
        'BS
        '
        Me.BS.BackColor = System.Drawing.Color.Lime
        Me.BS.Font = New System.Drawing.Font("MS UI Gothic", 16.0!)
        Me.BS.Location = New System.Drawing.Point(197, 6)
        Me.BS.Name = "BS"
        Me.BS.Size = New System.Drawing.Size(143, 40)
        Me.BS.TabIndex = 0
        Me.BS.Text = "Game Start"
        Me.BS.UseVisualStyleBackColor = False
        '
        'RS
        '
        Me.RS.AutoSize = True
        Me.RS.Checked = True
        Me.RS.Font = New System.Drawing.Font("MS UI Gothic", 16.0!)
        Me.RS.Location = New System.Drawing.Point(13, 13)
        Me.RS.Name = "RS"
        Me.RS.Size = New System.Drawing.Size(89, 26)
        Me.RS.TabIndex = 1
        Me.RS.TabStop = True
        Me.RS.Text = "Server"
        Me.RS.UseVisualStyleBackColor = True
        '
        'RC
        '
        Me.RC.AutoSize = True
        Me.RC.Font = New System.Drawing.Font("MS UI Gothic", 16.0!)
        Me.RC.Location = New System.Drawing.Point(108, 13)
        Me.RC.Name = "RC"
        Me.RC.Size = New System.Drawing.Size(83, 26)
        Me.RC.TabIndex = 2
        Me.RC.Text = "Client"
        Me.RC.UseVisualStyleBackColor = True
        '
        'GS
        '
        Me.GS.AutoSize = True
        Me.GS.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GS.Controls.Add(Me.SP)
        Me.GS.Controls.Add(Me.Label2)
        Me.GS.Controls.Add(Me.SH)
        Me.GS.Controls.Add(Me.Label1)
        Me.GS.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.GS.Location = New System.Drawing.Point(13, 53)
        Me.GS.Margin = New System.Windows.Forms.Padding(3, 3, 10, 10)
        Me.GS.Name = "GS"
        Me.GS.Size = New System.Drawing.Size(157, 96)
        Me.GS.TabIndex = 3
        Me.GS.TabStop = False
        Me.GS.Text = "Server"
        '
        'SP
        '
        Me.SP.Location = New System.Drawing.Point(51, 51)
        Me.SP.Name = "SP"
        Me.SP.Size = New System.Drawing.Size(100, 23)
        Me.SP.TabIndex = 3
        Me.SP.Text = "50001"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Port"
        '
        'SH
        '
        Me.SH.Location = New System.Drawing.Point(51, 22)
        Me.SH.Name = "SH"
        Me.SH.Size = New System.Drawing.Size(100, 23)
        Me.SH.TabIndex = 1
        Me.SH.Text = "localhost"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Host"
        '
        'GC1
        '
        Me.GC1.AutoSize = True
        Me.GC1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GC1.Controls.Add(Me.CP1)
        Me.GC1.Controls.Add(Me.Label3)
        Me.GC1.Controls.Add(Me.CH1)
        Me.GC1.Controls.Add(Me.Label4)
        Me.GC1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.GC1.Location = New System.Drawing.Point(183, 53)
        Me.GC1.Margin = New System.Windows.Forms.Padding(3, 3, 10, 10)
        Me.GC1.Name = "GC1"
        Me.GC1.Size = New System.Drawing.Size(157, 96)
        Me.GC1.TabIndex = 4
        Me.GC1.TabStop = False
        Me.GC1.Text = "Client 1"
        '
        'CP1
        '
        Me.CP1.Location = New System.Drawing.Point(51, 51)
        Me.CP1.Name = "CP1"
        Me.CP1.Size = New System.Drawing.Size(100, 23)
        Me.CP1.TabIndex = 3
        Me.CP1.Text = "50002"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Port"
        '
        'CH1
        '
        Me.CH1.Location = New System.Drawing.Point(51, 22)
        Me.CH1.Name = "CH1"
        Me.CH1.Size = New System.Drawing.Size(100, 23)
        Me.CH1.TabIndex = 1
        Me.CH1.Text = "localhost"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 16)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Host"
        '
        'GC2
        '
        Me.GC2.AutoSize = True
        Me.GC2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GC2.Controls.Add(Me.CP2)
        Me.GC2.Controls.Add(Me.Label5)
        Me.GC2.Controls.Add(Me.CH2)
        Me.GC2.Controls.Add(Me.Label6)
        Me.GC2.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.GC2.Location = New System.Drawing.Point(353, 53)
        Me.GC2.Margin = New System.Windows.Forms.Padding(3, 3, 10, 10)
        Me.GC2.Name = "GC2"
        Me.GC2.Size = New System.Drawing.Size(157, 96)
        Me.GC2.TabIndex = 5
        Me.GC2.TabStop = False
        Me.GC2.Text = "Client 2"
        '
        'CP2
        '
        Me.CP2.Location = New System.Drawing.Point(51, 51)
        Me.CP2.Name = "CP2"
        Me.CP2.Size = New System.Drawing.Size(100, 23)
        Me.CP2.TabIndex = 3
        Me.CP2.Text = "50003"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 54)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 16)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Port"
        '
        'CH2
        '
        Me.CH2.Location = New System.Drawing.Point(51, 22)
        Me.CH2.Name = "CH2"
        Me.CH2.Size = New System.Drawing.Size(100, 23)
        Me.CH2.TabIndex = 1
        Me.CH2.Text = "localhost"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 16)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Host"
        '
        'GC3
        '
        Me.GC3.AutoSize = True
        Me.GC3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GC3.Controls.Add(Me.CP3)
        Me.GC3.Controls.Add(Me.Label7)
        Me.GC3.Controls.Add(Me.CH3)
        Me.GC3.Controls.Add(Me.Label8)
        Me.GC3.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.GC3.Location = New System.Drawing.Point(523, 53)
        Me.GC3.Margin = New System.Windows.Forms.Padding(3, 3, 10, 10)
        Me.GC3.Name = "GC3"
        Me.GC3.Size = New System.Drawing.Size(157, 96)
        Me.GC3.TabIndex = 6
        Me.GC3.TabStop = False
        Me.GC3.Text = "Client 3"
        '
        'CP3
        '
        Me.CP3.Location = New System.Drawing.Point(51, 51)
        Me.CP3.Name = "CP3"
        Me.CP3.Size = New System.Drawing.Size(100, 23)
        Me.CP3.TabIndex = 3
        Me.CP3.Text = "50004"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 54)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 16)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Port"
        '
        'CH3
        '
        Me.CH3.Location = New System.Drawing.Point(51, 22)
        Me.CH3.Name = "CH3"
        Me.CH3.Size = New System.Drawing.Size(100, 23)
        Me.CH3.TabIndex = 1
        Me.CH3.Text = "localhost"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 25)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 16)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Host"
        '
        'SorC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(688, 166)
        Me.Controls.Add(Me.GC3)
        Me.Controls.Add(Me.GC2)
        Me.Controls.Add(Me.GC1)
        Me.Controls.Add(Me.GS)
        Me.Controls.Add(Me.RC)
        Me.Controls.Add(Me.RS)
        Me.Controls.Add(Me.BS)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "SorC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Server / Client Setteing"
        Me.GS.ResumeLayout(False)
        Me.GS.PerformLayout()
        Me.GC1.ResumeLayout(False)
        Me.GC1.PerformLayout()
        Me.GC2.ResumeLayout(False)
        Me.GC2.PerformLayout()
        Me.GC3.ResumeLayout(False)
        Me.GC3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BS As Windows.Forms.Button
    Friend WithEvents RS As Windows.Forms.RadioButton
    Friend WithEvents RC As Windows.Forms.RadioButton
    Friend WithEvents GS As Windows.Forms.GroupBox
    Friend WithEvents SP As Windows.Forms.TextBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents SH As Windows.Forms.TextBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents GC1 As Windows.Forms.GroupBox
    Friend WithEvents CP1 As Windows.Forms.TextBox
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents CH1 As Windows.Forms.TextBox
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents GC2 As Windows.Forms.GroupBox
    Friend WithEvents CP2 As Windows.Forms.TextBox
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents CH2 As Windows.Forms.TextBox
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents GC3 As Windows.Forms.GroupBox
    Friend WithEvents CP3 As Windows.Forms.TextBox
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents CH3 As Windows.Forms.TextBox
    Friend WithEvents Label8 As Windows.Forms.Label
End Class
