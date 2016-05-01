Imports System.Data
Imports System.Data.SqlClient
Public Class Dados

    Dim con As New SqlConnection("data source = will; initial catalog= bdFPC; integrated security = true;")

    Function abreConexao() As Boolean
        Try
            If (con.State = ConnectionState.Closed) Then
                con.Open()
            End If
            Return True
        Catch ex As Exception
            Throw New Exception("Erro ao abrir conexão " & ex.Message, ex)
            Return False
        End Try
    End Function

    Function fechaConexao() As Boolean
        Try
            If (con.State = ConnectionState.Open) Then
                con.Close()
            End If
            Return True
        Catch ex As Exception
            Throw New Exception("Erro ao fechar conexao " & ex.Message, ex)
            Return False
        End Try
    End Function

    'update, delete ou insert sem retornar a sequencia inserida
    Function executaCmd(ByVal cmd As SqlCommand) As Integer
        Dim ret As Integer
        Try
            cmd.Connection = con
            abreConexao()
            ret = cmd.ExecuteNonQuery
            fechaConexao()
        Catch ex As Exception
            Throw New Exception("Erro ao executar comando" & ex.Message, ex)
            ret = -1
        Finally
            cmd = Nothing
        End Try
        Return ret
    End Function

    'select que retorna uma linha e uma coluna
    Function executaCmdScalar(ByVal cmd As SqlCommand) As String
        Dim ret As String
        Try
            cmd.Connection = con
            abreConexao()
            ret = cmd.ExecuteScalar
            fechaConexao()
        Catch ex As Exception
            Throw New Exception("Erro ao executar comando " & ex.Message, ex)
            ret = ""
        Finally
            cmd = Nothing
        End Try
        Return ret
    End Function

    'insert que retorna a sequencia inserida
    Function executaCmdAI(ByVal cmd As SqlCommand, ByVal tabela As String) As Integer
        Dim ret As Integer
        Try
            cmd.Connection = con
            abreConexao()
            cmd.CommandText &= ";select @@identity " & tabela & ";"
            ret = Convert.ToInt32(cmd.ExecuteScalar.ToString)
            'dando erro na conversão
            fechaConexao()
        Catch ex As Exception
            Throw New Exception("Erro ao executar comando " & ex.Message, ex)
            ret = -1
        Finally
            cmd = Nothing

        End Try
        Return ret

    End Function

    'select - retorna datatable
    Function retdadosTab(ByVal cmd As SqlCommand) As DataTable
        Dim tab As DataTable
        Dim ds As DataSet
        Dim da As SqlDataAdapter
        Try
            cmd.Connection = con
            da = New SqlDataAdapter
            da.SelectCommand = cmd
            ds = New DataSet
            da.Fill(ds, "tab")
            tab = ds.Tables("tab")
        Catch ex As Exception
            Throw New Exception("Erro ao selecionar dados " & ex.Message, ex)
        Finally
            da = Nothing
            ds = Nothing
        End Try
        Return tab
    End Function

    Function executaConsulta(ByVal cmd As SqlCommand) As DataTable
        Dim tab As New DataTable
        Dim da As New SqlDataAdapter
        Try
            cmd.Connection = con
            da.SelectCommand = cmd
            da.Fill(tab)
            da = Nothing
        Catch ex As Exception
            Throw ex
        End Try
        Return tab
    End Function

    'select - retorna dataset
    Function retdados(ByVal cmd As SqlCommand) As DataSet
        Dim ds As DataSet
        Dim da As SqlDataAdapter
        Try
            cmd.Connection = con
            da = New SqlDataAdapter
            da.SelectCommand = cmd
            ds = New DataSet
            da.Fill(ds, "tab")
        Catch ex As Exception
            Throw New Exception("Erro ao selecionar dados " & ex.Message, ex)
        Finally
            da = Nothing
        End Try
        Return ds
    End Function

End Class

