using System.ComponentModel.DataAnnotations;
using DesafioFundamentos.Models;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

decimal precoInicial = 0;
decimal precoPorHora = 0;
bool control = true;

while (control)
{
    //executa loop até os valores estarem corretos
    Console.WriteLine("Seja bem vindo ao sistema de estacionamento!\n" +
                  "Digite o preço inicial:");
    bool precoInicialIsDecimal = decimal.TryParse(Console.ReadLine(), out precoInicial);

    Console.WriteLine("Agora digite o preço por hora:");
    bool precoPorHoraIsDecimal = decimal.TryParse(Console.ReadLine(), out precoPorHora);

    if (!precoInicialIsDecimal && !precoPorHoraIsDecimal)
    {
        Console.WriteLine("Os valores de preço inicial e preço por hora devem ser números.\n" +
        "Pressiona qualquer tecla para tentar novamente.");
        Console.ReadLine();
    }
    else
    {
        control = false;
    }

}

// Instancia a classe Estacionamento, já com os valores obtidos anteriormente
Estacionamento es = new(precoInicial, precoPorHora);

string opcao = string.Empty;
bool exibirMenu = true;

// Realiza o loop do menu
while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Encerrar");

    try
    {
        switch (Console.ReadLine())
        {
            case "1":
                es.AdicionarVeiculo();
                break;

            case "2":
                es.RemoverVeiculo();
                break;

            case "3":
                es.ListarVeiculos();
                break;

            case "4":
                exibirMenu = false;
                break;

            default:
                Console.WriteLine("Opção inválida");
                break;
        }

    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        Console.WriteLine();
    }

    Console.WriteLine("Pressione uma tecla para continuar");
    Console.ReadLine();
}

Console.WriteLine("O programa se encerrou");
