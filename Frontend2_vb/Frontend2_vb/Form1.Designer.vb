<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Label1 = New Label()
        Log_in = New Button()
        Sign_up = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.IndianRed
        Label1.Location = New Point(354, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(52, 15)
        Label1.TabIndex = 0
        Label1.Text = "VItaLuxx"
        ' 
        ' Log_in
        ' 
        Log_in.BackColor = Color.Yellow
        Log_in.Location = New Point(322, 191)
        Log_in.Name = "Log_in"
        Log_in.Size = New Size(129, 44)
        Log_in.TabIndex = 1
        Log_in.Text = "Log In"
        Log_in.UseVisualStyleBackColor = False
        ' 
        ' Sign_up
        ' 
        Sign_up.BackColor = Color.Orange
        Sign_up.Location = New Point(322, 241)
        Sign_up.Name = "Sign_up"
        Sign_up.Size = New Size(129, 40)
        Sign_up.TabIndex = 2
        Sign_up.Text = "Sign_up"
        Sign_up.UseVisualStyleBackColor = False
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Sign_up)
        Controls.Add(Log_in)
        Controls.Add(Label1)
        Name = "Form1"
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Log_in As Button
    Friend WithEvents Sign_up As Button

End Class
