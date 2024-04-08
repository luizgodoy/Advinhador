/// <summary>
/// Desafio pos-tech inaugural
/// https://github.com/FIAP/DESAFIO_DOTNET_INAUGURAL
/// </summary>
public class Program
{
    private static readonly HttpClient client = new HttpClient();

    static async Task Main(string[] args)
    {
        // Loop infinito para adivinhar vários números
        while (true)
        {
            // Gera um número aleatório de 1 a 100
            int numero = new Random().Next(1, 101);

            // Gera uma letra aleatória do alfabeto (maiúscula ou minúscula)
            char letraInicio = (char)new Random().Next('A', 'Z' + 1);
            char letraFinal = (char)new Random().Next('a', 'z' + 1);

            // Concatena o número com a letra antes e depois
            string chave = letraInicio + numero.ToString() + letraFinal;

            // Cria a requisição para a API
            var requisicao = new HttpRequestMessage(HttpMethod.Get, $"https://fiap-inaugural.azurewebsites.net/fiap?Key={chave}&Grupo=30");

            // Envia a requisição e obtém a resposta
            var resposta = await client.SendAsync(requisicao);

            // Lê o conteúdo da resposta
            string conteudo = await resposta.Content.ReadAsStringAsync();

            // Se a resposta for diferente de "Nope!", imprime o resultado
            if (conteudo != "Nope!")
            {
                Console.WriteLine($"Adivinhado! Chave: {chave}, Resultado: {conteudo}");
            }
        }
    }
}