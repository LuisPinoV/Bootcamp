<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InfoSV
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Panel1 = New Panel()
        sex = New Label()
        age = New Label()
        Id_paciente = New Label()
        Panel2 = New Panel()
        Temp = New Label()
        Pres = New Label()
        Rpm = New Label()
        Pulse = New Label()
        Label1 = New Label()
        Label7 = New Label()
        Label2 = New Label()
        Label6 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        ComboBox1 = New ComboBox()
        PictureBox1 = New PictureBox()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(sex)
        Panel1.Controls.Add(age)
        Panel1.Controls.Add(Id_paciente)
        Panel1.Controls.Add(Panel2)
        Panel1.Controls.Add(Label5)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(Label3)
        Panel1.Location = New Point(78, 127)
        Panel1.Margin = New Padding(3, 4, 3, 4)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(731, 272)
        Panel1.TabIndex = 3
        ' 
        ' sex
        ' 
        sex.AutoSize = True
        sex.Location = New Point(119, 215)
        sex.Name = "sex"
        sex.Size = New Size(30, 20)
        sex.TabIndex = 10
        sex.Text = "sex"
        ' 
        ' age
        ' 
        age.AutoSize = True
        age.Location = New Point(119, 172)
        age.Name = "age"
        age.Size = New Size(43, 20)
        age.TabIndex = 9
        age.Text = "edad"
        ' 
        ' Id_paciente
        ' 
        Id_paciente.AutoSize = True
        Id_paciente.Location = New Point(119, 123)
        Id_paciente.Name = "Id_paciente"
        Id_paciente.Size = New Size(24, 20)
        Id_paciente.TabIndex = 8
        Id_paciente.Text = "ID"
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(Temp)
        Panel2.Controls.Add(Pres)
        Panel2.Controls.Add(Rpm)
        Panel2.Controls.Add(Pulse)
        Panel2.Controls.Add(Label1)
        Panel2.Controls.Add(Label7)
        Panel2.Controls.Add(Label2)
        Panel2.Controls.Add(Label6)
        Panel2.Location = New Point(214, 81)
        Panel2.Margin = New Padding(3, 4, 3, 4)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(462, 133)
        Panel2.TabIndex = 7
        ' 
        ' Temp
        ' 
        Temp.AutoSize = True
        Temp.Location = New Point(338, 55)
        Temp.Name = "Temp"
        Temp.Size = New Size(61, 20)
        Temp.TabIndex = 14
        Temp.Text = "Label11"
        ' 
        ' Pres
        ' 
        Pres.AutoSize = True
        Pres.Location = New Point(234, 55)
        Pres.Name = "Pres"
        Pres.Size = New Size(61, 20)
        Pres.TabIndex = 13
        Pres.Text = "Label10"
        ' 
        ' Rpm
        ' 
        Rpm.AutoSize = True
        Rpm.Location = New Point(114, 55)
        Rpm.Name = "Rpm"
        Rpm.Size = New Size(53, 20)
        Rpm.TabIndex = 12
        Rpm.Text = "Label9"
        ' 
        ' Pulse
        ' 
        Pulse.AutoSize = True
        Pulse.Location = New Point(14, 55)
        Pulse.Name = "Pulse"
        Pulse.Size = New Size(53, 20)
        Pulse.TabIndex = 11
        Pulse.Text = "Label8"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(14, 13)
        Label1.Name = "Label1"
        Label1.Size = New Size(44, 20)
        Label1.TabIndex = 3
        Label1.Text = "Pulso"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(325, 13)
        Label7.Name = "Label7"
        Label7.Size = New Size(93, 20)
        Label7.TabIndex = 6
        Label7.Text = "Temperatura"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(125, 13)
        Label2.Name = "Label2"
        Label2.Size = New Size(39, 20)
        Label2.TabIndex = 4
        Label2.Text = "RPM"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(234, 13)
        Label6.Name = "Label6"
        Label6.Size = New Size(57, 20)
        Label6.TabIndex = 5
        Label6.Text = "Presion"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(9, 215)
        Label5.Name = "Label5"
        Label5.Size = New Size(44, 20)
        Label5.TabIndex = 2
        Label5.Text = "Sexo:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(9, 172)
        Label4.Name = "Label4"
        Label4.Size = New Size(46, 20)
        Label4.TabIndex = 1
        Label4.Text = "Edad:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(9, 123)
        Label3.Name = "Label3"
        Label3.Size = New Size(90, 20)
        Label3.TabIndex = 0
        Label3.Text = "ID_paciente:"
        ' 
        ' ComboBox1
        ' 
        ComboBox1.FormattingEnabled = True
        ComboBox1.Items.AddRange(New Object() {"ID143567", "ID859267", "ID037691", "ID856023", "ID785902", "ID947201", "ID759281"})
        ComboBox1.Location = New Point(87, 46)
        ComboBox1.Margin = New Padding(3, 4, 3, 4)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(199, 28)
        ComboBox1.TabIndex = 4
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Location = New Point(733, 28)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(125, 62)
        PictureBox1.TabIndex = 5
        PictureBox1.TabStop = False
        ' 
        ' InfoSV
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(914, 600)
        Controls.Add(PictureBox1)
        Controls.Add(ComboBox1)
        Controls.Add(Panel1)
        Margin = New Padding(3, 4, 3, 4)
        Name = "InfoSV"
        Text = "Pacientes"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents sex As Label
    Friend WithEvents age As Label
    Friend WithEvents Id_paciente As Label
    Friend WithEvents Temp As Label
    Friend WithEvents Pres As Label
    Friend WithEvents Rpm As Label
    Friend WithEvents Pulse As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
