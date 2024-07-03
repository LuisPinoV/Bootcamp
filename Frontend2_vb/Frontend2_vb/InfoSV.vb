Public Class InfoSV
    Private Sub InfoSV_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        Dim font As New Font("Arial", 24, FontStyle.Bold)
        Dim brush As New SolidBrush(Color.Black)
        Dim point As New Point(350, 50)
        e.Graphics.DrawString("VitaLuxx", font, brush, point)
        font.Dispose()
        brush.Dispose()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
    Private Sub Form3_campana(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim imagePath As String = "C:\Users\Larsi\OneDrive\Escritorio\campana.png"
        PictureBox1.Image = Image.FromFile(imagePath)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.Location = New Point(750, 50)
    End Sub

End Class