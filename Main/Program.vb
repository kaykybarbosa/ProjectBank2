Imports System
Imports Segunda20.Exceptions
Imports System.Threading

'Developer: Kayky Barbosa
'Date: 20/03/22
Module Program
    Sub Main()
        Dim exceptions = New Exceptions
        Dim bank = New Bank
        Dim interfaces = New ProgramI

        Dim menuOption As Integer
        While True
            Try
                interfaces.MenuInitial()
                menuOption = Trim(Console.ReadLine())

                Console.Clear()

                If menuOption = 1 Then

                    Dim name As String
                    Dim cpf As String
                    Dim birthday As String
                    Dim passWord As String

                    Try
                        name = exceptions.ReadName("NOME COMPLETO: ")
                        If name Is Nothing Then Exit Try

                        cpf = exceptions.ReadCPF("CPF: ")

                        If cpf Is Nothing Then Exit Try

                        If bank.ClientExist(cpf) Then
                            interfaces.ClientAlreadyRegisteredMessage()
                            Exit Try
                        End If

                        birthday = exceptions.ReadBirthday("DATA DE NASCIMENTO (dd/mm/aaaa): ")

                        If birthday Is Nothing Then Exit Try

                        passWord = exceptions.ReadPassWord("Crie uma Senha (6 Digitos): ")

                        If passWord Is Nothing Then Exit Try

                        bank.AddClients(New Client(name, cpf, passWord, birthday))
                        interfaces.ClientRegisterMessage()

                    Catch ex As Exception
                        interfaces.InvalidFieldMessage()
                        Exit Try
                    End Try

                ElseIf menuOption = 2 Then

                    Dim cpf As String
                    Dim password As Integer
                    Dim access As Boolean

                    Dim CurrentClient As Client

                    Try

                        Console.Write("Insira seu CPF: ")
                        cpf = Console.ReadLine()
                        Console.Write("Insira sua SENHA: ")
                        password = Console.ReadLine()

                        access = bank.AuthenticateClient(cpf, password)

                        interfaces.AccessingMesssage()

                        If Not access Then
                            interfaces.InvalidOptionCpfPassword()
                            Exit Try
                        End If

                        Console.Clear()
                        CurrentClient = bank.GetUser(cpf)

                        Dim userControlOption As Integer = 0
                        While userControlOption <> 7

                            Try
                                interfaces.MenuBank(CurrentClient.Name)
                                userControlOption = Console.ReadLine()

                                Console.Clear()
                                Select Case userControlOption
                                    Case 1

                                        Dim money As Double = CurrentClient.Money
                                        interfaces.DisplayMoney(money)

                                    Case 2

                                        Dim minimumValue As Double = 1
                                        Dim withDrawValue As Double
                                        Dim withDrawPassword As Integer
                                        Dim result As String

                                        withDrawValue = exceptions.CheckValue("Saque", minimumValue)

                                        If withDrawValue = Nothing Then Exit Try

                                        withDrawPassword = exceptions.ReadTransactionPassWord()

                                        If withDrawPassword = Nothing Then Exit Try

                                        Dim OperationData = New Operations(CurrentClient.Cpf, withDrawValue, withDrawPassword)
                                        result = bank.Withdraw(OperationData)

                                        interfaces.ResultMessage(result)

                                    Case 3

                                        Dim minimumValue As Double = 20
                                        Dim depositValue As Double
                                        Dim result As String

                                        depositValue = exceptions.CheckValue("Depósito", minimumValue)

                                        If depositValue = Nothing Then Exit Try

                                        Dim operationData = New Operations(CurrentClient.Cpf, depositValue)
                                        result = bank.Deposit(operationData)

                                        interfaces.ResultMessage(result)

                                    Case 4

                                        Dim beneficiaryAgency As String
                                        Dim accountChecking As Boolean
                                        Dim minimumValue = 10
                                        Dim transferValue As Double
                                        Dim transferPassword As Integer
                                        Dim result As String

                                        Console.Write("Agência do Beneficiário: ")
                                        beneficiaryAgency = Console.ReadLine()

                                        accountChecking = bank.AuthenticateAgency(beneficiaryAgency, cpf)

                                        If Not accountChecking Then
                                            interfaces.InvalidAgencyMessage()
                                            Exit Try
                                        End If

                                        transferValue = exceptions.CheckValue("Transferência", minimumValue)

                                        If transferValue = Nothing Then Exit Try

                                        transferPassword = exceptions.ReadTransactionPassWord()

                                        Dim operationData As New Operations(CurrentClient.Cpf, transferValue, transferPassword)
                                        result = bank.Transfer(operationData, beneficiaryAgency)

                                        interfaces.ResultMessage(result)

                                    Case 5
                                        Console.WriteLine(bank.ToStringUser(cpf))
                                        Console.ReadLine()
                                        Console.Clear()

                                    Case 6
                                        interfaces.MenuExtracts()
                                        bank.DisplayExtract(cpf)

                                        Console.ReadLine()
                                        Console.Clear()

                                    Case 7
                                        interfaces.AccountExitMessage()

                                    Case Else
                                        interfaces.InvalidOptionMessage()
                                End Select

                            Catch ex As Exception
                                interfaces.InvalidOptionMessage()
                            End Try

                        End While

                    Catch ex As Exception
                        interfaces.InvalidFieldMessage()
                    End Try

                ElseIf menuOption = 3 Then
                    interfaces.ProgramExitMessage()
                    End
                Else
                    interfaces.InvalidOptionMessage()
                End If

            Catch ex As Exception
                interfaces.InvalidOptionMessage()
                Exit Try
            End Try

        End While

        Console.ReadLine()
    End Sub

End Module
