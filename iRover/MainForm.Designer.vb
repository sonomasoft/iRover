<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Led1 = New NationalInstruments.UI.WindowsForms.Led()
        Me.Led2 = New NationalInstruments.UI.WindowsForms.Led()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Led3 = New NationalInstruments.UI.WindowsForms.Led()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Led4 = New NationalInstruments.UI.WindowsForms.Led()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Led5 = New NationalInstruments.UI.WindowsForms.Led()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Led6 = New NationalInstruments.UI.WindowsForms.Led()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Led7 = New NationalInstruments.UI.WindowsForms.Led()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Led8 = New NationalInstruments.UI.WindowsForms.Led()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Led9 = New NationalInstruments.UI.WindowsForms.Led()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Led10 = New NationalInstruments.UI.WindowsForms.Led()
        CType(Me.Led1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Led2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Led3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Led4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Led5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Led6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Led7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Led8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Led9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Led10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("AvantGardeGothicETT", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(22, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(206, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "3.1.1.1a High Voltage TP11"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("AvantGardeGothicETT", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(22, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 19)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Test"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("AvantGardeGothicETT", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(322, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 19)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Reading"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("AvantGardeGothicETT", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(322, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 19)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "0 V"
        '
        'Led1
        '
        Me.Led1.LedStyle = NationalInstruments.UI.LedStyle.Round3D
        Me.Led1.Location = New System.Drawing.Point(541, 60)
        Me.Led1.Name = "Led1"
        Me.Led1.OffColor = System.Drawing.Color.Black
        Me.Led1.Size = New System.Drawing.Size(31, 27)
        Me.Led1.TabIndex = 4
        '
        'Led2
        '
        Me.Led2.LedStyle = NationalInstruments.UI.LedStyle.Round3D
        Me.Led2.Location = New System.Drawing.Point(541, 96)
        Me.Led2.Name = "Led2"
        Me.Led2.OffColor = System.Drawing.Color.Black
        Me.Led2.Size = New System.Drawing.Size(31, 27)
        Me.Led2.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("AvantGardeGothicETT", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(322, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 19)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "0 V"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("AvantGardeGothicETT", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(22, 96)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(188, 19)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "3.1.1.1b Anode Voltage"
        '
        'Led3
        '
        Me.Led3.LedStyle = NationalInstruments.UI.LedStyle.Round3D
        Me.Led3.Location = New System.Drawing.Point(541, 129)
        Me.Led3.Name = "Led3"
        Me.Led3.OffColor = System.Drawing.Color.Black
        Me.Led3.Size = New System.Drawing.Size(31, 27)
        Me.Led3.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("AvantGardeGothicETT", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(322, 129)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 19)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "0 mA"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("AvantGardeGothicETT", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(22, 129)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(182, 19)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "3.1.1.1c Supply Current"
        '
        'Led4
        '
        Me.Led4.LedStyle = NationalInstruments.UI.LedStyle.Round3D
        Me.Led4.Location = New System.Drawing.Point(541, 161)
        Me.Led4.Name = "Led4"
        Me.Led4.OffColor = System.Drawing.Color.Black
        Me.Led4.Size = New System.Drawing.Size(31, 27)
        Me.Led4.TabIndex = 14
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("AvantGardeGothicETT", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(322, 161)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 19)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "0 uS"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("AvantGardeGothicETT", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(22, 161)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(249, 19)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "3.1.1.1d Negitive Pulse Width TP4"
        '
        'Led5
        '
        Me.Led5.LedStyle = NationalInstruments.UI.LedStyle.Round3D
        Me.Led5.Location = New System.Drawing.Point(541, 192)
        Me.Led5.Name = "Led5"
        Me.Led5.OffColor = System.Drawing.Color.Black
        Me.Led5.Size = New System.Drawing.Size(31, 27)
        Me.Led5.TabIndex = 17
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("AvantGardeGothicETT", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(322, 192)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(32, 19)
        Me.Label11.TabIndex = 16
        Me.Label11.Text = "0 V"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("AvantGardeGothicETT", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(22, 192)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(187, 19)
        Me.Label12.TabIndex = 15
        Me.Label12.Text = "3.1.1.2 Load Regulation"
        '
        'Led6
        '
        Me.Led6.LedStyle = NationalInstruments.UI.LedStyle.Round3D
        Me.Led6.Location = New System.Drawing.Point(541, 225)
        Me.Led6.Name = "Led6"
        Me.Led6.OffColor = System.Drawing.Color.Black
        Me.Led6.Size = New System.Drawing.Size(31, 27)
        Me.Led6.TabIndex = 20
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("AvantGardeGothicETT", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(322, 221)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(42, 19)
        Me.Label13.TabIndex = 19
        Me.Label13.Text = "0 uA"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("AvantGardeGothicETT", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(22, 221)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(256, 19)
        Me.Label14.TabIndex = 18
        Me.Label14.Text = "3.1.1.3 Light Load Supply Current"
        '
        'Led7
        '
        Me.Led7.LedStyle = NationalInstruments.UI.LedStyle.Round3D
        Me.Led7.Location = New System.Drawing.Point(541, 251)
        Me.Led7.Name = "Led7"
        Me.Led7.OffColor = System.Drawing.Color.Black
        Me.Led7.Size = New System.Drawing.Size(31, 27)
        Me.Led7.TabIndex = 23
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("AvantGardeGothicETT", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(322, 251)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(43, 19)
        Me.Label15.TabIndex = 22
        Me.Label15.Text = "0 mS"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("AvantGardeGothicETT", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(22, 251)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(257, 19)
        Me.Label16.TabIndex = 21
        Me.Label16.Text = "3.1.2 Watchdog Timer Period TP5"
        '
        'Led8
        '
        Me.Led8.LedStyle = NationalInstruments.UI.LedStyle.Round3D
        Me.Led8.Location = New System.Drawing.Point(541, 276)
        Me.Led8.Name = "Led8"
        Me.Led8.OffColor = System.Drawing.Color.Black
        Me.Led8.Size = New System.Drawing.Size(31, 27)
        Me.Led8.TabIndex = 26
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("AvantGardeGothicETT", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(321, 284)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(38, 19)
        Me.Label17.TabIndex = 25
        Me.Label17.Text = "0 uS"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("AvantGardeGothicETT", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(21, 284)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(269, 19)
        Me.Label18.TabIndex = 24
        Me.Label18.Text = "3.1.3a Front End Comparator TP15"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("AvantGardeGothicETT", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(516, 28)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(81, 19)
        Me.Label19.TabIndex = 27
        Me.Label19.Text = "Pass/Fail"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(277, 398)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(127, 31)
        Me.Button1.TabIndex = 28
        Me.Button1.Text = "Begin Test Sequence"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(12, 446)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(649, 130)
        Me.TextBox1.TabIndex = 29
        '
        'Timer1
        '
        Me.Timer1.Interval = 2000
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("AvantGardeGothicETT", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label20.Location = New System.Drawing.Point(22, 318)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(169, 19)
        Me.Label20.TabIndex = 30
        Me.Label20.Text = "3.1.3b GM Pulsewidth"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("AvantGardeGothicETT", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(321, 318)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(38, 19)
        Me.Label21.TabIndex = 31
        Me.Label21.Text = "0 uS"
        '
        'Led9
        '
        Me.Led9.LedStyle = NationalInstruments.UI.LedStyle.Round3D
        Me.Led9.Location = New System.Drawing.Point(541, 310)
        Me.Led9.Name = "Led9"
        Me.Led9.OffColor = System.Drawing.Color.Black
        Me.Led9.Size = New System.Drawing.Size(31, 27)
        Me.Led9.TabIndex = 32
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("AvantGardeGothicETT", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(22, 348)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(201, 19)
        Me.Label22.TabIndex = 33
        Me.Label22.Text = "3.1.4 High Voltage 3.0V In"
        Me.Label22.Visible = False
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("AvantGardeGothicETT", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(322, 348)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(32, 19)
        Me.Label23.TabIndex = 34
        Me.Label23.Text = "0 V"
        Me.Label23.Visible = False
        '
        'Led10
        '
        Me.Led10.LedStyle = NationalInstruments.UI.LedStyle.Round3D
        Me.Led10.Location = New System.Drawing.Point(541, 340)
        Me.Led10.Name = "Led10"
        Me.Led10.OffColor = System.Drawing.Color.Black
        Me.Led10.Size = New System.Drawing.Size(31, 27)
        Me.Led10.TabIndex = 35
        Me.Led10.Visible = False
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(681, 588)
        Me.Controls.Add(Me.Led10)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Led9)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Led8)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Led7)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Led6)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Led5)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Led4)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Led3)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Led2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Led1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MainForm"
        Me.Text = "iRover PCB Test Rev 2"
        CType(Me.Led1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Led2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Led3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Led4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Led5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Led6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Led7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Led8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Led9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Led10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Led1 As NationalInstruments.UI.WindowsForms.Led
    Friend WithEvents Led2 As NationalInstruments.UI.WindowsForms.Led
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Led3 As NationalInstruments.UI.WindowsForms.Led
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Led4 As NationalInstruments.UI.WindowsForms.Led
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Led5 As NationalInstruments.UI.WindowsForms.Led
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Led6 As NationalInstruments.UI.WindowsForms.Led
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Led7 As NationalInstruments.UI.WindowsForms.Led
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Led8 As NationalInstruments.UI.WindowsForms.Led
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Led9 As NationalInstruments.UI.WindowsForms.Led
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Led10 As NationalInstruments.UI.WindowsForms.Led

End Class
