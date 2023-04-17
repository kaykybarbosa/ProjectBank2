Public Class Operations

    Private _agency As String
    Public Property Cpf() As String
        Get
            Return _agency
        End Get
        Set(ByVal value As String)
            _agency = value
        End Set
    End Property

    Private _password As Integer
    Public Property PassWord() As Integer
        Get
            Return _password
        End Get
        Set(ByVal value As Integer)
            _password = value
        End Set
    End Property

    Private _value As Double
    Public Property Value() As Double
        Get
            Return _value
        End Get
        Set(ByVal value As Double)
            _value = value
        End Set
    End Property

    Public Sub New(ByVal cpf As String, ByVal value As Double, Optional password As Integer = 0)
        Me.Cpf = cpf
        Me.Value = value
        Me.PassWord = password
    End Sub
End Class
