Public Class Extracts
    Private _operationType As String
    Public Property OperatiuonType() As String
        Get
            Return _operationType
        End Get
        Set(ByVal value As String)
            _operationType = value
        End Set
    End Property

    Private _operationvalue As Double
    Public Property OperationValue() As Double
        Get
            Return _operationvalue
        End Get
        Set(ByVal value As Double)
            _operationvalue = value
        End Set
    End Property

    Public Sub New(ByVal type As String, ByVal value As Double)

        Me.OperatiuonType = type
        Me.OperationValue = value
    End Sub

End Class
