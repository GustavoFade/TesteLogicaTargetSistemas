using System.Text.Json;
using System.Text.Json.Serialization;
using TesteTecnicoTargetSistemas.Dto;

namespace TesteTecnicoTargetSistemas.ExerciciosTarget;
public static class TesteTargetSistemas
{
    //Ex 01
    public static void Soma()
    {
        try
        {
            Console.WriteLine("Ex 01");
            var indice = 13;
            var soma = 0;
            var k = 0;
            while (k < indice)
            {
                k = k + 1;
                soma = soma + k;
            }
            System.Console.WriteLine($"Valor da soma: {soma}");
            // Valor da soma: 91
            Console.WriteLine("------------------------------------------");
        }
        catch
        {
           System.Console.WriteLine("Ocorreu um erro no servidor !");
        }
        
    }

    //Ex 02
    public static void CalculoFibonacci()
    {
        try
        {
            Console.WriteLine("Ex 02");
            Console.WriteLine("Digite um número: ");
            long? numeroInformado = long.Parse(Console.ReadLine());
            Console.WriteLine("Resultado: ");
            long currentValue = 0;
            IList<long> listFibonacci = new List<long>();
            listFibonacci.Add(0);

            for (int i = 0; i <= numeroInformado; i++)
            {

                if (currentValue == 0)
                {
                    currentValue = 1;
                } else
                {
                    currentValue = listFibonacci[i - 1] + currentValue; 
                }

                bool numeroInformadoPertenceFibonacci = currentValue == numeroInformado;
                if (numeroInformadoPertenceFibonacci)
                {
                    System.Console.WriteLine("Número informado pertence a sequência de fibonacci !");
                    break;
                }
                bool passouDoNumeroInformado = currentValue > numeroInformado;
                if (passouDoNumeroInformado)
                {
                    System.Console.WriteLine("Número informado não pertence a sequência de fibonacci !");
                    break;
                }
                listFibonacci.Add(currentValue);
            }
            Console.WriteLine("------------------------------------------");
        }
        catch (FormatException)
        {
            System.Console.WriteLine("O input deve conter apenas números !");
        }
        catch
        {
            System.Console.WriteLine("Ocorreu um erro no servidor !");
        }
    }

    //Ex 03
    public static void FaturamentoMes()
    {
        try
        {
            Console.WriteLine("Ex 03");
            var data = File.ReadAllText("./Dados/dados.json");
            var dadosFaturamentos = JsonSerializer.Deserialize<List<DadosFaturamentoDto>>(data);
            
            const decimal diasSemExpediente = 0.0m;
            int? quantidadeDiasUteis = 0;
            decimal? faturamentoTotalDiasUteis = 0;
            decimal? menorFaturamento = null;
            decimal? maiorFaturamento = null;
            foreach (var dadosFaturamentoDia in dadosFaturamentos)
            {
                var valorFaturamentoDia = dadosFaturamentoDia.valor;
                if (menorFaturamento == null)
                {
                    menorFaturamento = valorFaturamentoDia;
                }
                menorFaturamento = valorFaturamentoDia < menorFaturamento 
                    ? valorFaturamentoDia : menorFaturamento;

                if (maiorFaturamento == null)
                {
                    maiorFaturamento = valorFaturamentoDia;
                }
                maiorFaturamento = valorFaturamentoDia > maiorFaturamento 
                    ? valorFaturamentoDia : maiorFaturamento;

                if (valorFaturamentoDia != diasSemExpediente)
                {
                    quantidadeDiasUteis = quantidadeDiasUteis + 1;
                    faturamentoTotalDiasUteis = faturamentoTotalDiasUteis + valorFaturamentoDia;
                }
            }

            Console.WriteLine($"O menor valor de faturamento ocorrido em um dia do mês {menorFaturamento}");
            Console.WriteLine($"O maior valor de faturamento ocorrido em um dia do mês {maiorFaturamento}");


            var media = faturamentoTotalDiasUteis / quantidadeDiasUteis;
            int? quantidadeDeDiasAcimaDaMedia = 0;
            foreach (var dadosFaturamentoDia in dadosFaturamentos)
            {
                var valorFaturamentoDia = dadosFaturamentoDia.valor;
                if (valorFaturamentoDia > media)
                {
                    quantidadeDeDiasAcimaDaMedia = quantidadeDeDiasAcimaDaMedia + 1;
                }
            }
            Console.WriteLine($"Quantidade de dias uteis acima da média {quantidadeDeDiasAcimaDaMedia}");
            Console.WriteLine("------------------------------------------");
        }
        catch
        {
            System.Console.WriteLine("Ocorreu um erro no servidor !");
        }
    }

    //Ex 04
    public static void CalcularPercentualFaturamento()
    {
        try
        {
            Console.WriteLine("Ex 04");
            var dados = new Dictionary<string, decimal>();
            dados.Add("SP",67836.43m);
            dados.Add("RJ",36678.66m);
            dados.Add("MG",29229.88m);
            dados.Add("ES",27165.48m);
            dados.Add("Outros",19849.53m);
            var valorTotal = dados.Sum(x => x.Value);
            foreach (var item in dados)
            {
                var estado = item.Key;
                var faturamentoMes = item.Value;
                var percentual = Math.Round((faturamentoMes*100)/valorTotal,2);
                System.Console.WriteLine($"{estado} tem o percentual de {percentual}%");
            }
            Console.WriteLine("------------------------------------------");
        }
        catch
        {
            System.Console.WriteLine("Ocorreu um erro no servidor !");
        }
    }

    //Ex 05
    public static void InverterCaracteresString()
    {
        try
        {
            Console.WriteLine("Ex 05");
            Console.WriteLine("Digite uma frase: ");
            var frase = Console.ReadLine();
            var fraseRepartida = frase?.ToArray();
            string? fraseInvertida = "";
            for (int i = fraseRepartida.Length - 1; i >= 0 ; i--)
            {
                fraseInvertida = fraseInvertida + fraseRepartida[i];
            }
            System.Console.WriteLine($"String invertida {fraseInvertida}");
            Console.WriteLine("------------------------------------------");
        }
        catch
        {
            System.Console.WriteLine("Ocorreu um erro no servidor !");
        }
    }
}