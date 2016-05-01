Imports Modelo
Imports DAL

Public Class BLLCliente
    Dim objD As DALCliente

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

    Public Function Pesquisar(codigo As Integer)

        objD = New DALCliente
        Return objD.Pesquisar(codigo)

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

End Class
