Imports System.Threading

Public Class ProgramI

    Private ReadOnly DateTime As DateTime = Date.Now
    Public Sub MenuInitial()
        Console.WriteLine("  ------------------")
        Console.WriteLine("    BANCO KBULOSO ")
        Console.WriteLine("   ----------------")
        Console.WriteLine("-----------------------")
        Console.WriteLine(" [1] - Criar Conta")
        Console.WriteLine(" [2] - Longin")
        Console.WriteLine(" [3] - Fechar Programa")
        Console.WriteLine("-----------------------")
        Console.Write("Opção: ")
    End Sub

    Public Sub Welcome(ByVal name As String)
        Dim positionEspace As String = InStr(name, " ")

        If positionEspace > 0 Then
            Console.WriteLine($"{vbCrLf} {Me.HoursNow()}{vbCrLf}  {Mid(name, 1, positionEspace)} {vbCrLf}")
        Else
            Console.WriteLine($"{vbCrLf} {Me.HoursNow()}{vbCrLf}  {name} {vbCrLf}")
        End If
    End Sub
    Public Sub MenuBank(ByVal name As String)
        Me.Welcome(name)
        Console.WriteLine("------------------------------------")
        Console.WriteLine("[1] - Saldo")
        Console.WriteLine("[2] - Saque")
        Console.WriteLine("[3] - Depósitar")
        Console.WriteLine("[4] - Transferir")
        Console.WriteLine("[5] - Perfil")
        Console.WriteLine("[6] - Ver Extrato")
        Console.WriteLine("[7] - Sair da Conta")
        Console.WriteLine("------------------------------------")
        Console.Write("Opção: ")
    End Sub

    Public Sub ClientRegisterMessage()
        Console.Clear()
        Console.WriteLine($"{vbCrLf} Cliente Cadastrado.{vbCrLf}")
    End Sub
    Public Sub ClientAlreadyRegisteredMessage()
        Console.WriteLine($"{vbCrLf} Cliente Já Está Cadastrado!{vbCrLf}")
    End Sub

    Public Sub InvalidFieldMessage()
        Console.Clear()
        Console.WriteLine($"{vbCrLf} Preencha os Campos Corretamente.{vbCrLf}")
    End Sub

    Public Sub InvalidOptionCpfPassword()
        Console.Clear()
        Console.WriteLine($"{vbCrLf} Cpf ou Senha Incorretos. {vbCrLf}")
    End Sub

    Public Sub AccessingMesssage()
        Console.WriteLine($"{vbCrLf} Acessando...")
        Thread.Sleep(2000)
    End Sub

    Public Sub InvalidAgencyMessage()
        Console.Clear()
        Console.WriteLine($"{vbCrLf} Agência do Beneficiário Inválida.{vbCrLf}")
    End Sub

    Public Sub InvalidOptionMessage()
        Console.Clear()
        Console.WriteLine($"{vbCrLf} Opção Inválida.{vbCrLf}")
    End Sub

    Public Sub DisplayMoney(ByVal money As Double)
        Console.WriteLine($"{vbCrLf} Saldo: R$ {money:F2}")
        Console.ReadLine()
        Console.Clear()
    End Sub
    Public Sub MenuExtracts()
        Console.WriteLine("----------------------------")
        Console.WriteLine("       SEU EXTRATO")
        Console.WriteLine(" TIPO               VALOR")
        Console.WriteLine("----------------------------")
    End Sub

    Public Sub ResultMessage(ByVal result As String)
        Console.Clear()
        Console.WriteLine($"{vbCrLf} Verificando...{vbCrLf}")
        Thread.Sleep(1000)
        Console.Clear()
        Console.WriteLine($"{vbCrLf} {result} {vbCrLf}")
        Console.ReadLine()
        Console.Clear()
    End Sub

    Public Sub AccountExitMessage()
        Console.WriteLine($"{vbCrLf} Desconectando...")
        Thread.Sleep(2000)
        Console.Clear()
        Console.WriteLine($"{vbCrLf} Conta Desconectada!")
        Console.ReadLine()
        Console.Clear()
    End Sub

    Public Sub ProgramExitMessage()
        Console.WriteLine($"{vbCrLf} Encerrando Programa...")
        Thread.Sleep(2000)
        Console.Clear()
        Console.WriteLine($"{vbCrLf}  OBRIGADO, VOLTE SEMPRE :)")
    End Sub

    Private Function HoursNow()
        Dim hourNow = DateTime.Hour

        If hourNow < 12 Then
            Return "Bom Dia,"
        End If

        If hourNow < 18 Then
            Return "Boa Tarde,"
        End If

        If hourNow < 24 Then
            Return "Boa Noite,"
        End If

        Return Nothing
    End Function

End Class
