using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace Byte_bank_SharpCoders001
{
    public class Program
    {
        public static string ValidName(string name)
        {
            List<char> allowedLetters = new() { 'a', 'b', 'c', 'd', 'e',
                'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p',
                'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z','A',
                'B','C','D','E','F','G','H','I','J','K','L','M','N',
                'O','P','Q','R','S','T','U','V','W','X','Y','Z',' '};
            for(int i = 0; i < name.Length; i++){
                char character = name[i];

                if (allowedLetters.Contains(character) == false) {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("O nome digitado é invalido, digite nome sem acentos ou caracteres especiais");
                    Console.ResetColor();

                    Console.Write("Digite aqui: ");
                    name = Console.ReadLine();
                    return ValidName(name);
                }
            }
            return name;
        }
        public static string ValidCpf(string cpf)
        {
            if (cpf.Length == 11) {
                List<char> allowedDigits = new() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

                for (int i = 0; i < cpf.Length; i++){
                    char digit = cpf[i];

                    if(allowedDigits.Contains(digit) == false){

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("O CPF digitado é inválido, digite o CPF sem pontos e sem traços como nesse exemplo [00011122233]");
                        Console.ResetColor();

                        Console.Write("Digite aqui: ");
                        cpf = Console.ReadLine();
                        return ValidCpf(cpf);
                    }
                }
            }
            else{
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("O CPF digitado é inválido, digite o CPF sem pontos e sem traços como nesse exemplo [00011122233]");
                Console.ResetColor();

                Console.Write("Digite aqui: ");
                cpf = Console.ReadLine();
                return ValidCpf(cpf);
            }
            return cpf;
        }
        public static string ValidEmail(string email, List<string> clients)
        {
            if (clients.Contains(email) == true){

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("O email cadastrado já existe em nossa base, digite um novo e-mail");
                Console.ResetColor();

                Console.Write("Digite aqui: ");
                email = Console.ReadLine();
                return ValidEmail(email, clients);
            }
            else{
                List<char> allowedLetters = new() { 'a', 'b', 'c', 'd', 'e',
                'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p',
                'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z','@',
                '_','-','.','0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
                for (int i = 0; i < email.Length; i++){
                    char character = email[i];

                    if (allowedLetters.Contains(character) == false){

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("O email digitado é invalido, digite o email todo minúsculo, sem acentos, espaços ou caracteres proibidos como: (',',';',':','/','*','%','$','#')");
                        Console.ResetColor();

                        Console.Write("Digite aqui: ");
                        email = Console.ReadLine();
                        return ValidEmail(email, clients);
                    }
                }
                return email;
            }            
        }
        public static string ValidPhone(string phone)
        {
            if (phone.Length == 11){

                List<char> allowedDigits = new() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                for (int i = 0; i < phone.Length; i++){
                    char digit = phone[i];
                    
                    if (allowedDigits.Contains(digit) == false){

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("O telefone digitado é inválido, digite seu telefone sem pontos e traços com 11 digitos sendo os dois primeiros para DDD");
                        Console.ResetColor();

                        Console.Write("Digite aqui: ");
                        phone = Console.ReadLine();
                        return ValidPhone(phone);
                    }
                }

            }
            else{
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("O telefone digitado é inválido, digite seu telefone sem pontos e traços com 11 digitos sendo os dois primeiros para DDD");
                Console.ResetColor();

                Console.Write("Digite aqui: ");
                phone = Console.ReadLine();
                return ValidPhone(phone);
            }
            return phone;
        }
        public static string ValidPassword(string password)
        {
            if (password.Length == 6)
            {
                List<char> allowedDigits = new() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

                for (int i = 0; i < password.Length; i++)
                {
                    char digit = password[i];

                    if (allowedDigits.Contains(digit) == false)
                    {

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("A senha digitada precisa possuir 6 digitos numéricos");
                        Console.ResetColor();

                        Console.Write("Digite aqui: ");
                        password = Console.ReadLine();
                        return ValidPassword(password);
                    }
                }
            }
            else
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("A senha digitada precisa possuir 6 digitos numéricos");
                Console.ResetColor();

                Console.Write("Digite aqui: ");
                password = Console.ReadLine();
                return ValidPassword(password);
            }
            return password;
        }
        public static List<string> ChoiceDeposit(List<string> clients, string action)
        {
            Console.Write("Insira um valor a ser depositado (digite apenas números): ");
            //fazer validação de valores
            double valueDeposit = double.Parse(Console.ReadLine());
            action = "depositar na";
            int indexAcc = IdAccount(clients, action);

            string name = clients[indexAcc - 1];
            string cpf = clients[indexAcc];
            string email = clients[indexAcc + 1];
            string phone = clients[indexAcc + 2];
            string balance = clients[indexAcc + 3];

            Console.WriteLine($"Nome do beneficiário: {name}");
            Console.WriteLine($"Cpf do beneficiário: {cpf}");
            Console.WriteLine($"Email do beneficiário: {email}");
            Console.WriteLine($"Telefone do beneficiário: {phone}");
            Console.WriteLine("");
            Console.WriteLine("Deseja confirmar o Depósito?");
            Console.WriteLine("Para sim digite -------------- [1]");
            Console.WriteLine("Para não digite -------------- [2]");
            Console.Write("Digite aqui: ");
            string choice = Console.ReadLine();

            for (bool i = true; i == true;)
            {
                if (choice == "1")
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Depósito Realizado");
                    Console.ResetColor();

                    double deposit = double.Parse(balance) + valueDeposit;
                    clients[indexAcc+3] = deposit.ToString();

                    i = false;
                }
                else if (choice == "2")
                {
                    ChoiceDeposit(clients, action);
                    i = false;
                }
                else
                {
                    i = true;
                }
            }
             return clients;
        }
        public static int IdAccount(List <string> clients, string action)
        {
            Console.Write("Insira o CPF de uma conta existente para buscar uma conta: ");
            string cpf = Console.ReadLine();
            cpf = ValidCpf(cpf);
            int indexAcc = 0;

            if(clients.IndexOf(cpf) == -1){

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("O Cpf não foi encontrado");
                Console.ResetColor();

                ExternalMenu(clients, action);        
            }
            else{
                List<int> accounts = new();
                int options = 1;
                for(int i = 0; i < clients.Count; i++){
                    if (clients[i] == cpf){
                        accounts.Add(i);
                        Console.WriteLine($"Se você deseja {action} conta vinculada ao e-mail {clients[i+1]} digite ----- [{options}]");
                        options++;
                    }
                }
                int acc = 0;
                for(bool i = true; i == true;)
                {
                    Console.Write("Digite Aqui: ");
                    acc = int.Parse(Console.ReadLine());

                    if(acc < 0 || acc > accounts.Count){
                        Console.WriteLine("Digite aqui uma opção válida: ");
                        acc = int.Parse(Console.ReadLine());

                    }
                    else
                        i = false;
                }
                
                int choice = acc - 1;
                indexAcc = accounts[choice];
            }
            return indexAcc;
        }
        public static List<string> ChoiceTransfer(List<string> clients, int indexAcc, string action)
        {
            Console.Write("Insira um valor a ser transferido (digite apenas números): ");
            //fazer validação de valores
            double valueTransfer = double.Parse(Console.ReadLine());
            action = "transferir para a";
            int indexBenef = IdAccount(clients, action);

            string name = clients[indexBenef - 1];
            string cpf = clients[indexBenef];
            string email = clients[indexBenef + 1];
            string phone = clients[indexBenef + 2];
            string balance = clients[indexBenef + 3];

            Console.WriteLine($"Nome do beneficiário: {name}");
            Console.WriteLine($"Cpf do beneficiário: {cpf}");
            Console.WriteLine($"Email do beneficiário: {email}");
            Console.WriteLine($"Telefone do beneficiário: {phone}");
            Console.WriteLine("");
            Console.WriteLine("Deseja confirmar a transferência?");
            Console.WriteLine("Para sim digite -------------- [1]");
            Console.WriteLine("Para não digite -------------- [2]");
            Console.Write("Digite aqui: ");
            string choice = Console.ReadLine();

            for (bool i = true; i == true;)
            {
                if (choice == "1")
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Transferência Realizada");
                    Console.ResetColor();

                    double transfer = double.Parse(balance) + valueTransfer;
                    clients[indexBenef + 3] = transfer.ToString();

                    double newBalance = double.Parse(clients[indexAcc + 3]) - valueTransfer;
                    clients[indexAcc + 3] = newBalance.ToString();

                    i = false;
                }
                else if (choice == "2")
                {
                    ChoiceTransfer(clients, indexAcc, action);
                    i = false;
                }
                else
                {
                    i = true;
                }
            }
            return clients;
        }
        public static List<string> RemoveFund(List<string> clients, int indexAcc,string action)
        {
            Console.Write("Insira um valor que você deseja sacar (digite apenas números): ");
            //fazer validação de valores
            double valueRemove = double.Parse(Console.ReadLine());

            string name = clients[indexAcc - 1];
            string cpf = clients[indexAcc];
            string email = clients[indexAcc + 1];
            string phone = clients[indexAcc + 2];
            string balance = clients[indexAcc + 3];

            Console.WriteLine("");
            Console.WriteLine("Deseja confirmar o saque?");
            Console.WriteLine("Para sim digite -------------- [1]");
            Console.WriteLine("Para não digite -------------- [2]");
            Console.Write("Digite aqui: ");
            string choice = Console.ReadLine();

            for (bool i = true; i == true;)
            {
                if (choice == "1")
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Saque Realizado, confira as notas");
                    Console.ResetColor();

                    double newBalance = double.Parse(balance) - valueRemove;
                    clients[indexAcc + 3] = newBalance.ToString();

                    i = false;
                }
                else if (choice == "2")
                {
                    RemoveFund(clients, indexAcc, action);
                    i = false;
                }
                else
                {
                    i = true;
                }
            }
            return clients;
        }
        public static List<string> DeleteAccount(List<string> clients, int indexAcc)
        { 
            clients.RemoveRange((indexAcc - 1),6);
            return clients;
        }
        public static void EnterAccount(List<string> clients, int indexAcc,string action)
        {
            Console.WriteLine($"Login: {clients[indexAcc+1]}");
            Console.Write("Senha: ");
            string password = Console.ReadLine();

            if(password == clients[indexAcc + 4])
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Sua senha está correta");
                Console.ResetColor();
                Console.WriteLine("");
                AccountMenu(clients, indexAcc, action);
                
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Sua senha está incorreta");
                Console.ResetColor();
                Console.WriteLine("");
                EnterAccount(clients, indexAcc, action);
            }
        }

        public static string[] NewAccount(List<string> clients)
        {
            Console.Write("Digite seu nome completo aqui sem acentos: ");
            string name = Console.ReadLine();
            name = ValidName(name);

            Console.Write("Cadastre seu CPF sem pontos e sem traços como nesse exemplo");
            Console.Write("[12345678900]: ");
            string cpf = Console.ReadLine();
            cpf = ValidCpf(cpf);

            Console.Write("Cadastre um email não cadastrado anteriormente, ele será seu identificador para futuros acessos: ");
            string email = Console.ReadLine();
            email = ValidEmail(email,clients);

            Console.Write("Cadastre um número de telefone sem pontos e traços com 11 digitos sendo os dois primeiros para DDD: ");
            string phone = Console.ReadLine();
            phone = ValidPhone(phone);

            string balance = "0";

            Console.Write("Digite uma senha de 6 dígitos com apenas números: ");
            string password = Console.ReadLine();
            password = ValidPassword(password);

            string[] newAcc = new string[6] { name, cpf, email, phone, balance, password };

            return newAcc;
        }
        public static void AccountMenu(List<string> clients, int indexAcc, string action)
        {
            string name = clients[indexAcc - 1];
            string cpf = clients[indexAcc];
            string email = clients[indexAcc + 1];
            string phone = clients[indexAcc + 2];
            string balance = clients[indexAcc + 3];
            string password = clients[indexAcc + 4];

            Console.WriteLine($"Seja bem vindo, {name}, a sua conta registrada no e-mail: {email}");
            Console.WriteLine($"Cpf: {cpf}");
            Console.WriteLine($"Telefone: {phone}");
            Console.WriteLine($"Saldo: {balance}");
            Console.WriteLine("Escolha uma das opções abaixo para seguirmos");
            Console.WriteLine("");
            Console.WriteLine("Para fazer uma transferência digite ------- [1]");
            Console.WriteLine("Para fazer um saque digite ---------------- [2]");
            Console.WriteLine("Para apagar a conta ----------------------- [3]");
            Console.WriteLine("Para sair da conta ------------------------ [4]");
            Console.Write("Digite aqui uma opção: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1": 
                    ChoiceTransfer(clients, indexAcc, action);
                    AccountMenu(clients, indexAcc, action);
                    return;
                case "2":
                    RemoveFund(clients, indexAcc, action);
                    AccountMenu(clients, indexAcc, action);
                    return;
                case "3":
                    DeleteAccount(clients, indexAcc);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"Conta Apagada com Sucesso");
                    Console.ResetColor();
                    ExternalMenu(clients, action);
                    return;
                case "4":
                    //Sair da conta
                    ExternalMenu(clients, action);
                    return;
            }
        }
        public static void ExternalMenu(List<string> clients, string action)
        {
            Console.WriteLine("");
            Console.WriteLine($"Seja bem vindo(a), ao menu incial Byte Bank");
            Console.WriteLine("Escolha uma das opções abaixo para seguirmos");
            Console.WriteLine("");
            Console.WriteLine("Criar uma conta no Byte Bank ----------- [1]");
            Console.WriteLine("Entrar em uma conta -------------------- [2]");
            Console.WriteLine("Realizar um depósito digite ------------ [3]");
            Console.WriteLine("Sair do Byte Bank ---------------------- [4]");
            Console.Write("Digite aqui uma opção: ");
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":                   
                    clients.AddRange(NewAccount(clients));
                    ExternalMenu(clients, action);
                    return;
                case "2":
                    int indexAcc = IdAccount(clients, action);
                    EnterAccount(clients,indexAcc, action);
                    return;
                case "3":
                   ChoiceDeposit(clients, action);
                    ExternalMenu(clients, action);
                    return;
                case "4":
                    //Sair do ByteBank
                    return;
            }
        }
        public static void Main(string[] args)
        {
            List<string> clients = new();
            string action = "";

            ExternalMenu(clients, action);

            








        }
    }
}