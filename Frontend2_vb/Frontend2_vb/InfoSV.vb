﻿Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Text.Json
Imports Microsoft
Imports Newtonsoft.Json

Public Class InfoSV
    'sacado de
    'https://es.stackoverflow.com/questions/436604/api-rest-en-visual-basic-cliente-windows-forms-vb-net
    Private Async Sub InfoSV_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Dim respuesta As String = Await GetHttp("")
        Dim lst As List(Of PacienteDatos) = JsonConvert.DeserializeObject(Of List(Of PacienteDatos))(respuesta)
        DataGridView1.DataSource = lst
    End Sub


    Private Async Function GetHttp(entidad As String) As Task(Of String) 'entidad sera la url
        Dim oRequest As WebRequest = WebRequest.Create("https://localhost:7101/" + entidad)
        Dim oResponse As WebResponse = oRequest.GetResponse()
        Dim sr As StreamReader = New StreamReader(oResponse.GetResponseStream())
        Return Await sr.ReadToEndAsync()
    End Function

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class
