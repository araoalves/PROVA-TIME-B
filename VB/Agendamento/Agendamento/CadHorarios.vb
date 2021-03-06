﻿Imports MySql.Data.MySqlClient
Public Class CadHorarios

    Dim id_user As String = ""
    Public Sub New(ByVal valor As String)
        InitializeComponent()
        id_user = valor
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        objconn = New MySqlConnection
        objconn.ConnectionString = "server='localhost';user='root';password='MySQL';database='agendamento';"
        objconn.Open()

        Dim hora As String = txtHora.Text
        Dim data As String = dtpData.Value.ToString("yyyy-MM-dd")

        Try
            objcmd = New MySql.Data.MySqlClient.MySqlCommand("INSERT INTO horario (hora_horario,data_horario) VALUES (@field1,@field2)", objconn)
            With objcmd
                .Parameters.AddWithValue("@field1", hora)
                .Parameters.AddWithValue("@field2", data)
            End With
            objcmd.ExecuteNonQuery()
            objcmd.Dispose()
            MsgBox("Cadastro efetuado com sucesso!", MsgBoxStyle.Information)
            txtHora.Text = ""
            carregarLista()
        Catch ex As Exception
            MsgBox("Erro")
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        txtHora.Text = ""
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Application.Exit()
    End Sub

    Private Sub CadHorarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        carregarLista()
    End Sub

    Public Sub carregarLista()
        objconn = New MySqlConnection
        objconn.ConnectionString = "server='localhost';user='root';password='MySQL';database='agendamento';"

        Dim stm As String = "SELECT * FROM horario ORDER BY id_horario"

        Try

            Dim cmd As MySqlCommand = New MySqlCommand(stm, objconn)
            Dim adpter As MySqlDataAdapter = New MySqlDataAdapter(cmd)

            Dim datatable As DataTable = New DataTable
            adpter.Fill(datatable)
            DataGridView1.DataSource = datatable


        Catch ex As MySqlException

        End Try
    End Sub
End Class