Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Text.Json
Imports System.Threading
Imports Microsoft
Imports Newtonsoft.Json
Imports System.Timers

Public Class InfoSV
    Private updateTimer As System.Timers.Timer
    'sacado de
    'https://es.stackoverflow.com/questions/436604/api-rest-en-visual-basic-cliente-windows-forms-vb-net
    Private Async Sub InfoSV_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        InitializeTimer()
        Dim respuesta As String = Await GetHttp("")
        Dim lista As List(Of PacienteDatos) = JsonConvert.DeserializeObject(Of List(Of PacienteDatos))(respuesta)
        DataGridView1.DataSource = lista
        'Label8.Text = String.Join(Environment.NewLine, lista.Select(Function(a) a.Id_paciente))
        'ComboBox1.Items = String.Join(Environment.NewLine, lista.Select(Function(a) a.Id_paciente))
    End Sub
    Private Sub InitializeTimer()
        ' Initialize and configure the timer
        updateTimer = New System.Timers.Timer(5000) ' 30000 milliseconds = 30 seconds
        AddHandler updateTimer.Elapsed, AddressOf OnTimedEvent
        updateTimer.AutoReset = True
        updateTimer.Enabled = True
    End Sub

    Private Async Sub OnTimedEvent(source As Object, e As ElapsedEventArgs)
        Await InfoSV_Update()
    End Sub

    Private Async Function InfoSV_Update() As Task(Of String)
        Dim respuesta As String = Await GetHttp("actualizar")
        Dim lista As List(Of PacienteDatos) = JsonConvert.DeserializeObject(Of List(Of PacienteDatos))(respuesta)
        UpdateDataGrid(lista)
        Return "Update completed"
        'Label8.Text = String.Join(Environment.NewLine, lista.Select(Function(a) a.Id_paciente))
        'ComboBox1.Items = String.Join(Environment.NewLine, lista.Select(Function(a) a.Id_paciente))
    End Function

    Private Sub UpdateDataGrid(lista As List(Of PacienteDatos))
        If DataGridView1.InvokeRequired Then
            DataGridView1.Invoke(Sub() UpdateDataGrid(lista))
        Else
            DataGridView1.DataSource = lista
            DataGridView1.Refresh()
        End If
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

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick

    End Sub
End Class
