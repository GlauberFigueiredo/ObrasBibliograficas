using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ObrasBibliograficas.Servico.API
{
    public static class StringExtensao
    {
        private static string PrimeiraLetraMaiuscula(string input)
        {
            return input.Length > 1 ? char.ToUpper(input[0]) + input.Substring(1) : input.ToUpper();
        }

        public static string FormataTitleCase(string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }

        public static string FormataNome(this string nomeCompleto)
        {
            string[] arrayNomeCompleto = nomeCompleto.Split(" ");
            string[] arrayPreposicao = new string[] { "DA", "DE", "DO", "DAS", "DOS" };
            string[] arraySufixo = new string[] { "FILHO", "FILHA", "NETO", "NETA", "SOBRINHO", "SOBRINHA", "JUNIOR" };

            string nome = string.Empty;
            string sobrenome = string.Empty;
            string nomeFormatado = string.Empty;
            //string lastValueArrayName = "";


            for (int i = 0; i < arrayNomeCompleto.Length; i++)
            {
                if (i == 0)
                    nome += PrimeiraLetraMaiuscula(arrayNomeCompleto[i]);
                else if (arrayPreposicao.Contains(arrayNomeCompleto[i].ToUpper()))
                {
                    nome += $" {arrayNomeCompleto[i].ToLower()}";
                }
                else if (arraySufixo.Contains(arrayNomeCompleto[i].ToUpper()) 
                    || (!(i == (arrayNomeCompleto.Length - 1)) && arraySufixo.Contains(arrayNomeCompleto[i + 1].ToUpper())))
                {
                    sobrenome += $" {arrayNomeCompleto[i]}";
                }
                else if (i == (arrayNomeCompleto.Length - 1))
                {
                    sobrenome += $" {arrayNomeCompleto[i]}";
                }
                else
                {
                    nome += $" {PrimeiraLetraMaiuscula(arrayNomeCompleto[i])}";
                }
                //lastValueArrayName = arrayNomeCompleto[i];
            }

            nomeFormatado = string.Join(' ', string.Concat(sobrenome, ",").ToUpper(), nome);
            return nomeFormatado;
        }


    }
}
