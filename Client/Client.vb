Public Class Client

    Private listExtracts = New List(Of Extracts)

    Private _name As String
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property

    Private _cpf As String
    Public Property Cpf() As String
        Get
            Return _cpf
        End Get
        Set(ByVal value As String)
            _cpf = value
        End Set
    End Property

    Private _birthday As String
    Public Property Birthday() As String
        Get
            Return _birthday
        End Get
        Set(ByVal value As String)
            _birthday = value
        End Set
    End Property

    Private _money As String
    Public Property Money() As Double
        Get
            Return _money
        End Get
        Set(ByVal value As Double)
            _money = value
        End Set
    End Property

    Private _passWord As Integer
    Public Property PassWord() As Integer
        Get
            Return _passWord
        End Get
        Set(ByVal value As Integer)
            _passWord = value
        End Set
    End Property

    Private _agency As String
    Public Property Agency() As String
        Get
            Return _agency
        End Get
        Set(ByVal value As String)
            _agency = value
        End Set
    End Property

    Public Sub New(ByVal name As String, ByVal cpf As String, ByVal password As Integer)
        Me.Name = name
        Me.Cpf = cpf
        Me.PassWord = password
        Me.Money = 0
        Me.Agency = Me.GenerateAgency()
    End Sub
    Public Sub New(ByVal name As String, ByVal cpf As String, ByVal password As Integer, ByVal birthday As String)
        Me.Name = name
        Me.Cpf = cpf
        Me.PassWord = password
        Me.Birthday = birthday
        Me.Money = 0
        Me.Agency = Me.GenerateAgency()
    End Sub

    Public Function GenerateAgency()

        Dim rand As New Random()
        Dim agencyNumber As Integer = rand.Next(1111, 9999)

        Return agencyNumber
    End Function

    Public Sub AddOperation(ByRef extracts As Extracts)
        Me.listExtracts.Add(extracts)
    End Sub

    Public Function SizeExtract()
        Dim i As Integer = 0

        For Each operations As Extracts In Me.listExtracts
            i += 1
        Next
        Return i
    End Function

    Public Function GetExtract(ByVal i As Integer)
        Return Me.listExtracts(i)
    End Function

    Public Function ToStringClient()
        Return $"__________________________________
Nome:  {Me.Name}
Cpf:  {Me.Cpf}
Data de Aniversário: {Me.Birthday}
Agência:  {Me.Agency}
Senha:  {Me.PassWord}
__________________________________"
    End Function

End Class
