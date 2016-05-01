Imports Modelo
Imports DAL

Public Class BLLCliente
    Dim objD As DALCliente
    Dim objC As Cliente
    Dim tab As DataTable

    Public Sub inserir(objCliente As Cliente)

        objD = New DALCliente
        objD.Inserir(objCliente)
        objD = Nothing

    End Sub

    Public Sub Alterar(objCliente As Cliente)

        objD = New DALCliente
        objD.AlterarCliente(objCliente)
        objD = Nothing

    End Sub

    Public Function Pesquisar(nome As String)

        objD = New DALCliente
        Return objD.Pesquisar(nome)

    End Function

    Public Function Pesquisar(codigo As Integer)

        objD = New DALCliente
        tab = objD.Pesquisar(codigo)
        preencherDados()
        Return objC

    End Function

    Public Function ValidarCamposObrigatorios(objCliente As Cliente)

        If (objCliente.nome.Length = 0 Or
            objCliente.dataNasc.Length = 0 Or
            objCliente.telefone.Length = 0 Or
            objCliente.rg.Length = 0) Then

            Return False
        End If

        Return True
    End Function

    Private Sub preencherDados()
        objC = New Cliente(Integer.Parse(tab.Rows(0)("Codigo").ToString),
                                    tab.Rows(0)("Nome").ToString,
                                    tab.Rows(0)("DataNasc").ToString,
                                    tab.Rows(0)("DataCad").ToString,
                                    tab.Rows(0)("Telefone").ToString,
                                    tab.Rows(0)("RG").ToString)

    End Sub

End Class
