Imports System.Data
Imports System.Data.SqlClient
Imports Modelo

Public Class DALCliente

    Dim cmd As SqlCommand
    Dim objD As Dados

    Public Sub New()
        LimparObjetos()
    End Sub


    Public Sub Inserir(objBLL As Cliente)

        IniciarObjetos()

        cmd.CommandText = "insert into Clientes (cli_nome, cli_telefone, cli_datanasc, cli_datacadastro, cli_rg) values (@nome,@telefone,@datanasc, @datacad, @rg)"
        cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = objBLL.nome
        cmd.Parameters.Add("@telefone", SqlDbType.VarChar).Value = objBLL.telefone
        cmd.Parameters.Add("@datanasc", SqlDbType.VarChar).Value = objBLL.DataNasc
        cmd.Parameters.Add("@datacad", SqlDbType.VarChar).Value = objBLL.dataCad
        cmd.Parameters.Add("@rg", SqlDbType.VarChar).Value = objBLL.rg

        objD.executaCmd(cmd)

        LimparObjetos()

    End Sub

    Public Sub AlterarCliente(objBLL As Cliente)

        IniciarObjetos()

        cmd.CommandText = "update Clientes set cli_nome = @nome, cli_telefone = @telefone, cli_datanasc = @datanasc, cli_rg = @rg where cli_codigo = @codigo"
        cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = objBLL.nome
        cmd.Parameters.Add("@telefone", SqlDbType.VarChar).Value = objBLL.telefone
        cmd.Parameters.Add("@datanasc", SqlDbType.VarChar).Value = objBLL.DataNasc
        cmd.Parameters.Add("@codigo", SqlDbType.Int).Value = objBLL.id
        cmd.Parameters.Add("@rg", SqlDbType.VarChar).Value = objBLL.rg

        objD.executaCmd(cmd)

        LimparObjetos()

    End Sub

    Public Function Pesquisar(nome As String)

        IniciarObjetos()

        cmd.CommandText = "select * from vwClientes where Nome like @nome "
        cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = "%" & nome & "%"

        Return objD.executaConsulta(cmd)

        LimparObjetos()

    End Function

    Public Function Pesquisar(codigo As Integer)


        IniciarObjetos()
        cmd.CommandText = "select * from vwClientes where Codigo = @codigo "
        cmd.Parameters.Add("@codigo", SqlDbType.Int).Value = codigo

        Return objD.executaConsulta(cmd)

        LimparObjetos()

    End Function

    Private Sub IniciarObjetos()
        cmd = New SqlCommand
        objD = New Dados

    End Sub

    Private Sub LimparObjetos()
        cmd = Nothing
        objD = Nothing

    End Sub

End Class
