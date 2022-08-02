using Ioutility.AmbienteConfig.Enums;
using Ioutility.AmbienteConfig.Services;

Console.WriteLine("----------------------------------------------------------------------------");
Console.WriteLine("Bem vindo ao configurador de ambiente da Pulsati (projeto: Ioutility)");


EOperacao operacao;
do
{
    operacao = ObterOperacao();
    var commandHandler = new AmbienteService();
    switch (operacao)
    {
        case EOperacao.ClonarRepositorios_1:
            commandHandler.ClonarRepositorios();
            break;
        case EOperacao.PullRepositorios_2:
            commandHandler.PullRepositorios();
            break;
        case EOperacao.RealizarBuildTodasImagens_3:
            commandHandler.BuildarImagensDocker();
            break;
        case EOperacao.Encerrar_10:
            break;
        default:
            break;
    }
    if (operacao != EOperacao.Encerrar_10)
        Console.WriteLine("Operação realizada com sucesso");
    commandHandler.Dispose();
    Console.WriteLine("");

} while (operacao != EOperacao.Encerrar_10);
Console.WriteLine("Configurador finalizado.");

static EOperacao ObterOperacao()
{
    EOperacao operacao;
    Console.WriteLine("----------------------------------------------------------------------------");
    Console.WriteLine("");
    Console.WriteLine("Selecione abaixo a operação que vc deseja realizar: ");
    Console.WriteLine($"{(int)EOperacao.ClonarRepositorios_1} Clonar repositorios");
    Console.WriteLine($"{(int)EOperacao.PullRepositorios_2} Atualizar repositorios (pull)");
    Console.WriteLine($"{(int)EOperacao.RealizarBuildTodasImagens_3} Realizar build de todas as imagens docker");
    Console.WriteLine($"{(int)EOperacao.ExecutarDockerCompose_4} Executar docker compose");
    operacao = (EOperacao)int.Parse(Console.ReadLine()!);
    Console.WriteLine("Iniciando operação:");
    Console.WriteLine("----------------------------------------------------------------------------");

    return operacao;
}