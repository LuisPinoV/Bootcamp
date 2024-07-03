Imports System.IO
Imports System.Net

Public Class LogIn

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Sign_up.Click

    End Sub

    Private Sub Log_in_Click(sender As Object, e As EventArgs) Handles Log_in.Click
        Dim value = New Form2()
        Me.AddOwnedForm(value)
        value.ShowDialog()
        Dim cancel = New WindowsFormsSection



    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        Dim font As New Font("Arial", 24, FontStyle.Bold)
        Dim brush As New SolidBrush(Color.Black)
        Dim point As New Point(350, 50)
        e.Graphics.DrawString("VitaLuxx", font, brush, point)
        font.Dispose()
        brush.Dispose()
    End Sub
    Private Sub Form1_campana(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim imagePath As String = "bell.jpeg"
        PictureBox1.Image = Image.FromFile(imagePath)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.Location = New Point(750, 50)
    End Sub
End Class