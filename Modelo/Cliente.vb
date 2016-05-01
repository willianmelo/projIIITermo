Public Class Cliente
    Public id As Integer
    Public nome As String
    Public dataNasc As String
    Public telefone As String
    Public dataCad As String
    Public rg As String

    Public Sub New(_id As Integer, _nome As String, _datanasc As String, _dataCad As String, _telefone As String, _rg As String)
        Me.id = _id
        Me.nome = _nome
        Me.telefone = _telefone
        Me.dataNasc = _datanasc
        Me.dataCad = _dataCad
        Me.rg = _rg
    End Sub

    Public Sub New()

    End Sub
End Class
