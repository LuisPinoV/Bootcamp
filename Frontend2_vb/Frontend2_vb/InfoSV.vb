Imports System.Net.Http
Imports System.Text.Json
Imports Microsoft


Public Class InfoSV

    Public Async Function GetData() As Task(Of List(Of PacienteDatos))

        Dim response As HttpResponseMessage = Await _client


        Dim responsestr As String = Await response.Content.ReadAsStringAsync()
        Dim responselist As List(Of PacienteDatos) = JsonSerializer.Deserialize(Of List(Of PacienteDatos))(responsestr)

        Return responselist
    End Function

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub
End Class
