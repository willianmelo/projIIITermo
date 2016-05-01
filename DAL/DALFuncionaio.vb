Imports System.Data
Imports System.Data.SqlClient
Imports Modelo

Public Class DALFuncionaio

    Dim cmd As SqlCommand
    Dim objD As Dados


    Private Sub inserir(objF As Funcionario)

        InicializarVariaveis()

        cmd.CommandText = "insert into Funcionarios (fun_nome, fun_cpf, fun_dataadmissao, fun_venccnh, fun_numerocnh, fun_datanasc, fun_salario, fun_dtDemissao, fun_status)" +
                             +"values (@nome, @cpf, @dtAdmissao, @vencCnh, @numeroCnh, @dtNasc, @salario, @dtDemissao, @status)"

        cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = objF.nome
        cmd.Parameters.Add("@cpf", SqlDbType.VarChar).Value = objF.cpf
        cmd.Parameters.Add("@dtAdmissao", SqlDbType.VarChar).Value = objF.dtAdmissao
        cmd.Parameters.Add("@vencCnh", SqlDbType.VarChar).Value = objF.vencCnh
        cmd.Parameters.Add("@numeroCnh", SqlDbType.VarChar).Value = objF.numeroCnh
        cmd.Parameters.Add("@dtNasc", SqlDbType.VarChar).Value = objF.dtNasc
        cmd.Parameters.Add("@salario", SqlDbType.VarChar).Value = objF.salario
        cmd.Parameters.Add("@dtDemissao", SqlDbType.VarChar).Value = objF.dtDemissao
        cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = objF.status


        objD.executaCmd(cmd)

        FinalizarVariaveis()
    End Sub

    Private Sub Alterar(objF As Funcionario)
        InicializarVariaveis()

        cmd.CommandText = "update Funcionarios set (fun_nome= @nome,  fun_cpf= @cpf, fun_dataadmissao = @dtAdmissao, " +
                            +"fun_venccnh = @vencCnh, fun_numerocnh = @numeroCnh, fun_datanasc =@dtNasc," +
                            +"fun_salario =@salario, fun_dtDemissao= @dtDemissao where id = @id)"


        cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = objF.nome
        cmd.Parameters.Add("@cpf", SqlDbType.VarChar).Value = objF.cpf
        cmd.Parameters.Add("@dtAdmissao", SqlDbType.VarChar).Value = objF.dtAdmissao
        cmd.Parameters.Add("@vencCnh", SqlDbType.VarChar).Value = objF.vencCnh
        cmd.Parameters.Add("@numeroCnh", SqlDbType.VarChar).Value = objF.numeroCnh
        cmd.Parameters.Add("@dtNasc", SqlDbType.VarChar).Value = objF.dtNasc
        cmd.Parameters.Add("@salario", SqlDbType.VarChar).Value = objF.salario
        cmd.Parameters.Add("@dtDemissao", SqlDbType.VarChar).Value = objF.dtDemissao
        cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = objF.id

        objD.executaCmd(cmd)

        FinalizarVariaveis()
    End Sub




    Private Sub InicializarVariaveis()
        cmd = New SqlCommand
        objD = New Dados
    End Sub

    Private Sub FinalizarVariaveis()
        cmd = Nothing
        objD = Nothing
    End Sub
End Class
