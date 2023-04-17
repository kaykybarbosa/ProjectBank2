Public Class Bank
    Private ReadOnly longinAdm As String
    Private ReadOnly passWordAdm As Integer

    Protected ClientsList = New List(Of Client)

    Public Sub New()
        Me.longinAdm = "12312312312"
        Me.passWordAdm = 123654

        Me.AddClients(New Client("SUPREMO", Me.longinAdm, Me.passWordAdm))
    End Sub

    Public Sub AddClients(ByVal client As Client)
        Me.ClientsList.Add(client)
    End Sub

    Public Function GetUser(ByVal cpf As String)

        For Each client As Client In Me.ClientsList

            If client.Cpf.Equals(cpf) Then
                Return client
            End If

        Next

        Return Nothing
    End Function

    Private Function GetClientAngecy(ByVal agency As String)

        For Each client As Client In ClientsList

            If client.Agency.Equals(agency) Then
                Return client
            End If
        Next

        Return 0
    End Function

    Public Function AuthenticateClient(ByVal cpf As String, ByVal password As Integer)

        Try
            Dim client As Client = Me.GetUser(cpf)

            If Me.Adm(cpf, password) Then
                Return True
            End If

            If client Is Nothing Then
                Return False
            End If

            If Not client.PassWord = password Then
                Return False
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function Withdraw(ByVal operationData As Operations)

        Dim client As Client = Me.GetUser(operationData.Cpf)

        If Not Me.PasswordVerification(client, operationData.PassWord) Then
            Return "Senha Inválida, Tente Novamente."
        End If

        If Not Me.MoneyVerification(client, operationData.Value) Then
            Return "Saldo Insuficiente."
        End If

        client.Money -= operationData.Value
        client.AddOperation(New Extracts("Saque -------------", operationData.Value))

        Return "Saque Realizado."
    End Function
    Private Function PasswordVerification(ByVal client As Client, ByVal password As Integer)

        If client.PassWord = password Then
            Return True
        End If

        Return False
    End Function

    Private Function MoneyVerification(ByVal client As Client, ByVal money As Double)

        If client.Money >= money Then
            Return True
        End If

        Return False
    End Function

    Public Function Deposit(ByVal operationData As Operations)

        Dim client As Client = Me.GetUser(operationData.Cpf)

        client.Money += operationData.Value
        client.AddOperation(New Extracts("Depósito ----------", operationData.Value))

        Return " Depósito Realizado."
    End Function

    Public Function Transfer(ByVal operationData As Operations, ByVal beneficiaryAgency As String)

        Dim client As Client = Me.GetUser(operationData.Cpf)

        If Not ConfirmTransfer(beneficiaryAgency, operationData.Value) Then
            Return "Transfêrencia Cancelada."
        End If

        If Not PasswordVerification(client, operationData.PassWord) Then
            Return "Senha Inválida, Tente Novamente"
        End If

        If Not MoneyVerification(client, operationData.Value) Then
            Return "Saldo Insuficiente."
        End If

        TranferToBeneficiary(beneficiaryAgency, operationData.Value)

        client.Money -= operationData.Value
        client.AddOperation(New Extracts("Tranferência ------", operationData.Value))

        Return "Transferência Realizada."
    End Function
    Private Sub TranferToBeneficiary(ByVal beneficiaryAgency As String, ByVal value As Double)

        Dim beneficiary As Client = GetClientAngecy(beneficiaryAgency)

        beneficiary.Money += value
        beneficiary.AddOperation(New Extracts("Transf Recebida ---", value))
    End Sub

    Public Function AuthenticateAgency(ByVal agency As String, ByVal cpf As String)
        Try
            Dim client As Client = GetClientAngecy(agency)
            Dim selfVerification As Client = Me.GetUser(cpf)

            If Not client.Agency.Equals(agency) Then
                Return False
            End If

            If selfVerification.Agency.Equals(agency) Then
                Return False
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function ConfirmTransfer(ByVal agency As String, ByVal value As Double)
        Dim exception As New Exceptions
        Dim beneficiary = Me.GetClientAngecy(agency)

        Console.Clear()
        Console.WriteLine($"{vbCrLf}---------------------------------------")
        Console.WriteLine("CONFIRME OS DADOS DO BENEFICIÁRIO")
        Console.WriteLine($"   Nome: {beneficiary.Name}")
        Console.WriteLine($"   Agência: {beneficiary.Agency}")
        Console.WriteLine($"   Valor: R$ {value:F2}")
        Console.WriteLine("---------------------------------------")

        Console.WriteLine("[1] - Confirmar Tranferência")
        Console.WriteLine("[2] - Cancelar Tranferência")
        Dim confirmation As Integer = exception.ReadOption(1, 2)

        If confirmation = 1 Then
            Return True
        End If

        Return False
    End Function

    Public Function Adm(ByVal cpf As String, ByVal password As Integer)

        If Me.longinAdm.Equals(cpf) And Me.passWordAdm = password Then

            For Each client As Client In ClientsList
                Console.WriteLine(client.ToStringClient())
            Next
            Console.ReadLine()
            Return True

        End If

        Return False
    End Function

    Public Function DisplayExtract(cpf As String)
        Dim client As Client = Me.GetUser(cpf)
        Try
            For i As Integer = 0 To client.SizeExtract() - 1
                Dim details As Extracts = client.GetExtract(i)

                Console.WriteLine($"{details.OperatiuonType} R$ {details.OperationValue:F2}")
            Next
            Console.WriteLine("----------------------------")

        Catch ex As Exception
            Return ex.Message
        End Try

        Return Nothing
    End Function

    Public Function ClientExist(ByVal cpf As String)

        Dim client As Client = Me.GetUser(cpf)

        If client Is Nothing Then
            Return False
        End If

        Return True
    End Function

    Public Function ToStringUser(ByVal cpf As String)

        Dim client As Client = Me.GetUser(cpf)

        Return client.ToStringClient()

    End Function

End Class