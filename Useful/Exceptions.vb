Public Class Exceptions

    Private ReadOnly DateTime As DateTime = Date.Now
    Private Attempts As Integer

    Public Function ReadName(ByVal text As String)
        Attempts = 5
        Dim name As String

        While True
            Try
                If Attempts = 0 Then
                    Console.WriteLine(Me.MaximumAttempts)
                    Return Nothing
                End If

                Attempts -= 1
                Console.Write(text)
                name = Trim(Console.ReadLine().ToUpper())

                Dim result As String = CustomWhiteLine(name)

                If result IsNot Nothing Then Return name

            Catch ex As Exception
            End Try

        End While

        Return Nothing
    End Function
    Private Function CustomWhiteLine(ByVal name As String)
        Try
            Console.Clear()
            If Not Empty(name) Then Throw New InvalidOperationException($"{vbCrLf} Campo Vazio, Preencha Corretamente.{vbCrLf}")

            If Not Num(name) Then Throw New InvalidOperationException($"{vbCrLf} Números Não São Permitidos Como Nome.{vbCrLf}")

            If Not LenMin(name) Then Throw New InvalidOperationException($"{vbCrLf} Seu Nome Não Deve Conter Menos que 10 caracteres.{vbCrLf}")

            If Not LenMax(name) Then Throw New InvalidOperationException($"{vbCrLf} Seu Nome Não Deve Conter Mais que 50 caracteres.{vbCrLf}")

            If Not SpecialSigns(name) Then Throw New InvalidOperationException($"{vbCrLf} Seu Nome Não Deve Conter Sinais.{vbCrLf}")

            Return name

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

        Return Nothing
    End Function

    Private Function Empty(ByVal text As String)

        If String.IsNullOrEmpty(text) Then Return False

        Return True
    End Function
    Private Function Num(ByVal text As String)

        If IsNumeric(text) Then Return False

        Return True
    End Function
    Private Function LenMin(ByVal text As String)

        If Len(text) < 9 Then Return False

        Return True
    End Function
    Private Function LenMax(ByVal text As String)

        If Len(text) > 30 Then Return False

        Return True
    End Function
    Private Function SpecialSigns(ByRef text As String)

        If text.Contains(",") Then Return False
        If text.Contains("?") Then Return False
        If text.Contains(":") Then Return False
        If text.Contains("°") Then Return False
        If text.Contains("[") Then Return False
        If text.Contains("]") Then Return False
        If text.Contains("{") Then Return False
        If text.Contains("}") Then Return False
        If text.Contains(".") Then Return False
        If text.Contains("-") Then Return False
        If text.Contains("#") Then Return False
        If text.Contains("$") Then Return False
        If text.Contains("?") Then Return False
        If text.Contains("/") Then Return False
        If text.Contains("*") Then Return False
        If text.Contains("@") Then Return False
        If text.Contains("%") Then Return False
        If text.Contains("¨") Then Return False
        If text.Contains("&") Then Return False
        If text.Contains("*") Then Return False
        If text.Contains("(") Then Return False
        If text.Contains(")") Then Return False
        If text.Contains("1") Then Return False
        If text.Contains("2") Then Return False
        If text.Contains("3") Then Return False
        If text.Contains("4") Then Return False
        If text.Contains("5") Then Return False
        If text.Contains("6") Then Return False
        If text.Contains("7") Then Return False
        If text.Contains("8") Then Return False
        If text.Contains("9") Then Return False

        Return True
    End Function

    Public Function ReadCPF(ByVal text As String)
        Attempts = 5
        Dim CPFvalid As String

        While True
            Try

                If Attempts = 0 Then
                    Console.WriteLine(Me.MaximumAttempts())
                    Return Nothing
                End If

                Attempts -= 1
                Console.Write(text)
                CPFvalid = Console.ReadLine()

                Dim checker = Me.TestCPFValid(CPFvalid)
                Console.Clear()

                If checker Then Return Me.CPFRemoveSpace(CPFvalid)

                Throw New InvalidOperationException($"{vbCrLf} CPF incorreto. Tente Novamente{vbCrLf}")

            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try

        End While

        Return Nothing
    End Function
    Private Function TestCPFValid(ByVal text As String) As String

        Dim cpf = Me.CPFRemoveSpace(text)

        If Not LenCpf(cpf) Then Return False

        If Not NumericalSequenceCpf(cpf) Then Return False

        If Not CalcTwoNumberCpf(cpf) Then Return False

        Return True
    End Function
    Private Function CPFRemoveSpace(ByVal cpf As String)

        cpf = Trim(cpf.Replace(".", "").Replace("-", ""))
        Return cpf
    End Function
    Private Function LenCpf(ByVal cpf As String)

        If cpf.Length <> 11 Then Return False

        Return True
    End Function
    Private Function NumericalSequenceCpf(ByVal cpf As String)

        Dim sequence0 As String = "00000000000"
        Dim sequence1 As String = "11111111111"

        If cpf.Equals(sequence0) Then Return False

        If cpf.Equals(sequence1) Then Return False

        Return True
    End Function
    Private Function CalcTwoNumberCpf(ByVal cpf As String)

        Dim firstDigit As Integer = Me.CalcFirstDigitCpf(cpf)
        Dim secondDigit As Integer = Me.CalcSecondDigitCpf(cpf, firstDigit)

        Dim valid As Boolean = Me.CheckTwoDigitCpf(cpf, firstDigit, secondDigit)

        If cpf Then Return True

        Return False
    End Function
    Private Function CalcFirstDigitCpf(ByVal cpf As String)
        Dim sum As Integer = 0

        For i As Integer = 0 To 8
            sum += (Convert.ToInt32(cpf(i).ToString()) * (10 - i))
        Next

        Dim firstDigit As Integer = 11 - (sum Mod 11)
        If firstDigit > 9 Then
            firstDigit = 0
        End If

        Return firstDigit
    End Function
    Private Function CalcSecondDigitCpf(ByVal cpf As String, ByVal firstDigit As Integer)
        Dim sum As Integer = 0

        For i As Integer = 0 To 8
            sum += (Convert.ToInt32(cpf(i).ToString()) * (11 - i))
        Next

        sum += (firstDigit * 2)
        Dim secondDigit As Integer = 11 - (sum Mod 11)
        If secondDigit > 9 Then
            secondDigit = 0
        End If

        Return secondDigit
    End Function
    Private Function CheckTwoDigitCpf(ByVal cpf As String, ByVal first As Integer, ByVal second As Integer)

        If (Convert.ToInt32(cpf(9).ToString()) = first) AndAlso (Convert.ToInt32(cpf(10).ToString()) = second) Then Return True

        Return False
    End Function

    Public Function ReadBirthday(ByVal text As String)
        Attempts = 5
        Dim birthday As String

        While True
            Try

                If Attempts = 0 Then
                    Console.WriteLine(Me.MaximumAttempts)
                    Return Nothing
                End If

                Attempts -= 1
                Console.Write(text)
                birthday = Trim(Console.ReadLine())

                If Me.ValidBirthDay(birthday) Then
                    birthday = Me.StyleBirthDay(birthday)
                    Return birthday
                End If

            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try

        End While

        Return Nothing
    End Function
    Private Function ValidBirthDay(ByVal birthday As String)

        birthday = Me.RemoveBarsBirthday(birthday)

        Console.Clear()
        If Not Me.LenBirthday(birthday) Then Throw New InvalidOperationException($"{vbCrLf} Estilo de Data Incorreto.{vbCrLf}")

        If Not Me.CheckDay(birthday) Then Throw New InvalidOperationException($"{vbCrLf} DIA Estar Incorreto.{vbCrLf}")

        If Not Me.CheckMonth(birthday) Then Throw New InvalidOperationException($"{vbCrLf} MÊS Estar Incorreto.{vbCrLf}")

        If Not Me.CheckYear(birthday) Then Throw New InvalidOperationException($"{vbCrLf} Idade Mínima: 18{vbCrLf}")

        Return True
    End Function
    Private Function RemoveBarsBirthday(ByVal birthday As String)

        birthday = birthday.Replace("/", "")
        Return birthday
    End Function
    Private Function LenBirthday(ByVal birthday As String)

        If birthday.Length <> 8 Then Return False

        Return True
    End Function
    Private Function CheckYear(ByVal birthday As String)

        Dim year = Mid(birthday, 5, 4)

        If year < 1900 Then Throw New InvalidOperationException($"{vbCrLf} ANO Está Incorreto.{vbCrLf}")

        If (DateTime.Year - year) < 18 Then Return False

        Return True
    End Function
    Private Function CheckMonth(ByVal birthday As String)

        Dim month = Mid(birthday, 3, 2)

        If month > 12 Then Return False

        If month < 1 Then Return False

        Return True
    End Function
    Private Function CheckDay(ByVal birthday As String)
        Dim day = Mid(birthday, 1, 2)

        If day > 31 Then Return False

        If day < 1 Then Return False

        Return True
    End Function
    Private Function StyleBirthDay(ByVal birthday As String)

        birthday = Me.RemoveBarsBirthday(birthday)
        birthday = Mid(birthday, 1, 2) & "/" & Mid(birthday, 3, 2) & "/" & Mid(birthday, 5, 5)

        Return birthday
    End Function

    Public Function ReadPassWord(ByVal text As String)
        Attempts = 5
        Dim password As Integer

        While True
            Try

                If Attempts = 0 Then
                    Console.WriteLine(Me.MaximumAttempts)
                    Return Nothing
                End If

                Attempts -= 1
                Console.Write(text)
                password = Trim(Console.ReadLine())

                Console.Clear()
                Dim valid = Me.LenPassword(password)

                If valid Then Return password

            Catch ex As InvalidOperationException
                Console.Clear()
                Console.WriteLine(ex.Message)
            Catch ex As Exception
                Console.Clear()
                Console.WriteLine($"{vbCrLf} Tipo De Valor Inválido.{vbCrLf}")
            End Try

        End While

        Return Nothing
    End Function
    Private Function LenPassword(ByVal passsword As String)

        If passsword = 0 Then Throw New InvalidOperationException($"{vbCrLf} Sua Senha Precisa ser Diferente De 0.{vbCrLf}")

        If passsword.Length <> 6 Then Throw New InvalidOperationException($"{vbCrLf} Tamanho da Senha Inválido.{vbCrLf}")

        Return True
    End Function
    Public Function ReadTransactionPassWord()
        Attempts = 5
        Dim passWord As Integer

        While True
            Try

                If Attempts = 0 Then
                    Return Nothing
                End If

                Attempts -= 1
                Console.Write($"{vbCrLf}Insira sua Senha: ")
                passWord = Trim(Console.ReadLine())

                Return passWord

            Catch ex As Exception
                Console.Clear()
                Console.WriteLine($"{vbCrLf} Tipo De Valor Inválido.{vbCrLf}")
            End Try

        End While

        Return Nothing
    End Function

    Public Function CheckValue(ByVal type As String, ByVal minimumValue As Double)
        Attempts = 5
        Dim value As Double

        While True
            Try

                If Attempts = 0 Then
                    Console.Clear()
                    Console.WriteLine(Me.MaximumAttempts)
                    Return Nothing
                End If

                Attempts -= 1
                Console.Write($"Valor do {type}: R$")
                value = Trim(Console.ReadLine())

                If value >= minimumValue Then Return value

                Throw New InvalidOperationException($"{vbCrLf} Valor Mínimo para {type}: R$ {minimumValue} {vbCrLf}")

            Catch ex As InvalidOperationException
                Console.Clear()
                Console.WriteLine(ex.Message)
            Catch exw As Exception
                Console.Clear()
                Console.WriteLine($"{vbCrLf} Tipo de Valor Inválido.{vbCrLf}")
            End Try

        End While

        Return Nothing
    End Function
    Public Function ReadOption(ByVal min As Integer, ByVal max As Integer)
        Attempts = 5
        Dim optionsUser As Integer
        Dim bank As New Bank

        While True
            Try
                If Attempts = 0 Then
                    Return Nothing
                End If

                Attempts -= 1
                Console.Write("Opção: ")
                optionsUser = Console.ReadLine()

                If optionsUser < min Or optionsUser > max Then
                    Console.WriteLine($"{vbCrLf} Opção Inválida, Digite Novamente.  {vbCrLf}")
                Else
                    Return optionsUser
                End If

            Catch ex As Exception

                Console.WriteLine($"{vbCrLf} Tipo De Valor Inválido.{vbCrLf}")
            End Try

        End While

        Return Nothing
    End Function
    Private Function MaximumAttempts()
        Console.Clear()
        Return $"{vbCrLf} Você Excedeu O Número de Tentativas.{vbCrLf}"
    End Function
End Class
