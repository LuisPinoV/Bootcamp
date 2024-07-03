<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LogIn
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Log_in = New Button()
        Sign_up = New Button()
        PictureBox1 = New PictureBox()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Log_in
        ' 
        Log_in.BackColor = Color.Yellow
        Log_in.Location = New Point(368, 255)
        Log_in.Margin = New Padding(3, 4, 3, 4)
        Log_in.Name = "Log_in"
        Log_in.Size = New Size(147, 59)
        Log_in.TabIndex = 1
        Log_in.Text = "Log In"
        Log_in.UseVisualStyleBackColor = False
        ' 
        ' Sign_up
        ' 
        Sign_up.BackColor = Color.Orange
        Sign_up.Location = New Point(368, 321)
        Sign_up.Margin = New Padding(3, 4, 3, 4)
        Sign_up.Name = "Sign_up"
        Sign_up.Size = New Size(147, 53)
        Sign_up.TabIndex = 2
        Sign_up.Text = "Sign_up"
        Sign_up.UseVisualStyleBackColor = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Location = New Point(725, 116)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(125, 62)
        PictureBox1.TabIndex = 3
        PictureBox1.TabStop = False
        ' 
        ' LogIn
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(914, 600)
        Controls.Add(PictureBox1)
        Controls.Add(Sign_up)
        Controls.Add(Log_in)
        Margin = New Padding(3, 4, 3, 4)
        Name = "LogIn"
        Text = "Vitalux"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub
    Friend WithEvents Log_in As Button
    Friend WithEvents Sign_up As Button
    Friend WithEvents PictureBox1 As PictureBox

End Class
