Public Class Funcionario
    Public id As Integer
    Public nome As String
    Public cpf As String
    Public dtAdmissao As String
    Public vencCnh As String
    Public dtNasc As String
    Public salario As Double
    Public dtDemissao As String
    Public numeroCnh As String
    Public status As String

    Public Sub New(_id As Integer, _nome As String, _cpf As String, _dtAdmissao As String, _vencCnha As String, _dtNasc As String, _salario As Double, _dtDemissao As String, _numeroCnh As String, _status As String)
        Me.id = _id
        Me.nome = _nome
        Me.cpf = _cpf
        Me.dtAdmissao = _dtAdmissao
        Me.vencCnh = _vencCnha
        Me.dtNasc = _dtNasc
        Me.salario = _salario
        Me.dtDemissao = _dtDemissao
        Me.numeroCnh = _numeroCnh
        Me.status = _status
    End Sub

    Public Sub New()

    End Sub
End Class
