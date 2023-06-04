using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace DesafioTecnicoSecSaude.Utils
{
    public static class Validation
    {
        public static bool ValidarCep(string cep)
        {
            string pattern = @"^\d{5}-\d{3}|\d{8}$";
            return Regex.IsMatch(cep, pattern);
        }

        public static bool ValidarEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }

        public static bool ValidarCpf(string cpf)
        {
            // Remover caracteres não numéricos do CPF
            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            // Verificar se o CPF tem 11 dígitos
            if (cpf.Length != 11)
                return false;

            // Verificar se todos os dígitos são iguais (CPF inválido)
            if (cpf.Distinct().Count() == 1)
                return false;

            // Calcula o primeiro dígito verificador
            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(cpf[i].ToString()) * (10 - i);
            int primeiroDigito = 11 - (soma % 11);
            if (primeiroDigito >= 10)
                primeiroDigito = 0;

            // Verifica se o primeiro dígito verificador está correto
            if (int.Parse(cpf[9].ToString()) != primeiroDigito)
                return false;

            // Calcula o segundo dígito verificador
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(cpf[i].ToString()) * (11 - i);
            int segundoDigito = 11 - (soma % 11);
            if (segundoDigito >= 10)
                segundoDigito = 0;

            // Verifica se o segundo dígito verificador está correto
            if (int.Parse(cpf[10].ToString()) != segundoDigito)
                return false;

            // CPF válido
            return true;
        }

        public static bool ValidarData(string data)
        {
            DateTime result;

            if (DateTime.TryParse(data, out result))
            {
                if (result == DateTime.MinValue)
                    return false;

                if (result > DateTime.Now)
                    return false;

                return true;
            }
            return false;
        }

        public static bool ValidarContato(string contato)
        {
            string pattern = @"^\d+$";
            return Regex.IsMatch(contato, pattern);
        }

        public static bool ValidarSenha(string senha)
        {
            Regex regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d).+$");
            return regex.IsMatch(senha);
        }
    }
}
