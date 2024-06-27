Public Class Form1

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Sign_up.Click

    End Sub

    Private Sub Log_in_Click(sender As Object, e As EventArgs) Handles Log_in.Click
        Dim value = New Form2()
        Me.AddOwnedForm(value)
        value.ShowDialog()
        Dim cancel = New WindowsFormsSection



    End Sub
End Class
