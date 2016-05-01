Imports System.Data
Imports System.Data.SqlClient
Imports Modelo

Public Class DALCliente

    Dim cmd As SqlCommand
    Dim objD As Dados

    Public Sub Inserir(objBLL As Cliente)

        IniciarObjetos()

        cmd.CommandText = "insert into Clientes (cli_nome, cli_telefone, cli_datanasc, cli_datacadastro) values (@nome,@telefone,@datanasc, @datacad)"
        cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = objBLL.nome
        cmd.Parameters.Add("@telefone", SqlDbType.VarChar).Value = objBLL.telefone
        cmd.Parameters.Add("@datanasc", SqlDbType.VarChar).Value = objBLL.DataNasc
        cmd.Parameters.Add("@datacad", SqlDbType.VarChar).Value = objBLL.DataCad

        objD.executaCmd(cmd)

        LimparObjetos()

    End Sub

    Public Sub AlterarCliente(objBLL As Cliente)

        IniciarObjetos()

        cmd.CommandText = "update Clientes set cli_nome = @nome, cli_telefone = @telefone, cli_datanasc = @datanasc where cli_codigo = @codigo"
        cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = objBLL.nome
        cmd.Parameters.Add("@telefone", SqlDbType.VarChar).Value = objBLL.telefone
        cmd.Parameters.Add("@datanasc", SqlDbType.VarChar).Value = objBLL.DataNasc
        cmd.Parameters.Add("@codigo", SqlDbType.Int).Value = objBLL.id

        objD.executaCmd(cmd)

        LimparObjetos()

    End Sub

    Private Sub IniciarObjetos()
        cmd = New SqlCommand
        objD = New Dados
    End Sub

    Private Sub LimparObjetos()
        cmd = Nothing
        objD = Nothing

    End Sub

End Class
