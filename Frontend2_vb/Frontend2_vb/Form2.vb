Public Class Form2
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim window = New InfoSV
        Me.Close()

        window.ShowDialog()

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Label3.Text = "Too bad lmao"


    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        Dim font As New Font("Arial", 24, FontStyle.Bold)
        Dim brush As New SolidBrush(Color.Black)
        Dim point As New Point(500, 50)
        e.Graphics.DrawString("VitaLuxx", font, brush, point)
        font.Dispose()
        brush.Dispose()
    End Sub
    Private Sub Form2_campana(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim imagePath As String = "VitaluxxLogo.png"
        PictureBox1.Image = Image.FromFile(imagePath)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.Location = New Point(750, 50)
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
End Class